using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB3 RID: 23987
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DreamLinkWhiteCatSettleItem : GridProxyAbstract<IDreamLinkReachedData>
	{
		// Token: 0x0603C658 RID: 247384 RVA: 0x00F5498C File Offset: 0x00F52B8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C659 RID: 247385 RVA: 0x00F54A16 File Offset: 0x00F52C16
		[NullableContext(1)]
		public override void Refresh(IDreamLinkReachedData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Title, Array.Empty<object>());
			base.GetText(2).SetText(data.Score, true);
		}

		// Token: 0x0200BE01 RID: 48641
		private class EDreamLinkSettleItemDefine
		{
			// Token: 0x0403A7DF RID: 239583
			public const int SpriteBg = 0;

			// Token: 0x0403A7E0 RID: 239584
			public const int TxtTitle = 1;

			// Token: 0x0403A7E1 RID: 239585
			public const int TxtScore = 2;
		}
	}
}
