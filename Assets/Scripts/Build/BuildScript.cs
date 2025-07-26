using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Build {
    public class BuildScript {
        public static void PerformBuild() {
            string[] scenes = EditorBuildSettings.scenes
                .Where(scene => scene.enabled)
                .Select(scene => scene.path)
                .ToArray();

            const string outputPath = "Builds/Win/Game.exe";

            BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.StandaloneWindows64, BuildOptions.None);
            Debug.Log("Build complete.");
        }
    }
}