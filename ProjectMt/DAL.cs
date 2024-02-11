using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;

namespace Data
{
    internal class Connect
    {
        private static String cliComConnectionString = GetConnectString();

        internal static String ConnectionString { get => cliComConnectionString; }

        private static String GetConnectString()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "College1en";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;
        }
    }
    public class DataTables
    {
        public static SqlDataAdapter adapterPrograms = InitAdapterPrograms();
        public static SqlDataAdapter adapterCourses = InitAdapterCourses();
        public static SqlDataAdapter adapterStudents = InitAdapterStudents();
        public static SqlDataAdapter adapterEnrollments = InitAdapterEnrollments();

        public static DataSet ds = InitDataSet();

        private static SqlDataAdapter InitAdapterPrograms()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT * FROM Programs ORDER BY ProgId ",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();

            return adapter;
        }

        private static SqlDataAdapter InitAdapterCourses()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT * FROM Courses ORDER BY CId ",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();

            return adapter;
        }

        private static SqlDataAdapter InitAdapterStudents()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT * FROM Students ORDER BY StId ",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();

            return adapter;
        }

        private static SqlDataAdapter InitAdapterEnrollments()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT * FROM Enrollments ORDER BY StId, CId ",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();

            return adapter;
        }

        private static DataSet InitDataSet()
        {
            DataSet ds = new DataSet();
            LoadPrograms(ds);
            LoadCourses(ds);
            LoadStudents(ds);
            LoadEnrollments(ds);
            return ds;
        }

        private static void LoadPrograms(DataSet ds)
        {
            adapterPrograms.Fill(ds, "Programs");

            ds.Tables["Programs"].Columns["ProgId"].AllowDBNull = false;
            ds.Tables["Programs"].Columns["ProgName"].AllowDBNull = false;

            ds.Tables["Programs"].PrimaryKey = new DataColumn[1]
                    { ds.Tables["Programs"].Columns["ProgId"]};
        }

        private static void LoadCourses(DataSet ds)
        {
            adapterCourses.Fill(ds, "Courses");

            ds.Tables["Courses"].Columns["CId"].AllowDBNull = false;
            ds.Tables["Courses"].Columns["CName"].AllowDBNull = false;

            ds.Tables["Courses"].PrimaryKey = new DataColumn[1]
                    { ds.Tables["Courses"].Columns["CId"]};
        }

        private static void LoadStudents(DataSet ds)
        {
            adapterStudents.Fill(ds, "Students");

            ds.Tables["Students"].Columns["StId"].AllowDBNull = false;
            ds.Tables["Students"].Columns["StName"].AllowDBNull = false;

            ds.Tables["Students"].PrimaryKey = new DataColumn[1]
                    { ds.Tables["Students"].Columns["StId"]};
        }

        private static void LoadEnrollments(DataSet ds)
        {
            adapterEnrollments.Fill(ds, "Enrollments");

            ds.Tables["Enrollments"].Columns["StId"].AllowDBNull = false;
            ds.Tables["Enrollments"].Columns["CId"].AllowDBNull = false;

            ds.Tables["Enrollments"].PrimaryKey = new DataColumn[2]
                    { ds.Tables["Enrollments"].Columns["StId"], ds.Tables["Enrollments"].Columns["CId"] };

            ForeignKeyConstraint fkStudent = new ForeignKeyConstraint("FK_Student",
                new DataColumn[]{
                    ds.Tables["Students"].Columns["StId"]
                },
                new DataColumn[] {
                    ds.Tables["Enrollments"].Columns["StId"]
                }
            );
            fkStudent.DeleteRule = Rule.Cascade;
            fkStudent.UpdateRule = Rule.Cascade;
            ds.Tables["Enrollments"].Constraints.Add(fkStudent);

            ForeignKeyConstraint fkCourse = new ForeignKeyConstraint("FK_Course",
              new DataColumn[]{
                    ds.Tables["Courses"].Columns["CId"]
              },
              new DataColumn[] {
                    ds.Tables["Enrollments"].Columns["CId"]
              }
          );
            fkCourse.DeleteRule = Rule.None;
            fkCourse.UpdateRule = Rule.Cascade;
            ds.Tables["Enrollments"].Constraints.Add(fkCourse);
        }

        public static SqlDataAdapter GetAdapterPrograms()
        {
            return adapterPrograms;
        }

        public static SqlDataAdapter GetAdapterCourses()
        {
            return adapterCourses;
        }

        public static SqlDataAdapter GetAdapterStudents()
        {
            return adapterStudents;
        }

        public static SqlDataAdapter GetAdapterEnrollments()
        {
            return adapterEnrollments;
        }

        public static DataSet GetDataSet()
        {
            return ds;
        }
    }

    internal class Students
    {
        private static SqlDataAdapter adapter = DataTables.GetAdapterStudents();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetStudents()
        {
            return ds.Tables["Students"];
        }



        internal static int InsertStudent(string[] studentData)
        {
            try
            {
                DataRow studentRow = ds.Tables["Students"].NewRow();
                studentRow.SetField("StId", studentData[0]);
                studentRow.SetField("StName", studentData[1]);
                studentRow.SetField("ProgId", studentData[2]);
                ds.Tables["Students"].Rows.Add(studentRow);

                adapter.Update(ds.Tables["Students"]);

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Insertion / Update rejected");
                return -1;
            }
        }

        internal static int DeleteStudents(List<string[]> lId)
        {
            try
            {

                var rowsToDelete = ds.Tables["Students"].AsEnumerable()
                    .Where(s =>
                        lId.Any(x => (x[0] == s.Field<string>("StId") && x[1] == s.Field<string>("StName") && x[2] == s.Field<string>("ProgId"))))
                    .ToList();

                foreach (var rowToDelete in rowsToDelete)
                {
                    rowToDelete.Delete();
                }

                adapter.Update(ds.Tables["Students"]);

                return 0;
            }
            catch (Exception ex)
            {
                EmpProj3.Form1.DALMessage($"An unexpected error occurred: {ex.Message}");
                return -1;
            }

        }


    }

    internal class Enrollments
    {
        private static SqlDataAdapter adapter = DataTables.GetAdapterEnrollments();
        private static DataSet ds = DataTables.GetDataSet();
        private static DataTable displayEnrollment = null;

        internal static DataTable GetEnrollments()
        {
            return ds.Tables["Enrollments"];
        }

        internal static DataTable GetDisplayEnrollment()
        {
            displayEnrollment = ds.Tables["DisplayEnrollment"];
            return displayEnrollment;
        }

        internal static int InsertEnrollment(string[] enrollmentData)
        {
            var test = (
                from enrollment in ds.Tables["Enrollments"].AsEnumerable()
                where enrollment.Field<string>("StId") == enrollmentData[0]
                where enrollment.Field<string>("CId") == enrollmentData[1]
                select enrollment);

            if (test.Count() > 0)
            {
                EmpProj3.Form1.DALMessage("This enrollment already exists");
                return -1;
            }

            try
            {
                DataRow enrollmentRow = ds.Tables["Enrollments"].NewRow();
                enrollmentRow.SetField("StId", enrollmentData[0]);
                enrollmentRow.SetField("CId", enrollmentData[1]);
                ds.Tables["Enrollments"].Rows.Add(enrollmentRow);

                adapter.Update(ds.Tables["Enrollments"]);

                if (displayEnrollment != null)
                {
                    var query = (
                        from student in ds.Tables["Students"].AsEnumerable()
                        from course in ds.Tables["Courses"].AsEnumerable()
                        where student.Field<string>("StId") == enrollmentData[0]
                        where course.Field<string>("CId") == enrollmentData[1]
                        select new
                        {
                            StId = student.Field<string>("StId"),
                            StName = student.Field<string>("StName"),
                            CId = course.Field<string>("CId"),
                            CName = course.Field<string>("CName"),
                            FinalGrade = enrollmentRow.Field<Nullable<int>>("FinalGrade")
                        });

                    var r = query.Single();
                    displayEnrollment.Rows.Add(new object[] { r.StId, r.StName, r.CId, r.CName, r.FinalGrade });
                }

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
                var enrollments = ds.Tables["Enrollments"].AsEnumerable()
                    .Where(s =>
                        enrollmentsToDelete.Any(x =>
                            x[0] == s.Field<string>("StId") && x[1] == s.Field<string>("CId")));

                foreach (var enrollmentRow in enrollments)
                {
                    enrollmentRow.Delete();
                }

                adapter.Update(ds.Tables["Enrollments"]);

                if (displayEnrollment != null)
                {
                    foreach (var p in enrollmentsToDelete)
                    {
                        var r = displayEnrollment.AsEnumerable()
                                .Where(s => (s.Field<string>("StId") == p[0] && s.Field<string>("CId") == p[1]))
                                .Single();
                        displayEnrollment.Rows.Remove(r);
                    }
                }

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Deletion rejected");
                return -1;
            }
        }

        internal static int ManageFinalGrade(string[] a, Nullable<int> finalGrade)
        {
            try
            {
                var enrollmentRow = ds.Tables["Enrollments"].AsEnumerable()
                    .Where(s =>
                        (s.Field<string>("StId") == a[0] && s.Field<string>("CId") == a[1]))
                    .Single();

                enrollmentRow.SetField("FinalGrade", finalGrade);

                adapter.Update(ds.Tables["Enrollments"]);

                if (displayEnrollment != null)
                {
                    var r = displayEnrollment.AsEnumerable()
                        .Where(s =>
                            (s.Field<string>("StId") == a[0] && s.Field<string>("CId") == a[1]))
                        .Single();
                    r.SetField("FinalGrade", finalGrade);
                }

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Update / Deletion rejected");
                return -1;
            }
        }
    }


    internal class Courses
    {
        private static SqlDataAdapter adapter = DataTables.GetAdapterCourses();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetCourses()
        {
            return ds.Tables["Courses"];
        }



        internal static int InsertCourse(string[] courseData)
        {
            try
            {
                DataRow courseRow = ds.Tables["Courses"].NewRow();
                courseRow.SetField("CId", courseData[0]);
                courseRow.SetField("CName", courseData[1]);
                courseRow.SetField("ProgId", courseData[2]);
                ds.Tables["Courses"].Rows.Add(courseRow);

                adapter.Update(ds.Tables["Courses"]);

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Insertion / Update rejected");
                return -1;
            }
        }

        internal static int DeleteCourses(List<string[]> lId)
        {
            try
            {
                var rowsToDelete = ds.Tables["Courses"].AsEnumerable()
                    .Where(c =>
                        lId.Any(x => (x[0] == c.Field<string>("CId") && x[1] == c.Field<string>("CName") && x[2] == c.Field<string>("ProgId"))))
                    .ToList();

                foreach (var rowToDelete in rowsToDelete)
                {
                    rowToDelete.Delete();
                }

                adapter.Update(ds.Tables["Courses"]);

                return 0;
            }
            catch (Exception ex)
            {
                EmpProj3.Form1.DALMessage($"An unexpected error occurred: {ex.Message}");
                return -1;
            }
        }
    }

    internal class Programs
    {
        private static SqlDataAdapter adapter = DataTables.GetAdapterPrograms();
        private static DataSet ds = DataTables.GetDataSet();

        internal static DataTable GetPrograms()
        {
            return ds.Tables["Programs"];
        }



        internal static int InsertProgram(string[] programData)
        {
            try
            {
                DataRow programRow = ds.Tables["Programs"].NewRow();
                programRow.SetField("ProgId", programData[0]);
                programRow.SetField("ProgName", programData[1]);

                ds.Tables["Programs"].Rows.Add(programRow);

                adapter.Update(ds.Tables["Programs"]);

                return 0;
            }
            catch (Exception)
            {
                EmpProj3.Form1.DALMessage("Insertion / Update rejected");
                return -1;
            }
        }


        internal static int DeletePrograms(List<string[]> lId)
        {
            try
            {
                var rowsToDelete = ds.Tables["Programs"].AsEnumerable()
                    .Where(p =>
                        lId.Any(x => (x[0] == p.Field<string>("ProgId") && x[1] == p.Field<string>("ProgName"))))
                    .ToList();

                foreach (var rowToDelete in rowsToDelete)
                {
                    rowToDelete.Delete();
                }

                adapter.Update(ds.Tables["Programs"]);

                return 0;
            }
            catch (Exception ex)
            {
                EmpProj3.Form1.DALMessage($"An unexpected error occurred: {ex.Message}");
                return -1;
            }
        }

    }

}

