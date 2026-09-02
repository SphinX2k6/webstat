using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006854 RID: 26708
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityEncircleConfig : ConfigBase<ActivityEncircleConfig>
	{
		// Token: 0x0604293D RID: 272701 RVA: 0x01117313 File Offset: 0x01115513
		public IReadOnlyList<EncircleMap> GetEncircleMap(int mapId)
		{
			return ConfigEncircleMapByMapId.GetConfigList(mapId, true);
		}

		// Token: 0x0604293E RID: 272702 RVA: 0x0111731C File Offset: 0x0111551C
		public IReadOnlyList<EncircleChallengeGroup> GetEncircleGroups(int activityId)
		{
			return ConfigEncircleChallengeGroupByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x0604293F RID: 272703 RVA: 0x01117325 File Offset: 0x01115525
		public EncircleChallengeGroup? GetEncircleGroup(int groupId)
		{
			return ConfigEncircleChallengeGroupById.GetConfig(groupId, true);
		}

		// Token: 0x06042940 RID: 272704 RVA: 0x01117330 File Offset: 0x01115530
		public int[] GetEncircleChallenges(int activityId, int levelId)
		{
			IReadOnlyList<EncircleChallengeGroup> encircleGroups = this.GetEncircleGroups(activityId);
			if (encircleGroups != null && encircleGroups.Count > 0)
			{
				return encircleGroups[levelId - 1].Challenges();
			}
			return null;
		}

		// Token: 0x06042941 RID: 272705 RVA: 0x01117364 File Offset: 0x01115564
		public EncircleChallenge? GetEncircleChallengeConfig(int challengeId)
		{
			return ConfigEncircleChallengeById.GetConfig(challengeId, true);
		}

		// Token: 0x06042942 RID: 272706 RVA: 0x01117370 File Offset: 0x01115570
		public EncircleHexType? GetMapItemType(int typeId)
		{
			if (ConfigEncircleMapItemById.GetConfig(typeId, true) == null)
			{
				return null;
			}
			EncircleMapItem? encircleMapItem;
			return new EncircleHexType?(encircleMapItem.GetValueOrDefault().Type);
		}

		// Token: 0x06042943 RID: 272707 RVA: 0x011173AC File Offset: 0x011155AC
		public string GetMapItemMemo(int typeId)
		{
			if (ConfigEncircleMapItemById.GetConfig(typeId, true) == null)
			{
				return null;
			}
			EncircleMapItem? encircleMapItem;
			return encircleMapItem.GetValueOrDefault().Memo;
		}

		// Token: 0x06042944 RID: 272708 RVA: 0x011173DC File Offset: 0x011155DC
		public string GetMapItemResource(int typeId)
		{
			if (ConfigEncircleMapItemById.GetConfig(typeId, true) == null)
			{
				return null;
			}
			EncircleMapItem? encircleMapItem;
			return encircleMapItem.GetValueOrDefault().ResourcePath;
		}
	}
}
