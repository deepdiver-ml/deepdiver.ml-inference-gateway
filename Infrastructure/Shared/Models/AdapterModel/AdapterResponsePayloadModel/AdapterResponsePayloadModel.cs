using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.Infrastructure.Shared.Models.AdapterModel.AdapterResponsePayloadModel {
    public class AdapterResponsePayloadModel<T> {
        public T? Value { get; set; }
    }
}