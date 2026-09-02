using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060B8 RID: 24760
	public class SpecialEnergyBarFeibiSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E864 RID: 256100 RVA: 0x00FFC9A4 File Offset: 0x00FFABA4
		protected override void OnStart()
		{
			SpecialEnergyBarInfo config = this.Config;
			if (!string.IsNullOrEmpty((config != null) ? config.EffectColor : null))
			{
				FColor fcolor = FColor.FromHex(this.Config.EffectColor);
				FLinearColor flinearColor = new FLinearColor(ref fcolor);
				foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
				{
					specialEnergyBarSlotItem.SetBarColor(fcolor);
					specialEnergyBarSlotItem.SetChangeEffectColor(flinearColor);
				}
			}
			base.OnStart();
		}

		// Token: 0x0603E865 RID: 256101 RVA: 0x00FFCA38 File Offset: 0x00FFAC38
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarSlotItem specialEnergyBarSlotItem = this.SlotItemList[i];
				float num = MathF.Floor((2f * curPercent - (float)i) * 19f) / 19f;
				num = MathF.Max(num, 0f);
				num = MathF.Min(num, 1f);
				float num2 = num * 0.46341464f;
				specialEnergyBarSlotItem.UpdatePercentWithFullEffect(num, num2, isStart);
				if (this.LastPercent[i] > num2 && !isStart)
				{
					specialEnergyBarSlotItem.SetChangeEffectOffsetX(184.5f + 369f * num2);
					specialEnergyBarSlotItem.PlayChangeEffectWithPercent(this.LastPercent[i] - num2);
				}
				this.LastPercent[i] = num2;
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x040230C1 RID: 143553
		private const float EFFECT_BASE_PERCENT = 0.46341464f;

		// Token: 0x040230C2 RID: 143554
		private const int TOTAL_POINT_NUM = 19;

		// Token: 0x040230C3 RID: 143555
		private const float CHANGE_EFFECT_OFFSET_X = 184.5f;

		// Token: 0x040230C4 RID: 143556
		private const float CHANGE_EFFECT_WIDTH = 369f;

		// Token: 0x040230C5 RID: 143557
		[Nullable(1)]
		private readonly float[] LastPercent = new float[2];
	}
}
