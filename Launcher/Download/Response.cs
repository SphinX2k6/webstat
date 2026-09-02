using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x02004624 RID: 17956
	[NullableContext(1)]
	[Nullable(0)]
	public class Response : IResponse
	{
		// Token: 0x17008099 RID: 32921
		// (get) Token: 0x0602EEA3 RID: 192163 RVA: 0x00B1C8C9 File Offset: 0x00B1AAC9
		// (set) Token: 0x0602EEA4 RID: 192164 RVA: 0x00B1C8D1 File Offset: 0x00B1AAD1
		public int Code { get; set; }

		// Token: 0x1700809A RID: 32922
		// (get) Token: 0x0602EEA5 RID: 192165 RVA: 0x00B1C8DA File Offset: 0x00B1AADA
		// (set) Token: 0x0602EEA6 RID: 192166 RVA: 0x00B1C8E2 File Offset: 0x00B1AAE2
		public string Result { get; set; }
	}
}
