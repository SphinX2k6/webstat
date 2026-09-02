using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006920 RID: 26912
	public class AddEnergyCommand : IDropCatchCommand
	{
		// Token: 0x06042D37 RID: 273719 RVA: 0x01126F24 File Offset: 0x01125124
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IAddEnergyCommandParams addEnergyCommandParams = (IAddEnergyCommandParams)@params;
			IRoleInstance role = context.GetLogicContext().GetGameplayRoleMgr().GetRole();
			if (role == null)
			{
				return;
			}
			role.AddEnergy(addEnergyCommandParams.Energy, addEnergyCommandParams.IsCalRate);
		}
	}
}
