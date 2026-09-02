using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001A1F RID: 6687
public class SmallItemGridDirectionalFusionComponent : SmallItemGridComponent
{
	// Token: 0x0600BFE6 RID: 49126 RVA: 0x0032C133 File Offset: 0x0032A333
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x0600BFE7 RID: 49127 RVA: 0x0032C156 File Offset: 0x0032A356
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemIconTag";
	}

	// Token: 0x0600BFE8 RID: 49128 RVA: 0x0032C160 File Offset: 0x0032A360
	[NullableContext(2)]
	protected override void OnRefresh(object phantomFetterId)
	{
		if (phantomFetterId == null)
		{
			this.SetActive(false);
			return;
		}
		int num = (int)phantomFetterId;
		if (num < 0)
		{
			this.SetActive(false);
			return;
		}
		UUITexture texture = base.GetTexture(0);
		if (num == 0)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconElementAttriNone");
			base.SetTextureByPath(resourcePath, texture, null, null);
			this.SetActive(true);
			return;
		}
		string fetterElementPath = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(num).FetterElementPath;
		if (string.IsNullOrEmpty(fetterElementPath))
		{
			this.SetActive(false);
			return;
		}
		base.SetTextureByPath(fetterElementPath, texture, null, null);
		this.SetActive(true);
	}
}
