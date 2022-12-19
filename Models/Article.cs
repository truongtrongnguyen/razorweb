using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorweb.models;

public class Article
{
    [Key]
    public int id {get; set;}
    [Required(ErrorMessage ="Phải nhập {0}")]
    [Column(TypeName="nvarchar")]
    [StringLength(255, MinimumLength =5, ErrorMessage ="{0} phải dài từ {2} đến {1} ký tự")]
    [DisplayName("Tiêu đề")]
    public string? Title {get; set;}
    [Required(ErrorMessage ="Phải nhập {0}")]
    [DataType(DataType.Date)]
    [DisplayName("Ngày tạo")]
    public DateTime Created {get; set;}
    [Column(TypeName ="ntext")]
    [DisplayName("Nội dung chi tiết")]
    public string? Content {get; set;}
}