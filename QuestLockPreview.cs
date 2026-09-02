using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200266A RID: 9834
public class QuestLockPreview : UiViewBase
{
	// Token: 0x060135F8 RID: 79352 RVA: 0x00564C0B File Offset: 0x00562E0B
	[NullableContext(1)]
	public QuestLockPreview(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060135F9 RID: 79353 RVA: 0x00564C14 File Offset: 0x00562E14
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060135FA RID: 79354 RVA: 0x00564C9E File Offset: 0x00562E9E
	protected override void OnBeforeCreate()
	{
		this.OccupationInfo = (this.OpenParam as List<IOccupationInfo>);
	}

	// Token: 0x060135FB RID: 79355 RVA: 0x00564CB1 File Offset: 0x00562EB1
	protected override void OnStart()
	{
		base.OnStart();
		this.InitLockReasonItems();
	}

	// Token: 0x060135FC RID: 79356 RVA: 0x00564CC0 File Offset: 0x00562EC0
	private void InitLockReasonItems()
	{
		if (this.OccupationInfo == null || this.OccupationInfo.Count == 0)
		{
			return;
		}
		this.LockReasonItems = new List<LockReasonItem>();
		UUIItem item = base.GetItem(2);
		UUIItem item2 = base.GetItem(1);
		foreach (IOccupationInfo occupationInfo in this.OccupationInfo)
		{
			UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item, item2);
			LockReasonItem lockReasonItem = new LockReasonItem(occupationInfo);
			lockReasonItem.CreateThenShowByActorAsync(uuiitem.GetOwner(), null, false);
			this.LockReasonItems.Add(lockReasonItem);
		}
		item.SetUIActive(false);
	}

	// Token: 0x04009732 RID: 38706
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<IOccupationInfo> OccupationInfo;

	// Token: 0x04009733 RID: 38707
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<LockReasonItem> LockReasonItems;

	// Token: 0x020089FD RID: 35325
	private class EChildComponent
	{
		// Token: 0x0402E8B4 RID: 190644
		public const int SubTitleText = 0;

		// Token: 0x0402E8B5 RID: 190645
		public const int Content = 1;

		// Token: 0x0402E8B6 RID: 190646
		public const int LockReasonItem = 2;
	}
}
