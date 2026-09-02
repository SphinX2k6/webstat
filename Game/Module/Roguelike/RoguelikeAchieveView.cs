using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005134 RID: 20788
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeAchieveView : UiViewBase
	{
		// Token: 0x0603584B RID: 219211 RVA: 0x00D6FCE9 File Offset: 0x00D6DEE9
		[NullableContext(1)]
		public RoguelikeAchieveView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603584C RID: 219212 RVA: 0x00D6FCF4 File Offset: 0x00D6DEF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603584D RID: 219213 RVA: 0x00D6FE8C File Offset: 0x00D6E08C
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeAchieveView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeAchieveView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603584E RID: 219214 RVA: 0x00D6FECF File Offset: 0x00D6E0CF
		protected override void OnStart()
		{
			this.RefreshByViewModel();
		}

		// Token: 0x0603584F RID: 219215 RVA: 0x00D6FED7 File Offset: 0x00D6E0D7
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoguelikeArchiveSaved, new Action<int>(this.OnArchiveSaved));
		}

		// Token: 0x06035850 RID: 219216 RVA: 0x00D6FEF5 File Offset: 0x00D6E0F5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoguelikeArchiveSaved, new Action<int>(this.OnArchiveSaved));
		}

		// Token: 0x06035851 RID: 219217 RVA: 0x00D6FF13 File Offset: 0x00D6E113
		protected override void OnBeforeShow()
		{
			this.RefreshByViewModel();
		}

		// Token: 0x06035852 RID: 219218 RVA: 0x00D6FF1C File Offset: 0x00D6E11C
		private void OnBtnRecordSaveClick(int _)
		{
			RoguelikeAchieveSlotData selectedSlotData = this.Vm.SelectedSlotData;
			if (!this.Vm.IsArchiveMode || selectedSlotData == null)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.RoguelikeAchieveSaveRecordRequest(selectedSlotData.SlotIndex).ContinueWith(delegate(bool isSuccess)
			{
				if (!isSuccess)
				{
					return;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Rogue_HintText_SaveRecord", Array.Empty<object>());
			});
		}

		// Token: 0x06035853 RID: 219219 RVA: 0x00D6FF7C File Offset: 0x00D6E17C
		private void OnBtnOverwriteRecordSaveClick(int _)
		{
			RoguelikeAchieveView.<>c__DisplayClass19_0 CS$<>8__locals1 = new RoguelikeAchieveView.<>c__DisplayClass19_0();
			CS$<>8__locals1.selectedSlot = this.Vm.SelectedSlotData;
			if (!this.Vm.IsArchiveMode || CS$<>8__locals1.selectedSlot == null)
			{
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoguelikeOverwriteArchiveConfirm);
			confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<OnBtnOverwriteRecordSaveClick>g__overwrite|0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06035854 RID: 219220 RVA: 0x00D6FFE8 File Offset: 0x00D6E1E8
		private void OnBtnConfirmLeaveClick(int _)
		{
			RoguelikeModel instance = ModelBase<RoguelikeModel>.Instance;
			if (instance != null && instance.CheckInRoguelike())
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().ContinueWith(delegate(bool _)
				{
					if (Singleton<UiManager>.Instance.IsViewShow(this.ViewInfo.Name))
					{
						base.CloseMe(null);
					}
				});
				return;
			}
			if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoguelikeSettleView) != null)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RoguelikeSettleView, null);
			}
			base.CloseMe(null);
		}

		// Token: 0x06035855 RID: 219221 RVA: 0x00D7004D File Offset: 0x00D6E24D
		private void OnArchiveSaved(int slotId)
		{
			this.Vm.TempArchiveSaved(slotId);
			this.RefreshByViewModel();
			this.RefreshSelectedRoguelikeInfo();
		}

		// Token: 0x06035856 RID: 219222 RVA: 0x00D70068 File Offset: 0x00D6E268
		private void RefreshViewModel()
		{
			RoguelikeAchieveViewModel roguelikeAchieveViewModel = this.OpenParam as RoguelikeAchieveViewModel;
			if (roguelikeAchieveViewModel == null)
			{
				return;
			}
			this.Vm = roguelikeAchieveViewModel;
		}

		// Token: 0x06035857 RID: 219223 RVA: 0x00D7008C File Offset: 0x00D6E28C
		private void RefreshByViewModel()
		{
			RoguelikeAchieveLeftItem leftPanel = this.LeftPanel;
			if (leftPanel != null)
			{
				leftPanel.RefreshByViewModel();
			}
			this.RefreshModeState();
		}

		// Token: 0x06035858 RID: 219224 RVA: 0x00D700A8 File Offset: 0x00D6E2A8
		private void RefreshSelectedRoguelikeInfo()
		{
			RogueArchiveInfoData selectedArchiveInfoData = this.Vm.SelectedArchiveInfoData;
			bool isTempRecordSelected = this.Vm.IsTempRecordSelected;
			RoguelikeAchieveTotalPanel totalPanel = this.TotalPanel;
			if (totalPanel != null)
			{
				totalPanel.Refresh(selectedArchiveInfoData);
			}
			RoguelikeAchieveTokenPanel tokenPanel = this.TokenPanel;
			if (tokenPanel != null)
			{
				tokenPanel.Refresh(selectedArchiveInfoData);
			}
			RoguelikeAchieveSpecialPanel specialPanel = this.SpecialPanel;
			if (specialPanel != null)
			{
				specialPanel.Refresh(selectedArchiveInfoData);
			}
			RoguelikeAchieveEntryPanel entryPanel = this.EntryPanel;
			if (entryPanel != null)
			{
				entryPanel.Refresh(selectedArchiveInfoData, isTempRecordSelected);
			}
			this.RefreshModeState();
		}

		// Token: 0x06035859 RID: 219225 RVA: 0x00D7011C File Offset: 0x00D6E31C
		private void RefreshModeState()
		{
			bool isArchiveMode = this.Vm.IsArchiveMode;
			bool isTempRecordSelected = this.Vm.IsTempRecordSelected;
			RoguelikeAchieveSlotData selectedSlotData = this.Vm.SelectedSlotData;
			bool flag;
			if (isArchiveMode && !isTempRecordSelected)
			{
				if (selectedSlotData == null)
				{
					flag = true;
				}
				else
				{
					RogueArchiveInfoData archiveInfoData = selectedSlotData.ArchiveInfoData;
					flag = !((archiveInfoData != null) ? new bool?(archiveInfoData.HasData) : null).GetValueOrDefault();
				}
			}
			else
			{
				flag = false;
			}
			bool uiactive = flag;
			bool flag2;
			if (isArchiveMode && !isTempRecordSelected)
			{
				if (selectedSlotData == null)
				{
					flag2 = false;
				}
				else
				{
					RogueArchiveInfoData archiveInfoData2 = selectedSlotData.ArchiveInfoData;
					flag2 = ((archiveInfoData2 != null) ? new bool?(archiveInfoData2.HasData) : null).GetValueOrDefault();
				}
			}
			else
			{
				flag2 = false;
			}
			bool uiactive2 = flag2;
			bool isTempRecordSaved = this.Vm.IsTempRecordSaved;
			bool flag3 = isArchiveMode && !isTempRecordSaved;
			string textId = flag3 ? "Rogue_Record_CanSave" : "Rogue_Record_Saved";
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 != null)
			{
				item2.SetUIActive(uiactive2);
			}
			ButtonItem btnConfirmLeaveItem = this.BtnConfirmLeaveItem;
			if (btnConfirmLeaveItem != null)
			{
				btnConfirmLeaveItem.SetUiActive(isArchiveMode && isTempRecordSaved);
			}
			ButtonItem btnRecordSaveItem = this.BtnRecordSaveItem;
			if (btnRecordSaveItem != null)
			{
				btnRecordSaveItem.SetUiActive(isArchiveMode);
			}
			ButtonItem btnRecordSaveItem2 = this.BtnRecordSaveItem;
			if (btnRecordSaveItem2 != null)
			{
				btnRecordSaveItem2.SetEnableClick(flag3);
			}
			ButtonItem btnRecordSaveItem3 = this.BtnRecordSaveItem;
			if (btnRecordSaveItem3 != null)
			{
				btnRecordSaveItem3.SetLocalTextNew(textId, Array.Empty<object>());
			}
			ButtonItem btnConfirmSaveItem = this.BtnConfirmSaveItem;
			if (btnConfirmSaveItem != null)
			{
				btnConfirmSaveItem.SetUiActive(isArchiveMode);
			}
			ButtonItem btnConfirmSaveItem2 = this.BtnConfirmSaveItem;
			if (btnConfirmSaveItem2 != null)
			{
				btnConfirmSaveItem2.SetEnableClick(flag3);
			}
			ButtonItem btnConfirmSaveItem3 = this.BtnConfirmSaveItem;
			if (btnConfirmSaveItem3 == null)
			{
				return;
			}
			btnConfirmSaveItem3.SetLocalTextNew(textId, Array.Empty<object>());
		}

		// Token: 0x0401EC14 RID: 125972
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401EC15 RID: 125973
		private RoguelikeAchieveLeftItem LeftPanel;

		// Token: 0x0401EC16 RID: 125974
		private ButtonItem BtnRecordSaveItem;

		// Token: 0x0401EC17 RID: 125975
		private RoguelikeAchieveTotalPanel TotalPanel;

		// Token: 0x0401EC18 RID: 125976
		private RoguelikeAchieveTokenPanel TokenPanel;

		// Token: 0x0401EC19 RID: 125977
		private RoguelikeAchieveSpecialPanel SpecialPanel;

		// Token: 0x0401EC1A RID: 125978
		private ButtonItem BtnConfirmLeaveItem;

		// Token: 0x0401EC1B RID: 125979
		private ButtonItem BtnConfirmSaveItem;

		// Token: 0x0401EC1C RID: 125980
		private RoguelikeAchieveEntryPanel EntryPanel;

		// Token: 0x0401EC1D RID: 125981
		[Nullable(1)]
		private RoguelikeAchieveViewModel Vm;

		// Token: 0x0200B0D3 RID: 45267
		[NullableContext(0)]
		private class ERoguelikeAchieveViewComponents
		{
			// Token: 0x04036DB0 RID: 224688
			public const int CaptionItem = 0;

			// Token: 0x04036DB1 RID: 224689
			public const int LeftItem = 1;

			// Token: 0x04036DB2 RID: 224690
			public const int PnlEmpty = 2;

			// Token: 0x04036DB3 RID: 224691
			public const int BtnRecordSave = 3;

			// Token: 0x04036DB4 RID: 224692
			public const int TotalPanel = 4;

			// Token: 0x04036DB5 RID: 224693
			public const int TokenPanel = 5;

			// Token: 0x04036DB6 RID: 224694
			public const int SpecialPanel = 6;

			// Token: 0x04036DB7 RID: 224695
			public const int BtnConfirmLeave = 7;

			// Token: 0x04036DB8 RID: 224696
			public const int BtnConfirmSave = 8;

			// Token: 0x04036DB9 RID: 224697
			public const int PnlBottomBtn = 9;

			// Token: 0x04036DBA RID: 224698
			public const int EntryPanel = 10;
		}
	}
}
