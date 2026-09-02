using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Level
{
	// Token: 0x02006606 RID: 26118
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballLevelStarItem : GridProxyAbstract<IPinballLevelStarData>
	{
		// Token: 0x06041430 RID: 267312 RVA: 0x010BE598 File Offset: 0x010BC798
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

		// Token: 0x06041431 RID: 267313 RVA: 0x010BE5E0 File Offset: 0x010BC7E0
		[NullableContext(1)]
		public override void Refresh(IPinballLevelStarData data, bool isSelected, int gridIndex)
		{
			base.GetSprite(0).SetUIActive(data.Passed);
		}

		// Token: 0x0200C628 RID: 50728
		private enum EStarComponent
		{
			// Token: 0x0403CFF5 RID: 249845
			SprStar
		}
	}
}
