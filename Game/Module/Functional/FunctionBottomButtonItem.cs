using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D1B RID: 23835
	public class FunctionBottomButtonItem : UiPanelBase
	{
		// Token: 0x0603C1AC RID: 246188 RVA: 0x00F3DC0B File Offset: 0x00F3BE0B
		[NullableContext(1)]
		public FunctionBottomButtonItem(UUIItem uiItem, ERedDotName redDotName)
		{
			this.RedDotName = redDotName;
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C1AD RID: 246189 RVA: 0x00F3DC28 File Offset: 0x00F3BE28
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

		// Token: 0x0603C1AE RID: 246190 RVA: 0x00F3DC70 File Offset: 0x00F3BE70
		public void BindRedDot()
		{
			UUIItem item = base.GetItem(0);
			ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName, item, null, 0);
		}

		// Token: 0x0603C1AF RID: 246191 RVA: 0x00F3DC98 File Offset: 0x00F3BE98
		public void UnBindRedDot()
		{
			UUIItem item = base.GetItem(0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName, item, 0);
		}

		// Token: 0x04021BE8 RID: 138216
		private readonly ERedDotName RedDotName;

		// Token: 0x0200BD8C RID: 48524
		private class ECompDefine
		{
			// Token: 0x0403A60D RID: 239117
			public const int RedDot = 0;
		}
	}
}
