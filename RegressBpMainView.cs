using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001533 RID: 5427
[NullableContext(2)]
[Nullable(0)]
public class RegressBpMainView : ActivityRegressMainSubViewBase
{
	// Token: 0x0600980A RID: 38922 RVA: 0x0027CDA8 File Offset: 0x0027AFA8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickBtnBuyExp)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickBtnClaimAll)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickBtnPay))
		};
	}

	// Token: 0x0600980B RID: 38923 RVA: 0x0027CEF0 File Offset: 0x0027B0F0
	protected override void OnUpdate(int subTabIndex)
	{
		this.RefreshButton();
		this.RefreshSubView();
	}

	// Token: 0x0600980C RID: 38924 RVA: 0x0027CF00 File Offset: 0x0027B100
	protected override UniTask OnBeforeStartAsync()
	{
		RegressBpMainView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RegressBpMainView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600980D RID: 38925 RVA: 0x0027CF43 File Offset: 0x0027B143
	private void OnInventoryUpdate(int configId, int count)
	{
		if (configId == 20)
		{
			this.RefreshSubView();
		}
	}

	// Token: 0x0600980E RID: 38926 RVA: 0x0027CF50 File Offset: 0x0027B150
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnInventoryUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.RegressBpExpAnim, new Action<int, int, float, float>(this.EventRegressBpExpAnim));
		this.RefreshView(true);
	}

	// Token: 0x0600980F RID: 38927 RVA: 0x0027CFA4 File Offset: 0x0027B1A4
	protected override void OnBeforeHide()
	{
		base.OnBeforeHide();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnInventoryUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.RegressBpExpAnim, new Action<int, int, float, float>(this.EventRegressBpExpAnim));
		this.KillExpTween();
	}

	// Token: 0x06009810 RID: 38928 RVA: 0x0027CFF5 File Offset: 0x0027B1F5
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.KillExpTween();
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.OnExpTweenUpdate));
	}

	// Token: 0x06009811 RID: 38929 RVA: 0x0027D014 File Offset: 0x0027B214
	private void RefreshView(bool playAnim = false)
	{
		IRegressLevelProgressData curLevelProgressData = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetCurLevelProgressData();
		base.GetText(2).SetText(curLevelProgressData.Level.ToString(), true);
		UUIText text = base.GetText(3);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(curLevelProgressData.CurScore);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(curLevelProgressData.NeedScore);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetSprite(4).SetFillAmount((float)curLevelProgressData.CurScore / (float)curLevelProgressData.NeedScore);
		this.RefreshButton();
		this.RefreshSubView(playAnim);
	}

	// Token: 0x06009812 RID: 38930 RVA: 0x0027D0BC File Offset: 0x0027B2BC
	private void RefreshButton()
	{
		IRegressLevelProgressData curLevelProgressData = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetCurLevelProgressData();
		base.GetButton(5).SetSelfInteractive(curLevelProgressData.Level < curLevelProgressData.MaxLevel);
		base.GetButton(8).RootUIComp.Get().SetUIActive(!ModelBase<ActivityRegressModel>.Instance.ActivityData.IsPayRewardUnlock());
		base.GetItem(9).SetUIActive(ModelBase<ActivityRegressModel>.Instance.ActivityData.CheckBpPayButtonRedDot());
	}

	// Token: 0x06009813 RID: 38931 RVA: 0x0027D13C File Offset: 0x0027B33C
	private void RefreshSubView(bool playAnim = false)
	{
		TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
		IRegressBpTabView regressBpTabView = ((tabViewComponent != null) ? tabViewComponent.GetCurrentTabView() : null) as IRegressBpTabView;
		if (regressBpTabView != null)
		{
			regressBpTabView.RefreshView(playAnim);
		}
		if (regressBpTabView == null)
		{
			return;
		}
		regressBpTabView.RefreshBtnClaimVisible(base.GetButton(7).RootUIComp.Get());
	}

	// Token: 0x06009814 RID: 38932 RVA: 0x0027D18B File Offset: 0x0027B38B
	private void RefreshSubView()
	{
		this.RefreshSubView(false);
	}

	// Token: 0x06009815 RID: 38933 RVA: 0x0027D194 File Offset: 0x0027B394
	[NullableContext(1)]
	public List<CommonTabItemData> CreateTabItemDataByLength(int length)
	{
		Dictionary<EUiTabViewName, ERedDotName> dictionary = new Dictionary<EUiTabViewName, ERedDotName>();
		dictionary[EUiTabViewName.RegressBpRewardTabView] = ERedDotName.ActivityRegressBpReward;
		dictionary[EUiTabViewName.RegressBpTaskTabView] = ERedDotName.ActivityRegressBpTask;
		List<CommonTabItemData> list = new List<CommonTabItemData>();
		for (int i = 0; i < length; i++)
		{
			CommonTabItemData commonTabItemData = new CommonTabItemData();
			commonTabItemData.Index = i;
			UiDynamicTab uiDynamicTab = this.TabDataList[i];
			commonTabItemData.Data = new CommonTabData("", new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
			ERedDotName value;
			if (dictionary.TryGetValue((EUiTabViewName)uiDynamicTab.ChildViewName, out value))
			{
				commonTabItemData.RedDotName = new ERedDotName?(value);
			}
			list.Add(commonTabItemData);
		}
		return list;
	}

	// Token: 0x06009816 RID: 38934 RVA: 0x0027D241 File Offset: 0x0027B441
	[NullableContext(1)]
	private RegressBpTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new RegressBpTabItem();
	}

	// Token: 0x06009817 RID: 38935 RVA: 0x0027D248 File Offset: 0x0027B448
	private void ToggleCallBack(int index)
	{
		UiDynamicTab data = this.TabDataList[index];
		TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
		if (tabViewComponent != null)
		{
			tabViewComponent.ToggleCallBack(data, (EUiTabViewName)data.ChildViewName, null, null, null);
		}
		TabViewComponent<UiDynamicTab> tabViewComponent2 = this.TabViewComponent;
		IRegressBpTabView regressBpTabView = ((tabViewComponent2 != null) ? tabViewComponent2.GetCurrentTabView() : null) as IRegressBpTabView;
		if (regressBpTabView != null)
		{
			regressBpTabView.RefreshBtnClaimVisible(base.GetButton(7).RootUIComp.Get());
		}
		UiSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.StopSequenceByKey("Switch", false, false);
		}
		UiSequencePlayer sequencePlayer2 = this.SequencePlayer;
		if (sequencePlayer2 == null)
		{
			return;
		}
		sequencePlayer2.PlaySequence("Switch", false, null);
	}

	// Token: 0x06009818 RID: 38936 RVA: 0x0027D2F8 File Offset: 0x0027B4F8
	private void OnClickBtnBuyExp()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RegressBpBuyLevelView, null, null);
	}

	// Token: 0x06009819 RID: 38937 RVA: 0x0027D30B File Offset: 0x0027B50B
	private void OnClickBtnClaimAll()
	{
		TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
		IRegressBpTabView regressBpTabView = ((tabViewComponent != null) ? tabViewComponent.GetCurrentTabView() : null) as IRegressBpTabView;
		if (regressBpTabView == null)
		{
			return;
		}
		regressBpTabView.OnClickBtnClaimAll();
	}

	// Token: 0x0600981A RID: 38938 RVA: 0x0027D330 File Offset: 0x0027B530
	private void OnClickBtnPay()
	{
		ModelBase<ActivityRegressModel>.Instance.ActivityData.SetBpPayButtonRedDotChecked();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RegressBpPayView, null, delegate(bool success, int viewId)
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.ActivityRegressMainView);
			if (viewByName == null)
			{
				return;
			}
			viewByName.AddChildViewById(viewId);
		});
		this.RefreshView(false);
	}

	// Token: 0x0600981B RID: 38939 RVA: 0x0027D382 File Offset: 0x0027B582
	private void EventRegressBpExpAnim(int prevLevel, int curLevel, float startFillAmount, float endFillAmount)
	{
		this.OnRegressBpExpAnim(prevLevel, curLevel, startFillAmount, endFillAmount);
	}

	// Token: 0x0600981C RID: 38940 RVA: 0x0027D390 File Offset: 0x0027B590
	private UniTask OnRegressBpExpAnim(int prevLevel, int curLevel, float startFillAmount, float endFillAmount)
	{
		RegressBpMainView.<OnRegressBpExpAnim>d__26 <OnRegressBpExpAnim>d__;
		<OnRegressBpExpAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnRegressBpExpAnim>d__.<>4__this = this;
		<OnRegressBpExpAnim>d__.prevLevel = prevLevel;
		<OnRegressBpExpAnim>d__.curLevel = curLevel;
		<OnRegressBpExpAnim>d__.startFillAmount = startFillAmount;
		<OnRegressBpExpAnim>d__.endFillAmount = endFillAmount;
		<OnRegressBpExpAnim>d__.<>1__state = -1;
		<OnRegressBpExpAnim>d__.<>t__builder.Start<RegressBpMainView.<OnRegressBpExpAnim>d__26>(ref <OnRegressBpExpAnim>d__);
		return <OnRegressBpExpAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600981D RID: 38941 RVA: 0x0027D3F4 File Offset: 0x0027B5F4
	private UniTask PlayExpBarAnim(float startFillAmount, float endFillAmount)
	{
		RegressBpMainView.<PlayExpBarAnim>d__27 <PlayExpBarAnim>d__;
		<PlayExpBarAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayExpBarAnim>d__.<>4__this = this;
		<PlayExpBarAnim>d__.startFillAmount = startFillAmount;
		<PlayExpBarAnim>d__.endFillAmount = endFillAmount;
		<PlayExpBarAnim>d__.<>1__state = -1;
		<PlayExpBarAnim>d__.<>t__builder.Start<RegressBpMainView.<PlayExpBarAnim>d__27>(ref <PlayExpBarAnim>d__);
		return <PlayExpBarAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600981E RID: 38942 RVA: 0x0027D448 File Offset: 0x0027B648
	private void OnExpTweenUpdate(float value)
	{
		UUISprite sprite = base.GetSprite(4);
		if (sprite != null)
		{
			sprite.SetFillAmount(value);
		}
	}

	// Token: 0x0600981F RID: 38943 RVA: 0x0027D467 File Offset: 0x0027B667
	private void OnExpTweenComplete()
	{
		this.KillExpTween();
	}

	// Token: 0x06009820 RID: 38944 RVA: 0x0027D470 File Offset: 0x0027B670
	private void KillExpTween()
	{
		if (this.BarAnimPromise != null)
		{
			this.BarAnimPromise.SetResult();
			this.BarAnimPromise = null;
		}
		if (this.ExpTweener != null && this.ExpTweener.IsValid())
		{
			this.ExpTweener.Kill(false);
		}
		this.ExpTweener = null;
	}

	// Token: 0x04004678 RID: 18040
	private const float EXP_BAR_ANIM_DURATION = 0.4f;

	// Token: 0x04004679 RID: 18041
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<RegressBpTabItem> TabComponent;

	// Token: 0x0400467A RID: 18042
	private TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x0400467B RID: 18043
	[Nullable(1)]
	private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x0400467C RID: 18044
	private ULTweener ExpTweener;

	// Token: 0x0400467D RID: 18045
	private FLTweenFloatSetterDynamic ExpTweenDelegate;

	// Token: 0x0400467E RID: 18046
	private CustomPromise BarAnimPromise;

	// Token: 0x020078E1 RID: 30945
	[NullableContext(0)]
	private class ERegressBpComponents
	{
		// Token: 0x040298C0 RID: 170176
		public const int PanelTopMenu = 0;

		// Token: 0x040298C1 RID: 170177
		public const int RoleDevelopToggle = 1;

		// Token: 0x040298C2 RID: 170178
		public const int TxtLevel = 2;

		// Token: 0x040298C3 RID: 170179
		public const int TxtExpValue = 3;

		// Token: 0x040298C4 RID: 170180
		public const int SpriteProgressFill = 4;

		// Token: 0x040298C5 RID: 170181
		public const int BtnBuyExp = 5;

		// Token: 0x040298C6 RID: 170182
		public const int PanelContent = 6;

		// Token: 0x040298C7 RID: 170183
		public const int BtnClaimAll = 7;

		// Token: 0x040298C8 RID: 170184
		public const int BtnPay = 8;

		// Token: 0x040298C9 RID: 170185
		public const int RedDot = 9;
	}
}
