using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net;

namespace QAthleticsWebRep.Pages
{
    public partial class Index : ComponentBase
    {
        #region Injections

        [Inject] protected IJSRuntime JsRuntime { get; set; }

        #endregion

        #region Properties

        protected string Email { get; set; }
        protected string Password { get; set; }

        #endregion

        #region Load Initials


        #endregion

        #region Login Function

        protected async Task Signin()
        {

        }

        #endregion
    }
}
