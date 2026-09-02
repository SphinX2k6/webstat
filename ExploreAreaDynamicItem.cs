using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B81 RID: 7041
public class ExploreAreaDynamicItem : UiPanelBase, IDynamicScrollBaseItem<ExploreAreaViewData>
{
	// Token: 0x0600CC84 RID: 52356 RVA: 0x00367184 File Offset: 0x00365384
	[NullableContext(1)]
	public UniTask Init(UUIItem actor)
	{
		ExploreAreaDynamicItem.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ExploreAreaDynamicItem.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600CC85 RID: 52357 RVA: 0x003671D0 File Offset: 0x003653D0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CC86 RID: 52358 RVA: 0x0036723C File Offset: 0x0036543C
	[NullableContext(1)]
	public FVector2D GetItemSize(ExploreAreaViewData data)
	{
		if (data.IsCountry)
		{
			UUIItem item = base.GetItem(0);
			return new FVector2D(item.GetWidth(), item.GetHeight());
		}
		UUIItem item2 = base.GetItem(1);
		return new FVector2D(item2.GetWidth(), item2.GetHeight());
	}

	// Token: 0x0600CC87 RID: 52359 RVA: 0x00367284 File Offset: 0x00365484
	public void ClearItem()
	{
	}

	// Token: 0x02007E60 RID: 32352
	private enum EChildType
	{
		// Token: 0x0402B0CA RID: 176330
		CountryItem,
		// Token: 0x0402B0CB RID: 176331
		AreaItem
	}
}
