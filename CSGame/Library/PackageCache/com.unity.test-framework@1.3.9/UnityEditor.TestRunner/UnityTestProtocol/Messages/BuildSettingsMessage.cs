<<<<<<< HEAD
using System;

namespace UnityEditor.TestTools.TestRunner.UnityTestProtocol
{
    [Serializable]
    internal class BuildSettingsMessage : Message
    {
        public BuildSettingsMessage()
        {
            type = "BuildSettings";
        }

        public BuildSettings BuildSettings;
    }
}
=======
using System;

namespace UnityEditor.TestTools.TestRunner.UnityTestProtocol
{
    [Serializable]
    internal class BuildSettingsMessage : Message
    {
        public BuildSettingsMessage()
        {
            type = "BuildSettings";
        }

        public BuildSettings BuildSettings;
    }
}
>>>>>>> main
