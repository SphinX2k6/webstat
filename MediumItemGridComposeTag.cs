using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020019B5 RID: 6581
public class MediumItemGridComposeTag : MediumItemGridComponent
{
	// Token: 0x0600BD0F RID: 48399 RVA: 0x003230E8 File Offset: 0x003212E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BD10 RID: 48400 RVA: 0x00323193 File Offset: 0x00321393
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ComposeItem";
	}

	// Token: 0x0600BD11 RID: 48401 RVA: 0x0032319C File Offset: 0x0032139C
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		CSharpScript.Game.Module.Common.MediumItemGrid.MediumItemGridComposeTag mediumItemGridComposeTag = data as CSharpScript.Game.Module.Common.MediumItemGrid.MediumItemGridComposeTag;
		if (mediumItemGridComposeTag == null)
		{
			return;
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(mediumItemGridComposeTag.IsRefreshItem);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(mediumItemGridComposeTag.IsLimitTimeItem);
		}
		this.RefreshBuffIcon(mediumItemGridComposeTag.BuffItem);
		this.SetActive(mediumItemGridComposeTag.IsRefreshItem || mediumItemGridComposeTag.IsLimitTimeItem || mediumItemGridComposeTag.BuffItem > EMediumItemGridBuffType.None);
	}

	// Token: 0x0600BD12 RID: 48402 RVA: 0x00323214 File Offset: 0x00321414
	protected void RefreshBuffIcon(EMediumItemGridBuffType buffIconType)
	{
		if (buffIconType == EMediumItemGridBuffType.None)
		{
			UUISprite sprite = base.GetSprite(3);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(false);
			return;
		}
		else
		{
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(true);
			}
			string text = null;
			MediumItemGridModel instance = ModelBase<MediumItemGridModel>.Instance;
			switch (buffIconType)
			{
			case EMediumItemGridBuffType.Attack:
				text = instance.AttackBuffSpritePath;
				break;
			case EMediumItemGridBuffType.Defense:
				text = instance.DefenseBuffSpritePath;
				break;
			case EMediumItemGridBuffType.RestoreHealth:
				text = instance.RestoreHealthBuffSpritePath;
				break;
			case EMediumItemGridBuffType.Recharge:
				text = instance.RechargeBuffSpritePath;
				break;
			case EMediumItemGridBuffType.Resurrection:
				text = instance.ResurrectionBuffSpritePath;
				break;
			case EMediumItemGridBuffType.Explore:
				text = instance.ExploreBuffSpritePath;
				break;
			}
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			UUISprite sprite3 = base.GetSprite(3);
			this.SetSpriteByPath(text, sprite3, false, null, null);
			return;
		}
	}

	// Token: 0x02007CB9 RID: 31929
	private class EChildType
	{
		// Token: 0x0402A958 RID: 174424
		public const int RootItem = 0;

		// Token: 0x0402A959 RID: 174425
		public const int LimitTimeItem = 1;

		// Token: 0x0402A95A RID: 174426
		public const int RefreshItem = 2;

		// Token: 0x0402A95B RID: 174427
		public const int BuffSprite = 3;
	}
}
