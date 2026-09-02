using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.PathLine.PathLine_Bullet;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002DDB RID: 11739
[NullableContext(2)]
[Nullable(0)]
public class BatchBulletPositionSpline : IBatchBulletPositionShape
{
	// Token: 0x06017A8F RID: 96911 RVA: 0x00699DF1 File Offset: 0x00697FF1
	[NullableContext(1)]
	public static BatchBulletPositionSpline Create(CharacterCustomValueComponent customValueComp, SBatchBulletPositionSpline config, SkillBehaviorBatchBulletTask taskContext)
	{
		BatchBulletPositionSpline batchBulletPositionSpline = new BatchBulletPositionSpline();
		batchBulletPositionSpline.FromUeConfig(customValueComp, config);
		batchBulletPositionSpline.Intervals = taskContext.GetInterval();
		batchBulletPositionSpline.Context = taskContext;
		return batchBulletPositionSpline;
	}

	// Token: 0x06017A90 RID: 96912 RVA: 0x00699E13 File Offset: 0x00698013
	private BatchBulletPositionSpline()
	{
	}

	// Token: 0x06017A91 RID: 96913 RVA: 0x00699E1C File Offset: 0x0069801C
	[NullableContext(1)]
	private void FromUeConfig(CharacterCustomValueComponent customValueComp, SBatchBulletPositionSpline spline)
	{
		this.SplineClassPath = spline.SplineClass.ToAssetPathName();
		Vector vector;
		this.Start = (customValueComp.GetBlackboard(spline.StartKey, default(TFormulaValue)).TryGetVector(out vector) ? vector : null);
		if (StringUtils.IsBlank(spline.EndKey.ToString()))
		{
			Rotator rotator;
			this.Rotator = (customValueComp.GetBlackboard(spline.RotatorKey, default(TFormulaValue)).TryGetRotator(out rotator) ? rotator : null);
		}
		else
		{
			Vector vector2;
			this.End = (customValueComp.GetBlackboard(spline.EndKey, default(TFormulaValue)).TryGetVector(out vector2) ? vector2 : null);
		}
		this.Duration = (float)customValueComp.GetBlackboard(spline.DurationKey, TFormulaValue.FromFloat(0f));
		this.Delay = spline.Delay;
		this.PathEffectOnEnd = spline.EffectOfEnd.ToAssetPathName();
		this.BulletIdOnEnd = spline.BulletIdOfEnd;
		this.DestroyOnEnd = spline.DestroyAllOnEnd;
		this.BulletIdOnBreak = spline.BulletIdOnBreak;
		this.PathEffectOnBreak = spline.EffectOnBreak.ToAssetPathName();
		this.SummonChildBullet = spline.DestroySummonBullet;
	}

	// Token: 0x06017A92 RID: 96914 RVA: 0x00699F54 File Offset: 0x00698154
	public UniTask Load()
	{
		BatchBulletPositionSpline.<Load>d__19 <Load>d__;
		<Load>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Load>d__.<>4__this = this;
		<Load>d__.<>1__state = -1;
		<Load>d__.<>t__builder.Start<BatchBulletPositionSpline.<Load>d__19>(ref <Load>d__);
		return <Load>d__.<>t__builder.Task;
	}

	// Token: 0x06017A93 RID: 96915 RVA: 0x00699F97 File Offset: 0x00698197
	public void OnBreak()
	{
		this.OnSplineFinish(this.PathEffectOnBreak, this.BulletIdOnBreak);
	}

	// Token: 0x06017A94 RID: 96916 RVA: 0x00699FAB File Offset: 0x006981AB
	public void OnEnd()
	{
		this.OnSplineFinish(this.PathEffectOnEnd, this.BulletIdOnEnd);
	}

	// Token: 0x06017A95 RID: 96917 RVA: 0x00699FC0 File Offset: 0x006981C0
	private void OnSplineFinish(string pathEffect, string bulletId)
	{
		bool flag = StringUtils.IsBlank(pathEffect);
		bool flag2 = StringUtils.IsBlank(bulletId);
		if (flag && flag2)
		{
			Singleton<ActorSystem>.Instance.Put("样条曲线批量子弹", this.Spline, null);
			this.Spline = null;
			this.SplineComp = null;
			return;
		}
		USplineComponent splineComp = this.SplineComp;
		FTransformDouble? initialTransform = (splineComp != null) ? new FTransformDouble?(splineComp.D_GetTransformAtTime(this.Duration, ESplineCoordinateSpace.World, true, true)) : null;
		if (!flag)
		{
			int id = Singleton<EffectSystem>.Instance.SpawnEffect(GlobalData.World, initialTransform, pathEffect, "样条批量子弹末尾特效", null, EEffectType.Scene, null, null, null, false, false);
			Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, id, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		}
		if (!flag2)
		{
			TsBaseCharacter owner = this.Context.GetOwner();
			int skillId = this.Context.GetSkillId();
			BaseSkillComponent skillComponent = this.Context.GetSkillComponent();
			Skill skill = (skillComponent != null) ? skillComponent.GetSkill(skillId) : null;
			long? preContextId = (skill != null && skill.SkillBehaviorAnimNotifyMessageId != null) ? ((skill != null) ? skill.SkillBehaviorAnimNotifyMessageId : null) : ((skill != null) ? skill.CombatMessageId : null);
			BulletUtil.CreateBulletFromAN(owner, bulletId, initialTransform, skillId, false, preContextId, null, null, null);
		}
		Singleton<ActorSystem>.Instance.Put("样条曲线批量子弹", this.Spline, null);
		this.Spline = null;
		this.SplineComp = null;
	}

	// Token: 0x06017A96 RID: 96918 RVA: 0x0069A138 File Offset: 0x00698338
	public Transform ToTransform(int index)
	{
		float time = this.Delay + this.Intervals * (float)index;
		return Transform.Create(this.SplineComp.D_GetTransformAtTime(time, ESplineCoordinateSpace.World, true, true));
	}

	// Token: 0x06017A97 RID: 96919 RVA: 0x0069A16F File Offset: 0x0069836F
	public Vector ToTargetLocation(Transform transform)
	{
		return null;
	}

	// Token: 0x06017A98 RID: 96920 RVA: 0x0069A172 File Offset: 0x00698372
	public float GetDelay()
	{
		return this.Delay;
	}

	// Token: 0x06017A99 RID: 96921 RVA: 0x0069A17A File Offset: 0x0069837A
	public bool IsDestroyOnEnd()
	{
		return this.DestroyOnEnd;
	}

	// Token: 0x06017A9A RID: 96922 RVA: 0x0069A182 File Offset: 0x00698382
	public bool IsSummonChildBullet()
	{
		return this.SummonChildBullet;
	}

	// Token: 0x0400B65D RID: 46685
	private string SplineClassPath;

	// Token: 0x0400B65E RID: 46686
	private BP_BasePathLineBullet_C Spline;

	// Token: 0x0400B65F RID: 46687
	private USplineComponent SplineComp;

	// Token: 0x0400B660 RID: 46688
	private Vector Start;

	// Token: 0x0400B661 RID: 46689
	private Vector End;

	// Token: 0x0400B662 RID: 46690
	private Rotator Rotator;

	// Token: 0x0400B663 RID: 46691
	private float Duration;

	// Token: 0x0400B664 RID: 46692
	private float Delay;

	// Token: 0x0400B665 RID: 46693
	private float Intervals;

	// Token: 0x0400B666 RID: 46694
	private string PathEffectOnEnd;

	// Token: 0x0400B667 RID: 46695
	private string BulletIdOnEnd;

	// Token: 0x0400B668 RID: 46696
	private string PathEffectOnBreak;

	// Token: 0x0400B669 RID: 46697
	private string BulletIdOnBreak;

	// Token: 0x0400B66A RID: 46698
	private SkillBehaviorBatchBulletTask Context;

	// Token: 0x0400B66B RID: 46699
	private bool DestroyOnEnd;

	// Token: 0x0400B66C RID: 46700
	private bool SummonChildBullet;
}
