using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E9E RID: 28318
	public class GridItem : GridProxyAbstract<int>
	{
		// Token: 0x06044ACC RID: 281292 RVA: 0x011D9A80 File Offset: 0x011D7C80
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044ACD RID: 281293 RVA: 0x011D9AEC File Offset: 0x011D7CEC
		public override void Refresh(int dataId, bool isSelected, int gridIndex)
		{
			bool flag = dataId == -1;
			bool flag2 = dataId > 0;
			UUISprite sprite = base.GetSprite(0);
			sprite.SetUIActive(!flag);
			base.GetSprite(1).SetUIActive(flag);
			UUIItem uuiitem = sprite;
			bool bUseChangeColor = flag2;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0200CB6A RID: 52074
		private class EItemComponents
		{
			// Token: 0x0403E6D2 RID: 255698
			public const int SpriteBg = 0;

			// Token: 0x0403E6D3 RID: 255699
			public const int SpriteBan = 1;
		}
	}
}
