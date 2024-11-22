﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingCommand : IRequest
    {
        public int ID { get; set; }

        public RemoveOrderingCommand(int id)
        {
            ID = id;
        }
    }
}
