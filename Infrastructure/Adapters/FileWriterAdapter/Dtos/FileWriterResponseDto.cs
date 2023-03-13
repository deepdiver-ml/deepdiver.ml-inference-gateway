using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deepdiver.Infrastructure.Adapters.Dtos.GenericAdapterDto;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Models;

namespace deepdiver.Infrastructure.Adapters.FileWriterAdapter.Dtos {
    public class FileWriterResponseDto : GenericAdapterResponseDto<FileWriterResponsePayloadModel> {}
}