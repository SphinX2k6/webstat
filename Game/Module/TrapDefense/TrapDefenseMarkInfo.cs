using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DFB RID: 19963
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseMarkInfo : ITrapDefenseMarkInfo
	{
		// Token: 0x170088BF RID: 35007
		// (get) Token: 0x060339D2 RID: 211410 RVA: 0x00CE4C30 File Offset: 0x00CE2E30
		// (set) Token: 0x060339D3 RID: 211411 RVA: 0x00CE4C38 File Offset: 0x00CE2E38
		public int MarkId { get; set; }

		// Token: 0x170088C0 RID: 35008
		// (get) Token: 0x060339D4 RID: 211412 RVA: 0x00CE4C41 File Offset: 0x00CE2E41
		// (set) Token: 0x060339D5 RID: 211413 RVA: 0x00CE4C49 File Offset: 0x00CE2E49
		public TrapDefenseDefine.ETrapDefenseMarkType MarkType { get; set; }

		// Token: 0x170088C1 RID: 35009
		// (get) Token: 0x060339D6 RID: 211414 RVA: 0x00CE4C52 File Offset: 0x00CE2E52
		// (set) Token: 0x060339D7 RID: 211415 RVA: 0x00CE4C5A File Offset: 0x00CE2E5A
		public object ExtraParam { get; set; }
	}
}
