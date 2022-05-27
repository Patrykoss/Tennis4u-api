using System.Security.Claims;

namespace Tennis4u_API.Helpers
{
    public static class JwtTokenExtention
    {
        public static int? GetIdUser(ClaimsPrincipal claimPrincipal)
        {
            var idUser = claimPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var canParse = int.TryParse(idUser, out var parsedIdUser);
            if (!canParse)
                return null;
            return parsedIdUser;
        }

        public static bool IsWorkerOrManager(ClaimsPrincipal claimPrincipal)
        {
            var rolesUser = claimPrincipal.FindFirst(ClaimTypes.Role)?.Value;
            if (rolesUser == null)
                return false;
            if(rolesUser.Contains("Manager") || rolesUser.Contains("Worker"))
                return true;
            return false;
        }

        public static bool IsClient(ClaimsPrincipal claimPrincipal)
        {
            var rolesUser = claimPrincipal.FindFirst(ClaimTypes.Role)?.Value;
            if (rolesUser == null)
                return false;
            if (rolesUser.Contains("Client"))
                return true;
            return false;
        }

    }
}
