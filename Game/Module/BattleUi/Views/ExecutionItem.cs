using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006005 RID: 24581
	[NullableContext(1)]
	[Nullable(0)]
	public class ExecutionItem : BattleSkillItem
	{
		// Token: 0x0603DEB2 RID: 253618 RVA: 0x00FCB873 File Offset: 0x00FC9A73
		public void Init(Action callback)
		{
			this.Callback = callback;
			if (!base.IsShowOrShowing)
			{
				base.Show(null);
			}
		}

		// Token: 0x0603DEB3 RID: 253619 RVA: 0x00FCB88C File Offset: 0x00FC9A8C
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

		// Token: 0x0603DEB4 RID: 253620 RVA: 0x00FCB918 File Offset: 0x00FC9B18
		public void RefreshSkillIconByResId(string resourceId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetSkillIcon(resourcePath);
		}

		// Token: 0x0603DEB5 RID: 253621 RVA: 0x00FCB938 File Offset: 0x00FC9B38
		protected override void OnSkillButtonPressed()
		{
			Action callback = this.Callback;
			if (callback == null)
			{
				return;
			}
			callback();
		}

		// Token: 0x0603DEB6 RID: 253622 RVA: 0x00FCB94A File Offset: 0x00FC9B4A
		public override void OnInputAction(bool bForcePlayClickEffect = false)
		{
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect == null)
			{
				return;
			}
			clickEffect.Play();
		}

		// Token: 0x04022BBD RID: 142269
		[Nullable(2)]
		private Action Callback;
	}
}
