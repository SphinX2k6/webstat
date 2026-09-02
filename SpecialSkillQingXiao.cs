using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200314F RID: 12623
[NullableContext(1)]
[Nullable(0)]
public class SpecialSkillQingXiao : SpecialSkillBase
{
	// Token: 0x0601A24B RID: 107083 RVA: 0x007AC5A3 File Offset: 0x007AA7A3
	public SpecialSkillQingXiao(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A24C RID: 107084 RVA: 0x007AC5D8 File Offset: 0x007AA7D8
	public override void OnStart()
	{
		Entity entity = this.SpecialSkillComponent.Entity;
		this.TagComp = entity.GetComponent<BaseTagComponent>();
		this.ActorComp = entity.GetComponent<CharacterActorComponent>();
		this.AnimComp = entity.GetComponent<BaseAnimationComponent>();
		BaseTagComponent tagComp = this.TagComp;
		this.SpecialTagListener = ((tagComp != null) ? tagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.状态标识.御剑飞行状态"]), new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialTagChanged), null) : null);
	}

	// Token: 0x0601A24D RID: 107085 RVA: 0x007AC64E File Offset: 0x007AA84E
	public override void OnTick(float delta)
	{
		if (!this.InSwordRidingState)
		{
			return;
		}
		this.UpdateSwordRidingMix();
	}

	// Token: 0x0601A24E RID: 107086 RVA: 0x007AC660 File Offset: 0x007AA860
	private void UpdateSwordRidingMix()
	{
		this.TmpVector4.DeepCopy(this.ActorComp.ActorForwardProxy);
		this.TmpVector4.MultiplyEqual((double)this.ActorComp.ScaledRadius);
		this.TmpVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.TmpVector.AdditionEqual(this.TmpVector4);
		UKuroHitResult ukuroHitResult = this.DetectFloor(this.TmpVector);
		if (ukuroHitResult == null)
		{
			return;
		}
		Singleton<TraceElementCommon>.Instance.GetHitLocation(ukuroHitResult, 0, this.TmpVector3);
		this.TmpVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.TmpVector.SubtractionEqual(this.TmpVector4);
		UKuroHitResult ukuroHitResult2 = this.DetectFloor(this.TmpVector);
		Singleton<TraceElementCommon>.Instance.GetHitLocation(ukuroHitResult2, 0, this.TmpVector4);
		if (ukuroHitResult2 == null)
		{
			return;
		}
		this.TmpVector.DeepCopy(this.TmpVector3);
		this.TmpVector.SubtractionEqual(this.TmpVector4);
		this.TmpVector2.DeepCopy(this.ActorComp.ActorGravityDirectProxy);
		this.TmpVector2.Normalize(9.99999993922529E-09);
		double num = this.TmpVector.DotProduct(this.TmpVector);
		if (num < 1E-06)
		{
			return;
		}
		double num2 = this.TmpVector.DotProduct(this.TmpVector2);
		double x = Math.Sqrt(Math.Max(0.0, num - num2 * num2));
		double value = Math.Atan2(-num2, x);
		double num3 = Singleton<MathUtils>.Instance.RangeClamp(value, -3.141592653589793, 3.141592653589793, -1.0, 1.0);
		BaseAnimationComponent animComp = this.AnimComp;
		UKuroAnimInstanceRole ukuroAnimInstanceRole = ((animComp != null) ? animComp.MainAnimInstance : null) as UKuroAnimInstanceRole;
		if (ukuroAnimInstanceRole != null)
		{
			ukuroAnimInstanceRole.SlideMix = (float)num3;
		}
	}

	// Token: 0x0601A24F RID: 107087 RVA: 0x007AC830 File Offset: 0x007AAA30
	[return: Nullable(2)]
	private UKuroHitResult DetectFloor(Vector loc)
	{
		if (this.ActorComp == null)
		{
			return null;
		}
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = this.ActorComp.Actor;
		actorTrace.Radius = this.ActorComp.ScaledRadius;
		this.TmpVector2.DeepCopy(loc);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector2, (double)(60f - actorTrace.Radius - this.ActorComp.ScaledHalfHeight));
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.TmpVector2);
		this.TmpVector2.DeepCopy(loc);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector2, (double)(-60f + actorTrace.Radius - this.ActorComp.ScaledHalfHeight));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.TmpVector2);
		actorTrace.ActorsToIgnore.Empty(true);
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			actorTrace.ActorsToIgnore.Add(value);
		}
		if (!Singleton<TraceElementCommon>.Instance.ShapeTrace(this.ActorComp.Actor.CapsuleComponent, actorTrace, "SpecialSkillQingXiao", "SpecialSkillQingXiao"))
		{
			return null;
		}
		return actorTrace.HitResult;
	}

	// Token: 0x0601A250 RID: 107088 RVA: 0x007AC998 File Offset: 0x007AAB98
	public override void OnEnd()
	{
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null)
		{
			tagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.状态标识.御剑飞行状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialTagChanged));
		}
		ITagTask specialTagListener = this.SpecialTagListener;
		if (specialTagListener != null)
		{
			specialTagListener.EndTask();
		}
		this.SpecialTagListener = null;
	}

	// Token: 0x0601A251 RID: 107089 RVA: 0x007AC9E9 File Offset: 0x007AABE9
	private void OnSpecialTagChanged(int tagId, bool bTagExists)
	{
		this.InSwordRidingState = bTagExists;
	}

	// Token: 0x0400D1F2 RID: 53746
	private const string PROFILE_KEY = "SpecialSkillQingXiao";

	// Token: 0x0400D1F3 RID: 53747
	private const int DETECT_FLOOR_HEIGHT = 60;

	// Token: 0x0400D1F4 RID: 53748
	private bool InSwordRidingState;

	// Token: 0x0400D1F5 RID: 53749
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D1F6 RID: 53750
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400D1F7 RID: 53751
	[Nullable(2)]
	private BaseAnimationComponent AnimComp;

	// Token: 0x0400D1F8 RID: 53752
	[Nullable(2)]
	private ITagTask SpecialTagListener;

	// Token: 0x0400D1F9 RID: 53753
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400D1FA RID: 53754
	private readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x0400D1FB RID: 53755
	private readonly Vector TmpVector3 = Vector.Create();

	// Token: 0x0400D1FC RID: 53756
	private readonly Vector TmpVector4 = Vector.Create();
}
