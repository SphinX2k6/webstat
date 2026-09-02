using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DAC RID: 19884
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMonsterData
	{
		// Token: 0x0603380D RID: 210957 RVA: 0x00CE1D1B File Offset: 0x00CDFF1B
		public static TrapDefenseMonsterData Create(TrapDefenseMonster config)
		{
			TrapDefenseMonsterData trapDefenseMonsterData = new TrapDefenseMonsterData(config.Id);
			trapDefenseMonsterData.Config = config;
			trapDefenseMonsterData.Init();
			return trapDefenseMonsterData;
		}

		// Token: 0x0603380E RID: 210958 RVA: 0x00CE1D36 File Offset: 0x00CDFF36
		private TrapDefenseMonsterData(int id)
		{
			this.Id = id;
		}

		// Token: 0x0603380F RID: 210959 RVA: 0x00CE1D5C File Offset: 0x00CDFF5C
		private void Init()
		{
			this.ConfigType = ConfigBase<TrapDefenseConfig>.Instance.GetMonsterTypeConfigById(this.Config.MonsterType).Value;
			this.IconPath = this.ConfigType.Icon;
			this.NameKey = this.Config.Name;
			this.SortId = this.Config.Sort;
		}

		// Token: 0x06033810 RID: 210960 RVA: 0x00CE1DC0 File Offset: 0x00CDFFC0
		public string GetShowActorLabelStr()
		{
			int id = this.Id;
			int simpleCombatSubtypeId = this.Config.SimpleCombatSubtypeId;
			int templateId = this.ConfigType.TemplateId;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 4);
			defaultInterpolatedStringHandler.AppendLiteral("Monster_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(id);
			defaultInterpolatedStringHandler.AppendLiteral("_tId-");
			defaultInterpolatedStringHandler.AppendFormatted<int>(templateId);
			defaultInterpolatedStringHandler.AppendLiteral("_subId-");
			defaultInterpolatedStringHandler.AppendFormatted<int>(simpleCombatSubtypeId);
			defaultInterpolatedStringHandler.AppendLiteral("_inInst-");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(this.InTheInstance);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06033811 RID: 210961 RVA: 0x00CE1E54 File Offset: 0x00CE0054
		public string GetQualityPathDesc()
		{
			TrapDefenseMonsterTypeData riskData = this.GetRiskData();
			string result;
			if ((result = ((riskData != null) ? riskData.Config.DescQualityPath : null)) == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("RiskType-QualityDesc-");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.ConfigType.RiskType);
				result = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return result;
		}

		// Token: 0x06033812 RID: 210962 RVA: 0x00CE1EAC File Offset: 0x00CE00AC
		public string GetQualityPathGrid()
		{
			TrapDefenseMonsterTypeData riskData = this.GetRiskData();
			string result;
			if ((result = ((riskData != null) ? riskData.Config.GridQualityPath : null)) == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("RiskType-QualityGrid-");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.ConfigType.RiskType);
				result = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return result;
		}

		// Token: 0x06033813 RID: 210963 RVA: 0x00CE1F04 File Offset: 0x00CE0104
		[NullableContext(2)]
		public TrapDefenseMonsterTypeData GetRiskData()
		{
			int riskType = this.ConfigType.RiskType;
			return ModelBase<TrapDefenseModel>.Instance.ViewModelMonster.MonsterTypeDataMap.GetValueOrDefault(riskType);
		}

		// Token: 0x06033814 RID: 210964 RVA: 0x00CE1F32 File Offset: 0x00CE0132
		public bool IsBoss()
		{
			return this.ConfigType.RiskType == 3;
		}

		// Token: 0x06033815 RID: 210965 RVA: 0x00CE1F44 File Offset: 0x00CE0144
		public string GetRiskTypeNameKey()
		{
			TrapDefenseMonsterTypeData riskData = this.GetRiskData();
			string result;
			if ((result = ((riskData != null) ? riskData.Config.Name : null)) == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
				defaultInterpolatedStringHandler.AppendLiteral("RiskType-Name-");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.ConfigType.RiskType);
				result = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return result;
		}

		// Token: 0x06033816 RID: 210966 RVA: 0x00CE1F9C File Offset: 0x00CE019C
		public string GetBodyTypeNameKey()
		{
			Dictionary<int, TrapDefenseMonsterBody> monsterBodyMap = ModelBase<TrapDefenseModel>.Instance.ViewModelMonster.GetMonsterBodyMap();
			int bodyType = this.ConfigType.BodyType;
			TrapDefenseMonsterBody trapDefenseMonsterBody;
			if (!monsterBodyMap.TryGetValue(bodyType, out trapDefenseMonsterBody))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
				defaultInterpolatedStringHandler.AppendLiteral("BodyType-Name-");
				defaultInterpolatedStringHandler.AppendFormatted<int>(bodyType);
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return trapDefenseMonsterBody.Name;
		}

		// Token: 0x06033817 RID: 210967 RVA: 0x00CE1FFC File Offset: 0x00CE01FC
		public List<ITrapDefenseAttrItemData> GetAttrDataShowList()
		{
			int simpleCombatSubtypeId = this.Config.SimpleCombatSubtypeId;
			int templateId = this.ConfigType.TemplateId;
			KSCBaseProperty? buffData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetBuffData(templateId, simpleCombatSubtypeId);
			if (buffData == null)
			{
				return new List<ITrapDefenseAttrItemData>();
			}
			List<ITrapDefenseAttrItemData> list = new List<ITrapDefenseAttrItemData>();
			foreach (int id in this.Config.AttrShowIter())
			{
				TrapDefenseAttributeShow? attrShow = ConfigBase<TrapDefenseConfig>.Instance.GetAttrShow(id);
				if (!StringUtils.IsEmpty(attrShow.Value.ToMonster))
				{
					PropertyInfo property = this.Config.GetType().GetProperty(attrShow.Value.ToMonster, BindingFlags.Instance | BindingFlags.Public);
					string text;
					if (!(property != null))
					{
						text = "UnFind-" + attrShow.Value.ToMonster;
					}
					else
					{
						object value = property.GetValue(this.Config);
						text = (((value != null) ? value.ToString() : null) ?? ("UnFind-" + attrShow.Value.ToMonster));
					}
					string value2 = text;
					list.Add(new TrapDefenseAttrItemData
					{
						NameKey = attrShow.Value.Name,
						IconPath = attrShow.Value.Icon,
						Value = value2
					});
					return list;
				}
				PropertyInfo property2 = buffData.GetType().GetProperty(attrShow.Value.Key, BindingFlags.Instance | BindingFlags.Public);
				string text2;
				if (!(property2 != null))
				{
					text2 = "UnFind-" + attrShow.Value.Key;
				}
				else
				{
					object value3 = property2.GetValue(buffData);
					text2 = (((value3 != null) ? value3.ToString() : null) ?? ("UnFind-" + attrShow.Value.Key));
				}
				string value4 = text2;
				list.Add(new TrapDefenseAttrItemData
				{
					NameKey = attrShow.Value.Name,
					IconPath = attrShow.Value.Icon,
					Value = value4
				});
			}
			return list;
		}

		// Token: 0x06033818 RID: 210968 RVA: 0x00CE2260 File Offset: 0x00CE0460
		public List<ITrapDefenseAttrItemData> GetTagDataShowList()
		{
			Dictionary<int, TrapDefenseMonsterTag> monsterTagMap = ModelBase<TrapDefenseModel>.Instance.ViewModelMonster.GetMonsterTagMap();
			List<ITrapDefenseAttrItemData> list = new List<ITrapDefenseAttrItemData>();
			for (int i = 0; i < this.Config.TagLength; i++)
			{
				TrapDefenseMonsterTag trapDefenseMonsterTag = monsterTagMap[this.Config.Tag(i)];
				TrapDefenseAttrItemData item = new TrapDefenseAttrItemData
				{
					IconPath = trapDefenseMonsterTag.Icon,
					NameKey = trapDefenseMonsterTag.Name,
					Value = this.Config.TagDesc(i)
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06033819 RID: 210969 RVA: 0x00CE22E8 File Offset: 0x00CE04E8
		public List<string> GetGridTagPathList()
		{
			List<ITrapDefenseAttrItemData> tagDataShowList = this.GetTagDataShowList();
			if (tagDataShowList.Count > 0)
			{
				List<string> list = new List<string>();
				foreach (ITrapDefenseAttrItemData trapDefenseAttrItemData in tagDataShowList)
				{
					list.Add(trapDefenseAttrItemData.IconPath);
				}
				return list;
			}
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string item = ((instance != null) ? instance.GetResourcePath(ETrapDefenseResKey.MonsterTagUnStateIcon.ToString()) : null) ?? ETrapDefenseResKey.MonsterTagUnStateIcon.ToString();
			return new List<string>
			{
				item
			};
		}

		// Token: 0x0603381A RID: 210970 RVA: 0x00CE2398 File Offset: 0x00CE0598
		public void SetIsInTheInstance(bool isIn)
		{
			this.InTheInstance = isIn;
		}

		// Token: 0x0401DD3B RID: 122171
		public int Id;

		// Token: 0x0401DD3C RID: 122172
		public string IconPath = "";

		// Token: 0x0401DD3D RID: 122173
		public int QualityId;

		// Token: 0x0401DD3E RID: 122174
		public string NameKey = "";

		// Token: 0x0401DD3F RID: 122175
		public TrapDefenseMonster Config;

		// Token: 0x0401DD40 RID: 122176
		public TrapDefenseMonsterType ConfigType;

		// Token: 0x0401DD41 RID: 122177
		public bool InTheInstance;

		// Token: 0x0401DD42 RID: 122178
		public int SortId;
	}
}
