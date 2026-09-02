using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006433 RID: 25651
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeMainView : UiViewBase
	{
		// Token: 0x17009DF7 RID: 40439
		// (get) Token: 0x0604065C RID: 263772 RVA: 0x0108250F File Offset: 0x0108070F
		private RoverlikeActivityData ActivityData
		{
			get
			{
				return ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			}
		}

		// Token: 0x0604065D RID: 263773 RVA: 0x0108251B File Offset: 0x0108071B
		[NullableContext(1)]
		public RoverlikeMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604065E RID: 263774 RVA: 0x01082524 File Offset: 0x01080724
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
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
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604065F RID: 263775 RVA: 0x01082720 File Offset: 0x01080920
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoverlikeEquippedLootChange, new Action<int>(this.OnEquippedLootChange));
			Singleton<EventSystem>.Instance.Add(EEventName.RoverlikeLootInfoUpdate, new Action(this.OnLootInfoUpdate));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040660 RID: 263776 RVA: 0x01082784 File Offset: 0x01080984
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeMainView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeMainView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040661 RID: 263777 RVA: 0x010827C8 File Offset: 0x010809C8
		protected override void OnStart()
		{
			this.Caption.SetCloseCallBack(new Action(this.OnClickClose));
			this.Caption.SetHelpCallBack(new Action(this.OnClickHelp));
			this.BtnSkillTree.SetFunction(delegate(int _)
			{
				this.OnClickTalentTree();
			});
			this.BtnAchieve.SetFunction(delegate(int _)
			{
				this.OnClickHandBook();
			});
			this.BtnEntrance.SetFunction(delegate(int _)
			{
				this.OnClickEntrance();
			});
		}

		// Token: 0x06040662 RID: 263778 RVA: 0x01082848 File Offset: 0x01080A48
		protected override void OnBeforeShow()
		{
			this.RefreshRemainTime();
			this.RefreshEntranceButton();
			this.RefreshRoleStand();
			this.RefreshRewardProgress();
			this.RefreshTalentTreeRedDot();
			this.RefreshEntranceRedDot();
			this.RefreshHandBookRedDot();
			RoverlikeQuestRewardButton questRewardBtn = this.QuestRewardBtn;
			if (questRewardBtn != null)
			{
				questRewardBtn.BindRedDot();
			}
			RoverlikeShopRewardButton shopRewardBtn = this.ShopRewardBtn;
			if (shopRewardBtn != null)
			{
				shopRewardBtn.BindRedDot();
			}
			ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.None);
			RoverlikeEquipmentPanel equipmentPanel = this.EquipmentPanel;
			if (equipmentPanel == null)
			{
				return;
			}
			equipmentPanel.Refresh();
		}

		// Token: 0x06040663 RID: 263779 RVA: 0x010828BC File Offset: 0x01080ABC
		protected override void OnAfterShow()
		{
			ControllerBase<RoverlikeController>.Instance.PlayMainViewUnlockFlow();
		}

		// Token: 0x06040664 RID: 263780 RVA: 0x010828C8 File Offset: 0x01080AC8
		protected override void OnBeforeHide()
		{
			RoverlikeQuestRewardButton questRewardBtn = this.QuestRewardBtn;
			if (questRewardBtn != null)
			{
				questRewardBtn.UnBindRedDot();
			}
			RoverlikeShopRewardButton shopRewardBtn = this.ShopRewardBtn;
			if (shopRewardBtn == null)
			{
				return;
			}
			shopRewardBtn.UnBindRedDot();
		}

		// Token: 0x06040665 RID: 263781 RVA: 0x010828EC File Offset: 0x01080AEC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoverlikeEquippedLootChange, new Action<int>(this.OnEquippedLootChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoverlikeLootInfoUpdate, new Action(this.OnLootInfoUpdate));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040666 RID: 263782 RVA: 0x0108294D File Offset: 0x01080B4D
		private void OnEquippedLootChange(int lootId)
		{
			RoverlikeEquipmentPanel equipmentPanel = this.EquipmentPanel;
			if (equipmentPanel == null)
			{
				return;
			}
			equipmentPanel.Refresh();
		}

		// Token: 0x06040667 RID: 263783 RVA: 0x0108295F File Offset: 0x01080B5F
		private void OnLootInfoUpdate()
		{
			RoverlikeEquipmentPanel equipmentPanel = this.EquipmentPanel;
			if (equipmentPanel == null)
			{
				return;
			}
			equipmentPanel.Refresh();
		}

		// Token: 0x06040668 RID: 263784 RVA: 0x01082974 File Offset: 0x01080B74
		private void OnRefreshCommonActivityRedDot(int activityId)
		{
			RoverlikeActivityData activityData = this.ActivityData;
			int? num = (activityData != null) ? new int?(activityData.Id) : null;
			if (!(activityId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.RefreshTalentTreeRedDot();
			this.RefreshEntranceRedDot();
			this.RefreshHandBookRedDot();
			RoverlikeEquipmentPanel equipmentPanel = this.EquipmentPanel;
			if (equipmentPanel == null)
			{
				return;
			}
			equipmentPanel.Refresh();
		}

		// Token: 0x06040669 RID: 263785 RVA: 0x010829D8 File Offset: 0x01080BD8
		private void RefreshTalentTreeRedDot()
		{
			RoverlikeActivityData activityData = this.ActivityData;
			bool redDotVisible = activityData != null && activityData.TalentTreeData.IsTalentTreeHasRedDot();
			ButtonItem btnSkillTree = this.BtnSkillTree;
			if (btnSkillTree == null)
			{
				return;
			}
			btnSkillTree.SetRedDotVisible(redDotVisible);
		}

		// Token: 0x0604066A RID: 263786 RVA: 0x01082A10 File Offset: 0x01080C10
		private void RefreshHandBookRedDot()
		{
			RoverlikeActivityData activityData = this.ActivityData;
			bool redDotVisible = activityData != null && activityData.HasNewBlessUnlockRedDot();
			ButtonItem btnAchieve = this.BtnAchieve;
			if (btnAchieve == null)
			{
				return;
			}
			btnAchieve.SetRedDotVisible(redDotVisible);
		}

		// Token: 0x0604066B RID: 263787 RVA: 0x01082A41 File Offset: 0x01080C41
		private void RefreshEntranceRedDot()
		{
			RoverlikeEntranceButton btnEntrance = this.BtnEntrance;
			if (btnEntrance == null)
			{
				return;
			}
			btnEntrance.RefreshNewLevelUnlockRedDot(this.ActivityData);
		}

		// Token: 0x0604066C RID: 263788 RVA: 0x01082A5C File Offset: 0x01080C5C
		private void RefreshRemainTime()
		{
			UUIText text = base.GetText(9);
			if (text == null)
			{
				return;
			}
			RoverlikeActivityData activityData = this.ActivityData;
			if (activityData == null)
			{
				text.SetText("", true);
				return;
			}
			string item = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(activityData, null).Item2;
			text.SetText(item, true);
		}

		// Token: 0x0604066D RID: 263789 RVA: 0x01082AA7 File Offset: 0x01080CA7
		private void RefreshEntranceButton()
		{
			this.BtnEntrance.RefreshSaveInfo(this.ActivityData);
		}

		// Token: 0x0604066E RID: 263790 RVA: 0x01082ABA File Offset: 0x01080CBA
		private bool HasSaveProgress()
		{
			RoverlikeActivityData activityData = this.ActivityData;
			return activityData != null && activityData.HasSaveProgress();
		}

		// Token: 0x0604066F RID: 263791 RVA: 0x01082AD0 File Offset: 0x01080CD0
		private void RefreshRoleStand()
		{
			bool flag = ModelBase<RoverlikeModel>.Instance.GetLastPassRoleTypeId() == 2;
			bool flag2 = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			UUIItem item3 = base.GetItem(10);
			if (item3 != null)
			{
				item3.SetUIActive(!flag && flag2);
			}
			UUIItem item4 = base.GetItem(11);
			if (item4 != null)
			{
				item4.SetUIActive(!flag && !flag2);
			}
			UUIItem item5 = base.GetItem(12);
			if (item5 != null)
			{
				item5.SetUIActive(flag && flag2);
			}
			UUIItem item6 = base.GetItem(13);
			if (item6 == null)
			{
				return;
			}
			item6.SetUIActive(flag && !flag2);
		}

		// Token: 0x06040670 RID: 263792 RVA: 0x01082B8A File Offset: 0x01080D8A
		private void RefreshRewardProgress()
		{
			this.RefreshQuestProgress();
			this.RefreshShopProgress();
		}

		// Token: 0x06040671 RID: 263793 RVA: 0x01082B98 File Offset: 0x01080D98
		private void RefreshQuestProgress()
		{
			RoverlikeActivityData activityData = this.ActivityData;
			if (activityData == null)
			{
				return;
			}
			ValueTuple<int, int> questProgress = activityData.GetQuestProgress();
			int item = questProgress.Item1;
			int item2 = questProgress.Item2;
			RoverlikeQuestRewardButton questRewardBtn = this.QuestRewardBtn;
			if (questRewardBtn == null)
			{
				return;
			}
			questRewardBtn.SetProgressNumText(item, item2);
		}

		// Token: 0x06040672 RID: 263794 RVA: 0x01082BD8 File Offset: 0x01080DD8
		private void RefreshShopProgress()
		{
			RoverlikeActivityData activityData = this.ActivityData;
			if (activityData == null)
			{
				return;
			}
			ValueTuple<int, int> shopProgress = activityData.GetShopProgress();
			int item = shopProgress.Item1;
			int item2 = shopProgress.Item2;
			RoverlikeShopRewardButton shopRewardBtn = this.ShopRewardBtn;
			if (shopRewardBtn == null)
			{
				return;
			}
			shopRewardBtn.SetProgressNumText(item, item2);
		}

		// Token: 0x06040673 RID: 263795 RVA: 0x01082C15 File Offset: 0x01080E15
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06040674 RID: 263796 RVA: 0x01082C1E File Offset: 0x01080E1E
		private void OnClickHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(642);
		}

		// Token: 0x06040675 RID: 263797 RVA: 0x01082C2F File Offset: 0x01080E2F
		private void OnClickTalentTree()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeTalentTreeView, null, null);
		}

		// Token: 0x06040676 RID: 263798 RVA: 0x01082C42 File Offset: 0x01080E42
		private void OnClickHandBook()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeHandBookView, EUiTabViewName.RoverlikeOutsideBlessTabView, null);
		}

		// Token: 0x06040677 RID: 263799 RVA: 0x01082C60 File Offset: 0x01080E60
		private void OnClickEntrance()
		{
			RoverlikeMainView.<>c__DisplayClass36_0 CS$<>8__locals1 = new RoverlikeMainView.<>c__DisplayClass36_0();
			CS$<>8__locals1.<>4__this = this;
			RoverlikeMainView.<>c__DisplayClass36_0 CS$<>8__locals2 = CS$<>8__locals1;
			RoverlikeActivityData activityData = this.ActivityData;
			int? num;
			if (activityData == null)
			{
				num = null;
			}
			else
			{
				RoverRogueHistoryInsInfo historyInsInfo = activityData.HistoryInsInfo;
				num = ((historyInsInfo != null) ? new int?(historyInsInfo.CurInsId) : null);
			}
			int? num2 = num;
			CS$<>8__locals2.saveInsId = num2.GetValueOrDefault();
			if (this.HasSaveProgress() && CS$<>8__locals1.saveInsId > 0)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoverRogueSaveEnterConfirm);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					CS$<>8__locals1.<>4__this.ContinueWithSave(CS$<>8__locals1.saveInsId);
				};
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					CS$<>8__locals1.<>4__this.SettleSave(CS$<>8__locals1.saveInsId);
				};
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.EnterNewGame();
		}

		// Token: 0x06040678 RID: 263800 RVA: 0x01082D24 File Offset: 0x01080F24
		private void ContinueWithSave(int saveInsId)
		{
			ControllerBase<RoverlikeController>.Instance.RoverRogueReChallengeRequest(saveInsId, delegate(bool success)
			{
				if (!success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Activity;
					ELogAuthor author = ELogAuthor.SWC;
					string message = "RoverlikeMainView 续档进入失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstId", saveInsId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			});
		}

		// Token: 0x06040679 RID: 263801 RVA: 0x01082D5C File Offset: 0x01080F5C
		private void SettleSave(int saveInsId)
		{
			int? currentActivityId = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityId();
			if (currentActivityId != null)
			{
				int? num = currentActivityId;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					ControllerBase<RoverlikeController>.Instance.RoverRogueResultRequest(currentActivityId.Value, saveInsId, delegate(bool success)
					{
						if (!success)
						{
							return;
						}
						this.RefreshEntranceButton();
					});
					return;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.SWC;
			string message = "RoverlikeMainView 存档结算失败:无活动Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstId", saveInsId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0604067A RID: 263802 RVA: 0x01082DE4 File Offset: 0x01080FE4
		private void EnterNewGame()
		{
			if (ControllerBase<RoverlikeActivityController>.Instance == null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeLevelSelectView, null, null);
				return;
			}
			ControllerBase<RoverlikeController>.Instance.RequestInsList(delegate
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeLevelSelectView, null, null);
			});
		}

		// Token: 0x0402411C RID: 147740
		private PopupCaptionItem Caption;

		// Token: 0x0402411D RID: 147741
		private RoverlikeShopRewardButton ShopRewardBtn;

		// Token: 0x0402411E RID: 147742
		private RoverlikeQuestRewardButton QuestRewardBtn;

		// Token: 0x0402411F RID: 147743
		private ButtonItem BtnSkillTree;

		// Token: 0x04024120 RID: 147744
		private ButtonItem BtnAchieve;

		// Token: 0x04024121 RID: 147745
		private RoverlikeEntranceButton BtnEntrance;

		// Token: 0x04024122 RID: 147746
		private RoverlikeEquipmentPanel EquipmentPanel;

		// Token: 0x0200C4A5 RID: 50341
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C86D RID: 247917
			public const int UiItemCaption = 0;

			// Token: 0x0403C86E RID: 247918
			public const int UiItemBtnReward = 1;

			// Token: 0x0403C86F RID: 247919
			public const int UiItemBtnShop = 2;

			// Token: 0x0403C870 RID: 247920
			public const int BtnSkillTree = 3;

			// Token: 0x0403C871 RID: 247921
			public const int BtnAchieve = 4;

			// Token: 0x0403C872 RID: 247922
			public const int PnlEquippment = 5;

			// Token: 0x0403C873 RID: 247923
			public const int BtnEntrance = 6;

			// Token: 0x0403C874 RID: 247924
			public const int PnlLight = 7;

			// Token: 0x0403C875 RID: 247925
			public const int PnlDark = 8;

			// Token: 0x0403C876 RID: 247926
			public const int TxtTime = 9;

			// Token: 0x0403C877 RID: 247927
			public const int PnlLightMale = 10;

			// Token: 0x0403C878 RID: 247928
			public const int PnlLightFemale = 11;

			// Token: 0x0403C879 RID: 247929
			public const int PnlDarkMale = 12;

			// Token: 0x0403C87A RID: 247930
			public const int PnlDarkFemale = 13;
		}
	}
}
