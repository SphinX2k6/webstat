using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006924 RID: 26916
	public class AddTimeCommand : IDropCatchCommand
	{
		// Token: 0x06042D3F RID: 273727 RVA: 0x01126FE4 File Offset: 0x011251E4
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IAddTimeCommandParams addTimeCommandParams = (IAddTimeCommandParams)@params;
			context.GetLogicContext().GetGameplayTimeMgr().AddTime(addTimeCommandParams.Time);
		}
	}
}
