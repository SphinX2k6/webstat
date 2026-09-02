using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001737 RID: 5943
[NullableContext(1)]
[Nullable(0)]
public abstract class ActivitySubViewBase : UiPanelBase
{
	// Token: 0x0600A5FA RID: 42490 RVA: 0x002BEABC File Offset: 0x002BCCBC
	protected sealed override void OnBeforeShowImplement()
	{
		this.ClearTimer();
		ControllerBase<ActivityController>.Instance.RegisterRefreshTimerDelegate(new Action<float>(this.OnTimerRefresh));
		if (this.LevelSequencePlayer == null)
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceStartEvent(new TSequenceStartEvent(this.OnSequenceStartPrivate));
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClosePrivate), false);
		}
		this.OnTimerRefresh((float)Singleton<TimeUtil>.Instance.InverseMillisecond);
		this.OnAddEventListener();
	}

	// Token: 0x0600A5FB RID: 42491 RVA: 0x002BEB44 File Offset: 0x002BCD44
	private void OnSequenceStartPrivate(string sequenceName)
	{
		this.OnSequenceStart(sequenceName);
	}

	// Token: 0x0600A5FC RID: 42492 RVA: 0x002BEB4D File Offset: 0x002BCD4D
	protected virtual void OnSequenceStart(string sequenceName)
	{
	}

	// Token: 0x0600A5FD RID: 42493 RVA: 0x002BEB4F File Offset: 0x002BCD4F
	private void OnSequenceClosePrivate(string sequenceName)
	{
		this.OnSequenceClose(sequenceName);
	}

	// Token: 0x0600A5FE RID: 42494 RVA: 0x002BEB58 File Offset: 0x002BCD58
	protected virtual void OnSequenceClose(string sequenceName)
	{
	}

	// Token: 0x0600A5FF RID: 42495 RVA: 0x002BEB5A File Offset: 0x002BCD5A
	protected override void OnAfterHideImplement()
	{
		this.ClearTimer();
		this.OnRemoveEventListener();
	}

	// Token: 0x0600A600 RID: 42496 RVA: 0x002BEB68 File Offset: 0x002BCD68
	private void OnTimerRefresh(float delta)
	{
		this.OnTimer((float)Singleton<TimeUtil>.Instance.InverseMillisecond);
	}

	// Token: 0x0600A601 RID: 42497 RVA: 0x002BEB7B File Offset: 0x002BCD7B
	private void ClearTimer()
	{
		ControllerBase<ActivityController>.Instance.UnregisterRefreshTimerDelegate(new Action<float>(this.OnTimerRefresh));
	}

	// Token: 0x0600A602 RID: 42498 RVA: 0x002BEB93 File Offset: 0x002BCD93
	public void SetData(ActivityBaseData data)
	{
		this.ActivityBaseData = data;
		this.OnSetData();
	}

	// Token: 0x0600A603 RID: 42499 RVA: 0x002BEBA2 File Offset: 0x002BCDA2
	public void SetOpenParam(object param)
	{
		this.OpenParam = param;
	}

	// Token: 0x0600A604 RID: 42500 RVA: 0x002BEBAB File Offset: 0x002BCDAB
	protected virtual void OnSetData()
	{
	}

	// Token: 0x0600A605 RID: 42501 RVA: 0x002BEBAD File Offset: 0x002BCDAD
	public void RefreshView()
	{
		if (this.ActivityBaseData != null)
		{
			ModelBase<ActivityModel>.Instance.SendActivityTabViewOpenLogData(this.ActivityBaseData);
		}
		this.OnRefreshView();
	}

	// Token: 0x0600A606 RID: 42502 RVA: 0x002BEBD0 File Offset: 0x002BCDD0
	public UniTask BeforeShowSelfAsync()
	{
		ActivitySubViewBase.<BeforeShowSelfAsync>d__16 <BeforeShowSelfAsync>d__;
		<BeforeShowSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BeforeShowSelfAsync>d__.<>4__this = this;
		<BeforeShowSelfAsync>d__.<>1__state = -1;
		<BeforeShowSelfAsync>d__.<>t__builder.Start<ActivitySubViewBase.<BeforeShowSelfAsync>d__16>(ref <BeforeShowSelfAsync>d__);
		return <BeforeShowSelfAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A607 RID: 42503 RVA: 0x002BEC14 File Offset: 0x002BCE14
	public UniTask BeforeHideSelfAsync()
	{
		ActivitySubViewBase.<BeforeHideSelfAsync>d__17 <BeforeHideSelfAsync>d__;
		<BeforeHideSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BeforeHideSelfAsync>d__.<>4__this = this;
		<BeforeHideSelfAsync>d__.<>1__state = -1;
		<BeforeHideSelfAsync>d__.<>t__builder.Start<ActivitySubViewBase.<BeforeHideSelfAsync>d__17>(ref <BeforeHideSelfAsync>d__);
		return <BeforeHideSelfAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A608 RID: 42504 RVA: 0x002BEC57 File Offset: 0x002BCE57
	public virtual void OnCommonViewStateChange(bool show)
	{
	}

	// Token: 0x0600A609 RID: 42505 RVA: 0x002BEC59 File Offset: 0x002BCE59
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x0600A60A RID: 42506 RVA: 0x002BEC5B File Offset: 0x002BCE5B
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x0600A60B RID: 42507 RVA: 0x002BEC5D File Offset: 0x002BCE5D
	protected virtual void OnRefreshView()
	{
	}

	// Token: 0x0600A60C RID: 42508 RVA: 0x002BEC5F File Offset: 0x002BCE5F
	protected virtual UniTask OnBeforeShowSelfAsync()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600A60D RID: 42509 RVA: 0x002BEC66 File Offset: 0x002BCE66
	protected virtual UniTask OnBeforeHideSelfAsync()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600A60E RID: 42510 RVA: 0x002BEC70 File Offset: 0x002BCE70
	public virtual void PlaySubViewSequence(string name, bool blockClick = false)
	{
		if (this.LevelSequencePlayer.CheckSeqActorIsSeqPlaying(name))
		{
			this.LevelSequencePlayer.ReplaySequenceByKey(name);
			return;
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName(name, blockClick, null, false);
	}

	// Token: 0x0600A60F RID: 42511 RVA: 0x002BECAF File Offset: 0x002BCEAF
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	protected virtual ValueTuple<bool, string, long> GetTimeVisibleAndRemainTime()
	{
		return ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityBaseData, null);
	}

	// Token: 0x0600A610 RID: 42512 RVA: 0x002BECC2 File Offset: 0x002BCEC2
	protected virtual string GetCurrentLockConditionText()
	{
		if (this.ActivityBaseData.IsUnLock())
		{
			return "";
		}
		return LevelGeneralCommons.GetConditionGroupHintText(this.ActivityBaseData.ConditionGroupId) ?? "";
	}

	// Token: 0x0600A611 RID: 42513 RVA: 0x002BECF0 File Offset: 0x002BCEF0
	protected virtual void OnTimer(float gap)
	{
	}

	// Token: 0x0600A612 RID: 42514 RVA: 0x002BECF2 File Offset: 0x002BCEF2
	protected sealed override void OnBeforeDestroyImplement()
	{
		this.ClearTimer();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.Clear();
	}

	// Token: 0x04004EAE RID: 20142
	protected string ActivityRemainTimeText = "";

	// Token: 0x04004EAF RID: 20143
	[Nullable(2)]
	protected ActivityBaseData ActivityBaseData;

	// Token: 0x04004EB0 RID: 20144
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04004EB1 RID: 20145
	[Nullable(2)]
	protected object SubViewOpenParam;
}
