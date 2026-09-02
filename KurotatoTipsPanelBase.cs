using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001D25 RID: 7461
public class KurotatoTipsPanelBase : UiPanelBase
{
	// Token: 0x0600DB81 RID: 56193 RVA: 0x003AFB62 File Offset: 0x003ADD62
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

	// Token: 0x0600DB82 RID: 56194 RVA: 0x003AFB8D File Offset: 0x003ADD8D
	protected override void OnBeforeShow()
	{
		this.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600DB83 RID: 56195 RVA: 0x003AFBC6 File Offset: 0x003ADDC6
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600DB84 RID: 56196 RVA: 0x003AFBFF File Offset: 0x003ADDFF
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x0600DB85 RID: 56197 RVA: 0x003AFC01 File Offset: 0x003ADE01
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x0600DB86 RID: 56198 RVA: 0x003AFC03 File Offset: 0x003ADE03
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
	}

	// Token: 0x0600DB87 RID: 56199 RVA: 0x003AFC05 File Offset: 0x003ADE05
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
	}

	// Token: 0x0600DB88 RID: 56200 RVA: 0x003AFC08 File Offset: 0x003ADE08
	public virtual void ShowTips()
	{
		base.Show(null);
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600DB89 RID: 56201 RVA: 0x003AFC44 File Offset: 0x003ADE44
	public void HideTips()
	{
		if (!base.IsShowOrShowing)
		{
			return;
		}
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
	}

	// Token: 0x040068E3 RID: 26851
	[Nullable(1)]
	protected LevelSequencePlayer SequencePlayer;
}
