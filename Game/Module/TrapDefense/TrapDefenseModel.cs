using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.KeySetting;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DFF RID: 19967
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class TrapDefenseModel : ModelBase<TrapDefenseModel>
	{
		// Token: 0x060339DB RID: 211419 RVA: 0x00CE50B4 File Offset: 0x00CE32B4
		public TrapDefenseModel()
		{
			this.ViewModelBdSum = TrapDefenseBdSumViewModel.Create(this);
			this.ViewModelBdQuality = TrapDefenseBdQualityViewModel.Create(this);
			this.ViewModeBdBuffSelect = TrapDefenseBdBuffSelectViewModel.Create(this);
			this.ViewModelReward = TrapDefenseRewardViewModel.Create();
			this.ViewModelMonster = TrapDefenseMonsterViewModel.Create(this);
			this.ViewModelTalentTree = TrapDefenseTalentTreeViewModel.Create();
			this.ViewModelFixedReward = TrapDefenseFixedRewardViewModel.Create(this);
			this.ViewModelMainLevel = TrapDefenseMainLevelViewModel.Create(this);
			this.ViewModelRougeLevel = TrapDefenseRougeLevelViewModel.Create(this);
			this.ViewModelShop = TrapDefenseShopViewModel.Create();
			this.BattleData = TrapDefenseBattleData.Create();
			this.MapData = TrapDefenseMapModel.Create();
			this.ShopData = TrapDefenseShopData.Create();
			this.BattleInventoryData = TrapDefenseBattleInventoryData.Create();
			this.ViewModelBuildingDevelop = TrapDefenseBuildingDevelopViewModel.Create(this);
		}

		// Token: 0x060339DC RID: 211420 RVA: 0x00CE5198 File Offset: 0x00CE3398
		protected override bool OnInit()
		{
			this.AddOpenViewCheck(EUiViewName.TrapDefenseMainLevelView, null);
			this.AddOpenViewCheck(EUiViewName.TrapDefenseRougeLevelView, new Func<EUiViewName, object, bool>(this.CheckCanOpenRougeMode));
			this.AddOpenViewCheck(EUiViewName.TrapDefenseFixedRewardView, null);
			this.AddOpenViewCheck(EUiViewName.TrapDefenseBdSumView, null);
			this.AddOpenViewCheck(EUiViewName.TrapDefenseBdQualityView, null);
			this.AddOpenViewCheck(EUiViewName.TrapDefenseBdBuffSelectView, null);
			this.AddOpenViewCheck(EUiViewName.TrapDefenseBdBuffGetView, null);
			this.AddOpenViewCheck(EUiViewName.TrapDefenseBdBuffStrengthenView, null);
			return true;
		}

		// Token: 0x060339DD RID: 211421 RVA: 0x00CE5214 File Offset: 0x00CE3414
		protected override bool OnClear()
		{
			foreach (KeyValuePair<EUiViewName, Func<EUiViewName, object, bool>> keyValuePair in this.CheckCanOpenViewMap)
			{
				Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(keyValuePair.Key, keyValuePair.Value);
			}
			this.BattleData.Clear();
			return true;
		}

		// Token: 0x060339DE RID: 211422 RVA: 0x00CE5284 File Offset: 0x00CE3484
		protected override bool OnLeaveLevel()
		{
			this.BattleData.Clear();
			return true;
		}

		// Token: 0x060339DF RID: 211423 RVA: 0x00CE5294 File Offset: 0x00CE3494
		private void AddOpenViewCheck(EUiViewName name, [Nullable(new byte[]
		{
			2,
			1
		})] Func<EUiViewName, object, bool> checkFun = null)
		{
			Func<EUiViewName, object, bool> func = checkFun ?? new Func<EUiViewName, object, bool>(this.CheckCanOpen);
			UiManager instance = Singleton<UiManager>.Instance;
			Func<EUiViewName, object, bool> func2 = func;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendFormatted<EUiViewName>(name);
			defaultInterpolatedStringHandler.AppendLiteral(".CheckCanOpen");
			instance.AddOpenViewCheckFunction(name, func2, defaultInterpolatedStringHandler.ToStringAndClear());
			this.CheckCanOpenViewMap[name] = func;
		}

		// Token: 0x170088C2 RID: 35010
		// (get) Token: 0x060339E0 RID: 211424 RVA: 0x00CE52F1 File Offset: 0x00CE34F1
		public bool NeedOpenActivityMainView
		{
			get
			{
				bool needOpenMainView = this.NeedOpenMainView;
				this.NeedOpenMainView = false;
				return needOpenMainView;
			}
		}

		// Token: 0x060339E1 RID: 211425 RVA: 0x00CE5300 File Offset: 0x00CE3500
		private bool CheckCanOpen(EUiViewName viewName, object _)
		{
			if (this.LevelModeData == null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_2500068_Text", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x060339E2 RID: 211426 RVA: 0x00CE5321 File Offset: 0x00CE3521
		private bool CheckCanOpenRougeMode(EUiViewName viewName, object _)
		{
			if (!this.CheckCanOpen(viewName, _))
			{
				return false;
			}
			if (!this.RougeModeData.CanEnterRougeMode())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(ETrapDefenseTextKey.RougeModeNotOpen.ToString(), Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x060339E3 RID: 211427 RVA: 0x00CE5360 File Offset: 0x00CE3560
		public void InitData(int? id = null)
		{
			int num = id ?? this.GetActivityId();
			TrapDefenseLevelModeData levelModeData = this.LevelModeData;
			if (levelModeData != null && levelModeData.ActivityId == num)
			{
				return;
			}
			this.LevelModeData = TrapDefenseLevelModeDataBase.Create<TrapDefenseLevelModeData>(num);
			this.RougeModeData = TrapDefenseLevelModeDataBase.Create<TrapDefenseRougeModeData>(num);
			this.RewardData = TrapDefenseRewardData.Create(num);
			this.TalentTreeData = TrapDefenseTalentTreeData.Create(num);
			this.LevelModeData.LevelDataList.Clear();
			this.RougeModeData.LevelDataList.Clear();
			this.LevelDataFromInstIdMap.Clear();
			this.LevelDataFromIdMap.Clear();
			foreach (TrapDefenseActivity levelConfig in ConfigBase<TrapDefenseConfig>.Instance.GetLevelListByActivityId(num))
			{
				TrapDefenseLevelData trapDefenseLevelData = this.AddLevelConfigToMode(levelConfig);
				this.LevelDataFromInstIdMap[trapDefenseLevelData.Config.InstId] = trapDefenseLevelData;
				this.LevelDataFromIdMap[trapDefenseLevelData.Config.Id] = trapDefenseLevelData;
			}
			this.LevelModeData.SortLevelDataList();
			this.RougeModeData.SortLevelDataList();
		}

		// Token: 0x060339E4 RID: 211428 RVA: 0x00CE5498 File Offset: 0x00CE3698
		public void UpdateActivityData(TrapDefenseActivityInfo data)
		{
			foreach (TrapDefenseChallengeInfo trapDefenseChallengeInfo in data.Challenges)
			{
				TrapDefenseLevelData trapDefenseLevelData;
				if (this.LevelDataFromIdMap.TryGetValue(trapDefenseChallengeInfo.ChallengeId, out trapDefenseLevelData))
				{
					trapDefenseLevelData.ProtoUpdateData(trapDefenseChallengeInfo);
				}
			}
			foreach (int key in data.UnlockBds)
			{
				TrapDefenseBdData trapDefenseBdData;
				if (this.RougeModeData.BdDataMap.TryGetValue(key, out trapDefenseBdData) && trapDefenseBdData != null)
				{
					trapDefenseBdData.SetUnlock(true);
				}
			}
			foreach (int key2 in data.UnlockBdGroups)
			{
				TrapDefenseBdBuffData trapDefenseBdBuffData;
				if (this.RougeModeData.BdBuffDataMap.TryGetValue(key2, out trapDefenseBdBuffData) && trapDefenseBdBuffData != null)
				{
					trapDefenseBdBuffData.SetUnlock(true);
				}
			}
			this.ViewModelBuildingDevelop.InitDevelopInfo(data);
			this.ViewModelBuildingDevelop.SetRemainPoints(data.LeftLevelUpPoint);
			TrapDefenseRewardData rewardData = this.RewardData;
			if (rewardData != null)
			{
				rewardData.UpdateRewardsByServerData(new List<TrapDefenseRewardInfo>(data.Rewards).ToArray());
			}
			this.RewardData.SetLimitTime(data.LimitBeginTime, data.LimitEndTime);
			TrapDefenseSpecialRewardData specialRewardData = this.RewardData.SpecialRewardData;
			if (specialRewardData != null)
			{
				specialRewardData.UpdateByServerData(data.SpecialRewards[0]);
			}
			foreach (int key3 in data.UnlockTechNodes)
			{
				TrapDefenseTalentTreeData talentTreeData = this.TalentTreeData;
				TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData;
				if (talentTreeData != null && talentTreeData.NodeIdMap.TryGetValue(key3, out trapDefenseTalentTreeNodeData) && trapDefenseTalentTreeNodeData != null)
				{
					trapDefenseTalentTreeNodeData.SetUnlock();
				}
			}
			TrapDefenseTalentTreeData talentTreeData2 = this.TalentTreeData;
			if (talentTreeData2 != null)
			{
				talentTreeData2.SetRemainPoints(data.LeftTechPoint);
			}
			TrapDefenseTalentTreeData talentTreeData3 = this.TalentTreeData;
			if (talentTreeData3 != null)
			{
				talentTreeData3.SetMaxPoints(data.TotalTechPoint);
			}
			TrapDefenseTalentTreeData talentTreeData4 = this.TalentTreeData;
			if (talentTreeData4 != null)
			{
				talentTreeData4.RefreshLineTypeMap();
			}
			this.MapData.InitMapData();
			this.ShopData.TryUpdateData();
			this.TryUpdateBdBuffAllUpdateNotify();
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseActivityDataUpdate);
		}

		// Token: 0x060339E5 RID: 211429 RVA: 0x00CE56EC File Offset: 0x00CE38EC
		private TrapDefenseLevelData AddLevelConfigToMode(TrapDefenseActivity levelConfig)
		{
			ETrapDefenseLevelType modeType = (ETrapDefenseLevelType)levelConfig.ModeType;
			if (modeType == ETrapDefenseLevelType.Mainline)
			{
				return this.LevelModeData.AddLevelConfig(levelConfig);
			}
			if (modeType - ETrapDefenseLevelType.RougeNormal > 1)
			{
				return this.LevelModeData.AddLevelConfig(levelConfig);
			}
			return this.RougeModeData.AddLevelConfig(levelConfig);
		}

		// Token: 0x060339E6 RID: 211430 RVA: 0x00CE5734 File Offset: 0x00CE3934
		public ITrapDefenseMachineIdInfo DecomposeMachineId(int id)
		{
			int branch = id % 100;
			int level = (int)Math.Floor((double)id / 100.0) % 100;
			int dataType = (int)Math.Floor((double)id / 10000.0) % 100;
			int machineType = (int)Math.Floor((double)id / 1000000.0) % 100;
			return new ITrapDefenseMachineIdInfo
			{
				MachineType = (ETrapDefenseMachineType)machineType,
				DataType = dataType,
				Level = level,
				Branch = branch
			};
		}

		// Token: 0x060339E7 RID: 211431 RVA: 0x00CE57A9 File Offset: 0x00CE39A9
		public int ComposeMachineId(ITrapDefenseMachineIdInfo info)
		{
			return (int)(info.MachineType * (ETrapDefenseMachineType)1000000 + info.DataType * 10000 + info.Level * 100 + info.Branch);
		}

		// Token: 0x060339E8 RID: 211432 RVA: 0x00CE57D8 File Offset: 0x00CE39D8
		public int GetActivityId()
		{
			ActivityTrapDefenseController instance = ControllerBase<ActivityTrapDefenseController>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				ActivityTrapDefenseData data = instance.Data;
				num = ((data != null) ? new int?(data.Id) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x060339E9 RID: 211433 RVA: 0x00CE5820 File Offset: 0x00CE3A20
		[NullableContext(2)]
		public TrapDefenseLevelData GetCurInstToLevelData()
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			TrapDefenseLevelData result;
			if (!this.LevelDataFromInstIdMap.TryGetValue(instanceId, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060339EA RID: 211434 RVA: 0x00CE584C File Offset: 0x00CE3A4C
		[return: Nullable(2)]
		public TrapDefenseLevelData GetNextLevelData(TrapDefenseLevelData data)
		{
			int nextId = data.Config.NextId;
			if (nextId == 0)
			{
				return null;
			}
			TrapDefenseLevelData result;
			if (!this.LevelDataFromIdMap.TryGetValue(nextId, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060339EB RID: 211435 RVA: 0x00CE5880 File Offset: 0x00CE3A80
		public TrapDefenseWave? GetCurrentBatchData()
		{
			TrapDefenseLevelData curInstToLevelData = this.GetCurInstToLevelData();
			if (curInstToLevelData == null)
			{
				return null;
			}
			int batch = this.BattleData.GetBatch();
			IReadOnlyList<TrapDefenseWave> trapDefenseWavesByLevelId = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseWavesByLevelId(curInstToLevelData.Config.Id);
			return new TrapDefenseWave?((batch > 0 && batch <= trapDefenseWavesByLevelId.Count) ? trapDefenseWavesByLevelId[batch - 1] : trapDefenseWavesByLevelId[0]);
		}

		// Token: 0x060339EC RID: 211436 RVA: 0x00CE58E8 File Offset: 0x00CE3AE8
		public bool GetCurInstIsRogue()
		{
			TrapDefenseLevelData curInstToLevelData = this.GetCurInstToLevelData();
			return curInstToLevelData != null && curInstToLevelData.Config.ModeType != 1;
		}

		// Token: 0x060339ED RID: 211437 RVA: 0x00CE5914 File Offset: 0x00CE3B14
		public bool IsInMainline()
		{
			TrapDefenseLevelData curInstToLevelData = this.GetCurInstToLevelData();
			return curInstToLevelData != null && curInstToLevelData.Config.ModeType == 1;
		}

		// Token: 0x060339EE RID: 211438 RVA: 0x00CE593C File Offset: 0x00CE3B3C
		public bool GetCurInstToLevelDataHasShop()
		{
			TrapDefenseLevelData curInstToLevelData = this.GetCurInstToLevelData();
			return curInstToLevelData != null && curInstToLevelData.HasShop;
		}

		// Token: 0x060339EF RID: 211439 RVA: 0x00CE595B File Offset: 0x00CE3B5B
		public void BdBuffSelectProcessFinish()
		{
			this.ViewModeBdBuffSelect.ViewProcessFinish();
			this.CheckIsNeedOpenBdBuffSelectView();
		}

		// Token: 0x060339F0 RID: 211440 RVA: 0x00CE5970 File Offset: 0x00CE3B70
		public void CheckIsNeedOpenBdBuffSelectView()
		{
			if (this.ViewModeBdBuffSelect.ShowingViewProcess)
			{
				return;
			}
			if (this.ViewModeBdBuffSelect.BackupIdList.Count <= 0)
			{
				return;
			}
			List<int> collection = this.ViewModeBdBuffSelect.BackupIdList[0];
			this.ViewModeBdBuffSelect.BackupIdList.RemoveAt(0);
			this.OpenViewBdBuffSelect(new List<int>(collection), null);
		}

		// Token: 0x060339F1 RID: 211441 RVA: 0x00CE59D8 File Offset: 0x00CE3BD8
		public int GetAllGetStarByLevel()
		{
			int num = 0;
			foreach (TrapDefenseLevelData trapDefenseLevelData in this.LevelModeData.LevelDataList)
			{
				num += trapDefenseLevelData.ReachTargetIndexList.Count;
			}
			int num2 = 0;
			foreach (TrapDefenseLevelData trapDefenseLevelData2 in this.RougeModeData.LevelDataList)
			{
				num2 += trapDefenseLevelData2.ReachTargetIndexList.Count;
			}
			return num + num2;
		}

		// Token: 0x060339F2 RID: 211442 RVA: 0x00CE5A90 File Offset: 0x00CE3C90
		public void OpenViewBdSum(bool? isInInstance = null, ETrapDefenseBdTabType? jumpTab = null, int? jumpId = null)
		{
			bool isInstance = isInInstance ?? ControllerBase<TowerDefenseEventController>.Instance.IsTowerDefenseEventInstance();
			this.ViewModelBdSum.SetIsInstance(isInstance);
			this.ViewModelBdSum.SetJumpTabType(jumpTab);
			this.ViewModelBdSum.SetJumpBdId(jumpId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBdSumView, null, null);
		}

		// Token: 0x060339F3 RID: 211443 RVA: 0x00CE5AF4 File Offset: 0x00CE3CF4
		public void OpenViewBdQuality(int bdId, ETrapDefenseBdBuffQuality? quality = null, bool? isNew = null, int? bdBuffId = null)
		{
			TrapDefenseBdData trapDefenseBdData;
			TrapDefenseBdData curSelectBdData = this.RougeModeData.BdDataMap.TryGetValue(bdId, out trapDefenseBdData) ? trapDefenseBdData : this.RougeModeData.BdDataList[0];
			TrapDefenseBdBuffData trapDefenseBdBuffData;
			TrapDefenseBdBuffData curSelectBdBuffData = (bdBuffId != null && this.RougeModeData.BdBuffDataMap.TryGetValue(bdBuffId.Value, out trapDefenseBdBuffData)) ? trapDefenseBdBuffData : null;
			this.ViewModelBdQuality.SetCurSelectBdData(curSelectBdData);
			this.ViewModelBdQuality.SetCurSelectBdBuffData(curSelectBdBuffData);
			this.ViewModelBdQuality.SetNewQualityMode(isNew.GetValueOrDefault());
			this.ViewModelBdQuality.SetShowQuality(quality);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBdQualityView, null, null);
		}

		// Token: 0x060339F4 RID: 211444 RVA: 0x00CE5B9B File Offset: 0x00CE3D9B
		public bool OpenViewBdBuffSelect(List<int> idList, int? selectId = null)
		{
			if (idList.Count <= 0)
			{
				return false;
			}
			this.ViewModeBdBuffSelect.SetBuffList(new List<int>(idList), selectId);
			this.ViewModeBdBuffSelect.OnOpenView();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBdBuffSelectView, null, null);
			return true;
		}

		// Token: 0x060339F5 RID: 211445 RVA: 0x00CE5BD8 File Offset: 0x00CE3DD8
		public void OpenViewBdBuffNewGet(int buffId, bool isCheckBdProgress = true)
		{
			TrapDefenseBdBuffData trapDefenseBdBuffData;
			TrapDefenseBdBuffData lastGetBdBuffData = this.RougeModeData.BdBuffDataMap.TryGetValue(buffId, out trapDefenseBdBuffData) ? trapDefenseBdBuffData : this.RougeModeData.BdBuffDataList[0];
			this.RougeModeData.SetLastGetBdBuffData(lastGetBdBuffData);
			this.RougeModeData.SetIsCheckBdProgress(isCheckBdProgress);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBdBuffGetView, null, null);
		}

		// Token: 0x060339F6 RID: 211446 RVA: 0x00CE5C38 File Offset: 0x00CE3E38
		public void OpenViewBdBuffStrengthen(int buffId, bool isCheckBdProgress = true)
		{
			TrapDefenseBdBuffData trapDefenseBdBuffData;
			TrapDefenseBdBuffData lastGetBdBuffData = this.RougeModeData.BdBuffDataMap.TryGetValue(buffId, out trapDefenseBdBuffData) ? trapDefenseBdBuffData : this.RougeModeData.BdBuffDataList[0];
			this.RougeModeData.SetLastGetBdBuffData(lastGetBdBuffData);
			this.RougeModeData.SetIsCheckBdProgress(isCheckBdProgress);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBdBuffStrengthenView, null, null);
		}

		// Token: 0x060339F7 RID: 211447 RVA: 0x00CE5C98 File Offset: 0x00CE3E98
		public void OpenViewMonster(int? instId = null, ETrapDefenseMonsterTabType? jumpTab = null, bool? isInst = null)
		{
			TrapDefenseLevelData trapDefenseLevelData;
			TrapDefenseLevelData selectLevelData = (instId != null && this.LevelDataFromInstIdMap.TryGetValue(instId.Value, out trapDefenseLevelData)) ? trapDefenseLevelData : this.GetCurInstToLevelData();
			bool isInstance = isInst ?? ControllerBase<TowerDefenseEventController>.Instance.IsTowerDefenseEventInstance();
			this.ViewModelMonster.SetSelectLevelData(selectLevelData);
			this.ViewModelMonster.SetJumpTabType(jumpTab);
			this.ViewModelMonster.SetIsInstance(isInstance);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseMonsterView, null, null);
		}

		// Token: 0x060339F8 RID: 211448 RVA: 0x00CE5D24 File Offset: 0x00CE3F24
		public void OpenViewKeySetting()
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<TouchUiEditController>.Instance.OpenCommonTouchUiEditView(1);
				return;
			}
			CommonKeySettingViewOpenData param = new CommonKeySettingViewOpenData
			{
				ViewType = EKeySettingExclusiveType.TrapDefense,
				BgSourceId = "T_FightEditBg"
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonKeySettingView, param, null);
		}

		// Token: 0x060339F9 RID: 211449 RVA: 0x00CE5D72 File Offset: 0x00CE3F72
		public void OpenViewLimitReward()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseRewardView, null, null);
		}

		// Token: 0x060339FA RID: 211450 RVA: 0x00CE5D85 File Offset: 0x00CE3F85
		[NullableContext(2)]
		public void OpenViewTalentTree(ITrapDefenseTalentTreeViewParam param = null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseTalentTreeView, param, null);
		}

		// Token: 0x060339FB RID: 211451 RVA: 0x00CE5D98 File Offset: 0x00CE3F98
		public void OpenMainEntryView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseMainView, null, null);
		}

		// Token: 0x060339FC RID: 211452 RVA: 0x00CE5DAB File Offset: 0x00CE3FAB
		public void OpenViewFixedReward()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseFixedRewardView, null, null);
		}

		// Token: 0x060339FD RID: 211453 RVA: 0x00CE5DC0 File Offset: 0x00CE3FC0
		public void OpenViewMainLevelMode(int? id = null, ETrapDefenseDifficultyLevel? difficulty = null, bool? isInst = null)
		{
			bool isInstance = isInst ?? ControllerBase<TowerDefenseEventController>.Instance.IsTowerDefenseEventInstance();
			this.ViewModelMainLevel.SetJumpLevelData(id);
			this.ViewModelMainLevel.SetJumpDifficulty(difficulty);
			this.ViewModelMainLevel.SetIsInstance(isInstance);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseMainLevelView, null, null);
		}

		// Token: 0x060339FE RID: 211454 RVA: 0x00CE5E24 File Offset: 0x00CE4024
		public void OpenViewRougeLevelMode(int? id = null, bool? isInst = null)
		{
			bool isInstance = isInst ?? ControllerBase<TowerDefenseEventController>.Instance.IsTowerDefenseEventInstance();
			this.ViewModelRougeLevel.SetJumpLevelData(id);
			this.ViewModelRougeLevel.SetIsInstance(isInstance);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseRougeLevelView, null, null);
		}

		// Token: 0x060339FF RID: 211455 RVA: 0x00CE5E79 File Offset: 0x00CE4079
		public void OpenViewShop()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseShopView, null, null);
		}

		// Token: 0x06033A00 RID: 211456 RVA: 0x00CE5E8C File Offset: 0x00CE408C
		public bool CheckNextLevelThreshold(TrapDefenseLevelData levelData, Action cb, [Nullable(2)] UiViewBase parent)
		{
			int nextLevelCostThreshold = ConfigBase<TrapDefenseConfig>.Instance.GetNextLevelCostThreshold();
			if (this.ViewModelBuildingDevelop.RemainPoints < nextLevelCostThreshold)
			{
				return false;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TrapDefenseNextLevelThreshold);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[1] = cb;
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<TrapDefenseController>.Instance.OpenOrganDevelop(false, parent, 0, levelData);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return true;
		}

		// Token: 0x06033A01 RID: 211457 RVA: 0x00CE5F0C File Offset: 0x00CE410C
		public void ProtoBdBuffAllUpdateNotify(TrapDefenseSyncGainingGroupsNotify response)
		{
			if (this.RougeModeData == null)
			{
				this.ResponseCacheBdBuff = response;
				return;
			}
			Dictionary<int, TrapDefenseGainingInfo> dictionary = new Dictionary<int, TrapDefenseGainingInfo>();
			foreach (TrapDefenseGainingInfo trapDefenseGainingInfo in response.GainingInfos)
			{
				dictionary[trapDefenseGainingInfo.GroupId] = trapDefenseGainingInfo;
			}
			foreach (TrapDefenseBdBuffData trapDefenseBdBuffData in this.RougeModeData.BdBuffDataList)
			{
				TrapDefenseGainingInfo trapDefenseGainingInfo2;
				dictionary.TryGetValue(trapDefenseBdBuffData.Id, out trapDefenseGainingInfo2);
				trapDefenseBdBuffData.SetActive(trapDefenseGainingInfo2 != null);
				trapDefenseBdBuffData.SetLevel((trapDefenseGainingInfo2 != null) ? trapDefenseGainingInfo2.LevelId : 1);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseBdBuffAllUpdate);
		}

		// Token: 0x06033A02 RID: 211458 RVA: 0x00CE5FF8 File Offset: 0x00CE41F8
		private void TryUpdateBdBuffAllUpdateNotify()
		{
			if (this.ResponseCacheBdBuff == null)
			{
				return;
			}
			this.ProtoBdBuffAllUpdateNotify(this.ResponseCacheBdBuff);
			this.ResponseCacheBdBuff = null;
		}

		// Token: 0x06033A03 RID: 211459 RVA: 0x00CE6018 File Offset: 0x00CE4218
		public void ProtoBdBuffSelectUpdateNotify(TrapDefenseRewardGainingGroupsNotify response)
		{
			RewardGainingPanelInfo rewardInfo = response.RewardInfo;
			if (rewardInfo == null)
			{
				return;
			}
			if (rewardInfo.GainingGroupIds.Count <= 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(ETrapDefenseTextKey.BdBuffSelectEmptyListTips.ToString(), Array.Empty<object>());
				return;
			}
			this.ViewModeBdBuffSelect.SetRemainRefreshCount(rewardInfo.RemainRefreshTimes);
			this.ViewModeBdBuffSelect.SetMaxRefreshCount(rewardInfo.TotalRefreshTimes);
			this.ViewModeBdBuffSelect.SetRefreshBuffCostNum(rewardInfo.RefreshCost);
			if (this.ViewModeBdBuffSelect.ShowingViewProcess)
			{
				this.ViewModeBdBuffSelect.BackupIdList.Add(new List<int>(rewardInfo.GainingGroupIds));
				return;
			}
			this.ViewModeBdBuffSelect.OnOpenView();
			this.OpenViewBdBuffSelect(new List<int>(rewardInfo.GainingGroupIds), null);
		}

		// Token: 0x06033A04 RID: 211460 RVA: 0x00CE60E0 File Offset: 0x00CE42E0
		public void ProtoBdBuffGetUpdateNotify(TrapDefenseGainingGroupUpdateNotify response)
		{
			TrapDefenseGainingInfo gainingGroupInfo = response.GainingGroupInfo;
			if (gainingGroupInfo == null)
			{
				return;
			}
			if (response.Reason != TrapDefenseGainingUpdateReason.RewardSelect)
			{
				this.RougeModeData.CheckBdBuffGetUpdate(gainingGroupInfo.GroupId, gainingGroupInfo.LevelId);
			}
		}

		// Token: 0x06033A05 RID: 211461 RVA: 0x00CE6118 File Offset: 0x00CE4318
		public void ProtoBdBuffRefreshResponse(TrapDefenseRefreshGainingGroupResponse response)
		{
			RewardGainingPanelInfo newRewardInfo = response.NewRewardInfo;
			if (newRewardInfo != null && newRewardInfo.GainingGroupIds.Count > 0)
			{
				this.ViewModeBdBuffSelect.SetBuffList(new List<int>(newRewardInfo.GainingGroupIds), null);
				this.ViewModeBdBuffSelect.SetRemainRefreshCount(newRewardInfo.RemainRefreshTimes);
				this.ViewModeBdBuffSelect.SetMaxRefreshCount(newRewardInfo.TotalRefreshTimes);
				this.ViewModeBdBuffSelect.SetRefreshBuffCostNum(newRewardInfo.RefreshCost);
			}
		}

		// Token: 0x06033A06 RID: 211462 RVA: 0x00CE6190 File Offset: 0x00CE4390
		public UniTask RequestBdBuffSelect(int id)
		{
			TrapDefenseModel.<RequestBdBuffSelect>d__69 <RequestBdBuffSelect>d__;
			<RequestBdBuffSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestBdBuffSelect>d__.<>4__this = this;
			<RequestBdBuffSelect>d__.id = id;
			<RequestBdBuffSelect>d__.<>1__state = -1;
			<RequestBdBuffSelect>d__.<>t__builder.Start<TrapDefenseModel.<RequestBdBuffSelect>d__69>(ref <RequestBdBuffSelect>d__);
			return <RequestBdBuffSelect>d__.<>t__builder.Task;
		}

		// Token: 0x06033A07 RID: 211463 RVA: 0x00CE61DC File Offset: 0x00CE43DC
		public void ProtoChallengeUpdateNotify(TrapDefenseChallengeUpdateNotify response)
		{
			foreach (TrapDefenseChallengeInfo trapDefenseChallengeInfo in response.ChallengeInfo)
			{
				TrapDefenseLevelData trapDefenseLevelData;
				if (this.LevelDataFromIdMap.TryGetValue(trapDefenseChallengeInfo.ChallengeId, out trapDefenseLevelData))
				{
					trapDefenseLevelData.ProtoUpdateData(trapDefenseChallengeInfo);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseLevelDataListUpdate);
		}

		// Token: 0x06033A08 RID: 211464 RVA: 0x00CE6250 File Offset: 0x00CE4450
		public void ProtoRewardUpdateNotify(TrapDefenseRewardUpdateNotify response)
		{
			TrapDefenseRewardData rewardData = this.RewardData;
			if (rewardData != null)
			{
				rewardData.UpdateRewardsByServerData(new List<TrapDefenseRewardInfo>(response.Rewards).ToArray());
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseRewardUpdate);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseLimitReward);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseFixedReward);
			ActivityTrapDefenseController instance = ControllerBase<ActivityTrapDefenseController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.RefreshActivityRedDot();
		}

		// Token: 0x06033A09 RID: 211465 RVA: 0x00CE62C0 File Offset: 0x00CE44C0
		public void ProtoSpecialRewardUpdateNotify(TrapDefenseSpecialRewardUpdateNotify response)
		{
			TrapDefenseRewardData rewardData = this.RewardData;
			if (rewardData != null)
			{
				TrapDefenseSpecialRewardData specialRewardData = rewardData.SpecialRewardData;
				if (specialRewardData != null)
				{
					specialRewardData.UpdateByServerData(response.SpecialRewards[0]);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseRewardUpdate);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseLimitReward);
			ActivityTrapDefenseController instance = ControllerBase<ActivityTrapDefenseController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.RefreshActivityRedDot();
		}

		// Token: 0x06033A0A RID: 211466 RVA: 0x00CE6324 File Offset: 0x00CE4524
		public void ProtoTechUpdateNotify(TrapDefenseTechUpdateNotify response)
		{
			foreach (int key in response.UnlockTechNodes)
			{
				TrapDefenseTalentTreeData talentTreeData = this.TalentTreeData;
				TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData;
				if (talentTreeData != null && talentTreeData.NodeIdMap.TryGetValue(key, out trapDefenseTalentTreeNodeData) && trapDefenseTalentTreeNodeData != null)
				{
					trapDefenseTalentTreeNodeData.SetUnlock();
				}
			}
			TrapDefenseTalentTreeData talentTreeData2 = this.TalentTreeData;
			if (talentTreeData2 != null)
			{
				talentTreeData2.RefreshLineTypeMap();
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseTalentTreeUpdate);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseTalentTree);
			ActivityTrapDefenseController instance = ControllerBase<ActivityTrapDefenseController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.RefreshActivityRedDot();
		}

		// Token: 0x06033A0B RID: 211467 RVA: 0x00CE63D0 File Offset: 0x00CE45D0
		public void ProtoBdUpdateNotify(TrapDefenseBdUpdateNotify response)
		{
			foreach (int key in response.UnlockBds)
			{
				TrapDefenseBdData trapDefenseBdData;
				if (this.RougeModeData.BdDataMap.TryGetValue(key, out trapDefenseBdData) && trapDefenseBdData != null)
				{
					trapDefenseBdData.SetUnlock(true);
				}
			}
		}

		// Token: 0x06033A0C RID: 211468 RVA: 0x00CE6438 File Offset: 0x00CE4638
		public void ProtoBdBuffUpdateNotify(TrapDefenseBdGroupUnlockNotify response)
		{
			foreach (int key in response.UnlockBdGroups)
			{
				TrapDefenseBdBuffData trapDefenseBdBuffData;
				if (this.RougeModeData.BdBuffDataMap.TryGetValue(key, out trapDefenseBdBuffData) && trapDefenseBdBuffData != null)
				{
					trapDefenseBdBuffData.SetUnlock(true);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseBdBuffListUpdate);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseBdBuffNewUnlock);
			ActivityTrapDefenseController instance = ControllerBase<ActivityTrapDefenseController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.RefreshActivityRedDot();
		}

		// Token: 0x06033A0D RID: 211469 RVA: 0x00CE64CC File Offset: 0x00CE46CC
		public void ProtoTechPointUpdateNotify(TrapDefenseTechPointUpdateNotify response)
		{
			TrapDefenseTalentTreeData talentTreeData = this.TalentTreeData;
			if (talentTreeData != null)
			{
				talentTreeData.SetRemainPoints(response.LeftTechPoint);
			}
			TrapDefenseTalentTreeData talentTreeData2 = this.TalentTreeData;
			if (talentTreeData2 != null)
			{
				talentTreeData2.SetMaxPoints(response.TotalTechPoint);
			}
			this.ViewModelBuildingDevelop.SetRemainPoints(response.LeftLevelUpPoint);
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseTalentTreeUpdate);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseTalentTree);
			ActivityTrapDefenseController instance = ControllerBase<ActivityTrapDefenseController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.RefreshActivityRedDot();
		}

		// Token: 0x06033A0E RID: 211470 RVA: 0x00CE6547 File Offset: 0x00CE4747
		public void ProtoShopRefreshResponse(TrapDefenseRefreshShopResponse response)
		{
			if (response.NewShopInfo == null)
			{
				return;
			}
			TrapDefenseShopData shopData = this.ShopData;
			if (shopData != null)
			{
				shopData.UpdateByServerData(response.NewShopInfo);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseShopRefresh);
		}

		// Token: 0x06033A0F RID: 211471 RVA: 0x00CE6579 File Offset: 0x00CE4779
		public void ProtoShopInitNotify(TrapDefenseShopPanelInfo response)
		{
			TrapDefenseShopData shopData = this.ShopData;
			if (shopData != null)
			{
				shopData.UpdateByServerData(response);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseShopRefresh);
		}

		// Token: 0x06033A10 RID: 211472 RVA: 0x00CE659D File Offset: 0x00CE479D
		public void ProtoShopPurchaseResponse(TrapDefenseShopPanelInfo response, int purchasedId)
		{
			TrapDefenseShopData shopData = this.ShopData;
			if (shopData != null)
			{
				shopData.UpdateByServerData(response);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseShopRefresh);
		}

		// Token: 0x06033A11 RID: 211473 RVA: 0x00CE65C4 File Offset: 0x00CE47C4
		public bool RequestStartChallenge(TrapDefenseLevelData data)
		{
			if (!data.IsLeaved)
			{
				ControllerBase<TrapDefenseController>.Instance.RequestChallenge(data, false);
				return true;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TrapDefenseLevelStarSwitch);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				ControllerBase<TrapDefenseController>.Instance.RequestChallenge(data, false);
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<TrapDefenseController>.Instance.RequestChallenge(data, true);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return true;
		}

		// Token: 0x0401DE7E RID: 122494
		public TrapDefenseLevelModeData LevelModeData;

		// Token: 0x0401DE7F RID: 122495
		public TrapDefenseRougeModeData RougeModeData;

		// Token: 0x0401DE80 RID: 122496
		public TrapDefenseRewardData RewardData;

		// Token: 0x0401DE81 RID: 122497
		public TrapDefenseTalentTreeData TalentTreeData;

		// Token: 0x0401DE82 RID: 122498
		public readonly Dictionary<int, TrapDefenseLevelData> LevelDataFromInstIdMap = new Dictionary<int, TrapDefenseLevelData>();

		// Token: 0x0401DE83 RID: 122499
		public readonly Dictionary<int, TrapDefenseLevelData> LevelDataFromIdMap = new Dictionary<int, TrapDefenseLevelData>();

		// Token: 0x0401DE84 RID: 122500
		public Dictionary<EUiViewName, Func<EUiViewName, object, bool>> CheckCanOpenViewMap = new Dictionary<EUiViewName, Func<EUiViewName, object, bool>>();

		// Token: 0x0401DE85 RID: 122501
		public TrapDefenseBdSumViewModel ViewModelBdSum;

		// Token: 0x0401DE86 RID: 122502
		public TrapDefenseBdQualityViewModel ViewModelBdQuality;

		// Token: 0x0401DE87 RID: 122503
		public TrapDefenseBdBuffSelectViewModel ViewModeBdBuffSelect;

		// Token: 0x0401DE88 RID: 122504
		public TrapDefenseRewardViewModel ViewModelReward;

		// Token: 0x0401DE89 RID: 122505
		public TrapDefenseMonsterViewModel ViewModelMonster;

		// Token: 0x0401DE8A RID: 122506
		public TrapDefenseTalentTreeViewModel ViewModelTalentTree;

		// Token: 0x0401DE8B RID: 122507
		public TrapDefenseFixedRewardViewModel ViewModelFixedReward;

		// Token: 0x0401DE8C RID: 122508
		public TrapDefenseMainLevelViewModel ViewModelMainLevel;

		// Token: 0x0401DE8D RID: 122509
		public TrapDefenseRougeLevelViewModel ViewModelRougeLevel;

		// Token: 0x0401DE8E RID: 122510
		public TrapDefenseShopViewModel ViewModelShop;

		// Token: 0x0401DE8F RID: 122511
		public TrapDefenseBattleData BattleData;

		// Token: 0x0401DE90 RID: 122512
		public TrapDefenseMapModel MapData;

		// Token: 0x0401DE91 RID: 122513
		public TrapDefenseShopData ShopData;

		// Token: 0x0401DE92 RID: 122514
		public TrapDefenseBattleInventoryData BattleInventoryData;

		// Token: 0x0401DE93 RID: 122515
		public TrapDefenseBuildingDevelopViewModel ViewModelBuildingDevelop;

		// Token: 0x0401DE94 RID: 122516
		public bool NeedOpenMainView;

		// Token: 0x0401DE95 RID: 122517
		public bool IsSkipMachineFullCheck;

		// Token: 0x0401DE96 RID: 122518
		[Nullable(2)]
		private TrapDefenseSyncGainingGroupsNotify ResponseCacheBdBuff;
	}
}
