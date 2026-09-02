using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006926 RID: 26918
	public class ConvertDropItemCommand : IDropCatchCommand
	{
		// Token: 0x06042D43 RID: 273731 RVA: 0x01127054 File Offset: 0x01125254
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IConvertDropItemCommandParams convertDropItemCommandParams = (IConvertDropItemCommandParams)@params;
			context.GetLogicContext().GetGameplayDropItemMgr().ConvertDropItem(convertDropItemCommandParams.SourceItemId, convertDropItemCommandParams.TargetItemId, convertDropItemCommandParams.Duration);
		}
	}
}
