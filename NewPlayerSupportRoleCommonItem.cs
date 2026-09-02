using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001478 RID: 5240
public class NewPlayerSupportRoleCommonItem : NewPlayerSupportRoleBaseItem
{
	// Token: 0x060092B0 RID: 37552 RVA: 0x0026B264 File Offset: 0x00269464
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060092B1 RID: 37553 RVA: 0x0026B330 File Offset: 0x00269530
	public override void Refresh()
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(3);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		base.SetTextureByPath(this.TrialRoleInfo.Value.ContentTexturePath, base.GetTexture(4), null, null);
	}

	// Token: 0x02007885 RID: 30853
	private class EComponentType
	{
		// Token: 0x04029723 RID: 169763
		public const int ContentTexture = 0;

		// Token: 0x04029724 RID: 169764
		public const int DescItem1 = 1;

		// Token: 0x04029725 RID: 169765
		public const int DescItem2 = 2;

		// Token: 0x04029726 RID: 169766
		public const int DescItem3 = 3;

		// Token: 0x04029727 RID: 169767
		public const int ThemeTextTexture = 4;
	}
}
