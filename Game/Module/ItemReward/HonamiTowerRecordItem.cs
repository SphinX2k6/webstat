using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B53 RID: 23379
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HonamiTowerRecordItem : GridProxyAbstract<IHonamiTowerRecordData>
	{
		// Token: 0x0603B263 RID: 242275 RVA: 0x00EF7580 File Offset: 0x00EF5780
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

		// Token: 0x0603B264 RID: 242276 RVA: 0x00EF75E9 File Offset: 0x00EF57E9
		[NullableContext(1)]
		public override void Refresh(IHonamiTowerRecordData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.RecordName, Array.Empty<object>());
			base.GetText(1).SetText(data.RecordValue, true);
		}

		// Token: 0x0200BB54 RID: 47956
		private class ERecordItemType
		{
			// Token: 0x04039CF2 RID: 236786
			public const int NameText = 0;

			// Token: 0x04039CF3 RID: 236787
			public const int ValueText = 1;
		}
	}
}
