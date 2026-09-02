using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022C6 RID: 8902
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleRootView : UiViewBase
{
	// Token: 0x06010D60 RID: 68960 RVA: 0x0049B898 File Offset: 0x00499A98
	public MotorcycleRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010D61 RID: 68961 RVA: 0x0049B8AC File Offset: 0x00499AAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06010D62 RID: 68962 RVA: 0x0049B8E8 File Offset: 0x00499AE8
	protected override void OnStart()
	{
		MotorDevelopRootData motorDevelopRootData = this.OpenParam as MotorDevelopRootData;
		if (motorDevelopRootData != null)
		{
			this.CurSelectTabView = motorDevelopRootData.OpenTabView;
			if (motorDevelopRootData.TreeType != null)
			{
				ModelBase<MotorcycleDevelopModel>.Instance.UpdateSelectedTreeType(motorDevelopRootData.TreeType.Value);
			}
		}
		this.InitTabComponent();
	}

	// Token: 0x06010D63 RID: 68963 RVA: 0x0049B938 File Offset: 0x00499B38
	protected override void OnHandleLoadScene()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.CreateMotor(EUiModelUseWay.MotorInMotorView);
		Singleton<MotorcycleUiModelUtil>.Instance.LoadEquippedMotor(null);
	}

	// Token: 0x06010D64 RID: 68964 RVA: 0x0049B951 File Offset: 0x00499B51
	protected override void OnBeforeShow()
	{
		this.RefreshTabListAsync();
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(true);
	}

	// Token: 0x06010D65 RID: 68965 RVA: 0x0049B965 File Offset: 0x00499B65
	protected override void OnAfterHide()
	{
		TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
		if (tabViewComponent == null)
		{
			return;
		}
		tabViewComponent.SetCurrentTabViewState(false);
	}

	// Token: 0x06010D66 RID: 68966 RVA: 0x0049B978 File Offset: 0x00499B78
	protected override void OnHandleReleaseScene()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.DestroyMotor();
	}

	// Token: 0x06010D67 RID: 68967 RVA: 0x0049B984 File Offset: 0x00499B84
	protected override void OnBeforeDestroy()
	{
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
		ModelBase<MotorcycleDevelopModel>.Instance.UpdateSelectedTreeType(0);
	}

	// Token: 0x06010D68 RID: 68968 RVA: 0x0049B9D1 File Offset: 0x00499BD1
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<MotorDevelopRootData>(EEventName.MotorDevelopRootUpdate, new Action<MotorDevelopRootData>(this.OnRootUpdate));
		Singleton<EventSystem>.Instance.Add<EUiTabViewName>(EEventName.SelectMotorDevelopTab, new Action<EUiTabViewName>(this.OnSelectDevelopTab));
	}

	// Token: 0x06010D69 RID: 68969 RVA: 0x0049BA0B File Offset: 0x00499C0B
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopRootUpdate, new Action<MotorDevelopRootData>(this.OnRootUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.SelectMotorDevelopTab, new Action<EUiTabViewName>(this.OnSelectDevelopTab));
	}

	// Token: 0x06010D6A RID: 68970 RVA: 0x0049BA48 File Offset: 0x00499C48
	protected void InitTabComponent()
	{
		CommonTabComponentData<MotorcycleTabItem> data = new CommonTabComponentData<MotorcycleTabItem>(new Func<UUIItem, int?, MotorcycleTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
		this.TabComponent = new TabComponentWithCaptionItem<MotorcycleTabItem>(base.GetItem(1), data, new Action(this.CloseClick), false);
		this.LastClickTime = null;
		this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
		this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(0), EKeyMode.Default);
	}

	// Token: 0x06010D6B RID: 68971 RVA: 0x0049BAD8 File Offset: 0x00499CD8
	protected UniTask RefreshTabListAsync()
	{
		MotorcycleRootView.<RefreshTabListAsync>d__17 <RefreshTabListAsync>d__;
		<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabListAsync>d__.<>4__this = this;
		<RefreshTabListAsync>d__.<>1__state = -1;
		<RefreshTabListAsync>d__.<>t__builder.Start<MotorcycleRootView.<RefreshTabListAsync>d__17>(ref <RefreshTabListAsync>d__);
		return <RefreshTabListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010D6C RID: 68972 RVA: 0x0049BB1C File Offset: 0x00499D1C
	protected bool CanToggleChange(int index, bool? _)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
		return this.LastClickTime == null || Singleton<Time>.Instance.Now - this.LastClickTime.Value >= (double)intConfig.Value;
	}

	// Token: 0x06010D6D RID: 68973 RVA: 0x0049BB72 File Offset: 0x00499D72
	private MotorcycleTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleTabItem();
	}

	// Token: 0x06010D6E RID: 68974 RVA: 0x0049BB7C File Offset: 0x00499D7C
	private void ToggleCallBack(int index)
	{
		this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
		UiDynamicTab data = this.TabDataList[index];
		EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
		MotorcycleTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		this.TabViewComponent.ToggleCallBack(data, viewName, tabItemByIndex, null, null);
		this.CurSelectTabView = new EUiTabViewName?(viewName);
		if (viewName != EUiTabViewName.MotorcycleTechTreeTabView)
		{
			this.TabComponent.SetCurrencyItemList(new List<int>());
		}
		this.TabComponent.SetHelpButtonCallBack(delegate
		{
			if (viewName == EUiTabViewName.MotorcycleDiyMainView)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(424);
				return;
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(466);
		});
	}

	// Token: 0x06010D6F RID: 68975 RVA: 0x0049BC38 File Offset: 0x00499E38
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x06010D70 RID: 68976 RVA: 0x0049BC70 File Offset: 0x00499E70
	protected ERedDotName? GetRedDotName(EUiTabViewName tabViewName)
	{
		if (tabViewName == EUiTabViewName.MotorcycleLevelInfoTabView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleLevelTab);
		}
		if (tabViewName == EUiTabViewName.MotorcycleTechTreeTabView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleTechTreeTab);
		}
		if (tabViewName == EUiTabViewName.MotorcycleTaskTabView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleTaskTab);
		}
		if (tabViewName == EUiTabViewName.MotorcycleDiyMainView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleDiyTab);
		}
		return null;
	}

	// Token: 0x06010D71 RID: 68977 RVA: 0x0049BCE8 File Offset: 0x00499EE8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "Tab"))
		{
			return null;
		}
		int index = int.Parse(configParams[1]);
		TabComponentWithCaptionItem<MotorcycleTabItem> tabComponent = this.TabComponent;
		UUIItem uuiitem;
		if (tabComponent == null)
		{
			uuiitem = null;
		}
		else
		{
			MotorcycleTabItem tabItemByIndex = tabComponent.GetTabItemByIndex(index);
			uuiitem = ((tabItemByIndex != null) ? tabItemByIndex.GetRootItem() : null);
		}
		UUIItem uuiitem2 = uuiitem;
		if (uuiitem2 == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem2,
			uuiitem2
		};
	}

	// Token: 0x06010D72 RID: 68978 RVA: 0x0049BD48 File Offset: 0x00499F48
	private void OnRootUpdate(MotorDevelopRootData data)
	{
		if (data.Currency != null)
		{
			List<int> currencyItemList = new List<int>(data.Currency);
			this.TabComponent.SetCurrencyItemList(currencyItemList);
		}
		if (data.IsObserving == null)
		{
			return;
		}
		bool state = data.IsObserving.Value;
		if (!state)
		{
			this.TabComponent.SetUiActive(!state);
			base.PlaySequence("UiIn", delegate
			{
			}, true);
			return;
		}
		base.PlaySequence("UiOut", delegate
		{
			this.TabComponent.SetUiActive(!state);
		}, true);
	}

	// Token: 0x06010D73 RID: 68979 RVA: 0x0049BE04 File Offset: 0x0049A004
	private void OnSelectDevelopTab(EUiTabViewName tabViewName)
	{
		int index = this.TabDataList.FindIndex((UiDynamicTab tabData) => (EUiTabViewName)tabData.ChildViewName == tabViewName);
		this.TabComponent.SelectToggleByIndex(index, false);
	}

	// Token: 0x06010D74 RID: 68980 RVA: 0x0049BE43 File Offset: 0x0049A043
	protected void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x040084BD RID: 33981
	protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x040084BE RID: 33982
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponentWithCaptionItem<MotorcycleTabItem> TabComponent;

	// Token: 0x040084BF RID: 33983
	[Nullable(2)]
	protected TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x040084C0 RID: 33984
	private EUiTabViewName? CurSelectTabView;

	// Token: 0x040084C1 RID: 33985
	private double? LastClickTime;

	// Token: 0x02008589 RID: 34185
	[NullableContext(0)]
	private class EMotorRootComponent
	{
		// Token: 0x0402D2F1 RID: 185073
		public const int TabRootItem = 0;

		// Token: 0x0402D2F2 RID: 185074
		public const int TabComponent = 1;
	}
}
