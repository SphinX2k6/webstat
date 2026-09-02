using System;
using System.Linq;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060D8 RID: 24792
	public class SpecialEnergyBarMoNingSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E9D9 RID: 256473 RVA: 0x010061F8 File Offset: 0x010043F8
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
	}
}
