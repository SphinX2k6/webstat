using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Monster.Component;

namespace CSharpScript.Game.Module.SkillButtonUi.Custom
{
	// Token: 0x02004F9C RID: 20380
	public class SkillButtonCustomHandleHackFollowAttach : SkillButtonCustomHandleBase
	{
		// Token: 0x060349CB RID: 215499 RVA: 0x00D32BC3 File Offset: 0x00D30DC3
		protected override void OnInit()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			EntityHandle entityHandle = this.SkillButtonData.GetEntityHandle();
			HackManagementComponent hackComp;
			if (entityHandle == null)
			{
				hackComp = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				hackComp = ((entity != null) ? entity.GetComponent<HackManagementComponent>() : null);
			}
			this.HackComp = hackComp;
		}

		// Token: 0x060349CC RID: 215500 RVA: 0x00D32BF8 File Offset: 0x00D30DF8
		public override void Refresh()
		{
			if (this.SkillButtonData == null || this.HackComp == null)
			{
				return;
			}
			if (this.TagIds.Count < 1)
			{
				return;
			}
			BaseTagComponent gameplayTagComponent = this.SkillButtonData.GameplayTagComponent;
			this.SkillButtonData.IsLimitCountCustom = true;
			this.SkillButtonData.RemainingCountCustom = ((gameplayTagComponent != null) ? gameplayTagComponent.GetTagCount(this.TagIds[0]) : 0);
		}

		// Token: 0x060349CD RID: 215501 RVA: 0x00D32C60 File Offset: 0x00D30E60
		public override void RefreshByTagChanged()
		{
			this.Refresh();
			this.SkillCdModifyMark = true;
		}

		// Token: 0x0401E55A RID: 124250
		[Nullable(2)]
		private HackManagementComponent HackComp;
	}
}
