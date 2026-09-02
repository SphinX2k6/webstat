using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020019BE RID: 6590
public class MediumItemGridDevelopRewardComponent : MediumItemGridComponent
{
	// Token: 0x0600BD36 RID: 48438 RVA: 0x0032395C File Offset: 0x00321B5C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BD37 RID: 48439 RVA: 0x003239C5 File Offset: 0x00321BC5
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemVisionMap";
	}

	// Token: 0x0600BD38 RID: 48440 RVA: 0x003239CC File Offset: 0x00321BCC
	protected override void OnActivate()
	{
		this.Layout = new GenericLayoutNew<DevelopRewardItem>(base.GetLayoutBase(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<DevelopRewardItem>(this.InitItem), base.GetItem(1));
	}

	// Token: 0x0600BD39 RID: 48441 RVA: 0x003239F3 File Offset: 0x00321BF3
	protected override void OnDeactivate()
	{
		GenericLayoutNew<DevelopRewardItem> layout = this.Layout;
		if (layout != null)
		{
			layout.ClearChildren();
		}
		this.Layout = null;
	}

	// Token: 0x0600BD3A RID: 48442 RVA: 0x00323A10 File Offset: 0x00321C10
	[NullableContext(1)]
	private ILayoutItem<DevelopRewardItem> InitItem(object data, UUIItem uiItem, int index)
	{
		DevelopRewardItem developRewardItem = new DevelopRewardItem();
		developRewardItem.CreateByActorAsync(uiItem.GetOwner(), null, false).ContinueWith(delegate()
		{
			developRewardItem.SetIsUnlock(index < this.UnlockLevel);
			developRewardItem.SetUiActive(true);
		}).Forget();
		return new LayoutItem<DevelopRewardItem>
		{
			Key = index,
			Value = developRewardItem
		};
	}

	// Token: 0x0600BD3B RID: 48443 RVA: 0x00323A88 File Offset: 0x00321C88
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		DevelopRewardInfo developRewardInfo = data as DevelopRewardInfo;
		if (developRewardInfo == null)
		{
			this.SetActive(false);
			return;
		}
		bool? isUnlock = developRewardInfo.IsUnlock;
		if (!isUnlock.GetValueOrDefault())
		{
			this.SetActive(false);
			return;
		}
		this.DevelopRewardLevel = developRewardInfo.DevelopRewardLevel;
		this.UnlockLevel = developRewardInfo.UnlockLevel;
		GenericLayoutNew<DevelopRewardItem> layout = this.Layout;
		if (layout != null)
		{
			layout.RebuildLayoutByDataNew<object>(null, new int?(this.DevelopRewardLevel));
		}
		this.SetActive(true);
	}

	// Token: 0x04005956 RID: 22870
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<DevelopRewardItem> Layout;

	// Token: 0x04005957 RID: 22871
	private int DevelopRewardLevel;

	// Token: 0x04005958 RID: 22872
	private int UnlockLevel;

	// Token: 0x02007CBF RID: 31935
	private class EChildType
	{
		// Token: 0x0402A967 RID: 174439
		public const int LevelLayout = 0;

		// Token: 0x0402A968 RID: 174440
		public const int LevelLayoutItem = 1;
	}
}
