using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070AF RID: 28847
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneCameraFollowConfig
	{
		// Token: 0x06045EE8 RID: 286440 RVA: 0x01253111 File Offset: 0x01251311
		public SceneCameraFollowConfig Set(ESceneCameraFollowTargetType targetType, int entityId = 0)
		{
			this.TargetType = targetType;
			this.EntityId = entityId;
			return this;
		}

		// Token: 0x06045EE9 RID: 286441 RVA: 0x01253122 File Offset: 0x01251322
		public void DeepCopy(SceneCameraFollowConfig source)
		{
			this.TargetType = source.TargetType;
			this.EntityId = source.EntityId;
		}

		// Token: 0x06045EEA RID: 286442 RVA: 0x0125313C File Offset: 0x0125133C
		public void Reset()
		{
			this.TargetType = ESceneCameraFollowTargetType.Player;
			this.EntityId = 0;
		}

		// Token: 0x040272BA RID: 160442
		public ESceneCameraFollowTargetType TargetType;

		// Token: 0x040272BB RID: 160443
		public int EntityId;
	}
}
