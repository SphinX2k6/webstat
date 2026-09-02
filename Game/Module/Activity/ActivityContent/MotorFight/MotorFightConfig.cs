using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066CA RID: 26314
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class MotorFightConfig : ConfigBase<MotorFightConfig>
	{
		// Token: 0x06041B7D RID: 269181 RVA: 0x010DA54F File Offset: 0x010D874F
		public IReadOnlyList<MotorFightRole> GetMotorFightRoleList(int activityId)
		{
			return ConfigMotorFightRoleByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x06041B7E RID: 269182 RVA: 0x010DA558 File Offset: 0x010D8758
		public MotorFightQuality? GetMotorFightQuality(int id)
		{
			return ConfigMotorFightQualityById.GetConfig(id, true);
		}

		// Token: 0x06041B7F RID: 269183 RVA: 0x010DA561 File Offset: 0x010D8761
		public MotorFightItemType? GetMotorFightItemType(int id)
		{
			return ConfigMotorFightItemTypeById.GetConfig(id, true);
		}

		// Token: 0x06041B80 RID: 269184 RVA: 0x010DA56A File Offset: 0x010D876A
		public MotorFightActivity? GetMotorFightActivityConfig(int id)
		{
			return ConfigMotorFightActivityByActivityId.GetConfig(id, true);
		}

		// Token: 0x06041B81 RID: 269185 RVA: 0x010DA573 File Offset: 0x010D8773
		public MotorFightLevelType? GetMotorFightLevelType(int id)
		{
			return ConfigMotorFightLevelTypeById.GetConfig(id, true);
		}

		// Token: 0x06041B82 RID: 269186 RVA: 0x010DA57C File Offset: 0x010D877C
		public List<MotorFightAttrShow> GetMotorFightAttrShow()
		{
			List<MotorFightAttrShow> list = new List<MotorFightAttrShow>(ConfigMotorFightAttrShowAll.GetConfigList(true));
			list.Sort((MotorFightAttrShow a, MotorFightAttrShow b) => a.SortId - b.SortId);
			return list;
		}

		// Token: 0x06041B83 RID: 269187 RVA: 0x010DA5AE File Offset: 0x010D87AE
		public MotorFightAttrShow? GetMotorFightAttrShowById(int id)
		{
			return ConfigMotorFightAttrShowById.GetConfig(id, true);
		}

		// Token: 0x06041B84 RID: 269188 RVA: 0x010DA5B7 File Offset: 0x010D87B7
		public MotorFightRole? GetMotorFightRoleConfig(int id)
		{
			return ConfigMotorFightRoleById.GetConfig(id, true);
		}

		// Token: 0x06041B85 RID: 269189 RVA: 0x010DA5C0 File Offset: 0x010D87C0
		public MotorFightItem? GetMotorFightItemConfig(int id)
		{
			return ConfigMotorFightItemById.GetConfig(id, true);
		}

		// Token: 0x06041B86 RID: 269190 RVA: 0x010DA5C9 File Offset: 0x010D87C9
		public IReadOnlyList<MotorFightRank> GetMotorFightRobotRankList()
		{
			return ConfigMotorFightRankAll.GetConfigList(true);
		}
	}
}
