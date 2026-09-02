using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E9 RID: 24809
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarXigelikaSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603EAC2 RID: 256706 RVA: 0x0100ADC4 File Offset: 0x01008FC4
		public void SwitchKeyItem(SpecialEnergyBarInfo cfg)
		{
			if (cfg != null)
			{
				this.Config = cfg;
				SpecialEnergyBarKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.SetConfig(cfg);
				}
				SpecialEnergyBarKeyItem keyItem2 = this.KeyItem;
				if (keyItem2 != null)
				{
					keyItem2.SwitchToKeyInfoList(this.Config.KeyInfoList);
				}
				base.ClearAllTagCountChangedCallback();
				base.InitKeyEnableTag();
				SpecialEnergyBarKeyItem keyItem3 = this.KeyItem;
				if (keyItem3 == null)
				{
					return;
				}
				keyItem3.RefreshKeyEnable(this.GetKeyEnable(), false);
			}
		}

		// Token: 0x0603EAC3 RID: 256707 RVA: 0x0100AE2C File Offset: 0x0100902C
		public void SetSegmentVisible(int i, bool visible)
		{
			if (0 <= i && i < this.SegmentVisibles.Length && this.SegmentVisibles[i] != visible)
			{
				this.SegmentVisibles[i] = visible;
				this.SlotItemList[i].SetUiActive(visible);
			}
		}

		// Token: 0x04023259 RID: 143961
		private readonly bool[] SegmentVisibles = new bool[]
		{
			true,
			true,
			true,
			true
		};
	}
}
