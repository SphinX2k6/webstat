using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.View.AttrSelect;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Shop
{
	// Token: 0x02005A74 RID: 23156
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoShopSelectCard : GridProxyAbstract<IKurotatoShopSelectCardData>
	{
		// Token: 0x0603A98F RID: 240015 RVA: 0x00ED7A7C File Offset: 0x00ED5C7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickConfirm));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A990 RID: 240016 RVA: 0x00ED7BA8 File Offset: 0x00ED5DA8
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoShopSelectCard.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoShopSelectCard.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A991 RID: 240017 RVA: 0x00ED7BEB File Offset: 0x00ED5DEB
		public void SetConfirmCb(Action<int> cb)
		{
			this.ConfirmCb = cb;
		}

		// Token: 0x0603A992 RID: 240018 RVA: 0x00ED7BF4 File Offset: 0x00ED5DF4
		public void SetBuildTagClickCb(Action<int, EToggleState> cb)
		{
			this.BuildTagClickCb = cb;
		}

		// Token: 0x0603A993 RID: 240019 RVA: 0x00ED7BFD File Offset: 0x00ED5DFD
		public void SetAttrPreviewCb(Action<int, bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> cb)
		{
			this.AttrPreviewCb = cb;
		}

		// Token: 0x0603A994 RID: 240020 RVA: 0x00ED7C06 File Offset: 0x00ED5E06
		public void ClearAttrPreviewSelection()
		{
			this.CardInfoItem.ClearAttrPreviewSelection();
		}

		// Token: 0x0603A995 RID: 240021 RVA: 0x00ED7C13 File Offset: 0x00ED5E13
		public override void Refresh(IKurotatoShopSelectCardData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshCardInfo();
		}

		// Token: 0x0603A996 RID: 240022 RVA: 0x00ED7C24 File Offset: 0x00ED5E24
		public void RefreshCurrencyState()
		{
			if (this.Data == null)
			{
				return;
			}
			int currencyCount = ModelBase<KurotatoModel>.Instance.BattleData.GetCurrencyCount();
			base.GetButton(1).SetSelfInteractive(currencyCount >= this.Data.Cost);
			UUIText text = base.GetText(3);
			UUIItem uuiitem = text;
			bool bUseChangeColor = currencyCount < this.Data.Cost;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0603A997 RID: 240023 RVA: 0x00ED7C91 File Offset: 0x00ED5E91
		public void SetComposeUpgradeVisible(bool visible)
		{
			this.CardInfoItem.SetComposeUpgradeVisible(visible);
		}

		// Token: 0x0603A998 RID: 240024 RVA: 0x00ED7C9F File Offset: 0x00ED5E9F
		public void RefreshBuildTagLevel()
		{
			this.CardInfoItem.RefreshBuildTagLevel();
		}

		// Token: 0x0603A999 RID: 240025 RVA: 0x00ED7CAC File Offset: 0x00ED5EAC
		public void RefreshHoldNum()
		{
			this.CardInfoItem.RefreshHoldNum();
		}

		// Token: 0x0603A99A RID: 240026 RVA: 0x00ED7CBC File Offset: 0x00ED5EBC
		private void RefreshCardInfo()
		{
			this.CardInfoItem.Refresh(new KurotatoCardItemData
			{
				Id = this.Data.Id,
				SelectionId = this.Data.SelectionId,
				HasBuy = this.Data.HasBuy,
				IsRecommend = this.Data.IsRecommend,
				CardType = this.Data.CardType,
				HasLock = this.Data.IsLock,
				ShowLock = true,
				Cost = this.Data.Cost
			});
			this.CardInfoItem.SetLockToggleCb(new Action<int, bool>(this.OnToggleClickLock));
			this.CardInfoItem.SetBuildTagClickCb(new Action<EToggleState>(this.OnClickBuildTag));
			this.CardInfoItem.SetAttrPreviewCb(new Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>>(this.OnAttrPreview));
			base.GetText(3).SetText(this.Data.Cost.ToString(), true);
			base.GetItem(4).SetUIActive(this.Data.HasBuy);
			base.GetButton(1).GetRootComponent().SetUIActive(!this.Data.HasBuy);
			base.GetText(5).SetText(this.Data.OriginalCost.ToString(), true);
			base.GetText(5).SetUIActive(this.Data.OriginalCost > this.Data.Cost);
			this.RefreshCurrencyState();
		}

		// Token: 0x0603A99B RID: 240027 RVA: 0x00ED7E3C File Offset: 0x00ED603C
		private void OnClickConfirm()
		{
			if (ModelBase<KurotatoModel>.Instance.BattleData.GetCurrencyCount() >= this.Data.Cost)
			{
				Action<int> confirmCb = this.ConfirmCb;
				if (confirmCb == null)
				{
					return;
				}
				confirmCb(this.Data.SelectionId);
			}
		}

		// Token: 0x0603A99C RID: 240028 RVA: 0x00ED7E75 File Offset: 0x00ED6075
		private void OnToggleClickLock(int selectionId, bool isLock)
		{
			ControllerBase<KurotatoController>.Instance.RequestKurotatoShopRewardLock(selectionId).Forget<bool>();
		}

		// Token: 0x0603A99D RID: 240029 RVA: 0x00ED7E87 File Offset: 0x00ED6087
		public void ClearBuildTagSelection()
		{
			this.CardInfoItem.ClearBuildTagSelection();
		}

		// Token: 0x0603A99E RID: 240030 RVA: 0x00ED7E94 File Offset: 0x00ED6094
		public void CloseBuildInfo()
		{
			this.CardInfoItem.CloseBuildInfo();
		}

		// Token: 0x0603A99F RID: 240031 RVA: 0x00ED7EA1 File Offset: 0x00ED60A1
		public int GetSelectionId()
		{
			IKurotatoShopSelectCardData data = this.Data;
			if (data == null)
			{
				return 0;
			}
			return data.SelectionId;
		}

		// Token: 0x0603A9A0 RID: 240032 RVA: 0x00ED7EB4 File Offset: 0x00ED60B4
		private void OnClickBuildTag(EToggleState state)
		{
			Action<int, EToggleState> buildTagClickCb = this.BuildTagClickCb;
			if (buildTagClickCb == null)
			{
				return;
			}
			buildTagClickCb(this.Data.SelectionId, state);
		}

		// Token: 0x0603A9A1 RID: 240033 RVA: 0x00ED7ED2 File Offset: 0x00ED60D2
		private void OnAttrPreview(bool active, IReadOnlyList<IKurotatoAttrPreviewDelta> deltas)
		{
			Action<int, bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
			if (attrPreviewCb == null)
			{
				return;
			}
			attrPreviewCb(this.Data.SelectionId, active, deltas);
		}

		// Token: 0x0603A9A2 RID: 240034 RVA: 0x00ED7EF1 File Offset: 0x00ED60F1
		public bool IsRecommend()
		{
			IKurotatoShopSelectCardData data = this.Data;
			return data != null && data.IsRecommend;
		}

		// Token: 0x0603A9A3 RID: 240035 RVA: 0x00ED7F04 File Offset: 0x00ED6104
		public bool HasBuildTag()
		{
			return this.CardInfoItem.HasBuildTag();
		}

		// Token: 0x0603A9A4 RID: 240036 RVA: 0x00ED7F14 File Offset: 0x00ED6114
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "ShopCard")
			{
				UUIItem rootItem = base.GetRootItem();
				if (rootItem == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					rootItem,
					rootItem
				};
			}
			else
			{
				if (a == "ShopRecommend" || a == "ShopCardLock" || a == "ShopBuildTag" || a == "ShopCardDes")
				{
					return this.CardInfoItem.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
				return null;
			}
		}

		// Token: 0x04021276 RID: 135798
		[Nullable(2)]
		private IKurotatoShopSelectCardData Data;

		// Token: 0x04021277 RID: 135799
		private readonly KurotatoCardInfoItem CardInfoItem = new KurotatoCardInfoItem();

		// Token: 0x04021278 RID: 135800
		[Nullable(2)]
		private Action<int> ConfirmCb;

		// Token: 0x04021279 RID: 135801
		[Nullable(2)]
		private Action<int, EToggleState> BuildTagClickCb;

		// Token: 0x0402127A RID: 135802
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<int, bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> AttrPreviewCb;

		// Token: 0x0200BA3A RID: 47674
		[NullableContext(0)]
		private class EChildComp
		{
			// Token: 0x04039828 RID: 235560
			public const int CardInfoItem = 0;

			// Token: 0x04039829 RID: 235561
			public const int ButtonConfirm = 1;

			// Token: 0x0403982A RID: 235562
			public const int TextureItemIcon = 2;

			// Token: 0x0403982B RID: 235563
			public const int TextNum = 3;

			// Token: 0x0403982C RID: 235564
			public const int PanelDone = 4;

			// Token: 0x0403982D RID: 235565
			public const int TextDiscount = 5;
		}
	}
}
