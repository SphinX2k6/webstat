using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DA9 RID: 19881
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseLevelModeData : TrapDefenseLevelModeDataBase, ITrapDefenseLevelModeData<TrapDefenseLevelModeData>
	{
		// Token: 0x060337F6 RID: 210934 RVA: 0x00CE18F4 File Offset: 0x00CDFAF4
		protected override void Init()
		{
		}

		// Token: 0x060337F7 RID: 210935 RVA: 0x00CE18F6 File Offset: 0x00CDFAF6
		public List<ITrapDefenseDifficultyLevelInfo> GetDifficultyTypeList()
		{
			return new List<ITrapDefenseDifficultyLevelInfo>
			{
				TrapDefenseDefine.trapDefenseDifficultyLevelRecord[ETrapDefenseDifficultyLevel.Normal],
				TrapDefenseDefine.trapDefenseDifficultyLevelRecord[ETrapDefenseDifficultyLevel.Nightmare],
				TrapDefenseDefine.trapDefenseDifficultyLevelRecord[ETrapDefenseDifficultyLevel.Hell]
			};
		}

		// Token: 0x060337F8 RID: 210936 RVA: 0x00CE1930 File Offset: 0x00CDFB30
		public List<TrapDefenseLevelData> GetLevelDataListByDifficulty(ETrapDefenseDifficultyLevel difficulty)
		{
			List<TrapDefenseLevelData> list = new List<TrapDefenseLevelData>();
			foreach (TrapDefenseLevelData trapDefenseLevelData in this.LevelDataList)
			{
				if (trapDefenseLevelData.IsDifficulty(difficulty))
				{
					list.Add(trapDefenseLevelData);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i].SetPosition(i + 1);
			}
			return list;
		}
	}
}
