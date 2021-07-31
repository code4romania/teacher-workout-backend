using System;
using Xunit;

namespace TeacherWorkout.Tests
{
    public class TestBoss
    {
        [Fact]
        public void MergeBoss()
        {
            Assert.Equal("Merge Boss", "Merge" + " Boss");
        }
    }
}