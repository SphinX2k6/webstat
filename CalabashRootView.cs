using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001801 RID: 6145
[NullableContext(1)]
[Nullable(0)]
public class CalabashRootView : UiViewBase
{
	// Token: 0x0600AE96 RID: 44694 RVA: 0x002E7F80 File Offset: 0x002E6180
	public CalabashRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600AE97 RID: 44695 RVA: 0x002E8020 File Offset: 0x002E6220
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnSimplyToggleChange)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickedShared))
		};
	}

	// Token: 0x0600AE98 RID: 44696 RVA: 0x002E80F7 File Offset: 0x002E62F7
	private void CloseClick()
	{
		if (this.CheckTabViewCloseToRoot())
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600AE99 RID: 44697 RVA: 0x002E8109 File Offset: 0x002E6309
	private void OnHelpBtnClick()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(this.HelpId);
	}

	// Token: 0x0600AE9A RID: 44698 RVA: 0x002E811C File Offset: 0x002E631C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.JumpToCalabashCollect, new Action<int>(this.JumpToCalabashCollect));
		Singleton<EventSystem>.Instance.Add(EEventName.JumpToPhantomBattleFettersTabView, new Action<int>(this.JumpPhantomBattleFettersTabView));
		Singleton<EventSystem>.Instance.Add(EEventName.CalabashEnterInternalView, new Action(this.OnEnterInternalView));
		Singleton<EventSystem>.Instance.Add(EEventName.CalabashQuitInternalView, new Action(this.OnQuitInternalView));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshCalabashTabShowState, new Action<bool>(this.OnRefreshTabShowState));
	}

	// Token: 0x0600AE9B RID: 44699 RVA: 0x002E81B8 File Offset: 0x002E63B8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.JumpToCalabashCollect, new Action<int>(this.JumpToCalabashCollect));
		Singleton<EventSystem>.Instance.Remove(EEventName.JumpToPhantomBattleFettersTabView, new Action<int>(this.JumpPhantomBattleFettersTabView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CalabashEnterInternalView, new Action(this.OnEnterInternalView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CalabashQuitInternalView, new Action(this.OnQuitInternalView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshCalabashTabShowState, new Action<bool>(this.OnRefreshTabShowState));
	}

	// Token: 0x0600AE9C RID: 44700 RVA: 0x002E8254 File Offset: 0x002E6454
	private void JumpToCalabashCollect(int monsterId)
	{
		int index = -1;
		for (int i = 0; i < this.TabDataList.Length; i++)
		{
			if (this.TabDataList[i].ChildViewName == EUiTabViewName.CalabashCollectTabView.ToString())
			{
				index = i;
				break;
			}
		}
		CalabashCollectViewData param = new CalabashCollectViewData
		{
			MonsterId = monsterId
		};
		if (this.CalabashCollectParams == null)
		{
			this.CalabashCollectParams = new CalabashRootViewData
			{
				TabViewName = EUiTabViewName.CalabashCollectTabView,
				Param = param
			};
		}
		else
		{
			this.CalabashCollectParams.TabViewName = EUiTabViewName.CalabashCollectTabView;
			this.CalabashCollectParams.Param = param;
		}
		this.TabComponent.SelectToggleByIndex(index, false);
	}

	// Token: 0x0600AE9D RID: 44701 RVA: 0x002E8300 File Offset: 0x002E6500
	private void JumpPhantomBattleFettersTabView(int id)
	{
		int index = -1;
		for (int i = 0; i < this.TabDataList.Length; i++)
		{
			if (this.TabDataList[i].ChildViewName == EUiTabViewName.PhantomBattleFettersTabView.ToString())
			{
				index = i;
				break;
			}
		}
		if (this.CalabashCollectParams == null)
		{
			this.CalabashCollectParams = new CalabashRootViewData
			{
				TabViewName = EUiTabViewName.PhantomBattleFettersTabView,
				Param = id
			};
		}
		else
		{
			this.CalabashCollectParams.TabViewName = EUiTabViewName.PhantomBattleFettersTabView;
			this.CalabashCollectParams.Param = id;
		}
		this.TabComponent.SelectToggleByIndex(index, false);
	}

	// Token: 0x0600AE9E RID: 44702 RVA: 0x002E83A8 File Offset: 0x002E65A8
	protected override UniTask OnBeforeStartAsync()
	{
		CalabashRootView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CalabashRootView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AE9F RID: 44703 RVA: 0x002E83EC File Offset: 0x002E65EC
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionRefineSubNeedAck);
		ICalabashRootViewData calabashCollectParams = this.CalabashCollectParams;
		EUiTabViewName? euiTabViewName = (calabashCollectParams != null) ? new EUiTabViewName?(calabashCollectParams.TabViewName) : null;
		ICalabashRootViewData calabashCollectParams2 = this.CalabashCollectParams;
		ICalabashCollectViewData calabashCollectViewData = ((calabashCollectParams2 != null) ? calabashCollectParams2.Param : null) as ICalabashCollectViewData;
		if (euiTabViewName == EUiTabViewName.CalabashCollectTabView && calabashCollectViewData != null && calabashCollectViewData.OnlyShow.GetValueOrDefault())
		{
			ControllerBase<BlackScreenController>.Instance.AddBlackScreen("None", "CalabashCollectOnlyShow", "Black");
		}
	}

	// Token: 0x0600AEA0 RID: 44704 RVA: 0x002E848E File Offset: 0x002E668E
	private void InitTabDataList()
	{
		this.TabDataList = ModelBase<CalabashModel>.Instance.GetViewTabList();
	}

	// Token: 0x0600AEA1 RID: 44705 RVA: 0x002E84A0 File Offset: 0x002E66A0
	private UniTask InitTabComponent()
	{
		CalabashRootView.<InitTabComponent>d__23 <InitTabComponent>d__;
		<InitTabComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTabComponent>d__.<>4__this = this;
		<InitTabComponent>d__.<>1__state = -1;
		<InitTabComponent>d__.<>t__builder.Start<CalabashRootView.<InitTabComponent>d__23>(ref <InitTabComponent>d__);
		return <InitTabComponent>d__.<>t__builder.Task;
	}

	// Token: 0x0600AEA2 RID: 44706 RVA: 0x002E84E3 File Offset: 0x002E66E3
	private CalabashTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CalabashTabItem();
	}

	// Token: 0x0600AEA3 RID: 44707 RVA: 0x002E84EC File Offset: 0x002E66EC
	private void ToggleCallBack(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		EUiTabViewName euiTabViewName = (EUiTabViewName)uiDynamicTab.ChildViewName;
		CalabashTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		EUiTabViewName left = euiTabViewName;
		ICalabashRootViewData calabashCollectParams = this.CalabashCollectParams;
		object obj;
		if (!(left == ((calabashCollectParams != null) ? new EUiTabViewName?(calabashCollectParams.TabViewName) : null)))
		{
			obj = null;
		}
		else
		{
			ICalabashRootViewData calabashCollectParams2 = this.CalabashCollectParams;
			obj = ((calabashCollectParams2 != null) ? calabashCollectParams2.Param : null);
		}
		object extraParams = obj;
		this.TabViewComponent.ToggleCallBackNew(uiDynamicTab, euiTabViewName, tabItemByIndex, extraParams, null);
		if (this.CalabashCollectParams != null)
		{
			this.CalabashCollectParams.Param = null;
		}
		int num;
		this.viewHelpId.TryGetValue(euiTabViewName.ToString(), out num);
		this.HelpId = ((num > 0) ? num : -1);
		this.TabComponent.SetHelpButtonShowState(this.HelpId > 0);
		this.UpdateDetailItem(euiTabViewName);
		this.ShowCostItemCaption(Array.Empty<int>());
	}

	// Token: 0x0600AEA4 RID: 44708 RVA: 0x002E85FC File Offset: 0x002E67FC
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x0600AEA5 RID: 44709 RVA: 0x002E8634 File Offset: 0x002E6834
	private void InitTabViewComponent()
	{
		this.TabViewComponent = new TabViewComponent<object>(base.GetItem(1), EKeyMode.Default);
	}

	// Token: 0x0600AEA6 RID: 44710 RVA: 0x002E864C File Offset: 0x002E684C
	private void UpdateDetailItem(EUiTabViewName viewName)
	{
		bool flag = viewName == EUiTabViewName.CalabashCollectTabView || viewName == EUiTabViewName.PhantomManageConfigNewView;
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (!flag)
		{
			return;
		}
		bool uiactive = viewName == EUiTabViewName.CalabashCollectTabView;
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		if (extendToggle != null)
		{
			UUIItem uuiitem = extendToggle.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(uiactive);
			}
		}
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetUIActive(uiactive);
		}
		UUIButtonComponent button = base.GetButton(4);
		if (button == null)
		{
			return;
		}
		UUIItem uuiitem2 = button.RootUIComp.Get();
		if (uuiitem2 == null)
		{
			return;
		}
		uuiitem2.SetUIActive(viewName == EUiTabViewName.PhantomManageConfigNewView);
	}

	// Token: 0x0600AEA7 RID: 44711 RVA: 0x002E8700 File Offset: 0x002E6900
	private void InitSelectedIndex()
	{
		ICalabashRootViewData calabashCollectParams = this.CalabashCollectParams;
		EUiTabViewName? euiTabViewName = (calabashCollectParams != null) ? new EUiTabViewName?(calabashCollectParams.TabViewName) : null;
		int index = 0;
		if (euiTabViewName == null)
		{
			int selectedIndex = this.TabComponent.GetSelectedIndex();
			index = ((selectedIndex != -1) ? selectedIndex : 0);
		}
		else
		{
			for (int i = 0; i < this.TabDataList.Length; i++)
			{
				if (this.TabDataList[i].ChildViewName == euiTabViewName.ToString())
				{
					index = i;
					break;
				}
			}
		}
		this.TabComponent.SelectToggleByIndex(index, false);
	}

	// Token: 0x0600AEA8 RID: 44712 RVA: 0x002E879E File Offset: 0x002E699E
	private void BindRedDot()
	{
		this.BindRedDotByName(EUiTabViewName.CalabashLevelUpTabView, ERedDotName.CalabashTab, true);
		this.BindRedDotByName(EUiTabViewName.VisionRecoveryTabView, ERedDotName.VisionRecovery, true);
		this.BindRedDotByName(EUiTabViewName.VisionRefineTabView, ERedDotName.VisionRefine, true);
	}

	// Token: 0x0600AEA9 RID: 44713 RVA: 0x002E87CC File Offset: 0x002E69CC
	private void BindRedDotByName(EUiTabViewName viewName, ERedDotName redDotName, bool bIsBind)
	{
		int num = -1;
		for (int i = 0; i < this.TabDataList.Length; i++)
		{
			if (this.TabDataList[i].ChildViewName == viewName.ToString())
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			CalabashTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(num);
			if (bIsBind)
			{
				if (tabItemByIndex != null)
				{
					tabItemByIndex.BindRedDot(redDotName, new int?(0));
					return;
				}
			}
			else if (tabItemByIndex != null)
			{
				tabItemByIndex.UnBindRedDot();
			}
		}
	}

	// Token: 0x0600AEAA RID: 44714 RVA: 0x002E8845 File Offset: 0x002E6A45
	private void OnSimplyToggleChange(EToggleState toggleState)
	{
		ModelBase<CalabashModel>.Instance.SaveIfSimpleState(toggleState != EToggleState.ETT_Checked);
	}

	// Token: 0x0600AEAB RID: 44715 RVA: 0x002E8858 File Offset: 0x002E6A58
	private void OnClickedShared()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomManagerConfigSharePopItem, null, null);
	}

	// Token: 0x0600AEAC RID: 44716 RVA: 0x002E886B File Offset: 0x002E6A6B
	protected override void OnBeforeShow()
	{
		if (this.IsViewFirstShow)
		{
			this.InitSelectedIndex();
		}
		else
		{
			this.TabViewComponent.SetCurrentTabViewState(true);
		}
		this.IsViewFirstShow = false;
		this.BindRedDot();
	}

	// Token: 0x0600AEAD RID: 44717 RVA: 0x002E8896 File Offset: 0x002E6A96
	protected override void OnBeforeHide()
	{
		this.UnBindRedDot();
		this.TabViewComponent.SetCurrentTabViewState(false);
	}

	// Token: 0x0600AEAE RID: 44718 RVA: 0x002E88AC File Offset: 0x002E6AAC
	protected override void OnAfterHide()
	{
		VisionRecoveryTabView visionRecoveryTabView = this.TabViewComponent.GetTabViewByTabKey(EUiTabViewName.VisionRecoveryTabView, null) as VisionRecoveryTabView;
		if (visionRecoveryTabView == null)
		{
			return;
		}
		visionRecoveryTabView.RemoveAllVisionItemOutside();
	}

	// Token: 0x0600AEAF RID: 44719 RVA: 0x002E88E2 File Offset: 0x002E6AE2
	private void UnBindRedDot()
	{
		this.BindRedDotByName(EUiTabViewName.CalabashLevelUpTabView, ERedDotName.CalabashTab, false);
		this.BindRedDotByName(EUiTabViewName.VisionRecoveryTabView, ERedDotName.VisionRecovery, false);
		this.BindRedDotByName(EUiTabViewName.VisionRefineTabView, ERedDotName.VisionRefine, false);
	}

	// Token: 0x0600AEB0 RID: 44720 RVA: 0x002E890E File Offset: 0x002E6B0E
	protected override void OnBeforeDestroy()
	{
		this.TabComponent.Destroy(null);
		this.TabViewComponent.DestroyTabViewComponent();
	}

	// Token: 0x0600AEB1 RID: 44721 RVA: 0x002E8928 File Offset: 0x002E6B28
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams[0] == "Tab")
		{
			UiTabViewBase currentTabView = this.TabViewComponent.GetCurrentTabView();
			if (currentTabView == null)
			{
				return null;
			}
			return currentTabView.GetGuideUiItemAndUiItemForShowEx(RuntimeHelpers.GetSubArray<string>(configParams, Range.StartAt(1)));
		}
		else
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
			CalabashTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			UUIItem uuiitem = (tabItemByIndex != null) ? tabItemByIndex.GetRootItem() : null;
			if (uuiitem != null)
			{
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
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
	}

	// Token: 0x0600AEB2 RID: 44722 RVA: 0x002E89FC File Offset: 0x002E6BFC
	private bool CheckTabViewCloseToRoot()
	{
		if (this.TabViewComponent != null && this.TabViewComponent.GetCurrentTabViewName(null) == EUiTabViewName.VisionRefineTabView)
		{
			VisionRefineTabView visionRefineTabView = this.TabViewComponent.GetCurrentTabView() as VisionRefineTabView;
			return visionRefineTabView != null && visionRefineTabView.OnClickCloseRoot();
		}
		return false;
	}

	// Token: 0x0600AEB3 RID: 44723 RVA: 0x002E8A64 File Offset: 0x002E6C64
	private void OnEnterInternalView()
	{
		TabComponentWithCaptionItem<CalabashTabItem> tabComponent = this.TabComponent;
		if (tabComponent == null)
		{
			return;
		}
		tabComponent.HideItem();
	}

	// Token: 0x0600AEB4 RID: 44724 RVA: 0x002E8A76 File Offset: 0x002E6C76
	private void OnQuitInternalView()
	{
		TabComponentWithCaptionItem<CalabashTabItem> tabComponent = this.TabComponent;
		if (tabComponent == null)
		{
			return;
		}
		tabComponent.ShowItem();
	}

	// Token: 0x0600AEB5 RID: 44725 RVA: 0x002E8A88 File Offset: 0x002E6C88
	private void OnRefreshTabShowState(bool isShow)
	{
		if (isShow)
		{
			this.UiViewSequence.PlaySequence("SwitchA", false, null);
			return;
		}
		this.UiViewSequence.PlaySequence("SwitchB", false, null);
	}

	// Token: 0x0600AEB6 RID: 44726 RVA: 0x002E8AD0 File Offset: 0x002E6CD0
	public bool GetIsVisionRecoveryTabViewOpen()
	{
		VisionRecoveryTabView visionRecoveryTabView = this.TabViewComponent.GetTabViewByTabKey(EUiTabViewName.VisionRecoveryTabView, null) as VisionRecoveryTabView;
		return visionRecoveryTabView != null && visionRecoveryTabView.GetRootItem().IsUIActiveSelf();
	}

	// Token: 0x0600AEB7 RID: 44727 RVA: 0x002E8B0C File Offset: 0x002E6D0C
	public void ShowCostItemCaption(int[] itemIdList)
	{
		TabComponentWithCaptionItem<CalabashTabItem> tabComponent = this.TabComponent;
		if (tabComponent == null)
		{
			return;
		}
		tabComponent.SetCurrencyItemList(new List<int>(itemIdList));
	}

	// Token: 0x040052E2 RID: 21218
	private const int CALABASH_LEVEL_UP_HELP_ID = 48;

	// Token: 0x040052E3 RID: 21219
	private const int CALABASH_COLLECT_HELP_ID = 47;

	// Token: 0x040052E4 RID: 21220
	private const int VISION_RECOVERY_HELP_ID = 70;

	// Token: 0x040052E5 RID: 21221
	private const int VISION_REFINE_HELP_ID = 512;

	// Token: 0x040052E6 RID: 21222
	private Dictionary<string, int> viewHelpId = new Dictionary<string, int>
	{
		{
			EUiTabViewName.CalabashLevelUpTabView.ToString(),
			48
		},
		{
			EUiTabViewName.CalabashCollectTabView.ToString(),
			47
		},
		{
			EUiTabViewName.VisionRecoveryTabView.ToString(),
			70
		},
		{
			EUiTabViewName.PhantomManageConfigNewView.ToString(),
			356
		},
		{
			EUiTabViewName.VisionRefineTabView.ToString(),
			512
		}
	};

	// Token: 0x040052E7 RID: 21223
	[Nullable(2)]
	private UiDynamicTab[] TabDataList;

	// Token: 0x040052E8 RID: 21224
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<CalabashTabItem> TabComponent;

	// Token: 0x040052E9 RID: 21225
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabViewComponent<object> TabViewComponent;

	// Token: 0x040052EA RID: 21226
	[Nullable(2)]
	private ICalabashRootViewData CalabashCollectParams;

	// Token: 0x040052EB RID: 21227
	private bool IsViewFirstShow;

	// Token: 0x040052EC RID: 21228
	private int HelpId;

	// Token: 0x02007B73 RID: 31603
	[NullableContext(0)]
	private enum ECompDefine
	{
		// Token: 0x0402A323 RID: 172835
		TabItem,
		// Token: 0x0402A324 RID: 172836
		TabViewMountItem,
		// Token: 0x0402A325 RID: 172837
		DetailToggle,
		// Token: 0x0402A326 RID: 172838
		DetailItem,
		// Token: 0x0402A327 RID: 172839
		BtnShared,
		// Token: 0x0402A328 RID: 172840
		DetailToggleTxt
	}
}
