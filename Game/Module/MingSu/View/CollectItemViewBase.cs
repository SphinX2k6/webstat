using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MingSu.View
{
	// Token: 0x0200573A RID: 22330
	public class CollectItemViewBase : UiViewBase
	{
		// Token: 0x06038D5B RID: 232795 RVA: 0x00E65A18 File Offset: 0x00E63C18
		[NullableContext(1)]
		public CollectItemViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038D5C RID: 232796 RVA: 0x00E65A24 File Offset: 0x00E63C24
		protected override void OnStart()
		{
			MingSuModel instance = ModelBase<MingSuModel>.Instance;
			this.PoolConfigId = instance.GetCurrentDragonPoolId();
			this.CollectItemConfigId = instance.GetCollectItemConfigId();
			this.CurrentShowLevel = instance.GetTargetDragonPoolLevelById(this.PoolConfigId) + 1;
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add(EEventName.OnAntiqueShopUpgradeSequencePlayFail, new Action(this.OnSubmitItemLevelUpSequencePlayFailCallback));
			Singleton<EventSystem>.Instance.Add(EEventName.UpdateDragonPoolView, new Action(this.OnUpdateDragonPoolViewCallback));
			Singleton<EventSystem>.Instance.Add(EEventName.OnAntiqueShopLevelMaxSequenceFinished, new Action(this.OnLevelMaxSequenceFinishedCallback));
			Singleton<EventSystem>.Instance.Add(EEventName.OnAntiqueShopUpgradeSequenceFinished, new Action(this.OnLevelUpSequenceFinishedCallback));
			ModelBase<MingSuModel>.Instance.CurrentInteractCreatureDataLongId = ModelBase<InteractionModel>.Instance.InteractCreatureDataLongId;
			this.OnBegined();
		}

		// Token: 0x06038D5D RID: 232797 RVA: 0x00E65B08 File Offset: 0x00E63D08
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAntiqueShopUpgradeSequencePlayFail, new Action(this.OnSubmitItemLevelUpSequencePlayFailCallback));
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdateDragonPoolView, new Action(this.OnUpdateDragonPoolViewCallback));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAntiqueShopLevelMaxSequenceFinished, new Action(this.OnLevelMaxSequenceFinishedCallback));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAntiqueShopUpgradeSequenceFinished, new Action(this.OnLevelUpSequenceFinishedCallback));
			this.OnEnded();
		}

		// Token: 0x06038D5E RID: 232798 RVA: 0x00E65BA4 File Offset: 0x00E63DA4
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnSubmitItemLevelUp, new Action(this.OnSubmitItemLevelUpCallback));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSubmitItemLevelMax, new Action(this.OnSubmitItemLevelMaxCallback));
			Singleton<EventSystem>.Instance.Add(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x06038D5F RID: 232799 RVA: 0x00E65C08 File Offset: 0x00E63E08
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSubmitItemLevelUp, new Action(this.OnSubmitItemLevelUpCallback));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSubmitItemLevelMax, new Action(this.OnSubmitItemLevelMaxCallback));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x06038D60 RID: 232800 RVA: 0x00E65C69 File Offset: 0x00E63E69
		private void OnUpdateDragonPoolViewCallback()
		{
			this.OnUpdateDragonPoolView();
		}

		// Token: 0x06038D61 RID: 232801 RVA: 0x00E65C71 File Offset: 0x00E63E71
		private void OnSubmitItemLevelUpCallback()
		{
			this.OnSubmitItemLevelUp();
		}

		// Token: 0x06038D62 RID: 232802 RVA: 0x00E65C79 File Offset: 0x00E63E79
		private void OnSubmitItemLevelMaxCallback()
		{
			this.OnSubmitItemLevelUp();
		}

		// Token: 0x06038D63 RID: 232803 RVA: 0x00E65C81 File Offset: 0x00E63E81
		private void OnLevelMaxSequenceFinishedCallback()
		{
			this.OnLevelMaxSequenceFinished();
		}

		// Token: 0x06038D64 RID: 232804 RVA: 0x00E65C89 File Offset: 0x00E63E89
		private void OnLevelUpSequenceFinishedCallback()
		{
			this.OnLevelUpSequenceFinished();
		}

		// Token: 0x06038D65 RID: 232805 RVA: 0x00E65C91 File Offset: 0x00E63E91
		private void OnSubmitItemLevelUpSequencePlayFailCallback()
		{
			this.OnSubmitItemLevelUpSequencePlayFail();
		}

		// Token: 0x06038D66 RID: 232806 RVA: 0x00E65C99 File Offset: 0x00E63E99
		private void OnCommonItemCountAnyChange(int configId, int count)
		{
			if (configId != this.CollectItemConfigId)
			{
				return;
			}
			this.OnCollectItemCountChanged(count);
		}

		// Token: 0x06038D67 RID: 232807 RVA: 0x00E65CAC File Offset: 0x00E63EAC
		private void OnCloseView(EUiViewName viewName, int id)
		{
			if (viewName != EUiViewName.CompositeRewardView)
			{
				return;
			}
			this.OnCloseRewardView();
		}

		// Token: 0x06038D68 RID: 232808 RVA: 0x00E65CC2 File Offset: 0x00E63EC2
		protected virtual void OnBegined()
		{
		}

		// Token: 0x06038D69 RID: 232809 RVA: 0x00E65CC4 File Offset: 0x00E63EC4
		protected virtual void OnEnded()
		{
		}

		// Token: 0x06038D6A RID: 232810 RVA: 0x00E65CC6 File Offset: 0x00E63EC6
		protected virtual void OnUpdateDragonPoolView()
		{
		}

		// Token: 0x06038D6B RID: 232811 RVA: 0x00E65CC8 File Offset: 0x00E63EC8
		protected virtual void OnSubmitItemLevelUp()
		{
		}

		// Token: 0x06038D6C RID: 232812 RVA: 0x00E65CCA File Offset: 0x00E63ECA
		protected virtual void OnSubmitItemLevelMax()
		{
		}

		// Token: 0x06038D6D RID: 232813 RVA: 0x00E65CCC File Offset: 0x00E63ECC
		protected virtual void OnLevelMaxSequenceFinished()
		{
		}

		// Token: 0x06038D6E RID: 232814 RVA: 0x00E65CCE File Offset: 0x00E63ECE
		protected virtual void OnLevelUpSequenceFinished()
		{
		}

		// Token: 0x06038D6F RID: 232815 RVA: 0x00E65CD0 File Offset: 0x00E63ED0
		protected virtual void OnSubmitItemLevelUpSequencePlayFail()
		{
		}

		// Token: 0x06038D70 RID: 232816 RVA: 0x00E65CD2 File Offset: 0x00E63ED2
		protected virtual void OnCloseRewardView()
		{
		}

		// Token: 0x06038D71 RID: 232817 RVA: 0x00E65CD4 File Offset: 0x00E63ED4
		protected virtual void OnCollectItemCountChanged(int count)
		{
		}

		// Token: 0x040205F3 RID: 132595
		protected int PoolConfigId;

		// Token: 0x040205F4 RID: 132596
		protected int CollectItemConfigId;

		// Token: 0x040205F5 RID: 132597
		protected int CurrentShowLevel;
	}
}
