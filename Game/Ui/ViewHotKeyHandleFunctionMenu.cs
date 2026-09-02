using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.BattleUi;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A15 RID: 18965
	public class ViewHotKeyHandleFunctionMenu : ViewHotKeyHandle
	{
		// Token: 0x060318FE RID: 203006 RVA: 0x00C5A35F File Offset: 0x00C5855F
		[NullableContext(1)]
		public ViewHotKeyHandleFunctionMenu(IOpenAndCloseViewHotKey parameters) : base(parameters)
		{
		}

		// Token: 0x060318FF RID: 203007 RVA: 0x00C5A368 File Offset: 0x00C58568
		protected override bool SpecialConditionCheck()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance() || !ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.HomeButton))
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.InputDistribute, this.ActionName);
				return false;
			}
			return true;
		}

		// Token: 0x06031900 RID: 203008 RVA: 0x00C5A3A4 File Offset: 0x00C585A4
		protected override bool CheckHasInputLimit()
		{
			return !ControllerBase<GameModeController>.Instance.IsInInstance() && Singleton<LevelEventLockInputState>.Instance.InputLimitView.Contains(this.ViewName.Value);
		}
	}
}
