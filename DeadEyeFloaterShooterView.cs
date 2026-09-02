using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B27 RID: 6951
[NullableContext(1)]
[Nullable(0)]
public class DeadEyeFloaterShooterView : UiTickViewBase
{
	// Token: 0x0600C83F RID: 51263 RVA: 0x0034FF8E File Offset: 0x0034E18E
	public DeadEyeFloaterShooterView(UiViewInfo ViewInfo) : base(ViewInfo)
	{
	}

	// Token: 0x0600C840 RID: 51264 RVA: 0x0034FFA4 File Offset: 0x0034E1A4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnLaunchButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C841 RID: 51265 RVA: 0x0035006C File Offset: 0x0034E26C
	protected override UniTask OnBeforeStartAsync()
	{
		DeadEyeFloaterShooterView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DeadEyeFloaterShooterView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C842 RID: 51266 RVA: 0x003500AF File Offset: 0x0034E2AF
	protected override void OnAfterShow()
	{
		DeadEyeAimItem aimItem = this.AimItem;
		if (aimItem == null)
		{
			return;
		}
		aimItem.ShowAsync().Forget<bool>();
	}

	// Token: 0x0600C843 RID: 51267 RVA: 0x003500C8 File Offset: 0x0034E2C8
	protected override void OnTick(float delta)
	{
		this.CurrentLockedCount = 0;
		this.CurrentDelayTime += delta;
		foreach (DeadEyeFloaterShooterTargetItem deadEyeFloaterShooterTargetItem in this.TargetItem)
		{
			deadEyeFloaterShooterTargetItem.OnTick(delta);
			if (deadEyeFloaterShooterTargetItem.IsLocked)
			{
				this.CurrentLockedCount++;
			}
		}
		bool uiactive = this.CurrentLockedCount == this.TargetItem.Count;
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(uiactive);
		}
		if ((double)this.CurrentDelayTime * Singleton<TimeUtil>.Instance.Millisecond * (double)ModelBase<DeadEyeModeModel>.Instance.TimeConsumption >= (double)ModelBase<DeadEyeModeModel>.Instance.MaxEnergy)
		{
			this.OnLaunchButtonClick();
		}
	}

	// Token: 0x0600C844 RID: 51268 RVA: 0x003501AC File Offset: 0x0034E3AC
	private UniTask InitAimItem()
	{
		DeadEyeFloaterShooterView.<InitAimItem>d__13 <InitAimItem>d__;
		<InitAimItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAimItem>d__.<>4__this = this;
		<InitAimItem>d__.<>1__state = -1;
		<InitAimItem>d__.<>t__builder.Start<DeadEyeFloaterShooterView.<InitAimItem>d__13>(ref <InitAimItem>d__);
		return <InitAimItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600C845 RID: 51269 RVA: 0x003501F0 File Offset: 0x0034E3F0
	private UniTask InitTargetItems(IReadOnlyList<EntityHandle> targetEntityHandles, IReadOnlyList<Vector> targetLocations)
	{
		DeadEyeFloaterShooterView.<InitTargetItems>d__14 <InitTargetItems>d__;
		<InitTargetItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTargetItems>d__.<>4__this = this;
		<InitTargetItems>d__.targetEntityHandles = targetEntityHandles;
		<InitTargetItems>d__.targetLocations = targetLocations;
		<InitTargetItems>d__.<>1__state = -1;
		<InitTargetItems>d__.<>t__builder.Start<DeadEyeFloaterShooterView.<InitTargetItems>d__14>(ref <InitTargetItems>d__);
		return <InitTargetItems>d__.<>t__builder.Task;
	}

	// Token: 0x0600C846 RID: 51270 RVA: 0x00350243 File Offset: 0x0034E443
	private void ShowTargetItemImp()
	{
		if (this.PlayStartSequenceTargetItemIndex >= this.TargetItem.Count)
		{
			return;
		}
		this.PlayTargetItemStartSequence().ContinueWith(new Action(this.ShowTargetItemImp));
	}

	// Token: 0x0600C847 RID: 51271 RVA: 0x00350274 File Offset: 0x0034E474
	private UniTask PlayTargetItemStartSequence()
	{
		DeadEyeFloaterShooterView.<PlayTargetItemStartSequence>d__16 <PlayTargetItemStartSequence>d__;
		<PlayTargetItemStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayTargetItemStartSequence>d__.<>4__this = this;
		<PlayTargetItemStartSequence>d__.<>1__state = -1;
		<PlayTargetItemStartSequence>d__.<>t__builder.Start<DeadEyeFloaterShooterView.<PlayTargetItemStartSequence>d__16>(ref <PlayTargetItemStartSequence>d__);
		return <PlayTargetItemStartSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600C848 RID: 51272 RVA: 0x003502B7 File Offset: 0x0034E4B7
	protected override void OnAfterDestroy()
	{
		Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motorcycle_dead_eye_slow_motion_end");
		ModelBase<DeadEyeModeModel>.Instance.EnterNextStage();
	}

	// Token: 0x0600C849 RID: 51273 RVA: 0x003502D4 File Offset: 0x0034E4D4
	private void OnLaunchButtonClick()
	{
		if (ModelBase<DeadEyeModeModel>.Instance.CurrentEnergy != 0f && this.CurrentLockedCount == 0)
		{
			return;
		}
		if (ModelBase<DeadEyeModeModel>.Instance.CurDeadEyeModeStage == EDeadEyeModeStage.WaitSettlement)
		{
			return;
		}
		this.LaunchImp().ContinueWith(delegate()
		{
			base.CloseMe(null);
		});
	}

	// Token: 0x0600C84A RID: 51274 RVA: 0x00350324 File Offset: 0x0034E524
	private UniTask LaunchImp()
	{
		DeadEyeFloaterShooterView.<LaunchImp>d__19 <LaunchImp>d__;
		<LaunchImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LaunchImp>d__.<>4__this = this;
		<LaunchImp>d__.<>1__state = -1;
		<LaunchImp>d__.<>t__builder.Start<DeadEyeFloaterShooterView.<LaunchImp>d__19>(ref <LaunchImp>d__);
		return <LaunchImp>d__.<>t__builder.Task;
	}

	// Token: 0x0400601F RID: 24607
	private const string END_AUDIO_NAME = "play_sfx_motorcycle_dead_eye_slow_motion_end";

	// Token: 0x04006020 RID: 24608
	[Nullable(2)]
	private DeadEyeAimItem AimItem;

	// Token: 0x04006021 RID: 24609
	private readonly List<DeadEyeFloaterShooterTargetItem> TargetItem = new List<DeadEyeFloaterShooterTargetItem>();

	// Token: 0x04006022 RID: 24610
	private int PlayStartSequenceTargetItemIndex;

	// Token: 0x04006023 RID: 24611
	private int CurrentLockedCount;

	// Token: 0x04006024 RID: 24612
	[Nullable(2)]
	private LevelSequencePlayer ButtonSequencePlayer;

	// Token: 0x04006025 RID: 24613
	private float CurrentDelayTime;

	// Token: 0x02007E04 RID: 32260
	[NullableContext(0)]
	private class EViewComponent
	{
		// Token: 0x0402AEA7 RID: 175783
		public const int AimItem = 0;

		// Token: 0x0402AEA8 RID: 175784
		public const int AimTargetItemRoot = 1;

		// Token: 0x0402AEA9 RID: 175785
		public const int LaunchBtn = 2;
	}
}
