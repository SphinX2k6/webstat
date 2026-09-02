using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BossPiling;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C33 RID: 23603
	public class BossPilingExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA67 RID: 244327 RVA: 0x00F1C9E4 File Offset: 0x00F1ABE4
		public override bool Checker()
		{
			return ModelBase<BossPilingModel>.Instance.CheckIsBossPiling();
		}

		// Token: 0x0603BA68 RID: 244328 RVA: 0x00F1C9F0 File Offset: 0x00F1ABF0
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			ControllerBase<BossPilingController>.Instance.OpenPauseView();
		}
	}
}
