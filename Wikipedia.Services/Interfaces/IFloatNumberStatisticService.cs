using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wikipedia.Services.Models;

namespace Wikipedia.Services.Interfaces
{
    public interface IFloatNumberStatisticService
    {
        Task<FloatNumberStatistic> GetFloatNumberStatistics(string term, string language);
    }
}
