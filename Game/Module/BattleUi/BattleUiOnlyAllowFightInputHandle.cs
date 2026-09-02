using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F80 RID: 24448
	public class BattleUiOnlyAllowFightInputHandle
	{
		// Token: 0x0603D631 RID: 251441 RVA: 0x00F9D929 File Offset: 0x00F9BB29
		public void SetEnable(bool isEnable)
		{
			if (this.IsEnable == isEnable)
			{
				return;
			}
			this.IsEnable = isEnable;
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.SpecialSkill, this.HideBattleUiChildren, !isEnable, true, 0);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x0603D632 RID: 251442 RVA: 0x00F9D963 File Offset: 0x00F9BB63
		public bool GetEnable()
		{
			return this.IsEnable;
		}

		// Token: 0x040227BD RID: 141245
		[Nullable(1)]
		private readonly EBattleUiChild[] HideBattleUiChildren = new EBattleUiChild[]
		{
			EBattleUiChild.Common,
			EBattleUiChild.ExitButton,
			EBattleUiChild.HomeButton,
			EBattleUiChild.TopButton,
			EBattleUiChild.MiniMap,
			EBattleUiChild.Mission,
			EBattleUiChild.Chat,
			EBattleUiChild.Formation,
			EBattleUiChild.GamepadFormation,
			EBattleUiChild.InteractionHint,
			EBattleUiChild.SilentAreaView,
			EBattleUiChild.SilentAreaInfoPanel,
			EBattleUiChild.Score
		};

		// Token: 0x040227BE RID: 141246
		private bool IsEnable;
	}
}
