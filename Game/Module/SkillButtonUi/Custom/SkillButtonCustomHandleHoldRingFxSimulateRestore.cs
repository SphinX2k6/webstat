using System;
using System.Collections.Generic;

namespace CSharpScript.Game.Module.SkillButtonUi.Custom
{
	// Token: 0x02004FA1 RID: 20385
	public class SkillButtonCustomHandleHoldRingFxSimulateRestore : SkillButtonCustomHandleBase
	{
		// Token: 0x060349DF RID: 215519 RVA: 0x00D33114 File Offset: 0x00D31314
		public override void Refresh()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.Params.Count < 1 || this.Params.Count != this.TagIds.Count)
			{
				return;
			}
			this.SkillButtonData.HoldRingFxRestoreMap = new Dictionary<int, int>();
			for (int i = 0; i < this.Params.Count; i++)
			{
				this.SkillButtonData.HoldRingFxRestoreMap.Add(this.TagIds[i], int.Parse(this.Params[i]));
			}
			this.CustomHdModifyMark = true;
			this.CustomHdMarkFrom = 7;
		}
	}
}
