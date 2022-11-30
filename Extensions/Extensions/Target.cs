using System;
namespace ExtensionMethods.Library
{
    public class Target
    {
        private string _id;

        protected string Id
        {
            get { return _id; }
            set { _id = value.Trim(); }
        }

        public string GetId()
        {
            return _id;
        }

        public Target(string id)
        {
            _id = id;
        }

        public string GetStandardizedId()
        {
            return _id.ToLower();
        }
    }

    internal class InternalTarget
    {
        protected class ProtectedSubclass
        { }
    }
}

