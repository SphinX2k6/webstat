using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.RoleDevelop;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061B1 RID: 25009
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class NewSoundDetectItem : GridProxyAbstract<NewSoundDetectItemData>
	{
		// Token: 0x0603F234 RID: 258612 RVA: 0x010321D0 File Offset: 0x010303D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
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
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickLockBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F235 RID: 258613 RVA: 0x01032450 File Offset: 0x01030650
		protected override UniTask OnBeforeStartAsync()
		{
			NewSoundDetectItem.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<NewSoundDetectItem.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F236 RID: 258614 RVA: 0x01032494 File Offset: 0x01030694
		public void SyncStart()
		{
			this.ConfirmButton = new ButtonItem(null);
			this.ConfirmButton.CreateThenShowByActor(base.GetItem(1).GetOwner(), null);
			this.ConfirmButton.SetFunction(new Action<int>(this.OnTrackClick));
			this.LevelSequencePlay = new LevelSequencePlayer(this.RootItem);
			this.RewardScroll = new GenericScrollViewNew<NewSoundDetectRewardItem, INewSoundDetectRewardItemData>(base.GetScrollViewWithScrollbar(0), new Func<NewSoundDetectRewardItem>(this.OnRewardLayoutUpdater), null, false, null);
			this.NewSoundLordItem = new NewSoundLordItem();
			this.NewSoundNormalItem = new NewSoundNormalItem();
			this.NewSoundTeachItem = new NewSoundTeachItem();
			this.NewSoundTowerItem = new NewSoundTowerItem();
			this.NewSoundWeeklyRogueItem = new NewSoundWeeklyRogueItem();
			this.NewSoundVisionItem = new NewSoundVisionItem();
			this.NewSoundNoSoundAreaItem = new NewSoundNoSoundAreaItem();
			this.ItemRoleBadge = new RoleDevelopItemRoleBadge();
			this.NewSoundLordItem.CreateByActor(base.GetItem(2).GetOwner(), null);
			this.NewSoundNormalItem.CreateByActor(base.GetItem(5).GetOwner(), null);
			this.NewSoundTeachItem.CreateByActor(base.GetItem(4).GetOwner(), null);
			this.NewSoundTowerItem.CreateByActor(base.GetItem(3).GetOwner(), null);
			this.NewSoundWeeklyRogueItem.CreateByActor(base.GetItem(10).GetOwner(), null);
			this.NewSoundVisionItem.CreateByActor(base.GetItem(13).GetOwner(), null);
			this.NewSoundNoSoundAreaItem.CreateByActor(base.GetItem(14).GetOwner(), null);
			this.ItemRoleBadge.CreateByActor(base.GetItem(15).GetOwner(), null);
		}

		// Token: 0x0603F237 RID: 258615 RVA: 0x0103262A File Offset: 0x0103082A
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.NewSoundAreaRefreshReward, new Action<int>(this.NewSoundAreaRefreshReward));
		}

		// Token: 0x0603F238 RID: 258616 RVA: 0x01032648 File Offset: 0x01030848
		[NullableContext(1)]
		private NewSoundDetectRewardItem OnRewardLayoutUpdater()
		{
			return new NewSoundDetectRewardItem();
		}

		// Token: 0x0603F239 RID: 258617 RVA: 0x01032650 File Offset: 0x01030850
		[NullableContext(1)]
		private void TryPlayTrackSequence(NewSoundDetectItemData data)
		{
			List<int> tracingList = data.TracingList;
			if (tracingList != null && tracingList.Contains(data.DetectRecordData.Id))
			{
				LevelSequencePlayer levelSequencePlay = this.LevelSequencePlay;
				if (levelSequencePlay == null)
				{
					return;
				}
				levelSequencePlay.PlayLevelSequenceByName("Track", false, null, false);
			}
		}

		// Token: 0x0603F23A RID: 258618 RVA: 0x0103269C File Offset: 0x0103089C
		[NullableContext(1)]
		public override void Refresh(NewSoundDetectItemData sourceData, bool isSelected, int gridIndex)
		{
			SoundAreaDetectionRecord detectRecordData = sourceData.DetectRecordData;
			this.Data = detectRecordData;
			UiPanelBase uiPanelBase = this.LeftItem as UiPanelBase;
			if (uiPanelBase != null)
			{
				uiPanelBase.SetUiActive(false);
			}
			EDungeonType secondary = (EDungeonType)detectRecordData.Secondary;
			if (secondary <= EDungeonType.NoSoundArea)
			{
				switch (secondary)
				{
				case EDungeonType.Tower:
					goto IL_8F;
				case EDungeonType.Tutorial:
				{
					NewSoundTeachItem newSoundTeachItem = this.NewSoundTeachItem;
					if (newSoundTeachItem != null)
					{
						newSoundTeachItem.SetUiActive(true);
					}
					this.LeftItem = this.NewSoundTeachItem;
					goto IL_150;
				}
				case EDungeonType.Weekly:
					break;
				default:
					if (secondary != EDungeonType.Boss)
					{
						if (secondary != EDungeonType.NoSoundArea)
						{
							goto IL_132;
						}
						NewSoundNoSoundAreaItem newSoundNoSoundAreaItem = this.NewSoundNoSoundAreaItem;
						if (newSoundNoSoundAreaItem != null)
						{
							newSoundNoSoundAreaItem.SetUiActive(true);
						}
						this.LeftItem = this.NewSoundNoSoundAreaItem;
						goto IL_150;
					}
					break;
				}
				NewSoundVisionItem newSoundVisionItem = this.NewSoundVisionItem;
				if (newSoundVisionItem != null)
				{
					newSoundVisionItem.SetUiActive(true);
				}
				this.LeftItem = this.NewSoundVisionItem;
				goto IL_150;
			}
			if (secondary != EDungeonType.ShipTower)
			{
				if (secondary == EDungeonType.WeeklyRogue)
				{
					NewSoundWeeklyRogueItem newSoundWeeklyRogueItem = this.NewSoundWeeklyRogueItem;
					if (newSoundWeeklyRogueItem != null)
					{
						newSoundWeeklyRogueItem.SetUiActive(true);
					}
					this.LeftItem = this.NewSoundWeeklyRogueItem;
					goto IL_150;
				}
				if (secondary == EDungeonType.LordGym)
				{
					NewSoundLordItem newSoundLordItem = this.NewSoundLordItem;
					if (newSoundLordItem != null)
					{
						newSoundLordItem.SetUiActive(true);
					}
					this.LeftItem = this.NewSoundLordItem;
					goto IL_150;
				}
				goto IL_132;
			}
			IL_8F:
			NewSoundTowerItem newSoundTowerItem = this.NewSoundTowerItem;
			if (newSoundTowerItem != null)
			{
				newSoundTowerItem.SetUiActive(true);
			}
			this.LeftItem = this.NewSoundTowerItem;
			goto IL_150;
			IL_132:
			NewSoundNormalItem newSoundNormalItem = this.NewSoundNormalItem;
			if (newSoundNormalItem != null)
			{
				newSoundNormalItem.SetUiActive(true);
			}
			this.LeftItem = this.NewSoundNormalItem;
			IL_150:
			INewSoundItem leftItem = this.LeftItem;
			if (leftItem != null)
			{
				leftItem.Update(sourceData);
			}
			RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
			bool flag = this.ItemRoleBadge != null && instance != null && instance.DevTargetRoleId != 0 && instance.GetDevelopRoleDeficitDetectionIdSet().Contains(detectRecordData.Id);
			RoleDevelopItemRoleBadge itemRoleBadge = this.ItemRoleBadge;
			if (itemRoleBadge != null)
			{
				itemRoleBadge.SetUiActive(flag);
			}
			if (flag)
			{
				this.ItemRoleBadge.SetRoleHeadIconPath(instance.GetDevelopRoleSmallIconPath());
			}
			bool isDetectionPreOpenByData = ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByData(detectRecordData);
			bool flag3;
			if (!isDetectionPreOpenByData)
			{
				bool? isLock = detectRecordData.IsLock;
				bool flag2 = false;
				flag3 = (isLock.GetValueOrDefault() == flag2 & isLock != null);
			}
			else
			{
				flag3 = true;
			}
			bool flag4 = flag3;
			base.GetItem(7).SetUIActive(false);
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton != null)
			{
				confirmButton.SetUiActive(flag4);
			}
			ButtonItem confirmButton2 = this.ConfirmButton;
			if (confirmButton2 != null)
			{
				confirmButton2.SetLocalTextNew(this.GetConfirmButtonTextId(), Array.Empty<object>());
			}
			if (this.Data.Secondary == 63 || this.Data.Secondary == 64 || this.Data.Secondary == 61)
			{
				base.GetItem(6).SetUIActive(false);
				base.GetItem(11).SetUIActive(!flag4);
			}
			else
			{
				base.GetItem(6).SetUIActive(!flag4);
				base.GetItem(11).SetUIActive(false);
			}
			if (secondary == EDungeonType.Tutorial || secondary == EDungeonType.SkillTeach)
			{
				bool uiactive = ModelBase<AdventureGuideModel>.Instance.IsRoleTutorialNew(detectRecordData.Id) && !ModelBase<AdventureGuideModel>.Instance.IsDetectionFinished(this.Data);
				base.GetItem(9).SetUIActive(uiactive);
			}
			else
			{
				bool flag5 = ModelBase<AdventureGuideModel>.Instance.IsDetectionNewContentOpen(detectRecordData);
				bool flag6 = !isDetectionPreOpenByData && flag5;
				base.GetItem(9).SetUIActive(flag6);
				if (flag6)
				{
					ModelBase<AdventureGuideModel>.Instance.SetAdventureItemNew(detectRecordData.Id);
				}
			}
			InstanceDungeon? instanceDungeon = null;
			int num = 0;
			ESoundAreaDataType? type = detectRecordData.Type;
			ESoundAreaDataType esoundAreaDataType = ESoundAreaDataType.Dungeon;
			if (type.GetValueOrDefault() == esoundAreaDataType & type != null)
			{
				DungeonDetection dungeonDetection = (T1)detectRecordData.Conf.Value;
				if (dungeonDetection.SubDungeonId != 0 && ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(dungeonDetection.SubDungeonId) == null && detectRecordData.Secondary == 6)
				{
					return;
				}
			}
			else
			{
				SilentAreaDetection silentAreaDetection = (T2)detectRecordData.Conf.Value;
				if (detectRecordData.Secondary == 61)
				{
					num = silentAreaDetection.AdditionalId;
				}
			}
			int num2 = 0;
			if (num != 0)
			{
				num2 = ModelBase<LordGymModel>.Instance.GetHasFinishLord(num) + 1;
			}
			num2 = ((num2 != 0) ? num2 : ModelBase<AdventureGuideModel>.Instance.CurrentShowLevel);
			Dictionary<int, int> dictionary = (this.Data.Secondary == 63 || this.Data.Secondary == 64) ? ConfigBase<AdventureGuideConfig>.Instance.GetNightMareShowReward(this.Data.ShowRewardMapCalabash) : ConfigBase<AdventureGuideConfig>.Instance.GetShowReward(detectRecordData.ShowRewardMap, new int?(num2));
			if (dictionary == null)
			{
				return;
			}
			bool haveFinish = ModelBase<AdventureGuideModel>.Instance.IsDetectionFinished(this.Data);
			List<INewSoundDetectRewardItemData> list = new List<INewSoundDetectRewardItemData>();
			foreach (int num3 in dictionary.Keys)
			{
				TItem itemData = new TItem(new InventoryDefine.GetItemData(num3, 0), dictionary[num3]);
				NewSoundDetectRewardItemData item = new NewSoundDetectRewardItemData
				{
					ItemData = itemData,
					HaveFinish = haveFinish
				};
				list.Add(item);
			}
			this.RewardScroll.RefreshByData(list, new Action(this.RewardScrollRefreshCallBack), false);
			this.TryPlayTrackSequence(sourceData);
			int? nightMareParam = sourceData.NightMareParam;
			int id = sourceData.DetectRecordData.Id;
			if (nightMareParam.GetValueOrDefault() == id & nightMareParam != null)
			{
				SoundAreaDetectionRecord detectRecordData2 = sourceData.DetectRecordData;
				if (detectRecordData2 != null && detectRecordData2.IsLock.GetValueOrDefault())
				{
					this.OnClickLockBtn();
				}
			}
		}

		// Token: 0x0603F23B RID: 258619 RVA: 0x01032BD4 File Offset: 0x01030DD4
		private void OnTrackClick(int _)
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
				return;
			}
			if (this.Data.Secondary == 6 || this.Data.Secondary == 62)
			{
				int dungeonId = ((T1)this.Data.Conf.Value).SubDungeonId;
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleTeachTip);
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(((T1)this.Data.Conf.Value).Name, null);
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					localTextNew
				});
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					int fightFormationId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(dungeonId).Value.FightFormationId;
					Aki.Config.FightFormation? fightFormation;
					int[] array2 = (ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId) != null) ? fightFormation.GetValueOrDefault().AutoRole() : null;
					if (((array2 != null) ? array2.Length : 0) <= 0)
					{
						Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.LJQ, "未配置出战人物", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
					List<int> list = new List<int>();
					foreach (int id in array2)
					{
						list.Add(ConfigBase<RoleConfig>.Instance.GetTrialRoleIdConfigByGroupId(id));
					}
					AdventureGuideCtx adventureGuideCtx = AdventureGuideCtx.Create();
					adventureGuideCtx.DungeonDetectionId = this.Data.Id;
					ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.AdventureGuideCtx = adventureGuideCtx;
					ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(dungeonId, list, 0, 0, null, null);
					if (this.Data.Secondary == 6 || this.Data.Secondary == 62)
					{
						ModelBase<AdventureGuideModel>.Instance.SetRoleTutorialNew(this.Data.Id);
						return;
					}
					ModelBase<AdventureGuideModel>.Instance.SetAdventureItemNew(this.Data.Id);
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (this.Data.Secondary == 29)
			{
				WeeklyRogueData activityData = ModelBase<WeeklyRogueModel>.Instance.ActivityData;
				if (activityData == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.WeeklyRogue, ELogAuthor.LPH, "点击周常肉鸽追踪 活动数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				RogueWeeklyCycle? cycleConfig = activityData.GetCycleConfig();
				WorldMapViewOpenParams param = new WorldMapViewOpenParams
				{
					MarkId = new int?(cycleConfig.Value.MapMark),
					MarkType = EMarkType.SmallTeleport
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WorldMapView, param, null);
				return;
			}
			else
			{
				if (this.Data.Secondary == 61)
				{
					if (ModelBase<OnlineModel>.Instance.GetIsTeamModel())
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_600064_Text", Array.Empty<object>());
						return;
					}
					if (ControllerBase<GameModeController>.Instance.IsInInstance())
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_200172_Text", Array.Empty<object>());
						return;
					}
					int additionalId = ((T2)this.Data.Conf.Value).AdditionalId;
					LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(additionalId);
					if (lordGymEntranceConfig == null)
					{
						return;
					}
					ModelBase<LordGymModel>.Instance.EntranceEntityId = additionalId;
					ModelBase<LordGymModel>.Instance.EntryChallengeId = additionalId;
					int[] array = lordGymEntranceConfig.Value.LordGymList();
					if (array.Length == 0)
					{
						return;
					}
					LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(array[0]);
					if (lordGymConfig == null)
					{
						return;
					}
					if (lordGymConfig.Value.Version == 3)
					{
						ModelBase<LordGymModel>.Instance.SkipBossSelectInFlow = true;
						ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(3924, 0, null);
						return;
					}
					if (lordGymConfig.Value.Version == 1)
					{
						ModelBase<LordGymModel>.Instance.SkipBossSelectInFlow = true;
						ControllerBase<LordGymController>.Instance.OpenLordGymViaGuide(ELordGymVersion.First, additionalId);
						return;
					}
					if (lordGymConfig.Value.Version == 2)
					{
						ModelBase<LordGymModel>.Instance.SkipBossSelectInFlow = true;
						ControllerBase<LordGymController>.Instance.OpenLordGymViaGuide(ELordGymVersion.Second, additionalId);
						return;
					}
					if (lordGymConfig.Value.Version == 4)
					{
						ModelBase<LordGymModel>.Instance.SkipBossSelectInFlow = true;
						ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(3925, 0, null);
						return;
					}
				}
				ESoundAreaDataType? type = this.Data.Type;
				ESoundAreaDataType esoundAreaDataType = ESoundAreaDataType.Dungeon;
				if (type.GetValueOrDefault() == esoundAreaDataType & type != null)
				{
					this.HandleDungeonDetection();
					return;
				}
				this.HandleSilentAreaDetection();
				return;
			}
		}

		// Token: 0x0603F23C RID: 258620 RVA: 0x01032F08 File Offset: 0x01031108
		private void NewSoundAreaRefreshReward(int worldLevel)
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.Secondary == 63 || this.Data.Secondary == 64)
			{
				return;
			}
			Dictionary<int, int> showReward = ConfigBase<AdventureGuideConfig>.Instance.GetShowReward(this.Data.ShowRewardMap, new int?(worldLevel));
			bool haveFinish = ModelBase<AdventureGuideModel>.Instance.IsDetectionFinished(this.Data);
			List<INewSoundDetectRewardItemData> list = new List<INewSoundDetectRewardItemData>();
			foreach (int num in showReward.Keys)
			{
				TItem itemData = new TItem(new InventoryDefine.GetItemData(num, 0), showReward[num]);
				NewSoundDetectRewardItemData item = new NewSoundDetectRewardItemData
				{
					ItemData = itemData,
					HaveFinish = haveFinish
				};
				list.Add(item);
			}
			this.RewardScroll.RefreshByData(list, new Action(this.RewardScrollRefreshCallBack), false);
		}

		// Token: 0x0603F23D RID: 258621 RVA: 0x01033000 File Offset: 0x01031200
		private void RewardScrollRefreshCallBack()
		{
			GenericScrollViewNew<NewSoundDetectRewardItem, INewSoundDetectRewardItemData> rewardScroll = this.RewardScroll;
			TWeakObjectPtr<UUIItem>? tweakObjectPtr;
			if (((rewardScroll != null) ? ((rewardScroll.ContentItem != null) ? tweakObjectPtr.GetValueOrDefault().Get() : null) : null) != null)
			{
				GenericScrollViewNew<NewSoundDetectRewardItem, INewSoundDetectRewardItemData> rewardScroll2 = this.RewardScroll;
				if (rewardScroll2 == null)
				{
					return;
				}
				rewardScroll2.ScrollToLeft(0);
			}
		}

		// Token: 0x0603F23E RID: 258622 RVA: 0x01033054 File Offset: 0x01031254
		private void HandleDungeonDetection()
		{
			if (ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByData(this.Data))
			{
				this.HandlePreOpenDetection();
				return;
			}
			if (ModelBase<AdventureGuideModel>.Instance.TryAdventureJumpByDungeon(this.Data.DungeonDetectionRecord))
			{
				return;
			}
			DungeonDetectionRecord soundAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSoundAreaDetectData(this.Data.Id);
			int jumpType = ((T1)this.Data.Conf.Value).JumpType;
			int dungeonId = soundAreaDetectData.Conf.DungeonId;
			if (jumpType == 2)
			{
				ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
				ControllerBase<AdventureGuideController>.Instance.RequestForDetection((soundAreaDetectData.Conf.Secondary != 2) ? DetectionType.Dungeon : DetectionType.SilentArea, new int[]
				{
					dungeonId
				}, this.Data.Id);
				return;
			}
			InstanceDungeonEntrance? config = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(dungeonId);
			if (!ControllerBase<AdventureGuideController>.Instance.IsMarkUnlock(config.Value.MarkId))
			{
				return;
			}
			ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
			ControllerBase<AdventureGuideController>.Instance.RequestForDetection((soundAreaDetectData.Conf.Secondary != 2) ? DetectionType.Dungeon : DetectionType.SilentArea, new int[]
			{
				dungeonId
			}, this.Data.Id);
		}

		// Token: 0x0603F23F RID: 258623 RVA: 0x01033188 File Offset: 0x01031388
		private void HandlePreOpenDetection()
		{
			if (ModelBase<OnlineModel>.Instance.GetIsTeamModel())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("CantUseInMultiplayerMode", Array.Empty<object>());
				return;
			}
			bool flag = false;
			PreOpenDetection? preOpenDetectionConf = ModelBase<AdventureGuideModel>.Instance.GetPreOpenDetectionConf(this.Data.Id, this.Data.Type.Value, this.Data.PreOpenId);
			if (preOpenDetectionConf != null)
			{
				flag = preOpenDetectionConf.Value.Spoiler;
			}
			if (flag)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PreOpenSpoilConfirmBox);
				confirmBoxDataNew.FunctionMap.Add(2, new Action(this.HandlePreOpenDetectionConfirmAction));
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.HandlePreOpenDetectionConfirmAction();
		}

		// Token: 0x0603F240 RID: 258624 RVA: 0x0103323C File Offset: 0x0103143C
		private void HandleSilentAreaDetection()
		{
			if (ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByData(this.Data))
			{
				this.HandlePreOpenDetection();
				return;
			}
			if (ModelBase<AdventureGuideModel>.Instance.TryAdventureJumpBySilent(this.Data.SilentAreaDetectionRecord))
			{
				return;
			}
			SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(this.Data.Id);
			if (((T2)this.Data.Conf.Value).JumpType == 2)
			{
				ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
				ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.SilentArea, silentAreaDetectData.Conf.LevelPlayList(), this.Data.Id);
				return;
			}
			if (!ControllerBase<AdventureGuideController>.Instance.IsMarkUnlock(silentAreaDetectData.Conf.MarkId))
			{
				return;
			}
			ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
			ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.SilentArea, silentAreaDetectData.Conf.LevelPlayList(), this.Data.Id);
		}

		// Token: 0x0603F241 RID: 258625 RVA: 0x01033330 File Offset: 0x01031530
		private int? GetMarkIdForJumpType()
		{
			ESoundAreaDataType? type = this.Data.Type;
			ESoundAreaDataType esoundAreaDataType = ESoundAreaDataType.Dungeon;
			if (type.GetValueOrDefault() == esoundAreaDataType & type != null)
			{
				DungeonDetectionRecord soundAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSoundAreaDetectData(this.Data.Id);
				if (soundAreaDetectData == null)
				{
					return null;
				}
				InstanceDungeonEntrance? config = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(soundAreaDetectData.Conf.DungeonId);
				if (config == null)
				{
					return null;
				}
				return new int?(config.Value.MarkId);
			}
			else
			{
				SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(this.Data.Id);
				if (silentAreaDetectData == null)
				{
					return null;
				}
				return new int?(silentAreaDetectData.Conf.MarkId);
			}
		}

		// Token: 0x0603F242 RID: 258626 RVA: 0x01033400 File Offset: 0x01031600
		[NullableContext(1)]
		private string GetConfirmButtonTextId()
		{
			ESoundAreaDataType? type = this.Data.Type;
			ESoundAreaDataType esoundAreaDataType = ESoundAreaDataType.Dungeon;
			int jumpType;
			if (type.GetValueOrDefault() == esoundAreaDataType & type != null)
			{
				jumpType = ((T1)this.Data.Conf.Value).JumpType;
			}
			else
			{
				jumpType = ((T2)this.Data.Conf.Value).JumpType;
			}
			EDetectionJumpType edetectionJumpType = (EDetectionJumpType)jumpType;
			if (edetectionJumpType == EDetectionJumpType.MapMark)
			{
				return "NewSoundDetectGoTo";
			}
			if (edetectionJumpType == EDetectionJumpType.DirectEntrance)
			{
				return "NewSoundDetectDirectChallenge";
			}
			int? markIdForJumpType = this.GetMarkIdForJumpType();
			if (markIdForJumpType != null && ModelBase<MapModel>.Instance.MapMarkIsCanTeleport(markIdForJumpType.Value))
			{
				return "NewSoundDetectDirectChallenge";
			}
			if (!ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByData(this.Data))
			{
				return "NewSoundDetectGoTo";
			}
			return "NewSoundDetectDirectChallenge";
		}

		// Token: 0x0603F243 RID: 258627 RVA: 0x010334D4 File Offset: 0x010316D4
		private void HandlePreOpenDetectionConfirmAction()
		{
			ControllerBase<AdventureGuideController>.Instance.HandlePreOpenDetection(this.Data.Id, this.Data.Type.Value, this.Data.PreOpenId);
		}

		// Token: 0x0603F244 RID: 258628 RVA: 0x01033508 File Offset: 0x01031708
		protected override void OnBeforeDestroy()
		{
			NewSoundLordItem newSoundLordItem = this.NewSoundLordItem;
			if (newSoundLordItem != null)
			{
				newSoundLordItem.Destroy(null);
			}
			NewSoundNormalItem newSoundNormalItem = this.NewSoundNormalItem;
			if (newSoundNormalItem != null)
			{
				newSoundNormalItem.Destroy(null);
			}
			NewSoundTeachItem newSoundTeachItem = this.NewSoundTeachItem;
			if (newSoundTeachItem != null)
			{
				newSoundTeachItem.Destroy(null);
			}
			NewSoundTowerItem newSoundTowerItem = this.NewSoundTowerItem;
			if (newSoundTowerItem != null)
			{
				newSoundTowerItem.Destroy(null);
			}
			NewSoundWeeklyRogueItem newSoundWeeklyRogueItem = this.NewSoundWeeklyRogueItem;
			if (newSoundWeeklyRogueItem != null)
			{
				newSoundWeeklyRogueItem.Destroy(null);
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.NewSoundAreaRefreshReward, new Action<int>(this.NewSoundAreaRefreshReward));
		}

		// Token: 0x0603F245 RID: 258629 RVA: 0x0103358C File Offset: 0x0103178C
		private void OnClickLockBtn()
		{
			List<IActivityConditionData> list = new List<IActivityConditionData>();
			foreach (int conditionId in ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(this.Data.LockCon))
			{
				Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId);
				int accessType = -1;
				if (conditionConfig.Value.AccessId != 0)
				{
					accessType = ConfigBase<GetWayConfig>.Instance.GetConfigById(conditionConfig.Value.AccessId).Value.SkipName;
				}
				ActivityConditionData item = new ActivityConditionData
				{
					ConditionId = conditionId,
					ConditionTextId = conditionConfig.Value.Description,
					IsFinished = false,
					AccessId = conditionConfig.Value.AccessId,
					AccessType = accessType
				};
				list.Add(item);
			}
			ConditionGroupData param = new ConditionGroupData(this.Data.LockCon, list, null, false);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
		}

		// Token: 0x0402372A RID: 145194
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<NewSoundDetectRewardItem, INewSoundDetectRewardItemData> RewardScroll;

		// Token: 0x0402372B RID: 145195
		private SoundAreaDetectionRecord Data;

		// Token: 0x0402372C RID: 145196
		private ButtonItem ConfirmButton;

		// Token: 0x0402372D RID: 145197
		private INewSoundItem LeftItem;

		// Token: 0x0402372E RID: 145198
		private NewSoundLordItem NewSoundLordItem;

		// Token: 0x0402372F RID: 145199
		private NewSoundNormalItem NewSoundNormalItem;

		// Token: 0x04023730 RID: 145200
		private NewSoundTeachItem NewSoundTeachItem;

		// Token: 0x04023731 RID: 145201
		private NewSoundTowerItem NewSoundTowerItem;

		// Token: 0x04023732 RID: 145202
		private NewSoundWeeklyRogueItem NewSoundWeeklyRogueItem;

		// Token: 0x04023733 RID: 145203
		private NewSoundVisionItem NewSoundVisionItem;

		// Token: 0x04023734 RID: 145204
		private NewSoundNoSoundAreaItem NewSoundNoSoundAreaItem;

		// Token: 0x04023735 RID: 145205
		private LevelSequencePlayer LevelSequencePlay;

		// Token: 0x04023736 RID: 145206
		private RoleDevelopItemRoleBadge ItemRoleBadge;
	}
}
