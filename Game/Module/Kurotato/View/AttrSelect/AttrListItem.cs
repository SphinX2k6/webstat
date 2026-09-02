using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005ACA RID: 23242
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class AttrListItem : GridProxyAbstract<string>
	{
		// Token: 0x0603AC41 RID: 240705 RVA: 0x00EE66E0 File Offset: 0x00EE48E0
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

		// Token: 0x0603AC42 RID: 240706 RVA: 0x00EE6728 File Offset: 0x00EE4928
		[NullableContext(1)]
		public override void Refresh(string data, bool isSelected, int gridIndex)
		{
			base.GetText(0).SetText(data, true);
		}

		// Token: 0x0200BAE8 RID: 47848
		private class EAttrListItemComp
		{
			// Token: 0x04039B14 RID: 236308
			public const int TextDes = 0;
		}
	}
}
