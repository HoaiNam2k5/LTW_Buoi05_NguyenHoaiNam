using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BTVN_03.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source=AGRIMOTOR\\SQLEXPRESS;database=QL_DTDD1;User ID=sa; Password=123; Trusted_Connection=True;";
        SqlConnection con = new SqlConnection(strcon);

        public List<Loai> dsLoai = new List<Loai>();
        public List<SanPham> dsSanPham = new List<SanPham>();

        public DuLieu()
        {
            LoadLoai();
            LoadSanPham();
        }

        public void LoadLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Loai", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var loai = new Loai();
                loai.MaLoai = Convert.ToInt32(dr["MaLoai"]);
                loai.TenLoai = dr["TenLoai"].ToString();
                dsLoai.Add(loai);
            }
        }

        public void LoadSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SanPham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = Convert.ToInt32(dr["MaSP"]);
                sp.TenSP = dr["TenSP"].ToString();
                sp.DuongDan = dr["DuongDan"].ToString();
                sp.Gia = Convert.ToDecimal(dr["Gia"]);
                sp.MoTa = dr["MoTa"].ToString();
                sp.MaLoai = Convert.ToInt32(dr["MaLoai"]);
                dsSanPham.Add(sp);
            }
        }
        // Lấy danh sách loại sản phẩm
        public List<Loai> GetLoaiSP()
        {
            List<Loai> ds = new List<Loai>();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Loai", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Loai l = new Loai();
                l.MaLoai = Convert.ToInt32(dr["MaLoai"]);
                l.TenLoai = dr["TenLoai"].ToString();
                ds.Add(l);
            }
            return ds;
        }
        // Lấy sản phẩm theo loại
        public List<SanPham> GetSanPhamByLoai(int maloai)
        {
            var list = new List<SanPham>();
            using (SqlConnection cnn = new SqlConnection(strcon))
            {
                cnn.Open();
                string sql = "SELECT MaSP, TenSP, DuongDan, Gia, MoTa, MaLoai FROM SanPham WHERE MaLoai = @maloai";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@maloai", maloai);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var sp = new SanPham();
                        sp.MaSP = rd.GetInt32(rd.GetOrdinal("MaSP"));
                        sp.TenSP = rd["TenSP"].ToString();
                        sp.DuongDan = rd["DuongDan"].ToString();
                        sp.Gia = rd.IsDBNull(rd.GetOrdinal("Gia")) ? 0 : Convert.ToDecimal(rd["Gia"]);
                        sp.MoTa = rd["MoTa"].ToString();
                        sp.MaLoai = rd.GetInt32(rd.GetOrdinal("MaLoai"));
                        list.Add(sp);
                    }
                }
            }
            return list;
        }



        // Tìm kiếm sản phẩm gần đúng
        public List<SanPham> SearchSanPham(string keyword)
        {
            var list = new List<SanPham>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string sql = "SELECT * FROM SanPham WHERE TenSP LIKE @keyword";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new SanPham
                    {
                        MaSP = (int)rd["MaSP"],
                        TenSP = rd["TenSP"].ToString(),
                        DuongDan = rd["DuongDan"].ToString(),
                        Gia = Convert.ToDecimal(rd["Gia"]),
                        MoTa = rd["MoTa"].ToString(),
                        MaLoai = (int)rd["MaLoai"]
                    });

                }
            }
            return list;
        }
    }
}
