using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006923 RID: 26915
	public class CrazyModeCommand : IDropCatchCommand
	{
		// Token: 0x06042D3D RID: 273725 RVA: 0x01126FBF File Offset: 0x011251BF
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			DropCatchGameplayView gameplayView = context.GetLogicContext().GetProxy().GetGameplayView();
			if (gameplayView == null)
			{
				return;
			}
			gameplayView.RefreshCrazyMode(true);
		}
	}
}
