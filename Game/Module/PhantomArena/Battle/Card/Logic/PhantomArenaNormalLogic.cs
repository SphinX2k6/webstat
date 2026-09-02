using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card.Logic
{
	// Token: 0x02005628 RID: 22056
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaNormalLogic : PhantomArenaCardLogic
	{
		// Token: 0x0603835B RID: 230235 RVA: 0x00E3B7CD File Offset: 0x00E399CD
		public PhantomArenaNormalLogic(PhantomArenaCard card, PhantomArenaBattleProxy viewProxy) : base(card, viewProxy)
		{
		}

		// Token: 0x0603835C RID: 230236 RVA: 0x00E3B7D8 File Offset: 0x00E399D8
		public override Tuple<bool, EPhantomCardSettingFailReason> CheckFunctionalSettingCondition(PhantomArenaCard oldCard)
		{
			if (oldCard != null)
			{
				return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.ExistCard);
			}
			if (this.Card.Data.Index == -1)
			{
				int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleCostPoint);
				if (this.Card.Data.HasActiveSkill)
				{
					int costConsume = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleSkillConfig(this.Card.Data.ActiveSkillId).CostConsume;
					if (battleStatusValue - costConsume < 0)
					{
						return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.NotEnoughCost);
					}
				}
			}
			if (!this.Card.Data.CanUse)
			{
				return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.CardLock);
			}
			if (!this.Card.Data.HasActiveSkill)
			{
				return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.NotHasActiveSkill);
			}
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x0603835D RID: 230237 RVA: 0x00E3B8A8 File Offset: 0x00E39AA8
		private Tuple<bool, EPhantomCardSettingFailReason> CheckCanSettingCardByEvolve(PhantomArenaCard oldCard)
		{
			if (this.Card.Data.Index == -1)
			{
				if (ModelBase<PhantomArenaBattleModel>.Instance.OwnData.CanEvolveNum <= 0)
				{
					return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.EvolveNumLimit);
				}
				ValueTuple<bool, EPhantomCardSettingFailReason> valueTuple = oldCard.Data.IsOtherCardCanEvolve(this.Card.Data);
				if (!valueTuple.Item1)
				{
					return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, valueTuple.Item2);
				}
			}
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x0603835E RID: 230238 RVA: 0x00E3B920 File Offset: 0x00E39B20
		private Tuple<bool, EPhantomCardSettingFailReason> CheckCanSettingCardBySetting()
		{
			if (this.Card.Data.Index == -1)
			{
				if (ModelBase<PhantomArenaBattleModel>.Instance.OwnData.MonsterCardLength >= 4)
				{
					return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.SettingLimit);
				}
				if (this.Card.Data.ConfigCost == 3)
				{
					return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.CantDragMonsterByThreeCost);
				}
			}
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x0603835F RID: 230239 RVA: 0x00E3B988 File Offset: 0x00E39B88
		public override Tuple<bool, EPhantomCardSettingFailReason> CheckMonsterSettingCondition(PhantomArenaCard oldCard)
		{
			if (this.Card.Data.Index == -1)
			{
				int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleCostPoint);
				int useCost = this.Card.Data.UseCost;
				if (battleStatusValue - useCost < 0)
				{
					return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.NotEnoughCost);
				}
			}
			if (!this.Card.Data.CanUse)
			{
				return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.CardLock);
			}
			if (oldCard != null)
			{
				if (!ModelBase<PhantomArenaBattleModel>.Instance.CanSetSlotIndex(oldCard.Data.Index))
				{
					return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.WaitBattleSlotIndex);
				}
				return this.CheckCanSettingCardByEvolve(oldCard);
			}
			else
			{
				if (!ModelBase<PhantomArenaBattleModel>.Instance.CanSetSlotIndex(this.Card.Data.Index))
				{
					return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.WaitBattleSlotIndex);
				}
				return this.CheckCanSettingCardBySetting();
			}
		}

		// Token: 0x06038360 RID: 230240 RVA: 0x00E3BA54 File Offset: 0x00E39C54
		protected override Tuple<bool, EPhantomCardSettingFailReason> OnCheckRecycleSettingConditionFromHead()
		{
			if (this.Card.Data.UseCost == 0)
			{
				return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.CantDragToRecycle);
			}
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x06038361 RID: 230241 RVA: 0x00E3BA7F File Offset: 0x00E39C7F
		protected override Tuple<bool, EPhantomCardSettingFailReason> OnCheckRecycleSettingConditionFromFunctional()
		{
			if (this.Card.Data.UseCost == 0)
			{
				return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.CantDragToRecycle);
			}
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x06038362 RID: 230242 RVA: 0x00E3BAAC File Offset: 0x00E39CAC
		protected override void OnBeforeStart()
		{
			CardSkillComponent component = this.Card.GetComponent<CardSkillComponent>(ECardItemComponent.CardSkillComponent);
			if (component != null)
			{
				component.SkillBtnClick = new Action(base.SkillBtnClick);
			}
		}

		// Token: 0x06038363 RID: 230243 RVA: 0x00E3BADC File Offset: 0x00E39CDC
		public override List<TCardComponentsRegisterInfoByResourceId> GetComponentsDataList()
		{
			List<TCardComponentsRegisterInfoByResourceId> list = new List<TCardComponentsRegisterInfoByResourceId>();
			if (this.Card.Data.HasClickActiveSkill)
			{
				list.Add(new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardSkillComponent, "UiItem_ActiveSkill", this.Card.GetPhantomArenaCardSpineRootItem()));
			}
			if (this.Card.Data.HasCountSkill)
			{
				list.Add(new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardEffectCountComponent, "UiItem_CardCount", this.Card.GetPhantomArenaCardSpineRootItem()));
			}
			return list;
		}

		// Token: 0x06038364 RID: 230244 RVA: 0x00E3BB50 File Offset: 0x00E39D50
		protected override void OnRefresh()
		{
			CardSkillComponentData data = new CardSkillComponentData
			{
				SkillCd = this.Card.Data.SkillCd,
				InSelect = false,
				InFight = (this.Card.Data.Index != -1)
			};
			CardSkillComponent component = this.Card.GetComponent<CardSkillComponent>(ECardItemComponent.CardSkillComponent);
			if (component != null)
			{
				component.Refresh(data);
			}
			CardEffectCountComponentData data2 = new CardEffectCountComponentData
			{
				EffectCount = this.Card.Data.CurEffectCount,
				EffectCountMax = this.Card.Data.MaxEffectCount,
				InFight = (this.Card.Data.Index != -1)
			};
			CardEffectCountComponent component2 = this.Card.GetComponent<CardEffectCountComponent>(ECardItemComponent.CardEffectCountComponent);
			if (component2 == null)
			{
				return;
			}
			component2.Refresh(data2);
		}

		// Token: 0x06038365 RID: 230245 RVA: 0x00E3BC1C File Offset: 0x00E39E1C
		protected override void OnSetSelectedState(bool value)
		{
			CardSkillComponentData data = new CardSkillComponentData
			{
				SkillCd = this.Card.Data.SkillCd,
				InSelect = (value && !this.Card.Data.IsNpcCard),
				InFight = (this.Card.Data.Index != -1)
			};
			CardSkillComponent component = this.Card.GetComponent<CardSkillComponent>(ECardItemComponent.CardSkillComponent);
			if (component == null)
			{
				return;
			}
			component.Refresh(data);
		}

		// Token: 0x06038366 RID: 230246 RVA: 0x00E3BC98 File Offset: 0x00E39E98
		protected override UniTask OnRefreshEffect(int curEffectCount)
		{
			PhantomArenaNormalLogic.<OnRefreshEffect>d__11 <OnRefreshEffect>d__;
			<OnRefreshEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnRefreshEffect>d__.<>4__this = this;
			<OnRefreshEffect>d__.curEffectCount = curEffectCount;
			<OnRefreshEffect>d__.<>1__state = -1;
			<OnRefreshEffect>d__.<>t__builder.Start<PhantomArenaNormalLogic.<OnRefreshEffect>d__11>(ref <OnRefreshEffect>d__);
			return <OnRefreshEffect>d__.<>t__builder.Task;
		}
	}
}
