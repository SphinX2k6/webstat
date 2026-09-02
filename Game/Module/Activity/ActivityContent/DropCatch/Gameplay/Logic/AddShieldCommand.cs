using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006925 RID: 26917
	public class AddShieldCommand : IDropCatchCommand
	{
		// Token: 0x06042D41 RID: 273729 RVA: 0x01127018 File Offset: 0x01125218
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IAddShieldCommandParams addShieldCommandParams = (IAddShieldCommandParams)@params;
			IRoleInstance role = context.GetLogicContext().GetGameplayRoleMgr().GetRole();
			if (role == null)
			{
				return;
			}
			role.AddShield(addShieldCommandParams.Time);
		}
	}
}
