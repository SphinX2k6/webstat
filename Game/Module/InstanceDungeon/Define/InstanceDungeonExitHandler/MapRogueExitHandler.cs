using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.MapRogue;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C3E RID: 23614
	public class MapRogueExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA87 RID: 244359 RVA: 0x00F1D190 File Offset: 0x00F1B390
		public override bool Checker()
		{
			return ControllerBase<MapRogueController>.Instance.CheckInMapRogueInstance();
		}

		// Token: 0x0603BA88 RID: 244360 RVA: 0x00F1D19C File Offset: 0x00F1B39C
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			ControllerBase<MapRogueController>.Instance.OpenExploreEnd(true);
		}
	}
}
