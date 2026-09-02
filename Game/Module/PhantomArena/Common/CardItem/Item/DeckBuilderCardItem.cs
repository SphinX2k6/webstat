using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x0200553D RID: 21821
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DeckBuilderCardItem : CommonGridCardItem<DeckBuilderCardItemData>
	{
		// Token: 0x06037A35 RID: 227893 RVA: 0x00E1D930 File Offset: 0x00E1BB30
		protected override void OnRegisterCardComponent()
		{
			if (this.IsNewPhantomArenaActivity)
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.NewCommonBaseCardComponent, base.GetRootItem())
				};
			}
			else
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.CommonBaseCardComponent, base.GetRootItem())
				};
			}
			string resourceId = this.IsNewPhantomArenaActivity ? "UiItem_CardLockNew" : "UiItem_CardLock";
			string resourceId2 = this.IsNewPhantomArenaActivity ? "UiItem_CardDisableNew" : "UiItem_CardDisable";
			string resourceId3 = this.IsNewPhantomArenaActivity ? "UiItem_CardUseNew" : "UiItem_CardUse";
			string resourceId4 = this.IsNewPhantomArenaActivity ? "NewUiItem_CardCheck" : "UiItem_CardCheck";
			this.ComponentsRegisterInfoByResourceId = new List<TCardComponentsRegisterInfoByResourceId>
			{
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardLockComponent, resourceId, base.GetContentRootItem()),
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardAllInDeckComponent, resourceId3, base.GetContentRootItem()),
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardDisabledComponent, resourceId2, base.GetContentRootItem()),
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardCheckComponent, resourceId4, base.GetContentRootItem()),
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardSpineComponent, "UiItem_SoundRemnantItem512Spine", base.GetSpineRootItem())
			};
		}

		// Token: 0x06037A36 RID: 227894 RVA: 0x00E1DA46 File Offset: 0x00E1BC46
		protected override void OnStart()
		{
			base.GetComponent<CardCheckComponent>(ECardItemComponent.CardCheckComponent).SetActive(true);
		}

		// Token: 0x06037A37 RID: 227895 RVA: 0x00E1DA58 File Offset: 0x00E1BC58
		public override void Refresh(DeckBuilderCardItemData data)
		{
			DeckBuilderCardItem.<>c__DisplayClass6_0 CS$<>8__locals1 = new DeckBuilderCardItem.<>c__DisplayClass6_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			UiAsyncTask task = new UiAsyncTask("DeckBuilderCardItem", delegate()
			{
				DeckBuilderCardItem.<>c__DisplayClass6_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<DeckBuilderCardItem.<>c__DisplayClass6_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x06037A38 RID: 227896 RVA: 0x00E1DA9C File Offset: 0x00E1BC9C
		public override UniTask RefreshAsync(DeckBuilderCardItemData data, bool isSelected, int gridIndex)
		{
			DeckBuilderCardItem.<RefreshAsync>d__7 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<DeckBuilderCardItem.<RefreshAsync>d__7>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037A39 RID: 227897 RVA: 0x00E1DAE8 File Offset: 0x00E1BCE8
		public void RefreshLeftCount()
		{
			CardCheckComponentData data = new CardCheckComponentData
			{
				LeftCount = this.Data.LeftCount,
				MaxCount = this.Data.MaxCount,
				OnCheckBtnClick = new Action(this.OpenCardInfoViewInternal)
			};
			base.GetComponent<CardCheckComponent>(ECardItemComponent.CardCheckComponent).Refresh(data);
		}

		// Token: 0x06037A3A RID: 227898 RVA: 0x00E1DB3C File Offset: 0x00E1BD3C
		public void RefreshAllInDeckComponent()
		{
			CardAllInDeckComponentData data = new CardAllInDeckComponentData
			{
				IsAllInDeck = this.Data.IsAllInDeck,
				ShowComponent = (this.Data.IsAllInDeck && !this.Data.IsLocked)
			};
			base.GetComponent<CardAllInDeckComponent>(ECardItemComponent.CardAllInDeckComponent).Refresh(data);
		}

		// Token: 0x06037A3B RID: 227899 RVA: 0x00E1DB94 File Offset: 0x00E1BD94
		public void RefreshDisabledComponent()
		{
			CardDisabledComponentData data = new CardDisabledComponentData
			{
				Disabled = this.Data.Disabled,
				ShowComponent = (this.Data.Disabled && !this.Data.IsLocked && !this.Data.IsAllInDeck)
			};
			base.GetComponent<CardDisabledComponent>(ECardItemComponent.CardDisabledComponent).Refresh(data);
		}

		// Token: 0x06037A3C RID: 227900 RVA: 0x00E1DBF7 File Offset: 0x00E1BDF7
		public void RefreshLockComponent()
		{
			base.GetComponent<CardLockComponent>(ECardItemComponent.CardLockComponent).Refresh(this.Data.IsLocked);
		}

		// Token: 0x06037A3D RID: 227901 RVA: 0x00E1DC10 File Offset: 0x00E1BE10
		public void RefreshOutlook()
		{
			ECardFaceType cardFaceType = ModelBase<PhantomArenaModel>.Instance.GetCardFaceType(this.Data.CardId);
			this.Data.CardFaceType = cardFaceType;
			this.CommonBaseCardComponentData.ShowCardFaceTexture = (cardFaceType == ECardFaceType.Texture);
			this.CommonBaseCardComponentData.OutlookUnlocked = this.Data.OutlookUnlocked;
			CommonBaseCardComponent component = base.GetComponent<CommonBaseCardComponent>(ECardItemComponent.CommonBaseCardComponent);
			if (component != null)
			{
				component.RefreshOutlook();
			}
			this.SpineComponentData.ShowSpine = (cardFaceType == ECardFaceType.Spine);
			base.GetComponent<CardSpineComponent>(ECardItemComponent.CardSpineComponent).Refresh(this.SpineComponentData);
		}

		// Token: 0x06037A3E RID: 227902 RVA: 0x00E1DC98 File Offset: 0x00E1BE98
		private void OpenCardInfoViewInternal()
		{
			DeckBuilderCardItemData data = this.Data;
			if (data == null)
			{
				return;
			}
			Action<int> openCardInfoView = data.OpenCardInfoView;
			DeckBuilderCardItemData data2 = this.Data;
			openCardInfoView((data2 != null) ? data2.CardId : 0);
		}

		// Token: 0x06037A3F RID: 227903 RVA: 0x00E1DCC1 File Offset: 0x00E1BEC1
		protected void OnPointerUp()
		{
			DeckBuilderCardItemData data = this.Data;
			if (data == null)
			{
				return;
			}
			data.AddCardToDeck(this.Data.CardId, 1);
		}

		// Token: 0x06037A40 RID: 227904 RVA: 0x00E1DCE4 File Offset: 0x00E1BEE4
		private bool CanToggleChange()
		{
			return false;
		}

		// Token: 0x06037A41 RID: 227905 RVA: 0x00E1DCE7 File Offset: 0x00E1BEE7
		public override object GetKey(DeckBuilderCardItemData data, int gridIndex)
		{
			return data.CardId;
		}

		// Token: 0x06037A42 RID: 227906 RVA: 0x00E1DCF4 File Offset: 0x00E1BEF4
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "CardDetail")
			{
				CardCheckComponent component = base.GetComponent<CardCheckComponent>(ECardItemComponent.CardCheckComponent);
				return ((component != null) ? component.GetGuideUiItemAndUiItemForShowEx(configParams) : null) ?? Array.Empty<UUIItem>();
			}
			if (a == "New:CardDetail")
			{
				CardCheckComponent component2 = base.GetComponent<CardCheckComponent>(ECardItemComponent.CardCheckComponent);
				UUIItem uuiitem;
				if (component2 == null)
				{
					uuiitem = null;
				}
				else
				{
					UUIItem[] guideUiItemAndUiItemForShowEx = component2.GetGuideUiItemAndUiItemForShowEx(configParams);
					uuiitem = ((guideUiItemAndUiItemForShowEx != null) ? guideUiItemAndUiItemForShowEx[0] : null);
				}
				UUIItem uuiitem2 = uuiitem;
				UUIItem rootItem = base.GetRootItem();
				if (uuiitem2 != null && rootItem != null)
				{
					return new UUIItem[]
					{
						uuiitem2,
						rootItem
					};
				}
			}
			return null;
		}

		// Token: 0x0401FE4C RID: 130636
		protected DeckBuilderCardItemData Data;

		// Token: 0x0401FE4D RID: 130637
		protected ICommonBaseCardComponentData CommonBaseCardComponentData;

		// Token: 0x0401FE4E RID: 130638
		protected ICardSpineComponentData SpineComponentData;

		// Token: 0x0401FE4F RID: 130639
		public bool IsNewPhantomArenaActivity;
	}
}
