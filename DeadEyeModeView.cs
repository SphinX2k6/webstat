using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B28 RID: 6952
[NullableContext(2)]
[Nullable(0)]
public class DeadEyeModeView : UiTickViewBase
{
	// Token: 0x0600C84C RID: 51276 RVA: 0x00350370 File Offset: 0x0034E570
	[NullableContext(1)]
	public DeadEyeModeView(UiViewInfo UiViewInfo) : base(UiViewInfo)
	{
	}

	// Token: 0x0600C84D RID: 51277 RVA: 0x00350384 File Offset: 0x0034E584
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
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
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnLaunchButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C84E RID: 51278 RVA: 0x003504B0 File Offset: 0x0034E6B0
	protected override UniTask OnBeforeStartAsync()
	{
		DeadEyeModeView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DeadEyeModeView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C84F RID: 51279 RVA: 0x003504F3 File Offset: 0x0034E6F3
	protected override void OnAfterShow()
	{
		this.ShowTargetItemList();
		DeadEyeProgressItem deadEyeProgressItem = this.DeadEyeProgressItem;
		if (deadEyeProgressItem != null)
		{
			deadEyeProgressItem.Show(null);
		}
		DeadEyeAimItem aimItem = this.AimItem;
		if (aimItem == null)
		{
			return;
		}
		aimItem.ShowAsync().Forget<bool>();
	}

	// Token: 0x0600C850 RID: 51280 RVA: 0x00350522 File Offset: 0x0034E722
	protected override void OnAfterDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DeadEyeModeTargetPointLocked, new Action(this.OnTargetPointLocked));
		ModelBase<DeadEyeModeModel>.Instance.EnterNextStage();
	}

	// Token: 0x0600C851 RID: 51281 RVA: 0x0035054C File Offset: 0x0034E74C
	protected override void OnTick(float delta)
	{
		foreach (DeadEyeTargetItem deadEyeTargetItem in this.TargetItem)
		{
			deadEyeTargetItem.OnTick(delta);
		}
		DeadEyeProgressItem deadEyeProgressItem = this.DeadEyeProgressItem;
		if (deadEyeProgressItem != null)
		{
			deadEyeProgressItem.OnTick(delta);
		}
		if (ModelBase<DeadEyeModeModel>.Instance.CurrentEnergy == 0f)
		{
			this.OnLaunchButtonClick();
		}
	}

	// Token: 0x0600C852 RID: 51282 RVA: 0x003505C8 File Offset: 0x0034E7C8
	private void OnTargetPointLocked()
	{
		this.CurrentLockedCount = 0;
		using (List<DeadEyeTargetItem>.Enumerator enumerator = this.TargetItem.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsLocked)
				{
					this.CurrentLockedCount++;
				}
			}
		}
		bool flag = this.CurrentLockedCount == this.TargetItem.Count;
		UUIButtonComponent button = base.GetButton(5);
		if (button != null)
		{
			button.SetEnable(this.CurrentLockedCount > 0);
		}
		if (flag && ModelBase<DeadEyeModeModel>.Instance.CurDeadEyeModeStage == EDeadEyeModeStage.AimInput)
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			LevelSequencePlayer tipsSequencePlayer = this.TipsSequencePlayer;
			if (tipsSequencePlayer == null)
			{
				return;
			}
			tipsSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
	}

	// Token: 0x0600C853 RID: 51283 RVA: 0x003506A0 File Offset: 0x0034E8A0
	private UniTask InitAimItem()
	{
		DeadEyeModeView.<InitAimItem>d__15 <InitAimItem>d__;
		<InitAimItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAimItem>d__.<>4__this = this;
		<InitAimItem>d__.<>1__state = -1;
		<InitAimItem>d__.<>t__builder.Start<DeadEyeModeView.<InitAimItem>d__15>(ref <InitAimItem>d__);
		return <InitAimItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600C854 RID: 51284 RVA: 0x003506E4 File Offset: 0x0034E8E4
	private UniTask InitProgressItem()
	{
		DeadEyeModeView.<InitProgressItem>d__16 <InitProgressItem>d__;
		<InitProgressItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitProgressItem>d__.<>4__this = this;
		<InitProgressItem>d__.<>1__state = -1;
		<InitProgressItem>d__.<>t__builder.Start<DeadEyeModeView.<InitProgressItem>d__16>(ref <InitProgressItem>d__);
		return <InitProgressItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600C855 RID: 51285 RVA: 0x00350728 File Offset: 0x0034E928
	[NullableContext(1)]
	private UniTask InitTargetItems(IEnumerable<EntityHandle> targetEntityHandles, IEnumerable<Vector> targetLocations)
	{
		DeadEyeModeView.<InitTargetItems>d__17 <InitTargetItems>d__;
		<InitTargetItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTargetItems>d__.<>4__this = this;
		<InitTargetItems>d__.targetEntityHandles = targetEntityHandles;
		<InitTargetItems>d__.targetLocations = targetLocations;
		<InitTargetItems>d__.<>1__state = -1;
		<InitTargetItems>d__.<>t__builder.Start<DeadEyeModeView.<InitTargetItems>d__17>(ref <InitTargetItems>d__);
		return <InitTargetItems>d__.<>t__builder.Task;
	}

	// Token: 0x0600C856 RID: 51286 RVA: 0x0035077C File Offset: 0x0034E97C
	private void ShowTargetItemList()
	{
		this.TargetItem.Sort(delegate(DeadEyeTargetItem a, DeadEyeTargetItem b)
		{
			double x = a.GetScreenPositionWithoutClamp(null).X;
			double x2 = b.GetScreenPositionWithoutClamp(null).X;
			if (x < x2)
			{
				return -1;
			}
			if (x > x2)
			{
				return 1;
			}
			return 0;
		});
		this.PlayStartSequenceTargetItemIndex = 0;
		if (this.TargetItem.Count == 0)
		{
			return;
		}
		this.ShowTargetItemImp();
	}

	// Token: 0x0600C857 RID: 51287 RVA: 0x003507CE File Offset: 0x0034E9CE
	private void ShowTargetItemImp()
	{
		if (this.PlayStartSequenceTargetItemIndex >= this.TargetItem.Count)
		{
			return;
		}
		this.PlayTargetItemStartSequence().ContinueWith(new Action(this.ShowTargetItemImp));
	}

	// Token: 0x0600C858 RID: 51288 RVA: 0x003507FC File Offset: 0x0034E9FC
	private UniTask PlayTargetItemStartSequence()
	{
		DeadEyeModeView.<PlayTargetItemStartSequence>d__20 <PlayTargetItemStartSequence>d__;
		<PlayTargetItemStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayTargetItemStartSequence>d__.<>4__this = this;
		<PlayTargetItemStartSequence>d__.<>1__state = -1;
		<PlayTargetItemStartSequence>d__.<>t__builder.Start<DeadEyeModeView.<PlayTargetItemStartSequence>d__20>(ref <PlayTargetItemStartSequence>d__);
		return <PlayTargetItemStartSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600C859 RID: 51289 RVA: 0x00350840 File Offset: 0x0034EA40
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

	// Token: 0x0600C85A RID: 51290 RVA: 0x00350890 File Offset: 0x0034EA90
	private UniTask LaunchImp()
	{
		DeadEyeModeView.<LaunchImp>d__22 <LaunchImp>d__;
		<LaunchImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LaunchImp>d__.<>4__this = this;
		<LaunchImp>d__.<>1__state = -1;
		<LaunchImp>d__.<>t__builder.Start<DeadEyeModeView.<LaunchImp>d__22>(ref <LaunchImp>d__);
		return <LaunchImp>d__.<>t__builder.Task;
	}

	// Token: 0x04006026 RID: 24614
	private DeadEyeAimItem AimItem;

	// Token: 0x04006027 RID: 24615
	private DeadEyeProgressItem DeadEyeProgressItem;

	// Token: 0x04006028 RID: 24616
	[Nullable(1)]
	private readonly List<DeadEyeTargetItem> TargetItem = new List<DeadEyeTargetItem>();

	// Token: 0x04006029 RID: 24617
	private int PlayStartSequenceTargetItemIndex;

	// Token: 0x0400602A RID: 24618
	private int CurrentLockedCount;

	// Token: 0x0400602B RID: 24619
	private LevelSequencePlayer ButtonSequencePlayer;

	// Token: 0x0400602C RID: 24620
	private LevelSequencePlayer TipsSequencePlayer;

	// Token: 0x02007E0A RID: 32266
	[NullableContext(0)]
	private class EViewComponent
	{
		// Token: 0x0402AEC2 RID: 175810
		public const int AimItem = 0;

		// Token: 0x0402AEC3 RID: 175811
		public const int AimTargetItemRoot = 1;

		// Token: 0x0402AEC4 RID: 175812
		public const int ProgressItem = 2;

		// Token: 0x0402AEC5 RID: 175813
		public const int ProgressItem2 = 3;

		// Token: 0x0402AEC6 RID: 175814
		public const int AllLockedTips = 4;

		// Token: 0x0402AEC7 RID: 175815
		public const int LaunchBtn = 5;
	}
}
