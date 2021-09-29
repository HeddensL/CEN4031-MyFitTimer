using System;
using System.Threading;
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
            //new watch object
            watch = new StopwatchTracker();
        }

        [Test]//ensures GetElapsed gets time
        public void TestGetElapsed()
        {
            var time = watch.GetElapsed();
            string result = time.ToString();

            Assert.AreEqual(result, "00:00:00");
        }


        [Test]//ensures Restart starts timer
        public void TestRestart()
        {
            watch.Restart();
            Thread.Sleep(3000);
            var time = watch.GetElapsed();
            int result = time.Seconds;

            Assert.GreaterOrEqual(result, 3);
        }

        [Test]//ensures Restart resets timer
        public void TestRestartReset()
        {
            watch.Restart();
            Thread.Sleep(3000);
            watch.Restart();
            watch.Stop();
            var time = watch.GetElapsed();
            int result = time.Seconds;

            Assert.AreEqual(result, 0);
        }

        [Test]//ensures Stop stops the timer
        public void TestStop()
        {
            watch.Restart();
            Thread.Sleep(3000);
            watch.Stop();
            var time = watch.GetElapsed();
            int result = time.Seconds;

            Assert.AreEqual(result, 3);
        }

        [Test]//ensures elapsed time is shown
        public void TestGetLap()
        {
            var time = watch.GetLap();
            string result = time.ToString();

            Assert.AreEqual(result, "00:00:00");
        }

        [Test]//ensure Stop stores lap
        public void TestStopStoreLap()
        {
            watch.Restart();
            Thread.Sleep(3000);
            watch.Stop();
            var time = watch.GetLap();
            int result = time.Seconds;

            Assert.AreEqual(result, 3);
        }
    }
}