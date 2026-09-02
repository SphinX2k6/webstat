using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022CC RID: 8908
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleTechTreeTabView : UiTabViewBase
{
	// Token: 0x170014E2 RID: 5346
	// (get) Token: 0x06010DA8 RID: 69032 RVA: 0x0049CDF9 File Offset: 0x0049AFF9
	private bool IsLockByTime
	{
		get
		{
			return ModelBase<MotorcycleDevelopModel>.Instance.IsSwitchTechTreeTimeLocked();
		}
	}

	// Token: 0x170014E3 RID: 5347
	// (get) Token: 0x06010DA9 RID: 69033 RVA: 0x0049CE05 File Offset: 0x0049B005
	private bool IsLockByPlayerStatus
	{
		get
		{
			return ModelBase<MotorcycleDevelopModel>.Instance.IsSwitchTechTreePlayerLocked();
		}
	}

	// Token: 0x06010DAA RID: 69034 RVA: 0x0049CE14 File Offset: 0x0049B014
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnBtnSwitchClick))
		};
	}

	// Token: 0x06010DAB RID: 69035 RVA: 0x0049CF44 File Offset: 0x0049B144
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleTechTreeTabView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleTechTreeTabView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010DAC RID: 69036 RVA: 0x0049CF87 File Offset: 0x0049B187
	protected override void OnBeforeShow()
	{
		this.SelectedTreeType = ModelBase<MotorcycleDevelopModel>.Instance.GetSelectedTreeType();
		if (this.SelectedTreeType == 0)
		{
			this.SelectedTreeType = ModelBase<MotorcycleDevelopModel>.Instance.GetCurTreeType();
		}
		this.OnTabUpdateAsync();
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotorLoadingIcon(false);
	}

	// Token: 0x06010DAD RID: 69037 RVA: 0x0049CFC3 File Offset: 0x0049B1C3
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnTechTreeNodeUpdate));
	}

	// Token: 0x06010DAE RID: 69038 RVA: 0x0049CFE1 File Offset: 0x0049B1E1
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTechTreeUpdate, new Action<bool>(this.OnTechTreeNodeUpdate));
	}

	// Token: 0x06010DAF RID: 69039 RVA: 0x0049CFFF File Offset: 0x0049B1FF
	protected override void OnBeforeHide()
	{
		this.CanPlayChangeTween = false;
	}

	// Token: 0x06010DB0 RID: 69040 RVA: 0x0049D008 File Offset: 0x0049B208
	private void OnTechTreeNodeUpdate(bool isUpdateNode)
	{
		this.RefreshCurrencyItemList();
		if (isUpdateNode)
		{
			this.OnNodeUpdateAsync(false);
			return;
		}
		this.OnTabItemUpdateAsync();
		this.RefreshActivateTreeTypeBtn();
	}

	// Token: 0x06010DB1 RID: 69041 RVA: 0x0049D02C File Offset: 0x0049B22C
	private UniTask OnNodeUpdateAsync(bool isPlayNodeTween)
	{
		MotorcycleTechTreeTabView.<OnNodeUpdateAsync>d__24 <OnNodeUpdateAsync>d__;
		<OnNodeUpdateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnNodeUpdateAsync>d__.<>4__this = this;
		<OnNodeUpdateAsync>d__.isPlayNodeTween = isPlayNodeTween;
		<OnNodeUpdateAsync>d__.<>1__state = -1;
		<OnNodeUpdateAsync>d__.<>t__builder.Start<MotorcycleTechTreeTabView.<OnNodeUpdateAsync>d__24>(ref <OnNodeUpdateAsync>d__);
		return <OnNodeUpdateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010DB2 RID: 69042 RVA: 0x0049D078 File Offset: 0x0049B278
	private UniTask OnTabItemUpdateAsync()
	{
		MotorcycleTechTreeTabView.<OnTabItemUpdateAsync>d__25 <OnTabItemUpdateAsync>d__;
		<OnTabItemUpdateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnTabItemUpdateAsync>d__.<>4__this = this;
		<OnTabItemUpdateAsync>d__.<>1__state = -1;
		<OnTabItemUpdateAsync>d__.<>t__builder.Start<MotorcycleTechTreeTabView.<OnTabItemUpdateAsync>d__25>(ref <OnTabItemUpdateAsync>d__);
		return <OnTabItemUpdateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010DB3 RID: 69043 RVA: 0x0049D0BC File Offset: 0x0049B2BC
	private UniTask OnTabUpdateAsync()
	{
		MotorcycleTechTreeTabView.<OnTabUpdateAsync>d__26 <OnTabUpdateAsync>d__;
		<OnTabUpdateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnTabUpdateAsync>d__.<>4__this = this;
		<OnTabUpdateAsync>d__.<>1__state = -1;
		<OnTabUpdateAsync>d__.<>t__builder.Start<MotorcycleTechTreeTabView.<OnTabUpdateAsync>d__26>(ref <OnTabUpdateAsync>d__);
		return <OnTabUpdateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010DB4 RID: 69044 RVA: 0x0049D0FF File Offset: 0x0049B2FF
	private MotorcycleTechTreeNodeListItem InitListItem()
	{
		return new MotorcycleTechTreeNodeListItem
		{
			OnAfterRefreshOneNode = new Action<MotorcycleTechTreeNodeItem>(this.OnAfterRefreshOneNode)
		};
	}

	// Token: 0x06010DB5 RID: 69045 RVA: 0x0049D118 File Offset: 0x0049B318
	private MotorcycleTreeTypeTabItem InitTreeTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleTreeTypeTabItem();
	}

	// Token: 0x06010DB6 RID: 69046 RVA: 0x0049D11F File Offset: 0x0049B31F
	private void OnAfterRefreshOneNode(MotorcycleTechTreeNodeItem nodeItem)
	{
		if (nodeItem == null)
		{
			return;
		}
		nodeItem.OnClickToggleBack = new Action<MotorTechTreeNode, UUIExtendToggle>(this.OnClickNode);
		this.ExclusiveNodeItemList.Add(nodeItem);
	}

	// Token: 0x06010DB7 RID: 69047 RVA: 0x0049D144 File Offset: 0x0049B344
	private void OnClickNode(MotorTechTreeNode treeNode, UUIExtendToggle toggle)
	{
		MotorcycleTechTreeTabView.<>c__DisplayClass30_0 CS$<>8__locals1 = new MotorcycleTechTreeTabView.<>c__DisplayClass30_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.treeNode = treeNode;
		if (this.CurrentSelectToggle != null)
		{
			this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		this.CurrentSelectNode = CS$<>8__locals1.treeNode;
		new UiAsyncTask("UpdateNodeInfoPanel", delegate()
		{
			MotorcycleTechTreeTabView.<>c__DisplayClass30_0.<<OnClickNode>b__0>d <<OnClickNode>b__0>d;
			<<OnClickNode>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnClickNode>b__0>d.<>4__this = CS$<>8__locals1;
			<<OnClickNode>b__0>d.<>1__state = -1;
			<<OnClickNode>b__0>d.<>t__builder.Start<MotorcycleTechTreeTabView.<>c__DisplayClass30_0.<<OnClickNode>b__0>d>(ref <<OnClickNode>b__0>d);
			return <<OnClickNode>b__0>d.<>t__builder.Task;
		}, null).Run();
	}

	// Token: 0x06010DB8 RID: 69048 RVA: 0x0049D1C0 File Offset: 0x0049B3C0
	private void ToggleCallBack(int index)
	{
		if (this.IsFirstInitTab)
		{
			return;
		}
		if (index == 1)
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "MotorTechTab2");
		}
		else if (index == 2)
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "MotorTechTab3");
		}
		this.RefreshUiAsync(index);
	}

	// Token: 0x06010DB9 RID: 69049 RVA: 0x0049D214 File Offset: 0x0049B414
	private UniTask RefreshUiAsync(int selectIndex)
	{
		MotorcycleTechTreeTabView.<RefreshUiAsync>d__32 <RefreshUiAsync>d__;
		<RefreshUiAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshUiAsync>d__.<>4__this = this;
		<RefreshUiAsync>d__.selectIndex = selectIndex;
		<RefreshUiAsync>d__.<>1__state = -1;
		<RefreshUiAsync>d__.<>t__builder.Start<MotorcycleTechTreeTabView.<RefreshUiAsync>d__32>(ref <RefreshUiAsync>d__);
		return <RefreshUiAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010DBA RID: 69050 RVA: 0x0049D260 File Offset: 0x0049B460
	private void RefreshActivateTreeTypeBtn()
	{
		bool flag = ModelBase<MotorcycleDevelopModel>.Instance.GetCurTreeType() == this.SelectedTreeType;
		base.GetItem(4).SetUIActive(!flag);
		base.GetItem(6).SetUIActive(flag);
	}

	// Token: 0x06010DBB RID: 69051 RVA: 0x0049D2A0 File Offset: 0x0049B4A0
	private void RefreshCurrencyItemList()
	{
		if (ModelBase<MotorcycleDevelopModel>.Instance.IsAllNodeMaxLevel(this.SelectedTreeType))
		{
			MotorDevelopRootData p = new MotorDevelopRootData
			{
				Currency = Array.Empty<int>()
			};
			Singleton<EventSystem>.Instance.Emit<MotorDevelopRootData>(EEventName.MotorDevelopRootUpdate, p);
			return;
		}
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(this.SelectedTreeType);
		if (motorTechTreeConfig != null)
		{
			MotorDevelopRootData p2 = new MotorDevelopRootData
			{
				Currency = new int[]
				{
					motorTechTreeConfig.Value.TpItemId
				}
			};
			Singleton<EventSystem>.Instance.Emit<MotorDevelopRootData>(EEventName.MotorDevelopRootUpdate, p2);
		}
	}

	// Token: 0x06010DBC RID: 69052 RVA: 0x0049D334 File Offset: 0x0049B534
	private UniTask RefreshCommonNodeList()
	{
		MotorcycleTechTreeTabView.<RefreshCommonNodeList>d__35 <RefreshCommonNodeList>d__;
		<RefreshCommonNodeList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCommonNodeList>d__.<>4__this = this;
		<RefreshCommonNodeList>d__.<>1__state = -1;
		<RefreshCommonNodeList>d__.<>t__builder.Start<MotorcycleTechTreeTabView.<RefreshCommonNodeList>d__35>(ref <RefreshCommonNodeList>d__);
		return <RefreshCommonNodeList>d__.<>t__builder.Task;
	}

	// Token: 0x06010DBD RID: 69053 RVA: 0x0049D378 File Offset: 0x0049B578
	private UniTask RefreshAllNodes()
	{
		MotorcycleTechTreeTabView.<RefreshAllNodes>d__36 <RefreshAllNodes>d__;
		<RefreshAllNodes>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAllNodes>d__.<>4__this = this;
		<RefreshAllNodes>d__.<>1__state = -1;
		<RefreshAllNodes>d__.<>t__builder.Start<MotorcycleTechTreeTabView.<RefreshAllNodes>d__36>(ref <RefreshAllNodes>d__);
		return <RefreshAllNodes>d__.<>t__builder.Task;
	}

	// Token: 0x06010DBE RID: 69054 RVA: 0x0049D3BC File Offset: 0x0049B5BC
	private void OnBtnSwitchClick()
	{
		if (this.IsLockByTime)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorBike_TechTree_ChangeFail_Time", Array.Empty<object>());
			return;
		}
		if (this.IsLockByPlayerStatus)
		{
			return;
		}
		ControllerBase<MotorcycleDevelopController>.Instance.RequestMotorTechTreeSwitch(this.SelectedTreeType, delegate
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("SwitchMotorTechTreeCD");
			if (intConfig != null)
			{
				ModelBase<MotorcycleDevelopModel>.Instance.StartSwitchTechTreeLockTimer(intConfig.Value);
			}
		});
	}

	// Token: 0x06010DBF RID: 69055 RVA: 0x0049D420 File Offset: 0x0049B620
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		string a = configParams[0];
		if (a == "ComNode")
		{
			int index = int.Parse(configParams[1]);
			MotorcycleTechTreeComStyleItem comStyleItem = this.ComStyleItem;
			MotorcycleTechTreeComNodeItem motorcycleTechTreeComNodeItem = (comStyleItem != null) ? comStyleItem.GetGuideNodeItem(index) : null;
			if (motorcycleTechTreeComNodeItem != null)
			{
				UUIItem rootItem = motorcycleTechTreeComNodeItem.GetRootItem();
				if (rootItem == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					rootItem,
					rootItem
				};
			}
		}
		if (a == "ComNode2")
		{
			int index2 = int.Parse(configParams[1]);
			MotorcycleTechTreeComStyleItem2 comStyleDoubleItem = this.ComStyleDoubleItem;
			MotorcycleTechTreeComNodeItem motorcycleTechTreeComNodeItem2 = (comStyleDoubleItem != null) ? comStyleDoubleItem.GetGuideNodeItem(index2) : null;
			if (motorcycleTechTreeComNodeItem2 != null)
			{
				UUIItem rootItem2 = motorcycleTechTreeComNodeItem2.GetRootItem();
				if (rootItem2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					rootItem2,
					rootItem2
				};
			}
		}
		if (!(a == "moto_skill_tab"))
		{
			return null;
		}
		int index3 = int.Parse(configParams[1]);
		TabComponent<MotorcycleTreeTypeTabItem> tabComponent = this.TabComponent;
		MotorcycleTreeTypeTabItem motorcycleTreeTypeTabItem = (tabComponent != null) ? tabComponent.GetTabItemByIndex(index3) : null;
		UUIItem uuiitem = (motorcycleTreeTypeTabItem != null) ? motorcycleTreeTypeTabItem.GetRootItem() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x040084D6 RID: 34006
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<MotorcycleTreeTypeTabItem> TabComponent;

	// Token: 0x040084D7 RID: 34007
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleTechTreeNodeListItem, IMotorTechNodeListData> NodeLayout;

	// Token: 0x040084D8 RID: 34008
	[Nullable(2)]
	private MotorcycleTechTreeComStyleItem ComStyleItem;

	// Token: 0x040084D9 RID: 34009
	[Nullable(2)]
	private MotorcycleTechTreeComStyleItem2 ComStyleDoubleItem;

	// Token: 0x040084DA RID: 34010
	[Nullable(2)]
	private MotorcycleTechTreeFirstNodeItem FirstNodeItem;

	// Token: 0x040084DB RID: 34011
	private List<MotorcycleTechTreeNodeItem> ExclusiveNodeItemList = new List<MotorcycleTechTreeNodeItem>();

	// Token: 0x040084DC RID: 34012
	[Nullable(2)]
	private MotorcycleTechTreeInfoPanel InfoPanel;

	// Token: 0x040084DD RID: 34013
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x040084DE RID: 34014
	[Nullable(2)]
	private MotorTechTreeNode CurrentSelectNode;

	// Token: 0x040084DF RID: 34015
	private int SelectedTreeType;

	// Token: 0x040084E0 RID: 34016
	private bool IsFirstInitTab = true;

	// Token: 0x040084E1 RID: 34017
	private bool CanPlayChangeTween;

	// Token: 0x0200859D RID: 34205
	[NullableContext(0)]
	private class EMotorTechTreeComponent
	{
		// Token: 0x0402D343 RID: 185155
		public const int PnlSkillTip = 0;

		// Token: 0x0402D344 RID: 185156
		public const int SkillFirstItem = 1;

		// Token: 0x0402D345 RID: 185157
		public const int SkillSubLayout = 2;

		// Token: 0x0402D346 RID: 185158
		public const int PnlSkillSubListItem = 3;

		// Token: 0x0402D347 RID: 185159
		public const int NotActivatedTreeItem = 4;

		// Token: 0x0402D348 RID: 185160
		public const int BtnSwitch = 5;

		// Token: 0x0402D349 RID: 185161
		public const int ActivateTreeItem = 6;

		// Token: 0x0402D34A RID: 185162
		public const int TabLayout = 7;

		// Token: 0x0402D34B RID: 185163
		public const int TabItem = 8;

		// Token: 0x0402D34C RID: 185164
		public const int SkillCommonStyleItem = 9;

		// Token: 0x0402D34D RID: 185165
		public const int SkillCommonStyleDoubleItem = 10;
	}
}
