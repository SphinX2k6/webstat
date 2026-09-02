using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006931 RID: 26929
	public class SetInputEnabledCommand : IDropCatchCommand
	{
		// Token: 0x06042D59 RID: 273753 RVA: 0x01127574 File Offset: 0x01125774
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			ISetInputEnabledCommandParams setInputEnabledCommandParams = (ISetInputEnabledCommandParams)@params;
			DropCatchGameplayView gameplayView = context.GetLogicContext().GetProxy().GetGameplayView();
			if (gameplayView == null)
			{
				return;
			}
			DropCatchGameplayJoystickView joystickView = gameplayView.GetJoystickView();
			if (joystickView == null)
			{
				return;
			}
			joystickView.SetInputEnabled(setInputEnabledCommandParams.Enabled);
		}
	}
}
