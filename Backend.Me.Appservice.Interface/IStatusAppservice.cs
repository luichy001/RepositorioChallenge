using Backend.Me.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Me.Appservice.Interface
{
    public interface IStatusAppservice
    {
        StatusRetornoVM Validar(StatusRequestVM request);
    }
}
