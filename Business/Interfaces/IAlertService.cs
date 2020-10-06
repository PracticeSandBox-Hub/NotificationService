using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAlertService
    {
        //CreateAlert //SendAlert //ScheduleAlert //Update //DeleteAlert //
        Task<bool> Create(Alert model);

        Task<bool> SendAlert();

        Task<bool> SendScheduleAlert();

        Task<bool> Update(Alert model);

        Task<bool> Delete(Alert model);
    }
}
