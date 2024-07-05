using System;
using System.Collections.Generic;

namespace TTS3_LEHOAN.Models;

public partial class TbSanPham
{
    public int MaSanPham { get; set; }

    public string? TenSanPham { get; set; }

    public int DonGia { get; set; }

    public int SoLuong { get; set; }

    public string? Mota { get; set; }

    public int MaDanhMuc { get; set; }

    public virtual TbDanhMuc MaDanhMucNavigation { get; set; } = null!;
}
