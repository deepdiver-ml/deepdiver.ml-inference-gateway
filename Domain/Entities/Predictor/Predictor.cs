using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.Domain.Entities.Predictor
{
    public class Predictor
    {
        public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public String RootPath { get; set; } = String.Empty;
        public String ExecutionPath { get; set; } = String.Empty;
        public String DescriptorPath { get; set; } = String.Empty;
        public String InferenceInput { get; set; } = String.Empty;
        public String Executable { get; set; } = String.Empty;
        public DateTime LastUpdated { get; set; }
    }
}