using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060D1 RID: 24785
	public class SpecialEnergyBarLuoselaSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E990 RID: 256400 RVA: 0x0100473C File Offset: 0x0100293C
		protected override void OnStart()
		{
			base.OnStart();
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				SpecialEnergyBarLuoselaSlotItem specialEnergyBarLuoselaSlotItem = specialEnergyBarSlotItem as SpecialEnergyBarLuoselaSlotItem;
				if (specialEnergyBarLuoselaSlotItem != null)
				{
					specialEnergyBarLuoselaSlotItem.SetFullEffectPercent(1f);
				}
			}
		}

		// Token: 0x0603E991 RID: 256401 RVA: 0x010047A4 File Offset: 0x010029A4
		[NullableContext(1)]
		protected override UniTask InitSlotItem(UUIItem slotItem)
		{
			SpecialEnergyBarLuoselaSlot.<InitSlotItem>d__3 <InitSlotItem>d__;
			<InitSlotItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSlotItem>d__.<>4__this = this;
			<InitSlotItem>d__.slotItem = slotItem;
			<InitSlotItem>d__.<>1__state = -1;
			<InitSlotItem>d__.<>t__builder.Start<SpecialEnergyBarLuoselaSlot.<InitSlotItem>d__3>(ref <InitSlotItem>d__);
			return <InitSlotItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E992 RID: 256402 RVA: 0x010047F0 File Offset: 0x010029F0
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
			FLinearColor flinearColor = FLinearColor.FromSRGBColor(fcolor);
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.SetPointColor(fcolor);
				specialEnergyBarSlotItem.SetBarColor(fcolor);
				specialEnergyBarSlotItem.SetFullEffectColor(flinearColor, false);
			}
		}

		// Token: 0x0603E993 RID: 256403 RVA: 0x0100488C File Offset: 0x01002A8C
		[NullableContext(2)]
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
				if (keyItem2 == null)
				{
					return;
				}
				keyItem2.SwitchToKeyInfoList(this.Config.KeyInfoList);
			}
		}

		// Token: 0x0603E994 RID: 256404 RVA: 0x010048C8 File Offset: 0x01002AC8
		public void SetSlotUlt(bool b)
		{
			if (this.IsUlt == b)
			{
				return;
			}
			this.IsUlt = b;
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarLuoselaSlotItem specialEnergyBarLuoselaSlotItem = this.SlotItemList[i] as SpecialEnergyBarLuoselaSlotItem;
				if (specialEnergyBarLuoselaSlotItem != null)
				{
					specialEnergyBarLuoselaSlotItem.SetSlotItemUlt(b, i <= this.PointIndex);
				}
			}
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E995 RID: 256405 RVA: 0x0100492C File Offset: 0x01002B2C
		public void SetSlotPoint(int pointIndex)
		{
			this.PointIndex = pointIndex;
		}

		// Token: 0x0402319E RID: 143774
		private bool IsUlt;

		// Token: 0x0402319F RID: 143775
		private int PointIndex;
	}
}
