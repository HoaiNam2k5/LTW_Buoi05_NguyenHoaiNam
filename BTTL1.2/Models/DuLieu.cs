using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Buoi05.Models
{
    public class DuLieu
    {

        //thuoc tinh
        static string strcon = "Data Source=AGRIMOTOR\\SQLEXPRESS;database=QL_NhanSu;User ID=sa; Password=123; Trusted_Connection=True;";
        SqlConnection con = new SqlConnection(strcon);
        public List<Employee> dsnv = new List<Employee>();
        public List<Deparment> dspb= new List<Deparment>();
        //pt khoi tao
        public DuLieu()
        {
            ThietLap_DSNV();
            ThietLap_PhongBan();
        }
        public void ThietLap_DSNV()
        {
            ///cau truy van select 
            /////tao co so du lieu cho nhan vien
            SqlDataAdapter da = new SqlDataAdapter("select * from tblEmployee", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //ket qua thuc hien
            foreach (DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.Manv = int.Parse(dr["Id"].ToString());
                em.Ten = dr["Name"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.Tinh = dr["City"].ToString();
                //em.Mapg = (int)dr["Deptid"];
                dsnv.Add(em);
            }
        }
        public void ThietLap_PhongBan()
        {

            ///cau truy van select 
          
            SqlDataAdapter da = new SqlDataAdapter("select * from tblDepartment", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //ket qua thuc hien
            foreach (DataRow dr in dt.Rows)
            {
                var pb = new Deparment();
                pb.Maph= int.Parse(dr["Deptid"].ToString());
                pb.TenPh= dr["Name"].ToString();
            dspb.Add(pb);
                                
            }
        }

        public Deparment ChiTietPhongBan(int maPhong)
        {
            Deparment department = new Deparment();
            string sqlScript = String.Format("SELECT * FROM tblDepartment WHERE Deptid = {0}", maPhong);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            department.Maph = int.Parse(dt.Rows[0]["Deptid"].ToString());
            department.TenPh = dt.Rows[0]["Name"].ToString();
            return department;
        }

        public bool ThemPhongBan(Deparment department)
        {
            bool result = false;
            string sqlScript = "INSERT INTO tblDepartment (Deptid, Name) VALUES(@MaPg, @TenPhong)";

            try
            {
                SqlCommand cmd = new SqlCommand(sqlScript, con);
                cmd.Parameters.AddWithValue("@MaPg", department.Maph);
                cmd.Parameters.AddWithValue("@TenPhong", department.TenPh);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
        public bool CapNhatPhongBan(Deparment department)
        {
            bool result = false;
            string sqlScript = "UPDATE tblDepartment SET Name = @TenPhong WHERE Deptid = @MaPg";

            try
            {
                SqlCommand cmd = new SqlCommand(sqlScript, con);
                cmd.Parameters.AddWithValue("@MaPg", department.Maph);
                cmd.Parameters.AddWithValue("@TenPhong", department.TenPh);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool XoaPhongBan(int MaPg)
        {
            bool result = false;
            string sqlScript = "DELETE FROM tblDepartment WHERE Deptid = @MaPg";

            try
            {
                SqlCommand cmd = new SqlCommand(sqlScript, con);
                cmd.Parameters.AddWithValue("@MaPg", MaPg);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public List<Employee> DanhSachNhanVienTheoMaPhong(int maPhong)
        {
            List<Employee> employees = new List<Employee>();
            string sqlScript = String.Format("SELECT * FROM tblEmployee WHERE Deptid = {0}", maPhong);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.Manv = int.Parse(dr["Id"].ToString());
                em.Ten = dr["Name"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.Tinh = dr["City"].ToString();
                em.Mapg = (int)dr["Deptid"];

                employees.Add(em);
            }
            return employees;
        }
    }
}