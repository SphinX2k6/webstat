using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x02005540 RID: 21824
	public class UnlockViewCardItem : CommonBaseCardItem<int>
	{
		// Token: 0x06037A4A RID: 227914 RVA: 0x00E1DF4C File Offset: 0x00E1C14C
		protected override void OnRegisterCardComponent()
		{
			this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
			{
				new TCardComponentsRegisterInfoByItem(ECardItemComponent.CommonBaseCardComponent, base.GetRootItem())
			};
			this.ComponentsRegisterInfoByResourceId = new List<TCardComponentsRegisterInfoByResourceId>
			{
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardSpineComponent, "UiItem_SoundRemnantItem512Spine", base.GetSpineRootItem())
			};
		}

		// Token: 0x06037A4B RID: 227915 RVA: 0x00E1DF9C File Offset: 0x00E1C19C
		public override void Refresh(int cardId)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			Dictionary<int, int> dictionary = phantomBattleCardConfig.InitAttack();
			CardSpineData cardSpineData = ModelBase<PhantomArenaModel>.Instance.CreateCardSpineData(cardId);
			ECardFaceType cardFaceType = ModelBase<PhantomArenaModel>.Instance.GetCardFaceType(cardId);
			CommonBaseCardComponentData commonBaseCardComponentData = new CommonBaseCardComponentData();
			commonBaseCardComponentData.CardId = cardId;
			commonBaseCardComponentData.Cost = phantomBattleCardConfig.Cost;
			commonBaseCardComponentData.Attack = (dictionary.ContainsKey(0) ? dictionary[0] : 0);
			commonBaseCardComponentData.Life = (dictionary.ContainsKey(1) ? dictionary[1] : 0);
			commonBaseCardComponentData.Element = phantomBattleCardConfig.Element;
			commonBaseCardComponentData.CardFaceTexturePath = phantomBattleCardConfig.CardFaceTexture;
			commonBaseCardComponentData.ShowCardFaceTexture = (cardFaceType == ECardFaceType.Texture);
			commonBaseCardComponentData.OutlookUnlocked = ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(cardId);
			commonBaseCardComponentData.CanToggleExecuteChange = (() => false);
			CommonBaseCardComponentData data = commonBaseCardComponentData;
			CommonBaseCardComponent component = base.GetComponent<CommonBaseCardComponent>(ECardItemComponent.CommonBaseCardComponent);
			if (component != null)
			{
				component.Refresh(data);
			}
			CardSpineComponentData data2 = new CardSpineComponentData
			{
				CardSpineData = cardSpineData,
				ShowSpine = (cardFaceType == ECardFaceType.Spine)
			};
			CardSpineComponent component2 = base.GetComponent<CardSpineComponent>(ECardItemComponent.CardSpineComponent);
			if (component2 == null)
			{
				return;
			}
			component2.Refresh(data2);
		}
	}
}
