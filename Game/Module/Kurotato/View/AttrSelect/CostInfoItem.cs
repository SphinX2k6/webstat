using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005AD4 RID: 23252
	internal class CostInfoItem : UiPanelBase
	{
		// Token: 0x0603ACAA RID: 240810 RVA: 0x00EE89A8 File Offset: 0x00EE6BA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickTitle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603ACAB RID: 240811 RVA: 0x00EE8A4E File Offset: 0x00EE6C4E
		private void OnClickTitle()
		{
			Action onClickCb = this.OnClickCb;
			if (onClickCb == null)
			{
				return;
			}
			onClickCb();
		}

		// Token: 0x0603ACAC RID: 240812 RVA: 0x00EE8A60 File Offset: 0x00EE6C60
		[NullableContext(1)]
		public void SetOnClickCb(Action cb)
		{
			this.OnClickCb = cb;
		}

		// Token: 0x040213A4 RID: 136100
		[Nullable(2)]
		private Action OnClickCb;

		// Token: 0x0200BAFF RID: 47871
		private class ECostItemComp
		{
			// Token: 0x04039B7F RID: 236415
			public const int BtnTitle = 0;

			// Token: 0x04039B80 RID: 236416
			public const int TextNum = 1;
		}
	}
}
