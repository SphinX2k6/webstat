using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005149 RID: 20809
	internal class RoguelikeBossChallengePagePointItem : GridProxyAbstract<bool>
	{
		// Token: 0x060358E4 RID: 219364 RVA: 0x00D71C44 File Offset: 0x00D6FE44
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

		// Token: 0x060358E5 RID: 219365 RVA: 0x00D71C8C File Offset: 0x00D6FE8C
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			this.OnDeselected(false);
		}

		// Token: 0x060358E6 RID: 219366 RVA: 0x00D71C95 File Offset: 0x00D6FE95
		public override void OnSelected(bool fireEvent)
		{
			base.GetItem(0).SetUIActive(true);
		}

		// Token: 0x060358E7 RID: 219367 RVA: 0x00D71CA4 File Offset: 0x00D6FEA4
		public override void OnDeselected(bool fireEvent)
		{
			base.GetItem(0).SetUIActive(false);
		}

		// Token: 0x0200B0E8 RID: 45288
		private class EPagePointComponents
		{
			// Token: 0x04036DFB RID: 224763
			public const int PnlDot = 0;
		}
	}
}
