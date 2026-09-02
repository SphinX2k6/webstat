using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C26 RID: 19494
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class VillageInfrConfig : ConfigBase<VillageInfrConfig>
	{
		// Token: 0x06032D55 RID: 208213 RVA: 0x00CBCBF4 File Offset: 0x00CBADF4
		protected override bool OnInit()
		{
			this.TreeRelativeAreas.Clear();
			this.ItemIdToTree.Clear();
			foreach (InfrV2TreeBuild infrV2TreeBuild in this.GetInfrTreeBuildAll())
			{
				this.TreeRelativeAreas.Add(infrV2TreeBuild.AreaId);
				Dictionary<int, int>.KeyCollection.Enumerator enumerator2 = infrV2TreeBuild.Requirement().Keys.GetEnumerator();
				enumerator2.MoveNext();
				this.ItemIdToTree[enumerator2.Current] = infrV2TreeBuild.Id;
			}
			return true;
		}

		// Token: 0x06032D56 RID: 208214 RVA: 0x00CBCC98 File Offset: 0x00CBAE98
		protected override bool OnClear()
		{
			this.TreeRelativeAreas.Clear();
			this.ItemIdToTree.Clear();
			return true;
		}

		// Token: 0x06032D57 RID: 208215 RVA: 0x00CBCCB1 File Offset: 0x00CBAEB1
		public InfrV2Reward? GetInfrActivityTaskConfig(int configId)
		{
			return ConfigInfrV2RewardById.GetConfig(configId, true);
		}

		// Token: 0x06032D58 RID: 208216 RVA: 0x00CBCCBA File Offset: 0x00CBAEBA
		public IReadOnlyList<InfrV2TreeBuild> GetInfrTreeBuildAll()
		{
			return ConfigInfrV2TreeBuildAll.GetConfigList(true) ?? new List<InfrV2TreeBuild>();
		}

		// Token: 0x06032D59 RID: 208217 RVA: 0x00CBCCCB File Offset: 0x00CBAECB
		public InfrV2TreeBuild? GetInfrTreeBuild(int configId)
		{
			return ConfigInfrV2TreeBuildById.GetConfig(configId, true);
		}

		// Token: 0x06032D5A RID: 208218 RVA: 0x00CBCCD4 File Offset: 0x00CBAED4
		public InfrV2Level? GetInfrLevel(int level)
		{
			return ConfigInfrV2LevelByLevel.GetConfig(level, true);
		}

		// Token: 0x06032D5B RID: 208219 RVA: 0x00CBCCDD File Offset: 0x00CBAEDD
		public IReadOnlyList<InfrV2Level> GetInfrLevelAll()
		{
			return ConfigInfrV2LevelAll.GetConfigList(true) ?? new List<InfrV2Level>();
		}

		// Token: 0x06032D5C RID: 208220 RVA: 0x00CBCCF0 File Offset: 0x00CBAEF0
		public int GetInfrMaxLevel()
		{
			int num = 0;
			foreach (InfrV2Level infrV2Level in this.GetInfrLevelAll())
			{
				if (infrV2Level.Level > num)
				{
					num = infrV2Level.Level;
				}
			}
			return num;
		}

		// Token: 0x06032D5D RID: 208221 RVA: 0x00CBCD4C File Offset: 0x00CBAF4C
		public IReadOnlyList<InfrV2ScoreReward> GetScoreReward()
		{
			return ConfigInfrV2ScoreRewardAll.GetConfigList(true) ?? new List<InfrV2ScoreReward>();
		}

		// Token: 0x06032D5E RID: 208222 RVA: 0x00CBCD5D File Offset: 0x00CBAF5D
		public InfrV2ScoreReward? GetScoreRewardById(int id)
		{
			return ConfigInfrV2ScoreRewardById.GetConfig(id, true);
		}

		// Token: 0x06032D5F RID: 208223 RVA: 0x00CBCD66 File Offset: 0x00CBAF66
		public InfrV2TreeBuild? GetTreeConfigByMarkId(int markId)
		{
			return ConfigInfrV2TreeBuildByMarkId.GetConfig(markId, true);
		}

		// Token: 0x06032D60 RID: 208224 RVA: 0x00CBCD70 File Offset: 0x00CBAF70
		public InfrV2TreeBuild? GetTreeConfigByAreaId(int areaId)
		{
			if (!this.TreeRelativeAreas.Contains(areaId))
			{
				return null;
			}
			return ConfigInfrV2TreeBuildByAreaId.GetConfig(areaId, true);
		}

		// Token: 0x06032D61 RID: 208225 RVA: 0x00CBCD9C File Offset: 0x00CBAF9C
		public IReadOnlyList<InfrV2PopupMsg> GetPopupMsgAll()
		{
			return ConfigInfrV2PopupMsgAll.GetConfigList(true) ?? new List<InfrV2PopupMsg>();
		}

		// Token: 0x06032D62 RID: 208226 RVA: 0x00CBCDB0 File Offset: 0x00CBAFB0
		public int? GetTreeIdByItemId(int itemId)
		{
			int value;
			if (this.ItemIdToTree.TryGetValue(itemId, out value))
			{
				return new int?(value);
			}
			return null;
		}

		// Token: 0x06032D63 RID: 208227 RVA: 0x00CBCDE0 File Offset: 0x00CBAFE0
		public int GetMainHelpId()
		{
			return ConfigCommonParamById.GetIntConfig("VillageInfrMainHelpId").GetValueOrDefault();
		}

		// Token: 0x0401D977 RID: 121207
		private readonly HashSet<int> TreeRelativeAreas = new HashSet<int>();

		// Token: 0x0401D978 RID: 121208
		private readonly Dictionary<int, int> ItemIdToTree = new Dictionary<int, int>();
	}
}
