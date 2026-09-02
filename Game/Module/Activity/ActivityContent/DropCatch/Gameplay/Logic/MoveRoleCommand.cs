using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006927 RID: 26919
	public class MoveRoleCommand : IDropCatchCommand
	{
		// Token: 0x06042D45 RID: 273733 RVA: 0x01127094 File Offset: 0x01125294
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IMoveRoleCommandParams moveRoleCommandParams = (IMoveRoleCommandParams)@params;
			context.GetLogicContext().GetGameplayInputMgr().SetMoveDirectionCommand(moveRoleCommandParams.Direction, moveRoleCommandParams.Duration);
		}
	}
}
