using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSteps.entities.Exceptions;
public class InsertQueryValidateException : Exception
{
	public InsertQueryValidateException(string? message) : base(message)
	{
	}
}
