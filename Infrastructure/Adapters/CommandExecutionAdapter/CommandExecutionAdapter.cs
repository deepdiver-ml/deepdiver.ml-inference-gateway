using deepdiver.Infrastructure.Shared.Dtos.AdapterDto.Response.AdapterResponseDto;
using deepdiver.Infrastructure.Shared.Models.AdapterModel.AdapterResponsePayloadModel;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter {
    public interface CommandExecutionAdapter {
        public AdapterResponseDto<AdapterResponsePayloadModel<String>> Execute(String executable, String arguments);
    }
}