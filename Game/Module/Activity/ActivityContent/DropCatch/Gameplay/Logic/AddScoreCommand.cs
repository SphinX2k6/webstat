using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006922 RID: 26914
	public class AddScoreCommand : IDropCatchCommand
	{
		// Token: 0x06042D3B RID: 273723 RVA: 0x01126F8C File Offset: 0x0112518C
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IAddScoreCommandParams addScoreCommandParams = (IAddScoreCommandParams)@params;
			context.GetLogicContext().GetProxy().AddScore((float)addScoreCommandParams.Score);
		}
	}
}
