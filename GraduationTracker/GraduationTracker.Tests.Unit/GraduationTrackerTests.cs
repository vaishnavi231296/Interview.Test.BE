using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
            // Arrange: create an instance of the tracker and the diploma definition
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            },
             // Student 5: No courses – should be marked as Remedial
             new Student
            {
                Id = 5,
                Courses = new Course[0]
            },
              // Student 6: Missing required course (Literature) – should not graduate
             new Student
            {
                Id = 6,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=90},
                    new Course{Id = 2, Name = "Science", Mark=90},
                    new Course{Id = 4, Name = "Physichal Education", Mark=90} // Missing Literature
                }
            }
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
