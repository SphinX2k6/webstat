using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001E4B RID: 7755
[NullableContext(1)]
[Nullable(0)]
public static class HandBookBaseViewHelper
{
	// Token: 0x0600E58F RID: 58767 RVA: 0x003E02E4 File Offset: 0x003DE4E4
	public static ILayoutItem<HandBookInfoTextItem> InitInfoItem(object content, UUIItem uiItem, int index)
	{
		HandBookInfoTextItem value = new HandBookInfoTextItem((string)content, uiItem);
		return new LayoutItem<HandBookInfoTextItem>
		{
			Key = index,
			Value = value
		};
	}

	// Token: 0x0600E590 RID: 58768 RVA: 0x003E0318 File Offset: 0x003DE518
	public static ILayoutItem<HandBookContentItem> InitContentItem(object data, UUIItem uiItem, int index)
	{
		HandBookContentItem value = new HandBookContentItem((HandBookContentItemData)data, uiItem);
		return new LayoutItem<HandBookContentItem>
		{
			Key = index,
			Value = value
		};
	}

	// Token: 0x0600E591 RID: 58769 RVA: 0x003E034A File Offset: 0x003DE54A
	public static AttributeItem InitAttributeItem()
	{
		return new AttributeItem();
	}
}
