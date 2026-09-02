using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C5F RID: 7263
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchHandBookItem : GridProxyAbstract<int>
{
	// Token: 0x0600D3F5 RID: 54261 RVA: 0x00388264 File Offset: 0x00386464
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D3F6 RID: 54262 RVA: 0x00388330 File Offset: 0x00386530
	protected override void OnStart()
	{
		this.SmallSlotLayout = new GenericLayout<FloroRanchHandBookSmallSlotItem, FloroRanchUnlockDataBase>(base.GetGridLayout(3), new Func<FloroRanchHandBookSmallSlotItem>(this.CreateSmallSlotItem), null, true, false);
	}

	// Token: 0x0600D3F7 RID: 54263 RVA: 0x00388354 File Offset: 0x00386554
	public override UniTask RefreshAsync(int data, bool isSelected, int gridIndex)
	{
		FloroRanchHandBookItem.<RefreshAsync>d__7 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.gridIndex = gridIndex;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<FloroRanchHandBookItem.<RefreshAsync>d__7>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D3F8 RID: 54264 RVA: 0x003883A8 File Offset: 0x003865A8
	private void TrySelectFirstItem()
	{
		FloroRanchHandBookSmallSlotItem floroRanchHandBookSmallSlotItem = this.SmallSlotLayout.GetLayoutItemList()[0];
		if ((this.IsSelectedItem == null || !this.IsSelectedItem()) && floroRanchHandBookSmallSlotItem != null)
		{
			this.OnClickCallback(floroRanchHandBookSmallSlotItem);
			this.SmallSlotLayout.SelectGridProxy(0, false);
		}
	}

	// Token: 0x0600D3F9 RID: 54265 RVA: 0x003883F8 File Offset: 0x003865F8
	private FloroRanchHandBookSmallSlotItem CreateSmallSlotItem()
	{
		FloroRanchHandBookSmallSlotItem floroRanchHandBookSmallSlotItem = new FloroRanchHandBookSmallSlotItem();
		floroRanchHandBookSmallSlotItem.SetActivityDataType(this.ActivityDataType);
		floroRanchHandBookSmallSlotItem.BindClickCallback(this.OnClickCallback);
		return floroRanchHandBookSmallSlotItem;
	}

	// Token: 0x040064D2 RID: 25810
	private GenericLayout<FloroRanchHandBookSmallSlotItem, FloroRanchUnlockDataBase> SmallSlotLayout;

	// Token: 0x040064D3 RID: 25811
	public EFloroRanchActivityDataType ActivityDataType;

	// Token: 0x040064D4 RID: 25812
	public Action<FloroRanchHandBookSmallSlotItem> OnClickCallback = delegate(FloroRanchHandBookSmallSlotItem item)
	{
	};

	// Token: 0x040064D5 RID: 25813
	[Nullable(2)]
	public Func<bool> IsSelectedItem;

	// Token: 0x02007F73 RID: 32627
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B645 RID: 177733
		public const int TextureTitleIcon = 0;

		// Token: 0x0402B646 RID: 177734
		public const int ItemTitlePanel = 1;

		// Token: 0x0402B647 RID: 177735
		public const int TextTitle = 2;

		// Token: 0x0402B648 RID: 177736
		public const int LayoutSmallSlot = 3;

		// Token: 0x0402B649 RID: 177737
		public const int ItemSmallSlot = 4;
	}
}
