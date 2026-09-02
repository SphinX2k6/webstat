using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022C7 RID: 8903
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleTaskTabView : UiTabViewBase
{
	// Token: 0x06010D75 RID: 68981 RVA: 0x0049BE4C File Offset: 0x0049A04C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnBtnAskClick))
		};
	}

	// Token: 0x06010D76 RID: 68982 RVA: 0x0049BF50 File Offset: 0x0049A150
	protected override void OnStart()
	{
		this.TabComponent = new TabComponent<MotorcycleTreeTypeTabItem>(base.GetHorizontalLayout(6).RootUIComp.Get(), new Func<UUIItem, int?, MotorcycleTreeTypeTabItem>(this.InitTreeTabItem), new Action<int>(this.ToggleCallBack), base.GetItem(7));
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(0);
		AUIBaseActor gridActor = base.GetItem(1).GetOwner() as AUIBaseActor;
		this.TaskLoopScroll = new LoopScrollView<MotorcycleTaskItem, MotorTechTaskNode>(loopScrollViewComponent, gridActor, new Func<MotorcycleTaskItem>(this.InitTaskItem), true);
	}

	// Token: 0x06010D77 RID: 68983 RVA: 0x0049BFD0 File Offset: 0x0049A1D0
	protected override void OnBeforeShow()
	{
		UUIInturnAnimController uuiinturnAnimController = base.GetLoopScrollViewComponent(0).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController != null)
		{
			uuiinturnAnimController.Play("", -1, false);
		}
		this.TreeType = ModelBase<MotorcycleDevelopModel>.Instance.GetSelectedTreeType();
		if (this.TreeType == 0)
		{
			this.TreeType = ModelBase<MotorcycleDevelopModel>.Instance.GetCurTreeType();
		}
		this.OnTabUpdateAsync();
	}

	// Token: 0x06010D78 RID: 68984 RVA: 0x0049C046 File Offset: 0x0049A246
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTaskUpdate, new Action(this.OnTaskUpdate));
	}

	// Token: 0x06010D79 RID: 68985 RVA: 0x0049C064 File Offset: 0x0049A264
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTaskUpdate, new Action(this.OnTaskUpdate));
	}

	// Token: 0x06010D7A RID: 68986 RVA: 0x0049C082 File Offset: 0x0049A282
	private void OnTaskUpdate()
	{
		new UiAsyncTask("TabUpdate", delegate()
		{
			MotorcycleTaskTabView.<<OnTaskUpdate>b__9_0>d <<OnTaskUpdate>b__9_0>d;
			<<OnTaskUpdate>b__9_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnTaskUpdate>b__9_0>d.<>4__this = this;
			<<OnTaskUpdate>b__9_0>d.<>1__state = -1;
			<<OnTaskUpdate>b__9_0>d.<>t__builder.Start<MotorcycleTaskTabView.<<OnTaskUpdate>b__9_0>d>(ref <<OnTaskUpdate>b__9_0>d);
			return <<OnTaskUpdate>b__9_0>d.<>t__builder.Task;
		}, null).Run();
	}

	// Token: 0x06010D7B RID: 68987 RVA: 0x0049C0A4 File Offset: 0x0049A2A4
	private UniTask OnTabUpdateAsync()
	{
		MotorcycleTaskTabView.<OnTabUpdateAsync>d__10 <OnTabUpdateAsync>d__;
		<OnTabUpdateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnTabUpdateAsync>d__.<>4__this = this;
		<OnTabUpdateAsync>d__.<>1__state = -1;
		<OnTabUpdateAsync>d__.<>t__builder.Start<MotorcycleTaskTabView.<OnTabUpdateAsync>d__10>(ref <OnTabUpdateAsync>d__);
		return <OnTabUpdateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010D7C RID: 68988 RVA: 0x0049C0E8 File Offset: 0x0049A2E8
	private void ToggleCallBack(int index)
	{
		List<int> activatedTreeTypeList = ModelBase<MotorcycleDevelopModel>.Instance.GetActivatedTreeTypeList();
		this.TreeType = activatedTreeTypeList[index];
		ModelBase<MotorcycleDevelopModel>.Instance.UpdateSelectedTreeType(this.TreeType);
		this.RefreshTaskList();
		this.RefreshOther();
		if (ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasNewTechTree(this.TreeType))
		{
			ModelBase<MotorcycleDevelopModel>.Instance.UpdateTechTreeNewUnlocked(this.TreeType, false);
			Singleton<EventSystem>.Instance.Emit(EEventName.MotorDevelopTreeTypeRedDotUpdate);
		}
	}

	// Token: 0x06010D7D RID: 68989 RVA: 0x0049C15C File Offset: 0x0049A35C
	private void RefreshTaskList()
	{
		MotorcycleTaskTabView.<>c__DisplayClass12_0 CS$<>8__locals1 = new MotorcycleTaskTabView.<>c__DisplayClass12_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.taskList = ModelBase<MotorcycleDevelopModel>.Instance.GetTaskListByTree(this.TreeType);
		new UiAsyncTask("TaskListUpdate", delegate()
		{
			MotorcycleTaskTabView.<>c__DisplayClass12_0.<<RefreshTaskList>b__0>d <<RefreshTaskList>b__0>d;
			<<RefreshTaskList>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshTaskList>b__0>d.<>4__this = CS$<>8__locals1;
			<<RefreshTaskList>b__0>d.<>1__state = -1;
			<<RefreshTaskList>b__0>d.<>t__builder.Start<MotorcycleTaskTabView.<>c__DisplayClass12_0.<<RefreshTaskList>b__0>d>(ref <<RefreshTaskList>b__0>d);
			return <<RefreshTaskList>b__0>d.<>t__builder.Task;
		}, null).Run();
	}

	// Token: 0x06010D7E RID: 68990 RVA: 0x0049C1AC File Offset: 0x0049A3AC
	private void RefreshOther()
	{
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(this.TreeType);
		if (motorTechTreeConfig == null)
		{
			return;
		}
		int costPointByTree = ModelBase<MotorcycleDevelopModel>.Instance.GetCostPointByTree(this.TreeType);
		int freePointByTree = ModelBase<MotorcycleDevelopModel>.Instance.GetFreePointByTree(this.TreeType);
		int totalPointByTree = ModelBase<MotorcycleDevelopModel>.Instance.GetTotalPointByTree(this.TreeType);
		int num = costPointByTree + freePointByTree;
		float fillAmount = (float)num / (float)totalPointByTree;
		string icon = ConfigBase<ItemConfig>.Instance.GetConfig(motorTechTreeConfig.Value.TpItemId).Value.Icon;
		base.GetSprite(5).SetFillAmount(fillAmount);
		base.GetText(2).SetText(num.ToString() + "/" + totalPointByTree.ToString(), true);
		base.SetTextureByPath(icon, base.GetTexture(8), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "MotorBike_TechCube_CurrentAvailable", new <>z__ReadOnlySingleElementList<object>(freePointByTree));
	}

	// Token: 0x06010D7F RID: 68991 RVA: 0x0049C2AC File Offset: 0x0049A4AC
	private MotorcycleTreeTypeTabItem InitTreeTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleTreeTypeTabItem();
	}

	// Token: 0x06010D80 RID: 68992 RVA: 0x0049C2B3 File Offset: 0x0049A4B3
	private MotorcycleTaskItem InitTaskItem()
	{
		return new MotorcycleTaskItem();
	}

	// Token: 0x06010D81 RID: 68993 RVA: 0x0049C2BA File Offset: 0x0049A4BA
	private void OnBtnAskClick()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(471);
	}

	// Token: 0x06010D82 RID: 68994 RVA: 0x0049C2CC File Offset: 0x0049A4CC
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
		string text = configParams[0];
		if (text == "Tab")
		{
			int index = int.Parse(configParams[1]);
			TabComponent<MotorcycleTreeTypeTabItem> tabComponent = this.TabComponent;
			MotorcycleTreeTypeTabItem motorcycleTreeTypeTabItem = (tabComponent != null) ? tabComponent.GetTabItemByIndex(index) : null;
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
		else
		{
			if (!text.Contains("Reward"))
			{
				return null;
			}
			int gridIndex = int.Parse(configParams[1]);
			LoopScrollView<MotorcycleTaskItem, MotorTechTaskNode> taskLoopScroll = this.TaskLoopScroll;
			MotorcycleTaskItem motorcycleTaskItem = (taskLoopScroll != null) ? taskLoopScroll.UnsafeGetGridProxy(gridIndex, false) : null;
			UUIItem uuiitem2 = (motorcycleTaskItem != null) ? motorcycleTaskItem.GetBtnGet() : null;
			UUIItem uuiitem3 = (motorcycleTaskItem != null) ? motorcycleTaskItem.GetNavigationItem() : null;
			if (motorcycleTaskItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem3
			};
		}
	}

	// Token: 0x040084C2 RID: 33986
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<MotorcycleTreeTypeTabItem> TabComponent;

	// Token: 0x040084C3 RID: 33987
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleTaskItem, MotorTechTaskNode> TaskLoopScroll;

	// Token: 0x040084C4 RID: 33988
	private int TreeType;

	// Token: 0x0200858F RID: 34191
	[NullableContext(0)]
	private class EMotorTaskComponent
	{
		// Token: 0x0402D2FE RID: 185086
		public const int LoopScrollView = 0;

		// Token: 0x0402D2FF RID: 185087
		public const int PnlItem = 1;

		// Token: 0x0402D300 RID: 185088
		public const int TxtProgress = 2;

		// Token: 0x0402D301 RID: 185089
		public const int TxtCurFree = 3;

		// Token: 0x0402D302 RID: 185090
		public const int BtnAsk = 4;

		// Token: 0x0402D303 RID: 185091
		public const int SprProgress = 5;

		// Token: 0x0402D304 RID: 185092
		public const int TabLayout = 6;

		// Token: 0x0402D305 RID: 185093
		public const int TabItem = 7;

		// Token: 0x0402D306 RID: 185094
		public const int TexIcon = 8;
	}
}
