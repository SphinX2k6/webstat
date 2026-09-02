using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006831 RID: 26673
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SuccessDescriptionItem : GridProxyAbstract<SingleText>
	{
		// Token: 0x060427FF RID: 272383 RVA: 0x011118B4 File Offset: 0x0110FAB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042800 RID: 272384 RVA: 0x011118FC File Offset: 0x0110FAFC
		public void SetDescriptionText(SingleText text)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), text.TextId, text.Params);
		}

		// Token: 0x06042801 RID: 272385 RVA: 0x0111191B File Offset: 0x0110FB1B
		public override void Refresh(SingleText data, bool isSelected, int gridIndex)
		{
			this.SetDescriptionText(data);
		}

		// Token: 0x0200C871 RID: 51313
		[NullableContext(0)]
		private class EDescriptionNode
		{
			// Token: 0x0403DB20 RID: 252704
			public const int TextDescription = 0;
		}
	}
}
