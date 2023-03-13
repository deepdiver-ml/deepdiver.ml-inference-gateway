using deepdiver.Domain.ValueObjects;

namespace deepdiver.Domain.Entities {
    public class Predictor {
        public String Id { get; set; } = String.Empty;
        public String Name { get; set; } = String.Empty;
        public String RootPath { get; set; } = String.Empty;
        public String ExecutionPath { get; set; } = String.Empty;
        public String DescriptorPath { get; set; } = String.Empty;
        public String InferenceInput { get; set; } = String.Empty;
        public String Executable { get; set; } = String.Empty;
        public PredictorInputFile? InputFile { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}