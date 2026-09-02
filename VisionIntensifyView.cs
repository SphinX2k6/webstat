using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002523 RID: 9507
[NullableContext(1)]
[Nullable(0)]
public class VisionIntensifyView : UiViewBase
{
	// Token: 0x060127A9 RID: 75689 RVA: 0x005165BB File Offset: 0x005147BB
	public VisionIntensifyView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060127AA RID: 75690 RVA: 0x005165DC File Offset: 0x005147DC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x060127AB RID: 75691 RVA: 0x00516638 File Offset: 0x00514838
	protected override void OnStart()
	{
		CommonTabComponentData<CommonTabItem> data = new CommonTabComponentData<CommonTabItem>(new Func<UUIItem, int?, CommonTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
		this.TabComponent = new TabComponentWithCaptionItem<CommonTabItem>(base.GetItem(0), data, new Action(this.CloseClick), false);
		this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
		this.TabComponent.SetHelpButtonShowState(true);
		this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
		base.GetItem(2).SetUIActive(false);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnVisionIntensifyViewShow, true);
	}

	// Token: 0x060127AC RID: 75692 RVA: 0x005166E4 File Offset: 0x005148E4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.RefreshVisionIntensifyViewBackBtnState, new Action<bool>(this.OnRefreshVisionIntensifyViewBackBtnState));
		Singleton<EventSystem>.Instance.Add(EEventName.PhantomLevelUp, new Action(this.OnVisionLevelUp));
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickVisionIntensifyItemJump, new Action(this.OnClickVisionIntensifyItemJump));
	}

	// Token: 0x060127AD RID: 75693 RVA: 0x00516748 File Offset: 0x00514948
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshVisionIntensifyViewBackBtnState, new Action<bool>(this.OnRefreshVisionIntensifyViewBackBtnState));
		Singleton<EventSystem>.Instance.Remove(EEventName.PhantomLevelUp, new Action(this.OnVisionLevelUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickVisionIntensifyItemJump, new Action(this.OnClickVisionIntensifyItemJump));
	}

	// Token: 0x060127AE RID: 75694 RVA: 0x005167A9 File Offset: 0x005149A9
	private void OnRefreshVisionIntensifyViewBackBtnState(bool state)
	{
		this.TabComponent.SetCloseBtnShowState(state);
	}

	// Token: 0x060127AF RID: 75695 RVA: 0x005167B7 File Offset: 0x005149B7
	private void OnClickVisionIntensifyItemJump()
	{
		this.TabComponent.SelectToggleByIndex(1, false);
	}

	// Token: 0x060127B0 RID: 75696 RVA: 0x005167C8 File Offset: 0x005149C8
	private void OnVisionLevelUp()
	{
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.CurrentUniqueId);
		if (phantomBattleData == null)
		{
			return;
		}
		if (phantomBattleData.GetQuality() <= 2)
		{
			return;
		}
		this.RefreshTabUnlockState();
	}

	// Token: 0x060127B1 RID: 75697 RVA: 0x005167FC File Offset: 0x005149FC
	protected bool CanToggleChange(int index, bool? _)
	{
		UiDynamicTab tabData = this.TabDataList[index];
		if (VisionDefine.tabViewWithLock != null && VisionDefine.tabViewWithLock.Contains(tabData.ChildViewName))
		{
			ValueTuple<bool, string> valueTuple = this.CheckTabIfUnlock(tabData);
			if (!valueTuple.Item1 && valueTuple.Item2 != null)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(valueTuple.Item2, Array.Empty<object>());
			}
			return valueTuple.Item1;
		}
		return true;
	}

	// Token: 0x060127B2 RID: 75698 RVA: 0x00516865 File Offset: 0x00514A65
	private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new VisionTabItem();
	}

	// Token: 0x060127B3 RID: 75699 RVA: 0x0051686C File Offset: 0x00514A6C
	[return: TupleElementNames(new string[]
	{
		"IsUnlocked",
		"Message"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private ValueTuple<bool, string> CheckTabIfUnlock(UiDynamicTab tabData)
	{
		if (tabData.ChildViewName == EUiTabViewName.VisionIdentifyView)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.CurrentUniqueId);
			if (phantomBattleData == null)
			{
				return new ValueTuple<bool, string>(false, ETextKey.VisionIdentifyLock.ToString());
			}
			int subPropUnlockLevel = phantomBattleData.GetSubPropUnlockLevel(0);
			bool flag = phantomBattleData.GetPhantomLevel() >= subPropUnlockLevel;
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.VisionIntensifyTabOpen);
			}
			return new ValueTuple<bool, string>(flag, flag ? null : ETextKey.VisionIdentifyLock.ToString());
		}
		else
		{
			if (!(tabData.ChildViewName == EUiTabViewName.VisionRefineTabView))
			{
				return new ValueTuple<bool, string>(true, null);
			}
			if (!ModelBase<FunctionModel>.Instance.IsOpen(tabData.FunctionId))
			{
				return new ValueTuple<bool, string>(false, ETextKey.VisionRefineNotOpen.ToString());
			}
			int num = 1;
			return new ValueTuple<bool, string>(num != 0, (num != 0) ? null : ETextKey.VisionRefineConditionUnfit.ToString());
		}
	}

	// Token: 0x060127B4 RID: 75700 RVA: 0x00516968 File Offset: 0x00514B68
	protected override void OnBeforePlayCloseSequence()
	{
		UiTabViewBase currentTabView = this.TabViewComponent.GetCurrentTabView();
		if (currentTabView != null)
		{
			new UiSequencePlayer(currentTabView.GetRootItem()).PlaySequence("Close", false, null);
		}
	}

	// Token: 0x060127B5 RID: 75701 RVA: 0x005169A4 File Offset: 0x00514BA4
	private void ToggleCallBack(int index)
	{
		UiDynamicTab data = this.TabDataList[index];
		EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
		CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		UiTabViewBase currentTabView = this.TabViewComponent.GetCurrentTabView();
		if (currentTabView != null)
		{
			currentTabView.HideUiTabView(false);
		}
		this.SetCurrencyItemList(euiTabViewName);
		object extraParams = this.CreateExtraParams(euiTabViewName);
		this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, extraParams, null);
		this.TabComponent.SetHelpButtonCallBack(new Action(this.OnClickHelpButton));
		this.HandleVisionSkeletal(euiTabViewName);
		this.CurSelectTabIndex = index;
	}

	// Token: 0x060127B6 RID: 75702 RVA: 0x00516A3D File Offset: 0x00514C3D
	private void HandleVisionSkeletal(EUiTabViewName viewName)
	{
		if (viewName == EUiTabViewName.VisionRefineTabView)
		{
			this.DestroyVisionSkeletal();
			return;
		}
		this.ShowVisionSkeletal();
	}

	// Token: 0x060127B7 RID: 75703 RVA: 0x00516A5C File Offset: 0x00514C5C
	private void ShowVisionSkeletal()
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.CurrentUniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		if (!Singleton<UiSceneManager>.Instance.HasVisionSkeletalHandle())
		{
			Singleton<UiSceneManager>.Instance.InitVisionSkeletalHandle();
		}
		SkeletalObserverHandle visionSkeletalHandle = Singleton<UiSceneManager>.Instance.GetVisionSkeletalHandle();
		if (visionSkeletalHandle == null)
		{
			return;
		}
		ControllerBase<PhantomBattleController>.Instance.SetMeshShow(phantomItemDataByUniqueId.GetConfigId(true), null, visionSkeletalHandle, true);
	}

	// Token: 0x060127B8 RID: 75704 RVA: 0x00516AB7 File Offset: 0x00514CB7
	private void DestroyVisionSkeletal()
	{
		Singleton<UiSceneManager>.Instance.DestroyVisionSkeletalHandle();
	}

	// Token: 0x060127B9 RID: 75705 RVA: 0x00516AC4 File Offset: 0x00514CC4
	[NullableContext(2)]
	public object CreateExtraParams(EUiTabViewName viewName)
	{
		object result;
		if (viewName == EUiTabViewName.VisionRefineTabView)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.CurrentUniqueId);
			EVisionRefineRefineType value = EVisionRefineRefineType.Main;
			if (phantomBattleData == null || phantomBattleData.GetVisionIfCanRefine(EVisionRefineRefineType.Sub))
			{
				value = EVisionRefineRefineType.Sub;
			}
			VisionAttrRecommendInfo roleCostAttrRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleCostAttrRecommendInfo(this.CurrentRoleId, (phantomBattleData != null) ? phantomBattleData.GetCost() : 0);
			List<AttrRecommendInfo> recommendRefineSubList = (roleCostAttrRecommendInfo != null) ? roleCostAttrRecommendInfo.GetSubAttrRecommendInfo() : null;
			result = new VisionRefineTabViewParam
			{
				ViewState = ERefineViewState.Attribute,
				RefineType = new EVisionRefineRefineType?(value),
				UniqueId = new int?(this.CurrentUniqueId),
				ActiveCaptionItem = new bool?(false),
				SlotInteractive = new bool?(false),
				ResultShowTips = new bool?(false),
				IsSingleMode = new bool?(true),
				CurrencyChangeCallback = delegate(int[] itemIdList)
				{
					List<int> currencyItemList = new List<int>(itemIdList);
					this.TabComponent.SetCurrencyItemList(currencyItemList);
				},
				RecommendRefineSubList = recommendRefineSubList
			};
		}
		else
		{
			result = this.CurrentUniqueId;
		}
		return result;
	}

	// Token: 0x060127BA RID: 75706 RVA: 0x00516BAF File Offset: 0x00514DAF
	public void SetCurrencyItemList(EUiTabViewName viewName)
	{
		this.CurrencyItemList.Clear();
		if (viewName != EUiTabViewName.VisionRefineTabView)
		{
			this.CurrencyItemList.Add(2);
			this.TabComponent.SetCurrencyItemList(this.CurrencyItemList);
		}
	}

	// Token: 0x060127BB RID: 75707 RVA: 0x00516BE7 File Offset: 0x00514DE7
	private void OnClickHelpButton()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(32);
	}

	// Token: 0x060127BC RID: 75708 RVA: 0x00516BF8 File Offset: 0x00514DF8
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x060127BD RID: 75709 RVA: 0x00516C30 File Offset: 0x00514E30
	protected void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x060127BE RID: 75710 RVA: 0x00516C3C File Offset: 0x00514E3C
	protected override void OnHandleLoadScene()
	{
		EUiTabViewName? currentTabViewName = this.TabViewComponent.GetCurrentTabViewName(null);
		if (currentTabViewName == null)
		{
			return;
		}
		this.HandleVisionSkeletal(currentTabViewName.Value);
	}

	// Token: 0x060127BF RID: 75711 RVA: 0x00516C75 File Offset: 0x00514E75
	protected override void OnHandleReleaseScene()
	{
		this.DestroyVisionSkeletal();
	}

	// Token: 0x060127C0 RID: 75712 RVA: 0x00516C80 File Offset: 0x00514E80
	protected override void OnBeforeShow()
	{
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		if (instance != null)
		{
			instance.AddNeedCameraFocusMethodDisableViewCount();
		}
		List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(this.ViewInfo.Name);
		foreach (UiDynamicTab item in viewTabList)
		{
			this.TabDataList.Add(item);
		}
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.CurrentUniqueId);
		if (phantomBattleData == null)
		{
			return;
		}
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(10001004);
		int num;
		if (phantomBattleData.GetQuality() <= 2 || !flag)
		{
			num = 1;
		}
		else
		{
			num = viewTabList.Count;
		}
		TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
		Dictionary<int, CommonTabItem> dictionary = (tabComponent != null) ? tabComponent.GetTabItemMap() : null;
		if (dictionary != null && num != dictionary.Count)
		{
			this.CurSelectTabIndex = 0;
		}
		TabComponentWithCaptionItem<CommonTabItem> tabComponent2 = this.TabComponent;
		if (tabComponent2 == null)
		{
			return;
		}
		tabComponent2.RefreshTabItemByLength(num, new Action(this.RefreshTabCallBack));
	}

	// Token: 0x060127C1 RID: 75713 RVA: 0x00516D88 File Offset: 0x00514F88
	private void RefreshTabUnlockState()
	{
		TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
		Dictionary<int, CommonTabItem> dictionary = (tabComponent != null) ? tabComponent.GetTabItemMap() : null;
		if (dictionary == null)
		{
			return;
		}
		foreach (KeyValuePair<int, CommonTabItem> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			CommonTabItem value = keyValuePair.Value;
			UiDynamicTab tabData = this.TabDataList[key];
			if (VisionDefine.tabViewWithLock != null && VisionDefine.tabViewWithLock.Contains(tabData.ChildViewName))
			{
				ValueTuple<bool, string> state = this.CheckTabIfUnlock(tabData);
				if (state.Item1)
				{
					value.SetToggleStateForce(EToggleState.ETT_UnChecked, false);
				}
				else
				{
					value.SetToggleStateForce(EToggleState.ETT_UnDetermined, false);
					value.SetCanClickWhenDisable(true);
					value.SetOnUndeterminedClick(delegate
					{
						if (state.Item2 != null)
						{
							ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(state.Item2, Array.Empty<object>());
						}
					});
				}
			}
		}
	}

	// Token: 0x060127C2 RID: 75714 RVA: 0x00516E78 File Offset: 0x00515078
	private void RefreshTabCallBack()
	{
		this.RefreshTabUnlockState();
		this.TabComponent.SelectToggleByIndex(this.CurSelectTabIndex, true);
		this.TabViewComponent.SetCurrentTabViewState(true);
		this.BindRedDot();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshVisionIdentifyRedPoint, this.CurrentUniqueId);
	}

	// Token: 0x060127C3 RID: 75715 RVA: 0x00516EC8 File Offset: 0x005150C8
	private void BindRedDot()
	{
		int num = -1;
		for (int i = 0; i < this.TabDataList.Count; i++)
		{
			if (this.TabDataList[i].ChildViewName == EUiTabViewName.VisionIdentifyView.ToString())
			{
				num = i;
				break;
			}
		}
		if (num > 0)
		{
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(num);
			if (tabItemByIndex != null)
			{
				tabItemByIndex.BindRedDot(ERedDotName.VisionIdentifyTab, new int?(this.CurrentUniqueId));
			}
		}
	}

	// Token: 0x060127C4 RID: 75716 RVA: 0x00516F44 File Offset: 0x00515144
	private void UnBindRedDot()
	{
		int num = -1;
		for (int i = 0; i < this.TabDataList.Count; i++)
		{
			if (this.TabDataList[i].ChildViewName == EUiTabViewName.VisionIdentifyView.ToString())
			{
				num = i;
				break;
			}
		}
		if (num > 0)
		{
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(num);
			if (tabItemByIndex != null)
			{
				tabItemByIndex.UnBindRedDot();
			}
		}
	}

	// Token: 0x060127C5 RID: 75717 RVA: 0x00516FB2 File Offset: 0x005151B2
	protected override void OnBeforeHide()
	{
		this.UnBindRedDot();
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.ReduceNeedCameraFocusMethodDisableViewCount();
	}

	// Token: 0x060127C6 RID: 75718 RVA: 0x00516FCC File Offset: 0x005151CC
	protected override void OnAfterHide()
	{
		UiTabViewBase currentTabView = this.TabViewComponent.GetCurrentTabView();
		if (currentTabView != null)
		{
			currentTabView.HideUiTabView(false);
		}
	}

	// Token: 0x060127C7 RID: 75719 RVA: 0x00516FF0 File Offset: 0x005151F0
	protected override void OnBeforeCreate()
	{
		VisionIntensifyViewPassData visionIntensifyViewPassData = this.OpenParam as VisionIntensifyViewPassData;
		if (visionIntensifyViewPassData == null)
		{
			return;
		}
		this.CurrentUniqueId = visionIntensifyViewPassData.UniqueId;
		this.CurrentRoleId = visionIntensifyViewPassData.RoleId;
	}

	// Token: 0x060127C8 RID: 75720 RVA: 0x00517025 File Offset: 0x00515225
	protected override void OnBeforeDestroy()
	{
		this.TabViewComponent.DestroyTabViewComponent();
		this.TabComponent.Destroy(null);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnVisionIntensifyViewShow, false);
	}

	// Token: 0x060127C9 RID: 75721 RVA: 0x00517050 File Offset: 0x00515250
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int num = int.Parse(configParams[0]);
		int index = -1;
		for (int i = 0; i < this.TabDataList.Count; i++)
		{
			if (this.TabDataList[i].Id == num)
			{
				index = i;
				break;
			}
		}
		CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
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

	// Token: 0x060127CA RID: 75722 RVA: 0x005170F3 File Offset: 0x005152F3
	public int GetCurrentUniqueId()
	{
		return this.CurrentUniqueId;
	}

	// Token: 0x04009029 RID: 36905
	private const int VISION_INTENSIFY_HELPID = 32;

	// Token: 0x0400902A RID: 36906
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

	// Token: 0x0400902B RID: 36907
	[Nullable(2)]
	protected TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x0400902C RID: 36908
	private readonly List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x0400902D RID: 36909
	private int CurrentUniqueId;

	// Token: 0x0400902E RID: 36910
	private int CurrentRoleId;

	// Token: 0x0400902F RID: 36911
	private readonly List<int> CurrencyItemList = new List<int>();

	// Token: 0x04009030 RID: 36912
	private int CurSelectTabIndex;

	// Token: 0x02008845 RID: 34885
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E070 RID: 188528
		Item,
		// Token: 0x0402E071 RID: 188529
		MountItem,
		// Token: 0x0402E072 RID: 188530
		Bg
	}
}
