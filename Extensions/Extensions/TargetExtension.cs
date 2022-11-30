using System;
namespace ExtensionMethods.Library
{
    public static class TargetExtension
    {
        static void  ExtendInternal(this InternalTarget target)
        {

        }

        //internal static void ExtendInternalProtected(this InternalTarget.ProtectedSubclass target)
        //{

        //}

        public static string GetStandardizedId(this Target target)
        {
            return target.GetId().ToUpper();
        }
    }
}

