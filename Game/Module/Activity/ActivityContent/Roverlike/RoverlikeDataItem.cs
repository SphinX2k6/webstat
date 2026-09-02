using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063FB RID: 25595
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeDataItem : GridProxyAbstract<IRoverlikeSettleDataItemData>
	{
		// Token: 0x0604043C RID: 263228 RVA: 0x01078788 File Offset: 0x01076988
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

		// Token: 0x0604043D RID: 263229 RVA: 0x010787F1 File Offset: 0x010769F1
		public override void Refresh(IRoverlikeSettleDataItemData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.NameTextId, Array.Empty<object>());
			base.GetText(1).SetText(data.ValueText, true);
		}

		// Token: 0x0604043E RID: 263230 RVA: 0x01078822 File Offset: 0x01076A22
		public override object GetKey(IRoverlikeSettleDataItemData data, int gridIndex)
		{
			return gridIndex;
		}

		// Token: 0x0200C463 RID: 50275
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C740 RID: 247616
			public const int TxtDataName = 0;

			// Token: 0x0403C741 RID: 247617
			public const int TxtDataNum = 1;
		}
	}
}
