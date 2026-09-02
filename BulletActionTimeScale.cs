using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils;

// Token: 0x02002D93 RID: 11667
public class BulletActionTimeScale : BulletActionBase
{
	// Token: 0x06017867 RID: 96359 RVA: 0x0068A43C File Offset: 0x0068863C
	public BulletActionTimeScale(EBulletAction type) : base(type)
	{
	}

	// Token: 0x06017868 RID: 96360 RVA: 0x0068A448 File Offset: 0x00688648
	protected override void OnExecute()
	{
		if (this.BulletInfo.BulletDataMain.TimeScale.TimeScaleWithAttacker)
		{
			this.BulletAttackerTimeScaleComponent = this.BulletInfo.Attacker.GetComponent<PawnTimeScaleComponent>();
			return;
		}
		BulletInfo bulletInfo = this.BulletInfo;
		Comparison<TimeScale> compare;
		if ((compare = BulletActionTimeScale.<>O.<0>__CompareScalePriority) == null)
		{
			compare = (BulletActionTimeScale.<>O.<0>__CompareScalePriority = new Comparison<TimeScale>(PawnTimeScaleComponent.CompareScalePriority));
		}
		bulletInfo.TimeScaleList = new PriorityQueue<TimeScale>(compare);
		this.BulletInfo.TimeScaleMap = new Dictionary<int, TimeScale>();
		this.BulletInfo.TimeScaleId = 1;
		double worldTimeSeconds = Singleton<Time>.Instance.WorldTimeSeconds;
		Dictionary<int, BulletPersistentTimeScale> persistentTimeScaleMap = ModelBase<BulletModel>.Instance.PersistentTimeScaleMap;
		foreach (BulletPersistentTimeScale bulletPersistentTimeScale in persistentTimeScaleMap.Values)
		{
			double num = worldTimeSeconds - (double)bulletPersistentTimeScale.StartTime;
			if (num >= (double)bulletPersistentTimeScale.Duration)
			{
				persistentTimeScaleMap.Remove(bulletPersistentTimeScale.TimeScaleId);
			}
			else
			{
				if (bulletPersistentTimeScale.CenterLocation != null)
				{
					Vector lastFramePosition = this.BulletInfo.CollisionInfo.LastFramePosition;
					if (lastFramePosition == null || Math.Abs(lastFramePosition.X - bulletPersistentTimeScale.CenterLocation.X) > (double)bulletPersistentTimeScale.Radius || Math.Abs(lastFramePosition.Y - bulletPersistentTimeScale.CenterLocation.Y) > (double)bulletPersistentTimeScale.Radius || Math.Abs(lastFramePosition.Z - bulletPersistentTimeScale.CenterLocation.Z) > (double)bulletPersistentTimeScale.Radius)
					{
						continue;
					}
				}
				BulletUtil.SetTimeScale(this.BulletInfo, bulletPersistentTimeScale.Priority, bulletPersistentTimeScale.TimeDilation, bulletPersistentTimeScale.Curve, bulletPersistentTimeScale.Duration, bulletPersistentTimeScale.SourceType, num, bulletPersistentTimeScale.TimeScaleId);
			}
		}
	}

	// Token: 0x06017869 RID: 96361 RVA: 0x0068A604 File Offset: 0x00688804
	protected override void OnTick(float delta)
	{
		float num = this.BulletInfo.Entity.TimeDilation;
		if (this.BulletInfo.BulletDataMain.TimeScale.TimeScaleWithAttacker)
		{
			PawnTimeScaleComponent bulletAttackerTimeScaleComponent = this.BulletAttackerTimeScaleComponent;
			this.CurrentTimeScaleValue = (bulletAttackerTimeScaleComponent.Active ? bulletAttackerTimeScaleComponent.CurrentTimeScale : 1f);
			if (this.LastSetTimeScale == this.CurrentTimeScaleValue)
			{
				return;
			}
			this.LastSetTimeScale = this.CurrentTimeScaleValue;
			this.BulletInfo.Actor.CustomTimeDilation = this.CurrentTimeScaleValue;
			EffectUtil.SetEffectTimeScale(this.BulletInfo.EffectInfo.Effect, bulletAttackerTimeScaleComponent, num, ETimeScaleType.FollowEntity);
			return;
		}
		else
		{
			double worldTimeSeconds = Singleton<Time>.Instance.WorldTimeSeconds;
			while (!this.BulletInfo.TimeScaleList.Empty && (this.BulletInfo.TimeScaleList.Top.EndTime <= worldTimeSeconds || this.BulletInfo.TimeScaleList.Top.MarkDelete))
			{
				TimeScale timeScale = this.BulletInfo.TimeScaleList.Pop();
				this.BulletInfo.TimeScaleMap.Remove(timeScale.Id);
			}
			if (!this.BulletInfo.TimeScaleList.Empty)
			{
				this.CurrentTimeScaleValue = this.BulletInfo.TimeScaleList.Top.CalculateTimeScale();
			}
			else
			{
				this.CurrentTimeScaleValue = 1f;
			}
			num *= this.CurrentTimeScaleValue;
			Entity attacker = this.BulletInfo.Attacker;
			float? num2;
			if (attacker == null)
			{
				num2 = null;
			}
			else
			{
				PawnTimeScaleComponent component = attacker.GetComponent<PawnTimeScaleComponent>();
				num2 = ((component != null) ? new float?(component.GetTopForeverTimeScale(new ESourceEffectGroup?(ESourceEffectGroup.LogicAndView))) : null);
			}
			float num3 = num2 ?? ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation;
			this.CurrentTimeScaleValue *= num3;
			if (this.LastSetTimeScale == num && this.LastTopForeverTimeScale == num3)
			{
				return;
			}
			this.LastSetTimeScale = num;
			this.LastTopForeverTimeScale = num3;
			this.BulletInfo.Actor.CustomTimeDilation = this.CurrentTimeScaleValue;
			BulletStaticFunction.SetBulletEffectTimeScale(this.BulletInfo.EffectInfo, (double)num, true);
			Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, this.BulletInfo.EffectInfo.Effect, num3);
			return;
		}
	}

	// Token: 0x0601786A RID: 96362 RVA: 0x0068A834 File Offset: 0x00688A34
	public override void Clear()
	{
		base.Clear();
		this.CurrentTimeScaleValue = 0f;
		this.BulletAttackerTimeScaleComponent = null;
		this.LastSetTimeScale = 0f;
		this.LastTopForeverTimeScale = 0f;
	}

	// Token: 0x0400B482 RID: 46210
	private float CurrentTimeScaleValue;

	// Token: 0x0400B483 RID: 46211
	[Nullable(2)]
	private PawnTimeScaleComponent BulletAttackerTimeScaleComponent;

	// Token: 0x0400B484 RID: 46212
	private float LastSetTimeScale;

	// Token: 0x0400B485 RID: 46213
	private float LastTopForeverTimeScale;

	// Token: 0x02009043 RID: 36931
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0403062F RID: 198191
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<TimeScale> <0>__CompareScalePriority;
	}
}
