using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006934 RID: 26932
	[NullableContext(1)]
	[Nullable(0)]
	public class IDropPoolRuntime
	{
		// Token: 0x040253F0 RID: 152560
		public int PoolId;

		// Token: 0x040253F1 RID: 152561
		public double LastSpawnTime;

		// Token: 0x040253F2 RID: 152562
		public DropCatchGameplayAttribute SpawnTimeInterval;

		// Token: 0x040253F3 RID: 152563
		public double LastSpawnPosX;

		// Token: 0x040253F4 RID: 152564
		public double SpawnPosInterval;

		// Token: 0x040253F5 RID: 152565
		public IAliasTable AliasTable;

		// Token: 0x040253F6 RID: 152566
		public List<double> TimeRange = new List<double>();
	}
}
