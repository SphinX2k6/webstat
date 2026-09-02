using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E06 RID: 19974
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMainLevelViewModel
	{
		// Token: 0x06033A7B RID: 211579 RVA: 0x00CE8A26 File Offset: 0x00CE6C26
		public static TrapDefenseMainLevelViewModel Create(TrapDefenseModel model)
		{
			return new TrapDefenseMainLevelViewModel
			{
				Model = model
			};
		}

		// Token: 0x06033A7C RID: 211580 RVA: 0x00CE8A34 File Offset: 0x00CE6C34
		private TrapDefenseMainLevelViewModel()
		{
		}

		// Token: 0x06033A7D RID: 211581 RVA: 0x00CE8A3C File Offset: 0x00CE6C3C
		public void OnViewClose()
		{
		}

		// Token: 0x06033A7E RID: 211582 RVA: 0x00CE8A3E File Offset: 0x00CE6C3E
		public void SetJumpDifficulty(ETrapDefenseDifficultyLevel? difficulty)
		{
			this.JumpDifficulty = difficulty;
		}

		// Token: 0x06033A7F RID: 211583 RVA: 0x00CE8A48 File Offset: 0x00CE6C48
		public void SetJumpLevelData(int? id)
		{
			TrapDefenseLevelData trapDefenseLevelData;
			this.JumpLevelData = (this.Model.LevelDataFromIdMap.TryGetValue(id.GetValueOrDefault(), out trapDefenseLevelData) ? trapDefenseLevelData : null);
		}

		// Token: 0x06033A80 RID: 211584 RVA: 0x00CE8A7A File Offset: 0x00CE6C7A
		public void SetIsInstance(bool isInstance)
		{
			this.IsInstance = isInstance;
		}

		// Token: 0x0401DEBC RID: 122556
		public TrapDefenseModel Model;

		// Token: 0x0401DEBD RID: 122557
		public ETrapDefenseDifficultyLevel? JumpDifficulty;

		// Token: 0x0401DEBE RID: 122558
		[Nullable(2)]
		public TrapDefenseLevelData JumpLevelData;

		// Token: 0x0401DEBF RID: 122559
		public bool IsInstance;
	}
}
