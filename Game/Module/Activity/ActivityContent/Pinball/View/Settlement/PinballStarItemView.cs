using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065C1 RID: 26049
	public class PinballStarItemView : GridProxyAbstract<bool>
	{
		// Token: 0x06041179 RID: 266617 RVA: 0x010B3A88 File Offset: 0x010B1C88
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

		// Token: 0x0604117A RID: 266618 RVA: 0x010B3AD0 File Offset: 0x010B1CD0
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			this.Refresh(data);
		}

		// Token: 0x0604117B RID: 266619 RVA: 0x010B3AD9 File Offset: 0x010B1CD9
		public void Refresh(bool isActive)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(isActive);
		}

		// Token: 0x0200C5C6 RID: 50630
		private enum EStarItemComponent
		{
			// Token: 0x0403CDFA RID: 249338
			SpriteStar
		}
	}
}
