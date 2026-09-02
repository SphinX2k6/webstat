using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005992 RID: 22930
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InfoItem : GridProxyAbstract<IItemInfoData>
	{
		// Token: 0x0603A10B RID: 237835 RVA: 0x00EB2227 File Offset: 0x00EB0427
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x0603A10C RID: 237836 RVA: 0x00EB2260 File Offset: 0x00EB0460
		public override void Refresh(IItemInfoData data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(0);
			UUIText text2 = base.GetText(1);
			UUIItem uuiitem = text2;
			bool valueChangeColor = data.ValueChangeColor;
			FColor? fcolor = new FColor?(text2.changeColor);
			uuiitem.SetChangeColor(valueChangeColor, fcolor);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TitleId, Array.Empty<object>());
			text2.SetText(data.Value, true);
		}
	}
}
