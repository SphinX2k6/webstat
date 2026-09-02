using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E4F RID: 20047
	public class TrapDefenseShopGoodsPanel : UiPanelBase
	{
		// Token: 0x06033CEC RID: 212204 RVA: 0x00CF3AB0 File Offset: 0x00CF1CB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033CED RID: 212205 RVA: 0x00CF3C01 File Offset: 0x00CF1E01
		protected override void OnStart()
		{
			this.ScrollView = new GenericScrollViewNew<TrapDefenseShopGoodsContainerItem, TrapDefenseShopGoodsListData>(base.GetScrollViewWithScrollbar(5), () => new TrapDefenseShopGoodsContainerItem(), null, false, null);
		}

		// Token: 0x06033CEE RID: 212206 RVA: 0x00CF3C38 File Offset: 0x00CF1E38
		public UniTask RefreshAsync()
		{
			TrapDefenseShopGoodsPanel.<RefreshAsync>d__4 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<TrapDefenseShopGoodsPanel.<RefreshAsync>d__4>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401DFA0 RID: 122784
		[Nullable(1)]
		private GenericScrollViewNew<TrapDefenseShopGoodsContainerItem, TrapDefenseShopGoodsListData> ScrollView;

		// Token: 0x0200ADE7 RID: 44519
		private class EComponentDefine
		{
			// Token: 0x04035FFC RID: 221180
			public const int SpriteShopIcon = 0;

			// Token: 0x04035FFD RID: 221181
			public const int TextShopTitle = 1;

			// Token: 0x04035FFE RID: 221182
			public const int SpriteShopIconBg = 2;

			// Token: 0x04035FFF RID: 221183
			public const int ItemPanel = 3;

			// Token: 0x04036000 RID: 221184
			public const int ItemPanelToggle = 4;

			// Token: 0x04036001 RID: 221185
			public const int ScrollView = 5;

			// Token: 0x04036002 RID: 221186
			public const int BtnConfirm = 6;

			// Token: 0x04036003 RID: 221187
			public const int ItemCaption = 7;

			// Token: 0x04036004 RID: 221188
			public const int TextLimit = 8;
		}
	}
}
