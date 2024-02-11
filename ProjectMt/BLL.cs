using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    internal class Students
    {
        private static SqlDataAdapter adapter = Data.DataTables.GetAdapterStudents();
        private static DataSet ds = Data.DataTables.GetDataSet();

        internal static DataTable GetStudents()
        {
            return ds.Tables["Students"];
        }

        internal static int UpdateStudents()
        {
            if (!ds.Tables["Students"].HasErrors)
            {
                return adapter.Update(ds.Tables["Students"]);
            }
            else
            {
                return -1;
            }
        }

        internal static int InsertStudent(string[] studentData)
        {
            try
            {
                string studentProgram = studentData[2]; 

                // Check if the student program exists
                var programExists = ds.Tables["Programs"].AsEnumerable()
                    .Any(p => p.Field<string>("ProgId") == studentProgram);

                if (!programExists)
                {
                    EmpProj3.Form1.BLLMessage("Invalid program ID for the student.");
                    return -1;
                }

                // Create a new DataRow for the student
                DataRow studentRow = ds.Tables["Students"].NewRow();
                studentRow.SetField("StId", studentData[0]);
                studentRow.SetField("StName", studentData[1]);
                studentRow.SetField("ProgId", studentProgram);
                ds.Tables["Students"].Rows.Add(studentRow);

                // Update the Students DataTable 
                adapter.Update(ds.Tables["Students"]);

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Insertion / Update rejected");
                return -1;
            }
        }

        internal static int DeleteStudents(List<string> studentIds)
        {
            try
            {
                var studentsToDelete = ds.Tables["Students"].AsEnumerable()
                    .Where(s => studentIds.Contains(s.Field<string>("StId")));

                foreach (var studentRow in studentsToDelete)
                {
                    studentRow.Delete();
                }

                adapter.Update(ds.Tables["Students"]);

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Deletion rejected");
                return -1;
            }
        }
    }

    internal class Enrollments
    {
        private static SqlDataAdapter adapter = Data.DataTables.GetAdapterEnrollments();
        private static DataSet ds = Data.DataTables.GetDataSet();

        internal static DataTable GetEnrollments()
        {
            return ds.Tables["Enrollments"];
        }

        internal static int UpdateEnrollments()
        {
            if (!ds.Tables["Enrollments"].HasErrors)
            {
                return adapter.Update(ds.Tables["Enrollments"]);
            }
            else
            {
                return -1;
            }
        }

        internal static int InsertEnrollment(string[] enrollmentData)
        {

            try
            {
                // Check if the course belongs to the program
                var courseProgram = ds.Tables["Courses"].AsEnumerable()
                    .Where(c => c.Field<string>("CId") == enrollmentData[1])
                    .Select(c => c.Field<string>("ProgId"))
                    .FirstOrDefault();

                var studentProgram = ds.Tables["Students"].AsEnumerable()
                    .Where(s => s.Field<string>("StId") == enrollmentData[0])
                    .Select(s => s.Field<string>("ProgId"))
                    .FirstOrDefault();

                // Check if course and student belong to the same program
                if (courseProgram != studentProgram)
                {
                    EmpProj3.Form1.BLLMessage("Cannot enroll in a course from a different program");
                    return -1;
                }

                // Check if the enrollment already exists
                var existingEnrollment = ds.Tables["Enrollments"].AsEnumerable()
                    .Where(e => e.Field<string>("StId") == enrollmentData[0] && e.Field<string>("CId") == enrollmentData[1])
                    .FirstOrDefault();

                if (existingEnrollment != null)
                {
                    EmpProj3.Form1.BLLMessage("Enrollment already exists");
                    return -1;
                }

                // Create a new DataRow for the enrollment
                DataRow enrollmentRow = ds.Tables["Enrollments"].NewRow();
                enrollmentRow.SetField("StId", enrollmentData[0]);
                enrollmentRow.SetField("CId", enrollmentData[1]);
                enrollmentRow.SetField("FinalGrade", DBNull.Value); //Set FinalGrade to null initially
                ds.Tables["Enrollments"].Rows.Add(enrollmentRow);

                // Update the Enrollments DataTable 
                adapter.Update(ds.Tables["Enrollments"]);

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Insertion / Update rejected");
                return -1;
            }
        }

        internal static int DeleteEnrollments(List<string[]> enrollmentsToDelete)
        {
            try
            {
                // Find and delete rows 
                var enrollments = ds.Tables["Enrollments"].AsEnumerable()
                    .Where(s =>
                        enrollmentsToDelete.Any(x =>
                            x[0] == s.Field<string>("StId") && x[1] == s.Field<string>("CId")));

                foreach (var enrollmentRow in enrollments)
                {
                    // Check if FinalGrade is not assigned (null)
                    if (enrollmentRow.Field<object>("FinalGrade") == DBNull.Value)
                    {
                        enrollmentRow.Delete();
                    }
                    else
                    {
                        EmpProj3.Form1.BLLMessage("Cannot delete enrollment with assigned FinalGrade");
                        return -1;
                    }
                }

                // Update the Enrollments DataTable 
                adapter.Update(ds.Tables["Enrollments"]);

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Deletion rejected");
                return -1;
            }
        }

        internal static int ManageFinalGrade(string[] a, string ev)
        {
            Nullable<int> finalg;
            int temp;

            if (ev == "")
            {
                finalg = null;
            }
            else if (int.TryParse(ev, out temp) && (0 <= temp && temp <= 100))
            {
                finalg = temp;
            }
            else
            {
                EmpProj3.Form1.BLLMessage(
                    "final Grade must be an integer between 0 and 100"
                    );
                return -1;
            }

            try
            {

                return Data.Enrollments.ManageFinalGrade(a, finalg);
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Modification rejected");
                return -1;
            }
        }
    }

        internal class Courses
        {
            private static SqlDataAdapter adapter = Data.DataTables.GetAdapterCourses();
            private static DataSet ds = Data.DataTables.GetDataSet();

            internal static DataTable GetCourses()
            {
                return ds.Tables["Courses"];
            }

            internal static int UpdateCourses()
            {
                if (!ds.Tables["Courses"].HasErrors)
                {
                    return adapter.Update(ds.Tables["Courses"]);
                }
                else
                {
                    return -1;
                }
            }

            internal static int InsertCourse(string[] courseData)
            {
                try
                {
                    // Create a new DataRow for the course
                    DataRow courseRow = ds.Tables["Courses"].NewRow();
                    courseRow.SetField("CId", courseData[0]);
                    courseRow.SetField("CName", courseData[1]);
                    courseRow.SetField("ProgId", courseData[2]);
                    ds.Tables["Courses"].Rows.Add(courseRow);

                    // Update the Courses DataTable 
                    adapter.Update(ds.Tables["Courses"]);

                    return 0;
                }
                catch (Exception)
                {
                    EmpProj3.Form1.DALMessage("Insertion / Update rejected");
                    return -1;
                }
            }

            internal static int DeleteCourses(List<string> courseIds)
            {
                try
                {
                    // Find and delete rows 
                    var coursesToDelete = ds.Tables["Courses"].AsEnumerable()
                        .Where(s => courseIds.Contains(s.Field<string>("CId")));

                    foreach (var courseRow in coursesToDelete)
                    {
                        courseRow.Delete();
                    }

                    // Update the Courses DataTable 
                    adapter.Update(ds.Tables["Courses"]);

                    return 0;
                }
                catch (Exception)
                {
                    EmpProj3.Form1.DALMessage("Deletion rejected");
                    return -1;
                }
            }
        }

        internal class Programs
        {
            private static SqlDataAdapter adapter = Data.DataTables.GetAdapterPrograms();
            private static DataSet ds = Data.DataTables.GetDataSet();

            internal static DataTable GetPrograms()
            {
                return ds.Tables["Programs"];
            }

            internal static int UpdatePrograms()
            {
         
                if (!ds.Tables["Programs"].HasErrors)
                {
                    return adapter.Update(ds.Tables["Programs"]);
                }
                else
                {
                    return -1;
                }
            }

            internal static int InsertProgram(string[] programData)
            {
            try
            {
                // Create a new DataRow for the program
                DataRow programRow = ds.Tables["Programs"].NewRow();
                programRow.SetField("ProgId", programData[0]);
                programRow.SetField("ProgName", programData[1]);
                ds.Tables["Programs"].Rows.Add(programRow);

                // Update the Programs DataTable 
                adapter.Update(ds.Tables["Programs"]);

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Insertion / Update rejected");
                return -1;
            }
        }

            internal static int DeletePrograms(List<string> programIds)
            {
            try
            {
                // Find and delete rows 
                var programsToDelete = ds.Tables["Programs"].AsEnumerable()
                    .Where(s => programIds.Contains(s.Field<string>("ProgId")));

                foreach (var programRow in programsToDelete)
                {
                    programRow.Delete();
                }

                // Update the Programs DataTable 
                adapter.Update(ds.Tables["Programs"]);

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Deletion rejected");
                return -1;
            }
        }
        }

  }