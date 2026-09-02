using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200641E RID: 25630
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeGameShopInfoItem : UiPanelBase
	{
		// Token: 0x06040570 RID: 263536 RVA: 0x0107D7B2 File Offset: 0x0107B9B2
		[NullableContext(1)]
		public void BindOnConfirm(Action cb)
		{
			this.OnConfirm = cb;
		}

		// Token: 0x06040571 RID: 263537 RVA: 0x0107D7BB File Offset: 0x0107B9BB
		public void SetCurrencyContext(int insideCurrencyItemId)
		{
			this.InsideCurrencyItemId = insideCurrencyItemId;
		}

		// Token: 0x06040572 RID: 263538 RVA: 0x0107D7C4 File Offset: 0x0107B9C4
		public void Refresh(IRoverlikeGameShopGridData data)
		{
			if (data == null)
			{
				base.SetUiActive(false);
				return;
			}
			RoverRogueItem? itemConfig = ConfigBase<RoverlikeConfig>.Instance.GetItemConfig(data.ShowItemId);
			if (itemConfig == null)
			{
				base.SetUiActive(false);
				return;
			}
			base.SetUiActive(true);
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, itemConfig.Value.Name, Array.Empty<object>());
			UUIText text2 = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, itemConfig.Value.Type, Array.Empty<object>());
			UUIText text3 = base.GetText(2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, itemConfig.Value.Desc, itemConfig.Value.DescParams());
			UUIText text4 = base.GetText(8);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text4, "RoverRogue_ItemDurationOutGame", new <>z__ReadOnlySingleElementList<object>(itemConfig.Value.RoomPassedRequired));
			text4.SetUIActive(itemConfig.Value.Classify == 2);
			int gold = ModelBase<RoverlikeModel>.Instance.Gold;
			RoverlikeGameShopCostItem storeCost = this.StoreCost;
			if (storeCost != null)
			{
				storeCost.Refresh(data, this.InsideCurrencyItemId, gold);
			}
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!data.IsBought);
		}

		// Token: 0x06040573 RID: 263539 RVA: 0x0107D916 File Offset: 0x0107BB16
		private void OnClickConfirm()
		{
			Action onConfirm = this.OnConfirm;
			if (onConfirm == null)
			{
				return;
			}
			onConfirm();
		}

		// Token: 0x06040574 RID: 263540 RVA: 0x0107D928 File Offset: 0x0107BB28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040575 RID: 263541 RVA: 0x0107DA7C File Offset: 0x0107BC7C
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeGameShopInfoItem.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeGameShopInfoItem.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040576 RID: 263542 RVA: 0x0107DABF File Offset: 0x0107BCBF
		protected override void OnStart()
		{
			ButtonItem confirmBtn = this.ConfirmBtn;
			if (confirmBtn == null)
			{
				return;
			}
			confirmBtn.SetFunction(delegate(int _)
			{
				this.OnClickConfirm();
			});
		}

		// Token: 0x06040577 RID: 263543 RVA: 0x0107DADD File Offset: 0x0107BCDD
		protected override void OnBeforeDestroy()
		{
			this.OnConfirm = null;
		}

		// Token: 0x040240D8 RID: 147672
		private ButtonItem ConfirmBtn;

		// Token: 0x040240D9 RID: 147673
		private RoverlikeGameShopCostItem StoreCost;

		// Token: 0x040240DA RID: 147674
		private Action OnConfirm;

		// Token: 0x040240DB RID: 147675
		private int InsideCurrencyItemId;

		// Token: 0x0200C487 RID: 50311
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C7DB RID: 247771
			public const int TxtName = 0;

			// Token: 0x0403C7DC RID: 247772
			public const int TxtType = 1;

			// Token: 0x0403C7DD RID: 247773
			public const int TxtDesc = 2;

			// Token: 0x0403C7DE RID: 247774
			public const int BtnConfirm = 3;

			// Token: 0x0403C7DF RID: 247775
			public const int ItemStoreCost = 4;

			// Token: 0x0403C7E0 RID: 247776
			public const int TextureCostIcon = 5;

			// Token: 0x0403C7E1 RID: 247777
			public const int TxtCost = 6;

			// Token: 0x0403C7E2 RID: 247778
			public const int TxtPlace = 7;

			// Token: 0x0403C7E3 RID: 247779
			public const int TxtItemRound = 8;
		}
	}
}
