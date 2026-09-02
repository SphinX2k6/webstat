using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DA6 RID: 19878
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopItemData
	{
		// Token: 0x060337AE RID: 210862 RVA: 0x00CDFEEA File Offset: 0x00CDE0EA
		public static TrapDefenseBuildingDevelopItemData Create(int id, ETrapDefenseMachineType type)
		{
			TrapDefenseBuildingDevelopItemData trapDefenseBuildingDevelopItemData = new TrapDefenseBuildingDevelopItemData(id, type);
			trapDefenseBuildingDevelopItemData.UpdateConfig();
			return trapDefenseBuildingDevelopItemData;
		}

		// Token: 0x060337AF RID: 210863 RVA: 0x00CDFEFC File Offset: 0x00CDE0FC
		private TrapDefenseBuildingDevelopItemData(int id, ETrapDefenseMachineType type)
		{
			this.Id = id;
			this.Type = type;
		}

		// Token: 0x060337B0 RID: 210864 RVA: 0x00CDFF4C File Offset: 0x00CDE14C
		private void UpdateConfig()
		{
			if (this.IsBuilding)
			{
				this.BuildingConfig = ConfigBase<TrapDefenseConfig>.Instance.GetBuildingById(this.Id);
				this.BuildingTypeConfig = ConfigBase<TrapDefenseConfig>.Instance.GetBuildingTypeById(this.BuildingConfig.Value.BuildingType);
				return;
			}
			this.AuxiliaryConfig = ConfigBase<TrapDefenseConfig>.Instance.GetAuxiliaryById(this.Id);
			this.AuxiliaryTypeConfig = ConfigBase<TrapDefenseConfig>.Instance.GetAuxiliaryTypeById(this.AuxiliaryConfig.Value.AuxiliaryType);
		}

		// Token: 0x060337B1 RID: 210865 RVA: 0x00CDFFD4 File Offset: 0x00CDE1D4
		public string GetIconPath()
		{
			if (!this.IsBuilding)
			{
				return this.AuxiliaryTypeConfig.Value.Icon;
			}
			return this.BuildingTypeConfig.Value.Icon;
		}

		// Token: 0x060337B2 RID: 210866 RVA: 0x00CE0010 File Offset: 0x00CDE210
		public string GetName()
		{
			if (!this.IsBuilding)
			{
				return this.AuxiliaryTypeConfig.Value.Name;
			}
			return this.BuildingTypeConfig.Value.Name;
		}

		// Token: 0x060337B3 RID: 210867 RVA: 0x00CE004C File Offset: 0x00CDE24C
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public ValueTuple<string, string[]> GetDesc()
		{
			if (this.IsBuilding)
			{
				return new ValueTuple<string, string[]>(this.BuildingConfig.Value.Desc, this.BuildingConfig.Value.DescArgs());
			}
			return new ValueTuple<string, string[]>(this.AuxiliaryConfig.Value.Desc, this.AuxiliaryConfig.Value.DescArgs());
		}

		// Token: 0x060337B4 RID: 210868 RVA: 0x00CE00B8 File Offset: 0x00CDE2B8
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<string, string> GetVideo()
		{
			if (this.IsBuilding)
			{
				return new ValueTuple<string, string>(this.BuildingTypeConfig.Value.VideoName, this.BuildingTypeConfig.Value.VideoPath);
			}
			return new ValueTuple<string, string>(this.AuxiliaryTypeConfig.Value.VideoName, this.AuxiliaryTypeConfig.Value.VideoPath);
		}

		// Token: 0x060337B5 RID: 210869 RVA: 0x00CE0124 File Offset: 0x00CDE324
		public void SetIsUnLock(bool isUnlock)
		{
			this.IsUnlock = isUnlock;
		}

		// Token: 0x060337B6 RID: 210870 RVA: 0x00CE012D File Offset: 0x00CDE32D
		public int GetLevel()
		{
			return ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(this.Id).Level;
		}

		// Token: 0x060337B7 RID: 210871 RVA: 0x00CE0144 File Offset: 0x00CDE344
		public ETrapDefensePlacementType GetPlacementType()
		{
			if (!this.IsBuilding)
			{
				return ETrapDefensePlacementType.None;
			}
			return (ETrapDefensePlacementType)this.BuildingTypeConfig.Value.PlacementType;
		}

		// Token: 0x060337B8 RID: 210872 RVA: 0x00CE0170 File Offset: 0x00CDE370
		public int GetUpgradeCost()
		{
			if (!this.IsBuilding)
			{
				return this.AuxiliaryConfig.Value.UpgradeCost;
			}
			return this.BuildingConfig.Value.UpgradeCost;
		}

		// Token: 0x060337B9 RID: 210873 RVA: 0x00CE01AC File Offset: 0x00CDE3AC
		public int GetBuildingCost(bool isDynamic)
		{
			if (!this.IsBuilding)
			{
				return 0;
			}
			if (isDynamic && this.BuildingCostPriceDiscount != -1)
			{
				return this.BuildingCostPriceDiscount;
			}
			return this.BuildingConfig.Value.ConstructDefaultCost;
		}

		// Token: 0x060337BA RID: 210874 RVA: 0x00CE01E9 File Offset: 0x00CDE3E9
		public float GetCoolDown()
		{
			if (!this.IsBuilding)
			{
				return TowerDefensePlayerController.GetFollowerSkillCD(this.Id);
			}
			return 0f;
		}

		// Token: 0x060337BB RID: 210875 RVA: 0x00CE0204 File Offset: 0x00CDE404
		public float GetRemainCd()
		{
			if (this.IsBuilding)
			{
				return 0f;
			}
			if (this.AuxiliaryConfig.Value.CDSkill == 0)
			{
				return 0f;
			}
			float followerSkillRemainCD = TowerDefensePlayerController.GetFollowerSkillRemainCD(this.Id);
			if (followerSkillRemainCD != 0f && !float.IsNaN(followerSkillRemainCD))
			{
				return followerSkillRemainCD;
			}
			return 0f;
		}

		// Token: 0x060337BC RID: 210876 RVA: 0x00CE0260 File Offset: 0x00CDE460
		public bool GetIsMaxLevel(bool needCur)
		{
			int num = needCur ? this.CurMaxLevel : this.GetMaxLevel();
			int level = this.GetLevel();
			return num == level;
		}

		// Token: 0x060337BD RID: 210877 RVA: 0x00CE0288 File Offset: 0x00CDE488
		public void SetBuildingPrice(int origin, int discount)
		{
			this.BuildingCostPriceDiscount = discount;
		}

		// Token: 0x060337BE RID: 210878 RVA: 0x00CE0291 File Offset: 0x00CDE491
		public void SetCurMaxLevel(int max)
		{
			this.CurMaxLevel = max;
		}

		// Token: 0x060337BF RID: 210879 RVA: 0x00CE029A File Offset: 0x00CDE49A
		public int GetCurMaxLevel()
		{
			return this.CurMaxLevel;
		}

		// Token: 0x060337C0 RID: 210880 RVA: 0x00CE02A4 File Offset: 0x00CDE4A4
		public int GetMaxLevel()
		{
			if (this.MaxLevel >= 0)
			{
				return this.MaxLevel;
			}
			if (this.IsBuilding)
			{
				this.MaxLevel = this.BuildingTypeConfig.Value.MaxLevel;
				return this.MaxLevel;
			}
			this.MaxLevel = this.AuxiliaryTypeConfig.Value.MaxLevel;
			return this.MaxLevel;
		}

		// Token: 0x060337C1 RID: 210881 RVA: 0x00CE0308 File Offset: 0x00CDE508
		public bool GetIsUnlock()
		{
			return this.IsUnlock;
		}

		// Token: 0x060337C2 RID: 210882 RVA: 0x00CE0310 File Offset: 0x00CDE510
		public bool GetHasBranch()
		{
			if (this.IsBuilding)
			{
				TrapDefenseBuilding? buildingConfig = this.BuildingConfig;
				TrapDefenseBuildingType? buildingTypeConfig = this.BuildingTypeConfig;
				return buildingConfig.Value.Level == buildingTypeConfig.Value.MaxLevel && buildingTypeConfig.Value.BranchCount > 1;
			}
			TrapDefenseAuxiliary? auxiliaryConfig = this.AuxiliaryConfig;
			TrapDefenseAuxiliaryType? auxiliaryTypeConfig = this.AuxiliaryTypeConfig;
			return auxiliaryConfig.Value.Level == auxiliaryTypeConfig.Value.MaxLevel && auxiliaryTypeConfig.Value.BranchCount > 1;
		}

		// Token: 0x060337C3 RID: 210883 RVA: 0x00CE03B0 File Offset: 0x00CDE5B0
		public int GetBranchCount()
		{
			if (!this.IsBuilding)
			{
				return this.AuxiliaryTypeConfig.Value.BranchCount;
			}
			return this.BuildingTypeConfig.Value.BranchCount;
		}

		// Token: 0x060337C4 RID: 210884 RVA: 0x00CE03EC File Offset: 0x00CDE5EC
		public unsafe List<ITrapDefenseBuildingDevelopAttrInfo> GetAttrItem()
		{
			if (this.AttrItems.Count > 0)
			{
				return this.AttrItems;
			}
			if (this.IsBuilding)
			{
				string icon = TrapDefenseBuildingDevelopDataDefine.placementAttrIcon[this.GetPlacementType()];
				ITrapDefenseBuildingDevelopAttrInfo item = new ITrapDefenseBuildingDevelopAttrInfo
				{
					Name = "TowerDefense_BuildingAttr_Type",
					Icon = icon,
					Value = this.GetPlacementId(),
					MultiTxt = new bool?(true)
				};
				this.AttrItems.Add(item);
				ITrapDefenseBuildingDevelopAttrInfo trapDefenseBuildingDevelopAttrInfo = new ITrapDefenseBuildingDevelopAttrInfo();
				trapDefenseBuildingDevelopAttrInfo.Name = "TowerDefense_BuildingAttr_Cost";
				trapDefenseBuildingDevelopAttrInfo.Icon = "/Game/Aki/UI/UIResources/Common/Image/IconAttribute/T_RogueSkill_Coin_UI.T_RogueSkill_Coin_UI";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetBuildingCost(false));
				trapDefenseBuildingDevelopAttrInfo.Value = defaultInterpolatedStringHandler.ToStringAndClear();
				ITrapDefenseBuildingDevelopAttrInfo item2 = trapDefenseBuildingDevelopAttrInfo;
				this.AttrItems.Add(item2);
			}
			if (this.IsBuilding)
			{
				TrapDefenseBuilding? buildingConfig = this.BuildingConfig;
				TrapDefenseBuildingType? buildingTypeConfig = this.BuildingTypeConfig;
				KSCBaseProperty? buffData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetBuffData(buildingTypeConfig.Value.TemplateId, buildingConfig.Value.SimpleCombatSubtypeIds(0));
				if (buffData == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.TowerDefense;
					ELogAuthor author = ELogAuthor.WHJ;
					string message = "无法获得Buff模板";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("机关ID", this.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("模板ID", buildingTypeConfig.Value.TemplateId);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return this.AttrItems;
				}
				using (IEnumerator<int> enumerator = buildingTypeConfig.Value.AttrShowIter().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int num = enumerator.Current;
						TrapDefenseAttributeShow? attrShow = ConfigBase<TrapDefenseConfig>.Instance.GetAttrShow(num);
						if (attrShow == null)
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.TowerDefense;
							ELogAuthor author2 = ELogAuthor.WHJ;
							string message2 = "缺少属性字段配置";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("属性ID", num);
							instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
						else
						{
							PropertyInfo property = buffData.GetType().GetProperty(attrShow.Value.Key, BindingFlags.Instance | BindingFlags.Public);
							int num2 = 0;
							if (property != null)
							{
								num2 = (int)property.GetValue(buffData);
							}
							string value = string.Empty;
							if (attrShow.Value.Key == "SkillCoolDown")
							{
								float num3 = (float)num2 / 10000f;
								string text;
								if (num3 % 1f != 0f)
								{
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
									defaultInterpolatedStringHandler.AppendFormatted<float>(num3, "F1");
									text = defaultInterpolatedStringHandler.ToStringAndClear();
								}
								else
								{
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
									defaultInterpolatedStringHandler.AppendFormatted<float>(num3, "F0");
									text = defaultInterpolatedStringHandler.ToStringAndClear();
								}
								value = text;
							}
							else
							{
								string text2;
								if (!float.IsNaN((float)num2))
								{
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
									defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
									text2 = defaultInterpolatedStringHandler.ToStringAndClear();
								}
								else
								{
									text2 = attrShow.Value.Key + "Error";
								}
								value = text2;
							}
							ITrapDefenseBuildingDevelopAttrInfo item3 = new ITrapDefenseBuildingDevelopAttrInfo
							{
								Name = attrShow.Value.Name,
								Icon = attrShow.Value.Icon,
								Value = value
							};
							this.AttrItems.Add(item3);
						}
					}
					goto IL_57A;
				}
			}
			TrapDefenseAuxiliaryType? auxiliaryTypeConfig = this.AuxiliaryTypeConfig;
			Dictionary<EKSC_AttrType, float> followerAttrsByProxy = KscUtil.GetFollowerAttrsByProxy(this.Id);
			if (followerAttrsByProxy == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.TowerDefense;
				ELogAuthor author3 = ELogAuthor.WHJ;
				string message3 = "无法读取辅助机属性";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AttrID", this.Id);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return this.AttrItems;
			}
			foreach (int num4 in auxiliaryTypeConfig.Value.AttrShowIter())
			{
				TrapDefenseAttributeShow? attrShow2 = ConfigBase<TrapDefenseConfig>.Instance.GetAttrShow(num4);
				float num5;
				if (attrShow2 == null)
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.TowerDefense;
					ELogAuthor author4 = ELogAuthor.WHJ;
					string message4 = "数据库未找到属性键";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("AttrID", num4);
					instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				}
				else if (!followerAttrsByProxy.TryGetValue((EKSC_AttrType)num4, out num5))
				{
					Log instance5 = Singleton<Log>.Instance;
					ELogModule module5 = ELogModule.TowerDefense;
					ELogAuthor author5 = ELogAuthor.WHJ;
					string message5 = "属性值Map未找到键";
					ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("AttrID", num4);
					instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				}
				else
				{
					float num6 = followerAttrsByProxy[(EKSC_AttrType)num4];
					string value2 = string.Empty;
					if (attrShow2.Value.Key == "SkillCoolDown")
					{
						float num7 = num6 / 10000f;
						string text3;
						if (num7 % 1f != 0f)
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
							defaultInterpolatedStringHandler.AppendFormatted<float>(num7, "F1");
							text3 = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						else
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
							defaultInterpolatedStringHandler.AppendFormatted<float>(num7, "F0");
							text3 = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						value2 = text3;
					}
					else
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
						defaultInterpolatedStringHandler.AppendFormatted<float>(num6);
						value2 = defaultInterpolatedStringHandler.ToStringAndClear();
					}
					ITrapDefenseBuildingDevelopAttrInfo item4 = new ITrapDefenseBuildingDevelopAttrInfo
					{
						Name = attrShow2.Value.Name,
						Icon = attrShow2.Value.Icon,
						Value = value2
					};
					this.AttrItems.Add(item4);
				}
			}
			IL_57A:
			return this.AttrItems;
		}

		// Token: 0x060337C5 RID: 210885 RVA: 0x00CE09B0 File Offset: 0x00CDEBB0
		public int GetBranch()
		{
			if (!this.IsBuilding)
			{
				return this.AuxiliaryConfig.Value.Branch;
			}
			return this.BuildingConfig.Value.Branch;
		}

		// Token: 0x060337C6 RID: 210886 RVA: 0x00CE09EC File Offset: 0x00CDEBEC
		public string GetBranchDesc()
		{
			if (!this.IsBuilding)
			{
				return this.AuxiliaryConfig.Value.BranchDesc;
			}
			return this.BuildingConfig.Value.BranchDesc;
		}

		// Token: 0x060337C7 RID: 210887 RVA: 0x00CE0A28 File Offset: 0x00CDEC28
		public string[] GetBranchDescArgs()
		{
			if (!this.IsBuilding)
			{
				return this.AuxiliaryConfig.Value.BranchDescArgs();
			}
			return this.BuildingConfig.Value.BranchDescArgs();
		}

		// Token: 0x060337C8 RID: 210888 RVA: 0x00CE0A64 File Offset: 0x00CDEC64
		public bool CheckNeedRedDot()
		{
			return this.GetIsMaxLevel(false) && this.GetBranchCount() > 1 && ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(this.Id).Branch == 0;
		}

		// Token: 0x17008813 RID: 34835
		// (get) Token: 0x060337C9 RID: 210889 RVA: 0x00CE0A94 File Offset: 0x00CDEC94
		public bool IsBuilding
		{
			get
			{
				return this.Type == ETrapDefenseMachineType.Building;
			}
		}

		// Token: 0x060337CA RID: 210890 RVA: 0x00CE0A9F File Offset: 0x00CDEC9F
		public void UpdateId(int newId)
		{
			this.Id = newId;
			this.AttrItems.Clear();
			this.UpdateConfig();
		}

		// Token: 0x060337CB RID: 210891 RVA: 0x00CE0ABC File Offset: 0x00CDECBC
		public int GetDataType()
		{
			if (this.DataType != -1)
			{
				return this.DataType;
			}
			ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(this.Id);
			this.DataType = trapDefenseMachineIdInfo.DataType;
			return this.DataType;
		}

		// Token: 0x060337CC RID: 210892 RVA: 0x00CE0AFC File Offset: 0x00CDECFC
		public int GetSortId()
		{
			if (!this.IsBuilding)
			{
				return this.AuxiliaryTypeConfig.Value.SortId;
			}
			return this.BuildingTypeConfig.Value.SortId;
		}

		// Token: 0x060337CD RID: 210893 RVA: 0x00CE0B38 File Offset: 0x00CDED38
		public string GetPlacementId()
		{
			if (this.Type == ETrapDefenseMachineType.Auxiliary)
			{
				return "TowerDefense_Building_AuxiliaryType_Text";
			}
			ETrapDefensePlacementType placementType = this.GetPlacementType();
			if (placementType == ETrapDefensePlacementType.Floor)
			{
				return "TowerDefense_Building_FloorBuildingType_Text";
			}
			if (placementType == ETrapDefensePlacementType.Wall)
			{
				return "TowerDefense_Building_WallBuildingType_Text";
			}
			return "TowerDefense_Building_TopBuildingType_Text";
		}

		// Token: 0x060337CE RID: 210894 RVA: 0x00CE0B74 File Offset: 0x00CDED74
		public void SetLockInBattle(bool isLocked)
		{
			this.NeedLockInBattle = isLocked;
		}

		// Token: 0x060337CF RID: 210895 RVA: 0x00CE0B7D File Offset: 0x00CDED7D
		public bool GetLockInBattle()
		{
			return this.NeedLockInBattle;
		}

		// Token: 0x060337D0 RID: 210896 RVA: 0x00CE0B85 File Offset: 0x00CDED85
		public void SetSellPrice(int price)
		{
			this.SellPrice = price;
		}

		// Token: 0x060337D1 RID: 210897 RVA: 0x00CE0B8E File Offset: 0x00CDED8E
		public int GetSellPrice()
		{
			return this.SellPrice;
		}

		// Token: 0x0401DD18 RID: 122136
		public int Id;

		// Token: 0x0401DD19 RID: 122137
		public ETrapDefenseMachineType Type;

		// Token: 0x0401DD1A RID: 122138
		public bool IsInDungeon;

		// Token: 0x0401DD1B RID: 122139
		private int DataType = -1;

		// Token: 0x0401DD1C RID: 122140
		private int MaxLevel = -1;

		// Token: 0x0401DD1D RID: 122141
		private int CurMaxLevel = -1;

		// Token: 0x0401DD1E RID: 122142
		private int SellPrice;

		// Token: 0x0401DD1F RID: 122143
		private readonly List<ITrapDefenseBuildingDevelopAttrInfo> AttrItems = new List<ITrapDefenseBuildingDevelopAttrInfo>();

		// Token: 0x0401DD20 RID: 122144
		private bool IsUnlock = true;

		// Token: 0x0401DD21 RID: 122145
		private bool NeedLockInBattle;

		// Token: 0x0401DD22 RID: 122146
		private TrapDefenseAuxiliary? AuxiliaryConfig;

		// Token: 0x0401DD23 RID: 122147
		private TrapDefenseAuxiliaryType? AuxiliaryTypeConfig;

		// Token: 0x0401DD24 RID: 122148
		private TrapDefenseBuilding? BuildingConfig;

		// Token: 0x0401DD25 RID: 122149
		private TrapDefenseBuildingType? BuildingTypeConfig;

		// Token: 0x0401DD26 RID: 122150
		private int BuildingCostPriceDiscount = -1;
	}
}
