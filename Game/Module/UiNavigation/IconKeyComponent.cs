using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C82 RID: 19586
	[NullableContext(1)]
	[Nullable(0)]
	public class IconKeyComponent : KeyBaseComponent
	{
		// Token: 0x060330D9 RID: 209113 RVA: 0x00CC9700 File Offset: 0x00CC7900
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUITexture))
			};
		}

		// Token: 0x060330DA RID: 209114 RVA: 0x00CC979C File Offset: 0x00CC799C
		protected override UUIText GetNameText()
		{
			return base.GetText(4);
		}

		// Token: 0x060330DB RID: 209115 RVA: 0x00CC97A5 File Offset: 0x00CC79A5
		protected override UUITexture GetKeyTexture()
		{
			return base.GetTexture(0);
		}

		// Token: 0x060330DC RID: 209116 RVA: 0x00CC97AE File Offset: 0x00CC79AE
		protected override UUIItem GetLongPressItem()
		{
			return base.GetItem(1);
		}

		// Token: 0x060330DD RID: 209117 RVA: 0x00CC97B7 File Offset: 0x00CC79B7
		protected override UUIItem GetCircleItem()
		{
			return base.GetItem(2);
		}

		// Token: 0x060330DE RID: 209118 RVA: 0x00CC97C0 File Offset: 0x00CC79C0
		protected override UUIItem GetSquareItem()
		{
			return base.GetItem(3);
		}

		// Token: 0x060330DF RID: 209119 RVA: 0x00CC97C9 File Offset: 0x00CC79C9
		protected override UUITexture GetLongPressTipTexture()
		{
			return base.GetTexture(5);
		}

		// Token: 0x0200AD44 RID: 44356
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04035D4F RID: 220495
			KeyTexture,
			// Token: 0x04035D50 RID: 220496
			LongPreItem,
			// Token: 0x04035D51 RID: 220497
			CircleItem,
			// Token: 0x04035D52 RID: 220498
			SquareItem,
			// Token: 0x04035D53 RID: 220499
			NameText,
			// Token: 0x04035D54 RID: 220500
			LongPreTipTexture
		}
	}
}
