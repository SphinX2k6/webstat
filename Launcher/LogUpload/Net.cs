using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045F2 RID: 17906
	[NullableContext(1)]
	[Nullable(0)]
	public class Net : INet
	{
		// Token: 0x17008091 RID: 32913
		// (get) Token: 0x0602EDC1 RID: 191937 RVA: 0x00B18EE2 File Offset: 0x00B170E2
		// (set) Token: 0x0602EDC2 RID: 191938 RVA: 0x00B18EEA File Offset: 0x00B170EA
		public Func<bool> IsServerConnected { get; set; }
	}
}
