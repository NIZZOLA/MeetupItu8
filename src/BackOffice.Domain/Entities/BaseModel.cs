using System.ComponentModel.DataAnnotations;

namespace BackOffice.Domain.Entities;

public class BaseModel
{
    [Key]
    public int Id { get; set; }

    public DateTime? CreateDate { get; set; } = DateTime.Now;
    public DateTime? UpdateDate { get; set; }
}
