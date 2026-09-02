using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060BC RID: 24764
	public class SpecialEnergyBarJiaBeiLiNaMorphSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E8A7 RID: 256167 RVA: 0x00FFE478 File Offset: 0x00FFC678
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			this.SlotItemList[0].UpdatePercentWithFullEffect(curPercent, curPercent, isStart);
		}
	}
}
