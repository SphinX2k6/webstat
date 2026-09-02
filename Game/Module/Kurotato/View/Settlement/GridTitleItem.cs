using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A7C RID: 23164
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class GridTitleItem : SyncGridProxyAbstract<GridTitleItemDataInner>
	{
		// Token: 0x0603A9EA RID: 240106 RVA: 0x00ED9B60 File Offset: 0x00ED7D60
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603A9EB RID: 240107 RVA: 0x00ED9BC9 File Offset: 0x00ED7DC9
		[NullableContext(1)]
		public override void Refresh(GridTitleItemDataInner data)
		{
			base.GetText(0).ShowTextNew(data.Title);
			base.GetText(1).SetText(data.Num, true);
		}

		// Token: 0x0200BA53 RID: 47699
		private class ETitleComp
		{
			// Token: 0x0403988C RID: 235660
			public const int TextTitle = 0;

			// Token: 0x0403988D RID: 235661
			public const int TextNum = 1;
		}
	}
}
