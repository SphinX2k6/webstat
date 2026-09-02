using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x02005538 RID: 21816
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class CollectCardItem : CommonBaseCardItem<CollectGridCardData>
	{
		// Token: 0x06037A17 RID: 227863 RVA: 0x00E1D4A0 File Offset: 0x00E1B6A0
		protected override void OnRegisterCardComponent()
		{
			string resourceId = this.IsNewPhantomArenaActivity ? "UiItem_CardLock256New" : "UiItem_CardLockSmall";
			if (this.IsNewPhantomArenaActivity)
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.NewCommonBaseCardComponent, base.GetCardRootItem())
				};
			}
			else
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.CommonBaseCardComponent, base.GetCardRootItem())
				};
			}
			this.ComponentsRegisterInfoByResourceId = new List<TCardComponentsRegisterInfoByResourceId>
			{
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardLockComponent, resourceId, base.GetContentRootItem()),
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardSpineComponent, "UiItem_SoundRemnantItemSpine", base.GetSpineRootItem())
			};
		}

		// Token: 0x06037A18 RID: 227864 RVA: 0x00E1D53C File Offset: 0x00E1B73C
		protected override void OnStart()
		{
			CollectGridCardData collectGridCardData = this.OpenParam as CollectGridCardData;
			if (collectGridCardData != null)
			{
				this.Refresh(collectGridCardData);
			}
		}

		// Token: 0x06037A19 RID: 227865 RVA: 0x00E1D560 File Offset: 0x00E1B760
		public override void Refresh(CollectGridCardData data)
		{
			this.Data = data;
			ICommonBaseCardComponent commonBaseCardComponent;
			if (!this.IsNewPhantomArenaActivity)
			{
				ICommonBaseCardComponent component = base.GetComponent<CommonBaseCardComponent>(ECardItemComponent.CommonBaseCardComponent);
				commonBaseCardComponent = component;
			}
			else
			{
				ICommonBaseCardComponent component = base.GetComponent<NewCommonBaseCardComponent>(ECardItemComponent.NewCommonBaseCardComponent);
				commonBaseCardComponent = component;
			}
			ICommonBaseCardComponent commonBaseCardComponent2 = commonBaseCardComponent;
			if (commonBaseCardComponent2 != null)
			{
				CommonBaseCardComponentData data2 = new CommonBaseCardComponentData
				{
					CardId = data.CardId,
					Attack = data.Attack,
					Life = data.Life,
					Element = data.Element,
					Cost = data.Cost,
					CanToggleExecuteChange = new Func<bool>(this.CanToggleChange),
					OnPointerUp = new Action(this.OnClickCard),
					OutlookUnlocked = ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(data.CardId),
					CardFaceTexturePath = data.CardFaceTexturePath,
					ShowCardFaceTexture = (data.CardFaceType == ECardFaceType.Texture)
				};
				commonBaseCardComponent2.Refresh(data2);
			}
			CardLockComponent component2 = base.GetComponent<CardLockComponent>(ECardItemComponent.CardLockComponent);
			if (component2 != null)
			{
				component2.Refresh(data.IsLocked);
			}
			CardSpineComponentData data3 = new CardSpineComponentData
			{
				CardSpineData = data.CardSpineData,
				ShowSpine = (data.CardFaceType == ECardFaceType.Spine)
			};
			CardSpineComponent component3 = base.GetComponent<CardSpineComponent>(ECardItemComponent.CardSpineComponent);
			if (component3 == null)
			{
				return;
			}
			component3.Refresh(data3);
		}

		// Token: 0x06037A1A RID: 227866 RVA: 0x00E1D681 File Offset: 0x00E1B881
		private bool CanToggleChange()
		{
			return false;
		}

		// Token: 0x06037A1B RID: 227867 RVA: 0x00E1D684 File Offset: 0x00E1B884
		private void OnClickCard()
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.CallbackOnClick != null)
			{
				this.CallbackOnClick(this.Data.CardId);
			}
		}

		// Token: 0x0401FE3F RID: 130623
		private CollectGridCardData Data;

		// Token: 0x0401FE40 RID: 130624
		public Action<int> CallbackOnClick;

		// Token: 0x0401FE41 RID: 130625
		public bool IsNewPhantomArenaActivity;
	}
}
