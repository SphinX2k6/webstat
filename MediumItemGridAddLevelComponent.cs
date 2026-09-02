using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019AC RID: 6572
public class MediumItemGridAddLevelComponent : MediumItemGridComponent
{
	// Token: 0x0600BCE6 RID: 48358 RVA: 0x00322D2C File Offset: 0x00320F2C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BCE7 RID: 48359 RVA: 0x00322D95 File Offset: 0x00320F95
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRogueRoleType";
	}

	// Token: 0x0600BCE8 RID: 48360 RVA: 0x00322D9C File Offset: 0x00320F9C
	[NullableContext(2)]
	protected override void OnRefresh(object @params = null)
	{
		if (!(@params is int))
		{
			return;
		}
		int num = (int)@params;
		if (num == 0)
		{
			this.SetActive(false);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_LevelShow_Text", new <>z__ReadOnlySingleElementList<object>(num));
		this.SetActive(true);
	}

	// Token: 0x02007CB6 RID: 31926
	private class EAddLevelComponentDefine
	{
		// Token: 0x0402A953 RID: 174419
		public const int TextureIcon = 0;

		// Token: 0x0402A954 RID: 174420
		public const int TxtLevel = 1;
	}
}
