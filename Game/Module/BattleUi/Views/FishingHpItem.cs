using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006009 RID: 24585
	public class FishingHpItem : UiPanelBase
	{
		// Token: 0x0603DEDA RID: 253658 RVA: 0x00FCC238 File Offset: 0x00FCA438
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DEDB RID: 253659 RVA: 0x00FCC2A1 File Offset: 0x00FCA4A1
		public void SetHpVisible(bool bVisible)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(bVisible);
		}

		// Token: 0x0200C0A1 RID: 49313
		private enum EChildType
		{
			// Token: 0x0403B4EB RID: 242923
			HpSprite,
			// Token: 0x0403B4EC RID: 242924
			BgItem
		}
	}
}
