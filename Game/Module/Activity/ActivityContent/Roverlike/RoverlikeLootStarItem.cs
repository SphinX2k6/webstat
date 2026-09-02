using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200642C RID: 25644
	public class RoverlikeLootStarItem : RoverlikeMultiUseGridProxyAbstract<bool>
	{
		// Token: 0x06040614 RID: 263700 RVA: 0x010811A8 File Offset: 0x0107F3A8
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

		// Token: 0x06040615 RID: 263701 RVA: 0x010811F0 File Offset: 0x0107F3F0
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(data);
		}

		// Token: 0x0200C49B RID: 50331
		private class EComponents
		{
			// Token: 0x0403C848 RID: 247880
			public const int SpLight = 0;
		}
	}
}
