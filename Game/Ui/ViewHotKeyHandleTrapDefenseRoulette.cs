using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A1A RID: 18970
	public class ViewHotKeyHandleTrapDefenseRoulette : ViewHotKeyHandleRoulette
	{
		// Token: 0x06031913 RID: 203027 RVA: 0x00C5A732 File Offset: 0x00C58932
		[NullableContext(1)]
		public ViewHotKeyHandleTrapDefenseRoulette(IOpenAndCloseViewHotKey parameters) : base(parameters)
		{
		}

		// Token: 0x06031914 RID: 203028 RVA: 0x00C5A73C File Offset: 0x00C5893C
		protected override void OnOpenViewImplement()
		{
			TrapDefenseRouletteMainViewProxy trapDefenseRouletteMainViewProxy = new TrapDefenseRouletteMainViewProxy();
			trapDefenseRouletteMainViewProxy.ActionType = (ERouletteActionType)Convert.ToInt32(this.ViewParam[0]);
			ControllerBase<RouletteController>.Instance.OpenRouletteMainView(trapDefenseRouletteMainViewProxy);
		}
	}
}
