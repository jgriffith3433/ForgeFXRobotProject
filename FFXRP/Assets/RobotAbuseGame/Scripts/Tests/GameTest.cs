using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class GameTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void DestroyAndResetRobotTestSimplePasses()
    {
        // Use the Assert class to test conditions
        //var game = Object.FindObjectsOfType<Game>();
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    //[UnityTest]
    //public IEnumerator GameTestWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // Use yield to skip a frame.
    //    yield return null;
    //}
}
