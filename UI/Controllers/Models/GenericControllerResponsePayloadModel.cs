using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.UI.Controllers.Models {
    public class GenericControllerResponsePayloadModel<T> {
        public T? Value { get; set; }
    }
}