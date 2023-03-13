using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.Application.Factories.Models {
    public class GenericFactoryResponsePayloadModel<T> {
        public T? Value { get; set; }
    }
}