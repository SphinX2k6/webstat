using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200519B RID: 20891
	public class RoguelikeSelectSpecialStarItem : GridProxyAbstract<bool>
	{
		// Token: 0x06035BB6 RID: 220086 RVA: 0x00D815CC File Offset: 0x00D7F7CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035BB7 RID: 220087 RVA: 0x00D81614 File Offset: 0x00D7F814
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			base.GetItem(0).SetUIActive(data);
		}

		// Token: 0x0200B165 RID: 45413
		private class EComponent
		{
			// Token: 0x04037030 RID: 225328
			public const int StarObj = 0;
		}
	}
}
