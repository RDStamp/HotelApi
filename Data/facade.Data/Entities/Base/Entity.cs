using System.ComponentModel.DataAnnotations;

namespace facade.Data.Entities.Base;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }

}
