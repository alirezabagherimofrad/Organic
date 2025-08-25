using MediatR;
using Organic.Application.DTO;
using Organic.Domain.Model.Address;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Command
{
    public class SendInformationCommand : IRequest<SendInformationDTO>
    {

    }
}
