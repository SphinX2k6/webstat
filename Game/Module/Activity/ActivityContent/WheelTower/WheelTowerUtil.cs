using System;
using System.Collections.Generic;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006225 RID: 25125
	public static class WheelTowerUtil
	{
		// Token: 0x0603F65A RID: 259674 RVA: 0x0103EF24 File Offset: 0x0103D124
		public static NewTowerMedal? GetLastMedalConfigByGroupId(int groupId)
		{
			IReadOnlyList<NewTowerMedal> medalConfigListByGroupId = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigListByGroupId(groupId);
			if (medalConfigListByGroupId == null || medalConfigListByGroupId.Count == 0)
			{
				return null;
			}
			NewTowerMedal value = medalConfigListByGroupId[0];
			for (int i = 1; i < medalConfigListByGroupId.Count; i++)
			{
				if (medalConfigListByGroupId[i].Target > value.Target)
				{
					value = medalConfigListByGroupId[i];
				}
			}
			return new NewTowerMedal?(value);
		}
	}
}
