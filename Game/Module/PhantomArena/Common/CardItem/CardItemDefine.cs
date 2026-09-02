using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem
{
	// Token: 0x02005531 RID: 21809
	public static class CardItemDefine
	{
		// Token: 0x0401FE34 RID: 130612
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static Dictionary<ECardItemComponent, CardComponentCreator> cardItemCreatorMap = new Dictionary<ECardItemComponent, CardComponentCreator>
		{
			{
				ECardItemComponent.CommonBaseCardComponent,
				() => new CommonBaseCardComponent()
			},
			{
				ECardItemComponent.NewCommonBaseCardComponent,
				() => new NewCommonBaseCardComponent()
			},
			{
				ECardItemComponent.CardLockComponent,
				() => new CardLockComponent()
			},
			{
				ECardItemComponent.BattleCardComponent,
				() => new BattleCardComponent()
			},
			{
				ECardItemComponent.NewBattleCardComponent,
				() => new NewBattleCardComponent()
			},
			{
				ECardItemComponent.CardReplaceComponent,
				() => new CardReplaceComponent()
			},
			{
				ECardItemComponent.CardChooseComponent,
				() => new CardCommonComponent()
			},
			{
				ECardItemComponent.CardCheckComponent,
				() => new CardCheckComponent()
			},
			{
				ECardItemComponent.CardSelectedComponent,
				() => new CardCommonComponent()
			},
			{
				ECardItemComponent.CardSpineComponent,
				() => new CardSpineComponent()
			},
			{
				ECardItemComponent.CardAllInDeckComponent,
				() => new CardAllInDeckComponent()
			},
			{
				ECardItemComponent.CardDisabledComponent,
				() => new CardDisabledComponent()
			},
			{
				ECardItemComponent.CardSkillComponent,
				() => new CardSkillComponent()
			},
			{
				ECardItemComponent.CardEffectCountComponent,
				() => new CardEffectCountComponent()
			}
		};
	}
}
