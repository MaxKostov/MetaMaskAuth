using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MetaMaskAuth.Services
{

    public class MetaMaskService
    {
        private readonly IJSRuntime _jsRuntime;

        public MetaMaskService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<string> RequestAccountAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("ethereumInterop.requestAccount");
        }

        public async Task<string> SignMessageAsync(string message)
        {
            return await _jsRuntime.InvokeAsync<string>("ethereumInterop.signMessage", message);
        }
    }

}
