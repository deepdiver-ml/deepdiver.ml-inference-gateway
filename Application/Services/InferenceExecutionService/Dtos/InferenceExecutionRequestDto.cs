using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.Application.Services.InferenceExecutionService.Dtos {
    public class InferenceExecutionRequestDto {
        public String PredictorId { get; set; } = String.Empty;
        public String PredictorName { get; set; } = String.Empty;
        public String PredictorInput { get; set; } = String.Empty;
        public Boolean Physical { get; set; }
    }
}