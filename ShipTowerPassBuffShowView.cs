using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029C7 RID: 10695
public class ShipTowerPassBuffShowView : UiViewBase
{
	// Token: 0x06015532 RID: 87346 RVA: 0x005E8D51 File Offset: 0x005E6F51
	[NullableContext(1)]
	public ShipTowerPassBuffShowView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015533 RID: 87347 RVA: 0x005E8D5C File Offset: 0x005E6F5C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06015534 RID: 87348 RVA: 0x005E8DA4 File Offset: 0x005E6FA4
	private void InitDataParam()
	{
	}

	// Token: 0x06015535 RID: 87349 RVA: 0x005E8DA8 File Offset: 0x005E6FA8
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerPassBuffShowView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerPassBuffShowView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015536 RID: 87350 RVA: 0x005E8DEC File Offset: 0x005E6FEC
	protected override void OnBeforeShow()
	{
		ShipTowerPassBuffShowView.Params @params = this.OpenParam as ShipTowerPassBuffShowView.Params;
		ShipTowerStageData shipTowerStageData = (@params != null) ? @params.StageData : null;
		IReadOnlyList<TItem> readOnlyList = (shipTowerStageData != null) ? shipTowerStageData.GetPassUnlockBuffList() : null;
		IReadOnlyList<TItem> data = readOnlyList ?? Array.Empty<TItem>();
		GenericScrollViewNew<ShipTowerPassBuffShowItem, TItem> buffScroll = this.BuffScroll;
		if (buffScroll == null)
		{
			return;
		}
		buffScroll.RefreshByData(data, null, false);
	}

	// Token: 0x0400A44F RID: 42063
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<ShipTowerPassBuffShowItem, TItem> BuffScroll;

	// Token: 0x02008D23 RID: 36131
	public class Params
	{
		// Token: 0x0402F78A RID: 194442
		[Nullable(2)]
		public ShipTowerStageData StageData;
	}

	// Token: 0x02008D24 RID: 36132
	private static class EChildType
	{
		// Token: 0x0402F78B RID: 194443
		public const int ScrollBar = 0;
	}
}
