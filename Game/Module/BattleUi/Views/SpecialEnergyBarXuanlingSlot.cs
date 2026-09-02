using System;
using System.Collections.Generic;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060EC RID: 24812
	public class SpecialEnergyBarXuanlingSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603EAF1 RID: 256753 RVA: 0x0100C082 File Offset: 0x0100A282
		protected override void OnStart()
		{
			this.OverrideColor = true;
			base.SetUseEffectMode(EUseEffectMode.EnergyDecreaseSegment);
			base.OnStart();
		}

		// Token: 0x0603EAF2 RID: 256754 RVA: 0x0100C098 File Offset: 0x0100A298
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarSlotItem specialEnergyBarSlotItem = this.SlotItemList[i];
				float percent = Math.Max(0f, Math.Min(1f, curPercent));
				float discreteEffectPercent = this.GetDiscreteEffectPercent(percent);
				specialEnergyBarSlotItem.UpdatePercentWithFullEffect(discreteEffectPercent, discreteEffectPercent, isStart);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(this.GetKeyEnable(), isStart);
		}

		// Token: 0x0603EAF3 RID: 256755 RVA: 0x0100C110 File Offset: 0x0100A310
		private float GetDiscreteEffectPercent(float percent)
		{
			return (float)Math.Ceiling((double)(Math.Max(0f, Math.Min(1f, percent)) * 41f)) / 41f;
		}

		// Token: 0x0603EAF4 RID: 256756 RVA: 0x0100C13A File Offset: 0x0100A33A
		protected override bool GetKeyEnable()
		{
			if (this.IsSpEnergyFull)
			{
				return base.GetKeyEnable();
			}
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			return ((attributeComponent != null) ? attributeComponent.GetCurrentValue(this.AttributeId) : 0f) > 0f && base.GetKeyEnable();
		}

		// Token: 0x0603EAF5 RID: 256757 RVA: 0x0100C178 File Offset: 0x0100A378
		public void SetKeyActionBySpEnergy(bool isFull, bool isStart = false)
		{
			if (this.IsSpEnergyFull == isFull && !isStart)
			{
				return;
			}
			this.IsSpEnergyFull = isFull;
			int action = (isFull > false) ? 1 : 0;
			List<SpecialEnergyBarKeyInfo> list = new List<SpecialEnergyBarKeyInfo>();
			foreach (SpecialEnergyBarKeyInfo specialEnergyBarKeyInfo in this.Config.KeyInfoList)
			{
				list.Add(new SpecialEnergyBarKeyInfo
				{
					Action = action,
					ActionType = specialEnergyBarKeyInfo.ActionType
				});
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.SwitchToKeyInfoList(list);
			}
			SpecialEnergyBarKeyItem keyItem2 = this.KeyItem;
			if (keyItem2 == null)
			{
				return;
			}
			keyItem2.RefreshKeyEnable(this.GetKeyEnable(), isStart);
		}

		// Token: 0x04023279 RID: 143993
		private const int KEY_ACTION_SP_ENERGY_NOT_FULL = 0;

		// Token: 0x0402327A RID: 143994
		private const int KEY_ACTION_SP_ENERGY_FULL = 1;

		// Token: 0x0402327B RID: 143995
		private const int TOTAL_EFFECT_POINT_NUM = 41;

		// Token: 0x0402327C RID: 143996
		private bool IsSpEnergyFull;
	}
}
