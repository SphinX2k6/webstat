using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002DCF RID: 11727
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicSummonRandom : BulletLogicController<LogicDataSummonRandom, object>
{
	// Token: 0x06017A29 RID: 96809 RVA: 0x0069590E File Offset: 0x00693B0E
	public BulletLogicSummonRandom(LogicDataSummonRandom logicController, Entity bullet) : base(logicController, bullet)
	{
	}

	// Token: 0x06017A2A RID: 96810 RVA: 0x00695918 File Offset: 0x00693B18
	[NullableContext(2)]
	public override void BulletLogicAction(object param = null)
	{
		BulletInfo bulletInfo = this.Bullet.GetBulletInfo();
		Entity attacker = bulletInfo.Attacker;
		FRotator frotator = bulletInfo.GetActorRotation().ToUeRotator();
		FVectorDouble fvectorDouble = bulletInfo.GetActorLocation().ToUeVector(false);
		FTransformDouble transform = new FTransformDouble(ref frotator, ref fvectorDouble, ref FVector.OneVector);
		ControllerBase<CreatureController>.Instance.SummonRandomRequest(attacker.Id, this.LogicController.SummonIndex, transform, this.LogicController.SkillId, this.LogicController.IsVisible);
	}

	// Token: 0x06017A2B RID: 96811 RVA: 0x00695994 File Offset: 0x00693B94
	public override void OnBulletDestroy()
	{
		if (!this.LogicController.DestroySummonOnDestroy)
		{
			return;
		}
		Entity attacker = this.Bullet.GetBulletInfo().Attacker;
		long summonRandomEntityId = attacker.GetComponent<CreatureDataComponent>().GetSummonRandomEntityId(this.LogicController.SummonIndex);
		if (summonRandomEntityId != 0L)
		{
			ControllerBase<CreatureController>.Instance.RemoveSummonEntityByServerIdRequest(this.LogicController.SkillId, attacker.Id, (long)((int)summonRandomEntityId));
		}
	}
}
