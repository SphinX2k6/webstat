using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.SkillButtonUi;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006088 RID: 24712
	public class MotorcycleSkillItem : BattleSkillItem
	{
		// Token: 0x0603E593 RID: 255379 RVA: 0x00FEC4C8 File Offset: 0x00FEA6C8
		[NullableContext(2)]
		public override void Refresh(ISkillButtonData skillButtonData)
		{
			if (skillButtonData == null)
			{
				this.InputValue = 0f;
			}
			else if (skillButtonData.GetButtonType() == ESkillButtonType.前进)
			{
				this.InputValue = 1f;
			}
			else if (skillButtonData.GetButtonType() == ESkillButtonType.刹车)
			{
				this.InputValue = -1f;
			}
			else
			{
				this.InputValue = 0f;
			}
			base.Refresh(skillButtonData);
		}

		// Token: 0x0603E594 RID: 255380 RVA: 0x00FEC52C File Offset: 0x00FEA72C
		[NullableContext(1)]
		public void RefreshSkillIconByResId(string resourceId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetSkillIcon(resourcePath);
		}

		// Token: 0x0603E595 RID: 255381 RVA: 0x00FEC54C File Offset: 0x00FEA74C
		protected override void OnSkillButtonPressed()
		{
			if (this.InputValue == 0f)
			{
				base.OnSkillButtonPressed();
				return;
			}
			this.IsPress = true;
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect != null)
			{
				clickEffect.Play();
			}
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, this.InputValue, true);
		}

		// Token: 0x0603E596 RID: 255382 RVA: 0x00FEC59B File Offset: 0x00FEA79B
		protected override void OnSkillButtonReleased()
		{
			if (this.InputValue == 0f)
			{
				base.OnSkillButtonReleased();
				return;
			}
			this.IsPress = false;
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, 0f, true);
		}

		// Token: 0x0603E597 RID: 255383 RVA: 0x00FEC5CD File Offset: 0x00FEA7CD
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (!this.IsPress)
			{
				return;
			}
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, this.InputValue, true);
		}

		// Token: 0x0603E598 RID: 255384 RVA: 0x00FEC5F5 File Offset: 0x00FEA7F5
		protected override void OnBeforeHide()
		{
			base.OnBeforeHide();
			this.IsPress = false;
		}

		// Token: 0x0603E599 RID: 255385 RVA: 0x00FEC604 File Offset: 0x00FEA804
		public override void OnInputAction(bool bForcePlayClickEffect = false)
		{
			if (this.InputValue == 0f)
			{
				base.OnInputAction(bForcePlayClickEffect);
				return;
			}
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect == null)
			{
				return;
			}
			clickEffect.Play();
		}

		// Token: 0x04022F18 RID: 143128
		private bool IsPress;

		// Token: 0x04022F19 RID: 143129
		private float InputValue;
	}
}
