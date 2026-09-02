using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E38 RID: 20024
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseRougeLevelTabPanel : TrapDefenseLevelTabPanel<TrapDefenseRougeModeData>
	{
		// Token: 0x06033C2C RID: 212012 RVA: 0x00CF06FB File Offset: 0x00CEE8FB
		public TrapDefenseRougeLevelTabPanel()
		{
			this.ModeData = ModelBase<TrapDefenseModel>.Instance.RougeModeData;
		}

		// Token: 0x06033C2D RID: 212013 RVA: 0x00CF0713 File Offset: 0x00CEE913
		protected override void OnStart()
		{
			this.PanelDifficultyChange.SetActive(false);
		}

		// Token: 0x06033C2E RID: 212014 RVA: 0x00CF0721 File Offset: 0x00CEE921
		public override void UpdateModeData()
		{
			base.UpdateLevelDataList(this.ModeData.LevelDataList.ToArray());
			base.UpdateBdSumProgress();
		}
	}
}
