using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060B4 RID: 24756
	public class SpecialEnergyBarDaniyaSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E81F RID: 256031 RVA: 0x00FFB14E File Offset: 0x00FF934E
		protected override bool GetKeyEnable()
		{
			return this.IsKeyEnable;
		}

		// Token: 0x0603E820 RID: 256032 RVA: 0x00FFB156 File Offset: 0x00FF9356
		public void RefreshSlotKeyEnable(bool enable, bool bForce = false)
		{
			if (enable != this.IsKeyEnable || bForce)
			{
				this.IsKeyEnable = enable;
				SpecialEnergyBarKeyItem keyItem = this.KeyItem;
				if (keyItem == null)
				{
					return;
				}
				keyItem.RefreshKeyEnable(enable, bForce);
			}
		}

		// Token: 0x0603E821 RID: 256033 RVA: 0x00FFB184 File Offset: 0x00FF9384
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarSlotItem specialEnergyBarSlotItem = this.SlotItemList[i];
				float num = curPercent * (float)this.SlotNum - (float)i;
				if (this.StateA)
				{
					specialEnergyBarSlotItem.UpdatePercent(num, curPercent >= 1f, false);
					specialEnergyBarSlotItem.SetBarPercent(num);
				}
				else
				{
					specialEnergyBarSlotItem.UpdatePercentWithFullEffect(num, num % 1.001f * 0.41f, false);
					specialEnergyBarSlotItem.UpdatePercent(num, false, false);
				}
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x04023097 RID: 143511
		public bool StateA;

		// Token: 0x04023098 RID: 143512
		private bool IsKeyEnable;
	}
}
