using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F63 RID: 24419
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiHoverTipsDescInfo : IBattleUiHoverTipsDescInfo
	{
		// Token: 0x17009A45 RID: 39493
		// (get) Token: 0x0603D51A RID: 251162 RVA: 0x00F98D3E File Offset: 0x00F96F3E
		// (set) Token: 0x0603D51B RID: 251163 RVA: 0x00F98D46 File Offset: 0x00F96F46
		public string DescKey { get; set; }

		// Token: 0x17009A46 RID: 39494
		// (get) Token: 0x0603D51C RID: 251164 RVA: 0x00F98D4F File Offset: 0x00F96F4F
		// (set) Token: 0x0603D51D RID: 251165 RVA: 0x00F98D57 File Offset: 0x00F96F57
		public bool? DescUseChangeColor { get; set; }

		// Token: 0x17009A47 RID: 39495
		// (get) Token: 0x0603D51E RID: 251166 RVA: 0x00F98D60 File Offset: 0x00F96F60
		// (set) Token: 0x0603D51F RID: 251167 RVA: 0x00F98D68 File Offset: 0x00F96F68
		[Nullable(2)]
		public string StateTitleKey { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009A48 RID: 39496
		// (get) Token: 0x0603D520 RID: 251168 RVA: 0x00F98D71 File Offset: 0x00F96F71
		// (set) Token: 0x0603D521 RID: 251169 RVA: 0x00F98D79 File Offset: 0x00F96F79
		public bool? IsUnlock { get; set; }

		// Token: 0x17009A49 RID: 39497
		// (get) Token: 0x0603D522 RID: 251170 RVA: 0x00F98D82 File Offset: 0x00F96F82
		// (set) Token: 0x0603D523 RID: 251171 RVA: 0x00F98D8A File Offset: 0x00F96F8A
		public bool? IsShowState { get; set; }
	}
}
