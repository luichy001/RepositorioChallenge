using Backend.Me.Contracts;
using Backend.Me.Domain.Contracts.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Backend.Me.Domain.StatusHandler;

namespace Backend.Me.Domain
{
    public interface IStatusHandler
    {
        StatusRetornoModel Handle(StatusCommand request);
    }
}
