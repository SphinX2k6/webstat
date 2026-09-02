using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200347C RID: 13436
[NullableContext(1)]
[Nullable(0)]
public class SubLevel
{
	// Token: 0x17002664 RID: 9828
	// (get) Token: 0x0601C56A RID: 116074 RVA: 0x0087D188 File Offset: 0x0087B388
	public bool LoadVisibleParam
	{
		get
		{
			return !this.DependOnBeginPlayLogic || this.VisibleAfterLoad;
		}
	}

	// Token: 0x17002665 RID: 9829
	// (get) Token: 0x0601C56B RID: 116075 RVA: 0x0087D19A File Offset: 0x0087B39A
	public bool IsVisible
	{
		get
		{
			if (this.DependOnBeginPlayLogic)
			{
				ULevelStreaming level = this.Level;
				return level != null && level.IsLevelVisible();
			}
			return this.InnerVisible;
		}
	}

	// Token: 0x0601C56C RID: 116076 RVA: 0x0087D1BC File Offset: 0x0087B3BC
	public SubLevel(string path, bool visibleAfterLoad)
	{
		this.Path = path;
		this.VisibleAfterLoad = visibleAfterLoad;
		this.FinishDelegate = global::DelegateUtils.ToManualReleaseDelegate<FSetVisibleFinishDelegate>(new Action<int>(this.SetLevelVisibleFinished));
		if (this.Path.Contains("_Audio"))
		{
			this.DependOnBeginPlayLogic = true;
		}
	}

	// Token: 0x0601C56D RID: 116077 RVA: 0x0087D224 File Offset: 0x0087B424
	public void Dispose()
	{
		if (this.SetLevelVisiblePromise != null && this.SetLevelVisiblePromise.IsPending)
		{
			this.SetLevelVisiblePromise.SetResult(false);
		}
		this.SetLevelVisiblePromise = null;
		UKuroSubLevelVisibleSubsystem subSystem = UKuroSubLevelVisibleSubsystem.GetSubSystem(GlobalData.GameInstance);
		if (subSystem != null)
		{
			subSystem.RemoveLevel(this.LinkId);
		}
		this.Level = null;
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.SetLevelVisibleFinished));
	}

	// Token: 0x0601C56E RID: 116078 RVA: 0x0087D28C File Offset: 0x0087B48C
	[NullableContext(2)]
	public UniTask OnLevelLoad(ULevelStreaming level)
	{
		SubLevel.<OnLevelLoad>d__13 <OnLevelLoad>d__;
		<OnLevelLoad>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnLevelLoad>d__.<>4__this = this;
		<OnLevelLoad>d__.level = level;
		<OnLevelLoad>d__.<>1__state = -1;
		<OnLevelLoad>d__.<>t__builder.Start<SubLevel.<OnLevelLoad>d__13>(ref <OnLevelLoad>d__);
		return <OnLevelLoad>d__.<>t__builder.Task;
	}

	// Token: 0x0601C56F RID: 116079 RVA: 0x0087D2D8 File Offset: 0x0087B4D8
	public UniTask SetLevelVisible(bool bVisible, string reason, bool bWaitingLoading = true)
	{
		SubLevel.<SetLevelVisible>d__14 <SetLevelVisible>d__;
		<SetLevelVisible>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetLevelVisible>d__.<>4__this = this;
		<SetLevelVisible>d__.bVisible = bVisible;
		<SetLevelVisible>d__.reason = reason;
		<SetLevelVisible>d__.bWaitingLoading = bWaitingLoading;
		<SetLevelVisible>d__.<>1__state = -1;
		<SetLevelVisible>d__.<>t__builder.Start<SubLevel.<SetLevelVisible>d__14>(ref <SetLevelVisible>d__);
		return <SetLevelVisible>d__.<>t__builder.Task;
	}

	// Token: 0x0601C570 RID: 116080 RVA: 0x0087D334 File Offset: 0x0087B534
	private UniTask SetLevelVisibleWithBeginPlay(ULevelStreaming level, bool bVisible, string reason)
	{
		SubLevel.<SetLevelVisibleWithBeginPlay>d__20 <SetLevelVisibleWithBeginPlay>d__;
		<SetLevelVisibleWithBeginPlay>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetLevelVisibleWithBeginPlay>d__.<>4__this = this;
		<SetLevelVisibleWithBeginPlay>d__.level = level;
		<SetLevelVisibleWithBeginPlay>d__.bVisible = bVisible;
		<SetLevelVisibleWithBeginPlay>d__.<>1__state = -1;
		<SetLevelVisibleWithBeginPlay>d__.<>t__builder.Start<SubLevel.<SetLevelVisibleWithBeginPlay>d__20>(ref <SetLevelVisibleWithBeginPlay>d__);
		return <SetLevelVisibleWithBeginPlay>d__.<>t__builder.Task;
	}

	// Token: 0x0601C571 RID: 116081 RVA: 0x0087D388 File Offset: 0x0087B588
	private UniTask SetLevelVisibleNoBeginPlay(bool bVisible, string reason)
	{
		SubLevel.<SetLevelVisibleNoBeginPlay>d__21 <SetLevelVisibleNoBeginPlay>d__;
		<SetLevelVisibleNoBeginPlay>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetLevelVisibleNoBeginPlay>d__.<>4__this = this;
		<SetLevelVisibleNoBeginPlay>d__.bVisible = bVisible;
		<SetLevelVisibleNoBeginPlay>d__.reason = reason;
		<SetLevelVisibleNoBeginPlay>d__.<>1__state = -1;
		<SetLevelVisibleNoBeginPlay>d__.<>t__builder.Start<SubLevel.<SetLevelVisibleNoBeginPlay>d__21>(ref <SetLevelVisibleNoBeginPlay>d__);
		return <SetLevelVisibleNoBeginPlay>d__.<>t__builder.Task;
	}

	// Token: 0x0601C572 RID: 116082 RVA: 0x0087D3DB File Offset: 0x0087B5DB
	private void SetLevelVisibleFinished(int linkId)
	{
		if (linkId != this.LinkId)
		{
			return;
		}
		CustomPromise<bool> setLevelVisiblePromise = this.SetLevelVisiblePromise;
		if (setLevelVisiblePromise == null)
		{
			return;
		}
		setLevelVisiblePromise.SetResult(true);
	}

	// Token: 0x0400E3E3 RID: 58339
	public ELoadLevelType LoadState;

	// Token: 0x0400E3E4 RID: 58340
	[Nullable(2)]
	public ULevelStreaming Level;

	// Token: 0x0400E3E5 RID: 58341
	public int LinkId;

	// Token: 0x0400E3E6 RID: 58342
	public int UnLoadLinkId;

	// Token: 0x0400E3E7 RID: 58343
	public readonly bool DependOnBeginPlayLogic;

	// Token: 0x0400E3E8 RID: 58344
	public readonly GameModePromise LoadPromise = new GameModePromise();

	// Token: 0x0400E3E9 RID: 58345
	public readonly GameModePromise UnLoadPromise = new GameModePromise();

	// Token: 0x0400E3EA RID: 58346
	private bool InnerVisible;

	// Token: 0x0400E3EB RID: 58347
	public readonly string Path;

	// Token: 0x0400E3EC RID: 58348
	public readonly bool VisibleAfterLoad;

	// Token: 0x0400E3ED RID: 58349
	[Nullable(2)]
	private CustomPromise<bool> SetLevelVisiblePromise;

	// Token: 0x0400E3EE RID: 58350
	private FSetVisibleFinishDelegate FinishDelegate;
}
