using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001D89 RID: 7561
public class SurvivorsRogueTipsPanelBase : UiPanelBase
{
	// Token: 0x0600DEC0 RID: 57024 RVA: 0x003BEEF1 File Offset: 0x003BD0F1
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				base.Hide(null);
			}
		}, false);
	}

	// Token: 0x0600DEC1 RID: 57025 RVA: 0x003BEF1C File Offset: 0x003BD11C
	protected override void OnBeforeShow()
	{
		this.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600DEC2 RID: 57026 RVA: 0x003BEF55 File Offset: 0x003BD155
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600DEC3 RID: 57027 RVA: 0x003BEF8E File Offset: 0x003BD18E
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x0600DEC4 RID: 57028 RVA: 0x003BEF90 File Offset: 0x003BD190
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x0600DEC5 RID: 57029 RVA: 0x003BEF92 File Offset: 0x003BD192
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.SurvivorsRogueExitView)
		{
			this.SequencePlayer.PauseSequence();
		}
	}

	// Token: 0x0600DEC6 RID: 57030 RVA: 0x003BEFAC File Offset: 0x003BD1AC
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.SurvivorsRogueExitView)
		{
			this.SequencePlayer.ResumeSequence();
		}
	}

	// Token: 0x0600DEC7 RID: 57031 RVA: 0x003BEFC8 File Offset: 0x003BD1C8
	public virtual void ShowTips()
	{
		base.Show(null);
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600DEC8 RID: 57032 RVA: 0x003BF004 File Offset: 0x003BD204
	public void HideTips()
	{
		if (!base.IsShowOrShowing)
		{
			return;
		}
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
	}

	// Token: 0x04006B1E RID: 27422
	[Nullable(1)]
	protected LevelSequencePlayer SequencePlayer;
}
