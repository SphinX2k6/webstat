using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F01 RID: 7937
public class HonamiStoryBackpackTitleItem : UiPanelBase
{
	// Token: 0x0600ECF2 RID: 60658 RVA: 0x00409422 File Offset: 0x00407622
	public HonamiStoryBackpackTitleItem(EHonamiStoryBackpackType backpackType)
	{
		this.Backpack = Singleton<HonamiStoryDefine>.Instance.HonamiBackpackTypeMap[backpackType];
	}

	// Token: 0x0600ECF3 RID: 60659 RVA: 0x00409448 File Offset: 0x00407648
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600ECF4 RID: 60660 RVA: 0x004094D4 File Offset: 0x004076D4
	protected override void OnStart()
	{
		string text;
		switch (this.Backpack)
		{
		case EHonamiStoryBackpack.Inventory:
			text = "HonamiStory_WareHouse";
			break;
		case EHonamiStoryBackpack.Backpack:
			text = "HonamiStory_BackPack";
			break;
		case EHonamiStoryBackpack.PickUpBox:
			text = "HonamiStory_FallingPile";
			break;
		default:
			text = "HonamiStory_BackPack";
			break;
		}
		string textStringId = text;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		switch (this.Backpack)
		{
		case EHonamiStoryBackpack.Inventory:
			text = "SP_TipsTitleIcon2";
			break;
		case EHonamiStoryBackpack.Backpack:
			text = "SP_TipsTitleIcon1";
			break;
		case EHonamiStoryBackpack.PickUpBox:
			text = "SP_TipsTitleIcon3";
			break;
		default:
			text = "SP_TipsTitleIcon1";
			break;
		}
		string resourceId = text;
		string path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId) ?? string.Empty;
		this.SetSpriteByPath(path, base.GetSprite(0), false, null, null);
		this.Refresh();
	}

	// Token: 0x0600ECF5 RID: 60661 RVA: 0x004095AC File Offset: 0x004077AC
	public void Refresh()
	{
		HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData((int)this.Backpack, false);
		int capacity = backPackData.GetCapacity();
		int occupy = backPackData.GetOccupy();
		if (this.Backpack == EHonamiStoryBackpack.Inventory && backPackData.GetOverflowCapacity() > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "HonamiStory_OverflowCapacity", new <>z__ReadOnlyArray<object>(new object[]
			{
				occupy,
				capacity
			}));
			return;
		}
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(occupy);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(capacity);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x040071E2 RID: 29154
	protected EHonamiStoryBackpack Backpack = EHonamiStoryBackpack.Inventory;

	// Token: 0x02008259 RID: 33369
	private enum EItem
	{
		// Token: 0x0402C366 RID: 181094
		Sprite,
		// Token: 0x0402C367 RID: 181095
		TxtName,
		// Token: 0x0402C368 RID: 181096
		TxtNum
	}
}
