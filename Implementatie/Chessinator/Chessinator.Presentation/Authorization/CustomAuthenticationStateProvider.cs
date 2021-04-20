using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Chessinator.Presentation.Authorization
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorageService = sessionStorage;
        }

        /// <summary>
        /// Even if the browser is refreshed checks if the user is authenticated, else identity get a new (dummy) identity.
        /// </summary>
        /// <returns></returns>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var username = await _sessionStorageService.GetItemAsync<string>("username");
            ClaimsIdentity identity;
            if (username != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }, "apiauth_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }


            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string username)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }, "apiauth_type");
            
            var user = new ClaimsPrincipal(identity);
            
            // Tells the AuthenticationStateProvider the state has been changed.
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            // Removes username in the session storage.
            _sessionStorageService.RemoveItemAsync("username");

            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal();

            // Tells the AuthenticationStateProvider the state has been changed.
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
