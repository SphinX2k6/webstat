using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001AC1 RID: 6849
[NullableContext(1)]
[Nullable(0)]
public class AbyssChallengeInfo
{
	// Token: 0x0600C4B5 RID: 50357 RVA: 0x0033EA10 File Offset: 0x0033CC10
	public void RefreshPlayerName(bool mode)
	{
		int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		if (this.PlayerNameMap.ContainsKey(value))
		{
			string value2 = (!mode) ? "" : ModelBase<PlayerInfoModel>.Instance.GetAccountName(true);
			this.PlayerNameMap[value] = value2;
		}
	}

	// Token: 0x0600C4B6 RID: 50358 RVA: 0x0033EA64 File Offset: 0x0033CC64
	public DangoAbyssRankRoleData[] GetDangoAbyssRankRoleData()
	{
		if (this.RankRoleDataList.Length == 0)
		{
			List<DangoAbyssRankRoleData> list = new List<DangoAbyssRankRoleData>();
			if (!this.GetIsSingle())
			{
				int i = 0;
				int num = this.PlayerInfoList.Length;
				while (i < num)
				{
					foreach (AbyssChallengePassRoleInfo abyssChallengePassRoleInfo in this.PlayerInfoList[i].GetPassRoleInfoList())
					{
						list.Add(new DangoAbyssRankRoleData
						{
							RoleSkinId = abyssChallengePassRoleInfo.GetRoleSkinId(),
							RoleLevel = abyssChallengePassRoleInfo.GetRoleLevel(),
							DangoId = abyssChallengePassRoleInfo.GetDangoId(),
							DangoEquipIds = abyssChallengePassRoleInfo.GetEquipmentList(),
							IsOnline = true,
							IsEmpty = false,
							Pos = i
						});
					}
					i++;
				}
				for (int k = list.Count; k < 3; k++)
				{
					DangoAbyssRankRoleData item = new DangoAbyssRankRoleData();
					list.Add(item);
				}
			}
			else if (this.PlayerInfoList.Length != 0)
			{
				foreach (AbyssChallengePassRoleInfo abyssChallengePassRoleInfo2 in this.PlayerInfoList[0].GetPassRoleInfoList())
				{
					list.Add(new DangoAbyssRankRoleData
					{
						RoleSkinId = abyssChallengePassRoleInfo2.GetRoleSkinId(),
						RoleLevel = abyssChallengePassRoleInfo2.GetRoleLevel(),
						DangoId = abyssChallengePassRoleInfo2.GetDangoId(),
						DangoEquipIds = abyssChallengePassRoleInfo2.GetEquipmentList(),
						IsOnline = false,
						IsEmpty = false
					});
				}
				for (int l = list.Count; l < 3; l++)
				{
					DangoAbyssRankRoleData item2 = new DangoAbyssRankRoleData();
					list.Add(item2);
				}
			}
			this.RankRoleDataList = list.ToArray();
		}
		return this.RankRoleDataList;
	}

	// Token: 0x17001000 RID: 4096
	// (get) Token: 0x0600C4B7 RID: 50359 RVA: 0x0033EC16 File Offset: 0x0033CE16
	public bool IsEmpty
	{
		get
		{
			return this.PlayerInfoList.Length == 0;
		}
	}

	// Token: 0x0600C4B8 RID: 50360 RVA: 0x0033EC22 File Offset: 0x0033CE22
	public global::AbyssChallengePassPlayerInfo[] GetPlayerInfoList()
	{
		return this.PlayerInfoList;
	}

	// Token: 0x0600C4B9 RID: 50361 RVA: 0x0033EC2A File Offset: 0x0033CE2A
	public int GetPassTime()
	{
		return this.PassTime;
	}

	// Token: 0x0600C4BA RID: 50362 RVA: 0x0033EC32 File Offset: 0x0033CE32
	public int GetProgress()
	{
		return this.PassWave;
	}

	// Token: 0x0600C4BB RID: 50363 RVA: 0x0033EC3A File Offset: 0x0033CE3A
	public int GetChallengeId()
	{
		return this.ChallengeId;
	}

	// Token: 0x0600C4BC RID: 50364 RVA: 0x0033EC42 File Offset: 0x0033CE42
	public bool GetIsSingle()
	{
		return this.IsSingle;
	}

	// Token: 0x0600C4BD RID: 50365 RVA: 0x0033EC4A File Offset: 0x0033CE4A
	public bool GetShowName()
	{
		return this.ShowName;
	}

	// Token: 0x0600C4BE RID: 50366 RVA: 0x0033EC52 File Offset: 0x0033CE52
	public int GetOwnerId()
	{
		return this.OwnerId;
	}

	// Token: 0x0600C4BF RID: 50367 RVA: 0x0033EC5A File Offset: 0x0033CE5A
	public void SetNameMode(bool mode)
	{
		this.ShowName = mode;
	}

	// Token: 0x0600C4C0 RID: 50368 RVA: 0x0033EC64 File Offset: 0x0033CE64
	public void Phrase(Aki.Protocol.AbyssChallengeInfo data)
	{
		this.PlayerInfoList = Array.Empty<global::AbyssChallengePassPlayerInfo>();
		this.RankRoleDataList = Array.Empty<DangoAbyssRankRoleData>();
		List<global::AbyssChallengePassPlayerInfo> list = new List<global::AbyssChallengePassPlayerInfo>();
		int count = data.PlayerInfos.Count;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		this.PlayerNameMap.Clear();
		for (int i = 0; i < count; i++)
		{
			global::AbyssChallengePassPlayerInfo abyssChallengePassPlayerInfo = new global::AbyssChallengePassPlayerInfo();
			abyssChallengePassPlayerInfo.Phrase(data.PlayerInfos[i]);
			list.Add(abyssChallengePassPlayerInfo);
			this.PlayerNameMap[abyssChallengePassPlayerInfo.GetPlayerId()] = abyssChallengePassPlayerInfo.GetName();
			int? num = id;
			int playerId = abyssChallengePassPlayerInfo.GetPlayerId();
			if (num.GetValueOrDefault() == playerId & num != null)
			{
				this.IsSelfInData = true;
			}
		}
		this.PlayerInfoList = list.ToArray();
		this.PassTime = data.PassTime;
		this.ChallengeId = data.ChallengeId;
		this.IsSingle = data.IsSingle;
		this.ShowName = data.ShowName;
		this.OwnerId = data.OwnerId;
		this.PassWave = data.PassWave;
	}

	// Token: 0x17001001 RID: 4097
	// (get) Token: 0x0600C4C1 RID: 50369 RVA: 0x0033ED72 File Offset: 0x0033CF72
	public string RankBg
	{
		get
		{
			if (this.IsFirst)
			{
				return "T_AnniversaryCelebrationRankBg_1";
			}
			if (this.IsSecond)
			{
				return "T_AnniversaryCelebrationRankBg_2";
			}
			if (this.IsThird)
			{
				return "T_AnniversaryCelebrationRankBg_3";
			}
			return "T_AnniversaryCelebrationRankBgOther";
		}
	}

	// Token: 0x17001002 RID: 4098
	// (get) Token: 0x0600C4C2 RID: 50370 RVA: 0x0033EDA3 File Offset: 0x0033CFA3
	public bool IsFirst
	{
		get
		{
			return this.Rank == 1 && this.IsInRank;
		}
	}

	// Token: 0x17001003 RID: 4099
	// (get) Token: 0x0600C4C3 RID: 50371 RVA: 0x0033EDB6 File Offset: 0x0033CFB6
	public bool IsSecond
	{
		get
		{
			return this.Rank == 2 && this.IsInRank;
		}
	}

	// Token: 0x17001004 RID: 4100
	// (get) Token: 0x0600C4C4 RID: 50372 RVA: 0x0033EDC9 File Offset: 0x0033CFC9
	public bool IsThird
	{
		get
		{
			return this.Rank == 3 && this.IsInRank;
		}
	}

	// Token: 0x0600C4C5 RID: 50373 RVA: 0x0033EDDC File Offset: 0x0033CFDC
	public Dictionary<int, string> GetPlayerNameMap()
	{
		return this.PlayerNameMap;
	}

	// Token: 0x04005E5A RID: 24154
	public bool IsSelf;

	// Token: 0x04005E5B RID: 24155
	public bool IsSelfInData;

	// Token: 0x04005E5C RID: 24156
	public bool IsInRank = true;

	// Token: 0x04005E5D RID: 24157
	private readonly Dictionary<int, string> PlayerNameMap = new Dictionary<int, string>();

	// Token: 0x04005E5E RID: 24158
	private global::AbyssChallengePassPlayerInfo[] PlayerInfoList = Array.Empty<global::AbyssChallengePassPlayerInfo>();

	// Token: 0x04005E5F RID: 24159
	private int PassTime;

	// Token: 0x04005E60 RID: 24160
	private int ChallengeId;

	// Token: 0x04005E61 RID: 24161
	private bool IsSingle;

	// Token: 0x04005E62 RID: 24162
	private bool ShowName;

	// Token: 0x04005E63 RID: 24163
	private int OwnerId;

	// Token: 0x04005E64 RID: 24164
	private int PassWave;

	// Token: 0x04005E65 RID: 24165
	public int Rank;

	// Token: 0x04005E66 RID: 24166
	private DangoAbyssRankRoleData[] RankRoleDataList = Array.Empty<DangoAbyssRankRoleData>();
}
