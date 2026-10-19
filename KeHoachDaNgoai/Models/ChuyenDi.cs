using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KeHoachDaNgoai.Models;

[Table("ChuyenDi")]
public partial class ChuyenDi
{
    [Key]
    public int MaChuyen { get; set; }

    [StringLength(100)]
    public string TenChuyen { get; set; } = null!;

    [StringLength(100)]
    public string DiaDiem { get; set; } = null!;

    public DateOnly NgayDi { get; set; }

    public int SoNguoi { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal NganSach { get; set; }

    [StringLength(30)]
    public string PhuongTien { get; set; } = null!;

    public bool DaHoanThanh { get; set; }

    [StringLength(200)]
    public string? GhiChu { get; set; }
}
