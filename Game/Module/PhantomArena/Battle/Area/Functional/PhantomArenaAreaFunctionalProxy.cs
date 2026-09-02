using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Hand;
using CSharpScript.Game.Module.PhantomArena.Battle.Canvas;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional
{
	// Token: 0x02005632 RID: 22066
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaAreaFunctionalProxy : PhantomArenaAreaProxyBase, IAreaCanvas, ISkillInteractMainInterface
	{
		// Token: 0x1700906D RID: 36973
		// (get) Token: 0x06038408 RID: 230408 RVA: 0x00E3E62C File Offset: 0x00E3C82C
		// (set) Token: 0x06038409 RID: 230409 RVA: 0x00E3E639 File Offset: 0x00E3C839
		public new PhantomArenaAreaFunctionalItem AreaItem
		{
			get
			{
				return base.AreaItem as PhantomArenaAreaFunctionalItem;
			}
			set
			{
				base.AreaItem = value;
			}
		}

		// Token: 0x1700906E RID: 36974
		// (get) Token: 0x0603840A RID: 230410 RVA: 0x00E3E642 File Offset: 0x00E3C842
		public override EPhantomArenaCardAreaType AreaType
		{
			get
			{
				return EPhantomArenaCardAreaType.Functional;
			}
		}

		// Token: 0x0603840B RID: 230411 RVA: 0x00E3E645 File Offset: 0x00E3C845
		public PhantomArenaAreaFunctionalProxy(int index, PhantomArenaFunctionalArea area) : base(index, area)
		{
		}

		// Token: 0x0603840C RID: 230412 RVA: 0x00E3E64F File Offset: 0x00E3C84F
		private void MagicUseCard()
		{
			if (this.Card != null)
			{
				this.Card.MagicUse().Forget();
				this.Card = null;
			}
		}

		// Token: 0x0603840D RID: 230413 RVA: 0x00E3E670 File Offset: 0x00E3C870
		[NullableContext(0)]
		protected UniTask<bool> OnHandleAreaBySetCard()
		{
			PhantomArenaAreaFunctionalProxy.<OnHandleAreaBySetCard>d__8 <OnHandleAreaBySetCard>d__;
			<OnHandleAreaBySetCard>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnHandleAreaBySetCard>d__.<>4__this = this;
			<OnHandleAreaBySetCard>d__.<>1__state = -1;
			<OnHandleAreaBySetCard>d__.<>t__builder.Start<PhantomArenaAreaFunctionalProxy.<OnHandleAreaBySetCard>d__8>(ref <OnHandleAreaBySetCard>d__);
			return <OnHandleAreaBySetCard>d__.<>t__builder.Task;
		}

		// Token: 0x0603840E RID: 230414 RVA: 0x00E3E6B4 File Offset: 0x00E3C8B4
		protected void ResetCardProxy()
		{
			if (this.Card != null)
			{
				if (this.Card.Data.Index == -1)
				{
					PhantomArenaHandCardProxy cardProxy = this.ParentArea.ParentArea.HandArea.GetCardProxy(this.Card.Data.CardId);
					this.Card.SetCardProxy(cardProxy);
					this.SetCard(null).Forget();
					return;
				}
				PhantomArenaAreaProxyBase cardProxyByIndex = this.ParentArea.ParentArea.FunctionalArea.GetCardProxyByIndex(this.Card.Data.Index);
				this.Card.SetCardProxy(cardProxyByIndex.GetCardProxy());
				this.SetCard(null).Forget();
			}
		}

		// Token: 0x0603840F RID: 230415 RVA: 0x00E3E764 File Offset: 0x00E3C964
		[NullableContext(0)]
		protected override UniTask<bool> OnHandleCardSetting([Nullable(1)] PhantomArenaCard card)
		{
			PhantomArenaAreaFunctionalProxy.<OnHandleCardSetting>d__10 <OnHandleCardSetting>d__;
			<OnHandleCardSetting>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnHandleCardSetting>d__.<>4__this = this;
			<OnHandleCardSetting>d__.card = card;
			<OnHandleCardSetting>d__.<>1__state = -1;
			<OnHandleCardSetting>d__.<>t__builder.Start<PhantomArenaAreaFunctionalProxy.<OnHandleCardSetting>d__10>(ref <OnHandleCardSetting>d__);
			return <OnHandleCardSetting>d__.<>t__builder.Task;
		}

		// Token: 0x06038410 RID: 230416 RVA: 0x00E3E7B0 File Offset: 0x00E3C9B0
		public override bool CheckGuideCondition(PhantomArenaCard card)
		{
			if (card.Data.Index == -1)
			{
				int handIndexByCardId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetHandIndexByCardId(card.Data.CardId);
				return this.ParentArea.ParentArea.ViewProxy.GuideManager.CheckCanExecuteAndShowFailTips(EBvbPlayerOperationType.BvbChangeHandCard, new object[]
				{
					handIndexByCardId
				});
			}
			return this.ParentArea.ParentArea.ViewProxy.GuideManager.CheckCanExecuteAndShowFailTips(EBvbPlayerOperationType.BvbChangeBoardCard, new object[]
			{
				card.Data.Index
			});
		}

		// Token: 0x06038411 RID: 230417 RVA: 0x00E3E848 File Offset: 0x00E3CA48
		public override bool CheckSettingCardCondition(PhantomArenaCard card)
		{
			bool flag;
			EPhantomCardSettingFailReason ephantomCardSettingFailReason;
			card.CardLogic.CheckFunctionalSettingCondition(this.Card).Deconstruct(out flag, out ephantomCardSettingFailReason);
			bool result = flag;
			EPhantomCardSettingFailReason settingFailReason = ephantomCardSettingFailReason;
			this.SettingFailReason = settingFailReason;
			return result;
		}

		// Token: 0x06038412 RID: 230418 RVA: 0x00E3E879 File Offset: 0x00E3CA79
		protected override UUIItem GetCardRootItem()
		{
			return this.AreaItem.GetCardRootItem();
		}

		// Token: 0x06038413 RID: 230419 RVA: 0x00E3E886 File Offset: 0x00E3CA86
		public bool CheckCanvasSortOrder(List<EPhantomArenaInteractTag> tagList, ISkillTriggerInfo skillTriggerInfo)
		{
			return this.Card != null;
		}

		// Token: 0x06038414 RID: 230420 RVA: 0x00E3E894 File Offset: 0x00E3CA94
		public void HandleSortOrder()
		{
			if (this.Card != null)
			{
				this.Card.OverrideCanvasSortOrder(true);
				ULGUICanvas renderCanvas = this.AreaItem.GetCardRootItem().GetRenderCanvas();
				if (renderCanvas != null)
				{
					renderCanvas.SetSortOrderNew(2, true);
				}
				this.Card.PlayStateSequence("PointStart");
				this.InSkillInteract = true;
			}
		}

		// Token: 0x06038415 RID: 230421 RVA: 0x00E3E8E8 File Offset: 0x00E3CAE8
		public void CancelSortOrder()
		{
			if (this.Card != null)
			{
				this.Card.OverrideCanvasSortOrder(false);
				ULGUICanvas renderCanvas = this.AreaItem.GetCardRootItem().GetRenderCanvas();
				if (renderCanvas != null)
				{
					renderCanvas.SetSortOrderNew(0, true);
				}
				this.Card.PlayStateSequence("PointClose");
				this.InSkillInteract = false;
			}
		}

		// Token: 0x06038416 RID: 230422 RVA: 0x00E3E93C File Offset: 0x00E3CB3C
		public UniTask StartSkillInteract()
		{
			PhantomArenaAreaFunctionalProxy.<StartSkillInteract>d__17 <StartSkillInteract>d__;
			<StartSkillInteract>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartSkillInteract>d__.<>4__this = this;
			<StartSkillInteract>d__.<>1__state = -1;
			<StartSkillInteract>d__.<>t__builder.Start<PhantomArenaAreaFunctionalProxy.<StartSkillInteract>d__17>(ref <StartSkillInteract>d__);
			return <StartSkillInteract>d__.<>t__builder.Task;
		}

		// Token: 0x06038417 RID: 230423 RVA: 0x00E3E980 File Offset: 0x00E3CB80
		public void CancelSkillInteract()
		{
			this.AreaItem.SetIncreaseActive(false).Forget();
			if (this.Card != null)
			{
				if (this.Card.Data.Index != -1)
				{
					this.ParentArea.ParentArea.FunctionalArea.ResetFunctionalToMonster(this.Card, this.Card.Data.Index, this.Index).Forget();
					return;
				}
				this.ParentArea.ParentArea.ResetFunctionalToHand(this.Card, this.Index);
			}
		}

		// Token: 0x06038418 RID: 230424 RVA: 0x00E3EA0C File Offset: 0x00E3CC0C
		public ISkillTriggerInfo GetData()
		{
			return ModelBase<PhantomArenaBattleModel>.Instance.BuffEffectData.CardSkillTriggerInfo;
		}

		// Token: 0x06038419 RID: 230425 RVA: 0x00E3EA1D File Offset: 0x00E3CC1D
		public void FinishSkillInteract()
		{
			this.AreaItem.SetIncreaseActive(false).Forget();
			base.DestroyCard();
			this.ParentArea.FinishBuffEffect(this.Index);
		}

		// Token: 0x0603841A RID: 230426 RVA: 0x00E3EA47 File Offset: 0x00E3CC47
		[NullableContext(2)]
		public void ReceiveUiInteract(ISkillInteractMainUiInteract uiInteract)
		{
		}

		// Token: 0x040201C9 RID: 131529
		public bool InSkillInteract;
	}
}
