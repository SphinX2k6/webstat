using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060CB RID: 24779
	public class SpecialEnergyBarLinNaiSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E963 RID: 256355 RVA: 0x01003AB4 File Offset: 0x01001CB4
		public void SwitchPointColor(bool enhanced)
		{
			SpecialEnergyBarInfo config = this.Config;
			string text;
			if (config == null)
			{
				text = null;
			}
			else
			{
				string[] pointColorList = config.PointColorList;
				text = ((pointColorList != null) ? pointColorList.ElementAtOrDefault((enhanced > false) ? 1 : 0) : null);
			}
			FColor fcolor = FColor.FromHex(text ?? "ffffff");
			this.SlotItemList[0].SetPointColor(fcolor);
		}

		// Token: 0x0603E964 RID: 256356 RVA: 0x01003B08 File Offset: 0x01001D08
		[NullableContext(2)]
		public void SwitchKeyItem(SpecialEnergyBarInfo cfg, bool pureHotkey = false)
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
			}
			if (pureHotkey)
			{
				UUIItem item = base.GetItem(0);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(1);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				UUIItem item3 = base.GetItem(2);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(false);
				return;
			}
			else
			{
				UUIItem item4 = base.GetItem(0);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				UUIItem item5 = base.GetItem(1);
				if (item5 != null)
				{
					item5.SetUIActive(true);
				}
				UUIItem item6 = base.GetItem(2);
				if (item6 == null)
				{
					return;
				}
				item6.SetUIActive(true);
				return;
			}
		}

		// Token: 0x0603E965 RID: 256357 RVA: 0x01003BC1 File Offset: 0x01001DC1
		protected override bool GetKeyEnable()
		{
			SpecialEnergyBarLinNai ownerLogic = this.OwnerLogic;
			return ownerLogic != null && ownerLogic.Internal_GetKeyEnable();
		}

		// Token: 0x0603E966 RID: 256358 RVA: 0x01003BD4 File Offset: 0x01001DD4
		public void RefreshKeyEnable(bool enable, bool bForce)
		{
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(enable, bForce);
		}

		// Token: 0x04023188 RID: 143752
		[Nullable(2)]
		public SpecialEnergyBarLinNai OwnerLogic;

		// Token: 0x0200C20E RID: 49678
		private enum EChildType
		{
			// Token: 0x0403BCC5 RID: 244933
			PnlSlot,
			// Token: 0x0403BCC6 RID: 244934
			PnlHotKey,
			// Token: 0x0403BCC7 RID: 244935
			SprDesc
		}
	}
}
