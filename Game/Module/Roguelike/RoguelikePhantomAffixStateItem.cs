using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005139 RID: 20793
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikePhantomAffixStateItem : GridProxyAbstract<IRoguelikePhantomAffixStateItemData>
	{
		// Token: 0x0603587B RID: 219259 RVA: 0x00D704E4 File Offset: 0x00D6E6E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603587C RID: 219260 RVA: 0x00D7054D File Offset: 0x00D6E74D
		[NullableContext(1)]
		public override void Refresh(IRoguelikePhantomAffixStateItemData data, bool isSelected, int gridIndex)
		{
			this.SetUnlockState(data.IsUnlock);
		}

		// Token: 0x0603587D RID: 219261 RVA: 0x00D7055B File Offset: 0x00D6E75B
		private void SetUnlockState(bool isUnlock)
		{
			base.GetItem(0).SetUIActive(isUnlock);
			base.GetItem(1).SetUIActive(!isUnlock);
		}

		// Token: 0x0200B0D9 RID: 45273
		private class EComponents
		{
			// Token: 0x04036DC5 RID: 224709
			public const int SprConfirm = 0;

			// Token: 0x04036DC6 RID: 224710
			public const int SprDis = 1;
		}
	}
}
