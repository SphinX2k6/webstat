using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.GameMainView.TrapDefense.ChildPanel
{
	// Token: 0x02005D14 RID: 23828
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMachineSelectPanel : BattleChildViewPanel
	{
		// Token: 0x0603C0D1 RID: 245969 RVA: 0x00F3B6A4 File Offset: 0x00F398A4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x0603C0D2 RID: 245970 RVA: 0x00F3B72C File Offset: 0x00F3992C
		private UniTask CreateMachineItem(UUIItem uiItem)
		{
			TrapDefenseMachineSelectPanel.<CreateMachineItem>d__16 <CreateMachineItem>d__;
			<CreateMachineItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMachineItem>d__.<>4__this = this;
			<CreateMachineItem>d__.uiItem = uiItem;
			<CreateMachineItem>d__.<>1__state = -1;
			<CreateMachineItem>d__.<>t__builder.Start<TrapDefenseMachineSelectPanel.<CreateMachineItem>d__16>(ref <CreateMachineItem>d__);
			return <CreateMachineItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603C0D3 RID: 245971 RVA: 0x00F3B778 File Offset: 0x00F39978
		private UniTask InitMachineItemList()
		{
			TrapDefenseMachineSelectPanel.<InitMachineItemList>d__17 <InitMachineItemList>d__;
			<InitMachineItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMachineItemList>d__.<>4__this = this;
			<InitMachineItemList>d__.<>1__state = -1;
			<InitMachineItemList>d__.<>t__builder.Start<TrapDefenseMachineSelectPanel.<InitMachineItemList>d__17>(ref <InitMachineItemList>d__);
			return <InitMachineItemList>d__.<>t__builder.Task;
		}

		// Token: 0x0603C0D4 RID: 245972 RVA: 0x00F3B7BC File Offset: 0x00F399BC
		private UniTask InitMoneyIcon()
		{
			TrapDefenseMachineSelectPanel.<InitMoneyIcon>d__18 <InitMoneyIcon>d__;
			<InitMoneyIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMoneyIcon>d__.<>4__this = this;
			<InitMoneyIcon>d__.<>1__state = -1;
			<InitMoneyIcon>d__.<>t__builder.Start<TrapDefenseMachineSelectPanel.<InitMoneyIcon>d__18>(ref <InitMoneyIcon>d__);
			return <InitMoneyIcon>d__.<>t__builder.Task;
		}

		// Token: 0x0603C0D5 RID: 245973 RVA: 0x00F3B800 File Offset: 0x00F39A00
		private UniTask InitTouchSlider()
		{
			TrapDefenseMachineSelectPanel.<InitTouchSlider>d__19 <InitTouchSlider>d__;
			<InitTouchSlider>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTouchSlider>d__.<>4__this = this;
			<InitTouchSlider>d__.<>1__state = -1;
			<InitTouchSlider>d__.<>t__builder.Start<TrapDefenseMachineSelectPanel.<InitTouchSlider>d__19>(ref <InitTouchSlider>d__);
			return <InitTouchSlider>d__.<>t__builder.Task;
		}

		// Token: 0x0603C0D6 RID: 245974 RVA: 0x00F3B844 File Offset: 0x00F39A44
		public override void InitializeTemp()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.LastMoneyNum = ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum();
			this.MoneyText = base.GetText(1);
			this.MoneyTween = new LguiIntTween();
			this.MoneyTween.BindUpdateTween(new Action<int>(this.OnMoneyTweenUpdate));
		}

		// Token: 0x0603C0D7 RID: 245975 RVA: 0x00F3B8A8 File Offset: 0x00F39AA8
		public override UniTask InitializeAsync()
		{
			TrapDefenseMachineSelectPanel.<InitializeAsync>d__21 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<TrapDefenseMachineSelectPanel.<InitializeAsync>d__21>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C0D8 RID: 245976 RVA: 0x00F3B8EB File Offset: 0x00F39AEB
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseOnSystemInfoNotify, new Action(this.OnTrapDefenseSystemInfoNotify));
		}

		// Token: 0x0603C0D9 RID: 245977 RVA: 0x00F3B909 File Offset: 0x00F39B09
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseOnSystemInfoNotify, new Action(this.OnTrapDefenseSystemInfoNotify));
		}

		// Token: 0x0603C0DA RID: 245978 RVA: 0x00F3B927 File Offset: 0x00F39B27
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			this.RefreshMachineState();
			this.RegisterBehaviorTreeVar();
			this.RefreshMachineSelectCollapse();
		}

		// Token: 0x0603C0DB RID: 245979 RVA: 0x00F3B93B File Offset: 0x00F39B3B
		protected override void OnHideBattleChildViewPanel()
		{
			this.UnregisterBehaviorTreeVar();
		}

		// Token: 0x0603C0DC RID: 245980 RVA: 0x00F3B944 File Offset: 0x00F39B44
		public override void OnTickBattleChildViewPanel(float delta)
		{
			foreach (TrapDefenseMachineSelectItem trapDefenseMachineSelectItem in this.ItemList)
			{
				trapDefenseMachineSelectItem.Tick(delta);
			}
		}

		// Token: 0x0603C0DD RID: 245981 RVA: 0x00F3B998 File Offset: 0x00F39B98
		protected override void OnBeforeDestroy()
		{
			this.MoneyTween.Destroy();
			this.Sequence.Clear();
		}

		// Token: 0x0603C0DE RID: 245982 RVA: 0x00F3B9B0 File Offset: 0x00F39BB0
		private void OnTrapDefenseSystemInfoNotify()
		{
			this.RefreshTouchSlider();
		}

		// Token: 0x0603C0DF RID: 245983 RVA: 0x00F3B9B8 File Offset: 0x00F39BB8
		private void RegisterBehaviorTreeVar()
		{
			ModelBase<TrapDefenseModel>.Instance.BattleData.AddTreeVarUpdateDelegate(ETrapDefenseSystemVarType.Gold, new TTreeVarUpdateDelegate(this.EventRefreshMoneyText));
			ModelBase<TrapDefenseModel>.Instance.BattleData.AddTreeVarUpdateDelegate(ETrapDefenseSystemVarType.TrapCount, new TTreeVarUpdateDelegate(this.EventRefreshBuildText));
			ModelBase<TrapDefenseModel>.Instance.BattleData.AddTreeVarUpdateDelegate(ETrapDefenseSystemVarType.MaxTrapCount, new TTreeVarUpdateDelegate(this.EventRefreshBuildText));
		}

		// Token: 0x0603C0E0 RID: 245984 RVA: 0x00F3BA1C File Offset: 0x00F39C1C
		private void UnregisterBehaviorTreeVar()
		{
			ModelBase<TrapDefenseModel>.Instance.BattleData.RemoveTreeVarUpdateDelegate(ETrapDefenseSystemVarType.Gold, new TTreeVarUpdateDelegate(this.EventRefreshMoneyText));
			ModelBase<TrapDefenseModel>.Instance.BattleData.RemoveTreeVarUpdateDelegate(ETrapDefenseSystemVarType.TrapCount, new TTreeVarUpdateDelegate(this.EventRefreshBuildText));
			ModelBase<TrapDefenseModel>.Instance.BattleData.RemoveTreeVarUpdateDelegate(ETrapDefenseSystemVarType.MaxTrapCount, new TTreeVarUpdateDelegate(this.EventRefreshBuildText));
		}

		// Token: 0x0603C0E1 RID: 245985 RVA: 0x00F3BA7D File Offset: 0x00F39C7D
		private void HandleMachineSelect(TrapDefenseMachineSelectItem selectItem)
		{
			this.SetCurrentSelectItem(selectItem);
			this.HandleCurrentSelectItem();
		}

		// Token: 0x0603C0E2 RID: 245986 RVA: 0x00F3BA8C File Offset: 0x00F39C8C
		private void SetCurrentSelectItem(TrapDefenseMachineSelectItem selectItem)
		{
			if (selectItem.Data == null)
			{
				return;
			}
			if (this.CurrentSelectItem == selectItem)
			{
				return;
			}
			if (this.CurrentSelectItem != null)
			{
				this.CurrentSelectItem.SetToggleState(EToggleState.ETT_UnChecked, false);
			}
			this.CurrentSelectItem = selectItem;
		}

		// Token: 0x0603C0E3 RID: 245987 RVA: 0x00F3BAC0 File Offset: 0x00F39CC0
		private void HandleCurrentSelectItem()
		{
			if (this.CurrentSelectItem == null || this.CurrentSelectItem.Data == null)
			{
				return;
			}
			if (this.CurrentSelectItem.Data.IsBuilding)
			{
				ControllerBase<TowerDefenseEventController>.Instance.HandleTowerDefenseSelect(this.CurrentSelectItem.Index);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPlayerFollowerEnableChange, false);
			}
			else
			{
				TowerDefensePlayerController.HandleTowerFollowerSelect(this.CurrentSelectItem.Data.Id);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPlayerFollowerEnableChange, true);
			}
			ITrapDefenseMachineSelectInterface machineSelectInterface = this.MachineSelectInterface;
			if (machineSelectInterface == null)
			{
				return;
			}
			machineSelectInterface.SelectMachine(this.CurrentSelectItem.Data);
		}

		// Token: 0x0603C0E4 RID: 245988 RVA: 0x00F3BB5E File Offset: 0x00F39D5E
		private void OpenOrganDevelop(TrapDefenseMachineSelectItem selectItem)
		{
			ControllerBase<TrapDefenseController>.Instance.OpenOrganDevelop(true, null, selectItem.Index, null);
		}

		// Token: 0x0603C0E5 RID: 245989 RVA: 0x00F3BB74 File Offset: 0x00F39D74
		private void RefreshMachineSelectCollapse()
		{
			bool machineSelectCollapse = Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PlotViewHUD);
			this.SetMachineSelectCollapse(machineSelectCollapse);
		}

		// Token: 0x0603C0E6 RID: 245990 RVA: 0x00F3BB98 File Offset: 0x00F39D98
		private void RefreshTouchSlider()
		{
			if (this.TouchSlider != null)
			{
				List<TrapDefenseBuildingSlotData> slotData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetSlotData();
				if (slotData.Count > 0)
				{
					this.TouchSlider.RefreshSliderMaxValue((float)(slotData.Count - 1));
				}
			}
		}

		// Token: 0x0603C0E7 RID: 245991 RVA: 0x00F3BBDA File Offset: 0x00F39DDA
		protected void EventRefreshMoneyText([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
		{
			this.RefreshMoneyText();
		}

		// Token: 0x0603C0E8 RID: 245992 RVA: 0x00F3BBE4 File Offset: 0x00F39DE4
		protected void RefreshMoneyText()
		{
			long goldNum = ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum();
			long num = Math.Abs(goldNum - this.LastMoneyNum);
			if (num > 0L)
			{
				float time = Math.Min((float)num * 0.01f, 0.5f);
				this.MoneyTween.PlayTween((int)this.LastMoneyNum, (int)goldNum, time, null);
			}
			else
			{
				this.MoneyTween.KillTween();
				this.MoneyText.SetText(goldNum.ToString(), true);
			}
			foreach (TrapDefenseMachineSelectItem trapDefenseMachineSelectItem in this.ItemList)
			{
				trapDefenseMachineSelectItem.RefreshCoin();
			}
		}

		// Token: 0x0603C0E9 RID: 245993 RVA: 0x00F3BCA0 File Offset: 0x00F39EA0
		protected void EventRefreshBuildText([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
		{
			this.RefreshBuildText();
		}

		// Token: 0x0603C0EA RID: 245994 RVA: 0x00F3BCA8 File Offset: 0x00F39EA8
		protected void RefreshBuildText()
		{
			long trapCount = ModelBase<TrapDefenseModel>.Instance.BattleData.GetTrapCount();
			long maxTrapCount = ModelBase<TrapDefenseModel>.Instance.BattleData.GetMaxTrapCount();
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(trapCount.ToString() + "/" + maxTrapCount.ToString(), true);
		}

		// Token: 0x0603C0EB RID: 245995 RVA: 0x00F3BD00 File Offset: 0x00F39F00
		private void OnToggleClick(TrapDefenseMachineSelectItem selectItem)
		{
			if (selectItem.Data == null && ModelBase<TrapDefenseModel>.Instance.BattleData.IsCanBuildMachine)
			{
				selectItem.SetToggleState(EToggleState.ETT_UnChecked, false);
				this.OpenOrganDevelop(selectItem);
				return;
			}
			this.HandleMachineSelect(selectItem);
			int num = this.ItemList.IndexOf(selectItem);
			TrapDefenseMachineSelectSlider touchSlider = this.TouchSlider;
			if (touchSlider == null)
			{
				return;
			}
			touchSlider.SetSliderValue((float)num, false);
		}

		// Token: 0x0603C0EC RID: 245996 RVA: 0x00F3BD5D File Offset: 0x00F39F5D
		private void OnSliderPointerDown()
		{
			this.SliderRecordLastSelectItem = this.CurrentSelectItem;
			this.SliderRecordDragSelectItem = this.CurrentSelectItem;
			ITrapDefenseMachineSelectInterface machineSelectInterface = this.MachineSelectInterface;
			if (machineSelectInterface == null)
			{
				return;
			}
			machineSelectInterface.SliderPointerDown();
		}

		// Token: 0x0603C0ED RID: 245997 RVA: 0x00F3BD88 File Offset: 0x00F39F88
		private void OnSliderValueChange(float value)
		{
			TrapDefenseMachineSelectItem trapDefenseMachineSelectItem = this.ItemList[(int)value];
			trapDefenseMachineSelectItem.SetToggleState(EToggleState.ETT_Checked, false);
			TrapDefenseMachineSelectItem sliderRecordDragSelectItem = this.SliderRecordDragSelectItem;
			if (sliderRecordDragSelectItem != null)
			{
				sliderRecordDragSelectItem.SetToggleState(EToggleState.ETT_UnChecked, false);
			}
			this.SliderRecordDragSelectItem = trapDefenseMachineSelectItem;
			ITrapDefenseMachineSelectInterface machineSelectInterface = this.MachineSelectInterface;
			if (machineSelectInterface == null)
			{
				return;
			}
			machineSelectInterface.SliderValueChange(trapDefenseMachineSelectItem.Data);
		}

		// Token: 0x0603C0EE RID: 245998 RVA: 0x00F3BDDC File Offset: 0x00F39FDC
		private void OnSliderEndDrag()
		{
			if (this.SliderRecordDragSelectItem != null)
			{
				if (this.SliderRecordDragSelectItem.Data == null)
				{
					this.SliderRecordDragSelectItem.SetToggleState(EToggleState.ETT_UnChecked, false);
					if (ModelBase<TrapDefenseModel>.Instance.BattleData.IsCanBuildMachine)
					{
						this.OpenOrganDevelop(this.SliderRecordDragSelectItem);
					}
				}
				else
				{
					this.SliderRecordLastSelectItem = this.SliderRecordDragSelectItem;
				}
			}
			if (this.SliderRecordLastSelectItem != null)
			{
				if (this.SliderRecordLastSelectItem != this.CurrentSelectItem)
				{
					this.HandleMachineSelect(this.SliderRecordLastSelectItem);
				}
				else
				{
					this.SliderRecordLastSelectItem.SetToggleState(EToggleState.ETT_Checked, true);
					int num = this.ItemList.IndexOf(this.SliderRecordLastSelectItem);
					TrapDefenseMachineSelectSlider touchSlider = this.TouchSlider;
					if (touchSlider != null)
					{
						touchSlider.SetSliderValue((float)num, false);
					}
				}
			}
			this.SliderRecordDragSelectItem = null;
			this.SliderRecordLastSelectItem = null;
			ITrapDefenseMachineSelectInterface machineSelectInterface = this.MachineSelectInterface;
			if (machineSelectInterface == null)
			{
				return;
			}
			machineSelectInterface.SliderDragEnd();
		}

		// Token: 0x0603C0EF RID: 245999 RVA: 0x00F3BEAB File Offset: 0x00F3A0AB
		private void OnMoneyTweenUpdate(int value)
		{
			this.MoneyText.SetText(value.ToString(), true);
			this.LastMoneyNum = (long)value;
		}

		// Token: 0x0603C0F0 RID: 246000 RVA: 0x00F3BEC8 File Offset: 0x00F3A0C8
		public void SetInterface(ITrapDefenseMachineSelectInterface machineSelectInterface)
		{
			this.MachineSelectInterface = machineSelectInterface;
		}

		// Token: 0x0603C0F1 RID: 246001 RVA: 0x00F3BED1 File Offset: 0x00F3A0D1
		public void OnTowerDefenseStepUpdate(ETowerDefenseEventProcessStatus status)
		{
			if (status == ETowerDefenseEventProcessStatus.Fighting)
			{
				this.TryResetToFirstAuxiliary();
				return;
			}
			if (status == ETowerDefenseEventProcessStatus.Ready && !this.IsInitialized)
			{
				this.IsInitialized = true;
				this.TryResetToFirstAuxiliary();
				return;
			}
			if (this.CurrentSelectItem == null)
			{
				this.RefreshMachineState();
				return;
			}
			this.RefreshSlotState();
		}

		// Token: 0x0603C0F2 RID: 246002 RVA: 0x00F3BF10 File Offset: 0x00F3A110
		public void RefreshMachineState()
		{
			this.RefreshSlotState();
			TrapDefenseMachineSelectItem currentSelectItem = this.CurrentSelectItem;
			int? num;
			if (currentSelectItem == null)
			{
				num = null;
			}
			else
			{
				TrapDefenseBuildingDevelopItemData data = currentSelectItem.Data;
				num = ((data != null) ? new int?(data.Id) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			List<TrapDefenseBuildingSlotData> slotData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetSlotData();
			if (slotData.Count > 0)
			{
				int num3 = -1;
				int num4 = -1;
				foreach (TrapDefenseBuildingSlotData trapDefenseBuildingSlotData in slotData)
				{
					TrapDefenseBuildingDevelopItemData slotData2 = trapDefenseBuildingSlotData.GetSlotData();
					if (slotData2 != null)
					{
						if (!slotData2.IsBuilding && num3 == -1)
						{
							num3 = trapDefenseBuildingSlotData.GetIndex();
						}
						if (slotData2.Id == valueOrDefault)
						{
							num4 = trapDefenseBuildingSlotData.GetIndex();
							break;
						}
					}
				}
				if (num4 != -1)
				{
					this.ItemList[num4].SetToggleState(EToggleState.ETT_Checked, true);
				}
				else if (num3 != -1)
				{
					this.ItemList[num3].SetToggleState(EToggleState.ETT_Checked, true);
				}
			}
			this.RefreshMoneyText();
			this.RefreshBuildText();
		}

		// Token: 0x0603C0F3 RID: 246003 RVA: 0x00F3C034 File Offset: 0x00F3A234
		private void TryResetToFirstAuxiliary()
		{
			this.RefreshSlotState();
			TrapDefenseMachineSelectItem currentSelectItem = this.CurrentSelectItem;
			int? num;
			if (currentSelectItem == null)
			{
				num = null;
			}
			else
			{
				TrapDefenseBuildingDevelopItemData data = currentSelectItem.Data;
				num = ((data != null) ? new int?(data.Id) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			List<TrapDefenseBuildingSlotData> slotData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetSlotData();
			if (slotData.Count > 0)
			{
				int num3 = -1;
				int num4 = -1;
				foreach (TrapDefenseBuildingSlotData trapDefenseBuildingSlotData in slotData)
				{
					TrapDefenseBuildingDevelopItemData slotData2 = trapDefenseBuildingSlotData.GetSlotData();
					if (slotData2 != null && !slotData2.IsBuilding)
					{
						if (!slotData2.IsBuilding && num3 == -1)
						{
							num3 = trapDefenseBuildingSlotData.GetIndex();
						}
						if (slotData2.Id == valueOrDefault)
						{
							num4 = trapDefenseBuildingSlotData.GetIndex();
							break;
						}
					}
				}
				if (num4 != -1)
				{
					this.ItemList[num4].SetToggleState(EToggleState.ETT_Checked, true);
					return;
				}
				if (num3 != -1)
				{
					this.ItemList[num3].SetToggleState(EToggleState.ETT_Checked, true);
				}
			}
		}

		// Token: 0x0603C0F4 RID: 246004 RVA: 0x00F3C154 File Offset: 0x00F3A354
		public void RefreshMachineCdState(int proxyId)
		{
			foreach (TrapDefenseMachineSelectItem trapDefenseMachineSelectItem in this.ItemList)
			{
				TrapDefenseBuildingDevelopItemData data = trapDefenseMachineSelectItem.Data;
				if (data != null && data.Id == proxyId)
				{
					trapDefenseMachineSelectItem.RefreshCd();
				}
			}
		}

		// Token: 0x0603C0F5 RID: 246005 RVA: 0x00F3C1C0 File Offset: 0x00F3A3C0
		public void RefreshSlotState()
		{
			List<TrapDefenseBuildingSlotData> slotData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetSlotData();
			int i = 0;
			int count = this.ItemList.Count;
			while (i < count)
			{
				TrapDefenseMachineSelectItem trapDefenseMachineSelectItem = this.ItemList[i];
				if (i < slotData.Count)
				{
					TrapDefenseBuildingSlotData trapDefenseBuildingSlotData = slotData[i];
					trapDefenseMachineSelectItem.Refresh(trapDefenseBuildingSlotData.GetSlotData());
					trapDefenseMachineSelectItem.SetActive(true);
				}
				else
				{
					trapDefenseMachineSelectItem.SetActive(false);
					trapDefenseMachineSelectItem.Refresh(null);
				}
				i++;
			}
		}

		// Token: 0x0603C0F6 RID: 246006 RVA: 0x00F3C238 File Offset: 0x00F3A438
		public void SetMachineSelectCollapse(bool isInPlotHud)
		{
			if (this.IsInPlotHud == isInPlotHud)
			{
				return;
			}
			this.IsInPlotHud = isInPlotHud;
			if (isInPlotHud)
			{
				this.Sequence.StopSequenceByKey("Normal", false, true);
				this.Sequence.PlaySequence("Collapse", false, null);
				return;
			}
			this.Sequence.StopSequenceByKey("Collapse", false, true);
			this.Sequence.PlaySequence("Normal", false, null);
		}

		// Token: 0x04021BB9 RID: 138169
		private const float TWEEN_NUM_INTERVAL = 0.01f;

		// Token: 0x04021BBA RID: 138170
		private const float TWEEN_MAX_TIME = 0.5f;

		// Token: 0x04021BBB RID: 138171
		protected List<TrapDefenseMachineSelectItem> ItemList = new List<TrapDefenseMachineSelectItem>();

		// Token: 0x04021BBC RID: 138172
		[Nullable(2)]
		protected TrapDefenseMachineSelectItem CurrentSelectItem;

		// Token: 0x04021BBD RID: 138173
		[Nullable(2)]
		protected ITrapDefenseMachineSelectInterface MachineSelectInterface;

		// Token: 0x04021BBE RID: 138174
		[Nullable(2)]
		protected TrapDefenseMachineSelectSlider TouchSlider;

		// Token: 0x04021BBF RID: 138175
		protected LguiIntTween MoneyTween;

		// Token: 0x04021BC0 RID: 138176
		protected UUIText MoneyText;

		// Token: 0x04021BC1 RID: 138177
		protected long LastMoneyNum;

		// Token: 0x04021BC2 RID: 138178
		[Nullable(2)]
		protected TrapDefenseMachineSelectItem SliderRecordLastSelectItem;

		// Token: 0x04021BC3 RID: 138179
		[Nullable(2)]
		protected TrapDefenseMachineSelectItem SliderRecordDragSelectItem;

		// Token: 0x04021BC4 RID: 138180
		protected UiSequencePlayer Sequence;

		// Token: 0x04021BC5 RID: 138181
		protected bool IsInPlotHud;

		// Token: 0x04021BC6 RID: 138182
		protected bool IsInitialized;

		// Token: 0x0200BD78 RID: 48504
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x0403A5BD RID: 239037
			public const int LayoutRootItem = 0;

			// Token: 0x0403A5BE RID: 239038
			public const int MoneyText = 1;

			// Token: 0x0403A5BF RID: 239039
			public const int BuildText = 2;

			// Token: 0x0403A5C0 RID: 239040
			public const int MoneyIcon = 3;

			// Token: 0x0403A5C1 RID: 239041
			public const int TouchSliderItem = 4;
		}
	}
}
