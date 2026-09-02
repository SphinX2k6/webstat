using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069CF RID: 27087
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class AnniversaryActivityConfig : ConfigBase<AnniversaryActivityConfig>
	{
		// Token: 0x06043270 RID: 275056 RVA: 0x011406E8 File Offset: 0x0113E8E8
		public IReadOnlyList<AnniversaryEntrance> GetAnniversaryEntranceAll()
		{
			return ConfigAnniversaryEntranceAll.GetConfigList(true);
		}

		// Token: 0x06043271 RID: 275057 RVA: 0x011406F0 File Offset: 0x0113E8F0
		public IReadOnlyList<PersonProgressCurve> GetPersonProgressCurveAll()
		{
			return ConfigPersonProgressCurveAll.GetConfigList(true);
		}

		// Token: 0x06043272 RID: 275058 RVA: 0x011406F8 File Offset: 0x0113E8F8
		public IReadOnlyList<WorldProgressCurve> GetWorldProgressCurveAll()
		{
			return ConfigWorldProgressCurveAll.GetConfigList(true);
		}

		// Token: 0x06043273 RID: 275059 RVA: 0x01140700 File Offset: 0x0113E900
		public AnniversaryEntrance? GetAnniversaryEntranceById(int id)
		{
			return ConfigAnniversaryEntranceById.GetConfig(id, true);
		}

		// Token: 0x06043274 RID: 275060 RVA: 0x01140709 File Offset: 0x0113E909
		public AnniversaryEntrance? GetAnniversaryEntranceByActivityId(int activityId)
		{
			return ConfigAnniversaryEntranceByActivityId.GetConfig(activityId, true);
		}

		// Token: 0x06043275 RID: 275061 RVA: 0x01140712 File Offset: 0x0113E912
		public PersonProgressCurve? GetPersonProgressCurveById(int id)
		{
			return ConfigPersonProgressCurveById.GetConfig(id, true);
		}

		// Token: 0x06043276 RID: 275062 RVA: 0x0114071B File Offset: 0x0113E91B
		public WorldProgressCurve? GetWorldProgressCurveById(int id)
		{
			return ConfigWorldProgressCurveById.GetConfig(id, true);
		}

		// Token: 0x06043277 RID: 275063 RVA: 0x01140724 File Offset: 0x0113E924
		public IReadOnlyList<WorldProgressCurve> GetWorldProgressCurveHadReward()
		{
			IReadOnlyList<WorldProgressCurve> configList = ConfigWorldProgressCurveAll.GetConfigList(true);
			if (configList != null)
			{
				List<WorldProgressCurve> list = new List<WorldProgressCurve>();
				foreach (WorldProgressCurve item in configList)
				{
					if (item.DropId > 0)
					{
						list.Add(item);
					}
				}
				return list;
			}
			return null;
		}
	}
}
