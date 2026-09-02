using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x02005730 RID: 22320
	[NullableContext(1)]
	[Nullable(0)]
	public class DarkCoastDeliveryLevelUpViewData
	{
		// Token: 0x06038CE8 RID: 232680 RVA: 0x00E63EB2 File Offset: 0x00E620B2
		public DarkCoastDeliveryLevelUpViewData(int preLevel, int curLevel)
		{
			this.PreLevel = preLevel;
			this.CurLevel = curLevel;
		}

		// Token: 0x06038CE9 RID: 232681 RVA: 0x00E63EC8 File Offset: 0x00E620C8
		public string GetLevelTexture(int level)
		{
			DarkCoastDeliveryData darkCoastDeliveryData = ModelBase<MingSuModel>.Instance.GetDragonPoolInstanceById(3) as DarkCoastDeliveryData;
			if (darkCoastDeliveryData == null)
			{
				return string.Empty;
			}
			return darkCoastDeliveryData.GetLevelTexturePath(level);
		}

		// Token: 0x06038CEA RID: 232682 RVA: 0x00E63EF8 File Offset: 0x00E620F8
		public List<DarkCoastDeliveryLevelData> GetLevelDataList()
		{
			DarkCoastDeliveryData darkCoastDeliveryData = ModelBase<MingSuModel>.Instance.GetDragonPoolInstanceById(3) as DarkCoastDeliveryData;
			if (darkCoastDeliveryData == null)
			{
				return new List<DarkCoastDeliveryLevelData>();
			}
			List<DarkCoastDeliveryLevelData> list = new List<DarkCoastDeliveryLevelData>();
			for (int i = this.PreLevel + 1; i <= this.CurLevel; i++)
			{
				DarkCoastDeliveryLevelData levelData = darkCoastDeliveryData.GetLevelData(i);
				if (levelData != null)
				{
					list.Add(levelData);
				}
			}
			return list;
		}

		// Token: 0x040205CD RID: 132557
		public readonly int PreLevel;

		// Token: 0x040205CE RID: 132558
		public readonly int CurLevel;
	}
}
