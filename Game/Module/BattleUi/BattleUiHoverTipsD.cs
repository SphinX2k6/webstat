using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F61 RID: 24417
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiHoverTipsD : IBattleUiHoverTipsD
	{
		// Token: 0x17009A3A RID: 39482
		// (get) Token: 0x0603D503 RID: 251139 RVA: 0x00F98CD0 File Offset: 0x00F96ED0
		// (set) Token: 0x0603D504 RID: 251140 RVA: 0x00F98CD8 File Offset: 0x00F96ED8
		public string TitleKey { get; set; }

		// Token: 0x17009A3B RID: 39483
		// (get) Token: 0x0603D505 RID: 251141 RVA: 0x00F98CE1 File Offset: 0x00F96EE1
		// (set) Token: 0x0603D506 RID: 251142 RVA: 0x00F98CE9 File Offset: 0x00F96EE9
		public FColor? TitleColor { get; set; }

		// Token: 0x17009A3C RID: 39484
		// (get) Token: 0x0603D507 RID: 251143 RVA: 0x00F98CF2 File Offset: 0x00F96EF2
		// (set) Token: 0x0603D508 RID: 251144 RVA: 0x00F98CFA File Offset: 0x00F96EFA
		[Nullable(2)]
		public string SubTitleKey { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009A3D RID: 39485
		// (get) Token: 0x0603D509 RID: 251145 RVA: 0x00F98D03 File Offset: 0x00F96F03
		// (set) Token: 0x0603D50A RID: 251146 RVA: 0x00F98D0B File Offset: 0x00F96F0B
		public IMediumItemGridBase ItemInfo { get; set; }

		// Token: 0x17009A3E RID: 39486
		// (get) Token: 0x0603D50B RID: 251147 RVA: 0x00F98D14 File Offset: 0x00F96F14
		// (set) Token: 0x0603D50C RID: 251148 RVA: 0x00F98D1C File Offset: 0x00F96F1C
		public List<IBattleUiHoverTipsDescInfo> DescInfoList { get; set; }

		// Token: 0x17009A3F RID: 39487
		// (get) Token: 0x0603D50D RID: 251149 RVA: 0x00F98D25 File Offset: 0x00F96F25
		// (set) Token: 0x0603D50E RID: 251150 RVA: 0x00F98D2D File Offset: 0x00F96F2D
		[Nullable(2)]
		public string DescTitleKey { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
