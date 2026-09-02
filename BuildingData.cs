using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020013AB RID: 5035
[NullableContext(1)]
[Nullable(0)]
public class BuildingData
{
	// Token: 0x17000BC9 RID: 3017
	// (get) Token: 0x06008AB7 RID: 35511 RVA: 0x002488AA File Offset: 0x00246AAA
	public bool IsBuild
	{
		get
		{
			return this.Level > 0;
		}
	}

	// Token: 0x06008AB8 RID: 35512 RVA: 0x002488B5 File Offset: 0x00246AB5
	public BuildingData(int id)
	{
		this.Id = id;
	}

	// Token: 0x06008AB9 RID: 35513 RVA: 0x002488C4 File Offset: 0x00246AC4
	public string GetBuildingName()
	{
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.Id).Name, null) ?? "";
	}

	// Token: 0x06008ABA RID: 35514 RVA: 0x002488F8 File Offset: 0x00246AF8
	public int GetConsumeCount()
	{
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.Id);
		if (this.Level == 0)
		{
			return buildingById.UnLockPrice;
		}
		return ConfigBase<BuildingConfig>.Instance.GetBuildingUpGradeCurveByGroupIdAndLevel(buildingById.UpGradeCurve, this.Level).UpGradePrice;
	}

	// Token: 0x06008ABB RID: 35515 RVA: 0x00248945 File Offset: 0x00246B45
	private IAdditionData CreateAdditionData(string textId, string valueText)
	{
		return new AdditionData(textId, valueText);
	}

	// Token: 0x06008ABC RID: 35516 RVA: 0x00248950 File Offset: 0x00246B50
	public List<IAdditionData> GetAdditionDataList(int level)
	{
		int level2 = Singleton<MathUtils>.Instance.Clamp(level, 1, this.LevelMax);
		List<IAdditionData> list = new List<IAdditionData>();
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.Id);
		BuildingUpGradeCurve buildingUpGradeCurveByGroupIdAndLevel = ConfigBase<BuildingConfig>.Instance.GetBuildingUpGradeCurveByGroupIdAndLevel(buildingById.UpGradeCurve, level2);
		if (buildingUpGradeCurveByGroupIdAndLevel.GoldAddition != 0)
		{
			string valueText = (buildingUpGradeCurveByGroupIdAndLevel.GoldAddition / 10).ToString() + "%";
			list.Add(this.CreateAdditionData("Moonfiesta_UP1", valueText));
		}
		if (buildingUpGradeCurveByGroupIdAndLevel.GoldAdditionFix != 0)
		{
			list.Add(this.CreateAdditionData("Moonfiesta_UP7", buildingUpGradeCurveByGroupIdAndLevel.GoldAdditionFix.ToString()));
		}
		if (buildingUpGradeCurveByGroupIdAndLevel.WishAdditionFix != 0)
		{
			list.Add(this.CreateAdditionData("Moonfiesta_UP2", buildingUpGradeCurveByGroupIdAndLevel.WishAdditionFix.ToString()));
		}
		if (buildingUpGradeCurveByGroupIdAndLevel.EnergyAddition != 0)
		{
			string valueText2 = (buildingUpGradeCurveByGroupIdAndLevel.EnergyAddition / 10).ToString() + "%";
			list.Add(this.CreateAdditionData("Moonfiesta_UP3", valueText2));
		}
		if (buildingUpGradeCurveByGroupIdAndLevel.IdeaRatioAddition != 0)
		{
			string valueText3 = (buildingUpGradeCurveByGroupIdAndLevel.IdeaRatioAddition / 10).ToString() + "%";
			list.Add(this.CreateAdditionData("Moonfiesta_UP4", valueText3));
		}
		if (buildingUpGradeCurveByGroupIdAndLevel.SuccessAddition != 0)
		{
			string valueText4 = (buildingUpGradeCurveByGroupIdAndLevel.SuccessAddition / 10).ToString() + "%";
			list.Add(this.CreateAdditionData("Moonfiesta_UP5", valueText4));
		}
		if (buildingUpGradeCurveByGroupIdAndLevel.HeatAddition != 0)
		{
			list.Add(this.CreateAdditionData("Moonfiesta_UP6", buildingUpGradeCurveByGroupIdAndLevel.HeatAddition.ToString()));
		}
		return list;
	}

	// Token: 0x06008ABD RID: 35517 RVA: 0x00248B08 File Offset: 0x00246D08
	public string GetLevelUpIncreaseDesc()
	{
		List<IAdditionData> additionDataList = this.GetAdditionDataList(this.Level);
		if (additionDataList.Count < 1)
		{
			return string.Empty;
		}
		IAdditionData additionData = additionDataList[0];
		return ConfigMultiTextLang.GetLocalTextNew(additionData.TextId, null) + " " + additionData.ValueText;
	}

	// Token: 0x06008ABE RID: 35518 RVA: 0x00248B58 File Offset: 0x00246D58
	public int GetAssociateRoleId()
	{
		return ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.Id).AssociateRole;
	}

	// Token: 0x17000BCA RID: 3018
	// (get) Token: 0x06008ABF RID: 35519 RVA: 0x00248B80 File Offset: 0x00246D80
	public bool IsCanLevelUp
	{
		get
		{
			int consumeCount = this.GetConsumeCount();
			int coinItemId = ConfigBase<BusinessConfig>.Instance.GetCoinItemId();
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(coinItemId, 0) >= consumeCount;
		}
	}

	// Token: 0x17000BCB RID: 3019
	// (get) Token: 0x06008AC0 RID: 35520 RVA: 0x00248BB4 File Offset: 0x00246DB4
	public int LevelMax
	{
		get
		{
			Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.Id);
			IReadOnlyList<BuildingUpGradeCurve> buildingUpGradeCurveByGroupId = ConfigBase<BuildingConfig>.Instance.GetBuildingUpGradeCurveByGroupId(buildingById.UpGradeCurve);
			return buildingUpGradeCurveByGroupId[buildingUpGradeCurveByGroupId.Count - 1].Level;
		}
	}

	// Token: 0x17000BCC RID: 3020
	// (get) Token: 0x06008AC1 RID: 35521 RVA: 0x00248BF8 File Offset: 0x00246DF8
	public bool IsMax
	{
		get
		{
			return this.Level >= this.LevelMax;
		}
	}

	// Token: 0x17000BCD RID: 3021
	// (get) Token: 0x06008AC2 RID: 35522 RVA: 0x00248C0B File Offset: 0x00246E0B
	public bool IsAvailableLevelUp
	{
		get
		{
			return this.IsBuild && !this.IsMax;
		}
	}

	// Token: 0x040040EE RID: 16622
	public int Level;

	// Token: 0x040040EF RID: 16623
	public bool IsUnlock;

	// Token: 0x040040F0 RID: 16624
	public readonly int Id;
}
