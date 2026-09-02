using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E32 RID: 7730
public class GuideTutorialTipsView : UiTickViewBase, IStaticVariableResetter
{
	// Token: 0x0600E4B8 RID: 58552 RVA: 0x003DB605 File Offset: 0x003D9805
	static GuideTutorialTipsView()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GuideTutorialTipsView.CreateStaticDefaultValue), new Action(GuideTutorialTipsView.ResetStaticDefaultValue));
	}

	// Token: 0x0600E4B9 RID: 58553 RVA: 0x003DB624 File Offset: 0x003D9824
	public static void CreateStaticDefaultValue()
	{
		GuideTutorialTipsView.RealProcessLock = false;
		GuideTutorialTipsView.BackupTimerHandle = null;
	}

	// Token: 0x0600E4BA RID: 58554 RVA: 0x003DB632 File Offset: 0x003D9832
	public static void ResetStaticDefaultValue()
	{
		GuideTutorialTipsView.RealProcessLock = false;
		GuideTutorialTipsView.BackupTimerHandle = null;
	}

	// Token: 0x0600E4BB RID: 58555 RVA: 0x003DB640 File Offset: 0x003D9840
	[NullableContext(1)]
	public GuideTutorialTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E4BC RID: 58556 RVA: 0x003DB64C File Offset: 0x003D984C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OpenGuideTutorialView));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600E4BD RID: 58557 RVA: 0x003DB758 File Offset: 0x003D9958
	protected override UniTask OnCreateAsync()
	{
		GuideTutorialTipsView.<OnCreateAsync>d__13 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<GuideTutorialTipsView.<OnCreateAsync>d__13>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E4BE RID: 58558 RVA: 0x003DB79C File Offset: 0x003D999C
	private void OpenGuideTutorialView()
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem != null && rootItem.bIsUIActive && !ModelBase<LoadingModel>.Instance.IsLoadingView)
		{
			this.TutorialInfo.ClickToPopState();
			this.UiViewSequence.PlaySequence("CloseTips", true, null);
		}
	}

	// Token: 0x0600E4BF RID: 58559 RVA: 0x003DB7F0 File Offset: 0x003D99F0
	[NullableContext(1)]
	private void OnStartSequenceEnd(string _)
	{
		this.TutorialInfo.TipState = ETutorialListType.Timing;
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, delegate(bool _)
		{
			ModelBase<GuideModel>.Instance.TryShowTutorial();
		});
	}

	// Token: 0x0600E4C0 RID: 58560 RVA: 0x003DB83D File Offset: 0x003D9A3D
	[NullableContext(1)]
	private void OnFinishSequenceEnd(string _)
	{
		if (this.TutorialInfo.TipState == ETutorialListType.Pop)
		{
			base.CloseMe(delegate(bool _)
			{
				ModelBase<GuideModel>.Instance.TryShowGuideTutorialView(true);
			});
			return;
		}
		this.OnTutorialHaveFinished();
	}

	// Token: 0x0600E4C1 RID: 58561 RVA: 0x003DB87C File Offset: 0x003D9A7C
	protected override void OnStart()
	{
		UUIText text = base.GetText(0);
		if (this.ViewConf == null)
		{
			if (!this.WaitToDestroy)
			{
				this.OnTutorialHaveFinished();
			}
			return;
		}
		string groupName = this.ViewConf.Value.GroupName;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, groupName, Array.Empty<object>());
		if (this.TypeIconSprite != null)
		{
			base.GetSprite(1).SetSprite(this.TypeIconSprite, true);
		}
		string tutorialTypeTxt = TutorialUtils.GetTutorialTypeTxt((ETutorialType)this.ViewConf.Value.TutorialType);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), tutorialTypeTxt, Array.Empty<object>());
		base.GetSprite(3).SetFillAmount(1f);
		this.UiViewSequence.AddSequenceFinishEvent("StartTips", new Action<string>(this.OnStartSequenceEnd), false);
		this.UiViewSequence.AddSequenceFinishEvent("CloseTips", new Action<string>(this.OnFinishSequenceEnd), false);
		if (!GuideTutorialTipsView.RealProcessLock)
		{
			GuideTutorialTipsView.RealProcessLock = true;
			ControllerBase<TutorialController>.Instance.OnTutorialTipExistChanged(true);
		}
		TimerHandle backupTimerHandle = GuideTutorialTipsView.BackupTimerHandle;
		if (backupTimerHandle != null)
		{
			backupTimerHandle.Remove();
		}
		GuideTutorialTipsView.BackupTimerHandle = null;
	}

	// Token: 0x0600E4C2 RID: 58562 RVA: 0x003DB998 File Offset: 0x003D9B98
	protected override void OnAfterShow()
	{
		if (this.TutorialInfo.TipState == ETutorialListType.Tip)
		{
			this.UiViewSequence.PlaySequence("StartTips", false, null);
			return;
		}
		this.UiViewSequence.PlaySequence("StartAtOnce", false, null);
	}

	// Token: 0x0600E4C3 RID: 58563 RVA: 0x003DB9E8 File Offset: 0x003D9BE8
	protected override void OnBeforeDestroy()
	{
		if (this.TutorialInfo.TipState == ETutorialListType.Tip)
		{
			TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
			TTimerAction action;
			if ((action = GuideTutorialTipsView.<>O.<0>__ExecuteRealBeforeDestroy) == null)
			{
				action = (GuideTutorialTipsView.<>O.<0>__ExecuteRealBeforeDestroy = new TTimerAction(GuideTutorialTipsView.ExecuteRealBeforeDestroy));
			}
			GuideTutorialTipsView.BackupTimerHandle = gameplayTimeInstance.Delay(action, 5000f, null, null, true, 1f);
			return;
		}
		GuideTutorialTipsView.ExecuteRealBeforeDestroy(0f);
	}

	// Token: 0x0600E4C4 RID: 58564 RVA: 0x003DBA44 File Offset: 0x003D9C44
	private static void ExecuteRealBeforeDestroy(float deltaTime)
	{
		if (GuideTutorialTipsView.RealProcessLock)
		{
			ControllerBase<TutorialController>.Instance.OnTutorialTipExistChanged(false);
			GuideTutorialTipsView.RealProcessLock = false;
		}
		TimerHandle backupTimerHandle = GuideTutorialTipsView.BackupTimerHandle;
		if (backupTimerHandle != null)
		{
			backupTimerHandle.Remove();
		}
		GuideTutorialTipsView.BackupTimerHandle = null;
	}

	// Token: 0x0600E4C5 RID: 58565 RVA: 0x003DBA75 File Offset: 0x003D9C75
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.HideHUD, new Action(this.OnBattleViewChange));
		Singleton<EventSystem>.Instance.Add(EEventName.ShowHUD, new Action(this.OnBattleViewChange));
	}

	// Token: 0x0600E4C6 RID: 58566 RVA: 0x003DBAAF File Offset: 0x003D9CAF
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.HideHUD, new Action(this.OnBattleViewChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShowHUD, new Action(this.OnBattleViewChange));
	}

	// Token: 0x0600E4C7 RID: 58567 RVA: 0x003DBAE9 File Offset: 0x003D9CE9
	private void OnBattleViewChange()
	{
		this.SetActive(Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView));
	}

	// Token: 0x0600E4C8 RID: 58568 RVA: 0x003DBB00 File Offset: 0x003D9D00
	protected override void OnTick(float delta)
	{
		if (base.IsShow)
		{
			float fillAmount = this.TutorialInfo.Duration / (float)this.TotalDuration;
			UUISprite sprite = base.GetSprite(3);
			if (sprite != null)
			{
				sprite.SetFillAmount(fillAmount);
			}
			if (this.TutorialInfo.Duration <= 0f && this.UiViewSequence.CurrentSequenceName != "CloseTips")
			{
				this.UiViewSequence.StopPrevSequence(false, false);
				this.UiViewSequence.PlaySequence("CloseTips", true, null);
			}
		}
	}

	// Token: 0x0600E4C9 RID: 58569 RVA: 0x003DBB8C File Offset: 0x003D9D8C
	private void OnTutorialHaveFinished()
	{
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, delegate(bool _)
		{
			ControllerBase<TutorialController>.Instance.TryOpenAwardUiViewPending();
			ModelBase<GuideModel>.Instance.TryShowTutorial();
		});
	}

	// Token: 0x04006DF8 RID: 28152
	[Nullable(2)]
	public TutorialListInfo TutorialInfo;

	// Token: 0x04006DF9 RID: 28153
	private GuideTutorial? ViewConf;

	// Token: 0x04006DFA RID: 28154
	private int TotalDuration;

	// Token: 0x04006DFB RID: 28155
	[Nullable(2)]
	private ULGUISpriteData_BaseObject TypeIconSprite;

	// Token: 0x04006DFC RID: 28156
	private static bool RealProcessLock;

	// Token: 0x04006DFD RID: 28157
	private const int BackupDuration = 5000;

	// Token: 0x04006DFE RID: 28158
	[Nullable(2)]
	private static TimerHandle BackupTimerHandle;

	// Token: 0x020081A0 RID: 33184
	private enum EGuideTutorialTipsView
	{
		// Token: 0x0402C00C RID: 180236
		TxtName,
		// Token: 0x0402C00D RID: 180237
		TutorialTypeTex,
		// Token: 0x0402C00E RID: 180238
		TutorialBtn,
		// Token: 0x0402C00F RID: 180239
		TimerSlider,
		// Token: 0x0402C010 RID: 180240
		TxtEvent
	}

	// Token: 0x020081A1 RID: 33185
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402C011 RID: 180241
		public static TTimerAction <0>__ExecuteRealBeforeDestroy;
	}
}
