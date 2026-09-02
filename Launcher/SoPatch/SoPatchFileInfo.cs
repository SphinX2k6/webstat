using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.SoPatch
{
	// Token: 0x02004530 RID: 17712
	[NullableContext(1)]
	[Nullable(0)]
	public class SoPatchFileInfo
	{
		// Token: 0x0401A7D1 RID: 108497
		public string Name = "";

		// Token: 0x0401A7D2 RID: 108498
		public int Size;

		// Token: 0x0401A7D3 RID: 108499
		public string Hash = "";

		// Token: 0x0401A7D4 RID: 108500
		public string Md5 = "";

		// Token: 0x0401A7D5 RID: 108501
		public string DestHash = "";
	}
}
