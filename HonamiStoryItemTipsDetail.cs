using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F12 RID: 7954
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryItemTipsDetail : UiPanelBase
{
	// Token: 0x0600EDC7 RID: 60871 RVA: 0x0040E744 File Offset: 0x0040C944
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
	}

	// Token: 0x0600EDC8 RID: 60872 RVA: 0x0040E824 File Offset: 0x0040CA24
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryItemTipsDetail.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryItemTipsDetail.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EDC9 RID: 60873 RVA: 0x0040E868 File Offset: 0x0040CA68
	public void Refresh(HonamiStoryItemDataBase data, EHonamiStoryBackpackType backpackType)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.GetName(), Array.Empty<object>());
		base.GetText(2).SetText(data.GetSellPrice().ToString(), true);
		base.GetItem(8).SetUIActive(false);
		if (data.GetItemType() != EHonamiStoryItemType.Normal)
		{
			HonamiStoryEquipItemData honamiStoryEquipItemData = data as HonamiStoryEquipItemData;
			if (honamiStoryEquipItemData == null)
			{
				return;
			}
			if (honamiStoryEquipItemData.GetBuffTempIdList(false).Count == 0)
			{
				return;
			}
			if (honamiStoryEquipItemData.GetWeaponTag() == 0)
			{
				return;
			}
			this.TagItem.Refresh(honamiStoryEquipItemData.GetWeaponTag(), false, -1);
			base.GetItem(8).SetUIActive(true);
		}
	}

	// Token: 0x0600EDCA RID: 60874 RVA: 0x0040E905 File Offset: 0x0040CB05
	public void AddHotKey(UUIItem hotKeyItem)
	{
		hotKeyItem.SetUIActive(true);
		hotKeyItem.SetUIParent(base.GetItem(4), false);
	}

	// Token: 0x0600EDCB RID: 60875 RVA: 0x0040E91C File Offset: 0x0040CB1C
	public void SetAutoLocation(UUIItem gridItem)
	{
		float x = base.GetText(0).GetTextRenderSize().X;
		Vector adaptiveTipsPosition = Singleton<LguiUtil>.Instance.GetAdaptiveTipsPosition(gridItem, this.RootItem, x + 50f);
		float width = base.GetItem(6).Width;
		float num = (gridItem.Height > gridItem.Width) ? (-gridItem.Width / 2f) : (-gridItem.Height / 2f);
		adaptiveTipsPosition.X += (double)width;
		adaptiveTipsPosition.Z += (double)num;
		FVector fvector = adaptiveTipsPosition.ToUeVectorOld();
		this.RootItem.SetUIWorldLocation(fvector);
	}

	// Token: 0x0400723C RID: 29244
	private const int TIPS_OFFSET_WIDTH = 50;

	// Token: 0x0400723D RID: 29245
	[Nullable(2)]
	private HonamiStoryWeaponTagItem TagItem;

	// Token: 0x02008276 RID: 33398
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402C401 RID: 181249
		TxtName,
		// Token: 0x0402C402 RID: 181250
		TexIcon,
		// Token: 0x0402C403 RID: 181251
		TxtPrice,
		// Token: 0x0402C404 RID: 181252
		PnlList,
		// Token: 0x0402C405 RID: 181253
		PnlKeyDown,
		// Token: 0x0402C406 RID: 181254
		PnlKeyUp,
		// Token: 0x0402C407 RID: 181255
		PnlLocalOffsetX,
		// Token: 0x0402C408 RID: 181256
		PnlCheckOffsetY,
		// Token: 0x0402C409 RID: 181257
		PnlTypeTabItem
	}
}
