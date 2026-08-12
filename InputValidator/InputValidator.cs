using System.Text.RegularExpressions;

namespace NineshaftLightIntel.Validation
{
    public static class InputValidator
    {
        private static readonly Regex NicknameRegex = new(@"^[a-zA-Z0-9_.-]+$", RegexOptions.Compiled);

        public static bool IsValidNickname(string? nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                return false;

            return NicknameRegex.IsMatch(nickname.Trim());
        }
    }
}
