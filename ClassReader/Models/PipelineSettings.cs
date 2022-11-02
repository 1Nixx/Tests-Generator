using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassReader.Models
{
	public class PipelineSettings
	{
		public int MaxReadFiles { get; set; }
		public int MaxGenerateFiles { get; set; }
		public int MaxWriteFiles { get; set; }
	}
}
