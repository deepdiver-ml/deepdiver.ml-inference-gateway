using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.Application.Services.PredictorValidationService
{
    public interface PredictorValidationService {
        public Boolean ValidateName(String predictorName);
    }
}