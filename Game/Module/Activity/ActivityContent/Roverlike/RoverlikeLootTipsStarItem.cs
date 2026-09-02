using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006401 RID: 25601
	public class RoverlikeLootTipsStarItem : GridProxyAbstract<bool>
	{
		// Token: 0x06040470 RID: 263280 RVA: 0x01079494 File Offset: 0x01077694
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

		// Token: 0x06040471 RID: 263281 RVA: 0x010794FD File Offset: 0x010776FD
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(data);
			}
			UUISprite sprite2 = base.GetSprite(1);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetUIActive(!data);
		}

		// Token: 0x0200C468 RID: 50280
		private class EComponents
		{
			// Token: 0x0403C74F RID: 247631
			public const int ImgStar = 0;

			// Token: 0x0403C750 RID: 247632
			public const int ImgStarOff = 1;
		}
	}
}
