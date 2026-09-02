using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200196C RID: 6508
[NullableContext(2)]
[Nullable(0)]
public class ItemGridVariantOne : ItemGridAbstract, IItemGrid, IItemGridVariantOne
{
	// Token: 0x0600BAF7 RID: 47863 RVA: 0x0031BCE0 File Offset: 0x00319EE0
	public ItemGridVariantOne(AActor commonItemActor = null, ItemGridAbstract source = null, EUiViewName? belongView = null) : base(commonItemActor, source, belongView)
	{
	}

	// Token: 0x17000F27 RID: 3879
	// (get) Token: 0x0600BAF8 RID: 47864 RVA: 0x0031BCF9 File Offset: 0x00319EF9
	public bool IsItemGridVariantOne { get; } = 1;

	// Token: 0x17000F28 RID: 3880
	// (get) Token: 0x0600BAF9 RID: 47865 RVA: 0x0031BD01 File Offset: 0x00319F01
	public bool IsItemGrid { get; } = 1;

	// Token: 0x0600BAFA RID: 47866 RVA: 0x0031BD0C File Offset: 0x00319F0C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
	}

	// Token: 0x0600BAFB RID: 47867 RVA: 0x0031BDC0 File Offset: 0x00319FC0
	protected override void OnStart()
	{
		this.StarLayoutItem = new StarLayoutItem(base.GetItem(1));
		this.ItemGrid = new ItemGrid(base.GetItem(0).GetOwner(), this, null);
		this.RefreshStar(null);
		this.RefreshRecoverSprite(false);
		this.RefreshRightDownLockSprite(false);
		this.RefreshUpgradePanel(false, null);
	}

	// Token: 0x0600BAFC RID: 47868 RVA: 0x0031BE1D File Offset: 0x0031A01D
	public void RefreshQualitySprite()
	{
		this.ItemGrid.RefreshQualitySprite();
	}

	// Token: 0x0600BAFD RID: 47869 RVA: 0x0031BE2A File Offset: 0x0031A02A
	[NullableContext(1)]
	public void RefreshTextureByPath(string path)
	{
		this.ItemGrid.RefreshTextureByPath(path);
	}

	// Token: 0x0600BAFE RID: 47870 RVA: 0x0031BE38 File Offset: 0x0031A038
	public void RefreshTextureIcon()
	{
		this.ItemGrid.RefreshTextureIcon();
	}

	// Token: 0x0600BAFF RID: 47871 RVA: 0x0031BE45 File Offset: 0x0031A045
	[NullableContext(1)]
	public void RefreshTextDown(bool showState, string text)
	{
		this.ItemGrid.RefreshTextDown(showState, text);
	}

	// Token: 0x0600BB00 RID: 47872 RVA: 0x0031BE54 File Offset: 0x0031A054
	[NullableContext(1)]
	public void RefreshTextDownByTextId(bool showState, string textId, params object[] args)
	{
		this.ItemGrid.RefreshTextDownByTextId(showState, textId, args);
	}

	// Token: 0x0600BB01 RID: 47873 RVA: 0x0031BE64 File Offset: 0x0031A064
	[NullableContext(1)]
	public void SetToggleClickEvent(Action<int, ItemConfig> call)
	{
		this.ItemGrid.SetToggleClickEvent(call);
	}

	// Token: 0x0600BB02 RID: 47874 RVA: 0x0031BE72 File Offset: 0x0031A072
	[NullableContext(1)]
	public void SetToggleClickStateEvent(Action<EToggleState> call)
	{
		this.ItemGrid.SetToggleClickStateEvent(call);
	}

	// Token: 0x0600BB03 RID: 47875 RVA: 0x0031BE80 File Offset: 0x0031A080
	public void BindRedPointWithKeyAndId(ERedDotName name, int uid)
	{
		this.ItemGrid.BindRedPointWithKeyAndId(name, uid);
	}

	// Token: 0x0600BB04 RID: 47876 RVA: 0x0031BE8F File Offset: 0x0031A08F
	[NullableContext(1)]
	public void RefreshCdPanel(bool showState, float cdFillAmount, string cdText)
	{
		this.ItemGrid.RefreshCdPanel(showState, cdFillAmount, cdText);
	}

	// Token: 0x0600BB05 RID: 47877 RVA: 0x0031BE9F File Offset: 0x0031A09F
	public void RefreshDarkSprite(bool showState)
	{
		this.ItemGrid.RefreshDarkSprite(showState);
	}

	// Token: 0x0600BB06 RID: 47878 RVA: 0x0031BEAD File Offset: 0x0031A0AD
	public void RefreshLockSprite(bool showState)
	{
		this.ItemGrid.RefreshLockSprite(showState);
	}

	// Token: 0x0600BB07 RID: 47879 RVA: 0x0031BEBB File Offset: 0x0031A0BB
	public UUIExtendToggle GetClickToggle()
	{
		return this.ItemGrid.GetClickToggle();
	}

	// Token: 0x0600BB08 RID: 47880 RVA: 0x0031BEC8 File Offset: 0x0031A0C8
	public UUIText GetDownText()
	{
		return this.ItemGrid.GetDownText();
	}

	// Token: 0x0600BB09 RID: 47881 RVA: 0x0031BED5 File Offset: 0x0031A0D5
	public void RefreshNewItem(bool state)
	{
		this.ItemGrid.RefreshNewItem(state);
	}

	// Token: 0x0600BB0A RID: 47882 RVA: 0x0031BEE3 File Offset: 0x0031A0E3
	public void RefreshStar(int[] starNum)
	{
		this.StarLayoutItem.RefreshStar(starNum);
	}

	// Token: 0x0600BB0B RID: 47883 RVA: 0x0031BEF1 File Offset: 0x0031A0F1
	public void RefreshRecoverSprite(bool showState)
	{
		base.GetSprite(3).SetUIActive(showState);
	}

	// Token: 0x0600BB0C RID: 47884 RVA: 0x0031BF00 File Offset: 0x0031A100
	public void RefreshRightDownLockSprite(bool showState)
	{
		base.GetSprite(4).SetUIActive(showState);
	}

	// Token: 0x0600BB0D RID: 47885 RVA: 0x0031BF0F File Offset: 0x0031A10F
	public void RefreshUpgradePanel(bool showState, string showText)
	{
		base.GetItem(5).SetUIActive(showState);
		if (showState)
		{
			base.GetText(6).SetText(showText, true);
		}
	}

	// Token: 0x0600BB0E RID: 47886 RVA: 0x0031BF2F File Offset: 0x0031A12F
	public override void Refresh(TItem data, bool isSelected, int gridIndex)
	{
	}

	// Token: 0x0600BB0F RID: 47887 RVA: 0x0031BF31 File Offset: 0x0031A131
	protected override void OnBeforeDestroy()
	{
		StarLayoutItem starLayoutItem = this.StarLayoutItem;
		if (starLayoutItem != null)
		{
			starLayoutItem.Destroy(null);
		}
		this.ItemGrid.Destroy(null);
	}

	// Token: 0x04005866 RID: 22630
	protected ItemGrid ItemGrid;

	// Token: 0x04005867 RID: 22631
	private StarLayoutItem StarLayoutItem;

	// Token: 0x02007C87 RID: 31879
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A868 RID: 174184
		ItemGrid,
		// Token: 0x0402A869 RID: 174185
		StarItem,
		// Token: 0x0402A86A RID: 174186
		RightDownVertical,
		// Token: 0x0402A86B RID: 174187
		RecoverSprite,
		// Token: 0x0402A86C RID: 174188
		LockSprite,
		// Token: 0x0402A86D RID: 174189
		UpgradePanel,
		// Token: 0x0402A86E RID: 174190
		UpgradeText
	}
}
