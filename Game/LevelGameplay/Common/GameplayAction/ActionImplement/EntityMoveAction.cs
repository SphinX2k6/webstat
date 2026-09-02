using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction.ActionImplement
{
	// Token: 0x02006F38 RID: 28472
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class EntityMoveAction : GameplayAction
	{
		// Token: 0x1700A454 RID: 42068
		// (get) Token: 0x06044ECA RID: 282314 RVA: 0x011F14DC File Offset: 0x011EF6DC
		protected override bool NeedTickInner
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06044ECB RID: 282315 RVA: 0x011F14DF File Offset: 0x011EF6DF
		[NullableContext(1)]
		public void Init(EntityHandle moveEntity, IMoveConfig config, Vector targetLocation, Rotator targetRotator)
		{
			this.MoveEntityHandle = moveEntity;
			this.Config = config;
			this.TargetLocation = targetLocation;
			this.TargetRotator = targetRotator;
		}

		// Token: 0x06044ECC RID: 282316 RVA: 0x011F14FE File Offset: 0x011EF6FE
		protected BaseActorComponent GetMoveActorComp()
		{
			if (this.MoveEntityHandle == null || !this.MoveEntityHandle.IsInit)
			{
				return null;
			}
			return this.MoveEntityHandle.Entity.GetComponent<BaseActorComponent>();
		}

		// Token: 0x040266E4 RID: 157412
		protected IMoveConfig Config;

		// Token: 0x040266E5 RID: 157413
		protected EntityHandle MoveEntityHandle;

		// Token: 0x040266E6 RID: 157414
		protected Vector TargetLocation;

		// Token: 0x040266E7 RID: 157415
		protected Rotator TargetRotator;
	}
}
