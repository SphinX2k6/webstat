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
	// Token: 0x02005629 RID: 22057
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaToolLogic : PhantomArenaCardLogic
	{
		// Token: 0x06038367 RID: 230247 RVA: 0x00E3BCE3 File Offset: 0x00E39EE3
		public PhantomArenaToolLogic(PhantomArenaCard card, PhantomArenaBattleProxy viewProxy) : base(card, viewProxy)
		{
		}

		// Token: 0x06038368 RID: 230248 RVA: 0x00E3BCED File Offset: 0x00E39EED
		public override Tuple<bool, EPhantomCardSettingFailReason> CheckFunctionalSettingCondition(PhantomArenaCard oldCard)
		{
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.ToolCantDragToFunctional);
		}

		// Token: 0x06038369 RID: 230249 RVA: 0x00E3BCFC File Offset: 0x00E39EFC
		public override Tuple<bool, EPhantomCardSettingFailReason> CheckMonsterSettingCondition(PhantomArenaCard oldCard)
		{
			if (this.Card.Data.Index == -1)
			{
				if (oldCard != null)
				{
					return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.ExistCard);
				}
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
			if (oldCard != null && !ModelBase<PhantomArenaBattleModel>.Instance.CanSetSlotIndex(oldCard.Data.Index))
			{
				return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.WaitBattleSlotIndex);
			}
			if (!ModelBase<PhantomArenaBattleModel>.Instance.CanSetSlotIndex(this.Card.Data.Index))
			{
				return Tuple.Create<bool, EPhantomCardSettingFailReason>(false, EPhantomCardSettingFailReason.WaitBattleSlotIndex);
			}
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x0603836A RID: 230250 RVA: 0x00E3BDD4 File Offset: 0x00E39FD4
		protected override Tuple<bool, EPhantomCardSettingFailReason> OnCheckRecycleSettingConditionFromHead()
		{
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x0603836B RID: 230251 RVA: 0x00E3BDE1 File Offset: 0x00E39FE1
		protected override Tuple<bool, EPhantomCardSettingFailReason> OnCheckRecycleSettingConditionFromFunctional()
		{
			return Tuple.Create<bool, EPhantomCardSettingFailReason>(true, EPhantomCardSettingFailReason.None);
		}

		// Token: 0x0603836C RID: 230252 RVA: 0x00E3BDF0 File Offset: 0x00E39FF0
		protected override void OnBeforeStart()
		{
			CardSkillComponent component = this.Card.GetComponent<CardSkillComponent>(ECardItemComponent.CardSkillComponent);
			if (component != null)
			{
				component.SkillBtnClick = new Action(base.SkillBtnClick);
			}
		}

		// Token: 0x0603836D RID: 230253 RVA: 0x00E3BE20 File Offset: 0x00E3A020
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

		// Token: 0x0603836E RID: 230254 RVA: 0x00E3BE94 File Offset: 0x00E3A094
		protected override void OnRefresh()
		{
			bool inFight = this.Card.Data.Index != -1;
			CardSkillComponentData data = new CardSkillComponentData
			{
				SkillCd = this.Card.Data.SkillCd,
				InSelect = false,
				InFight = inFight
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
				InFight = inFight
			};
			CardEffectCountComponent component2 = this.Card.GetComponent<CardEffectCountComponent>(ECardItemComponent.CardEffectCountComponent);
			if (component2 == null)
			{
				return;
			}
			component2.Refresh(data2);
		}

		// Token: 0x0603836F RID: 230255 RVA: 0x00E3BF4C File Offset: 0x00E3A14C
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

		// Token: 0x06038370 RID: 230256 RVA: 0x00E3BFC8 File Offset: 0x00E3A1C8
		protected override UniTask OnRefreshEffect(int curEffectCount)
		{
			PhantomArenaToolLogic.<OnRefreshEffect>d__9 <OnRefreshEffect>d__;
			<OnRefreshEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnRefreshEffect>d__.<>4__this = this;
			<OnRefreshEffect>d__.curEffectCount = curEffectCount;
			<OnRefreshEffect>d__.<>1__state = -1;
			<OnRefreshEffect>d__.<>t__builder.Start<PhantomArenaToolLogic.<OnRefreshEffect>d__9>(ref <OnRefreshEffect>d__);
			return <OnRefreshEffect>d__.<>t__builder.Task;
		}
	}
}
