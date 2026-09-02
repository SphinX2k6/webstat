using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x02005536 RID: 21814
	public class CardOutlookPreviewItem : CommonBaseCardItem<int>
	{
		// Token: 0x06037A0E RID: 227854 RVA: 0x00E1D250 File Offset: 0x00E1B450
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

		// Token: 0x06037A0F RID: 227855 RVA: 0x00E1D2A0 File Offset: 0x00E1B4A0
		public override void Refresh(int cardId)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardId);
			bool flag = !ModelBase<PhantomArenaModel>.Instance.CheckCardSpineConfigValid(cardId);
			Dictionary<int, int> dictionary = phantomBattleCardConfig.InitAttack();
			CommonBaseCardComponentData commonBaseCardComponentData = new CommonBaseCardComponentData();
			commonBaseCardComponentData.CardId = cardId;
			commonBaseCardComponentData.Cost = phantomBattleCardConfig.Cost;
			commonBaseCardComponentData.Attack = (dictionary.ContainsKey(0) ? dictionary[0] : 0);
			commonBaseCardComponentData.Life = (dictionary.ContainsKey(1) ? dictionary[1] : 0);
			commonBaseCardComponentData.Element = phantomBattleCardConfig.Element;
			commonBaseCardComponentData.CardFaceTexturePath = phantomBattleCardConfig.CardFaceTexture;
			commonBaseCardComponentData.ShowCardFaceTexture = flag;
			commonBaseCardComponentData.OutlookUnlocked = true;
			commonBaseCardComponentData.CanToggleExecuteChange = (() => false);
			CommonBaseCardComponentData data = commonBaseCardComponentData;
			CommonBaseCardComponent component = base.GetComponent<CommonBaseCardComponent>(ECardItemComponent.CommonBaseCardComponent);
			if (component != null)
			{
				component.Refresh(data);
			}
			CardSpineComponentData data2 = new CardSpineComponentData
			{
				CardSpineData = ModelBase<PhantomArenaModel>.Instance.CreateCardSpineData(cardId),
				ShowSpine = !flag
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
