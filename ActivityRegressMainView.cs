using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001520 RID: 5408
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressMainView : UiViewBase
{
	// Token: 0x06009731 RID: 38705 RVA: 0x00278E7D File Offset: 0x0027707D
	public ActivityRegressMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009732 RID: 38706 RVA: 0x00278EA8 File Offset: 0x002770A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x06009733 RID: 38707 RVA: 0x00278F44 File Offset: 0x00277144
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressMainView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressMainView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009734 RID: 38708 RVA: 0x00278F88 File Offset: 0x00277188
	protected override void OnBeforeShow()
	{
		ActivityRegressMainSubViewBase activityRegressMainSubViewBase;
		if (this.CurrentSubViewType != null && this.SubViewMap.TryGetValue(this.CurrentSubViewType.Value, out activityRegressMainSubViewBase))
		{
			bool isShowOrShowing = activityRegressMainSubViewBase.IsShowOrShowing;
			activityRegressMainSubViewBase.SetActive(true);
			if (!isShowOrShowing)
			{
				this.UiViewSequence.StopSequenceByKey("Switch", true, true);
				base.PlaySequenceAsync("Switch", true, false, null);
				activityRegressMainSubViewBase.OnParentShow();
			}
		}
		this.RefreshTimer = TimerSystem.Instance.Forever(new TTimerAction(this.OnTimerRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		this.RefreshTime();
	}

	// Token: 0x06009735 RID: 38709 RVA: 0x00279030 File Offset: 0x00277230
	private void RefreshTime()
	{
		ActivityBaseData activityData = this.ActivityData;
		if (activityData == null || !activityData.CheckIfInShowTime())
		{
			base.CloseMe(null);
			return;
		}
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.EndShowTime, this.RemainTimeText);
		base.GetText(5).SetText(remainTimeText, true);
	}

	// Token: 0x06009736 RID: 38710 RVA: 0x00279086 File Offset: 0x00277286
	private void OnTimerRefresh(float _)
	{
		this.RefreshTime();
	}

	// Token: 0x06009737 RID: 38711 RVA: 0x0027908E File Offset: 0x0027728E
	private void ClearTimer()
	{
		if (this.RefreshTimer != null && TimerSystem.Instance.Has(this.RefreshTimer))
		{
			TimerSystem.Instance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}
	}

	// Token: 0x06009738 RID: 38712 RVA: 0x002790C4 File Offset: 0x002772C4
	protected override void OnAfterHide()
	{
		this.ClearTimer();
		ActivityRegressMainSubViewBase activityRegressMainSubViewBase;
		if (this.CurrentSubViewType != null && this.SubViewMap.TryGetValue(this.CurrentSubViewType.Value, out activityRegressMainSubViewBase))
		{
			activityRegressMainSubViewBase.SetActive(false);
		}
	}

	// Token: 0x06009739 RID: 38713 RVA: 0x00279108 File Offset: 0x00277308
	protected override void OnBeforeDestroy()
	{
		this.CloseAllSubUi();
		if (this.CaptionTabComponent != null)
		{
			foreach (KeyValuePair<int, ActivityRegressTabItemPanel> keyValuePair in this.CaptionTabComponent.GetTabItemMap())
			{
				keyValuePair.Value.Clear();
			}
			this.CaptionTabComponent.Destroy(null);
			this.CaptionTabComponent = null;
		}
	}

	// Token: 0x0600973A RID: 38714 RVA: 0x00279188 File Offset: 0x00277388
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(this.OnActivityUpdate));
	}

	// Token: 0x0600973B RID: 38715 RVA: 0x002791A6 File Offset: 0x002773A6
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(this.OnActivityUpdate));
	}

	// Token: 0x0600973C RID: 38716 RVA: 0x002791C4 File Offset: 0x002773C4
	private UniTask OpenSubUi(EActivityMainSubViewNewType viewType, int subTabIndex)
	{
		ActivityRegressMainView.<OpenSubUi>d__22 <OpenSubUi>d__;
		<OpenSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenSubUi>d__.<>4__this = this;
		<OpenSubUi>d__.viewType = viewType;
		<OpenSubUi>d__.subTabIndex = subTabIndex;
		<OpenSubUi>d__.<>1__state = -1;
		<OpenSubUi>d__.<>t__builder.Start<ActivityRegressMainView.<OpenSubUi>d__22>(ref <OpenSubUi>d__);
		return <OpenSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x0600973D RID: 38717 RVA: 0x00279218 File Offset: 0x00277418
	private UniTask HideSubUi(EActivityMainSubViewNewType viewType)
	{
		ActivityRegressMainView.<HideSubUi>d__23 <HideSubUi>d__;
		<HideSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HideSubUi>d__.<>4__this = this;
		<HideSubUi>d__.viewType = viewType;
		<HideSubUi>d__.<>1__state = -1;
		<HideSubUi>d__.<>t__builder.Start<ActivityRegressMainView.<HideSubUi>d__23>(ref <HideSubUi>d__);
		return <HideSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x0600973E RID: 38718 RVA: 0x00279264 File Offset: 0x00277464
	private void CloseAllSubUi()
	{
		foreach (KeyValuePair<EActivityMainSubViewNewType, ActivityRegressMainSubViewBase> keyValuePair in this.SubViewMap)
		{
			ActivityRegressMainSubViewBase value = keyValuePair.Value;
			value.UnBindPassRecallBaseCallBack();
			value.CloseMeAsync().Forget<bool>();
		}
		this.SubViewMap.Clear();
	}

	// Token: 0x0600973F RID: 38719 RVA: 0x002792D4 File Offset: 0x002774D4
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ActivityRegressMainSubViewBase> CreateSubUi(EActivityMainSubViewNewType viewType)
	{
		ActivityRegressMainView.<CreateSubUi>d__25 <CreateSubUi>d__;
		<CreateSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder<ActivityRegressMainSubViewBase>.Create();
		<CreateSubUi>d__.<>4__this = this;
		<CreateSubUi>d__.viewType = viewType;
		<CreateSubUi>d__.<>1__state = -1;
		<CreateSubUi>d__.<>t__builder.Start<ActivityRegressMainView.<CreateSubUi>d__25>(ref <CreateSubUi>d__);
		return <CreateSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x06009740 RID: 38720 RVA: 0x00279320 File Offset: 0x00277520
	private UniTask ChangeSubUi(EActivityMainSubViewNewType subViewType, int subTabIndex = 0)
	{
		ActivityRegressMainView.<ChangeSubUi>d__26 <ChangeSubUi>d__;
		<ChangeSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ChangeSubUi>d__.<>4__this = this;
		<ChangeSubUi>d__.subViewType = subViewType;
		<ChangeSubUi>d__.subTabIndex = subTabIndex;
		<ChangeSubUi>d__.<>1__state = -1;
		<ChangeSubUi>d__.<>t__builder.Start<ActivityRegressMainView.<ChangeSubUi>d__26>(ref <ChangeSubUi>d__);
		return <ChangeSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x06009741 RID: 38721 RVA: 0x00279374 File Offset: 0x00277574
	private void UpdateTitle()
	{
		string text = null;
		if (this.CurrentSubViewType.GetValueOrDefault() == EActivityMainSubViewNewType.Sign)
		{
			text = "RecallActivity_Sign_Title";
		}
		string titleIconPath = this.GetTitleIconPath();
		string iconPath = (titleIconPath != null) ? ConfigBase<UiResourceConfig>.Instance.GetResourcePath(titleIconPath) : "";
		if (text != null)
		{
			this.CaptionTabComponent.UpdateTitle(iconPath, new CommonTabTitleData(text, Array.Empty<object>()));
		}
		base.GetItem(4).SetUIActive(this.CurrentSubViewType.GetValueOrDefault() != EActivityMainSubViewNewType.Sign);
	}

	// Token: 0x06009742 RID: 38722 RVA: 0x002793EC File Offset: 0x002775EC
	[NullableContext(2)]
	private string GetTypeTitleIconPath(EActivityMainSubViewNewType type)
	{
		switch (type)
		{
		case EActivityMainSubViewNewType.BattlePass:
			return "SP_IconCircumfluence1";
		case EActivityMainSubViewNewType.Recommend:
			return "SP_IconTab01";
		case EActivityMainSubViewNewType.DoubleDrop:
			return "SP_IconCircumfluence3";
		case EActivityMainSubViewNewType.Adventure:
			return "SP_IconBeginnerDev";
		case EActivityMainSubViewNewType.RoleGachaPool:
			return "SP_IconComDrawcard";
		case EActivityMainSubViewNewType.MainLine:
			return "SP_FuncIconRenwu";
		case EActivityMainSubViewNewType.Sign:
			return "SP_IconCircumfluence1";
		default:
			return null;
		}
	}

	// Token: 0x06009743 RID: 38723 RVA: 0x00279448 File Offset: 0x00277648
	[NullableContext(2)]
	private string GetTypeTitle(EActivityMainSubViewNewType type)
	{
		switch (type)
		{
		case EActivityMainSubViewNewType.BattlePass:
			return "Regress_BattlePass_Title";
		case EActivityMainSubViewNewType.Recommend:
			return "Regress_Recommend_Title";
		case EActivityMainSubViewNewType.DoubleDrop:
			return "Regress_DoubleDrop_Title";
		case EActivityMainSubViewNewType.Adventure:
			return "Regress_Adventure_Title";
		case EActivityMainSubViewNewType.RoleGachaPool:
			return "Regress_NewVersion_Role_Title";
		case EActivityMainSubViewNewType.MainLine:
			return "Regress_NewVersion_MainLine_Title";
		case EActivityMainSubViewNewType.Sign:
			return "Regress_Sign_Title";
		default:
			return null;
		}
	}

	// Token: 0x06009744 RID: 38724 RVA: 0x002794A4 File Offset: 0x002776A4
	[NullableContext(2)]
	private string GetTitleIconPath()
	{
		EActivityMainSubViewNewType? currentSubViewType = this.CurrentSubViewType;
		if (currentSubViewType != null)
		{
			switch (currentSubViewType.GetValueOrDefault())
			{
			case EActivityMainSubViewNewType.BattlePass:
				return "SP_IconCircumfluence1";
			case EActivityMainSubViewNewType.Recommend:
				return "SP_IconTab01";
			case EActivityMainSubViewNewType.DoubleDrop:
				return "SP_IconCircumfluence3";
			case EActivityMainSubViewNewType.Adventure:
				return "SP_IconBeginnerDev";
			case EActivityMainSubViewNewType.RoleGachaPool:
				return "SP_IconComDrawcard";
			case EActivityMainSubViewNewType.MainLine:
				return "SP_FuncIconRenwu";
			case EActivityMainSubViewNewType.Sign:
				return "SP_IconCircumfluence1";
			}
		}
		return null;
	}

	// Token: 0x06009745 RID: 38725 RVA: 0x00279518 File Offset: 0x00277718
	private void OnActivityUpdate()
	{
		this.RefreshView();
	}

	// Token: 0x06009746 RID: 38726 RVA: 0x00279520 File Offset: 0x00277720
	private void RefreshView()
	{
		ActivityRegressMainSubViewBase activityRegressMainSubViewBase;
		if (this.CurrentSubViewType != null && this.SubViewMap.TryGetValue(this.CurrentSubViewType.Value, out activityRegressMainSubViewBase))
		{
			activityRegressMainSubViewBase.Update(0);
		}
	}

	// Token: 0x06009747 RID: 38727 RVA: 0x0027955C File Offset: 0x0027775C
	private UniTask CreateTabs()
	{
		ActivityRegressMainView.<CreateTabs>d__33 <CreateTabs>d__;
		<CreateTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateTabs>d__.<>4__this = this;
		<CreateTabs>d__.<>1__state = -1;
		<CreateTabs>d__.<>t__builder.Start<ActivityRegressMainView.<CreateTabs>d__33>(ref <CreateTabs>d__);
		return <CreateTabs>d__.<>t__builder.Task;
	}

	// Token: 0x06009748 RID: 38728 RVA: 0x002795A0 File Offset: 0x002777A0
	private UniTask RefreshTabs()
	{
		ActivityRegressMainView.<RefreshTabs>d__34 <RefreshTabs>d__;
		<RefreshTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabs>d__.<>4__this = this;
		<RefreshTabs>d__.<>1__state = -1;
		<RefreshTabs>d__.<>t__builder.Start<ActivityRegressMainView.<RefreshTabs>d__34>(ref <RefreshTabs>d__);
		return <RefreshTabs>d__.<>t__builder.Task;
	}

	// Token: 0x06009749 RID: 38729 RVA: 0x002795E3 File Offset: 0x002777E3
	private ActivityRegressTabItemPanel ProxyCreateTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new ActivityRegressTabItemPanel();
	}

	// Token: 0x0600974A RID: 38730 RVA: 0x002795EA File Offset: 0x002777EA
	private void OnTabSelected(int index)
	{
		if (this.IgnoreFireEvent)
		{
			this.IgnoreFireEvent = false;
			return;
		}
		this.LastClickTime = Singleton<Time>.Instance.Now;
		this.ChangeSubUi(this.TabTypeList[index], 0).Forget();
	}

	// Token: 0x0600974B RID: 38731 RVA: 0x00279624 File Offset: 0x00277824
	private CommonTabData GetCommonData(int index)
	{
		EActivityMainSubViewNewType type = this.TabTypeList[index];
		string textId = this.GetTypeTitle(type) ?? "";
		string typeTitleIconPath = this.GetTypeTitleIconPath(type);
		return new CommonTabData((typeTitleIconPath != null) ? ConfigBase<UiResourceConfig>.Instance.GetResourcePath(typeTitleIconPath) : "", new CommonTabTitleData(textId, Array.Empty<object>()), null);
	}

	// Token: 0x0600974C RID: 38732 RVA: 0x00279680 File Offset: 0x00277880
	protected bool CanToggleChange(int index, bool? _)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		int num = 600;
		return this.LastClickTime == 0.0 || Singleton<Time>.Instance.Now - this.LastClickTime >= (double)num;
	}

	// Token: 0x04004631 RID: 17969
	private const int TAB_CD = 600;

	// Token: 0x04004632 RID: 17970
	[Nullable(2)]
	private ActivityBaseData ActivityData;

	// Token: 0x04004633 RID: 17971
	private EActivityRegressMainViewOpenDataType OpenType;

	// Token: 0x04004634 RID: 17972
	[Nullable(2)]
	private TimerHandle RefreshTimer;

	// Token: 0x04004635 RID: 17973
	private readonly Dictionary<EActivityMainSubViewNewType, ActivityRegressMainSubViewBase> SubViewMap = new Dictionary<EActivityMainSubViewNewType, ActivityRegressMainSubViewBase>();

	// Token: 0x04004636 RID: 17974
	private EActivityMainSubViewNewType? CurrentSubViewType;

	// Token: 0x04004637 RID: 17975
	[Nullable(2)]
	private ActivityRegressMainCaptionListPanel CaptionTabComponent;

	// Token: 0x04004638 RID: 17976
	private List<EActivityMainSubViewNewType> TabTypeList = new List<EActivityMainSubViewNewType>();

	// Token: 0x04004639 RID: 17977
	private bool IgnoreFireEvent;

	// Token: 0x0400463A RID: 17978
	private string RemainTimeText = "";

	// Token: 0x0400463B RID: 17979
	private double LastClickTime;

	// Token: 0x020078D0 RID: 30928
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029869 RID: 170089
		public const int CaptionNameList = 0;

		// Token: 0x0402986A RID: 170090
		public const int Bg = 1;

		// Token: 0x0402986B RID: 170091
		public const int SubViewRoot = 2;

		// Token: 0x0402986C RID: 170092
		public const int Bg2 = 3;

		// Token: 0x0402986D RID: 170093
		public const int TimeItem = 4;

		// Token: 0x0402986E RID: 170094
		public const int TimeText = 5;
	}
}
