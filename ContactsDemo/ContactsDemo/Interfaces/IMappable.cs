using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Interfaces
{
    public interface IMappable
    {
        double? Latitude { get; }
        double? Longitude { get; }
    }
}
