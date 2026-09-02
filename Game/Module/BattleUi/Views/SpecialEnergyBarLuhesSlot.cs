using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060CD RID: 24781
	public class SpecialEnergyBarLuhesSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E977 RID: 256375 RVA: 0x01003EEC File Offset: 0x010020EC
		[NullableContext(2)]
		public void SwitchKeyItem(SpecialEnergyBarInfo cfg)
		{
			if (cfg == null)
			{
				return;
			}
			this.Config = cfg;
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.SetConfig(cfg);
			}
			this.AttributeId = (EAttributeType)cfg.AttributeId;
			this.MaxAttributeId = (EAttributeType)cfg.MaxAttributeId;
			this.RemoveEvents();
			this.AddEvents();
			this.OnAttributeChanged();
			base.ClearAllTagCountChangedCallback();
			base.InitKeyEnableTag();
			SpecialEnergyBarKeyItem keyItem2 = this.KeyItem;
			if (keyItem2 != null)
			{
				keyItem2.SwitchToKeyInfoList(cfg.KeyInfoList);
			}
			SpecialEnergyBarKeyItem keyItem3 = this.KeyItem;
			if (keyItem3 == null)
			{
				return;
			}
			keyItem3.RefreshKeyEnable(this.GetKeyEnable(), false);
		}

		// Token: 0x0603E978 RID: 256376 RVA: 0x01003F7A File Offset: 0x0100217A
		public void SetBarState(bool isAdvance = false)
		{
			this.IsAdvance = isAdvance;
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E979 RID: 256377 RVA: 0x01003F8C File Offset: 0x0100218C
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				this.SlotItemList[i].UpdatePercent(curPercent * (float)this.SlotNum - (float)i, this.IsAdvance, false);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0402318E RID: 143758
		private bool IsAdvance;
	}
}
