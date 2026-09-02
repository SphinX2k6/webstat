using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C4A RID: 23626
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class InfrastructureConfig : ConfigBase<InfrastructureConfig>
	{
		// Token: 0x0603BABF RID: 244415 RVA: 0x00F1DE45 File Offset: 0x00F1C045
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603BAC0 RID: 244416 RVA: 0x00F1DE48 File Offset: 0x00F1C048
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x0603BAC1 RID: 244417 RVA: 0x00F1DE4B File Offset: 0x00F1C04B
		public InfrRoadBuild? GetRoadConfigById(int roadId)
		{
			return ConfigInfrRoadBuildById.GetConfig(roadId, true);
		}

		// Token: 0x0603BAC2 RID: 244418 RVA: 0x00F1DE54 File Offset: 0x00F1C054
		public IReadOnlyList<InfrRoadBuild> GetRoadConfigList()
		{
			return ConfigInfrRoadBuildAll.GetConfigList(true) ?? Array.Empty<InfrRoadBuild>();
		}

		// Token: 0x0603BAC3 RID: 244419 RVA: 0x00F1DE65 File Offset: 0x00F1C065
		public InfrRoadBuild? GetRoadConfigByMarkId(int markId)
		{
			return ConfigInfrRoadBuildByMarkId.GetConfig(markId, true);
		}

		// Token: 0x0603BAC4 RID: 244420 RVA: 0x00F1DE6E File Offset: 0x00F1C06E
		public InfrLevel? GetLevelConfigById(int levelId)
		{
			return ConfigInfrLevelByLevel.GetConfig(levelId, true);
		}

		// Token: 0x0603BAC5 RID: 244421 RVA: 0x00F1DE78 File Offset: 0x00F1C078
		public int GetMaxLevel()
		{
			return this.GetAllLevelConfigs().ToList<InfrLevel>().Aggregate(delegate(InfrLevel prev, InfrLevel cur)
			{
				if (prev.Level <= cur.Level)
				{
					return cur;
				}
				return prev;
			}).Level;
		}

		// Token: 0x0603BAC6 RID: 244422 RVA: 0x00F1DEBC File Offset: 0x00F1C0BC
		public IReadOnlyList<InfrLevel> GetAllLevelConfigs()
		{
			return ConfigInfrLevelAll.GetConfigList(true) ?? Array.Empty<InfrLevel>();
		}

		// Token: 0x0603BAC7 RID: 244423 RVA: 0x00F1DED0 File Offset: 0x00F1C0D0
		public string GetItemQualityColor(int quality)
		{
			InfrItemQuality? infrItemQuality;
			return ((ConfigInfrItemQualityById.GetConfig(quality, true) != null) ? infrItemQuality.GetValueOrDefault().Color : null) ?? "#FFE65A";
		}

		// Token: 0x0603BAC8 RID: 244424 RVA: 0x00F1DF09 File Offset: 0x00F1C109
		public InfrActivityTask? GetInfrActivityTaskConfig(int configId)
		{
			return ConfigInfrActivityTaskByTaskId.GetConfig(configId, true);
		}

		// Token: 0x0603BAC9 RID: 244425 RVA: 0x00F1DF14 File Offset: 0x00F1C114
		public string GetArchiveItemQualityPath(int quality)
		{
			InfrArchiveItemQuality? infrArchiveItemQuality;
			return ((ConfigInfrArchiveItemQualityById.GetConfig(quality, true) != null) ? infrArchiveItemQuality.GetValueOrDefault().Path : null) ?? "";
		}

		// Token: 0x0603BACA RID: 244426 RVA: 0x00F1DF4D File Offset: 0x00F1C14D
		public InfrArchiveItem? GetArchiveItemConfig(int configId)
		{
			return ConfigInfrArchiveItemById.GetConfig(configId, true);
		}

		// Token: 0x0603BACB RID: 244427 RVA: 0x00F1DF56 File Offset: 0x00F1C156
		public InfrArchiveItem? GetArchiveItemById(int itemId)
		{
			return ConfigInfrArchiveItemById.GetConfig(itemId, true);
		}

		// Token: 0x0603BACC RID: 244428 RVA: 0x00F1DF5F File Offset: 0x00F1C15F
		public IReadOnlyList<InfrArchiveItem> GetArchiveItemIdConfigList()
		{
			return ConfigInfrArchiveItemAll.GetConfigList(true) ?? Array.Empty<InfrArchiveItem>();
		}

		// Token: 0x0603BACD RID: 244429 RVA: 0x00F1DF70 File Offset: 0x00F1C170
		public IReadOnlyList<InfrArchiveTask> GetInfrArchiveTaskList()
		{
			return ConfigInfrArchiveTaskAll.GetConfigList(true) ?? Array.Empty<InfrArchiveTask>();
		}

		// Token: 0x0603BACE RID: 244430 RVA: 0x00F1DF81 File Offset: 0x00F1C181
		public IReadOnlyList<InfrPhoneTask> GetInfrPhoneTaskList()
		{
			return ConfigInfrPhoneTaskAll.GetConfigList(true) ?? Array.Empty<InfrPhoneTask>();
		}

		// Token: 0x0603BACF RID: 244431 RVA: 0x00F1DF92 File Offset: 0x00F1C192
		public IReadOnlyList<InfrPasser> GetInfrPasserConfigList()
		{
			return ConfigInfrPasserAll.GetConfigList(true) ?? Array.Empty<InfrPasser>();
		}

		// Token: 0x0603BAD0 RID: 244432 RVA: 0x00F1DFA3 File Offset: 0x00F1C1A3
		public InfrPasser? GetInfrPasserConfigById(int passerId)
		{
			return ConfigInfrPasserById.GetConfig(passerId, true);
		}

		// Token: 0x0603BAD1 RID: 244433 RVA: 0x00F1DFAC File Offset: 0x00F1C1AC
		public InfrPhoneMessage? GetInfrPhoneMessageConfigById(int messageId)
		{
			return ConfigInfrPhoneMessageById.GetConfig(messageId, true);
		}

		// Token: 0x0603BAD2 RID: 244434 RVA: 0x00F1DFB5 File Offset: 0x00F1C1B5
		public IReadOnlyList<InfrPhoneMessage> GetInfrPhoneMessageConfigList()
		{
			return ConfigInfrPhoneMessageAll.GetConfigList(true) ?? Array.Empty<InfrPhoneMessage>();
		}

		// Token: 0x0603BAD3 RID: 244435 RVA: 0x00F1DFC8 File Offset: 0x00F1C1C8
		public int GetHelpIdActivity()
		{
			return ConfigCommonParamById.GetIntConfig("BuildRoad_ActivityHelpId").GetValueOrDefault();
		}

		// Token: 0x0603BAD4 RID: 244436 RVA: 0x00F1DFE8 File Offset: 0x00F1C1E8
		public int GetHelpIdRoadProcess()
		{
			return ConfigCommonParamById.GetIntConfig("BuildRoad_RoadProcessHelpId").GetValueOrDefault();
		}

		// Token: 0x0603BAD5 RID: 244437 RVA: 0x00F1E007 File Offset: 0x00F1C207
		public IReadOnlyList<InfrAutoPilotCircle> GetAutoPilotCircle()
		{
			return ConfigInfrAutoPilotCircleAll.GetConfigList(true) ?? Array.Empty<InfrAutoPilotCircle>();
		}
	}
}
