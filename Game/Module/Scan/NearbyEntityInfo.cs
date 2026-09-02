using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Scan
{
	// Token: 0x0200500B RID: 20491
	internal class NearbyEntityInfo
	{
		// Token: 0x06034D27 RID: 216359 RVA: 0x00D42A7B File Offset: 0x00D40C7B
		[NullableContext(1)]
		public NearbyEntityInfo(Entity entity, double distance)
		{
			this.Entity = entity;
			this.Distance = distance;
		}

		// Token: 0x0401E71C RID: 124700
		[Nullable(2)]
		public Entity Entity;

		// Token: 0x0401E71D RID: 124701
		public double Distance;
	}
}
