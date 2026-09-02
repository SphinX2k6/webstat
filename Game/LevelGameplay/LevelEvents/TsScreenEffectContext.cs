using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BFF RID: 27647
	[NullableContext(1)]
	[Nullable(0)]
	internal class TsScreenEffectContext : IEffectContext
	{
		// Token: 0x1700A34B RID: 41803
		// (get) Token: 0x06044135 RID: 278837 RVA: 0x011AC2AD File Offset: 0x011AA4AD
		// (set) Token: 0x06044136 RID: 278838 RVA: 0x011AC2B5 File Offset: 0x011AA4B5
		public string AssetPath { get; set; }

		// Token: 0x06044137 RID: 278839 RVA: 0x011AC2BE File Offset: 0x011AA4BE
		public TsScreenEffectContext(string assetPath)
		{
			this.AssetPath = assetPath;
		}
	}
}
