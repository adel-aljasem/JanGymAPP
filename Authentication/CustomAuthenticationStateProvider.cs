using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace JanGym.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal();

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage= sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSesseion = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSesseion == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name,userSesseion.UserName),
                new Claim(ClaimTypes.Role,userSesseion.Role)
            }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));

            }
            catch (Exception ex)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));

            }

        }


        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if(userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userSession.UserName),
                    new Claim(ClaimTypes.Role,userSession.Role)
                    
                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSesssion");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));

        }


    }


}
