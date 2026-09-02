using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005949 RID: 22857
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueExploreListItem : GridProxyAbstract<IExploreData>
	{
		// Token: 0x06039F6A RID: 237418 RVA: 0x00EAB8EC File Offset: 0x00EA9AEC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x06039F6B RID: 237419 RVA: 0x00EAB95C File Offset: 0x00EA9B5C
		public override void Refresh(IExploreData data, bool isSelected, int gridIndex)
		{
			UUISprite sprite = base.GetSprite(1);
			UUIItem uuiitem = sprite;
			bool bUseChangeColor = gridIndex % 2 != 0;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.TitleId, Array.Empty<object>());
			base.GetText(3).SetText(data.ValueTxt, true);
		}
	}
}
