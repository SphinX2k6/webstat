using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB0 RID: 23984
	public class DreamLinkWhiteCatSettlePanel : UiPanelBase
	{
		// Token: 0x0603C647 RID: 247367 RVA: 0x00F54890 File Offset: 0x00F52A90
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C648 RID: 247368 RVA: 0x00F548FC File Offset: 0x00F52AFC
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkWhiteCatSettlePanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkWhiteCatSettlePanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C649 RID: 247369 RVA: 0x00F5493F File Offset: 0x00F52B3F
		[NullableContext(1)]
		protected DreamLinkWhiteCatSettleItem OnCreateItem()
		{
			return new DreamLinkWhiteCatSettleItem();
		}

		// Token: 0x04021F4F RID: 139087
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericScrollViewNew<DreamLinkWhiteCatSettleItem, IDreamLinkReachedData> Layout;

		// Token: 0x04021F50 RID: 139088
		[Nullable(2)]
		protected DreamLinkWhiteCatSettleRecordItem RecordPanel;

		// Token: 0x04021F51 RID: 139089
		[Nullable(2)]
		public RogueBossLinkSettleNotify Data;

		// Token: 0x0200BDFF RID: 48639
		private class EChildType
		{
			// Token: 0x0403A7D9 RID: 239577
			public const int BarVerticalItem = 0;

			// Token: 0x0403A7DA RID: 239578
			public const int RecordItem = 1;
		}
	}
}
