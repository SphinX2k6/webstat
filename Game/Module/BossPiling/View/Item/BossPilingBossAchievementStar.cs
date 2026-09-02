using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F03 RID: 24323
	public class BossPilingBossAchievementStar : GridProxyAbstract<bool>
	{
		// Token: 0x0603D19F RID: 250271 RVA: 0x00F85118 File Offset: 0x00F83318
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

		// Token: 0x0603D1A0 RID: 250272 RVA: 0x00F85181 File Offset: 0x00F83381
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(data);
		}

		// Token: 0x0200BF05 RID: 48901
		private enum EStar
		{
			// Token: 0x0403ACB1 RID: 240817
			SpriteBg,
			// Token: 0x0403ACB2 RID: 240818
			SpriteStar
		}
	}
}
