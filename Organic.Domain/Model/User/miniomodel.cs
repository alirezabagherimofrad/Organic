using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Domain.Model.User
{
    public class miniomodel
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; }

        private miniomodel() { }

        public miniomodel(string url)
        {
            Id = Guid.NewGuid();
            Url = url;
        }

        public void setUrl(string url)
        {
            Url = url;
        }
    }
}
