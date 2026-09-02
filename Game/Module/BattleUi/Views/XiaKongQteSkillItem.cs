using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006107 RID: 24839
	[NullableContext(1)]
	[Nullable(0)]
	public class XiaKongQteSkillItem : BattleSkillItem
	{
		// Token: 0x0603EC19 RID: 257049 RVA: 0x01011B04 File Offset: 0x0100FD04
		public void SetPressCallback(Action<int> onPressCallback)
		{
			this.OnPressCallback = onPressCallback;
		}

		// Token: 0x0603EC1A RID: 257050 RVA: 0x01011B0D File Offset: 0x0100FD0D
		public void RefreshType(int inputType)
		{
			this.InputType = inputType;
			this.RefreshOnInputControllerMainTypeChange();
		}

		// Token: 0x0603EC1B RID: 257051 RVA: 0x01011B1C File Offset: 0x0100FD1C
		public void RefreshOnInputControllerMainTypeChange()
		{
			string actionNameByInputType = this.GetActionNameByInputType(this.InputType);
			if (!string.IsNullOrEmpty(actionNameByInputType))
			{
				this.RefreshKeyByActionName(actionNameByInputType);
			}
		}

		// Token: 0x0603EC1C RID: 257052 RVA: 0x01011B45 File Offset: 0x0100FD45
		[NullableContext(2)]
		private string GetActionNameByInputType(int inputType)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return null;
			}
			if (inputType == 1)
			{
				return "向右移动";
			}
			if (inputType == 2)
			{
				return "向左移动";
			}
			if (inputType == 4)
			{
				return "大招";
			}
			return null;
		}

		// Token: 0x0603EC1D RID: 257053 RVA: 0x01011B74 File Offset: 0x0100FD74
		private void RefreshKeyByActionName(string actionName)
		{
			if (Singleton<Info>.Instance.OperationType != EOperationType.Desktop)
			{
				return;
			}
			if (this.KeyActionName == actionName)
			{
				return;
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
			this.KeyActionName = actionName;
		}

		// Token: 0x0603EC1E RID: 257054 RVA: 0x01011BD4 File Offset: 0x0100FDD4
		public void RefreshSkillIconByResId(string resourceId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetSkillIcon(resourcePath);
		}

		// Token: 0x0603EC1F RID: 257055 RVA: 0x01011BF4 File Offset: 0x0100FDF4
		protected override void OnSkillButtonPressed()
		{
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect != null)
			{
				clickEffect.Play();
			}
			Action<int> onPressCallback = this.OnPressCallback;
			if (onPressCallback == null)
			{
				return;
			}
			onPressCallback(this.InputType);
		}

		// Token: 0x0603EC20 RID: 257056 RVA: 0x01011C1D File Offset: 0x0100FE1D
		public void SetEnable(bool enable)
		{
			this.Enable = enable;
			this.RefreshEnable(false);
			this.RefreshDynamicEffect();
		}

		// Token: 0x0603EC21 RID: 257057 RVA: 0x01011C33 File Offset: 0x0100FE33
		public override void RefreshEnable(bool bForce = false)
		{
			base.SetSkillItemEnable(this.Enable, bForce);
		}

		// Token: 0x0603EC22 RID: 257058 RVA: 0x01011C42 File Offset: 0x0100FE42
		public override void RefreshDynamicEffect()
		{
			base.SetDynamicEffectVisible(this.Enable);
		}

		// Token: 0x0603EC23 RID: 257059 RVA: 0x01011C50 File Offset: 0x0100FE50
		public void SetSkillIconName(string skillIconName)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.SkillNameText, skillIconName, Array.Empty<object>());
			this.SkillNameText.SetUIActive(true);
		}

		// Token: 0x04023325 RID: 144165
		private int InputType;

		// Token: 0x04023326 RID: 144166
		[Nullable(2)]
		private Action<int> OnPressCallback;

		// Token: 0x04023327 RID: 144167
		private bool Enable;
	}
}
