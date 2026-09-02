using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F67 RID: 24423
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiHoverTipsDescInfoC : IBattleUiHoverTipsDescInfoC
	{
		// Token: 0x17009A50 RID: 39504
		// (get) Token: 0x0603D532 RID: 251186 RVA: 0x00F98DC5 File Offset: 0x00F96FC5
		// (set) Token: 0x0603D533 RID: 251187 RVA: 0x00F98DCD File Offset: 0x00F96FCD
		[Nullable(2)]
		public string TitleKey { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009A51 RID: 39505
		// (get) Token: 0x0603D534 RID: 251188 RVA: 0x00F98DD6 File Offset: 0x00F96FD6
		// (set) Token: 0x0603D535 RID: 251189 RVA: 0x00F98DDE File Offset: 0x00F96FDE
		public string DescKey { get; set; }
	}
}
