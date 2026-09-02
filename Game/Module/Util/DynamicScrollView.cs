using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C71 RID: 19569
	[NullableContext(1)]
	[Nullable(0)]
	public class DynamicScrollView<T, TBase, [Nullable(2)] TData> : IGridPreserver where T : class, IDynamicScrollItem<TData> where TBase : class, IDynamicScrollBaseItem<TData>
	{
		// Token: 0x06032FA8 RID: 208808 RVA: 0x00CC4EA4 File Offset: 0x00CC30A4
		public DynamicScrollView(UUIDynScrollViewComponent scrollView, UUIItem templateActor, TBase templateContent, TDynamicScrollViewCreate<T, TData> createFunction)
		{
			this.CreateFunction = createFunction;
			this.TemplateContent = templateContent;
			templateActor.SetUIParent(scrollView.RootUIComp, false);
			this.InitedActorMap.Clear();
			this.TemplateActor = templateActor;
			this.DynamicScroll = scrollView;
			this.DynamicScroll.OnItemUpdate.Bind(new Func<int, AUIBaseActor, AUIBaseActor>(this.OnItemUpdate));
			this.DynamicScroll.OnItemClear.Bind(new Action<int, AUIBaseActor>(this.OnItemClear));
			this.DynamicScroll.ItemSizeDelegate.Bind(new Func<int, FVector2D>(this.GetItemSize));
			this.DynamicScroll.OnDestroyCallBack.Bind(new Action(this.OnItemDestroy));
			this.GridsController = new InTurnGridAppearAnimation(this);
			this.GridsController.RegisterAnimController();
		}

		// Token: 0x06032FA9 RID: 208809 RVA: 0x00CC4FB0 File Offset: 0x00CC31B0
		public UniTask Init()
		{
			DynamicScrollView<T, TBase, TData>.<Init>d__14 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<DynamicScrollView<T, TBase, TData>.<Init>d__14>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06032FAA RID: 208810 RVA: 0x00CC4FF3 File Offset: 0x00CC31F3
		public int GetDisplayGridNum()
		{
			return this.DynamicScroll.DisplayItemArray.Num();
		}

		// Token: 0x06032FAB RID: 208811 RVA: 0x00CC5005 File Offset: 0x00CC3205
		public int GetPreservedGridNum()
		{
			return this.DynamicScroll.DisplayItemArray.Num() + this.DynamicScroll.IdleItemArray.Num();
		}

		// Token: 0x06032FAC RID: 208812 RVA: 0x00CC5028 File Offset: 0x00CC3228
		public int GetDisplayGridStartIndex()
		{
			int result = 0;
			this.DynamicScroll.GetItemIndex(0, ref result);
			return result;
		}

		// Token: 0x06032FAD RID: 208813 RVA: 0x00CC5048 File Offset: 0x00CC3248
		public int GetDisplayGridEndIndex()
		{
			int num = this.DynamicScroll.DisplayItemArray.Num() - 1;
			if (num < 0)
			{
				return 0;
			}
			int result = 0;
			this.DynamicScroll.GetItemIndex(num, ref result);
			return result;
		}

		// Token: 0x06032FAE RID: 208814 RVA: 0x00CC5080 File Offset: 0x00CC3280
		[NullableContext(2)]
		public UUIItem GetGrid(int gridIndex)
		{
			AUIBaseActor item = this.DynamicScroll.GetItem(gridIndex);
			if (item == null)
			{
				return null;
			}
			return item.GetUIItem();
		}

		// Token: 0x06032FAF RID: 208815 RVA: 0x00CC509C File Offset: 0x00CC329C
		public void LateScrollTo(int index)
		{
			this.BindLateUpdate(delegate(float delta)
			{
				this.ScrollToItemIndex(index, true, false).Forget();
				this.UnBindLateUpdate();
			});
		}

		// Token: 0x06032FB0 RID: 208816 RVA: 0x00CC50D0 File Offset: 0x00CC32D0
		[NullableContext(2)]
		public UUIItem GetGridByDisplayIndex(int gridIndex)
		{
			int index = 0;
			this.DynamicScroll.GetItemDisplayIndex(gridIndex, ref index);
			return this.DynamicScroll.DisplayItemArray.Get(index).Get().GetUIItem();
		}

		// Token: 0x06032FB1 RID: 208817 RVA: 0x00CC510C File Offset: 0x00CC330C
		public float GetGridAnimationInterval()
		{
			return this.DynamicScroll.GetGridAnimationInterval();
		}

		// Token: 0x06032FB2 RID: 208818 RVA: 0x00CC5119 File Offset: 0x00CC3319
		public float GetGridAnimationStartTime()
		{
			return this.DynamicScroll.GetGridAnimationStartTime();
		}

		// Token: 0x06032FB3 RID: 208819 RVA: 0x00CC5126 File Offset: 0x00CC3326
		public void NotifyAnimationStart()
		{
			this.DynamicScroll.SetInAnimation(true);
		}

		// Token: 0x06032FB4 RID: 208820 RVA: 0x00CC5134 File Offset: 0x00CC3334
		public void NotifyAnimationEnd()
		{
			this.DynamicScroll.SetInAnimation(false);
		}

		// Token: 0x06032FB5 RID: 208821 RVA: 0x00CC5144 File Offset: 0x00CC3344
		public void RefreshByData(IReadOnlyList<TData> data, bool keepContentPosition = false, bool skipGridAnim = false)
		{
			this.DataArray = data;
			this.ScrollItemMap.Clear();
			this.ScrollItemClearActionsMap.Clear();
			AUIBaseActor item = this.TemplateActor.GetOwner() as AUIBaseActor;
			this.TemplateActor.SetUIActive(true);
			this._tempActorCache.Clear();
			this.Refreshing = true;
			this.DynamicScroll.RefreshByData(item, data.Count, keepContentPosition);
			this.Refreshing = false;
			this.TemplateActor.SetUIActive(false);
			this.DynamicScroll.SetInAnimation(true);
			if (!skipGridAnim)
			{
				this.PlayGridAnimate();
			}
		}

		// Token: 0x06032FB6 RID: 208822 RVA: 0x00CC51D8 File Offset: 0x00CC33D8
		public bool CheckIfAllRefreshFinished()
		{
			UUIDynScrollViewComponent dynamicScroll = this.DynamicScroll;
			TMap<int, EScrollItemState> tmap = (dynamicScroll != null) ? dynamicScroll.ItemStateMap : null;
			if (tmap == null)
			{
				return true;
			}
			foreach (KeyValuePair<int, EScrollItemState> keyValuePair in tmap)
			{
				if (keyValuePair.Value == EScrollItemState.Updating)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06032FB7 RID: 208823 RVA: 0x00CC5244 File Offset: 0x00CC3444
		private void CheckUnBindDynScollLateUpdate()
		{
			if (this.LateUpdateBindState)
			{
				this.DynamicScroll.OnLateUpdate.Unbind();
				this.LateUpdateBindState = false;
			}
		}

		// Token: 0x06032FB8 RID: 208824 RVA: 0x00CC5265 File Offset: 0x00CC3465
		private void CheckBindDynScrollLateUpdateStateAndBind()
		{
			if (!this.LateUpdateBindState)
			{
				this.DynamicScroll.OnLateUpdate.Bind(new Action<float>(this.OnLateUpdate));
				this.LateUpdateBindState = true;
			}
		}

		// Token: 0x06032FB9 RID: 208825 RVA: 0x00CC5294 File Offset: 0x00CC3494
		[NullableContext(2)]
		private AUIBaseActor OnItemUpdate(int index, AUIBaseActor actor)
		{
			TData data = this.DataArray[index];
			T tempItem;
			T tempItem2;
			if (this.InitedActorMap.TryGetValue(actor, out tempItem2))
			{
				tempItem = tempItem2;
				this.WaitForUpdateItem(data, index, actor).Forget();
			}
			else
			{
				tempItem = this.CreateFunction(data, actor.GetUIItem(), index);
				UniTaskCompletionSource uniTaskCompletionSource = new UniTaskCompletionSource();
				tempItem.Init(actor.GetUIItem()).Finally(delegate()
				{
					tempItem.Update(data, index);
					if (this.DynamicScroll != null && this.DynamicScroll.IsValid())
					{
						this.DynamicScroll.SetScrollItemState(index, EScrollItemState.Completed);
					}
					uniTaskCompletionSource.TrySetResult();
				}).Forget();
				this.InitedActorMap[actor] = tempItem;
				this.ActorInitPromise[actor] = uniTaskCompletionSource.Task;
			}
			this.CheckIfNeedSetItemActiveWhenInit(tempItem, index);
			tempItem.SkipDestroyActor = true;
			this.ScrollItemMap[index] = tempItem;
			return tempItem.GetUsingItem(data);
		}

		// Token: 0x06032FBA RID: 208826 RVA: 0x00CC53D4 File Offset: 0x00CC35D4
		private UniTask WaitForUpdateItem(TData data, int index, AUIBaseActor actor)
		{
			DynamicScrollView<T, TBase, TData>.<WaitForUpdateItem>d__33 <WaitForUpdateItem>d__;
			<WaitForUpdateItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitForUpdateItem>d__.<>4__this = this;
			<WaitForUpdateItem>d__.data = data;
			<WaitForUpdateItem>d__.index = index;
			<WaitForUpdateItem>d__.actor = actor;
			<WaitForUpdateItem>d__.<>1__state = -1;
			<WaitForUpdateItem>d__.<>t__builder.Start<DynamicScrollView<T, TBase, TData>.<WaitForUpdateItem>d__33>(ref <WaitForUpdateItem>d__);
			return <WaitForUpdateItem>d__.<>t__builder.Task;
		}

		// Token: 0x06032FBB RID: 208827 RVA: 0x00CC542F File Offset: 0x00CC362F
		private void CheckIfNeedSetItemActiveWhenInit(T item, int index)
		{
			item.SetUiActive(true);
		}

		// Token: 0x06032FBC RID: 208828 RVA: 0x00CC5440 File Offset: 0x00CC3640
		[NullableContext(2)]
		private void OnItemClear(int index, AUIBaseActor actor)
		{
			UUIItem grid = this.GetGrid(index);
			Singleton<EventSystem>.Instance.Emit<UUIItem>(EEventName.OnDynamicScrollViewClearItem, grid);
			this.ScrollItemMap.Remove(index);
			Action action;
			if (this.ScrollItemClearActionsMap.TryGetValue(index, out action))
			{
				action();
				this.ScrollItemClearActionsMap.Remove(index);
			}
		}

		// Token: 0x06032FBD RID: 208829 RVA: 0x00CC5493 File Offset: 0x00CC3693
		private void OnItemDestroy()
		{
			this.CheckUnBindDynScollLateUpdate();
		}

		// Token: 0x06032FBE RID: 208830 RVA: 0x00CC549C File Offset: 0x00CC369C
		private FVector2D GetItemSize(int index)
		{
			TData data = this.DataArray[index];
			return this.TemplateContent.GetItemSize(data);
		}

		// Token: 0x06032FBF RID: 208831 RVA: 0x00CC54C7 File Offset: 0x00CC36C7
		public FVector2D GetItemSizeFromData(TData data)
		{
			return this.TemplateContent.GetItemSize(data);
		}

		// Token: 0x06032FC0 RID: 208832 RVA: 0x00CC54DC File Offset: 0x00CC36DC
		[NullableContext(2)]
		public T GetScrollItemFromIndex(int index)
		{
			T result;
			this.ScrollItemMap.TryGetValue(index, out result);
			return result;
		}

		// Token: 0x06032FC1 RID: 208833 RVA: 0x00CC54F9 File Offset: 0x00CC36F9
		public int GetScrollItemCount()
		{
			return this.ScrollItemMap.Count;
		}

		// Token: 0x06032FC2 RID: 208834 RVA: 0x00CC5506 File Offset: 0x00CC3706
		public T[] GetScrollItemItems()
		{
			return this.ScrollItemMap.Values.ToArray<T>();
		}

		// Token: 0x06032FC3 RID: 208835 RVA: 0x00CC5518 File Offset: 0x00CC3718
		private void OnLateUpdate(float deltaTime)
		{
			Action<float> lateUpdateCallBack = this.LateUpdateCallBack;
			if (lateUpdateCallBack != null)
			{
				lateUpdateCallBack(deltaTime);
			}
			Action<float> reloadLateUpdateCallBack = this.ReloadLateUpdateCallBack;
			if (reloadLateUpdateCallBack != null)
			{
				reloadLateUpdateCallBack(deltaTime);
			}
			this.CheckAndUnbindLateUpdate();
		}

		// Token: 0x06032FC4 RID: 208836 RVA: 0x00CC5544 File Offset: 0x00CC3744
		private void PlayGridAnimate()
		{
			if (this.GridsController != null)
			{
				this.GridsController.PlayGridAnim(this.DynamicScroll.DisplayItemArray.Num(), true);
			}
		}

		// Token: 0x06032FC5 RID: 208837 RVA: 0x00CC556A File Offset: 0x00CC376A
		private void CheckAndUnbindLateUpdate()
		{
			if (this.LateUpdateCallBack == null && this.ReloadLateUpdateCallBack == null)
			{
				this.CheckUnBindDynScollLateUpdate();
			}
		}

		// Token: 0x06032FC6 RID: 208838 RVA: 0x00CC5582 File Offset: 0x00CC3782
		private void BindReloadLateUpdate(Action<float> callback)
		{
			this.ReloadLateUpdateCallBack = callback;
			this.CheckBindDynScrollLateUpdateStateAndBind();
		}

		// Token: 0x06032FC7 RID: 208839 RVA: 0x00CC5591 File Offset: 0x00CC3791
		public void UnBindReloadLateUpdate()
		{
			this.ReloadLateUpdateCallBack = null;
		}

		// Token: 0x06032FC8 RID: 208840 RVA: 0x00CC559A File Offset: 0x00CC379A
		public void BindLateUpdate(Action<float> callback)
		{
			this.LateUpdateCallBack = callback;
			this.CheckBindDynScrollLateUpdateStateAndBind();
		}

		// Token: 0x06032FC9 RID: 208841 RVA: 0x00CC55A9 File Offset: 0x00CC37A9
		public void UnBindLateUpdate()
		{
			this.LateUpdateCallBack = null;
		}

		// Token: 0x06032FCA RID: 208842 RVA: 0x00CC55B2 File Offset: 0x00CC37B2
		public void AddListenerOnItemClear(int index, Action action)
		{
			if (this.ScrollItemClearActionsMap.ContainsKey(index))
			{
				this.ScrollItemClearActionsMap[index] = action;
				return;
			}
			this.ScrollItemClearActionsMap.Add(index, action);
		}

		// Token: 0x06032FCB RID: 208843 RVA: 0x00CC55E0 File Offset: 0x00CC37E0
		public void ClearChildren()
		{
			this.ScrollItemMap.Clear();
			this.ScrollItemClearActionsMap.Clear();
			this.CheckUnBindDynScollLateUpdate();
			this.DynamicScroll.OnItemUpdate.Unbind();
			this.DynamicScroll.OnItemClear.Unbind();
			this.DynamicScroll.ItemSizeDelegate.Unbind();
			this.DynamicScroll.OnDestroyCallBack.Unbind();
			GridAppearAnimationBase gridsController = this.GridsController;
			if (gridsController == null)
			{
				return;
			}
			gridsController.Clear();
		}

		// Token: 0x06032FCC RID: 208844 RVA: 0x00CC565C File Offset: 0x00CC385C
		public UniTask ScrollToItemIndex(int index, bool playGridAnim = true, bool resetAlpha = false)
		{
			DynamicScrollView<T, TBase, TData>.<ScrollToItemIndex>d__51 <ScrollToItemIndex>d__;
			<ScrollToItemIndex>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ScrollToItemIndex>d__.<>4__this = this;
			<ScrollToItemIndex>d__.index = index;
			<ScrollToItemIndex>d__.playGridAnim = playGridAnim;
			<ScrollToItemIndex>d__.resetAlpha = resetAlpha;
			<ScrollToItemIndex>d__.<>1__state = -1;
			<ScrollToItemIndex>d__.<>t__builder.Start<DynamicScrollView<T, TBase, TData>.<ScrollToItemIndex>d__51>(ref <ScrollToItemIndex>d__);
			return <ScrollToItemIndex>d__.<>t__builder.Task;
		}

		// Token: 0x06032FCD RID: 208845 RVA: 0x00CC56B8 File Offset: 0x00CC38B8
		public void ScrollToItemIndexByOffset(int index)
		{
			float num = this.DynamicScroll.PaddingVertical;
			int num2 = 0;
			int i = 0;
			while (i < index)
			{
				AUIBaseActor item = this.DynamicScroll.GetItem(i);
				float? num3;
				if (item == null)
				{
					num3 = null;
				}
				else
				{
					UUIItem uiitem = item.GetUIItem();
					num3 = ((uiitem != null) ? new float?(uiitem.GetHeight()) : null);
				}
				float? num4 = num3;
				if (num4 == null)
				{
					goto IL_95;
				}
				float? num5 = num4;
				float num6 = 0f;
				if (!(num5.GetValueOrDefault() > num6 & num5 != null))
				{
					goto IL_95;
				}
				num += num4.Value + this.DynamicScroll.SpacingVertical;
				IL_D2:
				i++;
				continue;
				IL_95:
				TData data = this.DataArray[i];
				FVector2D itemSize = this.TemplateContent.GetItemSize(data);
				num += itemSize.Y + this.DynamicScroll.SpacingVertical;
				num2++;
				goto IL_D2;
			}
			UUIItem uuiitem = this.DynamicScroll.ContentUIItem.Get();
			float num7 = (uuiitem != null) ? uuiitem.GetHeight() : 0f;
			UUIItem uuiitem2 = this.DynamicScroll.ContentParentUIItem.Get();
			float num8 = (uuiitem2 != null) ? uuiitem2.GetHeight() : 0f;
			float num9 = num7 - num8;
			if (num9 > 0f)
			{
				this.DynamicScroll.SetScrollProgress(Math.Min(num / num9, 1f));
			}
		}

		// Token: 0x06032FCE RID: 208846 RVA: 0x00CC5818 File Offset: 0x00CC3A18
		public UniTask WaitForInit()
		{
			DynamicScrollView<T, TBase, TData>.<WaitForInit>d__53 <WaitForInit>d__;
			<WaitForInit>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitForInit>d__.<>4__this = this;
			<WaitForInit>d__.<>1__state = -1;
			<WaitForInit>d__.<>t__builder.Start<DynamicScrollView<T, TBase, TData>.<WaitForInit>d__53>(ref <WaitForInit>d__);
			return <WaitForInit>d__.<>t__builder.Task;
		}

		// Token: 0x06032FCF RID: 208847 RVA: 0x00CC585C File Offset: 0x00CC3A5C
		public void ScrollToBottom(UUIItem uiItem)
		{
			FVector relativeLocation = this.DynamicScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.DynamicScroll.ScrollToBottom(ref fvector2D, uiItem, false);
		}

		// Token: 0x06032FD0 RID: 208848 RVA: 0x00CC58A4 File Offset: 0x00CC3AA4
		private UniTask WaitInitThenScrollToIndex(int index, bool playGridAnim = true, bool resetAlpha = false)
		{
			DynamicScrollView<T, TBase, TData>.<WaitInitThenScrollToIndex>d__55 <WaitInitThenScrollToIndex>d__;
			<WaitInitThenScrollToIndex>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitInitThenScrollToIndex>d__.<>4__this = this;
			<WaitInitThenScrollToIndex>d__.index = index;
			<WaitInitThenScrollToIndex>d__.playGridAnim = playGridAnim;
			<WaitInitThenScrollToIndex>d__.resetAlpha = resetAlpha;
			<WaitInitThenScrollToIndex>d__.<>1__state = -1;
			<WaitInitThenScrollToIndex>d__.<>t__builder.Start<DynamicScrollView<T, TBase, TData>.<WaitInitThenScrollToIndex>d__55>(ref <WaitInitThenScrollToIndex>d__);
			return <WaitInitThenScrollToIndex>d__.<>t__builder.Task;
		}

		// Token: 0x06032FD1 RID: 208849 RVA: 0x00CC58FF File Offset: 0x00CC3AFF
		public void ResetGridController()
		{
			if (this.GridsController != null)
			{
				this.GridsController.PlayGridAnim(this.GetDisplayGridNum(), true);
			}
		}

		// Token: 0x06032FD2 RID: 208850 RVA: 0x00CC591B File Offset: 0x00CC3B1B
		[NullableContext(2)]
		public UUIInturnAnimController GetUiAnimController()
		{
			UUIDynScrollViewComponent dynamicScroll = this.DynamicScroll;
			AUIBaseActor auibaseActor = (dynamicScroll != null) ? dynamicScroll.GetContent() : null;
			return ((auibaseActor != null) ? auibaseActor.GetComponentByClass(UUIInturnAnimController.StaticClass()) : null) as UUIInturnAnimController;
		}

		// Token: 0x0401DA90 RID: 121488
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private readonly TDynamicScrollViewCreate<T, TData> CreateFunction;

		// Token: 0x0401DA91 RID: 121489
		[Nullable(2)]
		private readonly UUIDynScrollViewComponent DynamicScroll;

		// Token: 0x0401DA92 RID: 121490
		[Nullable(2)]
		private readonly TBase TemplateContent;

		// Token: 0x0401DA93 RID: 121491
		private readonly Dictionary<int, T> ScrollItemMap = new Dictionary<int, T>();

		// Token: 0x0401DA94 RID: 121492
		private readonly Dictionary<int, Action> ScrollItemClearActionsMap = new Dictionary<int, Action>();

		// Token: 0x0401DA95 RID: 121493
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private IReadOnlyList<TData> DataArray;

		// Token: 0x0401DA96 RID: 121494
		[Nullable(2)]
		private readonly UUIItem TemplateActor;

		// Token: 0x0401DA97 RID: 121495
		[Nullable(2)]
		private readonly GridAppearAnimationBase GridsController;

		// Token: 0x0401DA98 RID: 121496
		private readonly Dictionary<AUIBaseActor, T> InitedActorMap = new Dictionary<AUIBaseActor, T>();

		// Token: 0x0401DA99 RID: 121497
		[Nullable(2)]
		public Action<float> LateUpdateCallBack;

		// Token: 0x0401DA9A RID: 121498
		[Nullable(2)]
		private Action<float> ReloadLateUpdateCallBack;

		// Token: 0x0401DA9B RID: 121499
		private readonly Dictionary<AUIBaseActor, UniTask> ActorInitPromise = new Dictionary<AUIBaseActor, UniTask>();

		// Token: 0x0401DA9C RID: 121500
		private bool LateUpdateBindState;

		// Token: 0x0401DA9D RID: 121501
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private Dictionary<int, AUIBaseActor> _tempActorCache = new Dictionary<int, AUIBaseActor>();

		// Token: 0x0401DA9E RID: 121502
		private bool Refreshing;
	}
}
