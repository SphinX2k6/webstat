using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList
{
	// Token: 0x02004BCF RID: 19407
	[NullableContext(1)]
	public interface IWorldMapSecondaryTipItemParam
	{
		// Token: 0x170086F7 RID: 34551
		// (get) Token: 0x06032A67 RID: 207463
		// (set) Token: 0x06032A68 RID: 207464
		string Name { get; set; }

		// Token: 0x170086F8 RID: 34552
		// (get) Token: 0x06032A69 RID: 207465
		// (set) Token: 0x06032A6A RID: 207466
		string Desc { get; set; }
	}
}
