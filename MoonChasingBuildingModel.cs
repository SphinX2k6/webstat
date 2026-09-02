using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;

// Token: 0x020013AC RID: 5036
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MoonChasingBuildingModel : ModelBase<MoonChasingBuildingModel>
{
	// Token: 0x06008AC3 RID: 35523 RVA: 0x00248C20 File Offset: 0x00246E20
	protected override bool OnInit()
	{
		IReadOnlyList<Building> buildingAll = ConfigBase<BuildingConfig>.Instance.GetBuildingAll();
		if (buildingAll != null)
		{
			for (int i = 0; i < buildingAll.Count; i++)
			{
				Building building = buildingAll[i];
				BuildingData value = new BuildingData(building.Id);
				this.BuildingDataMap[building.Id] = value;
			}
		}
		return true;
	}

	// Token: 0x06008AC4 RID: 35524 RVA: 0x00248C78 File Offset: 0x00246E78
	public void SetAllBuildingData(IReadOnlyList<BuildingInfo> dataList)
	{
		for (int i = 0; i < dataList.Count; i++)
		{
			this.SetBuildingData(dataList[i]);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.TrackMoonHandbookUpdate);
	}

	// Token: 0x06008AC5 RID: 35525 RVA: 0x00248CB3 File Offset: 0x00246EB3
	public void SetBuildingData(BuildingInfo data)
	{
		BuildingData buildingData = this.BuildingDataMap[data.BuildingId];
		buildingData.IsUnlock = data.IsUnlock;
		buildingData.Level = data.Level;
		Singleton<EventSystem>.Instance.Emit(EEventName.MoonChasingRefreshBuildingRedDot);
	}

	// Token: 0x06008AC6 RID: 35526 RVA: 0x00248CED File Offset: 0x00246EED
	public void ConditionUnlockBuildingData(BuildingInfo data)
	{
		this.SetBuildingData(data);
	}

	// Token: 0x06008AC7 RID: 35527 RVA: 0x00248CF6 File Offset: 0x00246EF6
	public void LevelUpBuildingData(BuildingInfo data, int lastPopularity, int curPopularity)
	{
		this.SetBuildingData(data);
		this.InitPopularityData(lastPopularity, curPopularity, true);
	}

	// Token: 0x06008AC8 RID: 35528 RVA: 0x00248D08 File Offset: 0x00246F08
	public BuildingData GetBuildingDataById(int id)
	{
		return this.BuildingDataMap[id];
	}

	// Token: 0x06008AC9 RID: 35529 RVA: 0x00248D16 File Offset: 0x00246F16
	public void UnlockBuildingData(int buildingId, int lastPopularity, int curPopularity)
	{
		BuildingData buildingData = this.BuildingDataMap[buildingId];
		buildingData.IsUnlock = true;
		buildingData.Level = 1;
		this.InitPopularityData(lastPopularity, curPopularity, false);
		Singleton<EventSystem>.Instance.Emit(EEventName.TrackMoonHandbookUpdate);
	}

	// Token: 0x06008ACA RID: 35530 RVA: 0x00248D4A File Offset: 0x00246F4A
	public int GetBuildingDataSize()
	{
		return this.BuildingDataMap.Count;
	}

	// Token: 0x06008ACB RID: 35531 RVA: 0x00248D58 File Offset: 0x00246F58
	public List<BuildingData> GetAllBuildingData()
	{
		List<BuildingData> list = new List<BuildingData>();
		foreach (BuildingData item in this.BuildingDataMap.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06008ACC RID: 35532 RVA: 0x00248DB8 File Offset: 0x00246FB8
	public int GetBuiltBuildingCount()
	{
		int num = 0;
		using (Dictionary<int, BuildingData>.ValueCollection.Enumerator enumerator = this.BuildingDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsBuild)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06008ACD RID: 35533 RVA: 0x00248E18 File Offset: 0x00247018
	public void InitPopularityData(int lastPopularity, int curPopularity, bool isLevelUp)
	{
		Popularity popularityConfigByValue = ModelBase<MoonChasingBusinessModel>.Instance.GetPopularityConfigByValue(curPopularity);
		int playerRoleId = ModelBase<MoonChasingBusinessModel>.Instance.GetPlayerRoleId();
		bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
		string title = isLevelUp ? "Moonfiesta_Title4" : "Moonfiesta_Title3";
		string dialogName = flag ? (popularityConfigByValue.NpcDialog ?? "") : (popularityConfigByValue.NpcDialogGirl ?? "");
		MoonChasingPopularityUpData popularityUpData = new MoonChasingPopularityUpData(playerRoleId, lastPopularity, curPopularity, dialogName, title);
		this.SetPopularityUpData(popularityUpData);
	}

	// Token: 0x06008ACE RID: 35534 RVA: 0x00248E8E File Offset: 0x0024708E
	[NullableContext(2)]
	public void SetPopularityUpData(MoonChasingPopularityUpData popularityUpData)
	{
		this.PopularityUpData = popularityUpData;
	}

	// Token: 0x06008ACF RID: 35535 RVA: 0x00248E97 File Offset: 0x00247097
	[NullableContext(2)]
	public MoonChasingPopularityUpData GetPopularityUpData()
	{
		return this.PopularityUpData;
	}

	// Token: 0x06008AD0 RID: 35536 RVA: 0x00248EA0 File Offset: 0x002470A0
	public bool CheckAllBuildingRedDotState()
	{
		foreach (BuildingData buildingData in this.BuildingDataMap.Values)
		{
			if (this.CheckBuildingRedDotState(buildingData))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06008AD1 RID: 35537 RVA: 0x00248F04 File Offset: 0x00247104
	[NullableContext(2)]
	public BuildingData GetFirstUnLockBuildingData()
	{
		foreach (BuildingData buildingData in this.BuildingDataMap.Values)
		{
			if (buildingData.IsUnlock && buildingData.Level == 0 && buildingData.IsCanLevelUp)
			{
				return buildingData;
			}
		}
		return null;
	}

	// Token: 0x06008AD2 RID: 35538 RVA: 0x00248F74 File Offset: 0x00247174
	public int? GetFirstCanLevelUpBuildingId()
	{
		foreach (BuildingData buildingData in this.BuildingDataMap.Values)
		{
			if (buildingData.IsAvailableLevelUp && this.CheckBuildingRedDotState(buildingData))
			{
				return new int?(buildingData.Id);
			}
		}
		return null;
	}

	// Token: 0x06008AD3 RID: 35539 RVA: 0x00248FF0 File Offset: 0x002471F0
	public bool CheckBuildingRedDotState(BuildingData buildingData)
	{
		int coinValue = ModelBase<MoonChasingModel>.Instance.GetCoinValue();
		return buildingData.IsUnlock && !buildingData.IsMax && coinValue >= buildingData.GetConsumeCount();
	}

	// Token: 0x06008AD4 RID: 35540 RVA: 0x00249028 File Offset: 0x00247228
	public List<Building> GetBuildingConfigListBySort()
	{
		IReadOnlyList<Building> buildingAll = ConfigBase<BuildingConfig>.Instance.GetBuildingAll();
		List<Building> list = new List<Building>();
		if (buildingAll != null)
		{
			for (int i = 0; i < buildingAll.Count; i++)
			{
				list.Add(buildingAll[i]);
			}
		}
		list.Sort(delegate(Building aConfig, Building bConfig)
		{
			if (aConfig.Sort >= bConfig.Sort)
			{
				return 1;
			}
			return -1;
		});
		return list;
	}

	// Token: 0x06008AD5 RID: 35541 RVA: 0x00249090 File Offset: 0x00247290
	public bool CheckPlotInfoValid(PlotResultInfo plotResult)
	{
		IReadOnlyList<Building> buildingAll = ConfigBase<BuildingConfig>.Instance.GetBuildingAll();
		if (buildingAll != null)
		{
			for (int i = 0; i < buildingAll.Count; i++)
			{
				Building building = buildingAll[i];
				if ((building.FlowListName ?? "") == (plotResult.FlowListName ?? "") && building.FlowId == plotResult.FlowId.GetValueOrDefault(-1) && building.StateId == plotResult.StateId.GetValueOrDefault(-1))
				{
					return true;
				}
			}
		}
		string a = ConfigCommonParamById.GetStringConfig("MoonChasingBuildLastFlowName") ?? "";
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("MoonChasingBuildLastFlowIdF").GetValueOrDefault();
		int valueOrDefault2 = ConfigCommonParamById.GetIntConfig("MoonChasingBuildLastFlowIdC").GetValueOrDefault();
		return a == (plotResult.FlowListName ?? "") && valueOrDefault == plotResult.FlowId.GetValueOrDefault(-1) && valueOrDefault2 == plotResult.StateId.GetValueOrDefault(-1);
	}

	// Token: 0x06008AD6 RID: 35542 RVA: 0x0024918C File Offset: 0x0024738C
	public int GetBuildingIdByRoleId(int roleId)
	{
		IReadOnlyList<Building> buildingAll = ConfigBase<BuildingConfig>.Instance.GetBuildingAll();
		if (buildingAll != null)
		{
			for (int i = 0; i < buildingAll.Count; i++)
			{
				Building building = buildingAll[i];
				if (building.AssociateRole == roleId)
				{
					return building.Id;
				}
			}
		}
		return -1;
	}

	// Token: 0x040040F1 RID: 16625
	private readonly Dictionary<int, BuildingData> BuildingDataMap = new Dictionary<int, BuildingData>();

	// Token: 0x040040F2 RID: 16626
	[Nullable(2)]
	private MoonChasingPopularityUpData PopularityUpData;
}
