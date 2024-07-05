using System;
using System.Collections.Generic;

namespace TTS3_LEHOAN.Models;

public partial class TbDanhMuc
{
    public int MaDanhMuc { get; set; }

    public string? TenDanhMuc { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<TbSanPham> TbSanPhams { get; set; } = new List<TbSanPham>();
}
