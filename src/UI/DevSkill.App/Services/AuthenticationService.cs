using Blazored.LocalStorage;
using DevSkill.App.Auth;
using DevSkill.App.Contracts;
using DevSkill.App.Services.Base.Catalog;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;

namespace DevSkill.App.Services;

public class AuthenticationService : BaseCatalogDataService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(ICatalogClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> Authenticate(string email, string password)
    {
        try
        {
            AuthenticationRequest authenticationRequest = new AuthenticationRequest() { Email = email, Password = password };
            var authenticationResponse = await _client.AuthenticateAsync(authenticationRequest);

            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(email);
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authenticationResponse.Token);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
        var response = await _client.RegisterAsync(registrationRequest);

        if (!string.IsNullOrEmpty(response.UserId))
        {
            return true;
        }
        return false;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("token");
        ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
        _client.HttpClient.DefaultRequestHeaders.Authorization = null;
    }
}