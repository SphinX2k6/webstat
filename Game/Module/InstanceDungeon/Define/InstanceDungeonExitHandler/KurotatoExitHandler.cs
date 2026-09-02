using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C3A RID: 23610
	public class KurotatoExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA78 RID: 244344 RVA: 0x00F1CCE4 File Offset: 0x00F1AEE4
		public override bool Checker()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.Value.InstSubType == 51;
		}

		// Token: 0x0603BA79 RID: 244345 RVA: 0x00F1CD35 File Offset: 0x00F1AF35
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPauseView, null, null);
		}
	}
}
