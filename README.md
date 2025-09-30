BÀI TẬP LẬP TRÌNH WEB - BUỔI 05  
Sinh viên thực hiện: Nguyễn Hoài Nam  
MSSV: 2001230530  

----------------------------------

GIỚI THIỆU  
Đây là bài tập thực hành môn Lập Trình Web (ASP.NET MVC) buổi 05.  
Dự án được xây dựng nhằm quản lý và hiển thị các sản phẩm điện thoại di động, có chức năng tìm kiếm và phân loại sản phẩm theo loại.  

----------------------------------

CÔNG NGHỆ SỬ DỤNG  
- Ngôn ngữ: C#  
- Framework: ASP.NET MVC 5  
- CSDL: SQL Server  
- Giao diện: Bootstrap 4/5  
- Công cụ phát triển: Visual Studio 2022  

----------------------------------

CẤU TRÚC CHÍNH  
- Models  
  - DuLieu.cs: Xử lý dữ liệu, kết nối CSDL  
  - SanPham.cs, Loai.cs: Khai báo các lớp thực thể  
- Controllers  
  - HomeController.cs: Điều khiển luồng xử lý chính  
- Views  
  - Home/Index.cshtml: Trang chủ  
  - Home/SanPhamTheoLoai.cshtml: Hiển thị sản phẩm theo loại  
  - Home/TimKiem.cshtml: Trang tìm kiếm sản phẩm  
- Content: Chứa CSS, Bootstrap  
- Scripts: Chứa các file JS  

----------------------------------

CHỨC NĂNG CHÍNH  
- Hiển thị danh sách loại sản phẩm  
- Hiển thị danh sách sản phẩm theo loại  
- Chức năng tìm kiếm sản phẩm theo tên  
- Giao diện sử dụng Bootstrap để hiển thị bảng, menu và layout đẹp mắt  

----------------------------------

HƯỚNG DẪN CHẠY DỰ ÁN  
1. Clone hoặc tải dự án từ GitHub  
   git clone <link-repo>  

2. Mở file .sln bằng Visual Studio  

3. Cấu hình lại chuỗi kết nối trong DuLieu.cs nếu cần:  
   static string strcon = "Data Source=TENMAY\\SQLEXPRESS;database=QL_DTDD1;User ID=sa;Password=123;";  

4. Chạy lệnh Update-Database (nếu có dùng Migration) hoặc import script SQL vào SQL Server  

5. Bấm Start (IIS Express) để chạy dự án  

----------------------------------

SINH VIÊN  
- Họ và tên: Nguyễn Hoài Nam  
- Mã số sinh viên: 2001230530  
- Trường: Đại học Công Thương TP.HCM  

----------------------------------

GHI CHÚ  
- Các thư mục
