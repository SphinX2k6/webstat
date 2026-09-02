using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001B9A RID: 7066
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MapExploreStoryItem : GridProxyAbstract<IMapExploreStoryItemData>
{
	// Token: 0x0600CD9A RID: 52634 RVA: 0x0036C544 File Offset: 0x0036A744
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CD9B RID: 52635 RVA: 0x0036C631 File Offset: 0x0036A831
	protected override void OnBeforeCreate()
	{
		this.Sequence = new LevelSequencePlayer(this.RootItem);
		this.Sequence.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceCloseEvent), false);
	}

	// Token: 0x0600CD9C RID: 52636 RVA: 0x0036C65C File Offset: 0x0036A85C
	protected override void OnStart()
	{
	}

	// Token: 0x0600CD9D RID: 52637 RVA: 0x0036C65E File Offset: 0x0036A85E
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer sequence = this.Sequence;
		if (sequence == null)
		{
			return;
		}
		sequence.Clear();
	}

	// Token: 0x0600CD9E RID: 52638 RVA: 0x0036C670 File Offset: 0x0036A870
	private void SetTextNew(MapExploreStoryItem.EChildType index, string text = null)
	{
		UUIText text2 = base.GetText((int)index);
		if (!string.IsNullOrEmpty(text))
		{
			if (text2 != null)
			{
				text2.ShowTextNew(text);
				return;
			}
		}
		else if (text2 != null)
		{
			text2.SetText("", true);
		}
	}

	// Token: 0x0600CD9F RID: 52639 RVA: 0x0036C6A8 File Offset: 0x0036A8A8
	public override void Refresh(IMapExploreStoryItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		this.SetTextNew(MapExploreStoryItem.EChildType.TxtTitle, data.StoryTitle);
		this.SetTextNew(MapExploreStoryItem.EChildType.TxtContent, data.StoryContent);
		this.SetTextNew(MapExploreStoryItem.EChildType.TxtContentLocked, data.LockedDesc);
		if (data.IsOpen)
		{
			bool? isNewOpen = data.IsNewOpen;
			bool flag = false;
			if (isNewOpen.GetValueOrDefault() == flag & isNewOpen != null)
			{
				this.SetOpenState();
				return;
			}
		}
		this.SetLockedState();
	}

	// Token: 0x0600CDA0 RID: 52640 RVA: 0x0036C718 File Offset: 0x0036A918
	private void SetOpenState()
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 == null)
		{
			return;
		}
		IMapExploreStoryItemData itemData = this.ItemData;
		item2.SetUIActive(!string.IsNullOrEmpty((itemData != null) ? itemData.StoryTitle : null));
	}

	// Token: 0x0600CDA1 RID: 52641 RVA: 0x0036C776 File Offset: 0x0036A976
	private void SetLockedState()
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600CDA2 RID: 52642 RVA: 0x0036C7B0 File Offset: 0x0036A9B0
	public void PlayNewOpenAnim()
	{
		LevelSequencePlayer sequence = this.Sequence;
		if (sequence == null)
		{
			return;
		}
		sequence.PlayLevelSequenceByName("Unlock", false, null, false);
	}

	// Token: 0x0600CDA3 RID: 52643 RVA: 0x0036C7DD File Offset: 0x0036A9DD
	private void SequenceCloseEvent(string sequenceName)
	{
		if (sequenceName != "Unlock")
		{
			return;
		}
		this.SetOpenState();
	}

	// Token: 0x0400622C RID: 25132
	private LevelSequencePlayer Sequence;

	// Token: 0x0400622D RID: 25133
	private IMapExploreStoryItemData ItemData;

	// Token: 0x02007E87 RID: 32391
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B1A4 RID: 176548
		ItemRoot,
		// Token: 0x0402B1A5 RID: 176549
		TxtTitle,
		// Token: 0x0402B1A6 RID: 176550
		TxtContent,
		// Token: 0x0402B1A7 RID: 176551
		ItemRootLocked,
		// Token: 0x0402B1A8 RID: 176552
		TxtContentLocked,
		// Token: 0x0402B1A9 RID: 176553
		ItemTitleRoot
	}
}
