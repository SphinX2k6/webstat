using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x02007042 RID: 28738
	public class EffectRuntimeGhostEffectContext : SkeletalMeshEffectContext
	{
		// Token: 0x060458C7 RID: 284871 RVA: 0x0122D310 File Offset: 0x0122B510
		[NullableContext(2)]
		public EffectRuntimeGhostEffectContext(int? entityId = null, UObject sourceObject = null, bool disablePostProcess = false) : base(entityId, sourceObject, disablePostProcess)
		{
		}

		// Token: 0x060458C8 RID: 284872 RVA: 0x0122D334 File Offset: 0x0122B534
		[NullableContext(1)]
		public override void ToKuroEffectContext(FKuroEffectContext context)
		{
			base.ToKuroEffectContext(context);
			FKuroEffectRuntimeGhostEffectContext fkuroEffectRuntimeGhostEffectContext = context as FKuroEffectRuntimeGhostEffectContext;
			if (fkuroEffectRuntimeGhostEffectContext != null)
			{
				fkuroEffectRuntimeGhostEffectContext.SpawnRate = this.SpawnRate;
				fkuroEffectRuntimeGhostEffectContext.UseSpawnRate = this.UseSpawnRate;
				fkuroEffectRuntimeGhostEffectContext.SpawnInterval = this.SpawnInterval;
				fkuroEffectRuntimeGhostEffectContext.GhostLifeTime = this.GhostLifeTime;
				fkuroEffectRuntimeGhostEffectContext.UseBaseColorTex = this.UseBaseColorTex;
			}
		}

		// Token: 0x04026D4E RID: 159054
		public float SpawnRate = --0f;

		// Token: 0x04026D4F RID: 159055
		public bool UseSpawnRate;

		// Token: 0x04026D50 RID: 159056
		public float SpawnInterval;

		// Token: 0x04026D51 RID: 159057
		public float GhostLifeTime = --0f;

		// Token: 0x04026D52 RID: 159058
		public bool UseBaseColorTex;
	}
}
