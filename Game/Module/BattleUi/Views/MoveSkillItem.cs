using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.SkillButtonUi;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200608A RID: 24714
	[NullableContext(1)]
	[Nullable(0)]
	public class MoveSkillItem : BattleSkillItem
	{
		// Token: 0x0603E5A2 RID: 255394 RVA: 0x00FEC92D File Offset: 0x00FEAB2D
		public void RefreshByMoveType(EInputAxis inputAxis, float inputValue, bool autoClearInput = true)
		{
			this.InputAxis = inputAxis;
			this.InputValue = inputValue;
			this.AutoClearInput = autoClearInput;
			if (!base.IsShowOrShowing)
			{
				base.Show(null);
			}
		}

		// Token: 0x0603E5A3 RID: 255395 RVA: 0x00FEC954 File Offset: 0x00FEAB54
		public void RefreshKeyByActionName(string actionName)
		{
			EOperationType operationType = Singleton<Info>.Instance.OperationType;
			if (operationType != EOperationType.Desktop)
			{
				return;
			}
			if (this.KeyActionName == actionName)
			{
				EOperationType? keyOperationType = this.KeyOperationType;
				EOperationType eoperationType = operationType;
				if (keyOperationType.GetValueOrDefault() == eoperationType & keyOperationType != null)
				{
					return;
				}
			}
			if (this.KeyItem != null)
			{
				InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
				{
					ActionOrAxisName = actionName
				};
				this.KeyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
				this.KeyItem.SetActive(true);
			}
			this.KeyOperationType = new EOperationType?(operationType);
			this.KeyActionName = actionName;
		}

		// Token: 0x0603E5A4 RID: 255396 RVA: 0x00FEC9E0 File Offset: 0x00FEABE0
		public void RefreshSkillIconByResId(string resourceId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetSkillIcon(resourcePath);
		}

		// Token: 0x0603E5A5 RID: 255397 RVA: 0x00FECA00 File Offset: 0x00FEAC00
		protected override void OnSkillButtonPressed()
		{
			this.IsPress = true;
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect != null)
			{
				clickEffect.Play();
			}
			ControllerBase<InputController>.Instance.InputAxis(this.InputAxis, this.InputValue, this.AutoClearInput);
		}

		// Token: 0x0603E5A6 RID: 255398 RVA: 0x00FECA36 File Offset: 0x00FEAC36
		protected override void OnSkillButtonReleased()
		{
			this.IsPress = false;
			ControllerBase<InputController>.Instance.InputAxis(this.InputAxis, 0f, this.AutoClearInput);
		}

		// Token: 0x0603E5A7 RID: 255399 RVA: 0x00FECA5A File Offset: 0x00FEAC5A
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (!this.IsPress || !this.AutoClearInput)
			{
				return;
			}
			ControllerBase<InputController>.Instance.InputAxis(this.InputAxis, this.InputValue, true);
		}

		// Token: 0x0603E5A8 RID: 255400 RVA: 0x00FECA8B File Offset: 0x00FEAC8B
		protected override void OnBeforeHide()
		{
			this.IsPress = false;
		}

		// Token: 0x0603E5A9 RID: 255401 RVA: 0x00FECA94 File Offset: 0x00FEAC94
		public override void OnInputAction(bool bForcePlayClickEffect = false)
		{
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect == null)
			{
				return;
			}
			clickEffect.Play();
		}

		// Token: 0x0603E5AA RID: 255402 RVA: 0x00FECAA6 File Offset: 0x00FEACA6
		public void SetCustomDynamicEffectId(int effectId)
		{
			this.CustomDynamicEffectId = effectId;
			this.RefreshDynamicEffect();
		}

		// Token: 0x0603E5AB RID: 255403 RVA: 0x00FECAB8 File Offset: 0x00FEACB8
		protected override SkillButtonEffect? GetDynamicEffectConfig()
		{
			if (this.CustomDynamicEffectId == 0)
			{
				return null;
			}
			return ConfigBase<SkillButtonConfig>.Instance.GetSkillButtonEffectConfig(this.CustomDynamicEffectId);
		}

		// Token: 0x0603E5AC RID: 255404 RVA: 0x00FECAE7 File Offset: 0x00FEACE7
		public void SetCustomSkillItemEnable(bool bEnable)
		{
			base.SetSkillItemEnable(bEnable, true);
		}

		// Token: 0x04022F23 RID: 143139
		private EInputAxis InputAxis = EInputAxis.None;

		// Token: 0x04022F24 RID: 143140
		private float InputValue;

		// Token: 0x04022F25 RID: 143141
		private int CustomDynamicEffectId;

		// Token: 0x04022F26 RID: 143142
		private bool AutoClearInput = true;

		// Token: 0x04022F27 RID: 143143
		private bool IsPress;
	}
}
