using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200692D RID: 26925
	public class ShowFloatEffCommand : IDropCatchCommand
	{
		// Token: 0x06042D51 RID: 273745 RVA: 0x0112743C File Offset: 0x0112563C
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IShowFloatEffCommandParams showFloatEffCommandParams = (IShowFloatEffCommandParams)@params;
			DropCatchGameplayView gameplayView = context.GetLogicContext().GetProxy().GetGameplayView();
			if (gameplayView == null)
			{
				return;
			}
			gameplayView.CreateFloatEffView(showFloatEffCommandParams.Icon, (showFloatEffCommandParams.Score != null) ? new float?(showFloatEffCommandParams.Score.Value * context.GetLogicContext().GetAddScoreRateAttr().GetFinalValue()) : null);
		}
	}
}
