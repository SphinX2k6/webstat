using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006424 RID: 25636
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeLevelInfoItem : GridProxyAbstract<RoverlikeLevelInfoItemData>
	{
		// Token: 0x060405A2 RID: 263586 RVA: 0x0107E920 File Offset: 0x0107CB20
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060405A3 RID: 263587 RVA: 0x0107E968 File Offset: 0x0107CB68
		public override void Refresh(RoverlikeLevelInfoItemData data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TextId, data.Params);
		}

		// Token: 0x060405A4 RID: 263588 RVA: 0x0107E998 File Offset: 0x0107CB98
		public void PlayRefreshAnim()
		{
		}

		// Token: 0x060405A5 RID: 263589 RVA: 0x0107E99A File Offset: 0x0107CB9A
		public override object GetKey(RoverlikeLevelInfoItemData data, int gridIndex)
		{
			return gridIndex;
		}

		// Token: 0x0200C48E RID: 50318
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C7FB RID: 247803
			public const int TxtInfo = 0;
		}
	}
}
