using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200525A RID: 21082
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleUtils
	{
		// Token: 0x06035F8A RID: 221066 RVA: 0x00D945C8 File Offset: 0x00D927C8
		public static List<IRogueBattleElementInfo> GetTokenSortElementInfo(RogueResGainData data)
		{
			List<IRogueBattleElementInfo> list = new List<IRogueBattleElementInfo>();
			foreach (ElementUnit elementUnit in data.RogueResToken.ElementUnits)
			{
				list.Add(new RogueBattleElementInfo
				{
					ElementId = elementUnit.ElementId,
					Count = elementUnit.Count,
					IsPreview = false
				});
			}
			return list;
		}

		// Token: 0x06035F8B RID: 221067 RVA: 0x00D94644 File Offset: 0x00D92844
		public static int[] GetTokenSortElementInfoByCount(RogueResGainData data)
		{
			List<IRogueBattleElementInfo> list = new List<IRogueBattleElementInfo>();
			ElementUnit[] array = new ElementUnit[0];
			if (data.RogueResToken != null)
			{
				array = data.RogueResToken.ElementUnits.ToArray<ElementUnit>();
			}
			else if (data.RogueResShopToken != null)
			{
				array = data.RogueResShopToken.ElementUnits.ToArray<ElementUnit>();
			}
			foreach (ElementUnit elementUnit in array)
			{
				list.Add(new RogueBattleElementInfo
				{
					ElementId = elementUnit.ElementId,
					Count = elementUnit.Count,
					IsPreview = false
				});
			}
			if (list.Count <= 0)
			{
				return Array.Empty<int>();
			}
			int[] array3 = new int[list[0].Count];
			for (int j = 0; j < array3.Length; j++)
			{
				array3[j] = list[0].ElementId;
			}
			return array3;
		}

		// Token: 0x06035F8C RID: 221068 RVA: 0x00D9471C File Offset: 0x00D9291C
		public static List<IRogueBattleElementInfo> ConvertElementUnitsToElementInfo(ElementUnit[] elementUnits)
		{
			List<IRogueBattleElementInfo> list = new List<IRogueBattleElementInfo>();
			foreach (ElementUnit elementUnit in elementUnits)
			{
				list.Add(new RogueBattleElementInfo
				{
					ElementId = elementUnit.ElementId,
					Count = elementUnit.Count,
					IsPreview = false
				});
			}
			return list;
		}
	}
}
