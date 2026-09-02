using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E53 RID: 24147
	public class MediumItemGridRoundCountComponent : MediumItemGridComponent
	{
		// Token: 0x0603CC9B RID: 248987 RVA: 0x00F6FCCF File Offset: 0x00F6DECF
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_ItemGridRound";
		}

		// Token: 0x0603CC9C RID: 248988 RVA: 0x00F6FCD8 File Offset: 0x00F6DED8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CC9D RID: 248989 RVA: 0x00F6FD44 File Offset: 0x00F6DF44
		[NullableContext(2)]
		protected override void OnRefresh(object data)
		{
			if (data is int)
			{
				int num = (int)data;
				UUISprite sprite = base.GetSprite(0);
				UUIItem uuiitem = sprite;
				bool bUseChangeColor = num == 0;
				FColor? fcolor = new FColor?(sprite.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
				this.SetRound(num);
				this.SetActive(true);
				return;
			}
			this.SetActive(false);
		}

		// Token: 0x0603CC9E RID: 248990 RVA: 0x00F6FD98 File Offset: 0x00F6DF98
		public void SetRound(int round)
		{
			base.GetText(1).SetText(round.ToString(), true);
		}

		// Token: 0x0200BE79 RID: 48761
		private enum EComponents
		{
			// Token: 0x0403AA66 RID: 240230
			SpriteBg,
			// Token: 0x0403AA67 RID: 240231
			TxtRound
		}
	}
}
