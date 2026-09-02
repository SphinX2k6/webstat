using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001DA2 RID: 7586
public class TrapDefensePreparationPanel : BattleChildViewPanel
{
	// Token: 0x0600DFC8 RID: 57288 RVA: 0x003C3828 File Offset: 0x003C1A28
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnStartChallengeBtnClicked)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnWeaponPreparationBtnClicked)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnShopBtnClicked))
		};
	}

	// Token: 0x0600DFC9 RID: 57289 RVA: 0x003C38D5 File Offset: 0x003C1AD5
	protected override void OnStart()
	{
		this.Sequence = new UiSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600DFCA RID: 57290 RVA: 0x003C38E8 File Offset: 0x003C1AE8
	protected override void OnBeforeShow()
	{
		this.Sequence.PlaySequencePurely("UiIn", false, false);
		this.RefreshShopItemActive();
		this.RefreshWeaponPreparationBtnActive();
	}

	// Token: 0x0600DFCB RID: 57291 RVA: 0x003C3908 File Offset: 0x003C1B08
	protected override UniTask OnBeforeHideAsync()
	{
		TrapDefensePreparationPanel.<OnBeforeHideAsync>d__5 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<TrapDefensePreparationPanel.<OnBeforeHideAsync>d__5>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DFCC RID: 57292 RVA: 0x003C394B File Offset: 0x003C1B4B
	protected override void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
	}

	// Token: 0x0600DFCD RID: 57293 RVA: 0x003C3969 File Offset: 0x003C1B69
	protected override void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
	}

	// Token: 0x0600DFCE RID: 57294 RVA: 0x003C3987 File Offset: 0x003C1B87
	protected override void OnBeforeDestroy()
	{
		this.Sequence.Clear();
	}

	// Token: 0x0600DFCF RID: 57295 RVA: 0x003C3994 File Offset: 0x003C1B94
	private void OnStartChallengeBtnClicked()
	{
		if (this.CheckShowConfirmBox())
		{
			this.ShowConfirmBox();
			return;
		}
		this.StartFight();
	}

	// Token: 0x0600DFD0 RID: 57296 RVA: 0x003C39AC File Offset: 0x003C1BAC
	protected override bool OnCheckBattleChildViewPanelShowCondition()
	{
		return ControllerBase<TowerDefenseEventController>.Instance.IsInPreview();
	}

	// Token: 0x0600DFD1 RID: 57297 RVA: 0x003C39B8 File Offset: 0x003C1BB8
	private void OnWeaponPreparationBtnClicked()
	{
		ControllerBase<TrapDefenseController>.Instance.OpenOrganDevelop(true, null, 0, null);
	}

	// Token: 0x0600DFD2 RID: 57298 RVA: 0x003C39C8 File Offset: 0x003C1BC8
	private void OnShopBtnClicked()
	{
		ModelBase<TrapDefenseModel>.Instance.OpenViewShop();
	}

	// Token: 0x0600DFD3 RID: 57299 RVA: 0x003C39D4 File Offset: 0x003C1BD4
	private void OnWorldDoneAndCloseLoading()
	{
		this.RefreshShopItemActive();
		this.RefreshWeaponPreparationBtnActive();
	}

	// Token: 0x0600DFD4 RID: 57300 RVA: 0x003C39E4 File Offset: 0x003C1BE4
	private void ShowConfirmBox()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TrapDefenseMachineFull);
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleTextKey = "ConfirmBox_363_Desc";
		confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
		{
			ModelBase<TrapDefenseModel>.Instance.IsSkipMachineFullCheck = isSelectOn;
		});
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			this.StartFight();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600DFD5 RID: 57301 RVA: 0x003C3A58 File Offset: 0x003C1C58
	private bool CheckShowConfirmBox()
	{
		int isCanBuildMachine = ModelBase<TrapDefenseModel>.Instance.BattleData.IsCanBuildMachine ? 1 : 0;
		bool isSkipMachineFullCheck = ModelBase<TrapDefenseModel>.Instance.IsSkipMachineFullCheck;
		return isCanBuildMachine != 0 && !isSkipMachineFullCheck && !ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.IsSlotFull();
	}

	// Token: 0x0600DFD6 RID: 57302 RVA: 0x003C3A9C File Offset: 0x003C1C9C
	private UniTask StartFight()
	{
		TrapDefensePreparationPanel.<StartFight>d__16 <StartFight>d__;
		<StartFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartFight>d__.<>1__state = -1;
		<StartFight>d__.<>t__builder.Start<TrapDefensePreparationPanel.<StartFight>d__16>(ref <StartFight>d__);
		return <StartFight>d__.<>t__builder.Task;
	}

	// Token: 0x0600DFD7 RID: 57303 RVA: 0x003C3AD8 File Offset: 0x003C1CD8
	public void RefreshShopItemActive()
	{
		UUIButtonComponent button = base.GetButton(2);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(ModelBase<TrapDefenseModel>.Instance.BattleData.IsShopOpen);
	}

	// Token: 0x0600DFD8 RID: 57304 RVA: 0x003C3B14 File Offset: 0x003C1D14
	public void RefreshWeaponPreparationBtnActive()
	{
		bool isCanBuildMachine = ModelBase<TrapDefenseModel>.Instance.BattleData.IsCanBuildMachine;
		UUIButtonComponent button = base.GetButton(1);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(isCanBuildMachine);
	}

	// Token: 0x04006B82 RID: 27522
	[Nullable(1)]
	protected UiSequencePlayer Sequence;

	// Token: 0x02008146 RID: 33094
	private static class EComponentDefine
	{
		// Token: 0x0402BEF1 RID: 179953
		public const int StartChallengeBtn = 0;

		// Token: 0x0402BEF2 RID: 179954
		public const int WeaponPreparationBtn = 1;

		// Token: 0x0402BEF3 RID: 179955
		public const int ShopBtn = 2;
	}
}
