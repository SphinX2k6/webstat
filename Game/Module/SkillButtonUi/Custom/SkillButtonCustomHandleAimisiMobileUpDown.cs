using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.SkillButtonUi.Custom
{
	// Token: 0x02004F9E RID: 20382
	public class SkillButtonCustomHandleAimisiMobileUpDown : SkillButtonCustomHandleBase
	{
		// Token: 0x060349D3 RID: 215507 RVA: 0x00D32DD4 File Offset: 0x00D30FD4
		public override void Refresh()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.TagIds.Count < 1)
			{
				return;
			}
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.SkillButtonData.CustomSkillIconName = null;
				this.SkillButtonData.CustomSkillTexturePath = null;
				this.SkillButtonData.IsEnableSlideControl = false;
				return;
			}
			BaseTagComponent gameplayTagComponent = this.SkillButtonData.GameplayTagComponent;
			if (gameplayTagComponent != null && !gameplayTagComponent.HasTag(this.TagIds[0]) && gameplayTagComponent.HasTag(this.TagIds[1]))
			{
				this.SkillButtonData.CustomSkillTexturePath = ((this.Params.Count > 0) ? this.Params[0] : null);
				this.SkillButtonData.CustomSkillIconName = ((this.Params.Count > 1) ? this.Params[1] : null);
				this.SkillButtonData.IsEnableSlideControl = true;
				return;
			}
			this.SkillButtonData.CustomSkillIconName = null;
			this.SkillButtonData.CustomSkillTexturePath = null;
			this.SkillButtonData.IsEnableSlideControl = false;
		}

		// Token: 0x060349D4 RID: 215508 RVA: 0x00D32EE5 File Offset: 0x00D310E5
		public override void RefreshByTagChanged()
		{
			this.Refresh();
		}

		// Token: 0x060349D5 RID: 215509 RVA: 0x00D32EED File Offset: 0x00D310ED
		public override bool RefreshOnInputControllerChange()
		{
			this.Refresh();
			return true;
		}
	}
}
