using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD9 RID: 24537
	public class ItemUseComponent : GridProxyAbstract<bool>
	{
		// Token: 0x0603DBE1 RID: 252897 RVA: 0x00FBA9AC File Offset: 0x00FB8BAC
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

		// Token: 0x0603DBE2 RID: 252898 RVA: 0x00FBA9F4 File Offset: 0x00FB8BF4
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			this.SetSpriteVisible(data);
		}

		// Token: 0x0603DBE3 RID: 252899 RVA: 0x00FBA9FD File Offset: 0x00FB8BFD
		public void SetSpriteVisible(bool bVisible)
		{
			base.GetSprite(0).SetUIActive(bVisible);
		}

		// Token: 0x0200C04E RID: 49230
		private enum EItemUseItem
		{
			// Token: 0x0403B30E RID: 242446
			PointSprite
		}
	}
}
