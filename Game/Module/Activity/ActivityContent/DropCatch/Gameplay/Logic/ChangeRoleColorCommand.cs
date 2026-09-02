using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200692E RID: 26926
	public class ChangeRoleColorCommand : IDropCatchCommand
	{
		// Token: 0x06042D53 RID: 273747 RVA: 0x011274B4 File Offset: 0x011256B4
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IChangeRoleColorCommandParams changeRoleColorCommandParams = (IChangeRoleColorCommandParams)@params;
			DropCatchGameplayView gameplayView = context.GetLogicContext().GetProxy().GetGameplayView();
			if (gameplayView == null)
			{
				return;
			}
			DropCatchGameplayRoleView roleView = gameplayView.GetRoleView();
			if (roleView == null)
			{
				return;
			}
			roleView.SetChangeColor(changeRoleColorCommandParams.UseChangeColor, changeRoleColorCommandParams.HexColor, changeRoleColorCommandParams.Duration);
		}
	}
}
