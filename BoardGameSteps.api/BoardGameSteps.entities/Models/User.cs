using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSteps.entities.Models;
public class User : BaseEntity
{
    [Required] public string Name { get; set; } = null!;
    [Required] public string Surname { get; set; } = null!;
    [Required] public string Nickname { get; set; } = null!;
}
