using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x02005539 RID: 21817
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public abstract class CommonBaseCardItem<[Nullable(2)] TItemData> : CardItemBase<TItemData>
	{
		// Token: 0x06037A1D RID: 227869 RVA: 0x00E1D6B8 File Offset: 0x00E1B8B8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem))
			};
		}

		// Token: 0x06037A1E RID: 227870 RVA: 0x00E1D713 File Offset: 0x00E1B913
		protected UUIItem GetCardRootItem()
		{
			return base.GetItem(0);
		}

		// Token: 0x06037A1F RID: 227871 RVA: 0x00E1D71C File Offset: 0x00E1B91C
		protected UUIItem GetContentRootItem()
		{
			return base.GetItem(2);
		}

		// Token: 0x06037A20 RID: 227872 RVA: 0x00E1D725 File Offset: 0x00E1B925
		protected UUIItem GetSpineRootItem()
		{
			return base.GetItem(13);
		}

		// Token: 0x0200B4D0 RID: 46288
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037F94 RID: 229268
			public const int CardItem = 0;

			// Token: 0x04037F95 RID: 229269
			public const int ContentItem = 2;

			// Token: 0x04037F96 RID: 229270
			public const int SpineRootItem = 13;
		}
	}
}
