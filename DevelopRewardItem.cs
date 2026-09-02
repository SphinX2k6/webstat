using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020019BD RID: 6589
public class DevelopRewardItem : UiPanelBase
{
	// Token: 0x0600BD33 RID: 48435 RVA: 0x003238C0 File Offset: 0x00321AC0
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

	// Token: 0x0600BD34 RID: 48436 RVA: 0x00323929 File Offset: 0x00321B29
	public void SetIsUnlock(bool bUnlock)
	{
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(bUnlock);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(!bUnlock);
	}

	// Token: 0x02007CBE RID: 31934
	private class ELevelItem
	{
		// Token: 0x0402A965 RID: 174437
		public const int Light = 0;

		// Token: 0x0402A966 RID: 174438
		public const int Dark = 1;
	}
}
