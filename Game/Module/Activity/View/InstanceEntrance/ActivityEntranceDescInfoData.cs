using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061DE RID: 25054
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityEntranceDescInfoData
	{
		// Token: 0x0603F38F RID: 258959 RVA: 0x0103A472 File Offset: 0x01038672
		public string GetName(int dataIndex)
		{
			if (this.GetNameFunc == null)
			{
				return string.Empty;
			}
			return this.GetNameFunc(dataIndex);
		}

		// Token: 0x0603F390 RID: 258960 RVA: 0x0103A48E File Offset: 0x0103868E
		public string GetDesc(int dataIndex)
		{
			if (this.GetDescFunc == null)
			{
				return string.Empty;
			}
			return this.GetDescFunc(dataIndex);
		}

		// Token: 0x0603F391 RID: 258961 RVA: 0x0103A4AA File Offset: 0x010386AA
		public List<int> GetRecommendElement(int dataIndex)
		{
			if (this.GetRecommendElementFunc == null)
			{
				return new List<int>();
			}
			return this.GetRecommendElementFunc(dataIndex);
		}

		// Token: 0x0603F392 RID: 258962 RVA: 0x0103A4C6 File Offset: 0x010386C6
		public static ActivityEntranceDescInfoData Create(Func<int, string> getNameFunc, Func<int, string> getDescFunc, Func<int, List<int>> getRecommendElementFunc)
		{
			return new ActivityEntranceDescInfoData
			{
				GetNameFunc = getNameFunc,
				GetDescFunc = getDescFunc,
				GetRecommendElementFunc = getRecommendElementFunc
			};
		}

		// Token: 0x040237FF RID: 145407
		private Func<int, string> GetNameFunc;

		// Token: 0x04023800 RID: 145408
		private Func<int, string> GetDescFunc;

		// Token: 0x04023801 RID: 145409
		private Func<int, List<int>> GetRecommendElementFunc;
	}
}
