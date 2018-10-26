using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution2
{
    public interface IManager : IEmployee
    {
        void GeneratePerformanceReview();
    }
}
