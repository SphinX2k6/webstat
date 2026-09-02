using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E2 RID: 24802
	public class SpecialEnergyBarSuisuiEnhancedStateSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603EA7A RID: 256634 RVA: 0x01009B24 File Offset: 0x01007D24
		protected override void OnStart()
		{
			base.OnStart();
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.SetFullEffectPercent(1f);
			}
		}
	}
}
