using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FCA RID: 24522
	public class BattleSkillExtraEffectItem : UiPanelBase
	{
		// Token: 0x0603DA96 RID: 252566 RVA: 0x00FB5BCF File Offset: 0x00FB3DCF
		public void SetEffectType(ESkillButtonExtraEffect effectType)
		{
			this.EffectType = effectType;
		}

		// Token: 0x0603DA97 RID: 252567 RVA: 0x00FB5BD8 File Offset: 0x00FB3DD8
		public ESkillButtonExtraEffect GetEffectType()
		{
			return this.EffectType;
		}

		// Token: 0x0603DA98 RID: 252568 RVA: 0x00FB5BE0 File Offset: 0x00FB3DE0
		[NullableContext(1)]
		public virtual void Init(UUIItem rootUiItem)
		{
		}

		// Token: 0x0603DA99 RID: 252569 RVA: 0x00FB5BE2 File Offset: 0x00FB3DE2
		public void SetComponentActive(bool visibility)
		{
			this.TargetVisible = visibility;
			if (base.InAsyncLoading())
			{
				return;
			}
			this.SetActive(visibility);
		}

		// Token: 0x0603DA9A RID: 252570 RVA: 0x00FB5BFB File Offset: 0x00FB3DFB
		public void Refresh(float extraEffectDuration)
		{
			this.ExtraEffectDuration = extraEffectDuration;
			if (base.InAsyncLoading())
			{
				return;
			}
			this.OnRefresh();
		}

		// Token: 0x0603DA9B RID: 252571 RVA: 0x00FB5C13 File Offset: 0x00FB3E13
		protected virtual void OnRefresh()
		{
		}

		// Token: 0x0603DA9C RID: 252572 RVA: 0x00FB5C15 File Offset: 0x00FB3E15
		protected override void OnStart()
		{
			if (this.TargetVisible)
			{
				base.Show(null);
			}
		}

		// Token: 0x0603DA9D RID: 252573 RVA: 0x00FB5C26 File Offset: 0x00FB3E26
		protected override void OnBeforeShow()
		{
			this.OnRefresh();
		}

		// Token: 0x0603DA9E RID: 252574 RVA: 0x00FB5C2E File Offset: 0x00FB3E2E
		public virtual void Stop()
		{
		}

		// Token: 0x040229BE RID: 141758
		protected bool TargetVisible;

		// Token: 0x040229BF RID: 141759
		protected float ExtraEffectDuration;

		// Token: 0x040229C0 RID: 141760
		protected ESkillButtonExtraEffect EffectType;
	}
}
