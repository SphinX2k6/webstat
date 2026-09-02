using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200593B RID: 22843
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MapRogueFetterStarLvItem : GridProxyAbstract<IFetterStarLvData>
	{
		// Token: 0x06039F37 RID: 237367 RVA: 0x00EAAB0C File Offset: 0x00EA8D0C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x06039F38 RID: 237368 RVA: 0x00EAAB48 File Offset: 0x00EA8D48
		public override void Refresh(IFetterStarLvData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			UUIText text = base.GetText(0);
			text.SetText(data.StageStarLv.ToString(), true);
			UUIItem uuiitem = text;
			bool bUseChangeColor = data.CurrentLv == data.StageLv;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.GetSprite(1).SetUIActive(data.StageLv < data.MaxLv);
		}

		// Token: 0x04020D57 RID: 134487
		protected IFetterStarLvData Data;
	}
}
