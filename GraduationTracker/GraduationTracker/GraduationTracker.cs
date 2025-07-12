using GraduationTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        // This method evaluates whether a student has graduated based on diploma requirements.
        // It checks required courses, calculates average mark, and returns graduation status with standing.
        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            int totalMarks = 0;
            int passedCredits = 0;
            int courseCount = 0;

            // Loop through each requirement in the diploma
            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                int requirementId = diploma.Requirements[i];           
                var requirement = Repository.GetRequirement(requirementId);

                // Loop through all courses the student has taken
                for (int j = 0; j < student.Courses.Length; j++)
                {
                    var course = student.Courses[j];

                    // Check if the course matches a course in the requirement
                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == course.Id)
                        {
                            totalMarks += course.Mark;
                            courseCount++;

                            // If the mark meets the minimum required, add the credits
                            if (course.Mark >= requirement.MinimumMark)
                            {
                                passedCredits += requirement.Credits;
                            }
                            // Once matched, no need to continue checking this requirement
                            break;
                        }
                    }
                }
            }
            // Calculate the average mark only from matched courses
            int average = courseCount > 0 ? totalMarks / courseCount : 0;

            // Determine academic standing based on average mark
            STANDING standing;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80)
                standing = STANDING.Average;
            else if (average < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.SumaCumLaude;

            // A student must have enough credits and not be remedial to graduate
            bool hasEnoughCredits = passedCredits >= diploma.Credits;
            bool graduated = hasEnoughCredits && standing != STANDING.Remedial;

            return new Tuple<bool, STANDING>(graduated, standing);
        }
    }
}
