using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcReverse.Services
{
    public class ReverseService : Reverse.ReverseBase
    {
        public override Task<StringResponse> ReverseString(StringRequest request, ServerCallContext context)
        {
            var charArray = request.ToReverse.ToCharArray();
            Array.Reverse(charArray);
            var reversed = new string(charArray);
            return Task.FromResult(new StringResponse() { ReversedString = reversed });
        }
    }
}
