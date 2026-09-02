using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x0200553A RID: 21818
	public class CommonCardItem : CommonBaseCardItem<int>
	{
		// Token: 0x06037A22 RID: 227874 RVA: 0x00E1D738 File Offset: 0x00E1B938
		protected override void OnRegisterCardComponent()
		{
			if (ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.CommonBaseCardComponent, base.GetRootItem())
				};
			}
			else
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.NewCommonBaseCardComponent, base.GetRootItem())
				};
			}
			this.ComponentsRegisterInfoByResourceId = new List<TCardComponentsRegisterInfoByResourceId>
			{
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardSpineComponent, "UiItem_SoundRemnantItem512Spine", base.GetSpineRootItem())
			};
		}

		// Token: 0x06037A23 RID: 227875 RVA: 0x00E1D7B0 File Offset: 0x00E1B9B0
		public override void Refresh(int cardId)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			Dictionary<int, int> dictionary = phantomBattleCardConfig.InitAttack();
			CardSpineData cardSpineData = ModelBase<PhantomArenaModel>.Instance.CreateCardSpineData(cardId);
			ECardFaceType cardFaceType = ModelBase<PhantomArenaModel>.Instance.GetCardFaceType(cardId);
			CommonBaseCardComponentData data = new CommonBaseCardComponentData
			{
				CardId = cardId,
				Cost = phantomBattleCardConfig.Cost,
				Attack = (dictionary.ContainsKey(0) ? dictionary[0] : 0),
				Life = (dictionary.ContainsKey(1) ? dictionary[1] : 0),
				Element = phantomBattleCardConfig.Element,
				CardFaceTexturePath = phantomBattleCardConfig.CardFaceTexture,
				ShowCardFaceTexture = (cardFaceType == ECardFaceType.Texture),
				OutlookUnlocked = ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(cardId)
			};
			ICommonBaseCardComponent commonBaseCardComponent = this.GetCommonBaseCardComponent();
			if (commonBaseCardComponent != null)
			{
				commonBaseCardComponent.Refresh(data);
			}
			CardSpineComponentData data2 = new CardSpineComponentData
			{
				CardSpineData = cardSpineData,
				ShowSpine = (cardFaceType == ECardFaceType.Spine)
			};
			CardSpineComponent component = base.GetComponent<CardSpineComponent>(ECardItemComponent.CardSpineComponent);
			if (component == null)
			{
				return;
			}
			component.Refresh(data2);
		}

		// Token: 0x06037A24 RID: 227876 RVA: 0x00E1D8AA File Offset: 0x00E1BAAA
		[NullableContext(1)]
		private ICommonBaseCardComponent GetCommonBaseCardComponent()
		{
			if (ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				return base.GetComponent<CommonBaseCardComponent>(ECardItemComponent.CommonBaseCardComponent);
			}
			return base.GetComponent<NewCommonBaseCardComponent>(ECardItemComponent.NewCommonBaseCardComponent);
		}
	}
}
