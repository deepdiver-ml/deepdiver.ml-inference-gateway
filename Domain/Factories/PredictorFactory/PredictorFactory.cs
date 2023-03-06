using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deepdiver.Domain.Entities.Predictor;

namespace deepdiver.Domain.Factories.PredictorFactory
{
    public interface PredictorFactory
    {
        public Predictor Create(String predictorName, String predictorInput);
    }
}