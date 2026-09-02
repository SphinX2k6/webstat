using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F0 RID: 24816
	public class SpecialEnergyBarZanniSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603EB21 RID: 256801 RVA: 0x0100D0C0 File Offset: 0x0100B2C0
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			if (!this.FullEffectWhenEnable)
			{
				base.RefreshBarPercent(isStart);
				int state = 0;
				if (curPercent <= 0f)
				{
					state = -1;
				}
				else if (curPercent >= 1f)
				{
					state = 1;
				}
				this.SetState(state, isStart);
				return;
			}
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarSlotItem specialEnergyBarSlotItem = this.SlotItemList[i];
				float percent = curPercent * (float)this.SlotNum - (float)i;
				specialEnergyBarSlotItem.UpdatePercentWithFullEffectEnable(percent, keyEnable, isStart);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0603EB22 RID: 256802 RVA: 0x0100D160 File Offset: 0x0100B360
		private void SetState(int state, bool isStart = false)
		{
			if (this.State == state && !isStart)
			{
				return;
			}
			this.State = state;
			UUIItem bottomLineLight = this.BottomLineLight;
			if (bottomLineLight != null)
			{
				bottomLineLight.SetUIActive(this.State == 1);
			}
			foreach (UUIItem uuiitem in this.DarkItemList)
			{
				uuiitem.SetUIActive(this.State != -1);
			}
		}

		// Token: 0x04023296 RID: 144022
		[Nullable(2)]
		public UUIItem BottomLineLight;

		// Token: 0x04023297 RID: 144023
		[Nullable(1)]
		public readonly List<UUIItem> DarkItemList = new List<UUIItem>();

		// Token: 0x04023298 RID: 144024
		public bool FullEffectWhenEnable;

		// Token: 0x04023299 RID: 144025
		private int State;
	}
}
