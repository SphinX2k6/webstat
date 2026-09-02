using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ED5 RID: 20181
	public class TowerDefensePhantomIconCornerMark : UiPanelBase
	{
		// Token: 0x0603421D RID: 213533 RVA: 0x00D08C24 File Offset: 0x00D06E24
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

		// Token: 0x0603421E RID: 213534 RVA: 0x00D08C6C File Offset: 0x00D06E6C
		[NullableContext(1)]
		public void RefreshColor(string hexColorPath)
		{
			this.SetSpriteByPath(hexColorPath, base.GetSprite(0), false, null, null);
		}

		// Token: 0x0401E1B5 RID: 123317
		private const int MARK_COMPONENT_INDEX = 0;
	}
}
