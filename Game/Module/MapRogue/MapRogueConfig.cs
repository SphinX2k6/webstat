using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x020058F8 RID: 22776
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class MapRogueConfig : ConfigBase<MapRogueConfig>
	{
		// Token: 0x06039CF0 RID: 236784 RVA: 0x00EA3D89 File Offset: 0x00EA1F89
		public RogueResGridMapType? GetGridMapTypeConfigById(int typeId)
		{
			return ConfigRogueResGridMapTypeById.GetConfig(typeId, true);
		}

		// Token: 0x06039CF1 RID: 236785 RVA: 0x00EA3D92 File Offset: 0x00EA1F92
		public RogueResGridEvent? GetGridEventConfigById(int id)
		{
			return ConfigRogueResGridEventById.GetConfig(id, true);
		}

		// Token: 0x06039CF2 RID: 236786 RVA: 0x00EA3D9B File Offset: 0x00EA1F9B
		public RogueResInstGrid? GetInsGridConfigByInstId(int instId)
		{
			return ConfigRogueResInstGridById.GetConfig(instId, true);
		}

		// Token: 0x06039CF3 RID: 236787 RVA: 0x00EA3DA4 File Offset: 0x00EA1FA4
		public RogueResEventCue? GetRogueResEventCueByType(string type)
		{
			return ConfigRogueResEventCueByType.GetConfig(type, true);
		}

		// Token: 0x06039CF4 RID: 236788 RVA: 0x00EA3DAD File Offset: 0x00EA1FAD
		public RogueResEffect? GetRogueEffectById(int id)
		{
			return ConfigRogueResEffectById.GetConfig(id, true);
		}

		// Token: 0x06039CF5 RID: 236789 RVA: 0x00EA3DB6 File Offset: 0x00EA1FB6
		public RogueResEffectTag? GetRogueEffectTagById(int id)
		{
			return ConfigRogueResEffectTagById.GetConfig(id, true);
		}

		// Token: 0x06039CF6 RID: 236790 RVA: 0x00EA3DBF File Offset: 0x00EA1FBF
		public RogueResEventStep? GetRogueEventStepById(int id)
		{
			return ConfigRogueResEventStepById.GetConfig(id, true);
		}

		// Token: 0x06039CF7 RID: 236791 RVA: 0x00EA3DC8 File Offset: 0x00EA1FC8
		public RogueResEventPlot? GetRogueEventPlotById(int plotId)
		{
			return ConfigRogueResEventPlotByPlotId.GetConfig(plotId, true);
		}

		// Token: 0x06039CF8 RID: 236792 RVA: 0x00EA3DD1 File Offset: 0x00EA1FD1
		public RogueResMoodRule? GetMoodRuleById(int id)
		{
			return ConfigRogueResMoodRuleById.GetConfig(id, true);
		}

		// Token: 0x06039CF9 RID: 236793 RVA: 0x00EA3DDA File Offset: 0x00EA1FDA
		public RogueResEventBg? GetEventBgById(int id)
		{
			return ConfigRogueResEventBgById.GetConfig(id, true);
		}

		// Token: 0x06039CFA RID: 236794 RVA: 0x00EA3DE3 File Offset: 0x00EA1FE3
		public RogueResEventBgm? GetEventBgmById(int id)
		{
			return ConfigRogueResEventBgmById.GetConfig(id, true);
		}

		// Token: 0x06039CFB RID: 236795 RVA: 0x00EA3DEC File Offset: 0x00EA1FEC
		public RogueResGridExplore? GetExploreByInstId(int instId)
		{
			return ConfigRogueResGridExploreByInstId.GetConfig(instId, true);
		}

		// Token: 0x06039CFC RID: 236796 RVA: 0x00EA3DF8 File Offset: 0x00EA1FF8
		public RogueResGlobalParam? GetGlobalParamConfig()
		{
			IReadOnlyList<RogueResGlobalParam> configList = ConfigRogueResGlobalParamAll.GetConfigList(true);
			if (configList != null && configList.Count > 0)
			{
				return new RogueResGlobalParam?(configList[0]);
			}
			return null;
		}
	}
}
