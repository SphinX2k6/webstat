using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C76 RID: 7286
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchUiCardItem : FloroRanchUiItemBase
{
	// Token: 0x0600D4A4 RID: 54436 RVA: 0x0038C524 File Offset: 0x0038A724
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D4A5 RID: 54437 RVA: 0x0038C653 File Offset: 0x0038A853
	protected override void OnBeforeCreate()
	{
		this.UiLevelSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiLevelSequence);
	}

	// Token: 0x0600D4A6 RID: 54438 RVA: 0x0038C670 File Offset: 0x0038A870
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchUiCardItem.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchUiCardItem.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4A7 RID: 54439 RVA: 0x0038C6B4 File Offset: 0x0038A8B4
	public void FollowPosition(FTransform transform)
	{
		FVector location = transform.GetLocation();
		location.Z -= 40f;
		this.OriginalPosition = location;
		base.GetRootItem().SetUIWorldLocation(this.OriginalPosition);
	}

	// Token: 0x0600D4A8 RID: 54440 RVA: 0x0038C6F4 File Offset: 0x0038A8F4
	public override UniTask RefreshItem()
	{
		FloroRanchUiCardItem.<RefreshItem>d__21 <RefreshItem>d__;
		<RefreshItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshItem>d__.<>4__this = this;
		<RefreshItem>d__.<>1__state = -1;
		<RefreshItem>d__.<>t__builder.Start<FloroRanchUiCardItem.<RefreshItem>d__21>(ref <RefreshItem>d__);
		return <RefreshItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4A9 RID: 54441 RVA: 0x0038C738 File Offset: 0x0038A938
	public void RefreshEvolveItem()
	{
		FloroRanchCardDataComponent floroRanchCardDataComponent = this.Entity.CheckGetComponent<FloroRanchCardDataComponent>();
		this.EvolveItem.Refresh(floroRanchCardDataComponent.EvolveData);
		this.EvolveItem.GetRootItem().SetAnchorOffsetY((float)floroRanchCardDataComponent.CardData.GetEvolveItemOffsetY());
	}

	// Token: 0x0600D4AA RID: 54442 RVA: 0x0038C780 File Offset: 0x0038A980
	public void RefreshRemainTimeItem()
	{
		FloroRanchEntityDataComponent floroRanchEntityDataComponent = this.Entity.CheckGetComponent<FloroRanchEntityDataComponent>();
		this.RemainTimeItem.Refresh(floroRanchEntityDataComponent.GetMinRemindDayBuff());
	}

	// Token: 0x0600D4AB RID: 54443 RVA: 0x0038C7AC File Offset: 0x0038A9AC
	public void RefreshSpecialEffect()
	{
		EFloroRanchSpecialEffectType cardSpecialEffect = this.Entity.CheckGetComponent<FloroRanchCardDataComponent>().CardData.GetCardSpecialEffect();
		base.GetUiNiagara(4).SetUIActive(cardSpecialEffect == EFloroRanchSpecialEffectType.Blue);
		base.GetUiNiagara(5).SetUIActive(cardSpecialEffect == EFloroRanchSpecialEffectType.Red);
	}

	// Token: 0x0600D4AC RID: 54444 RVA: 0x0038C7EF File Offset: 0x0038A9EF
	public void RefreshDebugInfo()
	{
	}

	// Token: 0x0600D4AD RID: 54445 RVA: 0x0038C7F4 File Offset: 0x0038A9F4
	public override UniTask PlayShowAnim()
	{
		FloroRanchUiCardItem.<PlayShowAnim>d__26 <PlayShowAnim>d__;
		<PlayShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayShowAnim>d__.<>4__this = this;
		<PlayShowAnim>d__.<>1__state = -1;
		<PlayShowAnim>d__.<>t__builder.Start<FloroRanchUiCardItem.<PlayShowAnim>d__26>(ref <PlayShowAnim>d__);
		return <PlayShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4AE RID: 54446 RVA: 0x0038C838 File Offset: 0x0038AA38
	public override UniTask PlayHideAnim()
	{
		FloroRanchUiCardItem.<PlayHideAnim>d__27 <PlayHideAnim>d__;
		<PlayHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideAnim>d__.<>4__this = this;
		<PlayHideAnim>d__.<>1__state = -1;
		<PlayHideAnim>d__.<>t__builder.Start<FloroRanchUiCardItem.<PlayHideAnim>d__27>(ref <PlayHideAnim>d__);
		return <PlayHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4AF RID: 54447 RVA: 0x0038C87C File Offset: 0x0038AA7C
	public override void ShowCoinNiagara(long count)
	{
		UUINiagara uiNiagara = base.GetUiNiagara(6);
		UUINiagara uiNiagara2 = base.GetUiNiagara(7);
		uiNiagara.SetUIActive(false);
		uiNiagara2.SetUIActive(false);
		if (count >= 1000L)
		{
			uiNiagara2.SetUIActive(true);
			return;
		}
		if (count >= 100L)
		{
			uiNiagara.SetUIActive(true);
		}
	}

	// Token: 0x0600D4B0 RID: 54448 RVA: 0x0038C8C8 File Offset: 0x0038AAC8
	public override UniTask ShowUiItem()
	{
		FloroRanchUiCardItem.<ShowUiItem>d__29 <ShowUiItem>d__;
		<ShowUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowUiItem>d__.<>4__this = this;
		<ShowUiItem>d__.<>1__state = -1;
		<ShowUiItem>d__.<>t__builder.Start<FloroRanchUiCardItem.<ShowUiItem>d__29>(ref <ShowUiItem>d__);
		return <ShowUiItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4B1 RID: 54449 RVA: 0x0038C90C File Offset: 0x0038AB0C
	public override UniTask HideUiItem()
	{
		FloroRanchUiCardItem.<HideUiItem>d__30 <HideUiItem>d__;
		<HideUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HideUiItem>d__.<>4__this = this;
		<HideUiItem>d__.<>1__state = -1;
		<HideUiItem>d__.<>t__builder.Start<FloroRanchUiCardItem.<HideUiItem>d__30>(ref <HideUiItem>d__);
		return <HideUiItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4B2 RID: 54450 RVA: 0x0038C94F File Offset: 0x0038AB4F
	public override void Pause()
	{
		this.UiLevelSequence.PauseSequence();
		base.GetSpine(1).SetTimeScale(0f);
	}

	// Token: 0x0600D4B3 RID: 54451 RVA: 0x0038C96D File Offset: 0x0038AB6D
	public override void Resume()
	{
		this.UiLevelSequence.ResumeSequence();
		base.GetSpine(1).SetTimeScale(1f);
	}

	// Token: 0x0600D4B4 RID: 54452 RVA: 0x0038C98C File Offset: 0x0038AB8C
	public override UniTask PlayNormalAnim()
	{
		FloroRanchUiCardItem.<PlayNormalAnim>d__33 <PlayNormalAnim>d__;
		<PlayNormalAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayNormalAnim>d__.<>4__this = this;
		<PlayNormalAnim>d__.<>1__state = -1;
		<PlayNormalAnim>d__.<>t__builder.Start<FloroRanchUiCardItem.<PlayNormalAnim>d__33>(ref <PlayNormalAnim>d__);
		return <PlayNormalAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4B5 RID: 54453 RVA: 0x0038C9D0 File Offset: 0x0038ABD0
	public override UniTask MoveToItem(UUIItem targetItem)
	{
		FloroRanchUiCardItem.<MoveToItem>d__34 <MoveToItem>d__;
		<MoveToItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveToItem>d__.<>4__this = this;
		<MoveToItem>d__.targetItem = targetItem;
		<MoveToItem>d__.<>1__state = -1;
		<MoveToItem>d__.<>t__builder.Start<FloroRanchUiCardItem.<MoveToItem>d__34>(ref <MoveToItem>d__);
		return <MoveToItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4B6 RID: 54454 RVA: 0x0038CA1C File Offset: 0x0038AC1C
	public override UniTask MoveToOriginalPosition()
	{
		FloroRanchUiCardItem.<MoveToOriginalPosition>d__35 <MoveToOriginalPosition>d__;
		<MoveToOriginalPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveToOriginalPosition>d__.<>4__this = this;
		<MoveToOriginalPosition>d__.<>1__state = -1;
		<MoveToOriginalPosition>d__.<>t__builder.Start<FloroRanchUiCardItem.<MoveToOriginalPosition>d__35>(ref <MoveToOriginalPosition>d__);
		return <MoveToOriginalPosition>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4B7 RID: 54455 RVA: 0x0038CA60 File Offset: 0x0038AC60
	public override void MoveToOriginalPositionImmediate()
	{
		base.GetRootItem().SetUIWorldLocation(this.OriginalPosition);
		this.TargetRotator.Set(0f, 0f, 0f);
		UUIItem item = base.GetItem(0);
		FRotator frotator = this.TargetRotator.ToUeRotator();
		item.SetUIRelativeRotation(frotator);
	}

	// Token: 0x0600D4B8 RID: 54456 RVA: 0x0038CAB2 File Offset: 0x0038ACB2
	public override FTransform? GetRewardPopTransform()
	{
		return new FTransform?(this.RootActor.GetTransform());
	}

	// Token: 0x0600D4B9 RID: 54457 RVA: 0x0038CAC4 File Offset: 0x0038ACC4
	public override UniTask PlayEatAnim()
	{
		FloroRanchUiCardItem.<PlayEatAnim>d__38 <PlayEatAnim>d__;
		<PlayEatAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayEatAnim>d__.<>4__this = this;
		<PlayEatAnim>d__.<>1__state = -1;
		<PlayEatAnim>d__.<>t__builder.Start<FloroRanchUiCardItem.<PlayEatAnim>d__38>(ref <PlayEatAnim>d__);
		return <PlayEatAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4BA RID: 54458 RVA: 0x0038CB08 File Offset: 0x0038AD08
	public override UniTask PlayBeEatAnim()
	{
		FloroRanchUiCardItem.<PlayBeEatAnim>d__39 <PlayBeEatAnim>d__;
		<PlayBeEatAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayBeEatAnim>d__.<>4__this = this;
		<PlayBeEatAnim>d__.<>1__state = -1;
		<PlayBeEatAnim>d__.<>t__builder.Start<FloroRanchUiCardItem.<PlayBeEatAnim>d__39>(ref <PlayBeEatAnim>d__);
		return <PlayBeEatAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4BB RID: 54459 RVA: 0x0038CB4C File Offset: 0x0038AD4C
	public override UniTask PlaySacrificeAnim()
	{
		FloroRanchUiCardItem.<PlaySacrificeAnim>d__40 <PlaySacrificeAnim>d__;
		<PlaySacrificeAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySacrificeAnim>d__.<>4__this = this;
		<PlaySacrificeAnim>d__.<>1__state = -1;
		<PlaySacrificeAnim>d__.<>t__builder.Start<FloroRanchUiCardItem.<PlaySacrificeAnim>d__40>(ref <PlaySacrificeAnim>d__);
		return <PlaySacrificeAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4BC RID: 54460 RVA: 0x0038CB90 File Offset: 0x0038AD90
	public override UniTask PlayFusionHideAnim()
	{
		FloroRanchUiCardItem.<PlayFusionHideAnim>d__41 <PlayFusionHideAnim>d__;
		<PlayFusionHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayFusionHideAnim>d__.<>4__this = this;
		<PlayFusionHideAnim>d__.<>1__state = -1;
		<PlayFusionHideAnim>d__.<>t__builder.Start<FloroRanchUiCardItem.<PlayFusionHideAnim>d__41>(ref <PlayFusionHideAnim>d__);
		return <PlayFusionHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4BD RID: 54461 RVA: 0x0038CBD4 File Offset: 0x0038ADD4
	public override UniTask PlayFusionShowAnim()
	{
		FloroRanchUiCardItem.<PlayFusionShowAnim>d__42 <PlayFusionShowAnim>d__;
		<PlayFusionShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayFusionShowAnim>d__.<>4__this = this;
		<PlayFusionShowAnim>d__.<>1__state = -1;
		<PlayFusionShowAnim>d__.<>t__builder.Start<FloroRanchUiCardItem.<PlayFusionShowAnim>d__42>(ref <PlayFusionShowAnim>d__);
		return <PlayFusionShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4BE RID: 54462 RVA: 0x0038CC18 File Offset: 0x0038AE18
	public override UniTask PlayEvolveUpAnim()
	{
		FloroRanchUiCardItem.<PlayEvolveUpAnim>d__43 <PlayEvolveUpAnim>d__;
		<PlayEvolveUpAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayEvolveUpAnim>d__.<>4__this = this;
		<PlayEvolveUpAnim>d__.<>1__state = -1;
		<PlayEvolveUpAnim>d__.<>t__builder.Start<FloroRanchUiCardItem.<PlayEvolveUpAnim>d__43>(ref <PlayEvolveUpAnim>d__);
		return <PlayEvolveUpAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4BF RID: 54463 RVA: 0x0038CC5C File Offset: 0x0038AE5C
	private Rotator GetSpineItemDirection(Vector currentLocation, Vector targetLocation)
	{
		this.TempRotator.Set(0f, 0f, 0f);
		EFloroRanchCardDirection cardDefaultDirection = this.Entity.CheckGetComponent<FloroRanchCardDataComponent>().CardData.GetCardDefaultDirection();
		if (cardDefaultDirection == EFloroRanchCardDirection.Center)
		{
			return this.TempRotator;
		}
		targetLocation.Subtraction(currentLocation, this.TempVector);
		EFloroRanchCardDirection efloroRanchCardDirection = (this.TempVector.X > 0.0) ? EFloroRanchCardDirection.Right : EFloroRanchCardDirection.Left;
		if (cardDefaultDirection == efloroRanchCardDirection)
		{
			return this.TempRotator;
		}
		this.TempRotator.Set(180f, 0f, 0f);
		return this.TempRotator;
	}

	// Token: 0x0600D4C0 RID: 54464 RVA: 0x0038CCF8 File Offset: 0x0038AEF8
	private void OnTick(float deltaTime)
	{
		if (ModelBase<FloroRanchGamePlayModel>.Instance.IsSkip)
		{
			this.MoveToOriginalPositionImmediate();
			this.ClearTimerHandle();
			return;
		}
		this.TickTime += deltaTime;
		this.MoveDirection.Multiply((double)this.CardMoveCurve.GetFloatValue(this.TickTime / 500f), this.TempVector);
		this.StartPosition.Addition(this.TempVector, this.TempVector2);
		UUIItem rootItem = base.GetRootItem();
		FVector fvector = this.TempVector2.ToUeVectorOld();
		rootItem.SetUIWorldLocation(fvector);
		if (this.TickTime >= 500f)
		{
			UUIItem rootItem2 = base.GetRootItem();
			fvector = this.TargetPosition.ToUeVectorOld();
			rootItem2.SetUIWorldLocation(fvector);
			UUIItem item = base.GetItem(0);
			FRotator frotator = this.TargetRotator.ToUeRotator();
			item.SetUIRelativeRotation(frotator);
			this.ClearTimerHandle();
		}
	}

	// Token: 0x0600D4C1 RID: 54465 RVA: 0x0038CDCD File Offset: 0x0038AFCD
	protected override void OnBeforeDestroy()
	{
		base.GetSpine(1).AnimationComplete.Remove(new Action<UTrackEntry>(this.OnSpineAnimationComplete));
		this.ClearTimerHandle();
	}

	// Token: 0x0600D4C2 RID: 54466 RVA: 0x0038CDF4 File Offset: 0x0038AFF4
	private void ClearTimerHandle()
	{
		if (ModelBase<FloroRanchGamePlayModel>.Instance.FloroRanchTimerSystem.Has(this.TimerHandle))
		{
			ModelBase<FloroRanchGamePlayModel>.Instance.FloroRanchTimerSystem.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		if (this.WaitPromise != null)
		{
			this.WaitPromise.SetResult(null);
			this.WaitPromise = null;
		}
	}

	// Token: 0x0600D4C3 RID: 54467 RVA: 0x0038CE50 File Offset: 0x0038B050
	public void BindMoveCurve(UCurveFloat curve)
	{
		this.CardMoveCurve = curve;
	}

	// Token: 0x0600D4C4 RID: 54468 RVA: 0x0038CE59 File Offset: 0x0038B059
	[NullableContext(2)]
	private void OnSpineAnimationComplete(UTrackEntry entry)
	{
		if (entry == null)
		{
			return;
		}
		if (entry.getAnimationName() == "eat")
		{
			USpineSkeletonAnimationComponent spine = base.GetSpine(1);
			spine.SetAnimation(0, "idle", true);
			spine.SetTimeScale(1f);
		}
	}

	// Token: 0x0600D4C5 RID: 54469 RVA: 0x0038CE90 File Offset: 0x0038B090
	private void OnHideAnimationComplete(string sequenceName)
	{
		base.GetRootItem().SetUIWorldLocation(this.OriginalPosition);
		base.GetRootItem().SetUIActive(false);
		base.GetSpine(1).ClearTracks();
	}

	// Token: 0x04006523 RID: 25891
	private FloroRanchEvolveItem EvolveItem;

	// Token: 0x04006524 RID: 25892
	private FloroRanchBuffRemindDayItem RemainTimeItem;

	// Token: 0x04006525 RID: 25893
	public UiBehaviorLevelSequence UiLevelSequence;

	// Token: 0x04006526 RID: 25894
	private FVector OriginalPosition;

	// Token: 0x04006527 RID: 25895
	private UCurveFloat CardMoveCurve;

	// Token: 0x04006528 RID: 25896
	private TimerHandle TimerHandle;

	// Token: 0x04006529 RID: 25897
	private CustomPromise<object> WaitPromise;

	// Token: 0x0400652A RID: 25898
	private FloroRanchEntityDebugInfoItem DebugInfoItem;

	// Token: 0x0400652B RID: 25899
	private readonly Vector MoveDirection = Vector.Create();

	// Token: 0x0400652C RID: 25900
	private readonly Vector StartPosition = Vector.Create();

	// Token: 0x0400652D RID: 25901
	private Vector TargetPosition = Vector.Create();

	// Token: 0x0400652E RID: 25902
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x0400652F RID: 25903
	private readonly Vector TempVector2 = Vector.Create();

	// Token: 0x04006530 RID: 25904
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x04006531 RID: 25905
	private readonly Rotator TargetRotator = Rotator.Create();

	// Token: 0x04006532 RID: 25906
	private float TickTime;

	// Token: 0x02007FA6 RID: 32678
	[NullableContext(0)]
	private class EItemComponentDefine
	{
		// Token: 0x0402B74B RID: 177995
		public const int SpineItem = 0;

		// Token: 0x0402B74C RID: 177996
		public const int Spine = 1;

		// Token: 0x0402B74D RID: 177997
		public const int EvolveItem = 2;

		// Token: 0x0402B74E RID: 177998
		public const int RemainTimeItem = 3;

		// Token: 0x0402B74F RID: 177999
		public const int NiagaraBlue = 4;

		// Token: 0x0402B750 RID: 178000
		public const int NiagaraRed = 5;

		// Token: 0x0402B751 RID: 178001
		public const int NiagaraReward = 6;

		// Token: 0x0402B752 RID: 178002
		public const int NiagaraMoreReward = 7;
	}
}
