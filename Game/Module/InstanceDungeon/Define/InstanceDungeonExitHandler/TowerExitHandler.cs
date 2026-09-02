using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C46 RID: 23622
	public class TowerExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BAA3 RID: 244387 RVA: 0x00F1D72D File Offset: 0x00F1B92D
		public override bool Checker()
		{
			return ModelBase<TowerModel>.Instance.CheckInTower();
		}

		// Token: 0x0603BAA4 RID: 244388 RVA: 0x00F1D73C File Offset: 0x00F1B93C
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			TowerExitHandler.<>c__DisplayClass1_0 CS$<>8__locals1 = new TowerExitHandler.<>c__DisplayClass1_0();
			CS$<>8__locals1.data = data;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TowerLeave);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[1] = new Action(CS$<>8__locals1.<HandleExit>g__Leave|1);
			confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<HandleExit>g__ReChallenge|0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}
}
