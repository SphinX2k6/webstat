using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E4D RID: 20045
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseShopGoodsDetailPanel : UiPanelBase
	{
		// Token: 0x06033CDD RID: 212189 RVA: 0x00CF378C File Offset: 0x00CF198C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033CDE RID: 212190 RVA: 0x00CF38BC File Offset: 0x00CF1ABC
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseShopGoodsDetailPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseShopGoodsDetailPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033CDF RID: 212191 RVA: 0x00CF38FF File Offset: 0x00CF1AFF
		protected override void OnStart()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelShop.AddOnSelectGoodsDelegate(new Action<ITrapDefenseShopGoods>(this.OnSelectGoods));
		}

		// Token: 0x06033CE0 RID: 212192 RVA: 0x00CF391C File Offset: 0x00CF1B1C
		protected override void OnBeforeDestroy()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelShop.RemoveOnSelectGoodsDelegate(new Action<ITrapDefenseShopGoods>(this.OnSelectGoods));
		}

		// Token: 0x06033CE1 RID: 212193 RVA: 0x00CF3939 File Offset: 0x00CF1B39
		public void RefreshPanel(ITrapDefenseShopGoods data)
		{
			if (data == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
		}

		// Token: 0x06033CE2 RID: 212194 RVA: 0x00CF395B File Offset: 0x00CF1B5B
		private void OnConfirmButtonClick(int _)
		{
		}

		// Token: 0x06033CE3 RID: 212195 RVA: 0x00CF395D File Offset: 0x00CF1B5D
		private void OnSelectGoods(ITrapDefenseShopGoods goods)
		{
			this.RefreshPanel(goods);
		}

		// Token: 0x0401DF9E RID: 122782
		private ButtonItem Button;

		// Token: 0x0200ADE5 RID: 44517
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04035FF0 RID: 221168
			public const int TextName = 0;

			// Token: 0x04035FF1 RID: 221169
			public const int TextHave = 1;

			// Token: 0x04035FF2 RID: 221170
			public const int ItemPurchase = 2;

			// Token: 0x04035FF3 RID: 221171
			public const int ItemConfirmBtn = 3;

			// Token: 0x04035FF4 RID: 221172
			public const int ItemDetail = 4;

			// Token: 0x04035FF5 RID: 221173
			public const int TextBtn = 5;

			// Token: 0x04035FF6 RID: 221174
			public const int ItemUnavailable = 6;

			// Token: 0x04035FF7 RID: 221175
			public const int TextUnavailable = 7;
		}
	}
}
