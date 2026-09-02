using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection
{
	// Token: 0x0200451F RID: 17695
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixNetworkDetectSelectData : IHotFixNetworkDetectSelectData, IHotFixLayoutData
	{
		// Token: 0x17008049 RID: 32841
		// (get) Token: 0x0602E9DB RID: 190939 RVA: 0x00B0B2DA File Offset: 0x00B094DA
		// (set) Token: 0x0602E9DC RID: 190940 RVA: 0x00B0B2E2 File Offset: 0x00B094E2
		public int? Index { get; set; }

		// Token: 0x1700804A RID: 32842
		// (get) Token: 0x0602E9DD RID: 190941 RVA: 0x00B0B2EB File Offset: 0x00B094EB
		// (set) Token: 0x0602E9DE RID: 190942 RVA: 0x00B0B2F3 File Offset: 0x00B094F3
		public ILoginServersData LoginServersData { get; set; }
	}
}
