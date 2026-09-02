using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015E7 RID: 5607
[NullableContext(1)]
[Nullable(0)]
public class ActivityTurntableComponent : UiPanelBase
{
	// Token: 0x06009DFA RID: 40442 RVA: 0x00295A5C File Offset: 0x00293C5C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009DFB RID: 40443 RVA: 0x00295BB0 File Offset: 0x00293DB0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityTurntableComponent.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityTurntableComponent.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009DFC RID: 40444 RVA: 0x00295BF4 File Offset: 0x00293DF4
	private UniTask CreateRewardItem(AActor itemActor)
	{
		ActivityTurntableComponent.<CreateRewardItem>d__16 <CreateRewardItem>d__;
		<CreateRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRewardItem>d__.<>4__this = this;
		<CreateRewardItem>d__.itemActor = itemActor;
		<CreateRewardItem>d__.<>1__state = -1;
		<CreateRewardItem>d__.<>t__builder.Start<ActivityTurntableComponent.<CreateRewardItem>d__16>(ref <CreateRewardItem>d__);
		return <CreateRewardItem>d__.<>t__builder.Task;
	}

	// Token: 0x06009DFD RID: 40445 RVA: 0x00295C3F File Offset: 0x00293E3F
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06009DFE RID: 40446 RVA: 0x00295C5D File Offset: 0x00293E5D
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06009DFF RID: 40447 RVA: 0x00295C7B File Offset: 0x00293E7B
	protected override void OnBeforeDestroy()
	{
		this.RemoveAnimationTimer();
	}

	// Token: 0x06009E00 RID: 40448 RVA: 0x00295C84 File Offset: 0x00293E84
	public UniTask Refresh(List<ITurntableReward> rewardList)
	{
		ActivityTurntableComponent.<Refresh>d__20 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.rewardList = rewardList;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<ActivityTurntableComponent.<Refresh>d__20>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x06009E01 RID: 40449 RVA: 0x00295CCF File Offset: 0x00293ECF
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param != "TurntableRotate" || !this.Activate)
		{
			return;
		}
		this.StartRotateGrid(this.AnimationRotateAngle);
	}

	// Token: 0x06009E02 RID: 40450 RVA: 0x00295CF4 File Offset: 0x00293EF4
	[NullableContext(2)]
	public void RunTurntableByRewardId(int rewardId, Action finishedCallback = null)
	{
		this.RunTurntableAnimation(rewardId, finishedCallback).ContinueWith(delegate()
		{
			Action finishedCallback2 = finishedCallback;
			if (finishedCallback2 == null)
			{
				return;
			}
			finishedCallback2();
		});
	}

	// Token: 0x06009E03 RID: 40451 RVA: 0x00295D30 File Offset: 0x00293F30
	[NullableContext(2)]
	private UniTask RunTurntableAnimation(int rewardId, Action finishedCallback = null)
	{
		ActivityTurntableComponent.<RunTurntableAnimation>d__23 <RunTurntableAnimation>d__;
		<RunTurntableAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RunTurntableAnimation>d__.<>4__this = this;
		<RunTurntableAnimation>d__.rewardId = rewardId;
		<RunTurntableAnimation>d__.finishedCallback = finishedCallback;
		<RunTurntableAnimation>d__.<>1__state = -1;
		<RunTurntableAnimation>d__.<>t__builder.Start<ActivityTurntableComponent.<RunTurntableAnimation>d__23>(ref <RunTurntableAnimation>d__);
		return <RunTurntableAnimation>d__.<>t__builder.Task;
	}

	// Token: 0x06009E04 RID: 40452 RVA: 0x00295D84 File Offset: 0x00293F84
	[NullableContext(0)]
	private ValueTuple<float, bool, bool> GetRotateInfoByRewardId(int rewardId)
	{
		int num = -1;
		bool item = false;
		bool item2 = false;
		for (int i = 0; i < this.RewardItemList.Count; i++)
		{
			if (this.RewardItemList[i].RewardId == rewardId)
			{
				num = i;
				item = this.RewardItemList[i].IsSpecial;
				item2 = this.RewardItemList[i].IsGoldenQuality;
				break;
			}
		}
		if (num < 0)
		{
			return new ValueTuple<float, bool, bool>(-1f, item, item2);
		}
		return new ValueTuple<float, bool, bool>((float)(-90 + -45 * num), item, item2);
	}

	// Token: 0x06009E05 RID: 40453 RVA: 0x00295E0C File Offset: 0x0029400C
	private void StartRotateGrid(float rotateAngle)
	{
		if (rotateAngle == 0f)
		{
			return;
		}
		this.RotateAllGridInner(-rotateAngle);
		this.AnimationTime = 0f;
		this.AnimationTimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float deltaTime)
		{
			this.RunAnimationTimer(deltaTime, rotateAngle);
		}, 20f, 1f, null, null, true);
	}

	// Token: 0x06009E06 RID: 40454 RVA: 0x00295E7C File Offset: 0x0029407C
	private void RotateAllGridInner(float changeAngle)
	{
		foreach (ActivityTurntableGrid activityTurntableGrid in this.RewardItemList)
		{
			activityTurntableGrid.Rotate(changeAngle);
		}
	}

	// Token: 0x06009E07 RID: 40455 RVA: 0x00295ED0 File Offset: 0x002940D0
	private void RunAnimationTimer(float deltaTime, float totalAngle)
	{
		this.AnimationTime += deltaTime;
		float num = Math.Min(this.AnimationTime / this.AnimationRotateTime, 1f);
		this.AnimationRotator.Pitch = 0f;
		this.AnimationRotator.Roll = 0f;
		this.AnimationRotator.Yaw = num * totalAngle;
		base.GetItem(8).SetUIRelativeRotation(this.AnimationRotator);
		if (this.AnimationTime >= this.AnimationRotateTime)
		{
			this.RemoveAnimationTimer();
		}
	}

	// Token: 0x06009E08 RID: 40456 RVA: 0x00295F57 File Offset: 0x00294157
	private void RemoveAnimationTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.AnimationTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AnimationTimerId);
			this.AnimationTimerId = null;
			this.AnimationTime = 0f;
		}
	}

	// Token: 0x06009E09 RID: 40457 RVA: 0x00295F90 File Offset: 0x00294190
	private UniTask PlayTurntableAnimation(string sequenceName, bool blockClick = false)
	{
		ActivityTurntableComponent.<PlayTurntableAnimation>d__29 <PlayTurntableAnimation>d__;
		<PlayTurntableAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayTurntableAnimation>d__.<>4__this = this;
		<PlayTurntableAnimation>d__.sequenceName = sequenceName;
		<PlayTurntableAnimation>d__.blockClick = blockClick;
		<PlayTurntableAnimation>d__.<>1__state = -1;
		<PlayTurntableAnimation>d__.<>t__builder.Start<ActivityTurntableComponent.<PlayTurntableAnimation>d__29>(ref <PlayTurntableAnimation>d__);
		return <PlayTurntableAnimation>d__.<>t__builder.Task;
	}

	// Token: 0x040048B0 RID: 18608
	private readonly List<ActivityTurntableGrid> RewardItemList = new List<ActivityTurntableGrid>();

	// Token: 0x040048B1 RID: 18609
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040048B2 RID: 18610
	[Nullable(2)]
	private TimerHandle AnimationTimerId;

	// Token: 0x040048B3 RID: 18611
	private float AnimationTime;

	// Token: 0x040048B4 RID: 18612
	private float AnimationRotateAngle;

	// Token: 0x040048B5 RID: 18613
	private FRotator AnimationRotator = new FRotator();

	// Token: 0x040048B6 RID: 18614
	public bool Activate = true;

	// Token: 0x040048B7 RID: 18615
	private float AnimationRotateTime;

	// Token: 0x040048B8 RID: 18616
	private const int TURNTABLE_GRID_SIZE = 8;

	// Token: 0x040048B9 RID: 18617
	private const int ROTATE_DEFAULT_ANGLE = -90;

	// Token: 0x040048BA RID: 18618
	private const int ROTATE_GRID_ANGLE = -45;

	// Token: 0x040048BB RID: 18619
	private const int ROTATE_LOOP_ANIMATION_TIME = 500;

	// Token: 0x040048BC RID: 18620
	private const string TURNTABLE_ROTATE_PARAM = "TurntableRotate";

	// Token: 0x020079A5 RID: 31141
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029C6F RID: 171119
		public const int Grid1 = 0;

		// Token: 0x04029C70 RID: 171120
		public const int Grid2 = 1;

		// Token: 0x04029C71 RID: 171121
		public const int Grid3 = 2;

		// Token: 0x04029C72 RID: 171122
		public const int Grid4 = 3;

		// Token: 0x04029C73 RID: 171123
		public const int Grid5 = 4;

		// Token: 0x04029C74 RID: 171124
		public const int Grid6 = 5;

		// Token: 0x04029C75 RID: 171125
		public const int Grid7 = 6;

		// Token: 0x04029C76 RID: 171126
		public const int Grid8 = 7;

		// Token: 0x04029C77 RID: 171127
		public const int Rotator = 8;
	}
}
