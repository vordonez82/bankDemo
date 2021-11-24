using BankDemo.Entities;
using BankDemo.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Services.Mappers
{
    public interface IMovementMapper
    {
        Movement Map(AddMovementRequest request);
    }
}
