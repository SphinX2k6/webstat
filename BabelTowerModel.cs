using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001233 RID: 4659
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BabelTowerModel : ModelBase<BabelTowerModel>
{
	// Token: 0x17000AAB RID: 2731
	// (get) Token: 0x06007C02 RID: 31746 RVA: 0x002092A9 File Offset: 0x002074A9
	[Nullable(2)]
	public BabelTowerInstanceData CurrentChallengeInstData
	{
		[NullableContext(2)]
		get
		{
			return this.CurrentChallengeInstDataInternal;
		}
	}

	// Token: 0x06007C03 RID: 31747 RVA: 0x002092B1 File Offset: 0x002074B1
	public void SetTraceId(string traceId)
	{
		if (this.CurrentChallengeInstDataInternal != null)
		{
			this.CurrentChallengeInstDataInternal.TraceId = traceId;
		}
	}

	// Token: 0x06007C04 RID: 31748 RVA: 0x002092C8 File Offset: 0x002074C8
	protected override bool OnInit()
	{
		this.ItemCountMax = ConfigCommonParamById.GetIntConfig("BabelTowerItemCountMax").GetValueOrDefault();
		return true;
	}

	// Token: 0x06007C05 RID: 31749 RVA: 0x002092F0 File Offset: 0x002074F0
	public void UpdateCurrentChallengeInstDataByNotify(BabelActivityInstInfoNotify notify)
	{
		if (this.CurrentChallengeInstDataInternal == null)
		{
			this.CurrentChallengeInstDataInternal = new BabelTowerInstanceData();
		}
		int roleCD = notify.RoleCD;
		this.CurrentChallengeInstDataInternal.LevelId = notify.LevelId;
		this.CurrentChallengeInstDataInternal.CurStarNum = notify.CurStar;
		this.CurrentChallengeInstDataInternal.UseReviveCount = notify.UseReviveCount;
		this.CurrentChallengeInstDataInternal.RoleCd = roleCD;
		this.CurrentChallengeInstDataInternal.BuffSelection = ((notify.BuffSelection == null) ? null : new List<int>(notify.BuffSelection));
		this.CurrentChallengeInstDataInternal.DeTermIdList = ((notify.BabelDeTermId == null) ? null : new List<int>(notify.BabelDeTermId));
		if (roleCD > 0)
		{
			ModelBase<SceneTeamModel>.Instance.UpdateChangeRoleCooldown((float)roleCD);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnBabelActivityInstInfoUpdate);
	}

	// Token: 0x06007C06 RID: 31750 RVA: 0x002093B8 File Offset: 0x002075B8
	public bool GetIfLevelTooLow(int instanceId, int[] roleList)
	{
		int num = 0;
		int num2 = 0;
		foreach (int id in roleList)
		{
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(id);
			if (roleInstanceById != null)
			{
				num += roleInstanceById.GetLevelData().GetLevel();
				num2++;
			}
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
			if (roleDataById != null)
			{
				num += roleDataById.GetLevelData().GetLevel();
				num2++;
			}
		}
		if (num2 <= 0)
		{
			return false;
		}
		double num3 = (double)num / (double)num2;
		return num3 < (double)this.GetRecommendLevel(instanceId) && num3 != 0.0;
	}

	// Token: 0x06007C07 RID: 31751 RVA: 0x00209454 File Offset: 0x00207654
	public int GetRecommendLevel(int instanceId)
	{
		return ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(instanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
	}

	// Token: 0x06007C08 RID: 31752 RVA: 0x0020946C File Offset: 0x0020766C
	public BabelTowerDifficulty? CalculateDifficultyConfigByStarNum(int activityId, int starNum)
	{
		IReadOnlyList<BabelTowerDifficulty> configList = ConfigBabelTowerDifficultyByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			return null;
		}
		for (int i = configList.Count - 1; i >= 0; i--)
		{
			BabelTowerDifficulty value = configList[i];
			if (starNum >= value.StarNum)
			{
				return new BabelTowerDifficulty?(value);
			}
		}
		return null;
	}

	// Token: 0x06007C09 RID: 31753 RVA: 0x002094C4 File Offset: 0x002076C4
	public List<int> GetSelectedDeTermList()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in this.DeTermSelectInfo)
		{
			int key = keyValuePair.Key;
			IBabelTowerSelectInfo value = keyValuePair.Value;
			if (key != 0 && value.State == EBabelTowerDeTermState.Select)
			{
				list.Add(key);
			}
		}
		return list;
	}

	// Token: 0x06007C0A RID: 31754 RVA: 0x0020953C File Offset: 0x0020773C
	public List<int> GetAllActiveDeTermList()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in this.DeTermSelectInfo)
		{
			int key = keyValuePair.Key;
			IBabelTowerSelectInfo value = keyValuePair.Value;
			if (key != 0 && (value.State == EBabelTowerDeTermState.Select || value.State == EBabelTowerDeTermState.StaticSelect))
			{
				list.Add(key);
			}
		}
		return list;
	}

	// Token: 0x06007C0B RID: 31755 RVA: 0x002095C0 File Offset: 0x002077C0
	public int GetCurrentDeTermStar()
	{
		int num = 0;
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in this.DeTermSelectInfo)
		{
			int key = keyValuePair.Key;
			IBabelTowerSelectInfo value = keyValuePair.Value;
			if (key != 0 && (value.State == EBabelTowerDeTermState.Select || value.State == EBabelTowerDeTermState.StaticSelect))
			{
				num += ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(key).Star;
			}
		}
		return num;
	}

	// Token: 0x06007C0C RID: 31756 RVA: 0x00209650 File Offset: 0x00207850
	public int GetSelectedDeTermCount()
	{
		int num = 0;
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in this.DeTermSelectInfo)
		{
			IBabelTowerSelectInfo value = keyValuePair.Value;
			if (value.State == EBabelTowerDeTermState.Select || value.State == EBabelTowerDeTermState.StaticSelect)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06007C0D RID: 31757 RVA: 0x002096C0 File Offset: 0x002078C0
	[NullableContext(2)]
	public IBabelTowerSelectInfo GetDeTermSelectInfo(int deTermId)
	{
		return this.DeTermSelectInfo.GetValueOrDefault(deTermId);
	}

	// Token: 0x06007C0E RID: 31758 RVA: 0x002096CE File Offset: 0x002078CE
	public int CoverStarNumToQualityId(int starNum)
	{
		return starNum + 2;
	}

	// Token: 0x06007C0F RID: 31759 RVA: 0x002096D4 File Offset: 0x002078D4
	public bool CheckInBattleBabelTower()
	{
		if (!ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return false;
		}
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config != null && config.Value.InstSubType == 30;
	}

	// Token: 0x06007C10 RID: 31760 RVA: 0x00209728 File Offset: 0x00207928
	public bool CheckCanRevive()
	{
		BabelTowerInstanceData currentChallengeInstData = this.CurrentChallengeInstData;
		if (currentChallengeInstData == null)
		{
			return false;
		}
		BabelTowerLevel? config = ConfigBabelTowerLevelById.GetConfig(currentChallengeInstData.LevelId, true);
		int num = (config != null) ? config.Value.ReviveStar : 0;
		return currentChallengeInstData.CurStarNum >= num;
	}

	// Token: 0x06007C11 RID: 31761 RVA: 0x00209776 File Offset: 0x00207976
	public int GetCurStarNum()
	{
		BabelTowerInstanceData currentChallengeInstData = this.CurrentChallengeInstData;
		if (currentChallengeInstData == null)
		{
			return 0;
		}
		return currentChallengeInstData.CurStarNum;
	}

	// Token: 0x06007C12 RID: 31762 RVA: 0x0020978C File Offset: 0x0020798C
	public List<EditFormationData> GetPresetTeamList()
	{
		List<EditFormationData> list = new List<EditFormationData>();
		for (int i = 1; i <= 10; i++)
		{
			EditFormationData editFormationData = ModelBase<EditFormationModel>.Instance.GetFormationData(i);
			if (editFormationData == null)
			{
				editFormationData = new EditFormationData(i);
			}
			list.Add(editFormationData);
		}
		return list;
	}

	// Token: 0x06007C13 RID: 31763 RVA: 0x002097CC File Offset: 0x002079CC
	public List<IBabelTowerTeamTab> GetTeamTabList()
	{
		if (this.TeamTabList.Count > 0)
		{
			return this.TeamTabList;
		}
		this.TeamTabList.Add(new BabelTowerTeamTab
		{
			TabType = EBabelTowerTeamTabType.RoleList,
			Title = "GhostShipRoleList_Text"
		});
		this.TeamTabList.Add(new BabelTowerTeamTab
		{
			TabType = EBabelTowerTeamTabType.UseTeam,
			Title = "GhostShipPreTeam_Text"
		});
		return this.TeamTabList;
	}

	// Token: 0x04003B51 RID: 15185
	[Nullable(2)]
	private BabelTowerInstanceData CurrentChallengeInstDataInternal;

	// Token: 0x04003B52 RID: 15186
	public int ItemCountMax;

	// Token: 0x04003B53 RID: 15187
	public int CurrentQuickIndex = -1;

	// Token: 0x04003B54 RID: 15188
	public Dictionary<int, IBabelTowerSelectInfo> DeTermSelectInfo = new Dictionary<int, IBabelTowerSelectInfo>();

	// Token: 0x04003B55 RID: 15189
	public bool IsShowLeftTeamPanel;

	// Token: 0x04003B56 RID: 15190
	public int DeTermSelectIndex;

	// Token: 0x04003B57 RID: 15191
	public HashSet<int> ClearedDeTerms = new HashSet<int>();

	// Token: 0x04003B58 RID: 15192
	public int LevelChoseHandle;

	// Token: 0x04003B59 RID: 15193
	public int CurrentSelectLevel;

	// Token: 0x04003B5A RID: 15194
	private readonly List<IBabelTowerTeamTab> TeamTabList = new List<IBabelTowerTeamTab>();
}
