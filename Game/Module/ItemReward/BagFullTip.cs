using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B43 RID: 23363
	public class BagFullTip : UiPanelBase
	{
		// Token: 0x0603B181 RID: 242049 RVA: 0x00EF3BC4 File Offset: 0x00EF1DC4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B182 RID: 242050 RVA: 0x00EF3C0C File Offset: 0x00EF1E0C
		public void SetAdjustPanelVisible(bool isShow)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isShow);
		}

		// Token: 0x0200BB29 RID: 47913
		private class EChildType
		{
			// Token: 0x04039C2D RID: 236589
			public const int ItemAdjustPanel = 0;
		}
	}
}
