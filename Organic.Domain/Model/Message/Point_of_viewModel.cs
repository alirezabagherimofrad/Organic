using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.Message
{
    public class Point_of_viewModel
    {
        public Guid Id { get; private set; }
        public string Score { get; private set; }
        public string Subject { get; private set; }
        public string FullName { get; private set; }
        public DateTime Date { get; private set; }
        public string View { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; } = string.Empty;

        public Point_of_viewModel(string score, string subject, string fullName, DateTime date, string view, string email, string description)
        {
            Id=Guid.NewGuid();
            Score=score;
            Subject=subject;
            FullName=fullName;
            Date=date;
            View=view;
            Email=email;
            Description=description;
        }
        private Point_of_viewModel() { }
    }
}
