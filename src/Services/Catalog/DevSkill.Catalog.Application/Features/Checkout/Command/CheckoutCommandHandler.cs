using DevSkill.Catalog.Application.Contracts;
using DevSkill.Catalog.Application.Contracts.Persistence;
using DevSkill.Catalog.Application.Exceptions;

using DevSkill.Integration.Messages;
using MassTransit;
using MassTransit.Transports;
using MediatR;

namespace DevSkill.Catalog.Application.Features.Checkout.Command;
public class CheckoutCommandHandler : IRequestHandler<CheckoutCommand, CheckoutCommandResponse>
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILoggedInUserService _loggedInUserService;
    private readonly IPublishEndpoint _publishEndpoint;

    public CheckoutCommandHandler(ICourseRepository courseRepository, ILoggedInUserService loggedInUserService, IPublishEndpoint publishEndpoint)
    {
        _courseRepository = courseRepository;
        _loggedInUserService = loggedInUserService;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<CheckoutCommandResponse> Handle(CheckoutCommand request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(request.CourseId);

        if (course == null)
        {
            throw new NotFoundException("Course Not Found", request.CourseId);
        }

        try
        {
            var checkoutMessage =  new CheckoutRequestMessage
            {
                Id = Guid.NewGuid(),
                UserId = _loggedInUserService.UserId,
                CreationDateTime = DateTime.Now,
                CourseId = request.CourseId,
                CoursePrice = course.Price,
                CourseName = course.Name,
                Country = request.Country,
                PostalCode = request.PostalCode,
                NameOnCard = request.NameOnCard,
                CreditCardNumber = request.CreditCardNumber,
                SecuityCode = request.SecuityCode,
                ExpirationDate = request.ExpirationDate
            };

            await _publishEndpoint.Publish(checkoutMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new CheckoutCommandResponse();
    }
}

