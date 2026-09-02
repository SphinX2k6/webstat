using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004687 RID: 18055
	public class IUdpProbe
	{
		// Token: 0x0401ACBD RID: 109757
		[Nullable(1)]
		public string ip;

		// Token: 0x0401ACBE RID: 109758
		public int port;

		// Token: 0x0401ACBF RID: 109759
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, string> ext;
	}
}
