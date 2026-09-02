using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C3F RID: 23615
	public class MotorFightExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA8A RID: 244362 RVA: 0x00F1D1B4 File Offset: 0x00F1B3B4
		public override bool Checker()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.Value.InstSubType == 44;
		}

		// Token: 0x0603BA8B RID: 244363 RVA: 0x00F1D205 File Offset: 0x00F1B405
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightPauseView, null, null);
		}
	}
}
