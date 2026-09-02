using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004E9F RID: 20127
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRankItemData
	{
		// Token: 0x17008933 RID: 35123
		// (get) Token: 0x0603400E RID: 213006 RVA: 0x00D02479 File Offset: 0x00D00679
		public bool IsEmpty
		{
			get
			{
				return this.ServerData.PlayerPassInfo.Count == 0;
			}
		}

		// Token: 0x17008934 RID: 35124
		// (get) Token: 0x0603400F RID: 213007 RVA: 0x00D0248E File Offset: 0x00D0068E
		public int PassScore
		{
			get
			{
				if (this.IsDifficult)
				{
					return this.ServerData.PassTime;
				}
				return this.ServerData.Score;
			}
		}

		// Token: 0x17008935 RID: 35125
		// (get) Token: 0x06034010 RID: 213008 RVA: 0x00D024AF File Offset: 0x00D006AF
		public int PassTime
		{
			get
			{
				return this.ServerData.PassTime;
			}
		}

		// Token: 0x06034011 RID: 213009 RVA: 0x00D024BC File Offset: 0x00D006BC
		public TowerDefenseRankItemData(bool isOnline, bool isDifficult, TowerDefencePassInfo data)
		{
			this.IsOnline = isOnline;
			this.IsDifficult = isDifficult;
			this.ServerData = data;
			this.InitRoleDataList();
			this.InitPlayerNameList();
			this.IsSelfInData = this.GetIsInSelfData();
		}

		// Token: 0x06034012 RID: 213010 RVA: 0x00D0251C File Offset: 0x00D0071C
		private void InitRoleDataList()
		{
			if (this.IsOnline)
			{
				int i = 0;
				int count = this.ServerData.PlayerPassInfo.Count;
				while (i < count)
				{
					foreach (TowerDefenceRolePassInfo towerDefenceRolePassInfo in this.ServerData.PlayerPassInfo[i].RoleList)
					{
						TowerDefenseRankRoleData towerDefenseRankRoleData = new TowerDefenseRankRoleData();
						towerDefenseRankRoleData.RoleSkinId = towerDefenceRolePassInfo.RoleSkinId;
						towerDefenseRankRoleData.RoleLevel = towerDefenceRolePassInfo.RoleLevel;
						towerDefenseRankRoleData.PhantomId = towerDefenceRolePassInfo.PhantomId;
						towerDefenseRankRoleData.IsOnline = true;
						towerDefenseRankRoleData.IsEmpty = false;
						towerDefenseRankRoleData.Pos = i;
						this.RoleDataList.Add(towerDefenseRankRoleData);
					}
					i++;
				}
				for (int j = this.RoleDataList.Count; j < 3; j++)
				{
					TowerDefenseRankRoleData item = new TowerDefenseRankRoleData();
					this.RoleDataList.Add(item);
				}
				return;
			}
			if (this.ServerData.PlayerPassInfo.Count > 0)
			{
				foreach (TowerDefenceRolePassInfo towerDefenceRolePassInfo2 in this.ServerData.PlayerPassInfo[0].RoleList)
				{
					TowerDefenseRankRoleData towerDefenseRankRoleData2 = new TowerDefenseRankRoleData();
					towerDefenseRankRoleData2.RoleSkinId = towerDefenceRolePassInfo2.RoleSkinId;
					towerDefenseRankRoleData2.RoleLevel = towerDefenceRolePassInfo2.RoleLevel;
					towerDefenseRankRoleData2.PhantomId = towerDefenceRolePassInfo2.PhantomId;
					towerDefenseRankRoleData2.IsOnline = false;
					towerDefenseRankRoleData2.IsEmpty = false;
					this.RoleDataList.Add(towerDefenseRankRoleData2);
				}
				for (int k = this.RoleDataList.Count; k < 3; k++)
				{
					TowerDefenseRankRoleData item2 = new TowerDefenseRankRoleData();
					this.RoleDataList.Add(item2);
				}
			}
		}

		// Token: 0x06034013 RID: 213011 RVA: 0x00D026FC File Offset: 0x00D008FC
		private void InitPlayerNameList()
		{
			foreach (TowerDefencePassPlayerInfo towerDefencePassPlayerInfo in this.ServerData.PlayerPassInfo)
			{
				this.PlayerNameMap[towerDefencePassPlayerInfo.PlayerId] = towerDefencePassPlayerInfo.Name;
			}
		}

		// Token: 0x06034014 RID: 213012 RVA: 0x00D02760 File Offset: 0x00D00960
		private bool GetIsInSelfData()
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			foreach (TowerDefencePassPlayerInfo towerDefencePassPlayerInfo in this.ServerData.PlayerPassInfo)
			{
				int playerId = towerDefencePassPlayerInfo.PlayerId;
				int? num = id;
				if (playerId == num.GetValueOrDefault() & num != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06034015 RID: 213013 RVA: 0x00D027D8 File Offset: 0x00D009D8
		public List<ITowerDefenseRankPlayerName> GetPlayerNameList()
		{
			List<ITowerDefenseRankPlayerName> list = new List<ITowerDefenseRankPlayerName>();
			foreach (TowerDefencePassPlayerInfo towerDefencePassPlayerInfo in this.ServerData.PlayerPassInfo)
			{
				string playerName = this.PlayerNameMap[towerDefencePassPlayerInfo.PlayerId];
				list.Add(new TowerDefenseRankPlayerName
				{
					PlayerId = towerDefencePassPlayerInfo.PlayerId,
					PlayerName = playerName
				});
			}
			return list;
		}

		// Token: 0x06034016 RID: 213014 RVA: 0x00D0285C File Offset: 0x00D00A5C
		public void RefreshPlayerName(bool isIsOpenAnonymousName)
		{
			int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
			if (this.PlayerNameMap.ContainsKey(value))
			{
				string value2 = isIsOpenAnonymousName ? "" : ModelBase<PlayerInfoModel>.Instance.GetAccountName(true);
				this.PlayerNameMap[value] = value2;
			}
		}

		// Token: 0x17008936 RID: 35126
		// (get) Token: 0x06034017 RID: 213015 RVA: 0x00D028AD File Offset: 0x00D00AAD
		public string TopThreeNumColor
		{
			get
			{
				if (this.IsFirst)
				{
					return "CB9C38FF";
				}
				if (this.IsSecond)
				{
					return "6A7E9DFF";
				}
				if (this.IsThird)
				{
					return "997E76FF";
				}
				return "FFFFFFFF";
			}
		}

		// Token: 0x17008937 RID: 35127
		// (get) Token: 0x06034018 RID: 213016 RVA: 0x00D028DE File Offset: 0x00D00ADE
		public string RankBg
		{
			get
			{
				if (this.IsFirst)
				{
					return "T_TipItemBgGold";
				}
				if (this.IsSecond)
				{
					return "T_TipItemBgSilver";
				}
				if (this.IsThird)
				{
					return "T_TipItemBgCopper";
				}
				return "T_TipItemBgMask";
			}
		}

		// Token: 0x17008938 RID: 35128
		// (get) Token: 0x06034019 RID: 213017 RVA: 0x00D0290F File Offset: 0x00D00B0F
		public bool IsFirst
		{
			get
			{
				return this.Rank == 1 && this.IsInRank;
			}
		}

		// Token: 0x17008939 RID: 35129
		// (get) Token: 0x0603401A RID: 213018 RVA: 0x00D02922 File Offset: 0x00D00B22
		public bool IsSecond
		{
			get
			{
				return this.Rank == 2 && this.IsInRank;
			}
		}

		// Token: 0x1700893A RID: 35130
		// (get) Token: 0x0603401B RID: 213019 RVA: 0x00D02935 File Offset: 0x00D00B35
		public bool IsThird
		{
			get
			{
				return this.Rank == 3 && this.IsInRank;
			}
		}

		// Token: 0x1700893B RID: 35131
		// (get) Token: 0x0603401C RID: 213020 RVA: 0x00D02948 File Offset: 0x00D00B48
		public bool IsTopThree
		{
			get
			{
				return this.IsFirst || this.IsSecond || this.IsThird;
			}
		}

		// Token: 0x0401E0E5 RID: 123109
		public const string FIRSTPLAYER_COLOR = "CB9C38FF";

		// Token: 0x0401E0E6 RID: 123110
		public const string SECONDPLAYER_COLOR = "6A7E9DFF";

		// Token: 0x0401E0E7 RID: 123111
		public const string THIRDPLAYER_COLOR = "997E76FF";

		// Token: 0x0401E0E8 RID: 123112
		public const string FIRST_RANKBG = "T_TipItemBgGold";

		// Token: 0x0401E0E9 RID: 123113
		public const string SECOND_RANKBG = "T_TipItemBgSilver";

		// Token: 0x0401E0EA RID: 123114
		public const string THIRD_RANKBG = "T_TipItemBgCopper";

		// Token: 0x0401E0EB RID: 123115
		public const string OTHER_RANKBG = "T_TipItemBgMask";

		// Token: 0x0401E0EC RID: 123116
		public const int MAX_COUNT = 3;

		// Token: 0x0401E0ED RID: 123117
		public readonly bool IsSelfInData;

		// Token: 0x0401E0EE RID: 123118
		public TowerDefencePassInfo ServerData;

		// Token: 0x0401E0EF RID: 123119
		public bool IsOnline;

		// Token: 0x0401E0F0 RID: 123120
		public bool IsDifficult;

		// Token: 0x0401E0F1 RID: 123121
		public bool IsInRank = true;

		// Token: 0x0401E0F2 RID: 123122
		public bool IsSelf;

		// Token: 0x0401E0F3 RID: 123123
		public int Rank;

		// Token: 0x0401E0F4 RID: 123124
		public readonly List<TowerDefenseRankRoleData> RoleDataList = new List<TowerDefenseRankRoleData>();

		// Token: 0x0401E0F5 RID: 123125
		private readonly Dictionary<int, string> PlayerNameMap = new Dictionary<int, string>();
	}
}
