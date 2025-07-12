using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Model;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        // This test verifies graduation logic across a range of student performance levels.
        // It also includes edge cases like missing courses and no courses at all.
        [TestMethod]
        public void TestEligibilityForAllStudents()
        {
            // Arrange
            var tracker = new GraduationTracker();

            // Get diploma and students from Repository (use the IDs accordingly)
            var diploma = Repository.GetDiploma(1);

            // Use all students defined in the repository
            var students = new Student[]
            {
                Repository.GetStudent(1),
                Repository.GetStudent(2),
                Repository.GetStudent(3),
                Repository.GetStudent(4),
                Repository.GetStudent(5),
                Repository.GetStudent(6)
            };

            var testCases = new[]
            {
                (Student: students[0], ExpectedGraduated: true, ExpectedStanding: STANDING.SumaCumLaude),
                (Student: students[1], ExpectedGraduated: true, ExpectedStanding: STANDING.MagnaCumLaude),
                (Student: students[2], ExpectedGraduated: true, ExpectedStanding: STANDING.Average),
                (Student: students[3], ExpectedGraduated: false, ExpectedStanding: STANDING.Remedial),
                (Student: students[4], ExpectedGraduated: false, ExpectedStanding: STANDING.Remedial),
                (Student: students[5], ExpectedGraduated: false, ExpectedStanding: STANDING.MagnaCumLaude)
            };

            for (int i = 0; i < testCases.Length; i++)
            {
                var result = tracker.HasGraduated(diploma, testCases[i].Student);
                Assert.AreEqual(testCases[i].ExpectedGraduated, result.Item1, $"Student {i + 1} graduation status mismatch.");
                Assert.AreEqual(testCases[i].ExpectedStanding, result.Item2, $"Student {i + 1} standing mismatch.");
            }

        }
    }
}
