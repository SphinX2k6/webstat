using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020019D2 RID: 6610
public class MediumItemGridPhantomSpecialSkillComponent : MediumItemGridComponent
{
	// Token: 0x0600BDB1 RID: 48561 RVA: 0x0032469C File Offset: 0x0032289C
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

	// Token: 0x0600BDB2 RID: 48562 RVA: 0x003246E4 File Offset: 0x003228E4
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_VisionTag";
	}

	// Token: 0x0600BDB3 RID: 48563 RVA: 0x003246EC File Offset: 0x003228EC
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (data is EMediumItemGridPhantomSpecialSkill)
		{
			EMediumItemGridPhantomSpecialSkill emediumItemGridPhantomSpecialSkill = (EMediumItemGridPhantomSpecialSkill)data;
			bool flag = emediumItemGridPhantomSpecialSkill > EMediumItemGridPhantomSpecialSkill.Hide;
			this.SetActive(flag);
			if (flag)
			{
				string path;
				if (emediumItemGridPhantomSpecialSkill == EMediumItemGridPhantomSpecialSkill.ShowAvailable)
				{
					path = "/Game/Aki/UI/UIResources/Common/Atlas/SP_ItemVision.SP_ItemVision";
				}
				else
				{
					path = "/Game/Aki/UI/UIResources/Common/Atlas/SP_ItemVisionB.SP_ItemVisionB";
				}
				UUISprite sprite = base.GetSprite(0);
				this.SetSpriteByPath(path, sprite, false, null, null);
			}
			return;
		}
	}

	// Token: 0x02007CC9 RID: 31945
	private class EComponent
	{
		// Token: 0x0402A97D RID: 174461
		public const int SpriteTag = 0;
	}
}
