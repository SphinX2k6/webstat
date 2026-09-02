using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001B07 RID: 6919
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoAbyssTagItem : GridProxyAbstract<DangoAbyssDefine.DangoAbyssTagData>
{
	// Token: 0x0600C75F RID: 51039 RVA: 0x0034BD0C File Offset: 0x00349F0C
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

	// Token: 0x0600C760 RID: 51040 RVA: 0x0034BD98 File Offset: 0x00349F98
	[NullableContext(1)]
	public override void Refresh(DangoAbyssDefine.DangoAbyssTagData data, bool isSelected, int gridIndex)
	{
		AbyssPluginPropDesc value = ConfigBase<DangoAbyssConfig>.Instance.GetDangoPluginPropDescById(data.TagId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Name, Array.Empty<object>());
		FColor color = FColor.FromHex(value.BgColor);
		base.GetSprite(0).SetColor(color);
		string formatAttributeValueByTagId = ModelBase<DangoAbyssModel>.Instance.GetFormatAttributeValueByTagId(data.Value, data.TagId, new bool?(this.GetValueByTips));
		base.GetText(2).SetText(formatAttributeValueByTagId, true);
	}

	// Token: 0x04005F7B RID: 24443
	public bool GetValueByTips;

	// Token: 0x02007DE3 RID: 32227
	private enum EComponent
	{
		// Token: 0x0402AE11 RID: 175633
		SpriteBg,
		// Token: 0x0402AE12 RID: 175634
		NameText,
		// Token: 0x0402AE13 RID: 175635
		DescText
	}
}
