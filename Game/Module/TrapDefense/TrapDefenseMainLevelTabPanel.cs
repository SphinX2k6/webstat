using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E36 RID: 20022
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseMainLevelTabPanel : TrapDefenseLevelTabPanel<TrapDefenseLevelModeData>
	{
		// Token: 0x06033C12 RID: 211986 RVA: 0x00CF005F File Offset: 0x00CEE25F
		public TrapDefenseMainLevelTabPanel()
		{
			this.ModeData = ModelBase<TrapDefenseModel>.Instance.LevelModeData;
		}

		// Token: 0x06033C13 RID: 211987 RVA: 0x00CF0080 File Offset: 0x00CEE280
		protected override void OnStart()
		{
			this.PanelDifficultyChange.SetActive(true);
			this.PanelDifficultyChange.OnSelectDifficultyCallback = new Action<ITrapDefenseDifficultyLevelInfo>(this.OnSelectDifficulty);
			this.PanelDifficultyChange.OnRedDotLeftVisibleCallback = new Func<int, bool>(this.OnRedDotLeftVisible);
			this.PanelDifficultyChange.OnRedDotRightVisibleCallback = new Func<int, bool>(this.OnRedDotRightVisible);
		}

		// Token: 0x06033C14 RID: 211988 RVA: 0x00CF00DE File Offset: 0x00CEE2DE
		public void InitSelectDifficulty(ETrapDefenseDifficultyLevel difficulty)
		{
			this.CurSelectDifficulty = difficulty;
		}

		// Token: 0x06033C15 RID: 211989 RVA: 0x00CF00E8 File Offset: 0x00CEE2E8
		public override void UpdateModeData()
		{
			List<ITrapDefenseDifficultyLevelInfo> difficultyTypeList = this.ModeData.GetDifficultyTypeList();
			int selectIndex = difficultyTypeList.FindIndex((ITrapDefenseDifficultyLevelInfo info) => info.DifficultyLevel == this.CurSelectDifficulty);
			this.DifficultyTypeList = difficultyTypeList.ToArray();
			this.PanelDifficultyChange.UpdateDataList(difficultyTypeList.ToArray(), selectIndex);
		}

		// Token: 0x06033C16 RID: 211990 RVA: 0x00CF0134 File Offset: 0x00CEE334
		public void OnSelectDifficulty(ITrapDefenseDifficultyLevelInfo info)
		{
			this.CurSelectDifficulty = info.DifficultyLevel;
			List<TrapDefenseLevelData> levelDataListByDifficulty = this.ModeData.GetLevelDataListByDifficulty(info.DifficultyLevel);
			base.UpdateLevelDataList(levelDataListByDifficulty.ToArray());
		}

		// Token: 0x06033C17 RID: 211991 RVA: 0x00CF016C File Offset: 0x00CEE36C
		public bool OnRedDotLeftVisible(int index)
		{
			ETrapDefenseDifficultyLevel difficultyLevel = this.DifficultyTypeList[index].DifficultyLevel;
			foreach (TrapDefenseLevelData data in this.ModeData.GetLevelDataListByDifficulty(difficultyLevel))
			{
				if (this.ModeData.GetLevelReachOpenTimeRedDotState(data))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06033C18 RID: 211992 RVA: 0x00CF01E4 File Offset: 0x00CEE3E4
		public bool OnRedDotRightVisible(int index)
		{
			ETrapDefenseDifficultyLevel difficultyLevel = this.DifficultyTypeList[index].DifficultyLevel;
			foreach (TrapDefenseLevelData data in this.ModeData.GetLevelDataListByDifficulty(difficultyLevel))
			{
				if (this.ModeData.GetLevelReachOpenTimeRedDotState(data))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0401DF4A RID: 122698
		public ETrapDefenseDifficultyLevel CurSelectDifficulty = ETrapDefenseDifficultyLevel.Normal;

		// Token: 0x0401DF4B RID: 122699
		public ITrapDefenseDifficultyLevelInfo[] DifficultyTypeList;
	}
}
