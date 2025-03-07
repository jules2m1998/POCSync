using POCSync.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCSync.Domain.Services;

public interface IEventEmitter<T> where T : Event
{
    public Task<T> Send(T @event);
}
