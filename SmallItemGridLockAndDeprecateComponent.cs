using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A29 RID: 6697
public class SmallItemGridLockAndDeprecateComponent : SmallItemGridComponent
{
	// Token: 0x0600C011 RID: 49169 RVA: 0x0032C5D6 File Offset: 0x0032A7D6
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_InventoryItemState";
	}

	// Token: 0x0600C012 RID: 49170 RVA: 0x0032C5E0 File Offset: 0x0032A7E0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C013 RID: 49171 RVA: 0x0032C64C File Offset: 0x0032A84C
	[NullableContext(2)]
	protected override void OnRefresh(object tempData)
	{
		ISmallItemGridLockAndDeprecate smallItemGridLockAndDeprecate = (ISmallItemGridLockAndDeprecate)tempData;
		bool valueOrDefault = smallItemGridLockAndDeprecate.IsLock.GetValueOrDefault();
		bool valueOrDefault2 = smallItemGridLockAndDeprecate.IsDeprecate.GetValueOrDefault();
		base.GetSprite(0).SetUIActive(valueOrDefault);
		base.GetSprite(1).SetUIActive(valueOrDefault2);
		this.SetActive(valueOrDefault || valueOrDefault2);
	}

	// Token: 0x02007CFE RID: 31998
	private enum EComponent
	{
		// Token: 0x0402AA19 RID: 174617
		SpriteLock,
		// Token: 0x0402AA1A RID: 174618
		SpriteDeprecate
	}
}
