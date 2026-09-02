using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x020062FA RID: 25338
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class SpringManorConfig : ConfigBase<SpringManorConfig>
	{
		// Token: 0x0603FAF7 RID: 260855 RVA: 0x010537AA File Offset: 0x010519AA
		public SpringFestival? GetActivityConfigByActivityId(int activityId)
		{
			return ConfigSpringFestivalByActivityId.GetConfig(activityId, true);
		}

		// Token: 0x0603FAF8 RID: 260856 RVA: 0x010537B4 File Offset: 0x010519B4
		public int GetWorldTeleportId()
		{
			return ConfigCommonParamById.GetIntConfig("Spring26WorldTeleportId").Value;
		}

		// Token: 0x0603FAF9 RID: 260857 RVA: 0x010537D3 File Offset: 0x010519D3
		public SpringFestivalMainTask? GetMainTaskConfigById(int id)
		{
			return ConfigSpringFestivalMainTaskById.GetConfig(id, true);
		}

		// Token: 0x0603FAFA RID: 260858 RVA: 0x010537DC File Offset: 0x010519DC
		public SpringFestivalMainTask? GetMainTaskConfigByQuestId(int questId)
		{
			return ConfigSpringFestivalMainTaskByQuestId.GetConfig(questId, true);
		}

		// Token: 0x0603FAFB RID: 260859 RVA: 0x010537E5 File Offset: 0x010519E5
		public IReadOnlyList<SpringFestivalMainTask> GetAllMainTaskConfig()
		{
			return ConfigSpringFestivalMainTaskAll.GetConfigList(true);
		}

		// Token: 0x0603FAFC RID: 260860 RVA: 0x010537ED File Offset: 0x010519ED
		public SpringFestivalSubTask? GetSubTaskConfigByQuestId(int questId)
		{
			return ConfigSpringFestivalSubTaskByQuestId.GetConfig(questId, true);
		}

		// Token: 0x0603FAFD RID: 260861 RVA: 0x010537F6 File Offset: 0x010519F6
		public IReadOnlyList<SpringFestivalSubTask> GetAllSubTaskConfig()
		{
			return ConfigSpringFestivalSubTaskAll.GetConfigList(true);
		}

		// Token: 0x0603FAFE RID: 260862 RVA: 0x010537FE File Offset: 0x010519FE
		public AtmosphereLevel? GetLevelConfigById(int id)
		{
			return ConfigAtmosphereLevelById.GetConfig(id, true);
		}

		// Token: 0x0603FAFF RID: 260863 RVA: 0x01053808 File Offset: 0x01051A08
		[NullableContext(1)]
		public IReadOnlyList<AtmosphereLevel> GetLevelConfigByActivityId(int activityId)
		{
			List<AtmosphereLevel> list = new List<AtmosphereLevel>();
			IReadOnlyList<AtmosphereLevel> configList = ConfigAtmosphereLevelAll.GetConfigList(true);
			if (configList != null)
			{
				foreach (AtmosphereLevel item in configList)
				{
					if (item.ActivityId == activityId)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x0603FB00 RID: 260864 RVA: 0x0105386C File Offset: 0x01051A6C
		public SpringFestivalSkipEntry? GetSkipEntryConfigById(int id)
		{
			return ConfigSpringFestivalSkipEntryById.GetConfig(id, true);
		}

		// Token: 0x0603FB01 RID: 260865 RVA: 0x01053875 File Offset: 0x01051A75
		public SpringFestivalReward? GetRewardTaskConfigById(int configId)
		{
			return ConfigSpringFestivalRewardById.GetConfig(configId, true);
		}

		// Token: 0x0603FB02 RID: 260866 RVA: 0x0105387E File Offset: 0x01051A7E
		public IReadOnlyList<SpringFestivalReward> GetRewardTaskConfigByActivityId(int activityId)
		{
			return ConfigSpringFestivalRewardByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x0603FB03 RID: 260867 RVA: 0x01053887 File Offset: 0x01051A87
		public SpringFestivalRewardTab? GetRewardTabConfigById(int configId)
		{
			return ConfigSpringFestivalRewardTabById.GetConfig(configId, true);
		}

		// Token: 0x0603FB04 RID: 260868 RVA: 0x01053890 File Offset: 0x01051A90
		public IReadOnlyList<SpringFestivalRewardTab> GetRewardTabConfigByActivityId(int activityId)
		{
			return ConfigSpringFestivalRewardTabByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x0603FB05 RID: 260869 RVA: 0x01053899 File Offset: 0x01051A99
		public SpringFestivalScoreReward? GetScoreRewardConfigById(int configId)
		{
			return ConfigSpringFestivalScoreRewardById.GetConfig(configId, true);
		}

		// Token: 0x0603FB06 RID: 260870 RVA: 0x010538A2 File Offset: 0x01051AA2
		public IReadOnlyList<SpringFestivalScoreReward> GetScoreRewardConfigListByActivityId(int activityId)
		{
			return ConfigSpringFestivalScoreRewardByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x0603FB07 RID: 260871 RVA: 0x010538AC File Offset: 0x01051AAC
		public int GetMapIdByActivityId(int activityId)
		{
			SpringFestival? activityConfigByActivityId = this.GetActivityConfigByActivityId(activityId);
			if (activityConfigByActivityId == null)
			{
				return 0;
			}
			int instanceId = activityConfigByActivityId.Value.InstanceId;
			if (instanceId == 0)
			{
				return 0;
			}
			InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
			return ((instance != null) ? instance.GetInstanceMapConfigId(instanceId) : null).GetValueOrDefault();
		}

		// Token: 0x0603FB08 RID: 260872 RVA: 0x01053904 File Offset: 0x01051B04
		[NullableContext(1)]
		public IReadOnlyList<ExhibitPhantom> GetPhantomExtraConfigByBodySize(int size)
		{
			IReadOnlyList<ExhibitPhantom> configList = ConfigExhibitPhantomByBodyType.GetConfigList(size, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Phantom;
				ELogAuthor author = ELogAuthor.BB;
				string message = "PhantomExtraConfig Invalid size";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("size", size);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new List<ExhibitPhantom>();
			}
			return configList;
		}

		// Token: 0x0603FB09 RID: 260873 RVA: 0x0105394F File Offset: 0x01051B4F
		public SpringFestivalUnlock? GetFunctionConfigById(int id)
		{
			return ConfigSpringFestivalUnlockById.GetConfig(id, true);
		}

		// Token: 0x0603FB0A RID: 260874 RVA: 0x01053958 File Offset: 0x01051B58
		public Brochure? GetSpringManorBrochureByActivityAndType(int activityId, EBrochureType type)
		{
			return ConfigBrochureByActivityIdAndType.GetConfig(activityId, (int)type, true);
		}

		// Token: 0x0603FB0B RID: 260875 RVA: 0x01053962 File Offset: 0x01051B62
		public BookItem? GetSpringManorBookItemById(int id)
		{
			return ConfigBookItemById.GetConfig(id, true);
		}

		// Token: 0x0603FB0C RID: 260876 RVA: 0x0105396B File Offset: 0x01051B6B
		public Brochure? GetSpringManorBrochureById(int id)
		{
			return ConfigBrochureById.GetConfig(id, true);
		}

		// Token: 0x0603FB0D RID: 260877 RVA: 0x01053974 File Offset: 0x01051B74
		public List<TItem> GetRewardItem(int dropId)
		{
			List<TItem> list = new List<TItem>();
			if (dropId == 0)
			{
				return list;
			}
			DropPackage? dropPackage;
			Dictionary<int, int> dictionary = (ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId) != null) ? dropPackage.GetValueOrDefault().DropPreview() : null;
			if (dictionary == null)
			{
				return list;
			}
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0603FB0E RID: 260878 RVA: 0x01053A24 File Offset: 0x01051C24
		public int GetConditionGroupQuestId(int conditionGroupId)
		{
			Condition? config = ConfigConditionById.GetConfig(conditionGroupId, true);
			if (config != null)
			{
				string value;
				config.Value.LimitParams().TryGetValue("NewQuestId", out value);
				return (int)Convert.ToDouble(value);
			}
			return 0;
		}

		// Token: 0x0603FB0F RID: 260879 RVA: 0x01053A68 File Offset: 0x01051C68
		public int GetConditionGroupLevelPlayId(int conditionGroupId)
		{
			Condition? config = ConfigConditionById.GetConfig(conditionGroupId, true);
			if (config != null)
			{
				string value;
				config.Value.LimitParams().TryGetValue("LevelPlayId", out value);
				return (int)Convert.ToDouble(value);
			}
			return 0;
		}
	}
}
