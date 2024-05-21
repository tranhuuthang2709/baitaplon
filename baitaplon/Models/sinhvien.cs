using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace baitaplon.Models
{
    public partial class sinhvien
    {
        public sinhvien()
        {
            this.diemthi = new HashSet<diemthi>();
        }

        public int MaSV { get; set; }

        [Required(ErrorMessage = "Tên sinh viên không được để trống")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Tên sinh viên phải có độ dài từ 10 đến 50 ký tự")]
        public string TenSV { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Giới tính không được để trống")]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^(090|098|091|031|035|038)\d{7}$", ErrorMessage = "Số điện thoại phải có 10 chữ số và bắt đầu bằng 090, 098, 091, 031, 035 hoặc 038")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date, ErrorMessage = "Ngày sinh phải theo định dạng dd/MM/yyyy")]
        [CustomValidation(typeof(sinhvien), "ValidateNgaySinh")]
        public System.DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Mã lớp không được để trống")]
        public Nullable<int> MaLop { get; set; }

        public virtual ICollection<diemthi> diemthi { get; set; }
        public virtual lop lop { get; set; }

        public static ValidationResult ValidateNgaySinh(DateTime ngaySinh, ValidationContext context)
        {
            var isValid = Regex.IsMatch(ngaySinh.ToString("dd/MM/yyyy"), @"^\d{2}/\d{2}/\d{4}$");
            if (!isValid)
            {
                return new ValidationResult("Ngày sinh phải theo định dạng dd/MM/yyyy");
            }
            if (ngaySinh > DateTime.Now)
            {
                return new ValidationResult("Ngày sinh không được vượt quá ngày hiện tại");
            }
            return ValidationResult.Success;
        }
    }
}
