using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067B7 RID: 26551
	[NullableContext(1)]
	[Nullable(0)]
	public class ListLayout : UiPanelBase
	{
		// Token: 0x060423AC RID: 271276 RVA: 0x010FD994 File Offset: 0x010FBB94
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060423AD RID: 271277 RVA: 0x010FDA00 File Offset: 0x010FBC00
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<ListItem, int>(base.GetLayoutBase(0), new Func<ListItem>(this.InitItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
			this.GridWidth = base.GetItem(1).GetWidth();
		}

		// Token: 0x060423AE RID: 271278 RVA: 0x010FDA50 File Offset: 0x010FBC50
		private ListItem InitItem()
		{
			return new ListItem();
		}

		// Token: 0x060423AF RID: 271279 RVA: 0x010FDA58 File Offset: 0x010FBC58
		public UniTask RefreshAsync(List<List<int>> dataDoublyList, int qualityId)
		{
			ListLayout.<RefreshAsync>d__6 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.dataDoublyList = dataDoublyList;
			<RefreshAsync>d__.qualityId = qualityId;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<ListLayout.<RefreshAsync>d__6>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04024E39 RID: 151097
		protected GenericLayout<ListItem, int> Layout;

		// Token: 0x04024E3A RID: 151098
		protected float GridWidth;

		// Token: 0x0200C7E4 RID: 51172
		[NullableContext(0)]
		private class EListLayout
		{
			// Token: 0x0403D869 RID: 252009
			public const int LayoutItem = 0;

			// Token: 0x0403D86A RID: 252010
			public const int GridItem = 1;
		}
	}
}
