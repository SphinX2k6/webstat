using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ECC RID: 20172
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseLevelDetailElementItem : GridProxyAbstract<string>
	{
		// Token: 0x060341C5 RID: 213445 RVA: 0x00D066B4 File Offset: 0x00D048B4
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

		// Token: 0x060341C6 RID: 213446 RVA: 0x00D066FC File Offset: 0x00D048FC
		[NullableContext(1)]
		public override void Refresh(string data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data, Array.Empty<object>());
		}

		// Token: 0x0200AE6F RID: 44655
		private class ELevelDetailElementItemComponent
		{
			// Token: 0x04036282 RID: 221826
			public const int DescTxt = 0;
		}
	}
}
