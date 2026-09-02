using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional
{
	// Token: 0x02005636 RID: 22070
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class PhantomArenaAreaProxyBase
	{
		// Token: 0x17009071 RID: 36977
		// (get) Token: 0x0603844B RID: 230475 RVA: 0x00E3F331 File Offset: 0x00E3D531
		// (set) Token: 0x0603844C RID: 230476 RVA: 0x00E3F339 File Offset: 0x00E3D539
		public double Distance { get; set; }

		// Token: 0x17009072 RID: 36978
		// (get) Token: 0x0603844D RID: 230477 RVA: 0x00E3F342 File Offset: 0x00E3D542
		// (set) Token: 0x0603844E RID: 230478 RVA: 0x00E3F34A File Offset: 0x00E3D54A
		public PhantomArenaAreaItemBase AreaItem { get; set; }

		// Token: 0x0603844F RID: 230479 RVA: 0x00E3F353 File Offset: 0x00E3D553
		public PhantomArenaAreaProxyBase(int index, PhantomArenaFunctionalArea area)
		{
			this.Distance = 99999.0;
			this.Index = index;
			this.ParentArea = area;
		}

		// Token: 0x06038450 RID: 230480 RVA: 0x00E3F38A File Offset: 0x00E3D58A
		protected void SetCardResetPosition(PhantomArenaCard card)
		{
			card.SetUiParent(this.GetCardRootItem(), true);
			card.PlayStateSequence("SeleClose");
		}

		// Token: 0x06038451 RID: 230481 RVA: 0x00E3F3A4 File Offset: 0x00E3D5A4
		protected void DestroyCard()
		{
			if (this.Card != null)
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "Card Destroy", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.Card.Destroy(null);
				this.Card = null;
			}
		}

		// Token: 0x06038452 RID: 230482 RVA: 0x00E3F3EB File Offset: 0x00E3D5EB
		public void SetAreaItem(PhantomArenaAreaItemBase areaItem)
		{
			this.AreaItem = areaItem;
			this.AreaItem.SetProxy(this);
		}

		// Token: 0x06038453 RID: 230483 RVA: 0x00E3F400 File Offset: 0x00E3D600
		[NullableContext(2)]
		public IPhantomCardProxyBase GetCardProxy()
		{
			return this as IPhantomCardProxyBase;
		}

		// Token: 0x06038454 RID: 230484 RVA: 0x00E3F408 File Offset: 0x00E3D608
		[NullableContext(2)]
		public virtual UniTask SetCard(PhantomArenaCard card)
		{
			PhantomArenaAreaProxyBase.<SetCard>d__18 <SetCard>d__;
			<SetCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetCard>d__.<>4__this = this;
			<SetCard>d__.card = card;
			<SetCard>d__.<>1__state = -1;
			<SetCard>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<SetCard>d__18>(ref <SetCard>d__);
			return <SetCard>d__.<>t__builder.Task;
		}

		// Token: 0x06038455 RID: 230485 RVA: 0x00E3F454 File Offset: 0x00E3D654
		public UniTask ChangeCard(PhantomArenaCard card)
		{
			PhantomArenaAreaProxyBase.<ChangeCard>d__19 <ChangeCard>d__;
			<ChangeCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeCard>d__.<>4__this = this;
			<ChangeCard>d__.card = card;
			<ChangeCard>d__.<>1__state = -1;
			<ChangeCard>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<ChangeCard>d__19>(ref <ChangeCard>d__);
			return <ChangeCard>d__.<>t__builder.Task;
		}

		// Token: 0x06038456 RID: 230486 RVA: 0x00E3F4A0 File Offset: 0x00E3D6A0
		public UniTask DissolveByLibrary()
		{
			PhantomArenaAreaProxyBase.<DissolveByLibrary>d__20 <DissolveByLibrary>d__;
			<DissolveByLibrary>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DissolveByLibrary>d__.<>4__this = this;
			<DissolveByLibrary>d__.<>1__state = -1;
			<DissolveByLibrary>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<DissolveByLibrary>d__20>(ref <DissolveByLibrary>d__);
			return <DissolveByLibrary>d__.<>t__builder.Task;
		}

		// Token: 0x06038457 RID: 230487 RVA: 0x00E3F4E3 File Offset: 0x00E3D6E3
		public bool IsCanSettingCard(PhantomArenaCard card)
		{
			return this.CheckSettingCardCondition(card) && this.IsCardNearlyAreaItem(card);
		}

		// Token: 0x06038458 RID: 230488 RVA: 0x00E3F4F7 File Offset: 0x00E3D6F7
		public void SetHoverStateActive(bool value)
		{
			this.AreaItem.SetHoverStateActive(value);
		}

		// Token: 0x06038459 RID: 230489 RVA: 0x00E3F505 File Offset: 0x00E3D705
		public void SetCanUseStateActive(bool value)
		{
			this.AreaItem.SetCanUseStateActive(value);
		}

		// Token: 0x0603845A RID: 230490 RVA: 0x00E3F514 File Offset: 0x00E3D714
		[NullableContext(0)]
		public UniTask<bool> HandleCardSetting([Nullable(1)] PhantomArenaCard card)
		{
			PhantomArenaAreaProxyBase.<HandleCardSetting>d__24 <HandleCardSetting>d__;
			<HandleCardSetting>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<HandleCardSetting>d__.<>4__this = this;
			<HandleCardSetting>d__.card = card;
			<HandleCardSetting>d__.<>1__state = -1;
			<HandleCardSetting>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<HandleCardSetting>d__24>(ref <HandleCardSetting>d__);
			return <HandleCardSetting>d__.<>t__builder.Task;
		}

		// Token: 0x0603845B RID: 230491 RVA: 0x00E3F55F File Offset: 0x00E3D75F
		public void ResetCardSelectState()
		{
			PhantomArenaCard card = this.Card;
			if (card == null)
			{
				return;
			}
			card.SetToggleState(EToggleState.ETT_UnChecked, false);
		}

		// Token: 0x0603845C RID: 230492 RVA: 0x00E3F574 File Offset: 0x00E3D774
		public bool IsCardNearlyAreaItem(PhantomArenaCard card)
		{
			Vector worldLocation = this.AreaItem.GetWorldLocation();
			Vector worldLocation2 = card.GetWorldLocation();
			this.Distance = Vector.Distance(worldLocation, worldLocation2);
			return this.Distance <= 200.0;
		}

		// Token: 0x0603845D RID: 230493 RVA: 0x00E3F5B5 File Offset: 0x00E3D7B5
		public EPhantomCardSettingFailReason GetSettingFailReason()
		{
			return this.SettingFailReason;
		}

		// Token: 0x0603845E RID: 230494 RVA: 0x00E3F5BD File Offset: 0x00E3D7BD
		public void ResetSettingFailReason()
		{
			this.SettingFailReason = EPhantomCardSettingFailReason.None;
		}

		// Token: 0x0603845F RID: 230495 RVA: 0x00E3F5CA File Offset: 0x00E3D7CA
		public void SetCardSelectedState(bool value)
		{
			PhantomArenaCard card = this.Card;
			if (card == null)
			{
				return;
			}
			card.SetSelectedState(value);
		}

		// Token: 0x06038460 RID: 230496 RVA: 0x00E3F5E0 File Offset: 0x00E3D7E0
		public UniTask PlayResetPositionTween()
		{
			PhantomArenaAreaProxyBase.<PlayResetPositionTween>d__30 <PlayResetPositionTween>d__;
			<PlayResetPositionTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayResetPositionTween>d__.<>4__this = this;
			<PlayResetPositionTween>d__.<>1__state = -1;
			<PlayResetPositionTween>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<PlayResetPositionTween>d__30>(ref <PlayResetPositionTween>d__);
			return <PlayResetPositionTween>d__.<>t__builder.Task;
		}

		// Token: 0x06038461 RID: 230497 RVA: 0x00E3F624 File Offset: 0x00E3D824
		public UniTask PlayChangeCardTween(UUIItem fromItem)
		{
			PhantomArenaAreaProxyBase.<PlayChangeCardTween>d__31 <PlayChangeCardTween>d__;
			<PlayChangeCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayChangeCardTween>d__.<>4__this = this;
			<PlayChangeCardTween>d__.fromItem = fromItem;
			<PlayChangeCardTween>d__.<>1__state = -1;
			<PlayChangeCardTween>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<PlayChangeCardTween>d__31>(ref <PlayChangeCardTween>d__);
			return <PlayChangeCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x06038462 RID: 230498 RVA: 0x00E3F670 File Offset: 0x00E3D870
		public UniTask PlaySetCardTween()
		{
			PhantomArenaAreaProxyBase.<PlaySetCardTween>d__32 <PlaySetCardTween>d__;
			<PlaySetCardTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySetCardTween>d__.<>4__this = this;
			<PlaySetCardTween>d__.<>1__state = -1;
			<PlaySetCardTween>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<PlaySetCardTween>d__32>(ref <PlaySetCardTween>d__);
			return <PlaySetCardTween>d__.<>t__builder.Task;
		}

		// Token: 0x06038463 RID: 230499 RVA: 0x00E3F6B4 File Offset: 0x00E3D8B4
		public UniTask PlayFunctionalCardToFunctionalTopTween(UUIItem toItem, bool needDragUpTween)
		{
			PhantomArenaAreaProxyBase.<PlayFunctionalCardToFunctionalTopTween>d__33 <PlayFunctionalCardToFunctionalTopTween>d__;
			<PlayFunctionalCardToFunctionalTopTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayFunctionalCardToFunctionalTopTween>d__.<>4__this = this;
			<PlayFunctionalCardToFunctionalTopTween>d__.toItem = toItem;
			<PlayFunctionalCardToFunctionalTopTween>d__.needDragUpTween = needDragUpTween;
			<PlayFunctionalCardToFunctionalTopTween>d__.<>1__state = -1;
			<PlayFunctionalCardToFunctionalTopTween>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<PlayFunctionalCardToFunctionalTopTween>d__33>(ref <PlayFunctionalCardToFunctionalTopTween>d__);
			return <PlayFunctionalCardToFunctionalTopTween>d__.<>t__builder.Task;
		}

		// Token: 0x06038464 RID: 230500 RVA: 0x00E3F708 File Offset: 0x00E3D908
		public UniTask PlayFunctionalCardToRecycleTween()
		{
			PhantomArenaAreaProxyBase.<PlayFunctionalCardToRecycleTween>d__34 <PlayFunctionalCardToRecycleTween>d__;
			<PlayFunctionalCardToRecycleTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayFunctionalCardToRecycleTween>d__.<>4__this = this;
			<PlayFunctionalCardToRecycleTween>d__.<>1__state = -1;
			<PlayFunctionalCardToRecycleTween>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<PlayFunctionalCardToRecycleTween>d__34>(ref <PlayFunctionalCardToRecycleTween>d__);
			return <PlayFunctionalCardToRecycleTween>d__.<>t__builder.Task;
		}

		// Token: 0x06038465 RID: 230501 RVA: 0x00E3F74C File Offset: 0x00E3D94C
		public UniTask PlayCardToLibraryTween()
		{
			PhantomArenaAreaProxyBase.<PlayCardToLibraryTween>d__35 <PlayCardToLibraryTween>d__;
			<PlayCardToLibraryTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCardToLibraryTween>d__.<>4__this = this;
			<PlayCardToLibraryTween>d__.<>1__state = -1;
			<PlayCardToLibraryTween>d__.<>t__builder.Start<PhantomArenaAreaProxyBase.<PlayCardToLibraryTween>d__35>(ref <PlayCardToLibraryTween>d__);
			return <PlayCardToLibraryTween>d__.<>t__builder.Task;
		}

		// Token: 0x06038466 RID: 230502 RVA: 0x00E3F78F File Offset: 0x00E3D98F
		public PhantomArenaAreaItemBase GetAreaItem()
		{
			return this.AreaItem;
		}

		// Token: 0x17009073 RID: 36979
		// (get) Token: 0x06038467 RID: 230503
		public abstract EPhantomArenaCardAreaType AreaType { get; }

		// Token: 0x06038468 RID: 230504
		public abstract bool CheckSettingCardCondition(PhantomArenaCard card);

		// Token: 0x06038469 RID: 230505
		public abstract bool CheckGuideCondition(PhantomArenaCard card);

		// Token: 0x0603846A RID: 230506
		[NullableContext(0)]
		protected abstract UniTask<bool> OnHandleCardSetting([Nullable(1)] PhantomArenaCard card);

		// Token: 0x0603846B RID: 230507
		protected abstract UUIItem GetCardRootItem();

		// Token: 0x040201D5 RID: 131541
		public int Index = -1;

		// Token: 0x040201D6 RID: 131542
		[Nullable(2)]
		public PhantomArenaCard Card;

		// Token: 0x040201D8 RID: 131544
		public PhantomArenaFunctionalArea ParentArea;

		// Token: 0x040201D9 RID: 131545
		protected EPhantomCardSettingFailReason SettingFailReason = EPhantomCardSettingFailReason.None;

		// Token: 0x040201DA RID: 131546
		public bool IsInCardTween;
	}
}
