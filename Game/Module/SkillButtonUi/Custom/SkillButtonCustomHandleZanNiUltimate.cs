using System;
using System.Reflection;

namespace CSharpScript.Game.Module.SkillButtonUi.Custom
{
	// Token: 0x02004F9D RID: 20381
	public class SkillButtonCustomHandleZanNiUltimate : SkillButtonCustomHandleBase
	{
		// Token: 0x060349CF RID: 215503 RVA: 0x00D32C77 File Offset: 0x00D30E77
		protected override void OnInit()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			this.SkillButtonData.HideCoolDownTextCustom = true;
		}

		// Token: 0x060349D0 RID: 215504 RVA: 0x00D32C90 File Offset: 0x00D30E90
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
			if (gameplayTagComponent.HasTag(this.TagIds[0]))
			{
				bool flag = true;
				for (int i = 1; i < this.TagIds.Count; i++)
				{
					if (gameplayTagComponent.HasTag(this.TagIds[i]))
					{
						flag = false;
						break;
					}
				}
				if (this.ForceEnable != flag)
				{
					this.ForceEnable = flag;
					this.EnableModifyMark = true;
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

		// Token: 0x060349D1 RID: 215505 RVA: 0x00D32DBC File Offset: 0x00D30FBC
		public override void RefreshByTagChanged()
		{
			this.Refresh();
			this.SkillCdModifyMark = true;
		}
	}
}
