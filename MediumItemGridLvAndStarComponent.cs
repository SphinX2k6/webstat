using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019CD RID: 6605
public class MediumItemGridLvAndStarComponent : MediumItemGridComponent
{
	// Token: 0x0600BDA0 RID: 48544 RVA: 0x0032445C File Offset: 0x0032265C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BDA1 RID: 48545 RVA: 0x00324507 File Offset: 0x00322707
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRoleInfo";
	}

	// Token: 0x0600BDA2 RID: 48546 RVA: 0x00324510 File Offset: 0x00322710
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		IMediumLevelAndStar mediumLevelAndStar = data as IMediumLevelAndStar;
		if (mediumLevelAndStar == null)
		{
			this.SetActive(false);
			return;
		}
		this.SetLevel(mediumLevelAndStar.Level);
		this.SetStar(mediumLevelAndStar.Star);
		this.SetActive(true);
	}

	// Token: 0x0600BDA3 RID: 48547 RVA: 0x0032454E File Offset: 0x0032274E
	public void SetLevel(int? level)
	{
		base.GetText(0).SetUIActive(level != null);
		if (level != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Text_LevelShow_Text", new <>z__ReadOnlySingleElementList<object>(level));
		}
	}

	// Token: 0x0600BDA4 RID: 48548 RVA: 0x0032458D File Offset: 0x0032278D
	public void SetStar(int? star)
	{
		base.GetItem(1).SetUIActive(star != null);
		if (star != null)
		{
			base.GetText(3).SetText(star.ToString(), true);
		}
	}

	// Token: 0x02007CC7 RID: 31943
	private class EInfoDefine
	{
		// Token: 0x0402A978 RID: 174456
		public const int TxtLevel = 0;

		// Token: 0x0402A979 RID: 174457
		public const int StarLayout = 1;

		// Token: 0x0402A97A RID: 174458
		public const int Star = 2;

		// Token: 0x0402A97B RID: 174459
		public const int TxtStar = 3;
	}
}
