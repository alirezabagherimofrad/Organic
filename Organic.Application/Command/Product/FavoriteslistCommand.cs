using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command.Product
{
    public class FavoriteslistCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
