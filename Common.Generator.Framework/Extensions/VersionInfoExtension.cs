using Mobioos.Foundation.Jade.Models;

namespace Common.Generator.Framework.Extensions
{
    public static class VersionInfoExtension
    {
        public static bool IsValid(this VersionInfo version)
        {
            if (version == null
                || !version.Major.ToString().IsValid()
                || !version.Minor.ToString().IsValid()
                || !version.Release.ToString().IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
