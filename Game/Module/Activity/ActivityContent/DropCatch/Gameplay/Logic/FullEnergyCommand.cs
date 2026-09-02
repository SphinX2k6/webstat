using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006921 RID: 26913
	public class FullEnergyCommand : IDropCatchCommand
	{
		// Token: 0x06042D39 RID: 273721 RVA: 0x01126F66 File Offset: 0x01125166
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IRoleInstance role = context.GetLogicContext().GetGameplayRoleMgr().GetRole();
			if (role == null)
			{
				return;
			}
			role.FullEnergy();
		}
	}
}
