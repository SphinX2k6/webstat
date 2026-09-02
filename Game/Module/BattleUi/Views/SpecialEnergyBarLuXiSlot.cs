using System;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060D6 RID: 24790
	public class SpecialEnergyBarLuXiSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E9C8 RID: 256456 RVA: 0x01005CF9 File Offset: 0x01003EF9
		protected override void OnStart()
		{
			if (this.ColorState >= 0)
			{
				this.OverrideColor = true;
			}
			base.OnStart();
		}

		// Token: 0x0603E9C9 RID: 256457 RVA: 0x01005D14 File Offset: 0x01003F14
		protected override void RefreshBarPercent(bool isStart = false)
		{
			if (!this.ForbidFullEffect)
			{
				base.RefreshBarPercent(isStart);
				return;
			}
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				this.SlotItemList[i].UpdatePercent(curPercent * (float)this.SlotNum - (float)i, false, false);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0603E9CA RID: 256458 RVA: 0x01005D8C File Offset: 0x01003F8C
		public void SetColorState(int state)
		{
			if (this.ColorState == state)
			{
				return;
			}
			this.ColorState = state;
			if (this.Config == null)
			{
				return;
			}
			string hexStr = (state == 0) ? this.Config.EffectColor : this.Config.OtherEffectColorList[state - 1];
			string hexStr2 = this.Config.PointColorList[state];
			FColor fcolor = FColor.FromHex(hexStr);
			FColor fcolor2 = fcolor;
			if (!string.IsNullOrEmpty(this.Config.PointColor))
			{
				fcolor2 = FColor.FromHex(hexStr2);
			}
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.SetBarColor(fcolor);
				specialEnergyBarSlotItem.SetPointColor(fcolor2);
			}
		}

		// Token: 0x040231C5 RID: 143813
		private int ColorState = -1;

		// Token: 0x040231C6 RID: 143814
		public bool ForbidFullEffect;
	}
}
