using UnityEngine;
using UnityEditor;
public class autoBuildScript : MonoBehaviour
{
    public static void Build(BuildTarget buildTarget, string extension)
    {
        string path = "Builds/" + Application.version + "/" + buildTarget + "/" + Application.productName + extension;

        BuildPlayerOptions playerOptions = new BuildPlayerOptions
        {
            locationPathName = path,
            target = buildTarget,
            options = BuildOptions.CompressWithLz4HC,
        };

        BuildPipeline.BuildPlayer(playerOptions);
    }
    //----------------------------------------------------------------------------
    [MenuItem("Builds/All", priority = 0)]
    public static void BuildAll()
    {
        WebGLBuild();
        WindowsBuild();
    }
    //----------------------------------------------------------------------------
    [MenuItem("Builds/WebGL")]
    public static void WebGLBuild()
    {
        Build(BuildTarget.WebGL, "");

    }
    //----------------------------------------------------------------------------
    [MenuItem("Builds/Windows")]
    public static void WindowsBuild()
    {
        Build(BuildTarget.StandaloneWindows64, ".exe");
    }

}
