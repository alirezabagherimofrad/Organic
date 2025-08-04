using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.Product
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string? Description { get; set; }

        public int Stock { get; set; }

        public ICollection<IFormFile> ProductImages { get; set; } = new List<IFormFile>();

        public List<Guid>? DeletedImageIds { get; set; }
    }
}
