using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020028AE RID: 10414
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleSkillBranchTipsContentItem : GridProxyAbstract<IRoleSkillBranchTipsContentItemData>
{
	// Token: 0x06014ACE RID: 84686 RVA: 0x005B9BB0 File Offset: 0x005B7DB0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014ACF RID: 84687 RVA: 0x005B9C7C File Offset: 0x005B7E7C
	[NullableContext(1)]
	public override void Refresh(IRoleSkillBranchTipsContentItemData data, bool isSelected, int gridIndex)
	{
		base.GetSprite(0).SetUIActive(data.IsHighlight);
		base.GetSprite(1).SetUIActive(data.IsHighlight);
		this.SetSpriteByPath(data.IconPath, base.GetSprite(2), false, null, null);
		base.GetText(3).ShowTextNew(data.TitleKey);
		base.GetText(4).ShowTextNew(data.DescKey);
	}

	// Token: 0x02008BFB RID: 35835
	private enum EComponent
	{
		// Token: 0x0402F26D RID: 193133
		ArrowSprite,
		// Token: 0x0402F26E RID: 193134
		TagBgSprite,
		// Token: 0x0402F26F RID: 193135
		TagIconSprite,
		// Token: 0x0402F270 RID: 193136
		TitleTxt,
		// Token: 0x0402F271 RID: 193137
		DescTxt
	}
}
