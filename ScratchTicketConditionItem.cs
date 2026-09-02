using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020015A3 RID: 5539
[Nullable(new byte[]
{
	0,
	1
})]
public class ScratchTicketConditionItem : GridProxyAbstract<ScratchTicketConditionData>
{
	// Token: 0x06009C08 RID: 39944 RVA: 0x0028D4B4 File Offset: 0x0028B6B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009C09 RID: 39945 RVA: 0x0028D53E File Offset: 0x0028B73E
	[NullableContext(1)]
	public override void Refresh(ScratchTicketConditionData data, bool isSelected, int gridIndex)
	{
		base.GetItem(0).SetUIActive(data.IsFinish());
		base.GetText(1).SetText(data.GetConditionDesc(), true);
		base.GetText(2).SetText(data.GetConditionTypeName(), true);
	}

	// Token: 0x02007963 RID: 31075
	private class EComponent
	{
		// Token: 0x04029B2A RID: 170794
		public const int FinishItem = 0;

		// Token: 0x04029B2B RID: 170795
		public const int ConditionDesc = 1;

		// Token: 0x04029B2C RID: 170796
		public const int ConditionTypeName = 2;
	}
}
