using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Dango.DangoAbyssGetDangoView
{
	// Token: 0x02005DE8 RID: 24040
	[NullableContext(1)]
	[Nullable(0)]
	public class DangoAbyssGetDangoViewParams
	{
		// Token: 0x170098D2 RID: 39122
		// (get) Token: 0x0603C7FD RID: 247805 RVA: 0x00F5D5C4 File Offset: 0x00F5B7C4
		// (set) Token: 0x0603C7FE RID: 247806 RVA: 0x00F5D5CC File Offset: 0x00F5B7CC
		public DangoAbyssDefine.IDangoUnlockData[] DataList { get; set; }

		// Token: 0x170098D3 RID: 39123
		// (get) Token: 0x0603C7FF RID: 247807 RVA: 0x00F5D5D5 File Offset: 0x00F5B7D5
		// (set) Token: 0x0603C800 RID: 247808 RVA: 0x00F5D5DD File Offset: 0x00F5B7DD
		public int ShowTime { get; set; }
	}
}
