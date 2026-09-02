using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026C7 RID: 9927
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class QuestTreeChapterGroupItem : GridProxyAbstract<List<QuestTreeChapterData>>
{
	// Token: 0x06013955 RID: 80213 RVA: 0x00576B94 File Offset: 0x00574D94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013956 RID: 80214 RVA: 0x00576D2C File Offset: 0x00574F2C
	protected override void OnStart()
	{
		this.AttachPointList.Add(base.GetItem(6));
		this.AttachPointList.Add(base.GetItem(7));
		this.AttachPointList.Add(base.GetItem(8));
		this.AttachPointList.Add(base.GetItem(9));
		this.AttachPointList.Add(base.GetItem(10));
		this.ContainerList.Add(base.GetItem(1));
		this.ContainerList.Add(base.GetItem(2));
		this.ContainerList.Add(base.GetItem(3));
		this.ContainerList.Add(base.GetItem(4));
		this.ContainerList.Add(base.GetItem(5));
		this.ChapterItemList = new List<QuestTreeChapterItem>();
		for (int i = 0; i < 5; i++)
		{
			this.ChapterItemList.Add(new QuestTreeChapterItem());
		}
	}

	// Token: 0x06013957 RID: 80215 RVA: 0x00576E16 File Offset: 0x00575016
	public override void Refresh(List<QuestTreeChapterData> data, bool isSelected, int gridIndex)
	{
		this.RefreshImp(data);
	}

	// Token: 0x06013958 RID: 80216 RVA: 0x00576E20 File Offset: 0x00575020
	public override UniTask RefreshAsync(List<QuestTreeChapterData> data, bool isSelected, int gridIndex)
	{
		QuestTreeChapterGroupItem.<RefreshAsync>d__8 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<QuestTreeChapterGroupItem.<RefreshAsync>d__8>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013959 RID: 80217 RVA: 0x00576E6C File Offset: 0x0057506C
	private UniTask RefreshImp(List<QuestTreeChapterData> data)
	{
		QuestTreeChapterGroupItem.<RefreshImp>d__9 <RefreshImp>d__;
		<RefreshImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshImp>d__.<>4__this = this;
		<RefreshImp>d__.data = data;
		<RefreshImp>d__.<>1__state = -1;
		<RefreshImp>d__.<>t__builder.Start<QuestTreeChapterGroupItem.<RefreshImp>d__9>(ref <RefreshImp>d__);
		return <RefreshImp>d__.<>t__builder.Task;
	}

	// Token: 0x04009876 RID: 39030
	private List<QuestTreeChapterData> DataList = new List<QuestTreeChapterData>();

	// Token: 0x04009877 RID: 39031
	private List<UUIItem> AttachPointList = new List<UUIItem>();

	// Token: 0x04009878 RID: 39032
	private List<UUIItem> ContainerList = new List<UUIItem>();

	// Token: 0x04009879 RID: 39033
	private List<QuestTreeChapterItem> ChapterItemList = new List<QuestTreeChapterItem>();

	// Token: 0x02008A77 RID: 35447
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EB3F RID: 191295
		public const int ItemSelf = 0;

		// Token: 0x0402EB40 RID: 191296
		public const int ItemContainer1 = 1;

		// Token: 0x0402EB41 RID: 191297
		public const int ItemContainer2 = 2;

		// Token: 0x0402EB42 RID: 191298
		public const int ItemContainer3 = 3;

		// Token: 0x0402EB43 RID: 191299
		public const int ItemContainer4 = 4;

		// Token: 0x0402EB44 RID: 191300
		public const int ItemContainer5 = 5;

		// Token: 0x0402EB45 RID: 191301
		public const int ItemAttachPoint1 = 6;

		// Token: 0x0402EB46 RID: 191302
		public const int ItemAttachPoint2 = 7;

		// Token: 0x0402EB47 RID: 191303
		public const int ItemAttachPoint3 = 8;

		// Token: 0x0402EB48 RID: 191304
		public const int ItemAttachPoint4 = 9;

		// Token: 0x0402EB49 RID: 191305
		public const int ItemAttachPoint5 = 10;
	}
}
