using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F66 RID: 24422
	[NullableContext(1)]
	public interface IBattleUiHoverTipsDescInfoC
	{
		// Token: 0x17009A4E RID: 39502
		// (get) Token: 0x0603D52E RID: 251182
		// (set) Token: 0x0603D52F RID: 251183
		[Nullable(2)]
		string TitleKey { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009A4F RID: 39503
		// (get) Token: 0x0603D530 RID: 251184
		// (set) Token: 0x0603D531 RID: 251185
		string DescKey { get; set; }
	}
}
