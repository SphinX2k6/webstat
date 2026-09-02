using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005AA3 RID: 23203
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class GridTitleItem : SyncGridProxyAbstract<GridTitleItemDataInner>
	{
		// Token: 0x0603AB30 RID: 240432 RVA: 0x00EE0DD8 File Offset: 0x00EDEFD8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB31 RID: 240433 RVA: 0x00EE0E41 File Offset: 0x00EDF041
		[NullableContext(1)]
		public override void Refresh(GridTitleItemDataInner data)
		{
			base.GetText(0).ShowTextNew(data.Title);
			base.GetText(1).SetText(data.Num, true);
		}

		// Token: 0x0200BAA7 RID: 47783
		private enum ETitleComp
		{
			// Token: 0x04039A10 RID: 236048
			TextTitle,
			// Token: 0x04039A11 RID: 236049
			TextNum
		}
	}
}
