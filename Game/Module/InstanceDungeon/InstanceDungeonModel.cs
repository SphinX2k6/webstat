using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Module.InstanceDungeon;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BC6 RID: 23494
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InstanceDungeonModel : ModelBase<InstanceDungeonModel>
	{
		// Token: 0x0603B7A6 RID: 243622 RVA: 0x00F13DC3 File Offset: 0x00F11FC3
		protected override bool OnLeaveLevel()
		{
			InstanceDungeonInfo instanceDungeonInfo = this.InstanceDungeonInfo;
			if (instanceDungeonInfo != null)
			{
				instanceDungeonInfo.SetTrack(false, ESetTrackReason.None);
			}
			this.InstanceFinishSuccess = EInstanceFinishState.UnFinish;
			this.InstanceRewardHaveTake = false;
			this.ClearInstanceDungeonInfo();
			return true;
		}

		// Token: 0x0603B7A7 RID: 243623 RVA: 0x00F13DED File Offset: 0x00F11FED
		public int GetInstanceId()
		{
			return this.InstanceId;
		}

		// Token: 0x0603B7A8 RID: 243624 RVA: 0x00F13DF5 File Offset: 0x00F11FF5
		public void SetInstanceId(int instanceId)
		{
			this.InstanceId = instanceId;
		}

		// Token: 0x1700978B RID: 38795
		// (get) Token: 0x0603B7A9 RID: 243625 RVA: 0x00F13DFE File Offset: 0x00F11FFE
		// (set) Token: 0x0603B7AA RID: 243626 RVA: 0x00F13E06 File Offset: 0x00F12006
		public bool InstanceContinue { get; set; }

		// Token: 0x0603B7AB RID: 243627 RVA: 0x00F13E0F File Offset: 0x00F1200F
		public void SetMatchTeamInfo(MatchTeamInfo matchTeamInfo)
		{
			this.MatchTeamInfo = matchTeamInfo;
		}

		// Token: 0x0603B7AC RID: 243628 RVA: 0x00F13E18 File Offset: 0x00F12018
		[NullableContext(2)]
		public MatchTeamInfo GetMatchTeamInfo()
		{
			return this.MatchTeamInfo;
		}

		// Token: 0x0603B7AD RID: 243629 RVA: 0x00F13E20 File Offset: 0x00F12020
		public void SetMatchTeamHost(int id)
		{
			this.MatchTeamInfo.HostId = id;
		}

		// Token: 0x0603B7AE RID: 243630 RVA: 0x00F13E2E File Offset: 0x00F1202E
		public void SetMatchTeamState(MatchTeamState state)
		{
			this.MatchTeamInfo.TeamState = state;
		}

		// Token: 0x0603B7AF RID: 243631 RVA: 0x00F13E3C File Offset: 0x00F1203C
		[NullableContext(2)]
		public string GetMatchTeamName(int playerId)
		{
			foreach (MatchPlayerInfo matchPlayerInfo in this.MatchTeamInfo.PlayerInfos)
			{
				if (matchPlayerInfo.PlayerId == playerId)
				{
					return matchPlayerInfo.PlayerName;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "获取匹配副本队伍队员信息失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("队员Id", playerId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0603B7B0 RID: 243632 RVA: 0x00F13EC8 File Offset: 0x00F120C8
		[NullableContext(2)]
		public string GetMatchTeamOnlineId(int playerId)
		{
			foreach (MatchPlayerInfo matchPlayerInfo in this.MatchTeamInfo.PlayerInfos)
			{
				if (matchPlayerInfo.PlayerId == playerId)
				{
					if (Singleton<Info>.Instance.IsPs5Platform())
					{
						return matchPlayerInfo.PsnOnlineId;
					}
					return matchPlayerInfo.XboxOnlineId;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "获取匹配副本队伍队员信息失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("队员Id", playerId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0603B7B1 RID: 243633 RVA: 0x00F13F68 File Offset: 0x00F12168
		public List<int> GetMatchTeamRoleCfgId(int playerId)
		{
			List<int> list = new List<int>();
			foreach (MatchPlayerInfo matchPlayerInfo in this.MatchTeamInfo.PlayerInfos)
			{
				if (matchPlayerInfo.PlayerId == playerId)
				{
					foreach (MatchRoleInfo matchRoleInfo in matchPlayerInfo.RoleInfo)
					{
						list.Add(matchRoleInfo.RoleId);
					}
				}
			}
			return list;
		}

		// Token: 0x0603B7B2 RID: 243634 RVA: 0x00F14008 File Offset: 0x00F12208
		public bool IsMatchTeamHost()
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			MatchTeamInfo matchTeamInfo = this.MatchTeamInfo;
			int? num = (matchTeamInfo != null) ? new int?(matchTeamInfo.HostId) : null;
			return playerId == num.GetValueOrDefault() & num != null;
		}

		// Token: 0x0603B7B3 RID: 243635 RVA: 0x00F14050 File Offset: 0x00F12250
		public bool IsTeamNotFull()
		{
			return this.GetTeamSize() < 3;
		}

		// Token: 0x0603B7B4 RID: 243636 RVA: 0x00F1405B File Offset: 0x00F1225B
		public int GetNeedMatchSize()
		{
			return 3 - this.GetTeamSize();
		}

		// Token: 0x0603B7B5 RID: 243637 RVA: 0x00F14068 File Offset: 0x00F12268
		private int GetTeamSize()
		{
			RepeatedField<MatchPlayerInfo> playerInfos = this.MatchTeamInfo.PlayerInfos;
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				return playerInfos.Count;
			}
			int[] allWorldTeamPlayer = ModelBase<OnlineModel>.Instance.GetAllWorldTeamPlayer();
			int num = playerInfos.Count + allWorldTeamPlayer.Length;
			foreach (int num2 in allWorldTeamPlayer)
			{
				foreach (MatchPlayerInfo matchPlayerInfo in playerInfos)
				{
					if (num2 == matchPlayerInfo.PlayerId)
					{
						num--;
					}
				}
			}
			return num;
		}

		// Token: 0x0603B7B6 RID: 243638 RVA: 0x00F14110 File Offset: 0x00F12310
		public bool IsAllPlayerInMatchTeam()
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				return true;
			}
			List<int> list = new List<int>();
			foreach (MatchPlayerInfo matchPlayerInfo in this.MatchTeamInfo.PlayerInfos)
			{
				list.Add(matchPlayerInfo.PlayerId);
			}
			int[] allWorldTeamPlayer = ModelBase<OnlineModel>.Instance.GetAllWorldTeamPlayer();
			bool result = true;
			foreach (int item in allWorldTeamPlayer)
			{
				if (!list.Contains(item))
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0603B7B7 RID: 243639 RVA: 0x00F141B0 File Offset: 0x00F123B0
		public void InitMatchingTeamConfirmReadyState(RepeatedField<MatchPlayerInfo> players)
		{
			foreach (MatchPlayerInfo matchPlayerInfo in players)
			{
				this.MatchingTeamConfirmState[matchPlayerInfo.PlayerId] = matchPlayerInfo.IsConfirm;
				this.PrewarPlayerReadyState[matchPlayerInfo.PlayerId] = matchPlayerInfo.IsReady;
				foreach (PrewarFormationData prewarFormationData in this.PrewarFormationDataList)
				{
					if (prewarFormationData.GetPlayerId() == matchPlayerInfo.PlayerId)
					{
						prewarFormationData.SetIsReady(matchPlayerInfo.IsReady);
					}
				}
			}
		}

		// Token: 0x0603B7B8 RID: 243640 RVA: 0x00F14278 File Offset: 0x00F12478
		public void SetMatchingPlayerConfirmState(int playerId, bool confirm)
		{
			this.MatchingTeamConfirmState[playerId] = confirm;
		}

		// Token: 0x0603B7B9 RID: 243641 RVA: 0x00F14288 File Offset: 0x00F12488
		public bool? GetMatchingPlayerConfirmStateByPlayerId(int playerId)
		{
			bool value;
			if (this.MatchingTeamConfirmState.TryGetValue(playerId, out value))
			{
				return new bool?(value);
			}
			return null;
		}

		// Token: 0x0603B7BA RID: 243642 RVA: 0x00F142B5 File Offset: 0x00F124B5
		public bool GetMatchingTeamReady()
		{
			return this.MatchTeamInfo.TeamState == MatchTeamState.ReadyConfirm;
		}

		// Token: 0x0603B7BB RID: 243643 RVA: 0x00F142C8 File Offset: 0x00F124C8
		public EMatchPlayerUiState GetPlayerUiState(int playerId)
		{
			foreach (MatchPlayerInfo matchPlayerInfo in this.MatchTeamInfo.PlayerInfos)
			{
				if (matchPlayerInfo.PlayerId == playerId)
				{
					return matchPlayerInfo.MatchUiState;
				}
			}
			return EMatchPlayerUiState.Wait;
		}

		// Token: 0x0603B7BC RID: 243644 RVA: 0x00F14328 File Offset: 0x00F12528
		public void SetPlayerUiState(int playerId, EMatchPlayerUiState uiState)
		{
			foreach (MatchPlayerInfo matchPlayerInfo in this.MatchTeamInfo.PlayerInfos)
			{
				if (matchPlayerInfo.PlayerId == playerId)
				{
					matchPlayerInfo.MatchUiState = uiState;
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRefreshPlayerUiState, playerId);
		}

		// Token: 0x0603B7BD RID: 243645 RVA: 0x00F14394 File Offset: 0x00F12594
		public void SetPrewarPlayerReadyState(int playerId, bool ready)
		{
			this.PrewarPlayerReadyState[playerId] = ready;
			foreach (PrewarFormationData prewarFormationData in this.PrewarFormationDataList)
			{
				if (prewarFormationData.GetPlayerId() == playerId)
				{
					prewarFormationData.SetIsReady(ready);
				}
			}
		}

		// Token: 0x0603B7BE RID: 243646 RVA: 0x00F14400 File Offset: 0x00F12600
		public void RemovePrewarPlayerReadyState(int playerId)
		{
			this.PrewarPlayerReadyState.Remove(playerId);
		}

		// Token: 0x0603B7BF RID: 243647 RVA: 0x00F1440F File Offset: 0x00F1260F
		public void ClearPrewarPlayerReadyState()
		{
			this.PrewarPlayerReadyState.Clear();
		}

		// Token: 0x0603B7C0 RID: 243648 RVA: 0x00F1441C File Offset: 0x00F1261C
		public void RemoveMatchingTeamConfirmState(int playerId)
		{
			this.MatchingTeamConfirmState.Remove(playerId);
		}

		// Token: 0x0603B7C1 RID: 243649 RVA: 0x00F1442B File Offset: 0x00F1262B
		public void ClearMatchingTeamConfirmState()
		{
			this.MatchingTeamConfirmState.Clear();
		}

		// Token: 0x0603B7C2 RID: 243650 RVA: 0x00F14438 File Offset: 0x00F12638
		public bool GetPrewarPlayerReadyState(int playerId)
		{
			bool flag;
			return this.PrewarPlayerReadyState.TryGetValue(playerId, out flag) && flag && flag;
		}

		// Token: 0x0603B7C3 RID: 243651 RVA: 0x00F1445B File Offset: 0x00F1265B
		private void ParseMatchRoleInfo(PrewarFormationData data, MatchRoleInfo info)
		{
			data.SetLevel(info.RoleLevel);
			data.SetConfigId(info.RoleId);
			data.SetSkinId(info.RoleSkinId);
			data.SetMultiSkillBranchId(info.SkillBranchId);
		}

		// Token: 0x0603B7C4 RID: 243652 RVA: 0x00F14490 File Offset: 0x00F12690
		public void SetPrewarFormationDataList()
		{
			this.ClearPrewarData();
			MatchTeamInfo matchTeamInfo = this.GetMatchTeamInfo();
			if (matchTeamInfo == null)
			{
				return;
			}
			foreach (MatchPlayerInfo matchPlayerInfo in matchTeamInfo.PlayerInfos)
			{
				foreach (MatchRoleInfo info in matchPlayerInfo.RoleInfo)
				{
					PrewarFormationData prewarFormationData = new PrewarFormationData();
					prewarFormationData.SetPlayerId(matchPlayerInfo.PlayerId);
					prewarFormationData.SetIsReady(this.GetPrewarPlayerReadyState(matchPlayerInfo.PlayerId));
					prewarFormationData.SetLife(1);
					prewarFormationData.SetMaxLife(1);
					this.ParseMatchRoleInfo(prewarFormationData, info);
					this.PrewarFormationDataList.Add(prewarFormationData);
				}
			}
			this.SortPrewarFormationData();
		}

		// Token: 0x0603B7C5 RID: 243653 RVA: 0x00F14574 File Offset: 0x00F12774
		public void AddPrewarFormationDataByPlayerInfo(MatchPlayerInfo playerInfo, bool bChangeTeamInfo = true)
		{
			if (bChangeTeamInfo)
			{
				this.MatchTeamInfo.PlayerInfos.Add(playerInfo);
			}
			foreach (MatchRoleInfo info in playerInfo.RoleInfo)
			{
				PrewarFormationData prewarFormationData = new PrewarFormationData();
				prewarFormationData.SetPlayerId(playerInfo.PlayerId);
				prewarFormationData.SetIsReady(this.GetPrewarPlayerReadyState(playerInfo.PlayerId));
				prewarFormationData.SetLife(1);
				prewarFormationData.SetMaxLife(1);
				this.ParseMatchRoleInfo(prewarFormationData, info);
				this.PrewarFormationDataList.Add(prewarFormationData);
			}
			this.SortPrewarFormationData();
		}

		// Token: 0x0603B7C6 RID: 243654 RVA: 0x00F1461C File Offset: 0x00F1281C
		private void SortPrewarFormationData()
		{
			int hostId = this.GetMatchTeamInfo().HostId;
			int num = 1;
			int num2 = 1;
			foreach (PrewarFormationData prewarFormationData in this.PrewarFormationDataList)
			{
				if (prewarFormationData.GetPlayerId() == hostId)
				{
					prewarFormationData.SetIndex(num++);
					prewarFormationData.SetOnlineNumber(num2);
				}
			}
			num2++;
			foreach (PrewarFormationData prewarFormationData2 in this.PrewarFormationDataList)
			{
				if (prewarFormationData2.GetPlayerId() != hostId)
				{
					prewarFormationData2.SetIndex(num++);
					prewarFormationData2.SetOnlineNumber(num2++);
				}
			}
			this.PrewarFormationDataList.Sort((PrewarFormationData a, PrewarFormationData b) => a.GetIndex() - b.GetIndex());
		}

		// Token: 0x0603B7C7 RID: 243655 RVA: 0x00F14724 File Offset: 0x00F12924
		public void SetMatchTeamInfoPlayerRole(int playerId, RepeatedField<MatchRoleInfo> roleInfos)
		{
			foreach (MatchPlayerInfo matchPlayerInfo in this.MatchTeamInfo.PlayerInfos)
			{
				if (matchPlayerInfo.PlayerId == playerId)
				{
					int count = matchPlayerInfo.RoleInfo.Count;
					int count2 = roleInfos.Count;
					matchPlayerInfo.RoleInfo.Clear();
					matchPlayerInfo.RoleInfo.AddRange(roleInfos);
					if (count == count2)
					{
						this.ChangePrewarFormationDataRole(matchPlayerInfo);
					}
					if (count < count2)
					{
						this.ResetPrewarFormationDataByPlayer(playerId);
						this.AddPrewarFormationDataByPlayerInfo(matchPlayerInfo, false);
					}
					if (count > count2)
					{
						this.RemovePrewarFormationDataByPlayerInfo(matchPlayerInfo);
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.PrewarFormationChanged);
		}

		// Token: 0x0603B7C8 RID: 243656 RVA: 0x00F147DC File Offset: 0x00F129DC
		public IReadOnlyList<PrewarFormationData> GetPrewarFormationDataList()
		{
			return this.PrewarFormationDataList;
		}

		// Token: 0x0603B7C9 RID: 243657 RVA: 0x00F147E4 File Offset: 0x00F129E4
		public bool RemovePrewarFormationDataByPlayer(int playerId)
		{
			bool result = false;
			for (int i = this.PrewarFormationDataList.Count - 1; i >= 0; i--)
			{
				if (this.PrewarFormationDataList[i].GetPlayerId() == playerId)
				{
					result = true;
					this.PrewarFormationDataList.RemoveAt(i);
					this.RemovePrewarPlayerReadyState(playerId);
					this.RemoveMatchingTeamConfirmState(playerId);
				}
			}
			for (int j = this.MatchTeamInfo.PlayerInfos.Count - 1; j >= 0; j--)
			{
				MatchPlayerInfo matchPlayerInfo = this.MatchTeamInfo.PlayerInfos[j];
				if (matchPlayerInfo != null && matchPlayerInfo.PlayerId == playerId)
				{
					result = true;
					this.MatchTeamInfo.PlayerInfos.RemoveAt(j);
				}
			}
			this.SortPrewarFormationData();
			return result;
		}

		// Token: 0x0603B7CA RID: 243658 RVA: 0x00F14890 File Offset: 0x00F12A90
		private void ChangePrewarFormationDataRole(MatchPlayerInfo playerInfo)
		{
			int count = this.PrewarFormationDataList.Count;
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				PrewarFormationData prewarFormationData = this.PrewarFormationDataList[i];
				if (playerInfo.PlayerId == prewarFormationData.GetPlayerId())
				{
					MatchRoleInfo info = playerInfo.RoleInfo[num++];
					this.ParseMatchRoleInfo(prewarFormationData, info);
				}
			}
		}

		// Token: 0x0603B7CB RID: 243659 RVA: 0x00F148F0 File Offset: 0x00F12AF0
		private void RemovePrewarFormationDataByPlayerInfo(MatchPlayerInfo playerInfo)
		{
			int playerId = playerInfo.PlayerId;
			RepeatedField<MatchRoleInfo> roleInfo = playerInfo.RoleInfo;
			for (int i = this.PrewarFormationDataList.Count - 1; i >= 0; i--)
			{
				PrewarFormationData prewarFormationData = this.PrewarFormationDataList[i];
				if (prewarFormationData.GetPlayerId() == playerId)
				{
					bool flag = false;
					using (IEnumerator<MatchRoleInfo> enumerator = roleInfo.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.RoleId == prewarFormationData.GetConfigId())
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						this.PrewarFormationDataList.RemoveAt(i);
					}
				}
			}
			this.SortPrewarFormationData();
		}

		// Token: 0x0603B7CC RID: 243660 RVA: 0x00F1499C File Offset: 0x00F12B9C
		private void ResetPrewarFormationDataByPlayer(int playerId)
		{
			for (int i = this.PrewarFormationDataList.Count - 1; i >= 0; i--)
			{
				if (this.PrewarFormationDataList[i].GetPlayerId() == playerId)
				{
					this.PrewarFormationDataList.RemoveAt(i);
				}
			}
		}

		// Token: 0x0603B7CD RID: 243661 RVA: 0x00F149E4 File Offset: 0x00F12BE4
		public bool IsInPrewarFormation(int playerId)
		{
			using (List<PrewarFormationData>.Enumerator enumerator = this.PrewarFormationDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetPlayerId() == playerId)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603B7CE RID: 243662 RVA: 0x00F14A40 File Offset: 0x00F12C40
		public void ClearPrewarData()
		{
			this.PrewarFormationDataList.Clear();
		}

		// Token: 0x0603B7CF RID: 243663 RVA: 0x00F14A4D File Offset: 0x00F12C4D
		public int MatchingPlayerCount()
		{
			return this.MatchingTeamConfirmState.Count;
		}

		// Token: 0x1700978C RID: 38796
		// (get) Token: 0x0603B7D0 RID: 243664 RVA: 0x00F14A5C File Offset: 0x00F12C5C
		public int FormationAverageRoleLevel
		{
			get
			{
				int num = 0;
				EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
				if (getAllRoleSlotData == null)
				{
					return 0;
				}
				int num2 = 0;
				foreach (EditBattleRoleSlotData editBattleRoleSlotData in getAllRoleSlotData)
				{
					if (editBattleRoleSlotData.GetRoleData != null)
					{
						int num3 = num;
						EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
						num = num3 + ((getRoleData != null) ? getRoleData.Level : 0);
						num2++;
					}
				}
				if (num2 == 0)
				{
					return 0;
				}
				return num / num2;
			}
		}

		// Token: 0x0603B7D1 RID: 243665 RVA: 0x00F14AC4 File Offset: 0x00F12CC4
		public bool CheckPrewarFormationAverageLowLevel(int instanceId)
		{
			int fightFormationId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.FightFormationId;
			if (fightFormationId != 0)
			{
				Aki.Config.FightFormation value = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId).Value;
				if (value.AutoRoleLength > 0 && value.TrialRoleLength > 0)
				{
					return false;
				}
			}
			int formationAverageRoleLevel = this.FormationAverageRoleLevel;
			ValueTuple<bool, int> valueTuple = ModelBase<ActivityModel>.Instance.CheckActivityLevelBelongToType(instanceId);
			bool item = valueTuple.Item1;
			int item2 = valueTuple.Item2;
			if (item)
			{
				return formationAverageRoleLevel < ModelBase<ActivityModel>.Instance.GetActivityLevelRecommendLevel(instanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel, item2);
			}
			return formationAverageRoleLevel < ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(instanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
		}

		// Token: 0x0603B7D2 RID: 243666 RVA: 0x00F14B72 File Offset: 0x00F12D72
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<InstanceBeInviteData> GetInstanceBeInviteDataList()
		{
			return this.InstanceBeInviteDataList;
		}

		// Token: 0x0603B7D3 RID: 243667 RVA: 0x00F14B7A File Offset: 0x00F12D7A
		[NullableContext(2)]
		public void AddInstanceBeInviteData(InstanceBeInviteData data)
		{
			if (data == null)
			{
				return;
			}
			if (this.InstanceBeInviteDataList == null)
			{
				this.InstanceBeInviteDataList = new List<InstanceBeInviteData>();
			}
			else
			{
				this.RemoveInstanceBeInviteData(data.GetPlayerId());
			}
			this.InstanceBeInviteDataList.Add(data);
		}

		// Token: 0x0603B7D4 RID: 243668 RVA: 0x00F14BB0 File Offset: 0x00F12DB0
		public bool RemoveInstanceBeInviteData(int playerId)
		{
			for (int i = 0; i < this.InstanceBeInviteDataList.Count; i++)
			{
				if (this.InstanceBeInviteDataList[i].GetPlayerId() == playerId)
				{
					this.InstanceBeInviteDataList.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603B7D5 RID: 243669 RVA: 0x00F14BF8 File Offset: 0x00F12DF8
		public long GetInvitePlayerCd(int playerId)
		{
			long num;
			if (this.InviteCdMap.TryGetValue(playerId, out num) && num != 0L)
			{
				return num;
			}
			return 0L;
		}

		// Token: 0x0603B7D6 RID: 243670 RVA: 0x00F14C1C File Offset: 0x00F12E1C
		public void SetInvitePlayerCd(int playerId, long value)
		{
			this.InviteCdMap[playerId] = value;
		}

		// Token: 0x0603B7D7 RID: 243671 RVA: 0x00F14C2B File Offset: 0x00F12E2B
		public InstanceDungeonInfo CreateInstanceInfo(int id)
		{
			this.InstanceDungeonInfo = new InstanceDungeonInfo(id);
			this.InstanceDungeonInfo.InitConfig();
			return this.InstanceDungeonInfo;
		}

		// Token: 0x0603B7D8 RID: 243672 RVA: 0x00F14C4A File Offset: 0x00F12E4A
		public void ClearInstanceDungeonInfo()
		{
			if (this.InstanceDungeonInfo == null)
			{
				return;
			}
			LogicTreeContainer instanceDungeonInfo = this.InstanceDungeonInfo;
			this.InstanceDungeonInfo = null;
			instanceDungeonInfo.Destroy();
		}

		// Token: 0x0603B7D9 RID: 243673 RVA: 0x00F14C67 File Offset: 0x00F12E67
		[NullableContext(2)]
		public InstanceDungeonInfo GetInstanceDungeonInfo()
		{
			return this.InstanceDungeonInfo;
		}

		// Token: 0x0603B7DA RID: 243674 RVA: 0x00F14C6F File Offset: 0x00F12E6F
		public void ResetData()
		{
			this.ClearPrewarData();
			this.ClearPrewarPlayerReadyState();
			this.ClearMatchingTeamConfirmState();
			this.MatchTeamInfo = null;
		}

		// Token: 0x1700978D RID: 38797
		// (get) Token: 0x0603B7DB RID: 243675 RVA: 0x00F14C8A File Offset: 0x00F12E8A
		// (set) Token: 0x0603B7DC RID: 243676 RVA: 0x00F14C92 File Offset: 0x00F12E92
		[Nullable(2)]
		public List<int> LastEnterRoleList { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x0603B7DD RID: 243677 RVA: 0x00F14C9B File Offset: 0x00F12E9B
		public void SetInstanceDungeonName(string name)
		{
			this.InstanceDungeonName = name;
		}

		// Token: 0x0603B7DE RID: 243678 RVA: 0x00F14CA4 File Offset: 0x00F12EA4
		[NullableContext(2)]
		public string GetInstanceDungeonName()
		{
			return this.InstanceDungeonName;
		}

		// Token: 0x0603B7DF RID: 243679 RVA: 0x00F14CAC File Offset: 0x00F12EAC
		public void ConstructCurrentDungeonAreaName()
		{
			this.InstanceDungeonName = null;
			if (ModelBase<TowerModel>.Instance.CheckInTower())
			{
				this.SetInstanceDungeonName(ModelBase<TowerModel>.Instance.GetCurrentFloorName());
			}
		}

		// Token: 0x0603B7E0 RID: 243680 RVA: 0x00F14CD1 File Offset: 0x00F12ED1
		public void ClearInstanceEnterContentText()
		{
			this.InstanceEnterContentText = new EnterInstContext();
		}

		// Token: 0x0603B7E1 RID: 243681 RVA: 0x00F14CE0 File Offset: 0x00F12EE0
		public unsafe IInstanceDungeonExitConfirmBoxData ParseExitDungeonConfirmData(InstanceDungeon dungeonConfig)
		{
			Span<int> exitDungeonConfirmIdBytes = dungeonConfig.GetExitDungeonConfirmIdBytes();
			return new InstanceDungeonExitConfirmBoxData
			{
				ParseRuleType = (EInstanceDungeonExitConfirmBoxParseRule)((dungeonConfig.ExitDungeonConfirmIdLength > 0) ? (*exitDungeonConfirmIdBytes[0]) : 0),
				UnfinishedBoxId = ((dungeonConfig.ExitDungeonConfirmIdLength > 1) ? new int?(*exitDungeonConfirmIdBytes[1]) : null),
				FinishBoxId = ((dungeonConfig.ExitDungeonConfirmIdLength > 2) ? new int?(*exitDungeonConfirmIdBytes[2]) : null),
				UnfinishedTelBoxId = ((dungeonConfig.ExitDungeonConfirmIdLength > 3) ? new int?(*exitDungeonConfirmIdBytes[3]) : null),
				FinishTelBoxId = ((dungeonConfig.ExitDungeonConfirmIdLength > 4) ? new int?(*exitDungeonConfirmIdBytes[4]) : null)
			};
		}

		// Token: 0x0603B7E2 RID: 243682 RVA: 0x00F14DBC File Offset: 0x00F12FBC
		public IInstanceDungeonExitConfirmBoxData GetCurrentDungeonExitConfirmData()
		{
			IInstanceDungeonExitConfirmBoxData instanceDungeonExitConfirmBoxData = this.ParseExitDungeonConfirmData(ModelBase<GameModeModel>.Instance.InstanceDungeon.Value);
			int id = ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.Id;
			EDungeonSubType instSubType = (EDungeonSubType)ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.InstSubType;
			if (instanceDungeonExitConfirmBoxData.ParseRuleType == EInstanceDungeonExitConfirmBoxParseRule.ConfirmBox && (instSubType == EDungeonSubType.RolePlot || instSubType == EDungeonSubType.MainLine || instSubType == EDungeonSubType.SingleDungeon))
			{
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonSupportArchive(id))
				{
					if (instanceDungeonExitConfirmBoxData.UnfinishedBoxId.GetValueOrDefault() == 0)
					{
						instanceDungeonExitConfirmBoxData.UnfinishedBoxId = new int?(284);
					}
					if (instanceDungeonExitConfirmBoxData.UnfinishedTelBoxId.GetValueOrDefault() == 0)
					{
						instanceDungeonExitConfirmBoxData.UnfinishedTelBoxId = new int?(284);
					}
				}
				else
				{
					if (instanceDungeonExitConfirmBoxData.UnfinishedBoxId.GetValueOrDefault() == 0)
					{
						instanceDungeonExitConfirmBoxData.UnfinishedBoxId = new int?(285);
					}
					if (instanceDungeonExitConfirmBoxData.UnfinishedTelBoxId.GetValueOrDefault() == 0)
					{
						instanceDungeonExitConfirmBoxData.UnfinishedTelBoxId = new int?(285);
					}
				}
				if (instanceDungeonExitConfirmBoxData.FinishBoxId.GetValueOrDefault() == 0)
				{
					instanceDungeonExitConfirmBoxData.FinishBoxId = new int?(290);
				}
				if (instanceDungeonExitConfirmBoxData.FinishTelBoxId.GetValueOrDefault() == 0)
				{
					instanceDungeonExitConfirmBoxData.FinishTelBoxId = new int?(290);
				}
			}
			return instanceDungeonExitConfirmBoxData;
		}

		// Token: 0x0603B7E3 RID: 243683 RVA: 0x00F14F0C File Offset: 0x00F1310C
		public int? GetCurrentDungeonExitConfirmId()
		{
			IInstanceDungeonExitConfirmBoxData currentDungeonExitConfirmData = this.GetCurrentDungeonExitConfirmData();
			if (this.InstanceFinishSuccess != EInstanceFinishState.UnFinish)
			{
				return currentDungeonExitConfirmData.FinishBoxId;
			}
			return currentDungeonExitConfirmData.UnfinishedBoxId;
		}

		// Token: 0x0603B7E4 RID: 243684 RVA: 0x00F14F38 File Offset: 0x00F13138
		public int? GetCurrentDungeonTelExitConfirmId()
		{
			IInstanceDungeonExitConfirmBoxData currentDungeonExitConfirmData = this.GetCurrentDungeonExitConfirmData();
			if (ModelBase<InstanceDungeonModel>.Instance.InstanceFinishSuccess != EInstanceFinishState.UnFinish)
			{
				return currentDungeonExitConfirmData.FinishTelBoxId;
			}
			return currentDungeonExitConfirmData.UnfinishedTelBoxId;
		}

		// Token: 0x0603B7E5 RID: 243685 RVA: 0x00F14F65 File Offset: 0x00F13165
		public void ClearInstanceIdsWithSaveData()
		{
			this.InstanceIdsWithSaveData.Clear();
		}

		// Token: 0x0603B7E6 RID: 243686 RVA: 0x00F14F74 File Offset: 0x00F13174
		public void AddInstanceIdsWithSaveData(params int[] ids)
		{
			foreach (int item in ids)
			{
				this.InstanceIdsWithSaveData.Add(item);
			}
		}

		// Token: 0x0603B7E7 RID: 243687 RVA: 0x00F14FA2 File Offset: 0x00F131A2
		public bool GetIfInstanceHasSaveData(int instId)
		{
			return this.InstanceIdsWithSaveData.Contains(instId);
		}

		// Token: 0x04021819 RID: 137241
		private const int MATCHINGTEAMSIZE = 3;

		// Token: 0x0402181A RID: 137242
		private int InstanceId;

		// Token: 0x0402181C RID: 137244
		[Nullable(2)]
		private MatchTeamInfo MatchTeamInfo;

		// Token: 0x0402181D RID: 137245
		private readonly Dictionary<int, bool> MatchingTeamConfirmState = new Dictionary<int, bool>();

		// Token: 0x0402181E RID: 137246
		private readonly List<PrewarFormationData> PrewarFormationDataList = new List<PrewarFormationData>();

		// Token: 0x0402181F RID: 137247
		private readonly Dictionary<int, bool> PrewarPlayerReadyState = new Dictionary<int, bool>();

		// Token: 0x04021820 RID: 137248
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<InstanceBeInviteData> InstanceBeInviteDataList;

		// Token: 0x04021821 RID: 137249
		private readonly Dictionary<int, long> InviteCdMap = new Dictionary<int, long>();

		// Token: 0x04021822 RID: 137250
		public EInstanceFinishState InstanceFinishSuccess;

		// Token: 0x04021823 RID: 137251
		public bool InstanceRewardHaveTake;

		// Token: 0x04021824 RID: 137252
		[Nullable(2)]
		private InstanceDungeonInfo InstanceDungeonInfo;

		// Token: 0x04021826 RID: 137254
		[Nullable(2)]
		private string InstanceDungeonName;

		// Token: 0x04021827 RID: 137255
		public bool? CurrentInstanceIsFinish = new bool?(false);

		// Token: 0x04021828 RID: 137256
		public bool HidePowerLackConfirmBox;

		// Token: 0x04021829 RID: 137257
		public EnterInstContext InstanceEnterContentText = new EnterInstContext();

		// Token: 0x0402182A RID: 137258
		public List<int> TrialRoleDungeonWhiteList = new List<int>();

		// Token: 0x0402182B RID: 137259
		private readonly HashSet<int> InstanceIdsWithSaveData = new HashSet<int>();
	}
}
