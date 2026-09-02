using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200666A RID: 26218
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingRiskConfigContext : IMowingRiskContextDisposable
	{
		// Token: 0x060417D6 RID: 268246 RVA: 0x010CFB04 File Offset: 0x010CDD04
		public MowingRiskConfigContext()
		{
			this.type2QualityData = new Dictionary<EMowingBuffType, IMowingRiskConfigQualityData>
			{
				{
					EMowingBuffType.BasicLow,
					new MowingRiskConfigQualityData
					{
						HexColor = EMowingBuffQualityHexColor.Blue,
						CfgQualityInfoId = InventoryDefine.EQuality.Blue,
						BackgroundResource = EMowingBuffIntroduceQualityBackground.Blue
					}
				},
				{
					EMowingBuffType.BasicHigh,
					new MowingRiskConfigQualityData
					{
						HexColor = EMowingBuffQualityHexColor.Purple,
						CfgQualityInfoId = InventoryDefine.EQuality.Purple,
						BackgroundResource = EMowingBuffIntroduceQualityBackground.Purple
					}
				},
				{
					EMowingBuffType.Super,
					new MowingRiskConfigQualityData
					{
						HexColor = EMowingBuffQualityHexColor.Gold,
						CfgQualityInfoId = InventoryDefine.EQuality.Orange,
						BackgroundResource = EMowingBuffIntroduceQualityBackground.Gold
					}
				}
			};
		}

		// Token: 0x060417D7 RID: 268247 RVA: 0x010CFB9D File Offset: 0x010CDD9D
		public void Dispose()
		{
		}

		// Token: 0x060417D8 RID: 268248 RVA: 0x010CFBA0 File Offset: 0x010CDDA0
		public EMowingBuffQualityHexColor GetBuffHexColorById(int id)
		{
			RiskHarvestBuffGroup? config = ConfigRiskHarvestBuffGroupById.GetConfig(id, true);
			if (config == null)
			{
				return EMowingBuffQualityHexColor.Default;
			}
			IMowingRiskConfigQualityData mowingRiskConfigQualityData;
			if (!this.type2QualityData.TryGetValue((EMowingBuffType)config.Value.BuffType, out mowingRiskConfigQualityData))
			{
				return EMowingBuffQualityHexColor.Default;
			}
			return mowingRiskConfigQualityData.HexColor;
		}

		// Token: 0x060417D9 RID: 268249 RVA: 0x010CFBF0 File Offset: 0x010CDDF0
		public string GetBuffNameTextIdById(int id)
		{
			RiskHarvestBuffGroup? config = ConfigRiskHarvestBuffGroupById.GetConfig(id, true);
			return ((config != null) ? config.GetValueOrDefault().BuffName : null) ?? string.Empty;
		}

		// Token: 0x060417DA RID: 268250 RVA: 0x010CFC2C File Offset: 0x010CDE2C
		public string GetBuffDescriptionTextIdById(int id)
		{
			RiskHarvestBuffGroup? config = ConfigRiskHarvestBuffGroupById.GetConfig(id, true);
			return ((config != null) ? config.GetValueOrDefault().BuffDesc : null) ?? string.Empty;
		}

		// Token: 0x060417DB RID: 268251 RVA: 0x010CFC68 File Offset: 0x010CDE68
		public string[] GetBuffDescriptionArgsById(int id)
		{
			RiskHarvestBuffGroup? config = ConfigRiskHarvestBuffGroupById.GetConfig(id, true);
			return ((config != null) ? config.GetValueOrDefault().BuffFactors() : null) ?? Array.Empty<string>();
		}

		// Token: 0x060417DC RID: 268252 RVA: 0x010CFCA4 File Offset: 0x010CDEA4
		public string GetBuffIconPathById(int id)
		{
			RiskHarvestBuffGroup? config = ConfigRiskHarvestBuffGroupById.GetConfig(id, true);
			return ((config != null) ? config.GetValueOrDefault().BuffIcon : null) ?? string.Empty;
		}

		// Token: 0x060417DD RID: 268253 RVA: 0x010CFCE0 File Offset: 0x010CDEE0
		public QualityInfo? GetBuffQualityInfoById(int id)
		{
			RiskHarvestBuffGroup? config = ConfigRiskHarvestBuffGroupById.GetConfig(id, true);
			if (config == null)
			{
				return null;
			}
			IMowingRiskConfigQualityData mowingRiskConfigQualityData;
			if (!this.type2QualityData.TryGetValue((EMowingBuffType)config.Value.BuffType, out mowingRiskConfigQualityData))
			{
				return null;
			}
			CommonConfig instance = ConfigBase<CommonConfig>.Instance;
			if (instance == null)
			{
				return null;
			}
			return instance.GetItemQualityById((int)mowingRiskConfigQualityData.CfgQualityInfoId);
		}

		// Token: 0x060417DE RID: 268254 RVA: 0x010CFD50 File Offset: 0x010CDF50
		public string GetBuffQualityPathById(int id)
		{
			QualityInfo? buffQualityInfoById = this.GetBuffQualityInfoById(id);
			return ((buffQualityInfoById != null) ? buffQualityInfoById.GetValueOrDefault().MediumItemGridQualitySpritePath : null) ?? string.Empty;
		}

		// Token: 0x060417DF RID: 268255 RVA: 0x010CFD8C File Offset: 0x010CDF8C
		public string GetNewBuffNameHexColorById(int id)
		{
			QualityInfo? buffQualityInfoById = this.GetBuffQualityInfoById(id);
			return ((buffQualityInfoById != null) ? buffQualityInfoById.GetValueOrDefault().TextColor : null) ?? EMowingBuffQualityHexColor.Default.ToString();
		}

		// Token: 0x060417E0 RID: 268256 RVA: 0x010CFDD0 File Offset: 0x010CDFD0
		public string GetNewBuffQualityTexPathById(int id)
		{
			QualityInfo? buffQualityInfoById = this.GetBuffQualityInfoById(id);
			return ((buffQualityInfoById != null) ? buffQualityInfoById.GetValueOrDefault().TextureAcquireBg : null) ?? string.Empty;
		}

		// Token: 0x060417E1 RID: 268257 RVA: 0x010CFE0C File Offset: 0x010CE00C
		public string GetNewBuffQualityFlowTexPathById(int id)
		{
			QualityInfo? buffQualityInfoById = this.GetBuffQualityInfoById(id);
			return ((buffQualityInfoById != null) ? buffQualityInfoById.GetValueOrDefault().TextureAcquireFlow : null) ?? string.Empty;
		}

		// Token: 0x060417E2 RID: 268258 RVA: 0x010CFE48 File Offset: 0x010CE048
		public bool IsNewBuffGoldenById(int id)
		{
			QualityInfo? buffQualityInfoById = this.GetBuffQualityInfoById(id);
			return buffQualityInfoById != null && buffQualityInfoById.GetValueOrDefault().Id == 5;
		}

		// Token: 0x060417E3 RID: 268259 RVA: 0x010CFE7C File Offset: 0x010CE07C
		public string GetBuffIntroduceBackgroundPath(int id)
		{
			RiskHarvestBuffGroup? config = ConfigRiskHarvestBuffGroupById.GetConfig(id, true);
			IMowingRiskConfigQualityData mowingRiskConfigQualityData;
			if (config == null || !this.type2QualityData.TryGetValue((EMowingBuffType)config.Value.BuffType, out mowingRiskConfigQualityData))
			{
				return string.Empty;
			}
			return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(mowingRiskConfigQualityData.BackgroundResource.ToString());
		}

		// Token: 0x060417E4 RID: 268260 RVA: 0x010CFEDC File Offset: 0x010CE0DC
		public int GetBuffMaxCountByArtifactId(int id)
		{
			RiskHarvestArtifact? config = ConfigRiskHarvestArtifactById.GetConfig(id, true);
			if (config == null)
			{
				return 0;
			}
			int[] array = config.Value.BasicBuffGroup();
			if (array.Length == 0)
			{
				return 0;
			}
			return array[array.Length - 1];
		}

		// Token: 0x060417E5 RID: 268261 RVA: 0x010CFF1C File Offset: 0x010CE11C
		public int GetProgressLevel(int id, int count)
		{
			int[] array = this.GetArtifactConfig(id).BasicBuffGroup();
			int num = array[array.Length - 1];
			if (count >= num)
			{
				return array.Length;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (count < array[i])
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x060417E6 RID: 268262 RVA: 0x010CFF60 File Offset: 0x010CE160
		public float GetProgressOverallPercentage(int id, int count)
		{
			int[] array = this.GetArtifactConfig(id).BasicBuffGroup();
			int num = array[array.Length - 1];
			if (count >= num)
			{
				return 1f;
			}
			int progressLevel = this.GetProgressLevel(id, count);
			int num2 = (progressLevel > 0) ? array[progressLevel - 1] : 0;
			int num3 = array[progressLevel];
			return (float)(count - num2) / (float)(num3 - num2);
		}

		// Token: 0x060417E7 RID: 268263 RVA: 0x010CFFB8 File Offset: 0x010CE1B8
		public float GetProgressPartialPercentage(int id, int count)
		{
			RiskHarvestArtifact artifactConfig = this.GetArtifactConfig(id);
			int[] array = artifactConfig.BasicBuffGroup();
			int num = array[array.Length - 1];
			if (count >= num)
			{
				return 1f;
			}
			int progressLevel = this.GetProgressLevel(id, count);
			float progressOverallPercentage = this.GetProgressOverallPercentage(id, count);
			int buffGroupLength = artifactConfig.BuffGroupLength;
			return (progressOverallPercentage + (float)progressLevel) / (float)buffGroupLength;
		}

		// Token: 0x060417E8 RID: 268264 RVA: 0x010D0004 File Offset: 0x010CE204
		public RiskHarvestArtifact GetArtifactConfig(int artifactId)
		{
			return ConfigRiskHarvestArtifactById.GetConfig(artifactId, true).Value;
		}

		// Token: 0x060417E9 RID: 268265 RVA: 0x010D0020 File Offset: 0x010CE220
		public int GetBuffThresholdByArtifactIdAndIndex(int artifactId, int index)
		{
			return this.GetArtifactConfig(artifactId).BasicBuffGroup()[index];
		}

		// Token: 0x060417EA RID: 268266 RVA: 0x010D0040 File Offset: 0x010CE240
		public int GetBuffIdByArtifactIdAndIndex(int artifactId, int index)
		{
			return this.GetArtifactConfig(artifactId).BuffGroup()[index];
		}

		// Token: 0x060417EB RID: 268267 RVA: 0x010D005E File Offset: 0x010CE25E
		public RiskHarvestBuffGroup? GetBuffConfigById(int id)
		{
			return ConfigRiskHarvestBuffGroupById.GetConfig(id, true);
		}

		// Token: 0x060417EC RID: 268268 RVA: 0x010D0068 File Offset: 0x010CE268
		public EMowingBuffType? GetBuffTypeById(int id)
		{
			RiskHarvestBuffGroup? config = ConfigRiskHarvestBuffGroupById.GetConfig(id, true);
			if (config == null)
			{
				return null;
			}
			return new EMowingBuffType?((EMowingBuffType)config.Value.BuffType);
		}

		// Token: 0x060417ED RID: 268269 RVA: 0x010D00A4 File Offset: 0x010CE2A4
		public int? GetIdByInstanceId(int instanceId)
		{
			RiskHarvestInst? config = ConfigRiskHarvestInstByInstanceID.GetConfig(instanceId, true);
			if (config == null)
			{
				return null;
			}
			return new int?(config.GetValueOrDefault().Id);
		}

		// Token: 0x060417EE RID: 268270 RVA: 0x010D00E0 File Offset: 0x010CE2E0
		public int GetInstanceRewardScoreById(int id)
		{
			if (ConfigRiskHarvestInstById.GetConfig(id, true) == null)
			{
				return 0;
			}
			RiskHarvestInst? riskHarvestInst;
			return riskHarvestInst.GetValueOrDefault().RewardScore;
		}

		// Token: 0x060417EF RID: 268271 RVA: 0x010D0110 File Offset: 0x010CE310
		public int GetScoreToUnlockById(int id)
		{
			RiskHarvestInst? config = ConfigRiskHarvestInstById.GetConfig(id, true);
			if (config == null)
			{
				return 0;
			}
			if (config.Value.UnlockInst != 0)
			{
				return config.Value.UnlockScore;
			}
			return 0;
		}

		// Token: 0x060417F0 RID: 268272 RVA: 0x010D0154 File Offset: 0x010CE354
		public bool IsSuperBuffByBuffId(int id)
		{
			return this.GetBuffTypeById(id).GetValueOrDefault() == EMowingBuffType.Super;
		}

		// Token: 0x060417F1 RID: 268273 RVA: 0x010D0174 File Offset: 0x010CE374
		public bool IsSuperBuffAvailable(int artifactId, int buffId, int basicBuffTotalCount)
		{
			if (!this.IsSuperBuffByBuffId(buffId))
			{
				return false;
			}
			RiskHarvestArtifact artifactConfig = this.GetArtifactConfig(artifactId);
			int[] array = artifactConfig.BasicBuffGroup();
			int[] array2 = artifactConfig.BuffGroup();
			for (int i = 0; i < array.Length; i++)
			{
				if (array2[i] == buffId && basicBuffTotalCount >= array[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17009F92 RID: 40850
		// (get) Token: 0x060417F2 RID: 268274 RVA: 0x010D01C4 File Offset: 0x010CE3C4
		// (set) Token: 0x060417F3 RID: 268275 RVA: 0x010D023C File Offset: 0x010CE43C
		public Dictionary<int, bool> IsInstanceNewCache
		{
			get
			{
				Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.MowingRiskIsInstanceNew, null);
				if (player == null)
				{
					Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
					IReadOnlyList<RiskHarvestInst> configList = ConfigRiskHarvestInstAll.GetConfigList(true);
					if (configList != null)
					{
						foreach (RiskHarvestInst riskHarvestInst in configList)
						{
							dictionary[riskHarvestInst.Id] = true;
						}
					}
					LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.MowingRiskIsInstanceNew, dictionary);
					return dictionary;
				}
				return player;
			}
			set
			{
				LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.MowingRiskIsInstanceNew, value);
			}
		}

		// Token: 0x060417F4 RID: 268276 RVA: 0x010D0247 File Offset: 0x010CE447
		public IReadOnlyList<RiskHarvestInst> GetRiskHarvestInstByActivityId(int activityId)
		{
			return ConfigRiskHarvestInstByActivityId.GetConfigList(activityId, true) ?? Array.Empty<RiskHarvestInst>();
		}

		// Token: 0x060417F5 RID: 268277 RVA: 0x010D0259 File Offset: 0x010CE459
		public IReadOnlyList<RiskHarvestScoreReward> GetRiskHarvestScoreRewardByActivityId(int activityId)
		{
			return ConfigRiskHarvestScoreRewardByActivityId.GetConfigList(activityId, true) ?? Array.Empty<RiskHarvestScoreReward>();
		}

		// Token: 0x060417F6 RID: 268278 RVA: 0x010D026B File Offset: 0x010CE46B
		public IReadOnlyList<RiskHarvestBuffGroup> GetBuffConfigListByActivityId(int activityId)
		{
			return ConfigRiskHarvestBuffGroupByActivityId.GetConfigList(activityId, true) ?? Array.Empty<RiskHarvestBuffGroup>();
		}

		// Token: 0x040249A3 RID: 149923
		private Dictionary<EMowingBuffType, IMowingRiskConfigQualityData> type2QualityData;
	}
}
