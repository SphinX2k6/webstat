using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020019AF RID: 6575
public class MediumItemGridBuffIconComponent : MediumItemGridComponent
{
	// Token: 0x0600BCEF RID: 48367 RVA: 0x00322E18 File Offset: 0x00321018
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BCF0 RID: 48368 RVA: 0x00322E60 File Offset: 0x00321060
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemType";
	}

	// Token: 0x0600BCF1 RID: 48369 RVA: 0x00322E68 File Offset: 0x00321068
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (!(data is EMediumItemGridBuffType))
		{
			this.SetActive(false);
			return;
		}
		EMediumItemGridBuffType emediumItemGridBuffType = (EMediumItemGridBuffType)data;
		string text = null;
		MediumItemGridModel instance = ModelBase<MediumItemGridModel>.Instance;
		switch (emediumItemGridBuffType)
		{
		case EMediumItemGridBuffType.Attack:
			text = instance.AttackBuffSpritePath;
			break;
		case EMediumItemGridBuffType.Defense:
			text = instance.DefenseBuffSpritePath;
			break;
		case EMediumItemGridBuffType.RestoreHealth:
			text = instance.RestoreHealthBuffSpritePath;
			break;
		case EMediumItemGridBuffType.Recharge:
			text = instance.RechargeBuffSpritePath;
			break;
		case EMediumItemGridBuffType.Resurrection:
			text = instance.ResurrectionBuffSpritePath;
			break;
		case EMediumItemGridBuffType.Explore:
			text = instance.ExploreBuffSpritePath;
			break;
		}
		if (string.IsNullOrEmpty(text))
		{
			this.SetActive(false);
			return;
		}
		UUISprite sprite = base.GetSprite(0);
		this.SetSpriteByPath(text, sprite, false, null, null);
		this.SetActive(true);
	}

	// Token: 0x02007CB7 RID: 31927
	private class EChildType
	{
		// Token: 0x0402A955 RID: 174421
		public const int BuffTypeSprite = 0;
	}
}
