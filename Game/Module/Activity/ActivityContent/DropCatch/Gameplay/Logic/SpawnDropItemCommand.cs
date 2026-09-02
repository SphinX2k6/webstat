using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200691F RID: 26911
	public class SpawnDropItemCommand : IDropCatchCommand
	{
		// Token: 0x06042D35 RID: 273717 RVA: 0x01126EE0 File Offset: 0x011250E0
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			ISpawnDropItemCommandParams spawnDropItemCommandParams = (ISpawnDropItemCommandParams)@params;
			context.GetLogicContext().GetGameplayDropItemMgr().SpawnDropItem(spawnDropItemCommandParams.ItemId, (double)spawnDropItemCommandParams.PosX, null);
		}
	}
}
