using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060B1 RID: 24753
	public class SpecialEnergyBarBuLingSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E800 RID: 256000 RVA: 0x00FFA2F8 File Offset: 0x00FF84F8
		protected override void OnStart()
		{
			this.OverrideColor = false;
			SpecialEnergyBarInfo config = this.Config;
			if (!string.IsNullOrEmpty((config != null) ? config.EffectColor : null))
			{
				this.SetColor(0, this.Config.EffectColor, this.Config.PointColor);
				this.SetColor(1, this.Config.OtherEffectColorList[0], this.Config.PointColorList[1]);
			}
			base.OnStart();
		}

		// Token: 0x0603E801 RID: 256001 RVA: 0x00FFA370 File Offset: 0x00FF8570
		[NullableContext(1)]
		private void SetColor(int index, string effectColorStr, string pointColorStr)
		{
			FColor fcolor = FColor.FromHex(effectColorStr);
			FLinearColor flinearColor = new FLinearColor(ref fcolor);
			FColor fcolor2 = FColor.FromHex(pointColorStr);
			this.SlotItemList[index].SetBarColor(fcolor);
			this.SlotItemList[index].SetPointColor(fcolor2);
			this.SlotItemList[index].SetFullEffectColor(flinearColor, false);
		}

		// Token: 0x0603E802 RID: 256002 RVA: 0x00FFA3CD File Offset: 0x00FF85CD
		public void SetState(bool leftState, bool rightState)
		{
			this.LeftState = leftState;
			this.RightState = rightState;
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E803 RID: 256003 RVA: 0x00FFA3E4 File Offset: 0x00FF85E4
		protected override void RefreshBarPercent(bool isStart = false)
		{
			bool enable = this.LeftState && this.RightState;
			this.SlotItemList[0].UpdatePercent(this.LeftState ? 1f : 0f, false, false);
			this.SlotItemList[1].UpdatePercent(this.RightState ? 1f : 0f, false, false);
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(enable, isStart);
		}

		// Token: 0x04023088 RID: 143496
		private bool LeftState;

		// Token: 0x04023089 RID: 143497
		private bool RightState;
	}
}
