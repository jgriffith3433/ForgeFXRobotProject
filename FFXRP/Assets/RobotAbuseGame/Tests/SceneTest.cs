using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class SceneTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void SceneTestSimplePasses()
    {
        //Make sure the first scene is Game
        Assert.True(EditorSceneManager.GetSceneByBuildIndex(0).name == "Game");
    }
}
