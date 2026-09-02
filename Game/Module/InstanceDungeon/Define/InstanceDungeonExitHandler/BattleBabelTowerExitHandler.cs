using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C31 RID: 23601
	public class BattleBabelTowerExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA61 RID: 244321 RVA: 0x00F1C947 File Offset: 0x00F1AB47
		public override bool Checker()
		{
			return ModelBase<BabelTowerModel>.Instance.CheckInBattleBabelTower();
		}

		// Token: 0x0603BA62 RID: 244322 RVA: 0x00F1C953 File Offset: 0x00F1AB53
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			ControllerBase<BabelTowerController>.Instance.OnClickInstanceDungeonExitButton();
		}
	}
}
