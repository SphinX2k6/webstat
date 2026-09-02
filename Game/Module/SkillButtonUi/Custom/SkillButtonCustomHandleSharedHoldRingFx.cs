using System;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.Module.SkillButtonUi.Custom
{
	// Token: 0x02004FA0 RID: 20384
	public class SkillButtonCustomHandleSharedHoldRingFx : SkillButtonCustomHandleBase
	{
		// Token: 0x060349DD RID: 215517 RVA: 0x00D33080 File Offset: 0x00D31280
		public override void Refresh()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.Params.Count < 2)
			{
				return;
			}
			this.SkillButtonData.SharedHoldRingFxActions = new EInputAction[this.Params.Count];
			for (int i = 0; i < this.Params.Count; i++)
			{
				this.SkillButtonData.SharedHoldRingFxActions[i] = (EInputAction)((byte)int.Parse(this.Params[i]));
			}
			this.CustomHdModifyMark = true;
			this.CustomHdMarkFrom = 6;
		}
	}
}
