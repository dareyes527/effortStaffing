using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using SendGrid;
using SendGrid.Helpers.Mail;
using EffortStaffing.ViewModels;
using EffortStaffing.Models;
using Microsoft.Extensions.Options;

namespace EffortStaffing.Services
{
    public class EffortStaffingMailService
    {
        private readonly SendGridClient _client;
        //private string apiKey = "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";
        private static readonly string MessageId = "X-Message-Id";
        //private string subject = "EffortStaffing website contact us";
        //private string fromToEmail = "sales@effort.com";
        private readonly EmailOptions _emailOptions;

        public EffortStaffingMailService(EmailOptions emailOptions)
        {
            _emailOptions = emailOptions;
            _client = new SendGridClient(_emailOptions.APIkey);
            //_client = new SendGridClient(apiKey);
        }

        public EmailResponse Send(ContactFormViewModel contact)
        {
            var emailMessage = new SendGridMessage()
            {
                //From = new EmailAddress(fromToEmail),
                //Subject = subject,
                From = new EmailAddress(_emailOptions.ContactUsFromEmail),
                Subject = _emailOptions.ContactUsSubject,
                HtmlContent = String.Format(@"Name: {0}
                                            <br /> Email: {1}
                                            <br /> Phone: {2}
                                            <br /> Message: {3}", contact.Name, contact.Email, contact.Phone, contact.Message)
            };

            emailMessage.AddTo(new EmailAddress(_emailOptions.ContactUsToEmail));

            return ProcessResponse(_client.SendEmailAsync(emailMessage).Result);
        }

        private EmailResponse ProcessResponse(Response response)
        {
            if (response.StatusCode.Equals(System.Net.HttpStatusCode.Accepted)
                || response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                return ToMailResponse(response);
            }
            var errorResponse = response.Body.ReadAsStringAsync().Result;

            throw new EmailServiceException(response.StatusCode.ToString(), errorResponse);
        }

        private static EmailResponse ToMailResponse(Response response)
        {
            if (response == null)
                return null;

            var headers = (HttpHeaders)response.Headers;
            var messageId = headers.GetValues(MessageId).FirstOrDefault();
            return new EmailResponse()
            {
                UniqueMessageId = messageId,
                DateSent = DateTime.UtcNow,
            };

        }
    }
}