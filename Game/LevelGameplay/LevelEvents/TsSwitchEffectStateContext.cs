using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C02 RID: 27650
	[NullableContext(1)]
	[Nullable(0)]
	internal class TsSwitchEffectStateContext : IEffectContext
	{
		// Token: 0x1700A34E RID: 41806
		// (get) Token: 0x0604413E RID: 278846 RVA: 0x011AC30D File Offset: 0x011AA50D
		// (set) Token: 0x0604413F RID: 278847 RVA: 0x011AC315 File Offset: 0x011AA515
		public string AssetPath { get; set; }

		// Token: 0x06044140 RID: 278848 RVA: 0x011AC31E File Offset: 0x011AA51E
		public TsSwitchEffectStateContext(string assetPath)
		{
			this.AssetPath = assetPath;
		}
	}
}
