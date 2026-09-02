using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019CA RID: 6602
public class MediumItemGridLevelAndLockComponent : MediumItemGridComponent
{
	// Token: 0x0600BD8D RID: 48525 RVA: 0x00324120 File Offset: 0x00322320
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BD8E RID: 48526 RVA: 0x0032420D File Offset: 0x0032240D
	protected override void OnActivate()
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600BD8F RID: 48527 RVA: 0x00324234 File Offset: 0x00322434
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		IMediumLevelAndLock mediumLevelAndLock = data as IMediumLevelAndLock;
		if (mediumLevelAndLock == null)
		{
			this.SetActive(false);
			return;
		}
		this.SetLevel(mediumLevelAndLock.Level, mediumLevelAndLock.IsUseVision, mediumLevelAndLock.IsLevelInfinite);
		this.SetLock(mediumLevelAndLock.IsLockVisible);
		this.SetDeprecate(mediumLevelAndLock.IsDeprecate);
		UUIText text = base.GetText(2);
		if (text != null)
		{
			UUIItem uuiitem = text;
			bool valueOrDefault = mediumLevelAndLock.IsLevelUseChangeColor.GetValueOrDefault();
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(valueOrDefault, fcolor);
		}
		this.SetActive(true);
	}

	// Token: 0x0600BD90 RID: 48528 RVA: 0x003242B7 File Offset: 0x003224B7
	public void SetLock(bool? bLock)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(bLock.GetValueOrDefault());
	}

	// Token: 0x0600BD91 RID: 48529 RVA: 0x003242D1 File Offset: 0x003224D1
	public void SetDeprecate(bool? isDeprecate)
	{
		UUISprite sprite = base.GetSprite(5);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(isDeprecate.GetValueOrDefault());
	}

	// Token: 0x0600BD92 RID: 48530 RVA: 0x003242EC File Offset: 0x003224EC
	public void SetLevel(int? level, bool? useVision = false, bool? isLevelInfinite = null)
	{
		if (useVision.GetValueOrDefault())
		{
			this.SetNormalLevel(null, null);
			this.SetVisionLevel(level);
			return;
		}
		this.SetVisionLevel(null);
		this.SetNormalLevel(level, isLevelInfinite);
	}

	// Token: 0x0600BD93 RID: 48531 RVA: 0x0032433C File Offset: 0x0032253C
	private void SetNormalLevel(int? level, bool? isLevelInfinite = null)
	{
		UUIItem item = base.GetItem(1);
		if (level == null && !isLevelInfinite.GetValueOrDefault())
		{
			if (item != null && item.IsUIActiveSelf())
			{
				item.SetUIActive(false);
			}
			return;
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(isLevelInfinite.GetValueOrDefault() ? "∞" : level.Value.ToString(), true);
		}
		if (item != null && !item.IsUIActiveSelf())
		{
			item.SetUIActive(true);
		}
	}

	// Token: 0x0600BD94 RID: 48532 RVA: 0x003243BC File Offset: 0x003225BC
	private void SetVisionLevel(int? level)
	{
		UUIItem item = base.GetItem(3);
		if (level == null)
		{
			if (item != null && item.IsUIActiveSelf())
			{
				item.SetUIActive(false);
			}
			return;
		}
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetText(level.Value.ToString(), true);
		}
		if (item != null && !item.IsUIActiveSelf())
		{
			item.SetUIActive(true);
		}
	}

	// Token: 0x0600BD95 RID: 48533 RVA: 0x00324421 File Offset: 0x00322621
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemState";
	}

	// Token: 0x02007CC6 RID: 31942
	private class EChildType
	{
		// Token: 0x0402A972 RID: 174450
		public const int LockSprite = 0;

		// Token: 0x0402A973 RID: 174451
		public const int LevelItem = 1;

		// Token: 0x0402A974 RID: 174452
		public const int LevelText = 2;

		// Token: 0x0402A975 RID: 174453
		public const int VisionLevelItem = 3;

		// Token: 0x0402A976 RID: 174454
		public const int VisionLevelText = 4;

		// Token: 0x0402A977 RID: 174455
		public const int DeprecateSprite = 5;
	}
}
