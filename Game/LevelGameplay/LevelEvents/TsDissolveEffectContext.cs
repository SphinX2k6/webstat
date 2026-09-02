using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C00 RID: 27648
	[NullableContext(1)]
	[Nullable(0)]
	internal class TsDissolveEffectContext : IEffectContext
	{
		// Token: 0x1700A34C RID: 41804
		// (get) Token: 0x06044138 RID: 278840 RVA: 0x011AC2CD File Offset: 0x011AA4CD
		// (set) Token: 0x06044139 RID: 278841 RVA: 0x011AC2D5 File Offset: 0x011AA4D5
		public string AssetPath { get; set; }

		// Token: 0x0604413A RID: 278842 RVA: 0x011AC2DE File Offset: 0x011AA4DE
		public TsDissolveEffectContext(string assetPath)
		{
			this.AssetPath = assetPath;
		}
	}
}
