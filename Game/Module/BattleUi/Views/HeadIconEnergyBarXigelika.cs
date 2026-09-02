using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006023 RID: 24611
	public class HeadIconEnergyBarXigelika : HeadIconEnergyBarBase
	{
		// Token: 0x0603E057 RID: 254039 RVA: 0x00FD39B4 File Offset: 0x00FD1BB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E058 RID: 254040 RVA: 0x00FD3A3E File Offset: 0x00FD1C3E
		protected override void OnStart()
		{
			base.OnStart();
			base.GetSprite(1).SetUIActive(true);
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603E059 RID: 254041 RVA: 0x00FD3A5A File Offset: 0x00FD1C5A
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E05A RID: 254042 RVA: 0x00FD3A64 File Offset: 0x00FD1C64
		private void RefreshBarPercent(bool bForce = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool flag = curPercent <= 0.5f;
			float fillAmount = flag ? (curPercent * 2f) : ((curPercent - 0.5f) * 2f);
			base.GetSprite(2).SetUIActive(!flag);
			if (flag)
			{
				base.GetSprite(1).SetFillAmount(fillAmount);
				return;
			}
			base.GetSprite(1).SetFillAmount(1f);
			base.GetSprite(2).SetFillAmount(fillAmount);
		}

		// Token: 0x0200C0D3 RID: 49363
		private enum EChildType
		{
			// Token: 0x0403B5E1 RID: 243169
			PnlBar,
			// Token: 0x0403B5E2 RID: 243170
			SprBar1,
			// Token: 0x0403B5E3 RID: 243171
			SprBar2
		}
	}
}
