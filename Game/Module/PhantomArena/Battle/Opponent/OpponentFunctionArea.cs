using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Opponent
{
	// Token: 0x020055F3 RID: 22003
	[NullableContext(1)]
	[Nullable(0)]
	public class OpponentFunctionArea : UiPanelBase
	{
		// Token: 0x060380D3 RID: 229587 RVA: 0x00E330C4 File Offset: 0x00E312C4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x060380D4 RID: 229588 RVA: 0x00E33178 File Offset: 0x00E31378
		protected override UniTask OnBeforeStartAsync()
		{
			OpponentFunctionArea.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<OpponentFunctionArea.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060380D5 RID: 229589 RVA: 0x00E331BC File Offset: 0x00E313BC
		private UniTask InitAreaProxy()
		{
			OpponentFunctionArea.<InitAreaProxy>d__5 <InitAreaProxy>d__;
			<InitAreaProxy>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAreaProxy>d__.<>4__this = this;
			<InitAreaProxy>d__.<>1__state = -1;
			<InitAreaProxy>d__.<>t__builder.Start<OpponentFunctionArea.<InitAreaProxy>d__5>(ref <InitAreaProxy>d__);
			return <InitAreaProxy>d__.<>t__builder.Task;
		}

		// Token: 0x060380D6 RID: 229590 RVA: 0x00E331FF File Offset: 0x00E313FF
		public void RegisterBattleArea(OpponentArea area)
		{
			this.ParentArea = area;
		}

		// Token: 0x060380D7 RID: 229591 RVA: 0x00E33208 File Offset: 0x00E31408
		public UniTask TrySettingCard(int cardId, int index)
		{
			OpponentFunctionArea.<TrySettingCard>d__7 <TrySettingCard>d__;
			<TrySettingCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TrySettingCard>d__.<>4__this = this;
			<TrySettingCard>d__.cardId = cardId;
			<TrySettingCard>d__.index = index;
			<TrySettingCard>d__.<>1__state = -1;
			<TrySettingCard>d__.<>t__builder.Start<OpponentFunctionArea.<TrySettingCard>d__7>(ref <TrySettingCard>d__);
			return <TrySettingCard>d__.<>t__builder.Task;
		}

		// Token: 0x060380D8 RID: 229592 RVA: 0x00E3325C File Offset: 0x00E3145C
		public UniTask TrySettingCardFromLibrary(int cardId, int index)
		{
			OpponentFunctionArea.<TrySettingCardFromLibrary>d__8 <TrySettingCardFromLibrary>d__;
			<TrySettingCardFromLibrary>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TrySettingCardFromLibrary>d__.<>4__this = this;
			<TrySettingCardFromLibrary>d__.cardId = cardId;
			<TrySettingCardFromLibrary>d__.index = index;
			<TrySettingCardFromLibrary>d__.<>1__state = -1;
			<TrySettingCardFromLibrary>d__.<>t__builder.Start<OpponentFunctionArea.<TrySettingCardFromLibrary>d__8>(ref <TrySettingCardFromLibrary>d__);
			return <TrySettingCardFromLibrary>d__.<>t__builder.Task;
		}

		// Token: 0x060380D9 RID: 229593 RVA: 0x00E332B0 File Offset: 0x00E314B0
		public UniTask TryEvolveCard(int cardId, int index)
		{
			OpponentFunctionArea.<TryEvolveCard>d__9 <TryEvolveCard>d__;
			<TryEvolveCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryEvolveCard>d__.<>4__this = this;
			<TryEvolveCard>d__.cardId = cardId;
			<TryEvolveCard>d__.index = index;
			<TryEvolveCard>d__.<>1__state = -1;
			<TryEvolveCard>d__.<>t__builder.Start<OpponentFunctionArea.<TryEvolveCard>d__9>(ref <TryEvolveCard>d__);
			return <TryEvolveCard>d__.<>t__builder.Task;
		}

		// Token: 0x060380DA RID: 229594 RVA: 0x00E33304 File Offset: 0x00E31504
		public UniTask TryUseCardSkill(PhantomCardData cardData)
		{
			OpponentFunctionArea.<TryUseCardSkill>d__10 <TryUseCardSkill>d__;
			<TryUseCardSkill>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryUseCardSkill>d__.<>4__this = this;
			<TryUseCardSkill>d__.cardData = cardData;
			<TryUseCardSkill>d__.<>1__state = -1;
			<TryUseCardSkill>d__.<>t__builder.Start<OpponentFunctionArea.<TryUseCardSkill>d__10>(ref <TryUseCardSkill>d__);
			return <TryUseCardSkill>d__.<>t__builder.Task;
		}

		// Token: 0x060380DB RID: 229595 RVA: 0x00E33350 File Offset: 0x00E31550
		public UniTask TryChangeCard(int oneIndex, int twoIndex)
		{
			OpponentFunctionArea.<TryChangeCard>d__11 <TryChangeCard>d__;
			<TryChangeCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryChangeCard>d__.<>4__this = this;
			<TryChangeCard>d__.oneIndex = oneIndex;
			<TryChangeCard>d__.twoIndex = twoIndex;
			<TryChangeCard>d__.<>1__state = -1;
			<TryChangeCard>d__.<>t__builder.Start<OpponentFunctionArea.<TryChangeCard>d__11>(ref <TryChangeCard>d__);
			return <TryChangeCard>d__.<>t__builder.Task;
		}

		// Token: 0x060380DC RID: 229596 RVA: 0x00E333A4 File Offset: 0x00E315A4
		public UniTask BackToRecycle(int index)
		{
			OpponentFunctionArea.<BackToRecycle>d__12 <BackToRecycle>d__;
			<BackToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<BackToRecycle>d__.<>4__this = this;
			<BackToRecycle>d__.index = index;
			<BackToRecycle>d__.<>1__state = -1;
			<BackToRecycle>d__.<>t__builder.Start<OpponentFunctionArea.<BackToRecycle>d__12>(ref <BackToRecycle>d__);
			return <BackToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x060380DD RID: 229597 RVA: 0x00E333F0 File Offset: 0x00E315F0
		public void ShowAddBuffEffect(EBuffShowType buffShowType, List<int> fightIdList)
		{
			foreach (OpponentFunctionAreaProxy opponentFunctionAreaProxy in this.CardProxyMap.Values)
			{
				if (opponentFunctionAreaProxy.Card != null && fightIdList.Contains(opponentFunctionAreaProxy.Card.Data.FightId))
				{
					OpponentMonsterProxy opponentMonsterProxy = opponentFunctionAreaProxy as OpponentMonsterProxy;
					if (opponentMonsterProxy != null)
					{
						if (buffShowType == EBuffShowType.UpGrade)
						{
							opponentMonsterProxy.AreaItem.SetBuffUpActive(true).Forget();
						}
						else if (buffShowType == EBuffShowType.DownGrade)
						{
							opponentMonsterProxy.AreaItem.SetBuffDownActive(true).Forget();
						}
					}
				}
			}
		}

		// Token: 0x060380DE RID: 229598 RVA: 0x00E33498 File Offset: 0x00E31698
		public UniTask DestroyCardByIndex(int index)
		{
			OpponentFunctionArea.<DestroyCardByIndex>d__14 <DestroyCardByIndex>d__;
			<DestroyCardByIndex>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DestroyCardByIndex>d__.<>4__this = this;
			<DestroyCardByIndex>d__.index = index;
			<DestroyCardByIndex>d__.<>1__state = -1;
			<DestroyCardByIndex>d__.<>t__builder.Start<OpponentFunctionArea.<DestroyCardByIndex>d__14>(ref <DestroyCardByIndex>d__);
			return <DestroyCardByIndex>d__.<>t__builder.Task;
		}

		// Token: 0x060380DF RID: 229599 RVA: 0x00E334E4 File Offset: 0x00E316E4
		public void RefreshBattleCard(int cardId)
		{
			foreach (OpponentFunctionAreaProxy opponentFunctionAreaProxy in this.CardProxyMap.Values)
			{
				if (opponentFunctionAreaProxy.Card != null && opponentFunctionAreaProxy.Card.Data.CardId == cardId)
				{
					opponentFunctionAreaProxy.Card.RefreshSelfAsync().Forget();
					break;
				}
			}
		}

		// Token: 0x060380E0 RID: 229600 RVA: 0x00E33564 File Offset: 0x00E31764
		public void RefreshAllBattleCard()
		{
			foreach (OpponentFunctionAreaProxy opponentFunctionAreaProxy in this.CardProxyMap.Values)
			{
				if (opponentFunctionAreaProxy.Card != null)
				{
					opponentFunctionAreaProxy.Card.RefreshSelfAsync().Forget();
				}
			}
		}

		// Token: 0x060380E1 RID: 229601 RVA: 0x00E335D0 File Offset: 0x00E317D0
		public OpponentFunctionAreaProxy GetCardProxyByCardId(int cardId)
		{
			foreach (OpponentFunctionAreaProxy opponentFunctionAreaProxy in this.CardProxyMap.Values)
			{
				if (opponentFunctionAreaProxy.Card != null && opponentFunctionAreaProxy.Card.Data.CardId == cardId)
				{
					return opponentFunctionAreaProxy;
				}
			}
			return null;
		}

		// Token: 0x060380E2 RID: 229602 RVA: 0x00E33644 File Offset: 0x00E31844
		public OpponentFunctionAreaProxy GetCardProxyByIndex(int index)
		{
			OpponentFunctionAreaProxy result;
			if (!this.CardProxyMap.TryGetValue(index, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060380E3 RID: 229603 RVA: 0x00E33664 File Offset: 0x00E31864
		public UniTask CopyCardListToFight(List<PhantomBattleFighterInfo> cardInfoList)
		{
			OpponentFunctionArea.<CopyCardListToFight>d__19 <CopyCardListToFight>d__;
			<CopyCardListToFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CopyCardListToFight>d__.<>4__this = this;
			<CopyCardListToFight>d__.cardInfoList = cardInfoList;
			<CopyCardListToFight>d__.<>1__state = -1;
			<CopyCardListToFight>d__.<>t__builder.Start<OpponentFunctionArea.<CopyCardListToFight>d__19>(ref <CopyCardListToFight>d__);
			return <CopyCardListToFight>d__.<>t__builder.Task;
		}

		// Token: 0x060380E4 RID: 229604 RVA: 0x00E336B0 File Offset: 0x00E318B0
		public UniTask PlayDamageHitEffect(int fightId, UUIItem toItem)
		{
			OpponentFunctionArea.<PlayDamageHitEffect>d__20 <PlayDamageHitEffect>d__;
			<PlayDamageHitEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayDamageHitEffect>d__.<>4__this = this;
			<PlayDamageHitEffect>d__.fightId = fightId;
			<PlayDamageHitEffect>d__.toItem = toItem;
			<PlayDamageHitEffect>d__.<>1__state = -1;
			<PlayDamageHitEffect>d__.<>t__builder.Start<OpponentFunctionArea.<PlayDamageHitEffect>d__20>(ref <PlayDamageHitEffect>d__);
			return <PlayDamageHitEffect>d__.<>t__builder.Task;
		}

		// Token: 0x060380E5 RID: 229605 RVA: 0x00E33704 File Offset: 0x00E31904
		public UniTask ReconstructFightCardToRecycle(List<int> cardIdList)
		{
			OpponentFunctionArea.<ReconstructFightCardToRecycle>d__21 <ReconstructFightCardToRecycle>d__;
			<ReconstructFightCardToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ReconstructFightCardToRecycle>d__.<>4__this = this;
			<ReconstructFightCardToRecycle>d__.cardIdList = cardIdList;
			<ReconstructFightCardToRecycle>d__.<>1__state = -1;
			<ReconstructFightCardToRecycle>d__.<>t__builder.Start<OpponentFunctionArea.<ReconstructFightCardToRecycle>d__21>(ref <ReconstructFightCardToRecycle>d__);
			return <ReconstructFightCardToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x060380E6 RID: 229606 RVA: 0x00E33750 File Offset: 0x00E31950
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length < 3)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "BattleCard")
			{
				int key = int.Parse(configParams[2]);
				OpponentFunctionAreaProxy opponentFunctionAreaProxy;
				if (this.CardProxyMap.TryGetValue(key, out opponentFunctionAreaProxy))
				{
					PhantomArenaCard card = opponentFunctionAreaProxy.Card;
					if (card == null)
					{
						return null;
					}
					return card.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
			}
			if (a == "BattleCardById" || a == "BattleCardSkillById")
			{
				int num = int.Parse(configParams[2]);
				foreach (OpponentFunctionAreaProxy opponentFunctionAreaProxy2 in this.CardProxyMap.Values)
				{
					PhantomArenaCard card2 = opponentFunctionAreaProxy2.Card;
					bool flag;
					if (card2 == null)
					{
						flag = false;
					}
					else
					{
						PhantomCardData data = card2.Data;
						int? num2 = (data != null) ? new int?(data.ConfigId) : null;
						int num3 = num;
						flag = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					if (flag)
					{
						return opponentFunctionAreaProxy2.Card.GetGuideUiItemAndUiItemForShowEx(configParams);
					}
				}
			}
			return null;
		}

		// Token: 0x040200D0 RID: 131280
		public OpponentArea ParentArea;

		// Token: 0x040200D1 RID: 131281
		protected Dictionary<int, OpponentFunctionAreaProxy> CardProxyMap = new Dictionary<int, OpponentFunctionAreaProxy>();

		// Token: 0x0200B619 RID: 46617
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038576 RID: 230774
			public const int MonsterOne = 0;

			// Token: 0x04038577 RID: 230775
			public const int MonsterTwo = 1;

			// Token: 0x04038578 RID: 230776
			public const int MonsterThree = 2;

			// Token: 0x04038579 RID: 230777
			public const int MonsterFour = 3;

			// Token: 0x0403857A RID: 230778
			public const int MonsterFive = 4;

			// Token: 0x0403857B RID: 230779
			public const int MonsterSix = 5;

			// Token: 0x0403857C RID: 230780
			public const int FunctionOne = 6;
		}
	}
}
