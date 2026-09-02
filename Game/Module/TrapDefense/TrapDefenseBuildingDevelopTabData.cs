using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DCA RID: 19914
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopTabData : ITrapDefenseBuildingDevelopTabData
	{
		// Token: 0x1700883A RID: 34874
		// (get) Token: 0x060338D2 RID: 211154 RVA: 0x00CE4679 File Offset: 0x00CE2879
		// (set) Token: 0x060338D3 RID: 211155 RVA: 0x00CE4681 File Offset: 0x00CE2881
		public ETrapDefenseBuildingDevelopTab TabType { get; set; }

		// Token: 0x1700883B RID: 34875
		// (get) Token: 0x060338D4 RID: 211156 RVA: 0x00CE468A File Offset: 0x00CE288A
		// (set) Token: 0x060338D5 RID: 211157 RVA: 0x00CE4692 File Offset: 0x00CE2892
		public string Icon { get; set; } = "";

		// Token: 0x1700883C RID: 34876
		// (get) Token: 0x060338D6 RID: 211158 RVA: 0x00CE469B File Offset: 0x00CE289B
		// (set) Token: 0x060338D7 RID: 211159 RVA: 0x00CE46A3 File Offset: 0x00CE28A3
		public string TabName { get; set; } = "";

		// Token: 0x1700883D RID: 34877
		// (get) Token: 0x060338D8 RID: 211160 RVA: 0x00CE46AC File Offset: 0x00CE28AC
		// (set) Token: 0x060338D9 RID: 211161 RVA: 0x00CE46B4 File Offset: 0x00CE28B4
		public ERedDotName? RedDot { get; set; }
	}
}
