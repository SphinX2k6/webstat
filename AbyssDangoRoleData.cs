using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x020012D2 RID: 4818
[NullableContext(1)]
[Nullable(0)]
public class AbyssDangoRoleData
{
	// Token: 0x06008172 RID: 33138 RVA: 0x00223AD8 File Offset: 0x00221CD8
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06008173 RID: 33139 RVA: 0x00223AE0 File Offset: 0x00221CE0
	public int GetLevel()
	{
		return this.Level;
	}

	// Token: 0x06008174 RID: 33140 RVA: 0x00223AE8 File Offset: 0x00221CE8
	public int[] GetEquipItems()
	{
		return this.EquipItems;
	}

	// Token: 0x06008175 RID: 33141 RVA: 0x00223AF0 File Offset: 0x00221CF0
	public int[] GetEquipItemConfigIdList()
	{
		List<int> list = new List<int>();
		foreach (int incId in this.EquipItems)
		{
			global::AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(incId);
			if (pluginItemInfoById != null)
			{
				list.Add(pluginItemInfoById.GetItemId());
			}
			else
			{
				list.Add(0);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06008176 RID: 33142 RVA: 0x00223B49 File Offset: 0x00221D49
	public bool GetIfLock()
	{
		return this.Lock;
	}

	// Token: 0x06008177 RID: 33143 RVA: 0x00223B54 File Offset: 0x00221D54
	public string GetTexture()
	{
		return this.GetConfig().Value.Icon;
	}

	// Token: 0x06008178 RID: 33144 RVA: 0x00223B78 File Offset: 0x00221D78
	public string GetFormationIcon()
	{
		return this.GetConfig().Value.FormationIcon;
	}

	// Token: 0x06008179 RID: 33145 RVA: 0x00223B9C File Offset: 0x00221D9C
	public int GetMeshId()
	{
		int phantomId = this.GetPhantomId();
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(phantomId).PhantomItem.Value.MeshId;
	}

	// Token: 0x0600817A RID: 33146 RVA: 0x00223BD0 File Offset: 0x00221DD0
	public int GetPhantomId()
	{
		return this.GetConfig().Value.PhantomItemId;
	}

	// Token: 0x0600817B RID: 33147 RVA: 0x00223BF3 File Offset: 0x00221DF3
	public void Init(AbyssLittleRole data)
	{
		this.Id = data.Id;
		this.Level = 1;
	}

	// Token: 0x0600817C RID: 33148 RVA: 0x00223C0C File Offset: 0x00221E0C
	public void Phrase(AbyssRoleInfo data, int[] itemIdList)
	{
		this.Id = data.Id;
		this.Level = data.Level;
		this.EquipItems = data.EquipItems.ToArray<int>();
		this.Lock = false;
		this.PhraseSlotData(data.EquipItems.ToArray<int>(), itemIdList);
	}

	// Token: 0x0600817D RID: 33149 RVA: 0x00223C5C File Offset: 0x00221E5C
	public void PhraseSlotData(int[] incIdList, int[] itemIdList)
	{
		if (incIdList.Length < 9)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.WDX;
			string message = "团子插槽信息不足";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dangoId", this.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		for (int i = 0; i < 9; i++)
		{
			int uniqueId = incIdList[i];
			int itemId = itemIdList[i];
			AbyssDangoRoleSlotData abyssDangoRoleSlotData = new AbyssDangoRoleSlotData();
			abyssDangoRoleSlotData.SetDangoRoleId(this.Id);
			abyssDangoRoleSlotData.Refresh(i, uniqueId, itemId);
			this.PluginSlotDataMap[i] = abyssDangoRoleSlotData;
		}
	}

	// Token: 0x0600817E RID: 33150 RVA: 0x00223CE8 File Offset: 0x00221EE8
	public int GetQuality()
	{
		return this.GetConfig().Value.Quality;
	}

	// Token: 0x0600817F RID: 33151 RVA: 0x00223D0C File Offset: 0x00221F0C
	public string GetQualitySpritePath()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(this.GetQuality()).Value.Bg;
	}

	// Token: 0x06008180 RID: 33152 RVA: 0x00223D3C File Offset: 0x00221F3C
	public Dictionary<int, int> GetEquipPluginMap()
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < 9; i++)
		{
			dictionary[i] = 0;
		}
		foreach (KeyValuePair<int, AbyssDangoRoleSlotData> keyValuePair in this.PluginSlotDataMap)
		{
			dictionary[keyValuePair.Value.GetSlotIndex()] = keyValuePair.Value.GetEquipId();
		}
		return dictionary;
	}

	// Token: 0x06008181 RID: 33153 RVA: 0x00223DC4 File Offset: 0x00221FC4
	[NullableContext(2)]
	public AbyssDangoRoleSlotData GetPluginSlotData(int slot)
	{
		AbyssDangoRoleSlotData result;
		if (this.PluginSlotDataMap.TryGetValue(slot, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06008182 RID: 33154 RVA: 0x00223DE4 File Offset: 0x00221FE4
	public int GetCurrentPluginSlotNum()
	{
		return this.GetLevelConfig().Value.PluginNum;
	}

	// Token: 0x06008183 RID: 33155 RVA: 0x00223E08 File Offset: 0x00222008
	public string GetName()
	{
		return this.GetConfig().Value.Name;
	}

	// Token: 0x06008184 RID: 33156 RVA: 0x00223E2C File Offset: 0x0022202C
	public AbyssCastDesc GetCastTypeDesc()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoCastDescById(this.GetConfig().Value.CastType).Value;
	}

	// Token: 0x06008185 RID: 33157 RVA: 0x00223E64 File Offset: 0x00222064
	public string GetSkillCastTypeName()
	{
		return this.GetCastTypeDesc().Name;
	}

	// Token: 0x06008186 RID: 33158 RVA: 0x00223E80 File Offset: 0x00222080
	public string GetSkillCastTypeIconPath()
	{
		return this.GetCastTypeDesc().Icon;
	}

	// Token: 0x06008187 RID: 33159 RVA: 0x00223E9B File Offset: 0x0022209B
	public AbyssLittleRole? GetConfig()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoRoleById(this.Id);
	}

	// Token: 0x06008188 RID: 33160 RVA: 0x00223EB0 File Offset: 0x002220B0
	private int GetLevelGroupId()
	{
		return this.GetConfig().Value.LevelGroupId;
	}

	// Token: 0x06008189 RID: 33161 RVA: 0x00223ED3 File Offset: 0x002220D3
	[NullableContext(2)]
	public IReadOnlyList<AbyssRoleLevel> GetLevelGroupConfigs()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoLevelConfigByGroupId(this.GetLevelGroupId());
	}

	// Token: 0x0600818A RID: 33162 RVA: 0x00223EE8 File Offset: 0x002220E8
	public int GetSkillId()
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(this.GetConfig().Value.PhantomItemId).GetPhantomSkillId().Value;
	}

	// Token: 0x0600818B RID: 33163 RVA: 0x00223F22 File Offset: 0x00222122
	public PhantomSkill? GetSkillConfig()
	{
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(this.GetSkillId());
	}

	// Token: 0x0600818C RID: 33164 RVA: 0x00223F34 File Offset: 0x00222134
	public string GetSkillDesc()
	{
		PhantomSkill? phantomSkill;
		return ((this.GetSkillConfig() != null) ? phantomSkill.GetValueOrDefault().DescriptionEx : null) ?? string.Empty;
	}

	// Token: 0x0600818D RID: 33165 RVA: 0x00223F6C File Offset: 0x0022216C
	public string[] GetSkillDescAddition()
	{
		int skillId = this.GetSkillId();
		int qualityId = ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(this.GetConfig().Value.PhantomItemId).PhantomItem.Value.QualityId;
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExBySkillIdAndQuality(skillId, qualityId);
	}

	// Token: 0x0600818E RID: 33166 RVA: 0x00223FC4 File Offset: 0x002221C4
	public string[] GetEffectPassiveSkillDescList()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<int, AbyssDangoRoleSlotData> keyValuePair in this.PluginSlotDataMap)
		{
			string passiveSkillDesc = keyValuePair.Value.GetPassiveSkillDesc();
			if (passiveSkillDesc != "")
			{
				list.Add(passiveSkillDesc);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600818F RID: 33167 RVA: 0x00224040 File Offset: 0x00222240
	public AbyssRoleLevel? GetLevelConfig()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoLevelConfigByLevelAndGroupId(this.Level, this.GetLevelGroupId());
	}

	// Token: 0x06008190 RID: 33168 RVA: 0x00224058 File Offset: 0x00222258
	public ICostData[] GetCurrentLevelUpConsume()
	{
		AbyssRoleLevel? levelConfig = this.GetLevelConfig();
		if (levelConfig == null)
		{
			return Array.Empty<ICostData>();
		}
		Dictionary<int, int> dictionary = levelConfig.Value.Consume();
		List<ICostData> list = new List<ICostData>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0);
			CostData item = new CostData
			{
				ItemId = keyValuePair.Key,
				Cost = keyValuePair.Value,
				Count = itemCountByConfigId
			};
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x06008191 RID: 33169 RVA: 0x00224118 File Offset: 0x00222318
	public bool GetIfLevelUpEnough()
	{
		foreach (ICostData costData in this.GetCurrentLevelUpConsume())
		{
			if (costData.Cost > costData.Count)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06008192 RID: 33170 RVA: 0x0022414F File Offset: 0x0022234F
	public int GetMaxLevel()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoLevelConfigByGroupId(this.GetLevelGroupId()).Count;
	}

	// Token: 0x06008193 RID: 33171 RVA: 0x00224168 File Offset: 0x00222368
	public bool GetIfMaxLevel()
	{
		IReadOnlyList<AbyssRoleLevel> dangoLevelConfigByGroupId = ConfigBase<DangoAbyssConfig>.Instance.GetDangoLevelConfigByGroupId(this.GetLevelGroupId());
		return this.Level >= dangoLevelConfigByGroupId.Count;
	}

	// Token: 0x06008194 RID: 33172 RVA: 0x00224198 File Offset: 0x00222398
	public bool GetIfCanLevelUp()
	{
		bool ifLock = this.GetIfLock();
		bool ifMaxLevel = this.GetIfMaxLevel();
		return !ifLock && !ifMaxLevel;
	}

	// Token: 0x06008195 RID: 33173 RVA: 0x002241BC File Offset: 0x002223BC
	public AttrListScrollData[] GetLevelUpPreviewData(int targetLevel)
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		foreach (ConfigPropValue configPropValue in ConfigBase<DangoAbyssConfig>.Instance.GetDangoLevelConfigByLevelAndGroupId(targetLevel - 1, this.GetLevelGroupId()).Value.Prop())
		{
			bool flag = false;
			foreach (AttrListScrollData attrListScrollData in list)
			{
				if (attrListScrollData.Id == configPropValue.Id && attrListScrollData.IsRatio == configPropValue.IsRatio)
				{
					attrListScrollData.BaseValue += (double)configPropValue.Value;
					flag = true;
				}
			}
			if (!flag)
			{
				list.Add(new AttrListScrollData(configPropValue.Id, (double)configPropValue.Value, 0.0, 0, configPropValue.IsRatio, CommonComponentDefine.EAttributeType.NormalType));
			}
		}
		if (targetLevel <= this.GetMaxLevel())
		{
			foreach (ConfigPropValue configPropValue2 in ConfigBase<DangoAbyssConfig>.Instance.GetDangoLevelConfigByLevelAndGroupId(targetLevel, this.GetLevelGroupId()).Value.Prop())
			{
				bool flag2 = false;
				foreach (AttrListScrollData attrListScrollData2 in list)
				{
					if (attrListScrollData2.Id == configPropValue2.Id && attrListScrollData2.IsRatio == configPropValue2.IsRatio)
					{
						attrListScrollData2.AddValue += (double)configPropValue2.Value;
						flag2 = true;
					}
				}
				if (!flag2)
				{
					list.Add(new AttrListScrollData(configPropValue2.Id, 0.0, (double)configPropValue2.Value, 0, configPropValue2.IsRatio, CommonComponentDefine.EAttributeType.NormalType));
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06008196 RID: 33174 RVA: 0x002243B0 File Offset: 0x002225B0
	public int GetLevelUpPluginAddData(int newLevel)
	{
		AbyssRoleLevel? dangoLevelConfigByLevelAndGroupId = ConfigBase<DangoAbyssConfig>.Instance.GetDangoLevelConfigByLevelAndGroupId(newLevel, this.GetLevelGroupId());
		AbyssRoleLevel? dangoLevelConfigByLevelAndGroupId2 = ConfigBase<DangoAbyssConfig>.Instance.GetDangoLevelConfigByLevelAndGroupId(newLevel - 1, this.GetLevelGroupId());
		if (dangoLevelConfigByLevelAndGroupId == null || dangoLevelConfigByLevelAndGroupId2 == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.WDX;
			string message = "获取团子升级信息错误，检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("level", newLevel);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		return dangoLevelConfigByLevelAndGroupId.Value.PluginNum - dangoLevelConfigByLevelAndGroupId2.Value.PluginNum;
	}

	// Token: 0x06008197 RID: 33175 RVA: 0x00224448 File Offset: 0x00222648
	private string GetPropValueString(int indexId, double value, bool isRatio)
	{
		double propRatioValue = TipsDataTool.GetPropRatioValue(value, isRatio);
		return ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(indexId, propRatioValue, isRatio);
	}

	// Token: 0x06008198 RID: 33176 RVA: 0x0022446C File Offset: 0x0022266C
	public IAttributeInfo[] GetLevelUpViewAttributeInfo(int newLevel, bool? isMax = null)
	{
		AttrListScrollData[] levelUpPreviewData = this.GetLevelUpPreviewData(newLevel);
		List<IAttributeInfo> list = new List<IAttributeInfo>();
		foreach (AttrListScrollData attrListScrollData in levelUpPreviewData)
		{
			PropertyIndex value = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attrListScrollData.Id).Value;
			AttributeInfo attributeInfo = new AttributeInfo
			{
				Name = value.Name,
				IconPath = value.Icon,
				ShowArrow = !isMax,
				PreText = this.GetPropValueString(attrListScrollData.Id, attrListScrollData.BaseValue, attrListScrollData.IsRatio)
			};
			if (isMax == null || !isMax.Value)
			{
				attributeInfo.CurText = this.GetPropValueString(attrListScrollData.Id, attrListScrollData.AddValue, attrListScrollData.IsRatio);
			}
			list.Add(attributeInfo);
		}
		int levelUpPluginAddData = this.GetLevelUpPluginAddData(newLevel);
		if (levelUpPluginAddData <= 0 || (isMax != null && isMax.Value))
		{
			return list.ToArray();
		}
		AttributeInfo item = new AttributeInfo
		{
			Name = "Ayess_Chajiancao_Text",
			IconPath = null,
			ShowArrow = new bool?(false),
			CurText = StringUtils.Format("+{0}", new string[]
			{
				levelUpPluginAddData.ToString()
			})
		};
		list.Add(item);
		return list.ToArray();
	}

	// Token: 0x06008199 RID: 33177 RVA: 0x002245EC File Offset: 0x002227EC
	public ILevelUpSuccessAttributeData GetLevelUpViewData(int newLevel)
	{
		LevelInfo levelInfo = new LevelInfo
		{
			PreUpgradeLv = newLevel - 1,
			UpgradeLv = newLevel,
			FormatStringId = "Text_LevelShow_Text",
			IsMaxLevel = new bool?(newLevel >= this.GetMaxLevel())
		};
		IAttributeInfo[] levelUpViewAttributeInfo = this.GetLevelUpViewAttributeInfo(newLevel, null);
		return new LevelUpSuccessAttributeData
		{
			LevelInfo = levelInfo,
			AttributeInfo = levelUpViewAttributeInfo.ToList<IAttributeInfo>()
		};
	}

	// Token: 0x04003DC6 RID: 15814
	private int Id;

	// Token: 0x04003DC7 RID: 15815
	private int Level;

	// Token: 0x04003DC8 RID: 15816
	private int[] EquipItems = Array.Empty<int>();

	// Token: 0x04003DC9 RID: 15817
	private bool Lock = true;

	// Token: 0x04003DCA RID: 15818
	private readonly Dictionary<int, AbyssDangoRoleSlotData> PluginSlotDataMap = new Dictionary<int, AbyssDangoRoleSlotData>();
}
