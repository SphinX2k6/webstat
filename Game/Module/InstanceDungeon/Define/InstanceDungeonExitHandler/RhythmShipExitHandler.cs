using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C41 RID: 23617
	public class RhythmShipExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA90 RID: 244368 RVA: 0x00F1D30C File Offset: 0x00F1B50C
		public override bool Checker()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.Value.InstSubType == 53;
		}

		// Token: 0x0603BA91 RID: 244369 RVA: 0x00F1D35D File Offset: 0x00F1B55D
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipPauseView, null, null);
		}
	}
}
