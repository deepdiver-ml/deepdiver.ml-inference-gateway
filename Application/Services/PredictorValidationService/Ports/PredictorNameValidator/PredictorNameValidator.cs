using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.Application.Services.PredictorValidationService.Ports.PredictorNameValidator
{
    public interface PredictorNameValidator
    {
        public Boolean ValidateName(String predictorName);
    }
}