using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020013F2 RID: 5106
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MemoryContentItemB : GridProxyAbstract<IMemoryItemData>
{
	// Token: 0x06008D7D RID: 36221 RVA: 0x00253458 File Offset: 0x00251658
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUITexture))
		};
	}

	// Token: 0x06008D7E RID: 36222 RVA: 0x002534F4 File Offset: 0x002516F4
	public override void Refresh(IMemoryItemData data, bool isSelected, int gridIndex)
	{
		UUITexture texture = base.GetTexture(2);
		bool flag = !data.IsDelegate && data.HasData;
		texture.SetUIActive(flag);
		if (flag)
		{
			base.SetTextureByPath(data.IconPath ?? "", texture, null, null);
		}
		base.GetItem(3).SetUIActive(!data.IsDelegate && !data.HasData);
		UUITexture texture2 = base.GetTexture(5);
		bool flag2 = data.IsDelegate && data.HasData;
		texture2.SetUIActive(data.IsDelegate);
		if (flag2)
		{
			base.SetTextureByPath(data.IconPath ?? "", texture2, null, null);
		}
		base.GetText(1).ShowTextNew(data.Title);
		UUIText text = base.GetText(0);
		text.SetUIActive(true);
		text.ShowTextNew(data.Content ?? "");
		UUIText text2 = base.GetText(4);
		text2.SetUIActive(true);
		text2.SetText(data.SubContent ?? "", true);
	}
}
