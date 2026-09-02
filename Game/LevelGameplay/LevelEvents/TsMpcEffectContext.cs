using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C01 RID: 27649
	[NullableContext(1)]
	[Nullable(0)]
	internal class TsMpcEffectContext : IEffectContext
	{
		// Token: 0x1700A34D RID: 41805
		// (get) Token: 0x0604413B RID: 278843 RVA: 0x011AC2ED File Offset: 0x011AA4ED
		// (set) Token: 0x0604413C RID: 278844 RVA: 0x011AC2F5 File Offset: 0x011AA4F5
		public string AssetPath { get; set; }

		// Token: 0x0604413D RID: 278845 RVA: 0x011AC2FE File Offset: 0x011AA4FE
		public TsMpcEffectContext(string assetPath)
		{
			this.AssetPath = assetPath;
		}
	}
}
