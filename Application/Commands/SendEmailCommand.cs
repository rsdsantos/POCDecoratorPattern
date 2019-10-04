using Communication.API.Application.Models;
using Communication.API.Domain.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Communication.API.Application.Commands
{
    public class SendEmailCommand : ICommand
    {
        public string From { get; set; }
        [Required]
        public IList<string> To { get; set; }
        public IList<string> Cc { get; set; }
        public IList<string> Bcc { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public IList<AttachmentFile> Attachment { get; set; }

        public SendEmailCommand(string from, IList<string> to, IList<string> cc, IList<string> bcc, string subject, string body, IList<AttachmentFile> attachment)
        {
            From = from;
            To = to;
            Cc = cc;
            Bcc = bcc;
            Subject = subject;
            Body = body;
            Attachment = attachment;
        }
    }
}
