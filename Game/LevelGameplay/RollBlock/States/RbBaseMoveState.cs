using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay.RollBlock.States
{
	// Token: 0x02006B23 RID: 27427
	public class RbBaseMoveState
	{
		// Token: 0x06043C5E RID: 277598 RVA: 0x0118169C File Offset: 0x0117F89C
		[NullableContext(1)]
		public RbBaseMoveState(RbBlockComponent owner)
		{
			this.Owner = owner;
			MethodInfo method = base.GetType().GetMethod("Update", BindingFlags.Instance | BindingFlags.Public);
			MethodInfo method2 = typeof(RbBaseMoveState).GetMethod("Update", BindingFlags.Instance | BindingFlags.Public);
			this.NeedUpdate = (method != null && method2 != null && method != method2);
			this.IsFinishedInternal = false;
		}

		// Token: 0x06043C5F RID: 277599 RVA: 0x01181710 File Offset: 0x0117F910
		public virtual void Enter([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<RbBlockIdlePbState, RbJumpMovement, RbRollMovement> info)
		{
		}

		// Token: 0x06043C60 RID: 277600 RVA: 0x01181712 File Offset: 0x0117F912
		public virtual void Exit()
		{
		}

		// Token: 0x06043C61 RID: 277601 RVA: 0x01181714 File Offset: 0x0117F914
		public virtual void Update(float delta)
		{
		}

		// Token: 0x06043C62 RID: 277602 RVA: 0x01181716 File Offset: 0x0117F916
		public bool IsFinished()
		{
			return this.IsFinishedInternal;
		}

		// Token: 0x06043C63 RID: 277603 RVA: 0x01181720 File Offset: 0x0117F920
		protected void NotifyServerMovementFinish()
		{
			RollBlockMovementFinishRequest rollBlockMovementFinishRequest = RollBlockMovementFinishRequest.Create();
			rollBlockMovementFinishRequest.IncId = this.Owner.IncId;
			rollBlockMovementFinishRequest.EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.Owner.CreatureDataId);
			Singleton<Net>.Instance.Call<RollBlockMovementFinishResponse>(ERequestMessageId.RollBlockMovementFinishRequest, rollBlockMovementFinishRequest, null, 0);
		}

		// Token: 0x04025E71 RID: 155249
		[Nullable(2)]
		protected RbBlockComponent Owner;

		// Token: 0x04025E72 RID: 155250
		public bool NeedUpdate;

		// Token: 0x04025E73 RID: 155251
		public ERollBlockMoveState StateName = ERollBlockMoveState.Idle;

		// Token: 0x04025E74 RID: 155252
		protected bool IsFinishedInternal;
	}
}
