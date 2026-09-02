using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato.View.AttrSelect;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.BoxDrop
{
	// Token: 0x02005AC7 RID: 23239
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoBoxDropMainView : UiViewBase
	{
		// Token: 0x0603AC17 RID: 240663 RVA: 0x00EE5A1C File Offset: 0x00EE3C1C
		public KurotatoBoxDropMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AC18 RID: 240664 RVA: 0x00EE5A54 File Offset: 0x00EE3C54
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AC19 RID: 240665 RVA: 0x00EE5B62 File Offset: 0x00EE3D62
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnChestRewardDataChanged, new Action(this.OnChestRewardChanged));
		}

		// Token: 0x0603AC1A RID: 240666 RVA: 0x00EE5B80 File Offset: 0x00EE3D80
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnChestRewardDataChanged, new Action(this.OnChestRewardChanged));
		}

		// Token: 0x0603AC1B RID: 240667 RVA: 0x00EE5BA0 File Offset: 0x00EE3DA0
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoBoxDropMainView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoBoxDropMainView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC1C RID: 240668 RVA: 0x00EE5BE4 File Offset: 0x00EE3DE4
		private UniTask CreatePopupPanel()
		{
			KurotatoBoxDropMainView.<CreatePopupPanel>d__11 <CreatePopupPanel>d__;
			<CreatePopupPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreatePopupPanel>d__.<>4__this = this;
			<CreatePopupPanel>d__.<>1__state = -1;
			<CreatePopupPanel>d__.<>t__builder.Start<KurotatoBoxDropMainView.<CreatePopupPanel>d__11>(ref <CreatePopupPanel>d__);
			return <CreatePopupPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC1D RID: 240669 RVA: 0x00EE5C28 File Offset: 0x00EE3E28
		private UniTask CreateCardItem()
		{
			KurotatoBoxDropMainView.<CreateCardItem>d__12 <CreateCardItem>d__;
			<CreateCardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCardItem>d__.<>4__this = this;
			<CreateCardItem>d__.<>1__state = -1;
			<CreateCardItem>d__.<>t__builder.Start<KurotatoBoxDropMainView.<CreateCardItem>d__12>(ref <CreateCardItem>d__);
			return <CreateCardItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC1E RID: 240670 RVA: 0x00EE5C6C File Offset: 0x00EE3E6C
		private UniTask CreateExchangeBtnAsync()
		{
			KurotatoBoxDropMainView.<CreateExchangeBtnAsync>d__13 <CreateExchangeBtnAsync>d__;
			<CreateExchangeBtnAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateExchangeBtnAsync>d__.<>4__this = this;
			<CreateExchangeBtnAsync>d__.<>1__state = -1;
			<CreateExchangeBtnAsync>d__.<>t__builder.Start<KurotatoBoxDropMainView.<CreateExchangeBtnAsync>d__13>(ref <CreateExchangeBtnAsync>d__);
			return <CreateExchangeBtnAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC1F RID: 240671 RVA: 0x00EE5CB0 File Offset: 0x00EE3EB0
		private UniTask CreateSelectBtnAsync()
		{
			KurotatoBoxDropMainView.<CreateSelectBtnAsync>d__14 <CreateSelectBtnAsync>d__;
			<CreateSelectBtnAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateSelectBtnAsync>d__.<>4__this = this;
			<CreateSelectBtnAsync>d__.<>1__state = -1;
			<CreateSelectBtnAsync>d__.<>t__builder.Start<KurotatoBoxDropMainView.<CreateSelectBtnAsync>d__14>(ref <CreateSelectBtnAsync>d__);
			return <CreateSelectBtnAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC20 RID: 240672 RVA: 0x00EE5CF3 File Offset: 0x00EE3EF3
		protected override void OnStart()
		{
			this.RefreshAttrSelectLayout();
			this.RefreshChangeNum();
			this.CommonPopupPanel.SetTitleLocalText("Kurotato_Reward_Title");
		}

		// Token: 0x0603AC21 RID: 240673 RVA: 0x00EE5D11 File Offset: 0x00EE3F11
		protected override void OnBeforeShow()
		{
			this.CommonPopupPanel.HideAttrChangeFx();
			this.OnChestRewardChanged();
		}

		// Token: 0x0603AC22 RID: 240674 RVA: 0x00EE5D24 File Offset: 0x00EE3F24
		private void RefreshAttrSelectLayout()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			KurotatoConfig instance2 = ConfigBase<KurotatoConfig>.Instance;
			int chestItemId = instance.GetChestItemId();
			int roleId = instance.GetRoleId();
			KurotatoCharacter? characterById = instance2.GetCharacterById(roleId);
			IEnumerable<string> enumerable = ((characterById != null) ? characterById.GetValueOrDefault().RecommendedTagsIter() : null) ?? new List<string>();
			List<int> list = ((characterById != null) ? characterById.GetValueOrDefault().ExcludedRecommendItemIdsIter().ToList<int>() : null) ?? new List<int>();
			KurotatoItem? itemConfigByItemId = instance2.GetItemConfigByItemId(chestItemId);
			List<string> list2 = ((itemConfigByItemId != null) ? itemConfigByItemId.GetValueOrDefault().TagsIter().ToList<string>() : null) ?? new List<string>();
			bool flag = list.Contains(chestItemId);
			bool isRecommend = false;
			if (!flag)
			{
				foreach (string item in enumerable)
				{
					if (list2.Contains(item))
					{
						isRecommend = true;
						break;
					}
				}
			}
			this.CardItem.Refresh(new KurotatoCardItemData
			{
				Id = chestItemId,
				SelectionId = 0,
				Cost = 0,
				HasBuy = false,
				IsRecommend = isRecommend,
				CardType = EKurotatoCardType.Item,
				HasLock = false,
				ShowLock = false
			});
			this.RecycleBtn.SetLocalTextNew("PrefabTextItem_538048862_Text", new object[]
			{
				instance.GetChestSoldPrice()
			});
		}

		// Token: 0x0603AC23 RID: 240675 RVA: 0x00EE5EA0 File Offset: 0x00EE40A0
		private void RefreshChangeNum()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			int chestRewardIndex = instance.GetChestRewardIndex();
			int chestRewardCount = instance.GetChestRewardCount();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "PrefabTextItem_1132806154_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				chestRewardIndex.ToString(),
				chestRewardCount.ToString()
			}));
		}

		// Token: 0x0603AC24 RID: 240676 RVA: 0x00EE5EF4 File Offset: 0x00EE40F4
		private void OnChestRewardChanged()
		{
			this.RewardSelected = false;
			this.RefreshAttrSelectLayout();
			this.RefreshChangeNum();
		}

		// Token: 0x0603AC25 RID: 240677 RVA: 0x00EE5F09 File Offset: 0x00EE4109
		private void OnClickSelect(int _)
		{
			this.RequestChestRewardSelect(false).Forget();
		}

		// Token: 0x0603AC26 RID: 240678 RVA: 0x00EE5F17 File Offset: 0x00EE4117
		private void OnClickRecycle(int _)
		{
			this.RequestChestRewardSelect(true).Forget();
		}

		// Token: 0x0603AC27 RID: 240679 RVA: 0x00EE5F28 File Offset: 0x00EE4128
		private UniTask RequestChestRewardSelect(bool willSold)
		{
			KurotatoBoxDropMainView.<RequestChestRewardSelect>d__22 <RequestChestRewardSelect>d__;
			<RequestChestRewardSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestChestRewardSelect>d__.<>4__this = this;
			<RequestChestRewardSelect>d__.willSold = willSold;
			<RequestChestRewardSelect>d__.<>1__state = -1;
			<RequestChestRewardSelect>d__.<>t__builder.Start<KurotatoBoxDropMainView.<RequestChestRewardSelect>d__22>(ref <RequestChestRewardSelect>d__);
			return <RequestChestRewardSelect>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC28 RID: 240680 RVA: 0x00EE5F73 File Offset: 0x00EE4173
		private void OnCardAttrPreview(bool active, IReadOnlyList<IKurotatoAttrPreviewDelta> deltas)
		{
			if (active)
			{
				this.CommonPopupPanel.ShowAttrPreview(deltas);
				return;
			}
			this.CommonPopupPanel.ClearAttrPreview();
		}

		// Token: 0x04021383 RID: 136067
		private readonly KurotatoCommonPopupPanel CommonPopupPanel = new KurotatoCommonPopupPanel();

		// Token: 0x04021384 RID: 136068
		private readonly KurotatoCardInfoItem CardItem = new KurotatoCardInfoItem();

		// Token: 0x04021385 RID: 136069
		private readonly ButtonItem RecycleBtn = new ButtonItem(null);

		// Token: 0x04021386 RID: 136070
		private readonly ButtonItem SelectBtn = new ButtonItem(null);

		// Token: 0x04021387 RID: 136071
		private bool RewardSelected;

		// Token: 0x0200BADC RID: 47836
		[NullableContext(0)]
		private class EChildComp
		{
			// Token: 0x04039ADE RID: 236254
			public const int CommonPopupPanel = 0;

			// Token: 0x04039ADF RID: 236255
			public const int TextureIcon = 1;

			// Token: 0x04039AE0 RID: 236256
			public const int TextChangeNum = 2;

			// Token: 0x04039AE1 RID: 236257
			public const int HorizontalLayoutAttr = 3;

			// Token: 0x04039AE2 RID: 236258
			public const int CardItem = 4;

			// Token: 0x04039AE3 RID: 236259
			public const int BtnRecycle = 5;

			// Token: 0x04039AE4 RID: 236260
			public const int BtnSelect = 6;
		}
	}
}
