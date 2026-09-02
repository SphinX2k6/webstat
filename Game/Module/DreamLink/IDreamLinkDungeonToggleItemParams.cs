using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005D9A RID: 23962
	[NullableContext(1)]
	public interface IDreamLinkDungeonToggleItemParams
	{
		// Token: 0x170098AA RID: 39082
		// (get) Token: 0x0603C572 RID: 247154
		// (set) Token: 0x0603C573 RID: 247155
		string TextureBgPath { get; set; }

		// Token: 0x170098AB RID: 39083
		// (get) Token: 0x0603C574 RID: 247156
		// (set) Token: 0x0603C575 RID: 247157
		string TextureLightPath { get; set; }

		// Token: 0x170098AC RID: 39084
		// (get) Token: 0x0603C576 RID: 247158
		// (set) Token: 0x0603C577 RID: 247159
		string EffectColor { get; set; }
	}
}
