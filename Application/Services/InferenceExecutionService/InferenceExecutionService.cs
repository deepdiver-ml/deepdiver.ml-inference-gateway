using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deepdiver.Domain.Entities.Predictor;

namespace deepdiver.Application.Services.InferenceExecutionService
{
    public interface InferenceExecutionService
    {
        public String Infer(Predictor predictor);
    }
}