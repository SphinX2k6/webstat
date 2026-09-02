using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B2A RID: 6954
[NullableContext(2)]
[Nullable(0)]
public class DeadEyeTargetItem : CommonMarkItem
{
	// Token: 0x0600C86B RID: 51307 RVA: 0x00350CC1 File Offset: 0x0034EEC1
	[NullableContext(1)]
	public DeadEyeTargetItem(in FVectorDouble TargetLocation, Vector2D AimRange, [Nullable(2)] EntityHandle TargetEntity = null) : base(TargetLocation, null)
	{
	}

	// Token: 0x17001011 RID: 4113
	// (get) Token: 0x0600C86C RID: 51308 RVA: 0x00350CD9 File Offset: 0x0034EED9
	// (set) Token: 0x0600C86D RID: 51309 RVA: 0x00350CE1 File Offset: 0x0034EEE1
	public bool IsLocked
	{
		get
		{
			return this.IsLockedInner;
		}
		set
		{
			this.IsLockedInner = value;
			this.OnLockStateChange(value);
		}
	}

	// Token: 0x0600C86E RID: 51310 RVA: 0x00350CF4 File Offset: 0x0034EEF4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C86F RID: 51311 RVA: 0x00350E04 File Offset: 0x0034F004
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(1);
		this.NotLockSequencePlayer = new LevelSequencePlayer(item);
		UUIItem item2 = base.GetItem(2);
		this.LockedSequencePlayer = new LevelSequencePlayer(item2);
		UUIItem item3 = base.GetItem(4);
		this.OutsideItemSequencePlayer = new LevelSequencePlayer(item3);
		base.UpdatePositionAndRotation();
		this.IsLocked = false;
	}

	// Token: 0x0600C870 RID: 51312 RVA: 0x00350E5A File Offset: 0x0034F05A
	protected override void OnAfterShow()
	{
		this.InRangeStateChanged(base.IsInRange(), true);
	}

	// Token: 0x0600C871 RID: 51313 RVA: 0x00350E6C File Offset: 0x0034F06C
	protected override UniTask OnBeforeHideAsync()
	{
		DeadEyeTargetItem.<OnBeforeHideAsync>d__15 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<DeadEyeTargetItem.<OnBeforeHideAsync>d__15>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C872 RID: 51314 RVA: 0x00350EAF File Offset: 0x0034F0AF
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0600C873 RID: 51315 RVA: 0x00350EB4 File Offset: 0x0034F0B4
	public override void OnTick(float delta)
	{
		if (this.RootItem == null || !base.GetActive() || !ModelBase<DeadEyeModeModel>.Instance.ViewStartSequenceFinish)
		{
			return;
		}
		base.OnTick(delta);
		FVector2D anchorOffset = this.RootItem.GetAnchorOffset();
		bool flag = this.CheckIsHover(anchorOffset);
		if (flag != this.IsHover)
		{
			this.OnHoverStateChanged(flag);
		}
	}

	// Token: 0x0600C874 RID: 51316 RVA: 0x00350F0C File Offset: 0x0034F10C
	public UniTask PlayClickSequence()
	{
		DeadEyeTargetItem.<PlayClickSequence>d__18 <PlayClickSequence>d__;
		<PlayClickSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayClickSequence>d__.<>4__this = this;
		<PlayClickSequence>d__.<>1__state = -1;
		<PlayClickSequence>d__.<>t__builder.Start<DeadEyeTargetItem.<PlayClickSequence>d__18>(ref <PlayClickSequence>d__);
		return <PlayClickSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600C875 RID: 51317 RVA: 0x00350F50 File Offset: 0x0034F150
	protected override void OnScreenPositionChanged(bool bInRange)
	{
		UUIItem item = base.GetItem(4);
		if (!bInRange && item != null)
		{
			UUIItem uuiitem = item;
			FRotator frotator = new FRotator();
			frotator.Yaw = (float)Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) * 57.295776f;
			uuiitem.SetUIRelativeRotation(frotator);
		}
	}

	// Token: 0x0600C876 RID: 51318 RVA: 0x00350FA4 File Offset: 0x0034F1A4
	protected override void InRangeStateChanged(bool bInRange, bool bFirst = false)
	{
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(bInRange);
		}
		if (item2 != null)
		{
			item2.SetUIActive(!bInRange && !this.IsLocked);
		}
		if (!base.GetActive() || base.IsHideOrHiding)
		{
			return;
		}
		if (bInRange)
		{
			if (this.IsLocked)
			{
				LevelSequencePlayer lockedSequencePlayer = this.LockedSequencePlayer;
				if (lockedSequencePlayer != null)
				{
					lockedSequencePlayer.PlayLevelSequenceByName(bFirst ? "Start" : "ShowView", false, null, false);
				}
			}
			else
			{
				LevelSequencePlayer notLockSequencePlayer = this.NotLockSequencePlayer;
				if (notLockSequencePlayer != null)
				{
					notLockSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
				}
			}
			LevelSequencePlayer outsideItemSequencePlayer = this.OutsideItemSequencePlayer;
			if (outsideItemSequencePlayer == null)
			{
				return;
			}
			outsideItemSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
			return;
		}
		else
		{
			if (this.IsLocked)
			{
				LevelSequencePlayer lockedSequencePlayer2 = this.LockedSequencePlayer;
				if (lockedSequencePlayer2 != null)
				{
					lockedSequencePlayer2.PlayLevelSequenceByName("Close", false, null, false);
				}
			}
			else
			{
				LevelSequencePlayer notLockSequencePlayer2 = this.NotLockSequencePlayer;
				if (notLockSequencePlayer2 != null)
				{
					notLockSequencePlayer2.PlayLevelSequenceByName("Close", false, null, false);
				}
			}
			LevelSequencePlayer outsideItemSequencePlayer2 = this.OutsideItemSequencePlayer;
			if (outsideItemSequencePlayer2 == null)
			{
				return;
			}
			outsideItemSequencePlayer2.PlayLevelSequenceByName("Start", false, null, false);
			return;
		}
	}

	// Token: 0x0600C877 RID: 51319 RVA: 0x003510DB File Offset: 0x0034F2DB
	private void OnHoverStateChanged(bool bHover)
	{
		this.IsHover = bHover;
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.DeadEyeModeTargetPointCanLockStateChange, this.IsHover);
		this.LockTarget();
	}

	// Token: 0x0600C878 RID: 51320 RVA: 0x00351100 File Offset: 0x0034F300
	private bool CheckIsHover(in FVector2D offset)
	{
		double num = this.AimRange.X * 0.5;
		double num2 = this.AimRange.Y * 0.5;
		return (double)offset.X >= -num && (double)offset.X <= num && (double)offset.Y >= -num2 && (double)offset.Y <= num2;
	}

	// Token: 0x0600C879 RID: 51321 RVA: 0x00351168 File Offset: 0x0034F368
	private void LockTarget()
	{
		if (this.IsLocked)
		{
			return;
		}
		if (!ModelBase<DeadEyeModeModel>.Instance.CheckEnergyEnoughLockTarget())
		{
			Singleton<Log>.Instance.Info(ELogModule.UiCommon, ELogAuthor.YSQ, "当前能量不足以再射一发子弹", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.IsLocked = true;
		if (this.TargetEntity != null)
		{
			ModelBase<DeadEyeModeModel>.Instance.RecordLockedTarget(this.TargetEntity);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.DeadEyeModeTargetPointLocked);
		LevelSequencePlayer lockedSequencePlayer = this.LockedSequencePlayer;
		if (lockedSequencePlayer == null)
		{
			return;
		}
		lockedSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600C87A RID: 51322 RVA: 0x003511F8 File Offset: 0x0034F3F8
	private void OnLockStateChange(bool bLock)
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(!bLock);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(bLock);
		}
		UUIItem item3 = base.GetItem(6);
		if (item3 != null)
		{
			item3.SetUIActive(bLock);
		}
		UUIItem item4 = base.GetItem(5);
		if (item4 != null)
		{
			item4.SetUIActive(!bLock);
		}
		if (bLock && this.TargetEntity != null)
		{
			ControllerBase<DeadEyeModeController>.Instance.EnableSingleEntityHighlight(this.TargetEntity, ETargetHighlightType.Locked);
		}
	}

	// Token: 0x04006034 RID: 24628
	private bool IsHover;

	// Token: 0x04006035 RID: 24629
	private bool IsLockedInner;

	// Token: 0x04006036 RID: 24630
	private LevelSequencePlayer LockedSequencePlayer;

	// Token: 0x04006037 RID: 24631
	private LevelSequencePlayer NotLockSequencePlayer;

	// Token: 0x04006038 RID: 24632
	private LevelSequencePlayer OutsideItemSequencePlayer;

	// Token: 0x04006039 RID: 24633
	[Nullable(1)]
	public readonly Vector2D AimRange = AimRange;

	// Token: 0x0400603A RID: 24634
	public readonly EntityHandle TargetEntity = TargetEntity;

	// Token: 0x02007E14 RID: 32276
	[NullableContext(0)]
	private class EViewComponent
	{
		// Token: 0x0402AEEF RID: 175855
		public const int RootButton = 0;

		// Token: 0x0402AEF0 RID: 175856
		public const int PanelNotLock = 1;

		// Token: 0x0402AEF1 RID: 175857
		public const int PanelLocked = 2;

		// Token: 0x0402AEF2 RID: 175858
		public const int InsideItem = 3;

		// Token: 0x0402AEF3 RID: 175859
		public const int OutsideItem = 4;

		// Token: 0x0402AEF4 RID: 175860
		public const int OutsideNormalItem = 5;

		// Token: 0x0402AEF5 RID: 175861
		public const int OutsideLockItem = 6;
	}
}
