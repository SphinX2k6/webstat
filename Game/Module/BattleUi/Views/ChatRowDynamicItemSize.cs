using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FFE RID: 24574
	public class ChatRowDynamicItemSize : UiPanelBase, IDynamicScrollBaseItem<ChatRowData>
	{
		// Token: 0x0603DE31 RID: 253489 RVA: 0x00FC8858 File Offset: 0x00FC6A58
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

		// Token: 0x0603DE32 RID: 253490 RVA: 0x00FC88C4 File Offset: 0x00FC6AC4
		[NullableContext(1)]
		public FVector2D GetItemSize(ChatRowData data)
		{
			float width = base.GetItem(1).GetWidth();
			float height = base.GetItem(1).GetHeight();
			return new FVector2D(width, height);
		}

		// Token: 0x0603DE33 RID: 253491 RVA: 0x00FC88F0 File Offset: 0x00FC6AF0
		[NullableContext(1)]
		public UniTask Init(UUIItem actor)
		{
			ChatRowDynamicItemSize.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ChatRowDynamicItemSize.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603DE34 RID: 253492 RVA: 0x00FC893B File Offset: 0x00FC6B3B
		public void ClearItem()
		{
		}

		// Token: 0x0200C087 RID: 49287
		private enum EChild
		{
			// Token: 0x0403B478 RID: 242808
			RootItem,
			// Token: 0x0403B479 RID: 242809
			PanelHorizon
		}
	}
}
