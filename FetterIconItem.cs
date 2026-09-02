using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002538 RID: 9528
[Nullable(new byte[]
{
	0,
	1
})]
public class FetterIconItem : GridProxyAbstract<IVisionNewRecommendFetterItemData>
{
	// Token: 0x0601289C RID: 75932 RVA: 0x0051B754 File Offset: 0x00519954
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0601289D RID: 75933 RVA: 0x0051B7B0 File Offset: 0x005199B0
	[NullableContext(1)]
	public override void Refresh(IVisionNewRecommendFetterItemData data, bool isSelected, int gridIndex)
	{
		base.TrySetTextureByPath(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data.GroupId).FetterElementPath, base.GetTexture(0), null, null);
		UUIText text = base.GetText(1);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			text2.SetUIActive(data.Count > 0);
		}
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(gridIndex != 0);
	}

	// Token: 0x0200885D RID: 34909
	private enum EFetterIcon
	{
		// Token: 0x0402E0F6 RID: 188662
		Icon,
		// Token: 0x0402E0F7 RID: 188663
		Num,
		// Token: 0x0402E0F8 RID: 188664
		Add
	}
}
