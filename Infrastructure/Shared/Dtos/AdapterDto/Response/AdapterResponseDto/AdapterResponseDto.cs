using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.Infrastructure.Shared.Dtos.AdapterDto.Response.AdapterResponseDto
{
    public class AdapterResponseDto<T>
    {
        public Boolean Success { get; set; } = true;
        public T? Data { get; set; }
    }
}