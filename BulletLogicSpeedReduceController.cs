using System;
using System.Runtime.CompilerServices;

// Token: 0x02002DCD RID: 11725
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicSpeedReduceController : BulletLogicController<LogicDataSpeedReduce, object>
{
	// Token: 0x06017A23 RID: 96803 RVA: 0x006953B0 File Offset: 0x006935B0
	public BulletLogicSpeedReduceController(LogicDataSpeedReduce bulletLogicBase, Entity bullet) : base(bulletLogicBase, bullet)
	{
		this.BulletInfo = this.Bullet.GetBulletInfo();
		this.Parameter = bulletLogicBase;
	}

	// Token: 0x06017A24 RID: 96804 RVA: 0x006953D4 File Offset: 0x006935D4
	[NullableContext(2)]
	public override void BulletLogicAction(object param = null)
	{
		float num = this.BulletInfo.AttackerMoveComp.CharacterWeight;
		num = ((num < 50f) ? 50f : num);
		Entity firstVictim = this.BulletInfo.CollisionInfo.GetFirstVictim(new EBulletHitActorType[]
		{
			EBulletHitActorType.Character
		});
		if (firstVictim == null || !firstVictim.Valid)
		{
			return;
		}
		float? num2 = (firstVictim != null) ? new float?(firstVictim.GetComponent<CharacterMoveComponent>().CharacterWeight) : null;
		float? num3 = num2;
		float num4 = 50f;
		num2 = ((num3.GetValueOrDefault() < num4 & num3 != null) ? new float?(50f) : num2);
		float? num5 = num - num2 * 0.1f * this.Parameter.SpeedDampingRatio;
		float? num6 = num + num2 * 0.1f * this.Parameter.SpeedDampingRatio;
		num3 = num6;
		num4 = 1E-05f;
		float? num7;
		if (!(num3.GetValueOrDefault() < num4 & num3 != null))
		{
			num3 = num5;
			num4 = 0f;
			if (!(num3.GetValueOrDefault() < num4 & num3 != null))
			{
				num7 = this.BulletInfo.MoveInfo.BulletSpeed * (num5 / num6);
				goto IL_271;
			}
		}
		num7 = new float?(0f);
		IL_271:
		float? num8 = num7;
		num3 = num8;
		num4 = 0f;
		num8 = ((num3.GetValueOrDefault() > num4 & num3 != null) ? num8 : new float?(0f));
		num3 = num8;
		num4 = this.Parameter.MinSpeed;
		num8 = ((num3.GetValueOrDefault() < num4 & num3 != null) ? new float?(0f) : num8);
		this.BulletInfo.MoveInfo.BulletSpeed = num8.Value;
	}

	// Token: 0x06017A25 RID: 96805 RVA: 0x006956D2 File Offset: 0x006938D2
	[NullableContext(2)]
	public override void BulletLogicActionOnHitObstacles(object param = null)
	{
		if (!this.Parameter.IsNotThroughObstacles)
		{
			return;
		}
		this.BulletInfo.MoveInfo.BulletSpeed = 0f;
	}

	// Token: 0x0400B61F RID: 46623
	private const float TOLERANCE = 1E-05f;

	// Token: 0x0400B620 RID: 46624
	private const float MIN_WEIGHT = 50f;

	// Token: 0x0400B621 RID: 46625
	private readonly LogicDataSpeedReduce Parameter;

	// Token: 0x0400B622 RID: 46626
	private readonly BulletInfo BulletInfo;
}
