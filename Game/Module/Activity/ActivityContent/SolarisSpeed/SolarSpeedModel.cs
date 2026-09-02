using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Personal;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200636E RID: 25454
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SolarSpeedModel : ModelBase<SolarSpeedModel>
	{
		// Token: 0x0603FEA4 RID: 261796 RVA: 0x01064F2B File Offset: 0x0106312B
		protected override bool OnInit()
		{
			this.ConfigContext = new SolarSpeedConfigContext(this);
			this.ProtocolContext = new SolarSpeedProtocolContext(this);
			this.UiContext = new SolarSpeedUiContext();
			return true;
		}

		// Token: 0x0603FEA5 RID: 261797 RVA: 0x01064F51 File Offset: 0x01063151
		protected override bool OnClear()
		{
			this.ConfigContext.Dispose();
			this.ProtocolContext.Dispose();
			this.UiContext.Dispose();
			return true;
		}

		// Token: 0x17009CE2 RID: 40162
		// (get) Token: 0x0603FEA6 RID: 261798 RVA: 0x01064F75 File Offset: 0x01063175
		public int CurrentActivityId
		{
			get
			{
				return this.ProtocolContext.Id;
			}
		}

		// Token: 0x17009CE3 RID: 40163
		// (get) Token: 0x0603FEA7 RID: 261799 RVA: 0x01064F82 File Offset: 0x01063182
		public ActivityBaseData ActivityData
		{
			get
			{
				return this.ProtocolContext;
			}
		}

		// Token: 0x17009CE4 RID: 40164
		// (get) Token: 0x0603FEA8 RID: 261800 RVA: 0x01064F8C File Offset: 0x0106318C
		public string ActivityTitleTextId
		{
			get
			{
				SolarSpeedProtocolContext protocolContext = this.ProtocolContext;
				return ((protocolContext.LocalConfig != null) ? protocolContext.LocalConfig.GetValueOrDefault().Title : null) ?? "";
			}
		}

		// Token: 0x17009CE5 RID: 40165
		// (get) Token: 0x0603FEA9 RID: 261801 RVA: 0x01064FC8 File Offset: 0x010631C8
		public string ActivityIconPath
		{
			get
			{
				SolarSpeedProtocolContext protocolContext = this.ProtocolContext;
				return ((protocolContext.LocalConfig != null) ? protocolContext.LocalConfig.GetValueOrDefault().TabResource : null) ?? "";
			}
		}

		// Token: 0x17009CE6 RID: 40166
		// (get) Token: 0x0603FEAA RID: 261802 RVA: 0x01065004 File Offset: 0x01063204
		public string InstanceEntranceIconPath
		{
			get
			{
				InstanceDungeonEntrance? config = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(9000);
				return ((config != null) ? config.GetValueOrDefault().TitleSprite : null) ?? "";
			}
		}

		// Token: 0x17009CE7 RID: 40167
		// (get) Token: 0x0603FEAB RID: 261803 RVA: 0x01065045 File Offset: 0x01063245
		public int? CurrentChosenTabInRewardView
		{
			get
			{
				return this.UiContext.CurrentChosenTabInRewardView;
			}
		}

		// Token: 0x17009CE8 RID: 40168
		// (get) Token: 0x0603FEAC RID: 261804 RVA: 0x01065054 File Offset: 0x01063254
		public bool HasLevelRedDot
		{
			get
			{
				foreach (KeyValuePair<int, TeamParKOurCfg> keyValuePair in this.ConfigContext.CurrentCfgCache)
				{
					int num;
					TeamParKOurCfg teamParKOurCfg;
					keyValuePair.Deconstruct(out num, out teamParKOurCfg);
					int id = num;
					if (this.HasRedDotById(id))
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x17009CE9 RID: 40169
		// (get) Token: 0x0603FEAD RID: 261805 RVA: 0x010650C4 File Offset: 0x010632C4
		public bool HasRewardRedDot
		{
			get
			{
				foreach (KeyValuePair<int, TeamParKOurReward> keyValuePair in this.ConfigContext.CurrentRewardCache)
				{
					int num;
					TeamParKOurReward teamParKOurReward;
					keyValuePair.Deconstruct(out num, out teamParKOurReward);
					int id = num;
					if (this.ProtocolContext.GetTaskStateById(id).GetValueOrDefault() == ActivityTaskState.ActivityTaskFinish)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x17009CEA RID: 40170
		// (get) Token: 0x0603FEAE RID: 261806 RVA: 0x01065144 File Offset: 0x01063344
		public int TotalRewardCount
		{
			get
			{
				return this.ConfigContext.CurrentRewardCache.Count;
			}
		}

		// Token: 0x17009CEB RID: 40171
		// (get) Token: 0x0603FEAF RID: 261807 RVA: 0x01065158 File Offset: 0x01063358
		public int CurrentCompletedCount
		{
			get
			{
				int num = 0;
				foreach (KeyValuePair<int, TeamParKOurReward> keyValuePair in this.ConfigContext.CurrentRewardCache)
				{
					int num2;
					TeamParKOurReward teamParKOurReward;
					keyValuePair.Deconstruct(out num2, out teamParKOurReward);
					int id = num2;
					ActivityTaskState? taskStateById = this.ProtocolContext.GetTaskStateById(id);
					if (taskStateById != null)
					{
						ActivityTaskState? activityTaskState = taskStateById;
						ActivityTaskState activityTaskState2 = ActivityTaskState.ActivityTaskRunning;
						if (activityTaskState.GetValueOrDefault() > activityTaskState2 & activityTaskState != null)
						{
							num++;
						}
					}
				}
				return num;
			}
		}

		// Token: 0x17009CEC RID: 40172
		// (get) Token: 0x0603FEB0 RID: 261808 RVA: 0x010651F4 File Offset: 0x010633F4
		public int DefaultLevelIdInRewardView
		{
			get
			{
				this.UiContext.CurrentChosenTabInRewardView = new int?(1);
				return this.UiContext.CurrentChosenTabInRewardView.Value;
			}
		}

		// Token: 0x0603FEB1 RID: 261809 RVA: 0x01065217 File Offset: 0x01063417
		[NullableContext(2)]
		public string GetInfoPicturePathByInstanceId(int instanceId)
		{
			return this.ConfigContext.GetInfoPicturePathByInstanceId(instanceId);
		}

		// Token: 0x0603FEB2 RID: 261810 RVA: 0x01065228 File Offset: 0x01063428
		[NullableContext(2)]
		public string GetIconPathInInstanceSeriesItemByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				return null;
			}
			int rankingById = this.ProtocolContext.GetRankingById(levelIdByInstanceId.Value);
			return this.GetMedalPathByRank(rankingById);
		}

		// Token: 0x0603FEB3 RID: 261811 RVA: 0x01065268 File Offset: 0x01063468
		public int GetHistoryHighScoreInSettleView()
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			return this.GetHistoryHighScoreByInstanceId(instanceId).GetValueOrDefault();
		}

		// Token: 0x0603FEB4 RID: 261812 RVA: 0x01065290 File Offset: 0x01063490
		public int? GetHistoryRankByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SolarSpeed;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "不能通过instanceId找到levelId，策划检查配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("instanceId", instanceId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new int?(this.ProtocolContext.GetRankingById(levelIdByInstanceId.Value));
		}

		// Token: 0x0603FEB5 RID: 261813 RVA: 0x01065304 File Offset: 0x01063504
		public int? GetHistoryHighScoreByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SolarSpeed;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "不能通过instanceId找到levelId，策划检查配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("instanceId", instanceId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new int?(this.ProtocolContext.GetScoreById(levelIdByInstanceId.Value));
		}

		// Token: 0x0603FEB6 RID: 261814 RVA: 0x01065378 File Offset: 0x01063578
		public int? GetHistoryLapRecordByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SolarSpeed;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "不能通过instanceId找到levelId，策划检查配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("instanceId", instanceId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new int?(this.ProtocolContext.GetLapRecord(levelIdByInstanceId.Value));
		}

		// Token: 0x0603FEB7 RID: 261815 RVA: 0x010653EC File Offset: 0x010635EC
		[NullableContext(2)]
		public string GetMedalPathByRank(int rank)
		{
			if (rank < 1 || rank > SolarSpeedDefine.medalTexPathMap.Count)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SolarSpeed;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "rank值超出奖牌资源索引范围";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("rank", rank);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return SolarSpeedDefine.medalTexPathMap[rank - 1];
		}

		// Token: 0x0603FEB8 RID: 261816 RVA: 0x01065448 File Offset: 0x01063648
		[NullableContext(2)]
		public string GetInstanceSubtitleTextIdByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				return null;
			}
			if (!this.IsUnlockById(levelIdByInstanceId.Value))
			{
				return "LianjiPaokuReward_Level_UnLock";
			}
			if (this.ProtocolContext.GetRankingById(levelIdByInstanceId.Value) == 0)
			{
				return "LianjiPaokuReward_Level_NoRecords";
			}
			return "LianjiPaokuReward_Level_TopScore";
		}

		// Token: 0x0603FEB9 RID: 261817 RVA: 0x010654A4 File Offset: 0x010636A4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] GetInstanceSubtitleArgsByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				return null;
			}
			if (this.IsUnlockById(levelIdByInstanceId.Value))
			{
				if (this.ProtocolContext.GetRankingById(levelIdByInstanceId.Value) == 0)
				{
					return null;
				}
				return new string[]
				{
					this.ProtocolContext.GetScoreById(levelIdByInstanceId.Value).ToString()
				};
			}
			else
			{
				string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((double)this.ProtocolContext.GetStartTime(levelIdByInstanceId.Value) - Singleton<TimeUtil>.Instance.GetServerTime()).CountDownText;
				if (countDownText != null)
				{
					return new string[]
					{
						countDownText
					};
				}
				return null;
			}
		}

		// Token: 0x0603FEBA RID: 261818 RVA: 0x01065550 File Offset: 0x01063750
		[NullableContext(2)]
		public string GetInstanceUnlockTextIdByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				return null;
			}
			if (this.IsUnlockById(levelIdByInstanceId.Value))
			{
				return ConfigBase<InstanceDungeonConfig>.Instance.GetUnlockConditionGroupHintText(instanceId);
			}
			return "LianjiPaokuReward_Level_UnLock";
		}

		// Token: 0x0603FEBB RID: 261819 RVA: 0x01065598 File Offset: 0x01063798
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] GetInstanceUnlockArgsByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				return null;
			}
			if (this.IsUnlockById(levelIdByInstanceId.Value))
			{
				return null;
			}
			string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((double)this.ProtocolContext.GetStartTime(levelIdByInstanceId.Value) - Singleton<TimeUtil>.Instance.GetServerTime()).CountDownText;
			if (countDownText != null)
			{
				return new string[]
				{
					countDownText
				};
			}
			return null;
		}

		// Token: 0x0603FEBC RID: 261820 RVA: 0x0106560C File Offset: 0x0106380C
		public bool IsUnlockByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			return levelIdByInstanceId != null && this.IsUnlockById(levelIdByInstanceId.Value);
		}

		// Token: 0x0603FEBD RID: 261821 RVA: 0x01065640 File Offset: 0x01063840
		public bool IsClickedById(int instanceId)
		{
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.SolarSpeedInstanceClicked, null);
			bool flag;
			return player != null && (player.TryGetValue(instanceId, out flag) && flag);
		}

		// Token: 0x0603FEBE RID: 261822 RVA: 0x01065666 File Offset: 0x01063866
		public bool IsUnlockById(int id)
		{
			return (double)this.ProtocolContext.GetStartTime(id) < Singleton<TimeUtil>.Instance.GetServerTime();
		}

		// Token: 0x0603FEBF RID: 261823 RVA: 0x01065681 File Offset: 0x01063881
		public bool HasRedDotById(int id)
		{
			return !this.IsClickedById(id) && this.IsUnlockById(id);
		}

		// Token: 0x0603FEC0 RID: 261824 RVA: 0x01065698 File Offset: 0x01063898
		public bool HasRedDotByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			return levelIdByInstanceId != null && this.HasRedDotById(levelIdByInstanceId.Value);
		}

		// Token: 0x0603FEC1 RID: 261825 RVA: 0x010656CA File Offset: 0x010638CA
		public void SetCurrentChosenTabInRewardView(int id)
		{
			this.UiContext.CurrentChosenTabInRewardView = new int?(id);
		}

		// Token: 0x0603FEC2 RID: 261826 RVA: 0x010656DD File Offset: 0x010638DD
		public void SyncTeamParkourTaskNotify(TeamParkourTaskNotify msg)
		{
			this.ProtocolContext.ParseTeamParkourTaskNotify(msg);
		}

		// Token: 0x0603FEC3 RID: 261827 RVA: 0x010656EB File Offset: 0x010638EB
		public void SyncTeamParkourSettleNotify(TeamParkourSettleNotify msg)
		{
			this.ProtocolContext.ParseTeamParkourSettleNotify(msg);
		}

		// Token: 0x0603FEC4 RID: 261828 RVA: 0x010656FC File Offset: 0x010638FC
		public void SyncInstanceClicked(int instanceId)
		{
			int? levelIdByInstanceId = this.ConfigContext.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				return;
			}
			if (!this.IsUnlockById(levelIdByInstanceId.Value))
			{
				return;
			}
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.SolarSpeedInstanceClicked, null);
			if (dictionary == null)
			{
				dictionary = new Dictionary<int, bool>();
			}
			if (!dictionary.ContainsKey(levelIdByInstanceId.Value))
			{
				dictionary.Add(levelIdByInstanceId.Value, true);
				LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.SolarSpeedInstanceClicked, dictionary);
			}
		}

		// Token: 0x0603FEC5 RID: 261829 RVA: 0x01065768 File Offset: 0x01063968
		public void SyncAfterRewardedById(int id)
		{
			this.ProtocolContext.SetTaskStateRewardedById(id);
		}

		// Token: 0x0603FEC6 RID: 261830 RVA: 0x01065778 File Offset: 0x01063978
		public ISolarSpeedRewardViewData BuildSolarSpeedRewardViewDataById(int id)
		{
			return new SolarSpeedRewardViewData
			{
				TitleTextId = this.ActivityTitleTextId,
				TitleIconPath = this.InstanceEntranceIconPath,
				Score = this.ProtocolContext.GetScoreById(id).ToString(),
				RewardPanelData = new SolarSpeedRewardPanelData
				{
					TabDataList = this.BuildTabCellPanelDataListInRewardView(id),
					RewardDataList = this.BuildRewardCellPanelDataListInRewardViewById(id)
				}
			};
		}

		// Token: 0x0603FEC7 RID: 261831 RVA: 0x010657E4 File Offset: 0x010639E4
		private SettleFlag? GetSettleFlagCfgByPlayerSettleInfo(PlayerSettleInfo msg)
		{
			foreach (SettleFlag value in this.ConfigContext.SortedSettleCfgCache)
			{
				switch (value.Id)
				{
				case 1:
					if (msg.Finish && msg.ConsumeTime < value.Args)
					{
						return new SettleFlag?(value);
					}
					break;
				case 2:
					if (msg.Ranking == value.Args)
					{
						return new SettleFlag?(value);
					}
					break;
				case 4:
					if (msg.Ranking != 1 && msg.Finish)
					{
						return new SettleFlag?(value);
					}
					break;
				case 6:
					if (msg.DistancePoints > value.Args && !msg.Finish)
					{
						return new SettleFlag?(value);
					}
					break;
				case 7:
					return new SettleFlag?(value);
				}
			}
			return null;
		}

		// Token: 0x0603FEC8 RID: 261832 RVA: 0x010658F4 File Offset: 0x01063AF4
		private bool GetRedDotStateInRewardViewById(int id)
		{
			TeamParKOurCfg teamParKOurCfg;
			int[] array = this.ConfigContext.CurrentCfgCache.TryGetValue(id, out teamParKOurCfg) ? teamParKOurCfg.GetTaskListArray() : null;
			if (array == null)
			{
				return false;
			}
			foreach (int id2 in array)
			{
				if (this.ProtocolContext.GetTaskStateById(id2).GetValueOrDefault() == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603FEC9 RID: 261833 RVA: 0x01065958 File Offset: 0x01063B58
		private bool GetRedDotStateInRewardViewBonus()
		{
			foreach (int id in SolarSpeedDefine.bonusRewardList)
			{
				if (this.ProtocolContext.GetTaskStateById(id).GetValueOrDefault() == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603FECA RID: 261834 RVA: 0x010659BC File Offset: 0x01063BBC
		public ISolarSpeedResultViewData BuildSolarSpeedResultViewData()
		{
			Dictionary<int, PlayerSettleInfo> playerSettleMsgCache = this.ProtocolContext.PlayerSettleMsgCache;
			List<ISolarSpeedRolePanelData> list = new List<ISolarSpeedRolePanelData>();
			foreach (KeyValuePair<int, PlayerSettleInfo> keyValuePair in playerSettleMsgCache)
			{
				int num;
				PlayerSettleInfo playerSettleInfo;
				keyValuePair.Deconstruct(out num, out playerSettleInfo);
				PlayerSettleInfo playerSettleInfo2 = playerSettleInfo;
				int playerId = playerSettleInfo2.PlayerId;
				int ranking = playerSettleInfo2.Ranking;
				int index = ranking - 1;
				OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
				bool flag = currentTeamListById != null && currentTeamListById.IsSelf;
				int index2 = (currentTeamListById != null) ? (currentTeamListById.PlayerNumber - 1) : 0;
				SettleFlag? settleFlagCfgByPlayerSettleInfo = this.GetSettleFlagCfgByPlayerSettleInfo(playerSettleInfo2);
				SolarSpeedRolePanelData item = new SolarSpeedRolePanelData
				{
					Rank = ranking,
					PlayerId = playerId,
					IsAddButtonAvailable = (!flag && !ModelBase<FriendModel>.Instance.IsMyFriend(playerId)),
					IsSelf = flag,
					BgPath = SolarSpeedDefine.rankBgPathMap[index],
					MedalTexturePath = SolarSpeedDefine.medalTexPathMap[index],
					MedalColorHex = SolarSpeedDefine.medalColorHex[index],
					FxColorHex = SolarSpeedDefine.fxColorHex[index],
					PlayerIndexIconPath = (flag ? SolarSpeedDefine.playerIndexSelfIconMap[index2] : SolarSpeedDefine.playerIndexIconMap[index2]),
					NameText = (((currentTeamListById != null) ? currentTeamListById.PlayerName : null) ?? ""),
					DescTextId = (((settleFlagCfgByPlayerSettleInfo != null) ? settleFlagCfgByPlayerSettleInfo.GetValueOrDefault().Content : null) ?? ""),
					TitleTextId = (((settleFlagCfgByPlayerSettleInfo != null) ? settleFlagCfgByPlayerSettleInfo.GetValueOrDefault().Title : null) ?? ""),
					IconData = new SolarSpeedRoleIconPanelData
					{
						IconPath = ((currentTeamListById == null) ? "" : ModelBase<PersonalModel>.Instance.GetPlayerHeadData(currentTeamListById.HeadId, false).GetRoleHeadIconCircle())
					}
				};
				list.Add(item);
			}
			list.Sort((ISolarSpeedRolePanelData a, ISolarSpeedRolePanelData b) => a.Rank - b.Rank);
			if (list.Count > 1)
			{
				ISolarSpeedRolePanelData value = list[0];
				list[0] = list[1];
				list[1] = value;
			}
			SolarSpeedResultViewData solarSpeedResultViewData = new SolarSpeedResultViewData();
			solarSpeedResultViewData.RoleDataList = list;
			solarSpeedResultViewData.PanelType = (() => new SolarSpeedRolePanel());
			solarSpeedResultViewData.ConfirmClick = delegate()
			{
				ControllerBase<ActivitySolarSpeedController>.Instance.HandleClickNextInResultView();
			};
			return solarSpeedResultViewData;
		}

		// Token: 0x0603FECB RID: 261835 RVA: 0x01065C7C File Offset: 0x01063E7C
		private List<ISolarSpeedTabCellPanelData> BuildTabCellPanelDataListInRewardView(int chosenLevelId)
		{
			List<ISolarSpeedTabCellPanelData> list = new List<ISolarSpeedTabCellPanelData>();
			SolarSpeedConfigContext configContext = this.ConfigContext;
			foreach (KeyValuePair<int, TeamParKOurCfg> keyValuePair in this.ConfigContext.CurrentCfgCache)
			{
				int num;
				TeamParKOurCfg teamParKOurCfg;
				keyValuePair.Deconstruct(out num, out teamParKOurCfg);
				int num2 = num;
				SolarSpeedTabCellPanelData item = new SolarSpeedTabCellPanelData
				{
					LevelId = num2,
					RomeNumberPath = (configContext.GetRomePathById(num2) ?? ""),
					TitleTextId = configContext.GetTitleTextIdById(num2),
					IsChosen = (num2 == chosenLevelId),
					IsRedDot = this.GetRedDotStateInRewardViewById(num2)
				};
				list.Add(item);
			}
			SolarSpeedTabCellPanelData item2 = new SolarSpeedTabCellPanelData
			{
				LevelId = 99,
				RomeNumberPath = "/Game/Aki/UI/UIResources/Common/Image/ComImg/T_ComRomeText_07.T_ComRomeText_07",
				TitleTextId = "LianjiPaoku_Bonus_Level_Title",
				IsChosen = (99 == chosenLevelId),
				IsRedDot = this.GetRedDotStateInRewardViewBonus()
			};
			list.Add(item2);
			return list;
		}

		// Token: 0x0603FECC RID: 261836 RVA: 0x01065D84 File Offset: 0x01063F84
		private List<ISolarSpeedRewardCellPanelData> BuildRewardCellPanelDataListInRewardViewById(int id)
		{
			List<ISolarSpeedRewardCellPanelData> list = new List<ISolarSpeedRewardCellPanelData>();
			SolarSpeedConfigContext configContext = this.ConfigContext;
			foreach (int num in configContext.GetTaskListById(id))
			{
				SolarSpeedRewardCellPanelData solarSpeedRewardCellPanelData = new SolarSpeedRewardCellPanelData();
				solarSpeedRewardCellPanelData.RewardId = num;
				solarSpeedRewardCellPanelData.TitleTextId = (configContext.GetRewardTitleTextId(num) ?? "");
				solarSpeedRewardCellPanelData.ProgressTextId = "LianjiPaoku_Reward_Desc";
				solarSpeedRewardCellPanelData.ProgressTextArgs = new string[]
				{
					this.ProtocolContext.GetCurrentProgressById(num).ToString(),
					this.ProtocolContext.GetCurrentProgressTargetById(num).ToString()
				};
				solarSpeedRewardCellPanelData.ItemsData = configContext.GetRewardItemDataListById(num).ToArray();
				solarSpeedRewardCellPanelData.ButtonTextId = "LianjiPaoku_Button_Receive";
				solarSpeedRewardCellPanelData.ButtonActive = (this.ProtocolContext.GetTaskStateById(num).GetValueOrDefault() == ActivityTaskState.ActivityTaskFinish);
				SolarSpeedRewardCellPanelData solarSpeedRewardCellPanelData2 = solarSpeedRewardCellPanelData;
				ActivityTaskState? taskStateById = this.ProtocolContext.GetTaskStateById(num);
				ActivityTaskState activityTaskState = ActivityTaskState.ActivityTaskRunning;
				solarSpeedRewardCellPanelData2.RightActive = (taskStateById.GetValueOrDefault() == activityTaskState & taskStateById != null);
				solarSpeedRewardCellPanelData.DoneSpriteActive = (this.ProtocolContext.GetTaskStateById(num).GetValueOrDefault() == ActivityTaskState.ActivityTaskTaken);
				SolarSpeedRewardCellPanelData item = solarSpeedRewardCellPanelData;
				list.Add(item);
			}
			list.Sort((ISolarSpeedRewardCellPanelData a, ISolarSpeedRewardCellPanelData b) => a.RewardId - b.RewardId);
			return list;
		}

		// Token: 0x0603FECD RID: 261837 RVA: 0x01065F14 File Offset: 0x01064114
		public ISolarSpeedActivitySubViewData BuildActivitySubViewData()
		{
			return new SolarSpeedActivitySubViewData
			{
				RewardTextId = "LianjiPaokuReward_9000_Preview",
				ButtonTextId = "PrefabTextItem_3950726357_Text",
				RewardRedDotStateGetter = (() => this.HasRewardRedDot),
				ConfirmRedDotStateGetter = (() => this.HasLevelRedDot),
				RewardProgressCurrentGetter = (() => this.CurrentCompletedCount.ToString()),
				RewardProgressTextId = "parkour_award_2_1",
				RewardProgressTotal = this.TotalRewardCount.ToString()
			};
		}

		// Token: 0x0603FECE RID: 261838 RVA: 0x01065F94 File Offset: 0x01064194
		public unsafe ReachTargetData BuildSettleReachTargetData()
		{
			int currentRankPointsCache = this.ProtocolContext.CurrentRankPointsCache;
			int currentDistancePointsCache = this.ProtocolContext.CurrentDistancePointsCache;
			int num = currentRankPointsCache + currentDistancePointsCache;
			ReachTargetData reachTargetData = new ReachTargetData();
			int num2 = 2;
			List<IRewardExploreTargetReached> list = new List<IRewardExploreTargetReached>(num2);
			CollectionsMarshal.SetCount<IRewardExploreTargetReached>(list, num2);
			Span<IRewardExploreTargetReached> span = CollectionsMarshal.AsSpan<IRewardExploreTargetReached>(list);
			int num3 = 0;
			ref IRewardExploreTargetReached ptr = ref span[num3];
			RewardExploreTargetReachedData rewardExploreTargetReachedData = new RewardExploreTargetReachedData();
			int num4 = 1;
			List<string> list2 = new List<string>(num4);
			CollectionsMarshal.SetCount<string>(list2, num4);
			Span<string> span2 = CollectionsMarshal.AsSpan<string>(list2);
			int num5 = 0;
			*span2[num5] = currentRankPointsCache.ToString();
			rewardExploreTargetReachedData.Target = list2;
			rewardExploreTargetReachedData.DescriptionTextId = "LianjiPaoku_End_RankScore";
			rewardExploreTargetReachedData.IsReached = true;
			ptr = rewardExploreTargetReachedData;
			num3++;
			ref IRewardExploreTargetReached ptr2 = ref span[num3];
			RewardExploreTargetReachedData rewardExploreTargetReachedData2 = new RewardExploreTargetReachedData();
			num5 = 1;
			List<string> list3 = new List<string>(num5);
			CollectionsMarshal.SetCount<string>(list3, num5);
			span2 = CollectionsMarshal.AsSpan<string>(list3);
			num4 = 0;
			*span2[num4] = currentDistancePointsCache.ToString();
			rewardExploreTargetReachedData2.Target = list3;
			rewardExploreTargetReachedData2.DescriptionTextId = "LianjiPaoku_End_CompleteRank";
			rewardExploreTargetReachedData2.IsReached = true;
			ptr2 = rewardExploreTargetReachedData2;
			reachTargetData.TargetReached = list;
			reachTargetData.IfNewRecord = (num > this.GetHistoryHighScoreInSettleView());
			reachTargetData.FullScore = num;
			reachTargetData.RecordTextId = "LianjiPaoku_End_HistoryRank";
			return reachTargetData;
		}

		// Token: 0x04023E86 RID: 147078
		private SolarSpeedConfigContext ConfigContext;

		// Token: 0x04023E87 RID: 147079
		private SolarSpeedProtocolContext ProtocolContext;

		// Token: 0x04023E88 RID: 147080
		private SolarSpeedUiContext UiContext;
	}
}
