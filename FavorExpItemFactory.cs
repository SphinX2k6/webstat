using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200286C RID: 10348
public static class FavorExpItemFactory
{
	// Token: 0x060147F8 RID: 83960 RVA: 0x005AFB78 File Offset: 0x005ADD78
	[NullableContext(1)]
	public static ILayoutItem<RoleFavorHintItem> InitFavorExpItem(object roleFavorHintData, UUIItem uiItem, int index)
	{
		RoleFavorHintItem value = new RoleFavorHintItem((RoleFavorHintData)roleFavorHintData, uiItem);
		return new LayoutItem<RoleFavorHintItem>
		{
			Key = index,
			Value = value
		};
	}
}
