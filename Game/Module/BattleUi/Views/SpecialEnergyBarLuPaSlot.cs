using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060D4 RID: 24788
	public class SpecialEnergyBarLuPaSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E9AC RID: 256428 RVA: 0x010050C5 File Offset: 0x010032C5
		public void SetTagCount(int tagCount)
		{
			this.TagCount = tagCount;
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E9AD RID: 256429 RVA: 0x010050D8 File Offset: 0x010032D8
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarSlotItem specialEnergyBarSlotItem = this.SlotItemList[i];
				if (i < this.TagCount)
				{
					specialEnergyBarSlotItem.UpdatePercent(curPercent * (float)this.SlotNum - (float)i, false, true);
				}
				else
				{
					specialEnergyBarSlotItem.UpdatePercent(curPercent * (float)this.SlotNum - (float)i, keyEnable, true);
				}
			}
			int num = (int)Math.Floor((double)(curPercent * (float)this.SlotNum));
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable && this.TagCount < num, isStart);
		}

		// Token: 0x040231A9 RID: 143785
		private int TagCount;
	}
}
