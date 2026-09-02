using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F60 RID: 24416
	[NullableContext(1)]
	public interface IBattleUiHoverTipsD
	{
		// Token: 0x17009A34 RID: 39476
		// (get) Token: 0x0603D4F7 RID: 251127
		// (set) Token: 0x0603D4F8 RID: 251128
		string TitleKey { get; set; }

		// Token: 0x17009A35 RID: 39477
		// (get) Token: 0x0603D4F9 RID: 251129
		// (set) Token: 0x0603D4FA RID: 251130
		FColor? TitleColor { get; set; }

		// Token: 0x17009A36 RID: 39478
		// (get) Token: 0x0603D4FB RID: 251131
		// (set) Token: 0x0603D4FC RID: 251132
		[Nullable(2)]
		string SubTitleKey { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009A37 RID: 39479
		// (get) Token: 0x0603D4FD RID: 251133
		// (set) Token: 0x0603D4FE RID: 251134
		IMediumItemGridBase ItemInfo { get; set; }

		// Token: 0x17009A38 RID: 39480
		// (get) Token: 0x0603D4FF RID: 251135
		// (set) Token: 0x0603D500 RID: 251136
		List<IBattleUiHoverTipsDescInfo> DescInfoList { get; set; }

		// Token: 0x17009A39 RID: 39481
		// (get) Token: 0x0603D501 RID: 251137
		// (set) Token: 0x0603D502 RID: 251138
		[Nullable(2)]
		string DescTitleKey { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
