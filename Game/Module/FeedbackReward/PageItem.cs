using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FeedbackReward
{
	// Token: 0x02005D8A RID: 23946
	public class PageItem : UiPanelBase
	{
		// Token: 0x0603C4BA RID: 246970 RVA: 0x00F4D40C File Offset: 0x00F4B60C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C4BB RID: 246971 RVA: 0x00F4D475 File Offset: 0x00F4B675
		public void RefreshItem(bool isShow)
		{
			base.GetItem(1).SetUIActive(isShow);
		}

		// Token: 0x0200BDBE RID: 48574
		private enum EPageItem
		{
			// Token: 0x0403A6EE RID: 239342
			BgItem,
			// Token: 0x0403A6EF RID: 239343
			ShowItem
		}
	}
}
