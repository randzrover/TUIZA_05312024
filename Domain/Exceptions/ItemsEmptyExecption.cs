using Domain.Entities;
using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;
public sealed class ItemsEmptyExecption : NotFoundException
{
    public ItemsEmptyExecption() :base($"No available item.")
    {

    }
}
