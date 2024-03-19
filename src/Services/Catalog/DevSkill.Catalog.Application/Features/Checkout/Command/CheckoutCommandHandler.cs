using DevSkill.Catalog.Application.Contracts;
using DevSkill.Catalog.Application.Contracts.Persistence;
using DevSkill.Catalog.Application.Exceptions;
using DevSkill.Catalog.Application.Features.Checkout.Messages;
using DevSkill.Integration.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Catalog.Application.Features.Checkout.Command;
public class CheckoutCommandHandler : IRequestHandler<CheckoutCommand, CheckoutCommandResponse>
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILoggedInUserService _loggedInUserService;
    private readonly IMessageBus _messageBus;

    public CheckoutCommandHandler(ICourseRepository courseRepository, ILoggedInUserService loggedInUserService, IMessageBus messageBus)
    {
        _courseRepository = courseRepository;
        _loggedInUserService = loggedInUserService;
        _messageBus = messageBus;
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
            var message =  new CheckoutRequestMessage
            {
                Id = Guid.NewGuid(),
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
            await _messageBus.PublishMessage(message, "checkoutmessage");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new CheckoutCommandResponse();
    }
}

