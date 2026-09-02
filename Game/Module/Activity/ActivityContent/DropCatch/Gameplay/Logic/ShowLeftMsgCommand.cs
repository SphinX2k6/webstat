using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200692C RID: 26924
	public class ShowLeftMsgCommand : IDropCatchCommand
	{
		// Token: 0x06042D4F RID: 273743 RVA: 0x011273D0 File Offset: 0x011255D0
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IShowLeftMsgCommandParams showLeftMsgCommandParams = (IShowLeftMsgCommandParams)@params;
			DropCatchGameplayView gameplayView = context.GetLogicContext().GetProxy().GetGameplayView();
			if (gameplayView == null)
			{
				return;
			}
			gameplayView.ShowMsgView(new IDropCatchGameplayLeftMsgParams
			{
				Type = showLeftMsgCommandParams.Type,
				Icon = showLeftMsgCommandParams.Icon,
				TextId = showLeftMsgCommandParams.TextId,
				Duration = showLeftMsgCommandParams.Duration
			});
		}
	}
}
