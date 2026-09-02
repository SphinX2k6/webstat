using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200199A RID: 6554
public class TipsAttributeItem : UiPanelBase
{
	// Token: 0x0600BC3A RID: 48186 RVA: 0x0031F5EC File Offset: 0x0031D7EC
	[NullableContext(1)]
	public TipsAttributeItem(UUIItem uiItem, ITipsAttributeItemData data)
	{
		this.Data = data;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600BC3B RID: 48187 RVA: 0x0031F608 File Offset: 0x0031D808
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BC3C RID: 48188 RVA: 0x0031F6B4 File Offset: 0x0031D8B4
	protected override void OnStart()
	{
		base.GetSprite(0).useChangeColor = !this.Data.IsMainAttribute;
		base.SetTextureByPath(this.Data.IconPath, base.GetTexture(1), null, null);
		base.GetText(2).ShowTextNew(this.Data.Name);
		base.GetText(3).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(this.Data.Id, this.Data.Value, this.Data.IsRatio), true);
	}

	// Token: 0x0600BC3D RID: 48189 RVA: 0x0031F74C File Offset: 0x0031D94C
	protected override void OnBeforeDestroy()
	{
		this.Data = null;
	}

	// Token: 0x0400591D RID: 22813
	[Nullable(2)]
	private ITipsAttributeItemData Data;

	// Token: 0x02007C9C RID: 31900
	private class ETipsAttributeNode
	{
		// Token: 0x0402A8C9 RID: 174281
		public const int SpriteBackground = 0;

		// Token: 0x0402A8CA RID: 174282
		public const int TextureIcon = 1;

		// Token: 0x0402A8CB RID: 174283
		public const int TxtName = 2;

		// Token: 0x0402A8CC RID: 174284
		public const int TxtValue = 3;
	}
}
