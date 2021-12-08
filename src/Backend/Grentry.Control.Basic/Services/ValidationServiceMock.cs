using Grentry.Control.Basic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grentry.Control.Basic.Services
{
    public class ValidationServiceMock : IValidationService
    {
        List<string> validBarcodes;
        List<string> validCardUids;
        public ValidationServiceMock()
        {
            validBarcodes = new List<string>
            {
                "000029146253",
            };

            validCardUids = new List<string>
            {
                "1006334138572"
            };
        }

        public async Task<bool> IsBarcodeValidAsync(string barcode)
        {
            return this.validBarcodes.Contains(barcode);
        }

        public async Task<bool> IsCardValidAsync(string cardUid)
        {
            return this.validCardUids.Contains(cardUid);
        }
    }
}
