using deepdiver.Application.Services.DescriptionService.Dtos;
using deepdiver.Domain.Entities;

namespace deepdiver.Application.Services.DescriptionService.Ports {
    public interface Descriptor {
        public DescriptionResponseDto Describe(String predictorName);
    }
}