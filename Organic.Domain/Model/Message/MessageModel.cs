using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Message
{
    public class MessageModel
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public string Email { get; private set; }
        public Status Status { get; private set; }

        private MessageModel() { }

        public MessageModel(string fullName, string title, string description, Status status, string email)
        {
            Id=Guid.NewGuid();
            FullName=fullName;
            Title=title;
            Description=description;
            Status=status;
            Email=email;
        }
        public void AddMessage(string fullName, string title, string description, string email)
        {
            FullName=fullName;
            Title=title;
            Description=description;
            Email=email;
        }
    }
    public enum Status
    {
        [Display(Name = "پاسخ داده شده.")]
        Answered,
        [Display(Name = "پاسخ داده نشده.")]
        Not_answered
    }
}
