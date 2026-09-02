using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x02007043 RID: 28739
	[NullableContext(2)]
	[Nullable(0)]
	public class SkeletalMeshEffectContext : EffectContext
	{
		// Token: 0x060458C9 RID: 284873 RVA: 0x0122D38E File Offset: 0x0122B58E
		public SkeletalMeshEffectContext(int? entityId = null, UObject sourceObject = null, bool disablePostProcess = false) : base(entityId, sourceObject, disablePostProcess)
		{
		}

		// Token: 0x060458CA RID: 284874 RVA: 0x0122D39C File Offset: 0x0122B59C
		[NullableContext(1)]
		public override void ToKuroEffectContext(FKuroEffectContext context)
		{
			base.ToKuroEffectContext(context);
			FKuroSkeletalMeshEffectContext fkuroSkeletalMeshEffectContext = context as FKuroSkeletalMeshEffectContext;
			if (fkuroSkeletalMeshEffectContext != null)
			{
				fkuroSkeletalMeshEffectContext.SkeletalMeshComponent = this.SkeletalMeshComp;
				fkuroSkeletalMeshEffectContext.IsSyncTimeDilation = this.IsSyncEffectTimeScale;
				fkuroSkeletalMeshEffectContext.IsSyncEventTimeToEffectTime = this.IsSyncEventTimeToEffectTime;
			}
		}

		// Token: 0x04026D53 RID: 159059
		public USkeletalMeshComponent SkeletalMeshComp;

		// Token: 0x04026D54 RID: 159060
		public bool IsSyncEffectTimeScale;

		// Token: 0x04026D55 RID: 159061
		public bool IsSyncEventTimeToEffectTime;
	}
}
