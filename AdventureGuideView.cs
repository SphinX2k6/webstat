using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001745 RID: 5957
[NullableContext(1)]
[Nullable(0)]
public class AdventureGuideView : UiViewBase
{
	// Token: 0x0600A77D RID: 42877 RVA: 0x002C8B97 File Offset: 0x002C6D97
	public AdventureGuideView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A77E RID: 42878 RVA: 0x002C8BAC File Offset: 0x002C6DAC
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBackBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnIntroductionBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A77F RID: 42879 RVA: 0x002C8D1C File Offset: 0x002C6F1C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.AdventureHelpBtn, new Action<int>(this.AdventureHelpBtn));
		Singleton<EventSystem>.Instance.Add<string, string>(EEventName.DailyActivityCountDownUpdate, new Action<string, string>(this.SetCountDownText));
		Singleton<EventSystem>.Instance.Add<EUiTabViewName, int?>(EEventName.ChangeChildView, new Action<EUiTabViewName, int?>(this.SwitchTabView));
		Singleton<EventSystem>.Instance.Add<AdventureGuideViewOpenData>(EEventName.SwitchAdventureGuideViewTab, new Action<AdventureGuideViewOpenData>(this.SwitchAdventureGuideViewTab));
	}

	// Token: 0x0600A780 RID: 42880 RVA: 0x002C8D94 File Offset: 0x002C6F94
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.AdventureHelpBtn, new Action<int>(this.AdventureHelpBtn));
		Singleton<EventSystem>.Instance.Remove(EEventName.DailyActivityCountDownUpdate, new Action<string, string>(this.SetCountDownText));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeChildView, new Action<EUiTabViewName, int?>(this.SwitchTabView));
		Singleton<EventSystem>.Instance.Remove(EEventName.SwitchAdventureGuideViewTab, new Action<AdventureGuideViewOpenData>(this.SwitchAdventureGuideViewTab));
	}

	// Token: 0x0600A781 RID: 42881 RVA: 0x002C8E0C File Offset: 0x002C700C
	protected override UniTask OnBeforeStartAsync()
	{
		AdventureGuideView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AdventureGuideView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A782 RID: 42882 RVA: 0x002C8E4F File Offset: 0x002C704F
	protected override void OnBeforeShow()
	{
		TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
		if (tabComponent == null)
		{
			return;
		}
		tabComponent.SelectToggleByIndex(this.CurSelectTabIndex, true);
	}

	// Token: 0x0600A783 RID: 42883 RVA: 0x002C8E68 File Offset: 0x002C7068
	private int GetIndexByTabViewName(EUiTabViewName viewName)
	{
		int num = this.TabDataList.Length;
		for (int i = 0; i < num; i++)
		{
			if (this.TabDataList[i].ChildViewName == viewName)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x0600A784 RID: 42884 RVA: 0x002C8EAC File Offset: 0x002C70AC
	protected UniTask InitTabComponent()
	{
		AdventureGuideView.<InitTabComponent>d__16 <InitTabComponent>d__;
		<InitTabComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTabComponent>d__.<>4__this = this;
		<InitTabComponent>d__.<>1__state = -1;
		<InitTabComponent>d__.<>t__builder.Start<AdventureGuideView.<InitTabComponent>d__16>(ref <InitTabComponent>d__);
		return <InitTabComponent>d__.<>t__builder.Task;
	}

	// Token: 0x0600A785 RID: 42885 RVA: 0x002C8EEF File Offset: 0x002C70EF
	private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x0600A786 RID: 42886 RVA: 0x002C8EF8 File Offset: 0x002C70F8
	private void ToggleCallBack(int index)
	{
		this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
		UiDynamicTab data = this.TabDataList[index];
		string childViewName = data.ChildViewName;
		ModelBase<AdventureGuideModel>.Instance.CurrentGuideTabName = new EUiTabViewName?((EUiTabViewName)childViewName);
		this.ShowCountDownPanel(false);
		TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
		List<CommonCurrencyItem> list = (tabComponent != null) ? tabComponent.GetCurrencyItemList() : null;
		if (list != null)
		{
			foreach (CommonCurrencyItem commonCurrencyItem in list)
			{
				commonCurrencyItem.SetUiActive(childViewName == EUiTabViewName.NewSoundAreaView || childViewName == EUiTabViewName.DisposableChallengeView);
			}
		}
		TabComponentWithCaptionItem<CommonTabItem> tabComponent2 = this.TabComponent;
		CommonTabItem tabItem = (tabComponent2 != null) ? tabComponent2.GetTabItemByIndex(index) : null;
		TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
		if (tabViewComponent != null)
		{
			tabViewComponent.ToggleCallBack(data, (EUiTabViewName)childViewName, tabItem, this.TabViewOpenData, null);
		}
		this.CurSelectTabIndex = index;
		this.RefreshIntroductionBtn();
	}

	// Token: 0x0600A787 RID: 42887 RVA: 0x002C9010 File Offset: 0x002C7210
	private void RefreshIntroductionBtn()
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[this.CurSelectTabIndex];
		EUiTabViewName left = (EUiTabViewName)uiDynamicTab.ChildViewName;
		UUIButtonComponent button = base.GetButton(6);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(ModelBase<FunctionModel>.Instance.IsOpen(10097) && left == EUiTabViewName.NewSoundAreaView);
	}

	// Token: 0x0600A788 RID: 42888 RVA: 0x002C907C File Offset: 0x002C727C
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x0600A789 RID: 42889 RVA: 0x002C90B4 File Offset: 0x002C72B4
	protected UniTask RebuildTabItem()
	{
		AdventureGuideView.<RebuildTabItem>d__21 <RebuildTabItem>d__;
		<RebuildTabItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RebuildTabItem>d__.<>4__this = this;
		<RebuildTabItem>d__.<>1__state = -1;
		<RebuildTabItem>d__.<>t__builder.Start<AdventureGuideView.<RebuildTabItem>d__21>(ref <RebuildTabItem>d__);
		return <RebuildTabItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600A78A RID: 42890 RVA: 0x002C90F8 File Offset: 0x002C72F8
	protected bool CanToggleChange(int index, bool? state)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
		if (this.LastClickTime != null)
		{
			double? num = Singleton<Time>.Instance.Now - this.LastClickTime;
			int? num2 = intConfig;
			double? num3 = (num2 != null) ? new double?((double)num2.GetValueOrDefault()) : null;
			if (!(num.GetValueOrDefault() >= num3.GetValueOrDefault() & (num != null & num3 != null)))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600A78B RID: 42891 RVA: 0x002C91B4 File Offset: 0x002C73B4
	private void SwitchAdventureGuideViewTab(AdventureGuideViewOpenData data)
	{
		this.TabViewOpenData = data;
		this.CurSelectTabIndex = this.GetIndexByTabViewName(data.OpenTabViewName ?? EUiTabViewName.DailyActivityTabView);
		TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
		if (tabComponent != null)
		{
			tabComponent.SelectToggleByIndex(this.CurSelectTabIndex, true);
		}
		ModelBase<AdventureGuideModel>.Instance.CurrentGuideTabName = data.OpenTabViewName;
	}

	// Token: 0x0600A78C RID: 42892 RVA: 0x002C921C File Offset: 0x002C741C
	private void SwitchTabView(EUiTabViewName tabViewName, int? param)
	{
		AdventureGuideViewOpenData tabViewOpenData = new AdventureGuideViewOpenData
		{
			OpenTabViewName = new EUiTabViewName?(tabViewName),
			OpenParam = param
		};
		this.TabViewOpenData = tabViewOpenData;
		this.CurSelectTabIndex = this.GetIndexByTabViewName(tabViewName);
		TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
		if (tabComponent != null)
		{
			tabComponent.SelectToggleByIndex(this.CurSelectTabIndex, true);
		}
		ModelBase<AdventureGuideModel>.Instance.CurrentGuideTabName = new EUiTabViewName?(tabViewName);
	}

	// Token: 0x0600A78D RID: 42893 RVA: 0x002C927E File Offset: 0x002C747E
	private void ShowCountDownPanel(bool bVisible)
	{
		if (bVisible)
		{
			this.SetCountDownText("", "");
		}
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(bVisible);
		}
		this.TimePanelShowFlag = bVisible;
	}

	// Token: 0x0600A78E RID: 42894 RVA: 0x002C92AD File Offset: 0x002C74AD
	public void SetTabViewOpenData(AdventureGuideViewOpenData data)
	{
		this.TabViewOpenData = data;
		if (data.OpenTabViewName != null)
		{
			this.CurSelectTabIndex = this.GetIndexByTabViewName(data.OpenTabViewName.Value);
		}
	}

	// Token: 0x0600A78F RID: 42895 RVA: 0x002C92DC File Offset: 0x002C74DC
	private void SetCountDownText(string textParam, string textId)
	{
		if (!StringUtils.IsEmpty(textParam) || !StringUtils.IsEmpty(textId))
		{
			if (!this.TimePanelShowFlag)
			{
				this.ShowCountDownPanel(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), textId, new <>z__ReadOnlySingleElementList<object>(textParam));
			return;
		}
		UUIText text = base.GetText(5);
		if (text == null)
		{
			return;
		}
		text.SetText("", true);
	}

	// Token: 0x0600A790 RID: 42896 RVA: 0x002C9338 File Offset: 0x002C7538
	private void OnBackBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.AdventureGuideView, null);
	}

	// Token: 0x0600A791 RID: 42897 RVA: 0x002C934C File Offset: 0x002C754C
	private void OnIntroductionBtnClick()
	{
		int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
		if (devTargetRoleId == 0 || RoleDevelopUtil.IsAnyProspectRole(devTargetRoleId))
		{
			ControllerBase<ChannelController>.Instance.OpenGameIntroduction();
			return;
		}
		ControllerBase<ChannelController>.Instance.OpenGameIntroductionByRoleId(devTargetRoleId);
	}

	// Token: 0x0600A792 RID: 42898 RVA: 0x002C9388 File Offset: 0x002C7588
	protected override void OnBeforeDestroy()
	{
		ModelBase<AdventureGuideModel>.Instance.CurrentGuideTabName = null;
		this.TabViewOpenData = null;
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		if (this.TabViewComponent != null)
		{
			this.TabViewComponent.DestroyTabViewComponent();
			this.TabViewComponent = null;
		}
	}

	// Token: 0x0600A793 RID: 42899 RVA: 0x002C93E1 File Offset: 0x002C75E1
	protected void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600A794 RID: 42900 RVA: 0x002C93EC File Offset: 0x002C75EC
	private void AdventureHelpBtn(int helpId)
	{
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(helpId != 0);
		}
		if (this.HelpBtn != null)
		{
			this.HelpBtn.HelpGroupId = helpId;
		}
	}

	// Token: 0x0600A795 RID: 42901 RVA: 0x002C9430 File Offset: 0x002C7630
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int num = int.Parse(configParams[0]);
		int index = -1;
		for (int i = 0; i < this.TabDataList.Length; i++)
		{
			if (this.TabDataList[i].Id == num)
			{
				index = i;
				break;
			}
		}
		TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
		UUIItem uuiitem;
		if (tabComponent == null)
		{
			uuiitem = null;
		}
		else
		{
			CommonTabItem tabItemByIndex = tabComponent.GetTabItemByIndex(index);
			uuiitem = ((tabItemByIndex != null) ? tabItemByIndex.GetRootItem() : null);
		}
		UUIItem uuiitem2 = uuiitem;
		if (uuiitem2 != null)
		{
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Guide;
		ELogAuthor author = ELogAuthor.JT;
		string message = "聚焦引导extraParam项配置有误";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x04004F12 RID: 20242
	[Nullable(2)]
	protected TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x04004F13 RID: 20243
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

	// Token: 0x04004F14 RID: 20244
	[Nullable(2)]
	private UUIExtendButtonComponent HelpBtn;

	// Token: 0x04004F15 RID: 20245
	private int CurSelectTabIndex;

	// Token: 0x04004F16 RID: 20246
	protected UiDynamicTab[] TabDataList = new UiDynamicTab[0];

	// Token: 0x04004F17 RID: 20247
	[Nullable(2)]
	private AdventureGuideViewOpenData TabViewOpenData;

	// Token: 0x04004F18 RID: 20248
	private double? LastClickTime;

	// Token: 0x04004F19 RID: 20249
	private bool TimePanelShowFlag;

	// Token: 0x02007AAC RID: 31404
	[NullableContext(0)]
	private enum ENodeDefine
	{
		// Token: 0x0402A058 RID: 172120
		BackBtn,
		// Token: 0x0402A059 RID: 172121
		TabComponent,
		// Token: 0x0402A05A RID: 172122
		TabRootItem,
		// Token: 0x0402A05B RID: 172123
		HelpBtn,
		// Token: 0x0402A05C RID: 172124
		PanelTime,
		// Token: 0x0402A05D RID: 172125
		TextTime,
		// Token: 0x0402A05E RID: 172126
		IntroductionBtn
	}
}
