using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay.RollBlock.States
{
	// Token: 0x02006B24 RID: 27428
	public class RbIdleState : RbBaseMoveState
	{
		// Token: 0x06043C64 RID: 277604 RVA: 0x01181771 File Offset: 0x0117F971
		[NullableContext(1)]
		public RbIdleState(RbBlockComponent owner) : base(owner)
		{
		}

		// Token: 0x06043C65 RID: 277605 RVA: 0x0118177C File Offset: 0x0117F97C
		public override void Enter([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<RbBlockIdlePbState, RbJumpMovement, RbRollMovement> info)
		{
			if (!RollBlockDefind.isRbBlockIdleState(info))
			{
				Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "RbIdleState Enter without IdleState info", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.StateName = ERollBlockMoveState.Idle;
			this.Info = info.AsT1;
			this.Owner.AvailableInputDirs = new List<RbGridDirection>();
			global::Vector vector = global::Vector.Create();
			vector.FromConfigVector(this.Info.Position);
			global::Rotator rotation = global::Rotator.Create(this.Info.Rotation.Y, this.Info.Rotation.Z, this.Info.Rotation.X);
			this.Owner.SetActorLocationAndRotation(vector, rotation);
			this.IsFinishedInternal = true;
		}

		// Token: 0x04025E75 RID: 155253
		[Nullable(2)]
		public RbBlockIdlePbState Info;
	}
}
