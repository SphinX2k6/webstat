using System;
using System.Reflection;

namespace CSharpScript.Game.Module.SkillButtonUi.Custom
{
	// Token: 0x02004F9B RID: 20379
	public class SkillButtonCustomHandleKeLaiTaUltimate : SkillButtonCustomHandleBase
	{
		// Token: 0x060349C6 RID: 215494 RVA: 0x00D329B1 File Offset: 0x00D30BB1
		protected override void OnInit()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			this.SkillButtonData.HideCoolDownTextCustom = true;
		}

		// Token: 0x060349C7 RID: 215495 RVA: 0x00D329C8 File Offset: 0x00D30BC8
		public override void Refresh()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.TagIds.Count < 1 || this.BuffIds.Count < 1)
			{
				return;
			}
			BaseTagComponent gameplayTagComponent = this.SkillButtonData.GameplayTagComponent;
			BaseBuffComponent buffComponent = this.SkillButtonData.BuffComponent;
			if (gameplayTagComponent == null || buffComponent == null)
			{
				return;
			}
			this.SkillButtonData.IsLimitCountCustom = false;
			this.SkillButtonData.RemainingCountCustom = 0;
			if (gameplayTagComponent.HasTag(this.TagIds[0]))
			{
				if (!this.ForceEnable)
				{
					this.ForceEnable = true;
					this.EnableModifyMark = true;
				}
				if (this.TagIds.Count > 1)
				{
					this.SkillButtonData.RemainingCountCustom = gameplayTagComponent.GetTagCount(this.TagIds[1]);
					if (this.SkillButtonData.RemainingCountCustom > 0)
					{
						this.SkillButtonData.IsLimitCountCustom = true;
					}
				}
				ActiveBuffInternal buffById = buffComponent.GetBuffById(this.BuffIds[0]);
				object obj;
				if (buffById == null)
				{
					obj = null;
				}
				else
				{
					PropertyInfo property = buffById.GetType().GetProperty("Duration");
					obj = ((property != null) ? property.GetValue(buffById) : null);
				}
				int? num = obj as int?;
				this.SkillButtonData.TotalCoolDownCustom = num.GetValueOrDefault();
				return;
			}
			this.SkillButtonData.TotalCoolDownCustom = 0;
			if (this.ForceEnable)
			{
				this.ForceEnable = false;
				this.EnableModifyMark = true;
			}
		}

		// Token: 0x060349C8 RID: 215496 RVA: 0x00D32B1C File Offset: 0x00D30D1C
		public override float GetCustomRemainingCoolDown()
		{
			if (this.SkillButtonData == null)
			{
				return 0f;
			}
			if (this.SkillButtonData.TotalCoolDownCustom <= 0)
			{
				return 0f;
			}
			BaseBuffComponent buffComponent = this.SkillButtonData.BuffComponent;
			if (buffComponent == null)
			{
				return 0f;
			}
			ActiveBuffInternal buffById = buffComponent.GetBuffById(this.BuffIds[0]);
			if (buffById == null)
			{
				return 0f;
			}
			MethodInfo method = buffById.GetType().GetMethod("GetRemainDuration");
			return (((method != null) ? method.Invoke(buffById, null) : null) as float?).GetValueOrDefault();
		}

		// Token: 0x060349C9 RID: 215497 RVA: 0x00D32BAC File Offset: 0x00D30DAC
		public override void RefreshByTagChanged()
		{
			this.Refresh();
			this.SkillCdModifyMark = true;
		}
	}
}
