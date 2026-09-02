using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020019C4 RID: 6596
public class MediumItemGridHalfAreaComponent : MediumItemGridComponent
{
	// Token: 0x0600BD58 RID: 48472 RVA: 0x00323E0D File Offset: 0x0032200D
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemTagTeam";
	}

	// Token: 0x0600BD59 RID: 48473 RVA: 0x00323E14 File Offset: 0x00322014
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BD5A RID: 48474 RVA: 0x00323E5C File Offset: 0x0032205C
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		HaveAreaInfo haveAreaInfo = data as HaveAreaInfo;
		if (haveAreaInfo == null)
		{
			return;
		}
		string halfAreaResId = this.GetHalfAreaResId(haveAreaInfo.BelongTo);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(halfAreaResId);
		this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		this.SetActive(true);
	}

	// Token: 0x0600BD5B RID: 48475 RVA: 0x00323EAD File Offset: 0x003220AD
	[NullableContext(1)]
	private string GetHalfAreaResId(ETeamBelong belongTo = ETeamBelong.FirstPart)
	{
		if (belongTo != ETeamBelong.FirstPart)
		{
			return "SP_ComTagTeam2";
		}
		return "SP_ComTagTeam1";
	}

	// Token: 0x02007CC4 RID: 31940
	private class EChildType
	{
		// Token: 0x0402A96F RID: 174447
		public const int Sprite = 0;
	}
}
