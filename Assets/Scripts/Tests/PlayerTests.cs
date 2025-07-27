using NUnit.Framework;
using UnityEngine;

namespace Tests {
    public class PlayerTests {
        Player.Player player;
        GameObject playerGo;

        [SetUp]
        public void Setup() {
            playerGo = new GameObject("TestPlayer");
            player = playerGo.AddComponent<Player.Player>();
        }

        [TearDown]
        public void Teardown() {
            Object.DestroyImmediate(playerGo);
        }

        [Test]
        public void TakeDamage_ReducesHealth() {
            player.TakeDamage(25);
            Assert.AreEqual(75, player.Health);
        }

        [Test]
        public void TakeDamage_ZeroHealth_DestroysGameObject() {
            player.TakeDamage(100);
            Assert.IsTrue(player == null || player.gameObject == null || !player.gameObject);
        }
    }
}