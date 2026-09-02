using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkillButtonUi.Custom
{
	// Token: 0x02004F9F RID: 20383
	public class SkillButtonCustomHandleDotIndicator : SkillButtonCustomHandleBase
	{
		// Token: 0x060349D7 RID: 215511 RVA: 0x00D32F00 File Offset: 0x00D31100
		protected override void OnInit()
		{
			if (this.Params.Count < 1 || this.Params[0] == "")
			{
				this.ActionType = 0;
			}
			else
			{
				int.TryParse(this.Params[0], out this.ActionType);
			}
			if (this.Params.Count >= 2)
			{
				this.IconPath = this.Params[1];
			}
		}

		// Token: 0x060349D8 RID: 215512 RVA: 0x00D32F74 File Offset: 0x00D31174
		public override void Refresh()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.TagIds.Count < 2)
			{
				this.ResetSkillButtonData();
				return;
			}
			if (this.ActionType == 0 || (int)this.SkillButtonData.GetActionType() == this.ActionType)
			{
				BaseTagComponent gameplayTagComponent = this.SkillButtonData.GameplayTagComponent;
				this.SkillButtonData.IsEnableDotIndicator = (gameplayTagComponent != null && gameplayTagComponent.HasTag(this.TagIds[0]));
				this.SkillButtonData.DotIndicatorCount = ((gameplayTagComponent != null) ? gameplayTagComponent.GetTagCount(this.TagIds[1]) : 0);
				this.SkillButtonData.DotIndicatorIconPath = this.IconPath;
				this.CustomHdModifyMark = true;
				this.CustomHdMarkFrom = 5;
				return;
			}
			this.ResetSkillButtonData();
		}

		// Token: 0x060349D9 RID: 215513 RVA: 0x00D33037 File Offset: 0x00D31237
		private void ResetSkillButtonData()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			this.SkillButtonData.IsEnableDotIndicator = false;
			this.SkillButtonData.DotIndicatorCount = 0;
			this.SkillButtonData.DotIndicatorIconPath = null;
		}

		// Token: 0x060349DA RID: 215514 RVA: 0x00D33066 File Offset: 0x00D31266
		public override void RefreshByTagChanged()
		{
			this.Refresh();
		}

		// Token: 0x060349DB RID: 215515 RVA: 0x00D3306E File Offset: 0x00D3126E
		public override bool RefreshOnInputControllerChange()
		{
			this.Refresh();
			return true;
		}

		// Token: 0x0401E55B RID: 124251
		private int ActionType;

		// Token: 0x0401E55C RID: 124252
		[Nullable(2)]
		private string IconPath;
	}
}
