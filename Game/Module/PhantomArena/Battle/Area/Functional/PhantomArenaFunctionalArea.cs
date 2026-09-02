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

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional
{
	// Token: 0x02005637 RID: 22071
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaFunctionalArea : UiPanelBase
	{
		// Token: 0x0603846C RID: 230508 RVA: 0x00E3F798 File Offset: 0x00E3D998
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

		// Token: 0x0603846D RID: 230509 RVA: 0x00E3F84C File Offset: 0x00E3DA4C
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaFunctionalArea.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603846E RID: 230510 RVA: 0x00E3F890 File Offset: 0x00E3DA90
		private UniTask InitAreaProxy()
		{
			PhantomArenaFunctionalArea.<InitAreaProxy>d__6 <InitAreaProxy>d__;
			<InitAreaProxy>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAreaProxy>d__.<>4__this = this;
			<InitAreaProxy>d__.<>1__state = -1;
			<InitAreaProxy>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<InitAreaProxy>d__6>(ref <InitAreaProxy>d__);
			return <InitAreaProxy>d__.<>t__builder.Task;
		}

		// Token: 0x0603846F RID: 230511 RVA: 0x00E3F8D4 File Offset: 0x00E3DAD4
		public void SetAllCardProxyUseActiveState(bool value, PhantomArenaCard card)
		{
			foreach (PhantomArenaAreaProxyBase phantomArenaAreaProxyBase in this.CardProxyMap.Values)
			{
				if (value && phantomArenaAreaProxyBase.CheckSettingCardCondition(card))
				{
					phantomArenaAreaProxyBase.SetCanUseStateActive(value);
				}
				else
				{
					phantomArenaAreaProxyBase.SetCanUseStateActive(false);
				}
			}
		}

		// Token: 0x06038470 RID: 230512 RVA: 0x00E3F944 File Offset: 0x00E3DB44
		public bool CheckSettingCardPosition(PhantomArenaCard card)
		{
			using (Dictionary<int, PhantomArenaAreaProxyBase>.ValueCollection.Enumerator enumerator = this.CardProxyMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.CheckSettingCardCondition(card))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06038471 RID: 230513 RVA: 0x00E3F9A4 File Offset: 0x00E3DBA4
		public void RegisterBattleArea(PhantomArenaOwnArea area)
		{
			this.ParentArea = area;
		}

		// Token: 0x06038472 RID: 230514 RVA: 0x00E3F9B0 File Offset: 0x00E3DBB0
		public unsafe void RefreshStateByDragCard(PhantomArenaCard card)
		{
			int num = -1;
			double num2 = 99999.0;
			foreach (KeyValuePair<int, PhantomArenaAreaProxyBase> keyValuePair in this.CardProxyMap)
			{
				PhantomArenaAreaProxyBase value = keyValuePair.Value;
				if (value.IsCanSettingCard(card) && value.Distance < num2)
				{
					num2 = value.Distance;
					num = keyValuePair.Key;
				}
			}
			if (this.LastProxyIndex == num)
			{
				return;
			}
			if (this.LastProxyIndex == -1 && num != -1)
			{
				this.SetAllCardProxyUseActiveState(true, card);
			}
			else if (this.LastProxyIndex != -1 && num == -1)
			{
				this.SetAllCardProxyUseActiveState(false, card);
			}
			if (this.LastProxyIndex != -1 && this.CardProxyMap.ContainsKey(this.LastProxyIndex))
			{
				this.CardProxyMap[this.LastProxyIndex].SetHoverStateActive(false);
			}
			if (num != -1 && this.CardProxyMap.ContainsKey(num))
			{
				this.CardProxyMap[num].SetHoverStateActive(true);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "找到放置区的位置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LastProxyIndex", this.LastProxyIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentProxyIndex", num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.LastProxyIndex = num;
		}

		// Token: 0x06038473 RID: 230515 RVA: 0x00E3FB30 File Offset: 0x00E3DD30
		public unsafe void RefreshStateByGamepad(PhantomArenaCard card, int slotIndex)
		{
			int num = -1;
			if (this.CardProxyMap.ContainsKey(slotIndex) && this.CardProxyMap[slotIndex].CheckSettingCardCondition(card))
			{
				num = slotIndex;
			}
			if (this.LastProxyIndex == num)
			{
				return;
			}
			if (this.LastProxyIndex == -1 && num != -1)
			{
				this.SetAllCardProxyUseActiveState(true, card);
			}
			else if (this.LastProxyIndex != -1 && num == -1)
			{
				this.SetAllCardProxyUseActiveState(false, card);
			}
			if (this.LastProxyIndex != -1 && this.CardProxyMap.ContainsKey(this.LastProxyIndex))
			{
				this.CardProxyMap[this.LastProxyIndex].SetHoverStateActive(false);
			}
			if (num != -1 && this.CardProxyMap.ContainsKey(num))
			{
				this.CardProxyMap[num].SetHoverStateActive(true);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "找到放置区的位置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LastProxyIndex", this.LastProxyIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentProxyIndex", num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.LastProxyIndex = num;
		}

		// Token: 0x06038474 RID: 230516 RVA: 0x00E3FC5C File Offset: 0x00E3DE5C
		public void ResetLastProxyIndexByGamepad()
		{
			this.LastProxyIndex = -1;
		}

		// Token: 0x06038475 RID: 230517 RVA: 0x00E3FC68 File Offset: 0x00E3DE68
		public bool CheckGuideCondition(PhantomArenaCard card)
		{
			if (!this.ParentArea.ViewProxy.GuideManager.InGuiding)
			{
				return true;
			}
			PhantomArenaAreaProxyBase nearlyAreaItemProxyByCard = this.GetNearlyAreaItemProxyByCard(card);
			return nearlyAreaItemProxyByCard == null || nearlyAreaItemProxyByCard.CheckGuideCondition(card);
		}

		// Token: 0x06038476 RID: 230518 RVA: 0x00E3FCA4 File Offset: 0x00E3DEA4
		[NullableContext(0)]
		public UniTask<bool> TrySettingCard([Nullable(1)] PhantomArenaCard card, int index, bool needExecLogic)
		{
			PhantomArenaFunctionalArea.<TrySettingCard>d__14 <TrySettingCard>d__;
			<TrySettingCard>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TrySettingCard>d__.<>4__this = this;
			<TrySettingCard>d__.card = card;
			<TrySettingCard>d__.index = index;
			<TrySettingCard>d__.needExecLogic = needExecLogic;
			<TrySettingCard>d__.<>1__state = -1;
			<TrySettingCard>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<TrySettingCard>d__14>(ref <TrySettingCard>d__);
			return <TrySettingCard>d__.<>t__builder.Task;
		}

		// Token: 0x06038477 RID: 230519 RVA: 0x00E3FD00 File Offset: 0x00E3DF00
		public PhantomArenaAreaProxyBase GetNearlyAreaItemProxyByCard(PhantomArenaCard card)
		{
			double num = 99999.0;
			PhantomArenaAreaProxyBase result = null;
			foreach (PhantomArenaAreaProxyBase phantomArenaAreaProxyBase in this.CardProxyMap.Values)
			{
				if (phantomArenaAreaProxyBase.IsCardNearlyAreaItem(card) && phantomArenaAreaProxyBase.Distance < num)
				{
					num = phantomArenaAreaProxyBase.Distance;
					result = phantomArenaAreaProxyBase;
				}
			}
			return result;
		}

		// Token: 0x06038478 RID: 230520 RVA: 0x00E3FD7C File Offset: 0x00E3DF7C
		[NullableContext(0)]
		public UniTask<bool> TryChangeCard([Nullable(1)] PhantomArenaCard card, int index)
		{
			PhantomArenaFunctionalArea.<TryChangeCard>d__16 <TryChangeCard>d__;
			<TryChangeCard>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryChangeCard>d__.<>4__this = this;
			<TryChangeCard>d__.card = card;
			<TryChangeCard>d__.index = index;
			<TryChangeCard>d__.<>1__state = -1;
			<TryChangeCard>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<TryChangeCard>d__16>(ref <TryChangeCard>d__);
			return <TryChangeCard>d__.<>t__builder.Task;
		}

		// Token: 0x06038479 RID: 230521 RVA: 0x00E3FDCF File Offset: 0x00E3DFCF
		public void RemoveCard(int index)
		{
			if (this.CardProxyMap.ContainsKey(index))
			{
				this.CardProxyMap[index].SetCard(null).Forget();
			}
		}

		// Token: 0x0603847A RID: 230522 RVA: 0x00E3FDF6 File Offset: 0x00E3DFF6
		public void ResetCardSelectState(int index)
		{
			if (this.CardProxyMap.ContainsKey(index))
			{
				this.CardProxyMap[index].ResetCardSelectState();
			}
		}

		// Token: 0x0603847B RID: 230523 RVA: 0x00E3FE17 File Offset: 0x00E3E017
		public void FinishBuffEffect(int index)
		{
			if (this.CardProxyMap.ContainsKey(index))
			{
				PhantomArenaAreaFunctionalProxy phantomArenaAreaFunctionalProxy = this.CardProxyMap[index] as PhantomArenaAreaFunctionalProxy;
				if (phantomArenaAreaFunctionalProxy == null)
				{
					return;
				}
				phantomArenaAreaFunctionalProxy.SetCard(null).Forget();
			}
		}

		// Token: 0x0603847C RID: 230524 RVA: 0x00E3FE48 File Offset: 0x00E3E048
		public void ShowAddBuffEffect(EBuffShowType buffShowType, List<int> fightIdList)
		{
			foreach (PhantomArenaAreaProxyBase phantomArenaAreaProxyBase in this.CardProxyMap.Values)
			{
				if (phantomArenaAreaProxyBase.Card != null && fightIdList.Contains(phantomArenaAreaProxyBase.Card.Data.FightId))
				{
					PhantomArenaAreaMonsterProxy phantomArenaAreaMonsterProxy = (PhantomArenaAreaMonsterProxy)phantomArenaAreaProxyBase;
					if (buffShowType == EBuffShowType.UpGrade)
					{
						if (phantomArenaAreaMonsterProxy != null)
						{
							phantomArenaAreaMonsterProxy.AreaItem.SetBuffUpActive(true);
						}
					}
					else if (buffShowType == EBuffShowType.DownGrade && phantomArenaAreaMonsterProxy != null)
					{
						phantomArenaAreaMonsterProxy.AreaItem.SetBuffDownActive(true);
					}
				}
			}
		}

		// Token: 0x0603847D RID: 230525 RVA: 0x00E3FEEC File Offset: 0x00E3E0EC
		public void RefreshBattleCard(int cardId)
		{
			foreach (PhantomArenaAreaProxyBase phantomArenaAreaProxyBase in this.CardProxyMap.Values)
			{
				if (phantomArenaAreaProxyBase.Card != null && phantomArenaAreaProxyBase.Card.Data.CardId == cardId)
				{
					phantomArenaAreaProxyBase.Card.RefreshSelfAsync().Forget();
					break;
				}
			}
		}

		// Token: 0x0603847E RID: 230526 RVA: 0x00E3FF6C File Offset: 0x00E3E16C
		public void RefreshAllBattleCard()
		{
			foreach (PhantomArenaAreaProxyBase phantomArenaAreaProxyBase in this.CardProxyMap.Values)
			{
				if (phantomArenaAreaProxyBase.Card != null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PhantomArena;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "RefreshAllBattleCard";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CardId", phantomArenaAreaProxyBase.Card.Data.CardId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					phantomArenaAreaProxyBase.Card.RefreshSelfAsync().Forget();
				}
			}
		}

		// Token: 0x0603847F RID: 230527 RVA: 0x00E40014 File Offset: 0x00E3E214
		public PhantomArenaAreaProxyBase GetCardProxyByCardId(int cardId)
		{
			foreach (PhantomArenaAreaProxyBase phantomArenaAreaProxyBase in this.CardProxyMap.Values)
			{
				if (phantomArenaAreaProxyBase.Card != null && phantomArenaAreaProxyBase.Card.Data.CardId == cardId)
				{
					return phantomArenaAreaProxyBase;
				}
			}
			return null;
		}

		// Token: 0x06038480 RID: 230528 RVA: 0x00E40088 File Offset: 0x00E3E288
		public UniTask DestroyCardByLibrary(int index)
		{
			PhantomArenaFunctionalArea.<DestroyCardByLibrary>d__24 <DestroyCardByLibrary>d__;
			<DestroyCardByLibrary>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DestroyCardByLibrary>d__.<>4__this = this;
			<DestroyCardByLibrary>d__.index = index;
			<DestroyCardByLibrary>d__.<>1__state = -1;
			<DestroyCardByLibrary>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<DestroyCardByLibrary>d__24>(ref <DestroyCardByLibrary>d__);
			return <DestroyCardByLibrary>d__.<>t__builder.Task;
		}

		// Token: 0x06038481 RID: 230529 RVA: 0x00E400D4 File Offset: 0x00E3E2D4
		public UniTask ResetCardPosition(int index)
		{
			PhantomArenaFunctionalArea.<ResetCardPosition>d__25 <ResetCardPosition>d__;
			<ResetCardPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetCardPosition>d__.<>4__this = this;
			<ResetCardPosition>d__.index = index;
			<ResetCardPosition>d__.<>1__state = -1;
			<ResetCardPosition>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<ResetCardPosition>d__25>(ref <ResetCardPosition>d__);
			return <ResetCardPosition>d__.<>t__builder.Task;
		}

		// Token: 0x06038482 RID: 230530 RVA: 0x00E40120 File Offset: 0x00E3E320
		public UniTask RemoveCardToLibrary(int index)
		{
			PhantomArenaFunctionalArea.<RemoveCardToLibrary>d__26 <RemoveCardToLibrary>d__;
			<RemoveCardToLibrary>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RemoveCardToLibrary>d__.<>4__this = this;
			<RemoveCardToLibrary>d__.index = index;
			<RemoveCardToLibrary>d__.<>1__state = -1;
			<RemoveCardToLibrary>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<RemoveCardToLibrary>d__26>(ref <RemoveCardToLibrary>d__);
			return <RemoveCardToLibrary>d__.<>t__builder.Task;
		}

		// Token: 0x06038483 RID: 230531 RVA: 0x00E4016C File Offset: 0x00E3E36C
		public UniTask ResetFunctionalToMonster(PhantomArenaCard card, int lastCardIndex, int index)
		{
			PhantomArenaFunctionalArea.<ResetFunctionalToMonster>d__27 <ResetFunctionalToMonster>d__;
			<ResetFunctionalToMonster>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetFunctionalToMonster>d__.<>4__this = this;
			<ResetFunctionalToMonster>d__.card = card;
			<ResetFunctionalToMonster>d__.lastCardIndex = lastCardIndex;
			<ResetFunctionalToMonster>d__.index = index;
			<ResetFunctionalToMonster>d__.<>1__state = -1;
			<ResetFunctionalToMonster>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<ResetFunctionalToMonster>d__27>(ref <ResetFunctionalToMonster>d__);
			return <ResetFunctionalToMonster>d__.<>t__builder.Task;
		}

		// Token: 0x06038484 RID: 230532 RVA: 0x00E401C8 File Offset: 0x00E3E3C8
		public UniTask FunctionalCardToFunctionalTop(PhantomArenaCard card, int slotIndex, bool needDragUpTween)
		{
			PhantomArenaFunctionalArea.<FunctionalCardToFunctionalTop>d__28 <FunctionalCardToFunctionalTop>d__;
			<FunctionalCardToFunctionalTop>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FunctionalCardToFunctionalTop>d__.<>4__this = this;
			<FunctionalCardToFunctionalTop>d__.card = card;
			<FunctionalCardToFunctionalTop>d__.slotIndex = slotIndex;
			<FunctionalCardToFunctionalTop>d__.needDragUpTween = needDragUpTween;
			<FunctionalCardToFunctionalTop>d__.<>1__state = -1;
			<FunctionalCardToFunctionalTop>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<FunctionalCardToFunctionalTop>d__28>(ref <FunctionalCardToFunctionalTop>d__);
			return <FunctionalCardToFunctionalTop>d__.<>t__builder.Task;
		}

		// Token: 0x06038485 RID: 230533 RVA: 0x00E40224 File Offset: 0x00E3E424
		public UniTask CopyCardListToFight(PhantomBattleFighterInfo[] cardInfoList)
		{
			PhantomArenaFunctionalArea.<CopyCardListToFight>d__29 <CopyCardListToFight>d__;
			<CopyCardListToFight>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CopyCardListToFight>d__.<>4__this = this;
			<CopyCardListToFight>d__.cardInfoList = cardInfoList;
			<CopyCardListToFight>d__.<>1__state = -1;
			<CopyCardListToFight>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<CopyCardListToFight>d__29>(ref <CopyCardListToFight>d__);
			return <CopyCardListToFight>d__.<>t__builder.Task;
		}

		// Token: 0x06038486 RID: 230534 RVA: 0x00E40270 File Offset: 0x00E3E470
		public UniTask PlayDamageHitEffect(int fightId, UUIItem toItem)
		{
			PhantomArenaFunctionalArea.<PlayDamageHitEffect>d__30 <PlayDamageHitEffect>d__;
			<PlayDamageHitEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayDamageHitEffect>d__.<>4__this = this;
			<PlayDamageHitEffect>d__.fightId = fightId;
			<PlayDamageHitEffect>d__.toItem = toItem;
			<PlayDamageHitEffect>d__.<>1__state = -1;
			<PlayDamageHitEffect>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<PlayDamageHitEffect>d__30>(ref <PlayDamageHitEffect>d__);
			return <PlayDamageHitEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038487 RID: 230535 RVA: 0x00E402C4 File Offset: 0x00E3E4C4
		public UniTask FunctionalToRecycle(PhantomArenaCard card)
		{
			PhantomArenaFunctionalArea.<FunctionalToRecycle>d__31 <FunctionalToRecycle>d__;
			<FunctionalToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FunctionalToRecycle>d__.<>4__this = this;
			<FunctionalToRecycle>d__.card = card;
			<FunctionalToRecycle>d__.<>1__state = -1;
			<FunctionalToRecycle>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<FunctionalToRecycle>d__31>(ref <FunctionalToRecycle>d__);
			return <FunctionalToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x06038488 RID: 230536 RVA: 0x00E4030F File Offset: 0x00E3E50F
		public PhantomArenaAreaProxyBase GetCardProxyByIndex(int index)
		{
			if (!this.CardProxyMap.ContainsKey(index))
			{
				return null;
			}
			return this.CardProxyMap[index];
		}

		// Token: 0x06038489 RID: 230537 RVA: 0x00E40330 File Offset: 0x00E3E530
		public UniTask RefreshEffect(int cardId, int curEffectCount)
		{
			PhantomArenaFunctionalArea.<RefreshEffect>d__33 <RefreshEffect>d__;
			<RefreshEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEffect>d__.<>4__this = this;
			<RefreshEffect>d__.cardId = cardId;
			<RefreshEffect>d__.curEffectCount = curEffectCount;
			<RefreshEffect>d__.<>1__state = -1;
			<RefreshEffect>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<RefreshEffect>d__33>(ref <RefreshEffect>d__);
			return <RefreshEffect>d__.<>t__builder.Task;
		}

		// Token: 0x0603848A RID: 230538 RVA: 0x00E40384 File Offset: 0x00E3E584
		public UniTask ReconstructFightCardToRecycle(List<int> cardIdList)
		{
			PhantomArenaFunctionalArea.<ReconstructFightCardToRecycle>d__34 <ReconstructFightCardToRecycle>d__;
			<ReconstructFightCardToRecycle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ReconstructFightCardToRecycle>d__.<>4__this = this;
			<ReconstructFightCardToRecycle>d__.cardIdList = cardIdList;
			<ReconstructFightCardToRecycle>d__.<>1__state = -1;
			<ReconstructFightCardToRecycle>d__.<>t__builder.Start<PhantomArenaFunctionalArea.<ReconstructFightCardToRecycle>d__34>(ref <ReconstructFightCardToRecycle>d__);
			return <ReconstructFightCardToRecycle>d__.<>t__builder.Task;
		}

		// Token: 0x0603848B RID: 230539 RVA: 0x00E403D0 File Offset: 0x00E3E5D0
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length < 3)
			{
				return null;
			}
			string a = configParams[0];
			if (!(a == "BattleCard"))
			{
				if (a == "BattleCardById" || a == "BattleCardSkillById")
				{
					int num = int.Parse(configParams[2]);
					foreach (PhantomArenaAreaProxyBase phantomArenaAreaProxyBase in this.CardProxyMap.Values)
					{
						PhantomArenaCard card = phantomArenaAreaProxyBase.Card;
						bool flag;
						if (card == null)
						{
							flag = false;
						}
						else
						{
							PhantomCardData data = card.Data;
							int? num2 = (data != null) ? new int?(data.ConfigId) : null;
							int num3 = num;
							flag = (num2.GetValueOrDefault() == num3 & num2 != null);
						}
						if (flag)
						{
							return phantomArenaAreaProxyBase.Card.GetGuideUiItemAndUiItemForShowEx(configParams);
						}
					}
				}
				return null;
			}
			int key = int.Parse(configParams[2]);
			if (!this.CardProxyMap.ContainsKey(key))
			{
				return null;
			}
			PhantomArenaCard card2 = this.CardProxyMap[key].Card;
			if (card2 == null)
			{
				return null;
			}
			return card2.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x040201DB RID: 131547
		public PhantomArenaOwnArea ParentArea;

		// Token: 0x040201DC RID: 131548
		protected Dictionary<int, PhantomArenaAreaProxyBase> CardProxyMap = new Dictionary<int, PhantomArenaAreaProxyBase>();

		// Token: 0x040201DD RID: 131549
		private int LastProxyIndex = -1;

		// Token: 0x0200B6DD RID: 46813
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x04038937 RID: 231735
			public const int MonsterOne = 0;

			// Token: 0x04038938 RID: 231736
			public const int MonsterTwo = 1;

			// Token: 0x04038939 RID: 231737
			public const int MonsterThree = 2;

			// Token: 0x0403893A RID: 231738
			public const int MonsterFour = 3;

			// Token: 0x0403893B RID: 231739
			public const int MonsterFive = 4;

			// Token: 0x0403893C RID: 231740
			public const int MonsterSix = 5;

			// Token: 0x0403893D RID: 231741
			public const int FunctionOne = 6;
		}
	}
}
