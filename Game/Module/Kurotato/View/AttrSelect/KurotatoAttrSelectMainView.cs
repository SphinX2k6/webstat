using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005ACB RID: 23243
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoAttrSelectMainView : UiViewBase
	{
		// Token: 0x0603AC44 RID: 240708 RVA: 0x00EE6740 File Offset: 0x00EE4940
		public KurotatoAttrSelectMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AC45 RID: 240709 RVA: 0x00EE6754 File Offset: 0x00EE4954
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickRefresh));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AC46 RID: 240710 RVA: 0x00EE689F File Offset: 0x00EE4A9F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnUpgradeRewardDataChanged, new Action(this.OnUpgradeRewardChanged));
		}

		// Token: 0x0603AC47 RID: 240711 RVA: 0x00EE68BD File Offset: 0x00EE4ABD
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnUpgradeRewardDataChanged, new Action(this.OnUpgradeRewardChanged));
		}

		// Token: 0x0603AC48 RID: 240712 RVA: 0x00EE68DC File Offset: 0x00EE4ADC
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoAttrSelectMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoAttrSelectMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC49 RID: 240713 RVA: 0x00EE6920 File Offset: 0x00EE4B20
		private UniTask CreatePopupPanel()
		{
			KurotatoAttrSelectMainView.<CreatePopupPanel>d__9 <CreatePopupPanel>d__;
			<CreatePopupPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreatePopupPanel>d__.<>4__this = this;
			<CreatePopupPanel>d__.<>1__state = -1;
			<CreatePopupPanel>d__.<>t__builder.Start<KurotatoAttrSelectMainView.<CreatePopupPanel>d__9>(ref <CreatePopupPanel>d__);
			return <CreatePopupPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC4A RID: 240714 RVA: 0x00EE6963 File Offset: 0x00EE4B63
		private void CreateAttrSelectLayout()
		{
			this.AttrSelectLayout = new GenericLayout<KurotatoAttrSelectCard, IKurotatoAttrSelectCardData>(base.GetHorizontalLayout(2), delegate()
			{
				KurotatoAttrSelectCard kurotatoAttrSelectCard = new KurotatoAttrSelectCard();
				kurotatoAttrSelectCard.SetFunctionCb(new Action<int>(this.OnClickSelectFunction));
				kurotatoAttrSelectCard.SetAttrPreviewCb(new Action<int, bool, IReadOnlyList<IKurotatoAttrPreviewDelta>>(this.OnCardAttrPreview));
				return kurotatoAttrSelectCard;
			}, null, false, true);
		}

		// Token: 0x0603AC4B RID: 240715 RVA: 0x00EE6986 File Offset: 0x00EE4B86
		protected override void OnStart()
		{
			this.RefreshAttrSelectLayout();
			this.RefreshBtnRefresh();
			this.RefreshChangeNum();
			this.CommonPopupPanel.SetTitleLocalText("Kurotato_LevelUp_Title");
		}

		// Token: 0x0603AC4C RID: 240716 RVA: 0x00EE69AA File Offset: 0x00EE4BAA
		protected override void OnBeforeShow()
		{
			this.CommonPopupPanel.HideAttrChangeFx();
			this.OnUpgradeRewardChanged();
		}

		// Token: 0x0603AC4D RID: 240717 RVA: 0x00EE69C0 File Offset: 0x00EE4BC0
		private void RefreshAttrSelectLayout()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			KurotatoConfig kurotatoConfig = ConfigBase<KurotatoConfig>.Instance;
			int roleId = instance.GetRoleId();
			KurotatoCharacter? characterById = kurotatoConfig.GetCharacterById(roleId);
			List<string> roleTags = ((characterById != null) ? characterById.GetValueOrDefault().RecommendedTagsIter().ToList<string>() : null) ?? new List<string>();
			List<int> excludedItemIds = ((characterById != null) ? characterById.GetValueOrDefault().ExcludedRecommendItemIdsIter().ToList<int>() : null) ?? new List<int>();
			this.CommonPopupPanel.ClearAttrPreview();
			GenericLayout<KurotatoAttrSelectCard, IKurotatoAttrSelectCardData> attrSelectLayout = this.AttrSelectLayout;
			foreach (KurotatoAttrSelectCard kurotatoAttrSelectCard in (((attrSelectLayout != null) ? attrSelectLayout.GetLayoutItemList() : null) ?? new List<KurotatoAttrSelectCard>()))
			{
				kurotatoAttrSelectCard.ClearAttrPreviewSelection();
			}
			this.AttrSelectLayout.RefreshByData(instance.GetUpgradeRewardData().Select(delegate(KurotatoItemRewardPbData item)
			{
				KurotatoItem? kurotatoItem;
				List<string> itemTags = ((kurotatoConfig.GetItemConfigByItemId(item.ItemId) != null) ? kurotatoItem.GetValueOrDefault().TagsIter().ToList<string>() : null) ?? new List<string>();
				bool flag = excludedItemIds.Contains(item.ItemId);
				return new KurotatoAttrSelectCardData
				{
					ItemId = item.ItemId,
					SelectionId = item.SelectionId,
					IsRecommend = (!flag && roleTags.Any((string tag) => itemTags.Contains(tag))),
					SelectType = EKurotatoAttrSelectType.Upgrade
				};
			}).ToList<IKurotatoAttrSelectCardData>(), null, true);
		}

		// Token: 0x0603AC4E RID: 240718 RVA: 0x00EE6AE8 File Offset: 0x00EE4CE8
		private void ClearAttrSelectLayout()
		{
			this.CommonPopupPanel.ClearAttrPreview();
			GenericLayout<KurotatoAttrSelectCard, IKurotatoAttrSelectCardData> attrSelectLayout = this.AttrSelectLayout;
			if (attrSelectLayout == null)
			{
				return;
			}
			attrSelectLayout.RefreshByData(new List<IKurotatoAttrSelectCardData>(), null, false);
		}

		// Token: 0x0603AC4F RID: 240719 RVA: 0x00EE6B0C File Offset: 0x00EE4D0C
		private void RefreshBtnRefresh()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			int refreshCost = instance.GetRefreshCost();
			UUIText text = base.GetText(5);
			text.SetText(refreshCost.ToString(), true);
			base.GetText(6).SetUIActive(false);
			bool flag = instance.BattleData.GetCurrencyCount() < refreshCost;
			base.GetButton(4).SetSelfInteractive(!flag);
			UUIItem uuiitem = text;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0603AC50 RID: 240720 RVA: 0x00EE6B7C File Offset: 0x00EE4D7C
		private void RefreshChangeNum()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			int upgradeRewardIndex = instance.GetUpgradeRewardIndex();
			int upgradeRewardCount = instance.GetUpgradeRewardCount();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Kurotato_Levelchoose", new <>z__ReadOnlyArray<object>(new object[]
			{
				upgradeRewardIndex.ToString(),
				upgradeRewardCount.ToString()
			}));
		}

		// Token: 0x0603AC51 RID: 240721 RVA: 0x00EE6BD0 File Offset: 0x00EE4DD0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length < 2 || configParams[0] != "UpgradeRecommend")
			{
				return null;
			}
			int num;
			if (!int.TryParse(configParams[1], out num))
			{
				return null;
			}
			int num2 = num - 1;
			if (num2 < 0)
			{
				return null;
			}
			KurotatoAttrSelectCard nthRecommendCard = this.GetNthRecommendCard(num2);
			if (nthRecommendCard == null)
			{
				return null;
			}
			return nthRecommendCard.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603AC52 RID: 240722 RVA: 0x00EE6C20 File Offset: 0x00EE4E20
		[NullableContext(2)]
		private KurotatoAttrSelectCard GetNthRecommendCard(int idx)
		{
			int num = 0;
			GenericLayout<KurotatoAttrSelectCard, IKurotatoAttrSelectCardData> attrSelectLayout = this.AttrSelectLayout;
			foreach (KurotatoAttrSelectCard kurotatoAttrSelectCard in (((attrSelectLayout != null) ? attrSelectLayout.GetLayoutItemList() : null) ?? new List<KurotatoAttrSelectCard>()))
			{
				if (kurotatoAttrSelectCard.IsRecommend())
				{
					if (num == idx)
					{
						return kurotatoAttrSelectCard;
					}
					num++;
				}
			}
			return null;
		}

		// Token: 0x0603AC53 RID: 240723 RVA: 0x00EE6C9C File Offset: 0x00EE4E9C
		private void OnClickRefresh()
		{
			if (this.RequestPending)
			{
				return;
			}
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			if (instance.BattleData.GetCurrencyCount() < instance.GetRefreshCost())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Kurotato_Insufficient_Gold_Coins", Array.Empty<object>());
				return;
			}
			this.RequestPending = true;
			this.RequestRefreshAsync().Forget();
		}

		// Token: 0x0603AC54 RID: 240724 RVA: 0x00EE6CF4 File Offset: 0x00EE4EF4
		private UniTask RequestRefreshAsync()
		{
			KurotatoAttrSelectMainView.<RequestRefreshAsync>d__20 <RequestRefreshAsync>d__;
			<RequestRefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRefreshAsync>d__.<>4__this = this;
			<RequestRefreshAsync>d__.<>1__state = -1;
			<RequestRefreshAsync>d__.<>t__builder.Start<KurotatoAttrSelectMainView.<RequestRefreshAsync>d__20>(ref <RequestRefreshAsync>d__);
			return <RequestRefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC55 RID: 240725 RVA: 0x00EE6D37 File Offset: 0x00EE4F37
		private void OnClickSelectFunction(int selectionId)
		{
			this.OnClickSelectFunctionImpAsync(selectionId).Forget();
		}

		// Token: 0x0603AC56 RID: 240726 RVA: 0x00EE6D48 File Offset: 0x00EE4F48
		private UniTask OnClickSelectFunctionImpAsync(int selectionId)
		{
			KurotatoAttrSelectMainView.<OnClickSelectFunctionImpAsync>d__22 <OnClickSelectFunctionImpAsync>d__;
			<OnClickSelectFunctionImpAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnClickSelectFunctionImpAsync>d__.<>4__this = this;
			<OnClickSelectFunctionImpAsync>d__.selectionId = selectionId;
			<OnClickSelectFunctionImpAsync>d__.<>1__state = -1;
			<OnClickSelectFunctionImpAsync>d__.<>t__builder.Start<KurotatoAttrSelectMainView.<OnClickSelectFunctionImpAsync>d__22>(ref <OnClickSelectFunctionImpAsync>d__);
			return <OnClickSelectFunctionImpAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC57 RID: 240727 RVA: 0x00EE6D93 File Offset: 0x00EE4F93
		private void OnUpgradeRewardChanged()
		{
			this.RequestPending = false;
			this.RefreshAttrSelectLayout();
			this.RefreshBtnRefresh();
			this.RefreshChangeNum();
		}

		// Token: 0x0603AC58 RID: 240728 RVA: 0x00EE6DB0 File Offset: 0x00EE4FB0
		private void OnCardAttrPreview(int selectionId, bool active, IReadOnlyList<IKurotatoAttrPreviewDelta> deltas)
		{
			if (!active)
			{
				this.CommonPopupPanel.ClearAttrPreview();
				return;
			}
			this.CommonPopupPanel.ShowAttrPreview(deltas);
			GenericLayout<KurotatoAttrSelectCard, IKurotatoAttrSelectCardData> attrSelectLayout = this.AttrSelectLayout;
			foreach (KurotatoAttrSelectCard kurotatoAttrSelectCard in (((attrSelectLayout != null) ? attrSelectLayout.GetLayoutItemList() : null) ?? new List<KurotatoAttrSelectCard>()))
			{
				if (kurotatoAttrSelectCard.GetSelectionId() != selectionId)
				{
					kurotatoAttrSelectCard.ClearAttrPreviewSelection();
				}
			}
		}

		// Token: 0x0402138F RID: 136079
		private readonly KurotatoCommonPopupPanel CommonPopupPanel = new KurotatoCommonPopupPanel();

		// Token: 0x04021390 RID: 136080
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoAttrSelectCard, IKurotatoAttrSelectCardData> AttrSelectLayout;

		// Token: 0x04021391 RID: 136081
		private bool RequestPending;

		// Token: 0x0200BAE9 RID: 47849
		[NullableContext(0)]
		private class EChildComp
		{
			// Token: 0x04039B15 RID: 236309
			public const int CommonPopupPanel = 0;

			// Token: 0x04039B16 RID: 236310
			public const int TextChangeNum = 1;

			// Token: 0x04039B17 RID: 236311
			public const int HorizontalLayoutAttr = 2;

			// Token: 0x04039B18 RID: 236312
			public const int CardItem = 3;

			// Token: 0x04039B19 RID: 236313
			public const int BtnRefresh = 4;

			// Token: 0x04039B1A RID: 236314
			public const int TextNum = 5;

			// Token: 0x04039B1B RID: 236315
			public const int TextDiscountNum = 6;
		}
	}
}
