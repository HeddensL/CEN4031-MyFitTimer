using System;
using MyFitTimer.Server;
using NUnit.Framework;

namespace MyFitTimer.Test
{
    [TestFixture]
    public class TestStopwatchTracker
    {
        private StopwatchTracker watch;
        
        [SetUp]
        public void SetUp()
        {
            watch = new StopwatchTracker();
        }

        [Test]
        public void TestGetElapsed()
        {
            var time = watch.GetElapsed();
            string result = time.ToString();

            Assert.AreEqual(result, "00:00:00");
        }
    }
}