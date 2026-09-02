using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C36 RID: 23606
	public class HonamiStoryExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA70 RID: 244336 RVA: 0x00F1CB2A File Offset: 0x00F1AD2A
		public override bool Checker()
		{
			return HonamiStoryUtil.CheckInHonamiStoryDungeon();
		}

		// Token: 0x0603BA71 RID: 244337 RVA: 0x00F1CB31 File Offset: 0x00F1AD31
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			ControllerBase<HonamiStoryController>.Instance.TryHonamiStoryInstLeave(false);
		}
	}
}
