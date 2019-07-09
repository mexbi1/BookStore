using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer.Services.Interfaces
{
    public interface IEmailServices
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
