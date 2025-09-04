using System;
using System.Collections.Generic;

namespace ApiMar.Models.DTO
{
	public class ResultListDTO<T>
	{
		public List<T> Result { get; set; } = new List<T>();
		public int Count { get; set; }

	}
}
