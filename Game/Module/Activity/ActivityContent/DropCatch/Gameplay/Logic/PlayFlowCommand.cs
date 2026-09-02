using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006930 RID: 26928
	public class PlayFlowCommand : IDropCatchCommand
	{
		// Token: 0x06042D57 RID: 273751 RVA: 0x01127538 File Offset: 0x01125738
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IPlayFlowCommandParams playFlowCommandParams = (IPlayFlowCommandParams)@params;
			context.GetLogicContext().GetProxy().PlayFlow(playFlowCommandParams.FlowId.Split(',', StringSplitOptions.None));
		}
	}
}
