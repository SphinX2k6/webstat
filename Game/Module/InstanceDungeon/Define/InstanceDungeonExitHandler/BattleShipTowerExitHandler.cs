using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C32 RID: 23602
	public class BattleShipTowerExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA64 RID: 244324 RVA: 0x00F1C967 File Offset: 0x00F1AB67
		public override bool Checker()
		{
			return ModelBase<ShipTowerModel>.Instance.CheckInBattleShipTower();
		}

		// Token: 0x0603BA65 RID: 244325 RVA: 0x00F1C974 File Offset: 0x00F1AB74
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			BattleShipTowerExitHandler.<>c__DisplayClass1_0 CS$<>8__locals1 = new BattleShipTowerExitHandler.<>c__DisplayClass1_0();
			CS$<>8__locals1.data = data;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ShipTowerLeaveInstance);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[1] = new Action(CS$<>8__locals1.<HandleExit>g__Leave|1);
			confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<HandleExit>g__ReChallenge|0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}
}
