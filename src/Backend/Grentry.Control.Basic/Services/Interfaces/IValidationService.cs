using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grentry.Control.Basic.Services.Interfaces
{
    public interface IValidationService
    {
        Task<bool> IsBarcodeValidAsync(string barcode);
        Task<bool> IsCardValidAsync(string cardUid);
    }
}
