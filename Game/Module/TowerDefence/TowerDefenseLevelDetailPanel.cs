using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ECB RID: 20171
	[NullableContext(2)]
	[Nullable(0)]
	public class TowerDefenseLevelDetailPanel : UiPanelBase
	{
		// Token: 0x060341AB RID: 213419 RVA: 0x00D05764 File Offset: 0x00D03964
		protected unsafe override void OnRegisterComponent()
		{
			int num = 21;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnBuffTips));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnClickBtnBestRecord));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060341AC RID: 213420 RVA: 0x00D05AB0 File Offset: 0x00D03CB0
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseLevelDetailPanel.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseLevelDetailPanel.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060341AD RID: 213421 RVA: 0x00D05AF4 File Offset: 0x00D03CF4
		protected override void OnStart()
		{
			this.ElementScroll = new GenericScrollViewNew<TowerDefenseLevelDetailElementItem, string>(base.GetScrollViewWithScrollbar(5), () => new TowerDefenseLevelDetailElementItem(), null, false, null);
			this.PhantomScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(8), () => new CommonItemSmallItemGrid(), null, false, null);
			this.BossScroll = new GenericScrollViewNew<TowerDefenseLevelBossItem, int>(base.GetScrollViewWithScrollbar(11), () => new TowerDefenseLevelBossItem(), null, false, null);
			this.MultiChallengeBtn = new ButtonItem(base.GetItem(18));
			this.MultiChallengeBtn.SetFunction(delegate(int _)
			{
				this.OnClickBtnMultiChallenge();
			});
			this.SingleChallengeBtn = new ButtonItem(base.GetItem(19));
			this.SingleChallengeBtn.SetFunction(delegate(int _)
			{
				this.OnClickBtnSingleChallenge();
			});
		}

		// Token: 0x060341AE RID: 213422 RVA: 0x00D05BF4 File Offset: 0x00D03DF4
		public void RefreshItem(int instanceId)
		{
			this.CurrentInstanceId = instanceId;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), config.Value.MapName, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.Value.DungeonDesc, Array.Empty<object>());
			}
			TowerDefenceInstance? towerDefenseInstanceByInstance = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(instanceId);
			bool unlocked = (towerDefenseInstanceByInstance != null) ? ControllerBase<TowerDefenseController>.Instance.CheckStageUnlockById(towerDefenseInstanceByInstance.Value.Id) : ControllerBase<TowerDefenseController>.Instance.CheckIsInstanceUnlock(instanceId);
			this.RefreshLockPanel(instanceId, unlocked);
			TowerDefenseRecommendLevel towerDefenseRecommendLevel = ControllerBase<TowerDefenseController>.Instance.BuildRecommendLevelForInstanceDungeonEntranceData(instanceId);
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIActive(towerDefenseRecommendLevel.Level > 0);
			}
			if (towerDefenseRecommendLevel.Level > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), towerDefenseRecommendLevel.TextId, new <>z__ReadOnlySingleElementList<object>(towerDefenseRecommendLevel.Level));
			}
			this.RefreshBestRecordPanel(instanceId);
			this.RefreshBuffPanel(instanceId);
			this.RefreshPhantomPanel(instanceId);
			this.RefreshBossPanel(instanceId);
		}

		// Token: 0x060341AF RID: 213423 RVA: 0x00D05D24 File Offset: 0x00D03F24
		private void RefreshLockPanel(int instanceId, bool unlocked)
		{
			UUIItem item = base.GetItem(20);
			if (item != null)
			{
				item.SetUIActive(!unlocked);
			}
			this.RefreshChallengeButtonsVisibility(instanceId, unlocked);
			this.RefreshChallengeBtnMatchingState();
			if (unlocked || this.LockPanel == null)
			{
				return;
			}
			this.LockPanel.SetSpriteVisible(true);
			this.LockPanel.SetButtonVisible(false);
			string unlockConditionGroupHintText = ConfigBase<InstanceDungeonConfig>.Instance.GetUnlockConditionGroupHintText(instanceId);
			if (!string.IsNullOrEmpty(unlockConditionGroupHintText))
			{
				this.LockPanel.SetTextByTextId(unlockConditionGroupHintText, Array.Empty<string>());
			}
		}

		// Token: 0x060341B0 RID: 213424 RVA: 0x00D05DA0 File Offset: 0x00D03FA0
		private void RefreshChallengeButtonsVisibility(int instanceId, bool unlocked)
		{
			if (!unlocked)
			{
				this.ShouldShowSingleChallengeBtn = false;
				ButtonItem multiChallengeBtn = this.MultiChallengeBtn;
				if (multiChallengeBtn != null)
				{
					multiChallengeBtn.SetUiActive(false);
				}
				ButtonItem singleChallengeBtn = this.SingleChallengeBtn;
				if (singleChallengeBtn == null)
				{
					return;
				}
				singleChallengeBtn.SetUiActive(false);
				return;
			}
			else
			{
				if (!ModelBase<GameModeModel>.Instance.IsMulti || ModelBase<OnlineModel>.Instance.GetIsMyTeam())
				{
					InstanceDungeon? instanceDungeon;
					InstOnlineType instOnlineType = (ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId) != null) ? instanceDungeon.GetValueOrDefault().OnlineType : InstOnlineType.Single;
					bool isMulti = ModelBase<GameModeModel>.Instance.IsMulti;
					bool uiActive;
					bool flag;
					if (instOnlineType == InstOnlineType.Single)
					{
						uiActive = false;
						flag = true;
					}
					else if (instOnlineType == InstOnlineType.Multi)
					{
						uiActive = true;
						flag = isMulti;
					}
					else
					{
						uiActive = true;
						flag = true;
					}
					this.ShouldShowSingleChallengeBtn = flag;
					ButtonItem multiChallengeBtn2 = this.MultiChallengeBtn;
					if (multiChallengeBtn2 != null)
					{
						multiChallengeBtn2.SetUiActive(uiActive);
					}
					ButtonItem singleChallengeBtn2 = this.SingleChallengeBtn;
					if (singleChallengeBtn2 != null)
					{
						singleChallengeBtn2.SetUiActive(flag);
					}
					if (flag && isMulti)
					{
						ButtonItem singleChallengeBtn3 = this.SingleChallengeBtn;
						if (singleChallengeBtn3 == null)
						{
							return;
						}
						singleChallengeBtn3.SetLocalTextNew("AbyssMPChallenge", Array.Empty<object>());
					}
					return;
				}
				this.ShouldShowSingleChallengeBtn = false;
				ButtonItem multiChallengeBtn3 = this.MultiChallengeBtn;
				if (multiChallengeBtn3 != null)
				{
					multiChallengeBtn3.SetUiActive(false);
				}
				ButtonItem singleChallengeBtn4 = this.SingleChallengeBtn;
				if (singleChallengeBtn4 == null)
				{
					return;
				}
				singleChallengeBtn4.SetUiActive(false);
				return;
			}
		}

		// Token: 0x060341B1 RID: 213425 RVA: 0x00D05EBC File Offset: 0x00D040BC
		public void RefreshChallengeBtnMatchingState()
		{
			bool flag = ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Matching;
			ButtonItem singleChallengeBtn = this.SingleChallengeBtn;
			if (singleChallengeBtn != null)
			{
				singleChallengeBtn.SetUiActive(this.ShouldShowSingleChallengeBtn && !flag);
			}
			ButtonItem multiChallengeBtn = this.MultiChallengeBtn;
			if (multiChallengeBtn != null)
			{
				multiChallengeBtn.SetLocalTextNew(flag ? "MultRacing_Button_Matching" : "MultRacing_Button_Match", Array.Empty<object>());
			}
			ButtonItem multiChallengeBtn2 = this.MultiChallengeBtn;
			if (multiChallengeBtn2 != null)
			{
				multiChallengeBtn2.SetEnableClick(!flag);
			}
			ButtonItem singleChallengeBtn2 = this.SingleChallengeBtn;
			if (singleChallengeBtn2 == null)
			{
				return;
			}
			singleChallengeBtn2.SetEnableClick(!flag);
		}

		// Token: 0x060341B2 RID: 213426 RVA: 0x00D05F48 File Offset: 0x00D04148
		private void RefreshBestRecordPanel(int instanceId)
		{
			TowerDefenseRankGlobalData rankData = ModelBase<TowerDefenseModel>.Instance.RankData;
			UUIItem item = base.GetItem(13);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			if (!rankData.HasOwnRecord(instanceId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "ChallengeOL_Norecord", Array.Empty<object>());
				return;
			}
			string bestRecordText = rankData.GetBestRecordText(instanceId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "ChallengeOL_Bestrecord", new <>z__ReadOnlySingleElementList<object>(bestRecordText));
		}

		// Token: 0x060341B3 RID: 213427 RVA: 0x00D05FC0 File Offset: 0x00D041C0
		private void RefreshBossPanel(int instanceId)
		{
			TowerDefenceInstance? towerDefenseInstanceByInstance = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(instanceId);
			bool flag = towerDefenseInstanceByInstance != null && towerDefenseInstanceByInstance.Value.BossRush;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			List<int> list = new List<int>();
			if (flag && config != null)
			{
				for (int i = 0; i < config.Value.MonsterPreviewLength; i++)
				{
					list.Add(config.Value.MonsterPreview(i));
				}
			}
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(list.Count > 0);
			}
			GenericScrollViewNew<TowerDefenseLevelBossItem, int> bossScroll = this.BossScroll;
			if (bossScroll == null)
			{
				return;
			}
			bossScroll.RefreshByData(list, null, false);
		}

		// Token: 0x060341B4 RID: 213428 RVA: 0x00D06078 File Offset: 0x00D04278
		private void RefreshPhantomPanel(int instanceId)
		{
			TowerDefenceInstance? towerDefenseInstanceByInstance = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(instanceId);
			List<TItem> list = (towerDefenseInstanceByInstance != null && towerDefenseInstanceByInstance.Value.BossRush) ? new List<TItem>() : ControllerBase<TowerDefenseController>.Instance.BuildPhantomForInstanceDungeonEntranceData(instanceId);
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(list.Count > 0);
			}
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> phantomScroll = this.PhantomScroll;
			if (phantomScroll == null)
			{
				return;
			}
			phantomScroll.RefreshByData(list, delegate
			{
				foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.PhantomScroll.GetScrollItemList())
				{
					commonItemSmallItemGrid.SetQuality(null);
					commonItemSmallItemGrid.SetExtendToggleEnable(false, false);
				}
			}, false);
		}

		// Token: 0x060341B5 RID: 213429 RVA: 0x00D060FC File Offset: 0x00D042FC
		private void RefreshBuffPanel(int instanceId)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			string text = (config != null) ? (config.Value.MonsterTips ?? "") : "";
			bool flag = config != null && config.Value.MonsterPreviewLength > 0;
			List<string> list = (from line in text.Split('\n', StringSplitOptions.None)
			where line.Length > 0
			select line).ToList<string>();
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(list.Count > 0 || flag);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "PrefabTextItem_2611535427_Text", Array.Empty<object>());
			UUIButtonComponent button = base.GetButton(4);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(flag);
				}
			}
			GenericScrollViewNew<TowerDefenseLevelDetailElementItem, string> elementScroll = this.ElementScroll;
			if (elementScroll == null)
			{
				return;
			}
			elementScroll.RefreshByData(list, null, false);
		}

		// Token: 0x060341B6 RID: 213430 RVA: 0x00D06200 File Offset: 0x00D04400
		private void OnClickBtnBuffTips()
		{
			if (this.CurrentInstanceId <= 0)
			{
				return;
			}
			InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam param = new InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam
			{
				InstanceId = this.CurrentInstanceId,
				InfoType = new InstanceDungeonBuffItem.EBuffInfoType?(InstanceDungeonBuffItem.EBuffInfoType.Buff)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, param, null);
		}

		// Token: 0x060341B7 RID: 213431 RVA: 0x00D06248 File Offset: 0x00D04448
		private void OnClickBtnBestRecord()
		{
			if (this.CurrentInstanceId <= 0)
			{
				return;
			}
			TowerDefenseRankViewModelV2 towerDefenseRankViewModelV = new TowerDefenseRankViewModelV2();
			towerDefenseRankViewModelV.InstanceId = this.CurrentInstanceId;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerDefenseRankViewV2, towerDefenseRankViewModelV, null);
		}

		// Token: 0x060341B8 RID: 213432 RVA: 0x00D06282 File Offset: 0x00D04482
		private bool GetIsAllowedClickBegin()
		{
			if (this.NextCanClickButtonTime > Singleton<TimeUtil>.Instance.GetServerTimeStamp())
			{
				return false;
			}
			this.NextCanClickButtonTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + 500.0;
			return true;
		}

		// Token: 0x060341B9 RID: 213433 RVA: 0x00D062B4 File Offset: 0x00D044B4
		private bool CheckOnlineChallengeGuard()
		{
			if (!ControllerBase<OnlineController>.Instance.ShowTipsWhenOnlineDisabled(null))
			{
				return false;
			}
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceCanChallenge(this.CurrentInstanceId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonLackChallengeTimes", Array.Empty<object>());
				return false;
			}
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return false;
			}
			if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.Online))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("IsNotOpenOnline", Array.Empty<object>());
				return false;
			}
			if (ControllerBase<InstanceDungeonController>.Instance.IsForbidDungeon(this.CurrentInstanceId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInstanceTip", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x060341BA RID: 213434 RVA: 0x00D0636C File Offset: 0x00D0456C
		private bool CheckSoloChallengeGuard()
		{
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceCanChallenge(this.CurrentInstanceId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonLackChallengeTimes", Array.Empty<object>());
				return false;
			}
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return false;
			}
			if (ControllerBase<InstanceDungeonController>.Instance.IsForbidDungeon(this.CurrentInstanceId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInstanceTip", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x060341BB RID: 213435 RVA: 0x00D063EC File Offset: 0x00D045EC
		private void OnClickBtnMultiChallenge()
		{
			if (this.CurrentInstanceId <= 0 || !this.GetIsAllowedClickBegin())
			{
				return;
			}
			if (!this.CheckOnlineChallengeGuard())
			{
				return;
			}
			ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
			ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = false;
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(this.CurrentInstanceId, false, true);
				return;
			}
			int currentTeamSize = ModelBase<OnlineModel>.Instance.GetCurrentTeamSize();
			if (currentTeamSize <= 1)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(this.CurrentInstanceId, false, true);
				return;
			}
			if (currentTeamSize < ModelBase<OnlineModel>.Instance.TeamMaxSize)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InstanceDungeonMatchStart);
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(this.CurrentInstanceId, true, true);
				};
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(this.CurrentInstanceId, false, true);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CanNotMatching", Array.Empty<object>());
		}

		// Token: 0x060341BC RID: 213436 RVA: 0x00D064E0 File Offset: 0x00D046E0
		private void OnClickBtnSingleChallenge()
		{
			if (this.CurrentInstanceId <= 0 || !this.GetIsAllowedClickBegin())
			{
				return;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				if (!this.CheckOnlineChallengeGuard())
				{
					return;
				}
				ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
				ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = false;
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingId(this.CurrentInstanceId);
				if (ModelBase<OnlineModel>.Instance.GetCurrentTeamSize() <= 1)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(this.CurrentInstanceId, false);
					return;
				}
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InstanceDungeonMultiStart);
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(this.CurrentInstanceId, true);
				};
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(this.CurrentInstanceId, false);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			else
			{
				if (!this.CheckSoloChallengeGuard())
				{
					return;
				}
				ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = false;
				ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = false;
				ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = this.CurrentInstanceId;
				ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
				return;
			}
		}

		// Token: 0x0401E17B RID: 123259
		private const int CLICK_INSTANCE_BEGIN_BUTTON_CD = 500;

		// Token: 0x0401E17C RID: 123260
		private int CurrentInstanceId;

		// Token: 0x0401E17D RID: 123261
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<TowerDefenseLevelDetailElementItem, string> ElementScroll;

		// Token: 0x0401E17E RID: 123262
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> PhantomScroll;

		// Token: 0x0401E17F RID: 123263
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<TowerDefenseLevelBossItem, int> BossScroll;

		// Token: 0x0401E180 RID: 123264
		private FunctionalPanelConditionLock LockPanel;

		// Token: 0x0401E181 RID: 123265
		private ButtonItem MultiChallengeBtn;

		// Token: 0x0401E182 RID: 123266
		private ButtonItem SingleChallengeBtn;

		// Token: 0x0401E183 RID: 123267
		private bool ShouldShowSingleChallengeBtn;

		// Token: 0x0401E184 RID: 123268
		private double NextCanClickButtonTime;

		// Token: 0x0200AE6C RID: 44652
		[NullableContext(0)]
		private class ELevelDetailComponent
		{
			// Token: 0x04036264 RID: 221796
			public const int TitleTxt = 0;

			// Token: 0x04036265 RID: 221797
			public const int TopDescTxt = 1;

			// Token: 0x04036266 RID: 221798
			public const int BuffPnl = 2;

			// Token: 0x04036267 RID: 221799
			public const int BuffTitleTxt = 3;

			// Token: 0x04036268 RID: 221800
			public const int BuffTipsBtn = 4;

			// Token: 0x04036269 RID: 221801
			public const int ElementScorll = 5;

			// Token: 0x0403626A RID: 221802
			public const int ElementItem = 6;

			// Token: 0x0403626B RID: 221803
			public const int PhantomPnl = 7;

			// Token: 0x0403626C RID: 221804
			public const int PhantomScroll = 8;

			// Token: 0x0403626D RID: 221805
			public const int PhantomItem = 9;

			// Token: 0x0403626E RID: 221806
			public const int BossPnl = 10;

			// Token: 0x0403626F RID: 221807
			public const int BossScroll = 11;

			// Token: 0x04036270 RID: 221808
			public const int BossItem = 12;

			// Token: 0x04036271 RID: 221809
			public const int BestRecordPnl = 13;

			// Token: 0x04036272 RID: 221810
			public const int BestRecordBtn = 14;

			// Token: 0x04036273 RID: 221811
			public const int BestRecordTxt = 15;

			// Token: 0x04036274 RID: 221812
			public const int LevelTipsPnl = 16;

			// Token: 0x04036275 RID: 221813
			public const int LevelTipsTxt = 17;

			// Token: 0x04036276 RID: 221814
			public const int MultiChallengeBtn = 18;

			// Token: 0x04036277 RID: 221815
			public const int SingleChallengeBtn = 19;

			// Token: 0x04036278 RID: 221816
			public const int LockPnl = 20;
		}
	}
}
