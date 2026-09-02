using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020013D7 RID: 5079
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MoonChasingBusinessModel : ModelBase<MoonChasingBusinessModel>
{
	// Token: 0x17000BE3 RID: 3043
	// (get) Token: 0x06008C5E RID: 35934 RVA: 0x0024E6CC File Offset: 0x0024C8CC
	public bool IsInDelegate
	{
		get
		{
			return this.IsInDelegateInternal;
		}
	}

	// Token: 0x06008C5F RID: 35935 RVA: 0x0024E6D4 File Offset: 0x0024C8D4
	protected override bool OnInit()
	{
		IReadOnlyList<EntrustRole> configList = ConfigEntrustRoleAll.GetConfigList(true);
		if (configList != null)
		{
			for (int i = 0; i < configList.Count; i++)
			{
				EntrustRole entrustRole = configList[i];
				EditTeamData value = new EditTeamData(entrustRole.Id, entrustRole.Type, entrustRole.UnLockCondition);
				this.EditTeamDataMap[entrustRole.Id] = value;
			}
		}
		return true;
	}

	// Token: 0x06008C60 RID: 35936 RVA: 0x0024E734 File Offset: 0x0024C934
	public void SetAllDelegationData(IReadOnlyList<EntrustInfo> dataList)
	{
		for (int i = 0; i < dataList.Count; i++)
		{
			this.SetDelegationData(dataList[i]);
		}
	}

	// Token: 0x06008C61 RID: 35937 RVA: 0x0024E760 File Offset: 0x0024C960
	public void SetDelegationData(EntrustInfo data)
	{
		DelegationData value = new DelegationData(data.EntrustId, data.HistoryLevel, data.IsVisiable);
		this.DelegationDataMap[data.EntrustId] = value;
	}

	// Token: 0x06008C62 RID: 35938 RVA: 0x0024E798 File Offset: 0x0024C998
	public void ReplaceDelegationData(int oldId, EntrustInfo newData)
	{
		if (oldId == newData.EntrustId)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.RefreshDelegate, false);
			return;
		}
		this.DelegationDataMap.Remove(oldId);
		this.SetDelegationData(newData);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.RefreshDelegate, true);
	}

	// Token: 0x06008C63 RID: 35939 RVA: 0x0024E7E5 File Offset: 0x0024C9E5
	public void ConditionUnlockDelegationData(EntrustInfo data)
	{
		this.SetDelegationData(data);
	}

	// Token: 0x06008C64 RID: 35940 RVA: 0x0024E7EE File Offset: 0x0024C9EE
	public DelegationData GetDelegationData(int id)
	{
		return this.DelegationDataMap[id];
	}

	// Token: 0x06008C65 RID: 35941 RVA: 0x0024E7FC File Offset: 0x0024C9FC
	public List<DelegationData> GetDelegationDataList()
	{
		List<DelegationData> list = new List<DelegationData>();
		foreach (DelegationData item in this.DelegationDataMap.Values)
		{
			list.Add(item);
		}
		list.Sort(delegate(DelegationData aData, DelegationData bData)
		{
			if (aData.IsVisible != bData.IsVisible)
			{
				if (!aData.IsVisible)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				TrackMoonEntrust valueOrDefault = ConfigTrackMoonEntrustById.GetConfig(aData.Id, true).GetValueOrDefault();
				TrackMoonEntrust valueOrDefault2 = ConfigTrackMoonEntrustById.GetConfig(bData.Id, true).GetValueOrDefault();
				if (valueOrDefault.Star != valueOrDefault2.Star)
				{
					if (valueOrDefault.Star >= valueOrDefault2.Star)
					{
						return 1;
					}
					return -1;
				}
				else if (aData.BestEvaluateLevel != bData.BestEvaluateLevel)
				{
					if (aData.BestEvaluateLevel >= bData.BestEvaluateLevel)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (aData.Id >= bData.Id)
					{
						return 1;
					}
					return -1;
				}
			}
		});
		return list;
	}

	// Token: 0x06008C66 RID: 35942 RVA: 0x0024E880 File Offset: 0x0024CA80
	public void SetAllEditTeamData(IReadOnlyList<EntrustRoleInfo> dataList)
	{
		for (int i = 0; i < dataList.Count; i++)
		{
			this.SetEditTeamData(dataList[i]);
		}
	}

	// Token: 0x06008C67 RID: 35943 RVA: 0x0024E8AC File Offset: 0x0024CAAC
	public void SetEditTeamData(EntrustRoleInfo data)
	{
		RoleProperSettle roleAttr = data.RoleAttr;
		if (roleAttr == null)
		{
			return;
		}
		EditTeamData editTeamData;
		if (!this.EditTeamDataMap.TryGetValue(roleAttr.RoleId, out editTeamData))
		{
			return;
		}
		editTeamData.IsOwn = true;
		editTeamData.SetCharacterDataList(roleAttr);
	}

	// Token: 0x06008C68 RID: 35944 RVA: 0x0024E8E8 File Offset: 0x0024CAE8
	public EditTeamData DeepCopyEditTeamData(EditTeamData editTeamData)
	{
		EditTeamData editTeamData2 = new EditTeamData(editTeamData.Id, editTeamData.Type, editTeamData.UnLockCondition);
		editTeamData2.SetCharacterDataByEditTeamData(editTeamData);
		return editTeamData2;
	}

	// Token: 0x06008C69 RID: 35945 RVA: 0x0024E908 File Offset: 0x0024CB08
	public void ConditionUnlockEditTeamData(EntrustRoleInfo data)
	{
		this.SetEditTeamData(data);
		RoleProperSettle roleAttr = data.RoleAttr;
		if (roleAttr != null)
		{
			this.UnlockRoleIdList.Add(roleAttr.RoleId);
			ModelBase<MoonChasingModel>.Instance.SaveRoleIdUnlockFlag(roleAttr.RoleId);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.ConditionUnlockRole);
	}

	// Token: 0x06008C6A RID: 35946 RVA: 0x0024E958 File Offset: 0x0024CB58
	public int? PopUnlockRoleId()
	{
		if (this.UnlockRoleIdList.Count == 0)
		{
			return null;
		}
		int value = this.UnlockRoleIdList[0];
		this.UnlockRoleIdList.RemoveAt(0);
		return new int?(value);
	}

	// Token: 0x06008C6B RID: 35947 RVA: 0x0024E999 File Offset: 0x0024CB99
	public bool IsUnlockRoleIdEmpty()
	{
		return this.UnlockRoleIdList.Count == 0;
	}

	// Token: 0x06008C6C RID: 35948 RVA: 0x0024E9AC File Offset: 0x0024CBAC
	public List<EditTeamData> GetHelpEditTeamDataList(bool withMainRole = false)
	{
		List<EditTeamData> list = new List<EditTeamData>();
		foreach (EditTeamData editTeamData in this.EditTeamDataMap.Values)
		{
			if (this.CheckTypeCanUse(editTeamData.Type) && (editTeamData.Type == 0 || withMainRole))
			{
				list.Add(editTeamData);
			}
		}
		list.Sort(new Comparison<EditTeamData>(this.SortHelpTeamData));
		return list;
	}

	// Token: 0x06008C6D RID: 35949 RVA: 0x0024EA38 File Offset: 0x0024CC38
	public List<EditTeamData> GetUnlockHelpEditTeamDataList(bool withMainRole = false)
	{
		List<EditTeamData> list = new List<EditTeamData>();
		foreach (EditTeamData editTeamData in this.EditTeamDataMap.Values)
		{
			if (this.CheckTypeCanUse(editTeamData.Type) && (editTeamData.Type == 0 || withMainRole) && editTeamData.IsOwn)
			{
				list.Add(editTeamData);
			}
		}
		list.Sort(new Comparison<EditTeamData>(this.SortHelpTeamData));
		return list;
	}

	// Token: 0x06008C6E RID: 35950 RVA: 0x0024EACC File Offset: 0x0024CCCC
	private int SortHelpTeamData(EditTeamData aData, EditTeamData bData)
	{
		if (aData.IsOwn != bData.IsOwn)
		{
			if (!aData.IsOwn)
			{
				return 1;
			}
			return -1;
		}
		else if (aData.Level != bData.Level)
		{
			if (aData.Level <= bData.Level)
			{
				return 1;
			}
			return -1;
		}
		else
		{
			int allCharacterValue = aData.GetAllCharacterValue();
			int allCharacterValue2 = bData.GetAllCharacterValue();
			if (allCharacterValue != allCharacterValue2)
			{
				if (allCharacterValue <= allCharacterValue2)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				bool flag = aData.GetTeamDataUnLockState() == EEditTeamDataUnLockState.TaskUnFinish;
				bool flag2 = bData.GetTeamDataUnLockState() == EEditTeamDataUnLockState.TaskUnFinish;
				if (flag != flag2)
				{
					if (!flag)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (aData.Id >= bData.Id)
					{
						return 1;
					}
					return -1;
				}
			}
		}
	}

	// Token: 0x06008C6F RID: 35951 RVA: 0x0024EB60 File Offset: 0x0024CD60
	public int GetPlayerRoleId()
	{
		foreach (EditTeamData editTeamData in this.EditTeamDataMap.Values)
		{
			if (this.CheckTypeCanUse(editTeamData.Type) && editTeamData.Type != 0)
			{
				return editTeamData.Id;
			}
		}
		return 0;
	}

	// Token: 0x06008C70 RID: 35952 RVA: 0x0024EBD4 File Offset: 0x0024CDD4
	private bool CheckTypeCanUse(int type)
	{
		PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
		return (type != 1 || instance.GetPlayerGender() == EPlayerGender.Male) && (type != 2 || instance.GetPlayerGender() == EPlayerGender.Female);
	}

	// Token: 0x06008C71 RID: 35953 RVA: 0x0024EC08 File Offset: 0x0024CE08
	public List<EditTeamData> GetOwnEditTeamDataList()
	{
		List<EditTeamData> list = new List<EditTeamData>();
		foreach (EditTeamData editTeamData in this.EditTeamDataMap.Values)
		{
			if (this.CheckTypeCanUse(editTeamData.Type) && editTeamData.IsOwn)
			{
				list.Add(editTeamData);
			}
		}
		list.Sort(delegate(EditTeamData aData, EditTeamData bData)
		{
			if (aData.Level != bData.Level)
			{
				if (aData.Level <= bData.Level)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				int allCharacterValue = aData.GetAllCharacterValue();
				int allCharacterValue2 = bData.GetAllCharacterValue();
				if (allCharacterValue != allCharacterValue2)
				{
					if (allCharacterValue <= allCharacterValue2)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (aData.Id >= bData.Id)
					{
						return 1;
					}
					return -1;
				}
			}
		});
		return list;
	}

	// Token: 0x06008C72 RID: 35954 RVA: 0x0024ECA4 File Offset: 0x0024CEA4
	public EditTeamData GetEditTeamDataById(int roleId)
	{
		return this.EditTeamDataMap[roleId];
	}

	// Token: 0x06008C73 RID: 35955 RVA: 0x0024ECB2 File Offset: 0x0024CEB2
	public void SetResultData(DelegationResultData resultData)
	{
		this.DelegationResultDataInternal = resultData;
		Singleton<EventSystem>.Instance.Emit(EEventName.SetDelegationResultData);
	}

	// Token: 0x06008C74 RID: 35956 RVA: 0x0024ECCB File Offset: 0x0024CECB
	public DelegationResultData GetResultData()
	{
		return this.DelegationResultDataInternal;
	}

	// Token: 0x06008C75 RID: 35957 RVA: 0x0024ECD4 File Offset: 0x0024CED4
	private List<CharacterData> CreateCharacterList(bool useScoreName)
	{
		List<CharacterData> list = new List<CharacterData>();
		for (int i = 1; i <= 3; i++)
		{
			CharacterData characterData = new CharacterData(i);
			characterData.SetUseScoreName(useScoreName);
			list.Add(characterData);
		}
		return list;
	}

	// Token: 0x06008C76 RID: 35958 RVA: 0x0024ED0C File Offset: 0x0024CF0C
	public List<CharacterData> GetCharacterValueListByRoleIds(IEnumerable<int> roleIds, bool useScoreName)
	{
		List<CharacterData> list = this.CreateCharacterList(useScoreName);
		foreach (int key in roleIds)
		{
			List<CharacterData> characterDataList = this.EditTeamDataMap[key].GetCharacterDataList();
			for (int i = 0; i < 3; i++)
			{
				CharacterData characterData = list[i];
				characterData.SetCurrentValue(characterData.CurrentValue + characterDataList[i].CurrentValue);
			}
		}
		return list;
	}

	// Token: 0x06008C77 RID: 35959 RVA: 0x0024ED9C File Offset: 0x0024CF9C
	public IInvestData GetInvestData(int invest)
	{
		TrackMoonEntrust valueOrDefault = ConfigTrackMoonEntrustById.GetConfig(this.GetResultData().EntrustId, true).GetValueOrDefault();
		float num;
		if (valueOrDefault.IdeaSuccRatioLength >= 2)
		{
			DicIntInt valueOrDefault2 = valueOrDefault.IdeaSuccRatio(0).GetValueOrDefault();
			DicIntInt valueOrDefault3 = valueOrDefault.IdeaSuccRatio(1).GetValueOrDefault();
			int key = valueOrDefault2.Key;
			int value = valueOrDefault2.Value;
			int key2 = valueOrDefault3.Key;
			int value2 = valueOrDefault3.Value;
			if (invest >= key2)
			{
				num = (float)value2 / 10f;
			}
			else
			{
				num = ((float)(value2 - value) / (float)(key2 - key) * (float)invest + (float)value) / 10f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = (valueOrDefault.IdeaSuccMulLength >= 1) ? ((float)valueOrDefault.IdeaSuccMul(0) / 1000f) : 0f;
		float num3 = (valueOrDefault.IdeaSuccMulLength >= 2) ? ((float)valueOrDefault.IdeaSuccMul(1) / 1000f) : 1f;
		float num4 = num2 * (float)invest / (num3 + (float)invest);
		return new InvestData
		{
			SuccessProbability = (int)num,
			Ratio = (int)((num4 + 1f) * 100f)
		};
	}

	// Token: 0x06008C78 RID: 35960 RVA: 0x0024EEB8 File Offset: 0x0024D0B8
	public Popularity GetCurrentPopularityConfig()
	{
		int popularityValue = ModelBase<MoonChasingModel>.Instance.GetPopularityValue();
		return this.GetPopularityConfigByValue(popularityValue);
	}

	// Token: 0x06008C79 RID: 35961 RVA: 0x0024EED8 File Offset: 0x0024D0D8
	public Popularity? GetLastPopularityConfig()
	{
		Popularity? result = null;
		IReadOnlyList<Popularity> configList = ConfigPopularityAll.GetConfigList(true);
		int popularityValue = ModelBase<MoonChasingModel>.Instance.GetPopularityValue();
		if (configList != null)
		{
			for (int i = 0; i < configList.Count; i++)
			{
				Popularity value = configList[i];
				if (value.PopularityValue > popularityValue)
				{
					break;
				}
				result = new Popularity?(value);
			}
		}
		return result;
	}

	// Token: 0x06008C7A RID: 35962 RVA: 0x0024EF30 File Offset: 0x0024D130
	public Popularity GetPopularityConfigByValue(int value)
	{
		IReadOnlyList<Popularity> configList = ConfigPopularityAll.GetConfigList(true);
		if (configList == null || configList.Count == 0)
		{
			return default(Popularity);
		}
		for (int i = 0; i < configList.Count; i++)
		{
			Popularity result = configList[i];
			if (result.PopularityValue > value)
			{
				return result;
			}
		}
		return configList[configList.Count - 1];
	}

	// Token: 0x06008C7B RID: 35963 RVA: 0x0024EF8C File Offset: 0x0024D18C
	public void SetIsInDelegate(bool value)
	{
		this.IsInDelegateInternal = value;
		if (!value)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.ConditionUnlockRole);
		}
	}

	// Token: 0x04004171 RID: 16753
	private readonly Dictionary<int, DelegationData> DelegationDataMap = new Dictionary<int, DelegationData>();

	// Token: 0x04004172 RID: 16754
	private readonly Dictionary<int, EditTeamData> EditTeamDataMap = new Dictionary<int, EditTeamData>();

	// Token: 0x04004173 RID: 16755
	private DelegationResultData DelegationResultDataInternal;

	// Token: 0x04004174 RID: 16756
	private readonly List<int> UnlockRoleIdList = new List<int>();

	// Token: 0x04004175 RID: 16757
	private bool IsInDelegateInternal;
}
