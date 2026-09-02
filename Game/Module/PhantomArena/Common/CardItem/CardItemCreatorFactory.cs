using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem
{
	// Token: 0x02005533 RID: 21811
	public class CardItemCreatorFactory : IStaticVariableResetter
	{
		// Token: 0x060379F9 RID: 227833 RVA: 0x00E1CD67 File Offset: 0x00E1AF67
		static CardItemCreatorFactory()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CardItemCreatorFactory.CreateStaticDefaultValue), new Action(CardItemCreatorFactory.ResetStaticDefaultValue));
		}

		// Token: 0x060379FA RID: 227834 RVA: 0x00E1CD88 File Offset: 0x00E1AF88
		public static void CreateStaticDefaultValue()
		{
			CardItemCreatorFactory.FactoryMap = new CommonCreatorFactory<ICardComponentBase>();
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CommonBaseCardComponent>(ECardItemComponent.CommonBaseCardComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<NewCommonBaseCardComponent>(ECardItemComponent.NewCommonBaseCardComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardLockComponent>(ECardItemComponent.CardLockComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<BattleCardComponent>(ECardItemComponent.BattleCardComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<NewBattleCardComponent>(ECardItemComponent.NewBattleCardComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardReplaceComponent>(ECardItemComponent.CardReplaceComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardCommonComponent>(ECardItemComponent.CardChooseComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardCheckComponent>(ECardItemComponent.CardCheckComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardCommonComponent>(ECardItemComponent.CardSelectedComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardSpineComponent>(ECardItemComponent.CardSpineComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardAllInDeckComponent>(ECardItemComponent.CardAllInDeckComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardDisabledComponent>(ECardItemComponent.CardDisabledComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardSkillComponent>(ECardItemComponent.CardSkillComponent);
			CardItemCreatorFactory.FactoryMap.RegisterWithKey<CardEffectCountComponent>(ECardItemComponent.CardEffectCountComponent);
		}

		// Token: 0x060379FB RID: 227835 RVA: 0x00E1CE84 File Offset: 0x00E1B084
		public static void ResetStaticDefaultValue()
		{
			CardItemCreatorFactory.FactoryMap = null;
		}

		// Token: 0x060379FC RID: 227836 RVA: 0x00E1CE8C File Offset: 0x00E1B08C
		[NullableContext(1)]
		public static T GetComponent<[Nullable(0)] T>(ECardItemComponent name) where T : ICardComponentBase, new()
		{
			return CardItemCreatorFactory.FactoryMap.GetComponentWithKey<T>(name);
		}

		// Token: 0x0401FE38 RID: 130616
		[Nullable(1)]
		private static CommonCreatorFactory<ICardComponentBase> FactoryMap;
	}
}
