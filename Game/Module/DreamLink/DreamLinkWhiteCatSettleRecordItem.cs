using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB6 RID: 23990
	public class DreamLinkWhiteCatSettleRecordItem : UiPanelBase
	{
		// Token: 0x0603C668 RID: 247400 RVA: 0x00F54A8C File Offset: 0x00F52C8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C669 RID: 247401 RVA: 0x00F54B18 File Offset: 0x00F52D18
		protected override void OnBeforeShow()
		{
			if (this.Data == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.Data.Title, Array.Empty<object>());
			base.GetText(1).SetText(this.Data.Score, true);
			base.GetItem(2).SetUIActive(this.Data.IsNew);
		}

		// Token: 0x04021F58 RID: 139096
		[Nullable(2)]
		public IDreamLinkRecordData Data;

		// Token: 0x0200BE02 RID: 48642
		private class EDreamLinkWhiteCatSettleRecordItemDefine
		{
			// Token: 0x0403A7E2 RID: 239586
			public const int TxtTitle = 0;

			// Token: 0x0403A7E3 RID: 239587
			public const int TxtContent = 1;

			// Token: 0x0403A7E4 RID: 239588
			public const int NewRecordItem = 2;
		}
	}
}
