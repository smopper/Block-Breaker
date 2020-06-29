using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PauseTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void PauseTestPasses()
        {
            var gamesession = new GameSession();
            Assert.AreEqual(true, gamesession.gamePause());
        }

    }
}
