using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F9A RID: 24474
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleChildViewPanel : UiPanelBase
	{
		// Token: 0x0603D727 RID: 251687 RVA: 0x00FA30AD File Offset: 0x00FA12AD
		public virtual UniTask InitializeAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603D728 RID: 251688 RVA: 0x00FA30B4 File Offset: 0x00FA12B4
		public virtual void InitializeTemp()
		{
		}

		// Token: 0x0603D729 RID: 251689 RVA: 0x00FA30B8 File Offset: 0x00FA12B8
		protected override UniTask OnBeforeStartAsync()
		{
			BattleChildViewPanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleChildViewPanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D72A RID: 251690 RVA: 0x00FA30FB File Offset: 0x00FA12FB
		public void ShowBattleChildViewPanel()
		{
			if (!this.CheckBattleChildViewPanelShowCondition())
			{
				return;
			}
			this.IsEnable = true;
			this.SetVisibleInner(EBattleUiVisibleReason.Default, true);
			this.SetActive(this.Visible);
			if (this.Visible)
			{
				this.CheckFirstShow();
			}
		}

		// Token: 0x0603D72B RID: 251691 RVA: 0x00FA312F File Offset: 0x00FA132F
		public void HideBattleChildViewPanel()
		{
			this.IsEnable = false;
			bool visible = this.Visible;
			this.SetVisibleInner(EBattleUiVisibleReason.Default, false);
			this.SetActive(this.Visible);
			if (visible)
			{
				this.OnHideBattleChildViewPanel();
			}
		}

		// Token: 0x0603D72C RID: 251692 RVA: 0x00FA315C File Offset: 0x00FA135C
		public virtual void Reset()
		{
			this.SetVisibleInner(EBattleUiVisibleReason.Default, false);
			this.ResetAllStaticChildView();
			this.RemoveEvents();
			this.ClearAllTagSignificantChangedCallback();
			if (this.ChildViewData != null)
			{
				this.ChildViewData.RemoveCallback(this.ChildType, new Action(this.OnBattleUiChildVisibleChanged));
				this.ChildViewData = null;
			}
		}

		// Token: 0x0603D72D RID: 251693 RVA: 0x00FA31B0 File Offset: 0x00FA13B0
		public override void SetActive(bool visibility)
		{
			if (this.Visible != visibility)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "战斗子界面不要直接调用SetActive, 请调用SetVisible", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			base.SetActive(visibility);
		}

		// Token: 0x0603D72E RID: 251694 RVA: 0x00FA31EA File Offset: 0x00FA13EA
		public bool GetVisible()
		{
			return this.Visible;
		}

		// Token: 0x0603D72F RID: 251695 RVA: 0x00FA31F4 File Offset: 0x00FA13F4
		protected void SetVisible(EBattleUiVisibleReason visibleReason, bool bVisible)
		{
			bool visible = this.Visible;
			this.SetVisibleInner(visibleReason, bVisible);
			this.CheckVisibleChange(visible);
		}

		// Token: 0x0603D730 RID: 251696 RVA: 0x00FA3218 File Offset: 0x00FA1418
		private void OnBattleUiChildVisibleChanged()
		{
			bool visible = this.Visible;
			this.Visible = this.ChildViewData.GetChildVisible(this.ChildType);
			this.CheckVisibleChange(visible);
		}

		// Token: 0x0603D731 RID: 251697 RVA: 0x00FA324C File Offset: 0x00FA144C
		private void CheckVisibleChange(bool oldVisible)
		{
			if (!this.IsEnable)
			{
				return;
			}
			bool visible = this.GetVisible();
			if (oldVisible == visible)
			{
				return;
			}
			this.SetActive(visible);
			if (visible)
			{
				this.CheckFirstShow();
				return;
			}
			this.OnHideBattleChildViewPanel();
		}

		// Token: 0x0603D732 RID: 251698 RVA: 0x00FA3285 File Offset: 0x00FA1485
		private void SetVisibleInner(EBattleUiVisibleReason visibleReason, bool bVisible)
		{
			if (this.ChildType == EBattleUiChild.Common)
			{
				return;
			}
			this.Visible = this.ChildViewData.SetChildVisible(visibleReason, this.ChildType, bVisible, false, 0);
		}

		// Token: 0x0603D733 RID: 251699 RVA: 0x00FA32AB File Offset: 0x00FA14AB
		private void CheckFirstShow()
		{
			if (this.IsShowOnce)
			{
				this.OnShowBattleChildViewPanel(false);
				return;
			}
			this.IsShowOnce = true;
			this.OnShowBattleChildViewPanel(true);
		}

		// Token: 0x0603D734 RID: 251700 RVA: 0x00FA32CB File Offset: 0x00FA14CB
		protected virtual void OnShowBattleChildViewPanel(bool isFirst)
		{
		}

		// Token: 0x0603D735 RID: 251701 RVA: 0x00FA32CD File Offset: 0x00FA14CD
		protected virtual void OnHideBattleChildViewPanel()
		{
		}

		// Token: 0x0603D736 RID: 251702 RVA: 0x00FA32CF File Offset: 0x00FA14CF
		public virtual void OnTickBattleChildViewPanel(float delta)
		{
		}

		// Token: 0x0603D737 RID: 251703 RVA: 0x00FA32D1 File Offset: 0x00FA14D1
		public virtual void OnAfterTickBattleChildViewPanel(float delta)
		{
		}

		// Token: 0x0603D738 RID: 251704 RVA: 0x00FA32D3 File Offset: 0x00FA14D3
		protected virtual void AddEvents()
		{
		}

		// Token: 0x0603D739 RID: 251705 RVA: 0x00FA32D5 File Offset: 0x00FA14D5
		protected virtual void RemoveEvents()
		{
		}

		// Token: 0x0603D73A RID: 251706 RVA: 0x00FA32D8 File Offset: 0x00FA14D8
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		protected UniTask<T> NewStaticChildViewAsync<[Nullable(0)] T>(AActor rootActor, [Nullable(2)] object param = null) where T : BattleChildView, new()
		{
			BattleChildViewPanel.<NewStaticChildViewAsync>d__26<T> <NewStaticChildViewAsync>d__;
			<NewStaticChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
			<NewStaticChildViewAsync>d__.<>4__this = this;
			<NewStaticChildViewAsync>d__.rootActor = rootActor;
			<NewStaticChildViewAsync>d__.param = param;
			<NewStaticChildViewAsync>d__.<>1__state = -1;
			<NewStaticChildViewAsync>d__.<>t__builder.Start<BattleChildViewPanel.<NewStaticChildViewAsync>d__26<T>>(ref <NewStaticChildViewAsync>d__);
			return <NewStaticChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D73B RID: 251707 RVA: 0x00FA332C File Offset: 0x00FA152C
		private void ResetAllStaticChildView()
		{
			foreach (BattleChildView battleChildView in this.StaticChildViewList)
			{
				if (battleChildView != null)
				{
					battleChildView.Destroy(null);
				}
			}
			this.StaticChildViewList.Clear();
		}

		// Token: 0x0603D73C RID: 251708 RVA: 0x00FA3390 File Offset: 0x00FA1590
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected UniTask<T> NewDynamicChildViewByResourceId<[Nullable(0)] T>(UUIItem parentItem, string resourceId, bool bFromPool = false, [Nullable(2)] object param = null) where T : BattleChildView, new()
		{
			BattleChildViewPanel.<NewDynamicChildViewByResourceId>d__28<T> <NewDynamicChildViewByResourceId>d__;
			<NewDynamicChildViewByResourceId>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
			<NewDynamicChildViewByResourceId>d__.parentItem = parentItem;
			<NewDynamicChildViewByResourceId>d__.resourceId = resourceId;
			<NewDynamicChildViewByResourceId>d__.bFromPool = bFromPool;
			<NewDynamicChildViewByResourceId>d__.param = param;
			<NewDynamicChildViewByResourceId>d__.<>1__state = -1;
			<NewDynamicChildViewByResourceId>d__.<>t__builder.Start<BattleChildViewPanel.<NewDynamicChildViewByResourceId>d__28<T>>(ref <NewDynamicChildViewByResourceId>d__);
			return <NewDynamicChildViewByResourceId>d__.<>t__builder.Task;
		}

		// Token: 0x0603D73D RID: 251709 RVA: 0x00FA33EC File Offset: 0x00FA15EC
		protected unsafe T NewDynamicChildViewByResourceIdWithCallback<[Nullable(0)] T>(UUIItem parentItem, string resourceId, bool bFromPool = false, [Nullable(new byte[]
		{
			2,
			1
		})] Action<T> onLoadCompleted = null, [Nullable(2)] object param = null) where T : BattleChildView, new()
		{
			T battleChildView = Activator.CreateInstance<T>();
			try
			{
				battleChildView.NewByResourceId(parentItem, resourceId, bFromPool, param).ContinueWith(delegate()
				{
					Action<T> onLoadCompleted2 = onLoadCompleted;
					if (onLoadCompleted2 == null)
					{
						return;
					}
					onLoadCompleted2(battleChildView);
				}).Forget();
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCommon;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "战斗界面子界面创建失败";
				Exception error = ex;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("资源名", resourceId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("错误", ex.Message);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return battleChildView;
		}

		// Token: 0x0603D73E RID: 251710 RVA: 0x00FA34B4 File Offset: 0x00FA16B4
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		protected UniTask<T> NewDynamicChildViewAsync<[Nullable(0)] T>(AActor rootActor, [Nullable(2)] object param = null) where T : BattleChildView, new()
		{
			BattleChildViewPanel.<NewDynamicChildViewAsync>d__30<T> <NewDynamicChildViewAsync>d__;
			<NewDynamicChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
			<NewDynamicChildViewAsync>d__.rootActor = rootActor;
			<NewDynamicChildViewAsync>d__.param = param;
			<NewDynamicChildViewAsync>d__.<>1__state = -1;
			<NewDynamicChildViewAsync>d__.<>t__builder.Start<BattleChildViewPanel.<NewDynamicChildViewAsync>d__30<T>>(ref <NewDynamicChildViewAsync>d__);
			return <NewDynamicChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D73F RID: 251711 RVA: 0x00FA34FF File Offset: 0x00FA16FF
		protected EOperationType GetOperationType()
		{
			return Singleton<Info>.Instance.OperationType;
		}

		// Token: 0x0603D740 RID: 251712 RVA: 0x00FA350C File Offset: 0x00FA170C
		protected void ListenForTagSignificantChanged(EntityHandle handle, int gameplayTag, BaseTagComponent.TTagSwitchedCallback callback)
		{
			BaseTagComponent component = handle.Entity.GetComponent<BaseTagComponent>();
			if (component == null)
			{
				return;
			}
			ITagTask item = component.ListenForTagAddOrRemove(new int?(gameplayTag), callback, null);
			this.TagSignificantChangedTaskList.Add(item);
		}

		// Token: 0x0603D741 RID: 251713 RVA: 0x00FA3544 File Offset: 0x00FA1744
		protected void ClearAllTagSignificantChangedCallback()
		{
			foreach (ITagTask tagTask in this.TagSignificantChangedTaskList)
			{
				tagTask.EndTask();
			}
			this.TagSignificantChangedTaskList.Clear();
		}

		// Token: 0x0603D742 RID: 251714 RVA: 0x00FA35A0 File Offset: 0x00FA17A0
		protected bool ContainsTag(EntityHandle handle, int gameplayTag)
		{
			BaseTagComponent component = handle.Entity.GetComponent<BaseTagComponent>();
			return component != null && component.HasTag(gameplayTag);
		}

		// Token: 0x0603D743 RID: 251715 RVA: 0x00FA35C5 File Offset: 0x00FA17C5
		[NullableContext(2)]
		public new UUIItem GetItem(int index)
		{
			return base.GetItem(index);
		}

		// Token: 0x0603D744 RID: 251716 RVA: 0x00FA35CE File Offset: 0x00FA17CE
		[NullableContext(2)]
		public virtual AActor GetUiActorForGuide()
		{
			return null;
		}

		// Token: 0x0603D745 RID: 251717 RVA: 0x00FA35D1 File Offset: 0x00FA17D1
		public virtual void OnSeamlessTravelFinish()
		{
		}

		// Token: 0x0603D746 RID: 251718 RVA: 0x00FA35D3 File Offset: 0x00FA17D3
		public void RefreshPureMode(bool isOpen)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAlpha(!isOpen);
		}

		// Token: 0x0603D747 RID: 251719 RVA: 0x00FA35EA File Offset: 0x00FA17EA
		public bool IsChildType(EBattleUiChild childType)
		{
			return this.ChildType == childType;
		}

		// Token: 0x0603D748 RID: 251720 RVA: 0x00FA35F5 File Offset: 0x00FA17F5
		public bool CheckBattleChildViewPanelShowCondition()
		{
			return this.OnCheckBattleChildViewPanelShowCondition();
		}

		// Token: 0x0603D749 RID: 251721 RVA: 0x00FA35FD File Offset: 0x00FA17FD
		protected virtual bool OnCheckBattleChildViewPanelShowCondition()
		{
			return true;
		}

		// Token: 0x0603D74A RID: 251722 RVA: 0x00FA3600 File Offset: 0x00FA1800
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.HYF, "主界面子面板聚焦引导获取方法未实现", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}

		// Token: 0x04022887 RID: 141447
		private readonly List<BattleChildView> StaticChildViewList = new List<BattleChildView>();

		// Token: 0x04022888 RID: 141448
		private readonly List<ITagTask> TagSignificantChangedTaskList = new List<ITagTask>();

		// Token: 0x04022889 RID: 141449
		[Nullable(2)]
		protected BattleUiChildViewData ChildViewData;

		// Token: 0x0402288A RID: 141450
		protected EBattleUiChild ChildType;

		// Token: 0x0402288B RID: 141451
		protected bool Visible;

		// Token: 0x0402288C RID: 141452
		protected bool IsEnable;

		// Token: 0x0402288D RID: 141453
		protected bool IsShowOnce;
	}
}
