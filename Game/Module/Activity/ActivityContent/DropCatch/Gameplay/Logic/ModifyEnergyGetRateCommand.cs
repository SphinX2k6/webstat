using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200692B RID: 26923
	public class ModifyEnergyGetRateCommand : IDropCatchCommand
	{
		// Token: 0x06042D4D RID: 273741 RVA: 0x01127384 File Offset: 0x01125584
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IModifyEnergyGetRateCommandParams modifyEnergyGetRateCommandParams = (IModifyEnergyGetRateCommandParams)@params;
			DropCatchGameplayAttribute energyGetRateAttr = context.GetLogicContext().GetEnergyGetRateAttr();
			context.GetLogicContext().GetGameplayModifierMgr().AddModifierToAttr(energyGetRateAttr, modifyEnergyGetRateCommandParams.Type, modifyEnergyGetRateCommandParams.Value, modifyEnergyGetRateCommandParams.Duration);
		}
	}
}
