using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001A26 RID: 6694
public class SmallItemGridLeftTopIconComponent : SmallItemGridComponent
{
	// Token: 0x0600C004 RID: 49156 RVA: 0x0032C543 File Offset: 0x0032A743
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x0600C005 RID: 49157 RVA: 0x0032C566 File Offset: 0x0032A766
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_AddtionIcon";
	}

	// Token: 0x0600C006 RID: 49158 RVA: 0x0032C570 File Offset: 0x0032A770
	[NullableContext(2)]
	protected override void OnRefresh(object tempData)
	{
		string path = (string)tempData;
		this.SetSpriteByPath(path, base.GetSprite(0), false, null, null);
		this.SetActive(true);
	}

	// Token: 0x02007CFD RID: 31997
	private static class EChildType
	{
		// Token: 0x0402AA17 RID: 174615
		public const int SpriteIcon = 0;
	}
}
