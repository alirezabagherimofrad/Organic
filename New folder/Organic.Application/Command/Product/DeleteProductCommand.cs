using MediatR;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.Product
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }

        public Guid ProductImageId { get; set; }
    }
}
