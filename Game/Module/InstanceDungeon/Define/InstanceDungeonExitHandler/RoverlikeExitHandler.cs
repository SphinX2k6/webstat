using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C44 RID: 23620
	public class RoverlikeExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA9D RID: 244381 RVA: 0x00F1D634 File Offset: 0x00F1B834
		public override bool Checker()
		{
			return ControllerBase<RoverlikeController>.Instance.CheckInRoverlike();
		}

		// Token: 0x0603BA9E RID: 244382 RVA: 0x00F1D640 File Offset: 0x00F1B840
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikePauseView, null, null);
		}
	}
}
