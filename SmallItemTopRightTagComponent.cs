using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A46 RID: 6726
public class SmallItemTopRightTagComponent : SmallItemGridComponent
{
	// Token: 0x0600C08E RID: 49294 RVA: 0x0032D41C File Offset: 0x0032B61C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C08F RID: 49295 RVA: 0x0032D488 File Offset: 0x0032B688
	[NullableContext(2)]
	protected override void OnRefresh(object tempData)
	{
		ISmallItemTopRightTagComponentParams smallItemTopRightTagComponentParams = (ISmallItemTopRightTagComponentParams)tempData;
		string topRightTextId = smallItemTopRightTagComponentParams.TopRightTextId;
		string topRightText = smallItemTopRightTagComponentParams.TopRightText;
		bool flag = StringUtils.IsEmpty(topRightTextId);
		bool flag2 = StringUtils.IsEmpty(topRightText);
		bool flag3 = !flag || !flag2;
		this.SetActive(flag3);
		if (!flag3)
		{
			return;
		}
		UUIText text = base.GetText(1);
		if (topRightTextId != null && !flag)
		{
			object[] topRightTextParameter = smallItemTopRightTagComponentParams.TopRightTextParameter;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, topRightTextId, topRightTextParameter);
		}
		else if (topRightText != null && !flag2)
		{
			text.SetText(topRightText, true);
		}
		string topRightTextBgColor = smallItemTopRightTagComponentParams.TopRightTextBgColor;
		if (topRightTextBgColor != null)
		{
			base.GetSprite(0).SetColor(FColor.FromHex(topRightTextBgColor));
		}
		string topRightTextColor = smallItemTopRightTagComponentParams.TopRightTextColor;
		if (topRightTextColor != null)
		{
			base.GetText(1).SetColor(FColor.FromHex(topRightTextColor));
		}
	}

	// Token: 0x0600C090 RID: 49296 RVA: 0x0032D549 File Offset: 0x0032B749
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemTopRightText";
	}

	// Token: 0x0600C091 RID: 49297 RVA: 0x0032D550 File Offset: 0x0032B750
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007D0A RID: 32010
	private enum EChildType
	{
		// Token: 0x0402AA36 RID: 174646
		BgSprite,
		// Token: 0x0402AA37 RID: 174647
		TopRightText
	}
}
