using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060C3 RID: 24771
	public class SpecialEnergyBarKanTeLeiLaSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E900 RID: 256256 RVA: 0x010007EC File Offset: 0x00FFE9EC
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			bool fullEffectEnable = !this.FullEffectForceDisable && keyEnable;
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				this.SlotItemList[i].UpdatePercent(curPercent * (float)this.SlotNum - (float)i, fullEffectEnable, false);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x04023130 RID: 143664
		public bool FullEffectForceDisable;
	}
}
