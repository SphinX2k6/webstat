using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DB9 RID: 11705
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicAdditiveAccelerateController : BulletLogicController<LogicDataAdditiveAccelerate, object>
{
	// Token: 0x060179CA RID: 96714 RVA: 0x00691C5B File Offset: 0x0068FE5B
	[NullableContext(1)]
	public BulletLogicAdditiveAccelerateController(LogicDataAdditiveAccelerate bulletLogicBase, Entity bullet) : base(bulletLogicBase, bullet)
	{
		this.BulletInfo = (bullet as BulletEntity).GetBulletInfo();
	}

	// Token: 0x060179CB RID: 96715 RVA: 0x00691C78 File Offset: 0x0068FE78
	public override void BulletLogicAction(object param = null)
	{
		LogicDataAdditiveAccelerate logicController = this.LogicController;
		if (this.BulletInfo.BulletDataMain.Move.Trajectory == EMoveTrajectory.限时命中子弹)
		{
			return;
		}
		BulletMoveInfo moveInfo = this.BulletInfo.MoveInfo;
		CharacterMoveComponent attackerMoveComp = this.BulletInfo.AttackerMoveComp;
		FVector acceleration;
		if (attackerMoveComp != null && attackerMoveComp.IsStandardGravity)
		{
			moveInfo.AdditiveAccelerateCurve = logicController.AccelerationCurve;
			Vector baseAdditiveAccelerate = moveInfo.BaseAdditiveAccelerate;
			acceleration = logicController.Acceleration;
			baseAdditiveAccelerate.FromUeVector(acceleration);
			Vector additiveAccelerate = moveInfo.AdditiveAccelerate;
			acceleration = logicController.Acceleration;
			additiveAccelerate.FromUeVector(acceleration);
			return;
		}
		Quat quat = Quat.Create(0f, 0f, 0f, 1f);
		Singleton<GravityUtils>.Instance.GetBaseQuatInGravityForActor(this.BulletInfo.AttackerActorComp, quat);
		Vector vector = BulletPool.CreateVector(false);
		Vector vector2 = vector;
		acceleration = logicController.Acceleration;
		vector2.FromUeVector(acceleration);
		quat.RotateVector(vector, moveInfo.BaseAdditiveAccelerate);
		BulletPool.RecycleVector(vector);
		moveInfo.AdditiveAccelerate.FromUeVector(moveInfo.BaseAdditiveAccelerate);
	}

	// Token: 0x0400B5D1 RID: 46545
	private readonly BulletInfo BulletInfo;
}
