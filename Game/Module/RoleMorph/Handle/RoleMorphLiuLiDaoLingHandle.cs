using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.RoleMorph.Handle
{
	// Token: 0x020050E7 RID: 20711
	public class RoleMorphLiuLiDaoLingHandle : RoleMorphHandleBase
	{
		// Token: 0x0603562F RID: 218671 RVA: 0x00D64405 File Offset: 0x00D62605
		public override void BeginMorph()
		{
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData == null)
			{
				return;
			}
			childViewData.SetChildrenVisible(EBattleUiVisibleReason.Custom, new List<EBattleUiChild>
			{
				EBattleUiChild.BattleFloat,
				EBattleUiChild.SkillButton,
				EBattleUiChild.GamepadSkillButton
			}, false, true, 0);
		}

		// Token: 0x06035630 RID: 218672 RVA: 0x00D6443C File Offset: 0x00D6263C
		public override void EndMorph()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.LiuLiDaoLingView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.LiuLiDaoLingView, null);
			}
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData == null)
			{
				return;
			}
			childViewData.SetChildrenVisible(EBattleUiVisibleReason.Custom, new List<EBattleUiChild>
			{
				EBattleUiChild.BattleFloat,
				EBattleUiChild.SkillButton,
				EBattleUiChild.GamepadSkillButton
			}, true, true, 0);
		}
	}
}
