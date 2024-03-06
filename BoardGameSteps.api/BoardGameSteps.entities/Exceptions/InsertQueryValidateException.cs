using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSteps.entities.Exceptions;
public class InsertQueryValidateException(string? message) : Exception(message)
{
}
