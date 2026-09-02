using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C63 RID: 19555
	[NullableContext(1)]
	[Nullable(0)]
	public class GenericLayout<TProxy, [Nullable(2)] TData> : IGridPreserver where TProxy : class, IGridProxy<TData>
	{
		// Token: 0x06032F3E RID: 208702 RVA: 0x00CC34AC File Offset: 0x00CC16AC
		public GenericLayout(UUILayoutBase layout, Func<TProxy> gridProxyCreateFunction, [Nullable(2)] AUIBaseActor gridActor = null, bool isRefreshAsync = false, bool isGridShowWhenCreate = true)
		{
			this.IsRefreshAsync = isRefreshAsync;
			this.IsGridShowWhenCreate = isGridShowWhenCreate;
			this.Layout = layout;
			AUIBaseActor auibaseActor = this.Layout.GetOwner() as AUIBaseActor;
			if (auibaseActor != null)
			{
				auibaseActor.OnPreDestroyed.Add(new Action<AActor>(this.OnDestroy));
			}
			if (gridActor == null)
			{
				UUIItem attachUIChild = layout.RootUIComp.Get().GetAttachUIChild(0);
				this.TemplateGridActor = (((attachUIChild != null) ? attachUIChild.GetOwner() : null) as AUIBaseActor);
			}
			else
			{
				this.TemplateGridActor = gridActor;
			}
			if (this.TemplateGridActor == null)
			{
				return;
			}
			this.TemplateGridActor.GetUIItem().SetUIActive(false);
			this.Delegate = new ScrollViewDelegate<TProxy, TData>(gridProxyCreateFunction);
			this.GridsController = new InTurnGridAppearAnimation(this);
			this.GridsController.RegisterAnimController();
		}

		// Token: 0x17008781 RID: 34689
		// (get) Token: 0x06032F3F RID: 208703 RVA: 0x00CC35B5 File Offset: 0x00CC17B5
		public bool IsLock
		{
			get
			{
				return this.Operating;
			}
		}

		// Token: 0x06032F40 RID: 208704 RVA: 0x00CC35BD File Offset: 0x00CC17BD
		private void Lock()
		{
			this.Operating = true;
		}

		// Token: 0x06032F41 RID: 208705 RVA: 0x00CC35C8 File Offset: 0x00CC17C8
		private void Unlock()
		{
			this.Operating = false;
			if (this.OperationQueue.Size > 0)
			{
				GenericLayout<TProxy, TData>.OperationParam operationParam = this.OperationQueue.Pop();
				this.RefreshByData(operationParam.Data, operationParam.CallBack, operationParam.PlayGridAnim);
			}
		}

		// Token: 0x06032F42 RID: 208706 RVA: 0x00CC3610 File Offset: 0x00CC1810
		[NullableContext(2)]
		public UUIItem GetRootUiItem()
		{
			UUILayoutBase layout = this.Layout;
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (layout != null) ? new TWeakObjectPtr<UUIItem>?(layout.RootUIComp) : null;
			if (tweakObjectPtr == null)
			{
				return null;
			}
			return tweakObjectPtr.GetValueOrDefault();
		}

		// Token: 0x06032F43 RID: 208707 RVA: 0x00CC3654 File Offset: 0x00CC1854
		[NullableContext(2)]
		private UUIItem CreateGrid()
		{
			return Singleton<LguiUtil>.Instance.CopyItem(this.TemplateGridActor.GetUIItem(), this.GetRootUiItem());
		}

		// Token: 0x06032F44 RID: 208708 RVA: 0x00CC3674 File Offset: 0x00CC1874
		[NullableContext(2)]
		public object GetKey(int gridIndex)
		{
			if (gridIndex < 0 || gridIndex >= this.ProxyDisplayList.Count)
			{
				return null;
			}
			TProxy tproxy = this.ProxyDisplayList[gridIndex];
			IReadOnlyList<TData> datas = this.Delegate.GetDatas();
			if (gridIndex >= datas.Count)
			{
				return null;
			}
			return tproxy.GetKey(datas[gridIndex], gridIndex);
		}

		// Token: 0x06032F45 RID: 208709 RVA: 0x00CC36CC File Offset: 0x00CC18CC
		public int? GetGridIndexByKey<[Nullable(2)] T>(T key)
		{
			TProxy tproxy;
			if (this.ProxyMap.TryGetValue(key, out tproxy))
			{
				return new int?(tproxy.GridIndex);
			}
			return null;
		}

		// Token: 0x06032F46 RID: 208710 RVA: 0x00CC3708 File Offset: 0x00CC1908
		public void ClearChildren()
		{
			foreach (UUIItem uuiitem in this.GridItemList)
			{
				AActor owner = uuiitem.GetOwner();
				if (owner != null && owner.IsValid())
				{
					ULGUIBPLibrary.DestroyActorWithHierarchy(owner, true);
				}
			}
			this.GridItemList.Clear();
			this.GridDisplayItemList.Clear();
			this.ProxyDisplayList.Clear();
			this.ProxyMap.Clear();
		}

		// Token: 0x06032F47 RID: 208711 RVA: 0x00CC3798 File Offset: 0x00CC1998
		public UniTask LoadGrid(int length, bool bShow = true)
		{
			GenericLayout<TProxy, TData>.<LoadGrid>d__24 <LoadGrid>d__;
			<LoadGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadGrid>d__.<>4__this = this;
			<LoadGrid>d__.length = length;
			<LoadGrid>d__.bShow = bShow;
			<LoadGrid>d__.<>1__state = -1;
			<LoadGrid>d__.<>t__builder.Start<GenericLayout<TProxy, TData>.<LoadGrid>d__24>(ref <LoadGrid>d__);
			return <LoadGrid>d__.<>t__builder.Task;
		}

		// Token: 0x06032F48 RID: 208712 RVA: 0x00CC37EC File Offset: 0x00CC19EC
		[NullableContext(0)]
		public UniTask<bool> RefreshByDataDirectly([Nullable(1)] IReadOnlyList<TData> data)
		{
			GenericLayout<TProxy, TData>.<RefreshByDataDirectly>d__25 <RefreshByDataDirectly>d__;
			<RefreshByDataDirectly>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RefreshByDataDirectly>d__.<>4__this = this;
			<RefreshByDataDirectly>d__.data = data;
			<RefreshByDataDirectly>d__.<>1__state = -1;
			<RefreshByDataDirectly>d__.<>t__builder.Start<GenericLayout<TProxy, TData>.<RefreshByDataDirectly>d__25>(ref <RefreshByDataDirectly>d__);
			return <RefreshByDataDirectly>d__.<>t__builder.Task;
		}

		// Token: 0x06032F49 RID: 208713 RVA: 0x00CC3838 File Offset: 0x00CC1A38
		public bool RefreshByDataDirectlySync(IReadOnlyList<TData> data)
		{
			int count = data.Count;
			if (count > this.GridItemList.Count)
			{
				return false;
			}
			this.Delegate.SetData(data);
			this.Delegate.ClearSelectInfo();
			this.ProxyMap.Clear();
			int count2 = this.GridDisplayItemList.Count;
			if (count > count2)
			{
				for (int i = count2; i < count; i++)
				{
					UUIItem uuiitem = this.GridItemList[i];
					uuiitem.SetUIActive(true);
					this.GridDisplayItemList.Add(uuiitem);
					this.ProxyDisplayList.Add(this.Delegate.GetGridProxy(i));
				}
			}
			for (int j = count; j < this.GridItemList.Count; j++)
			{
				this.GridItemList[j].SetUIActive(false);
			}
			if (this.GridDisplayItemList.Count > count)
			{
				this.GridDisplayItemList.RemoveRange(count, this.GridDisplayItemList.Count - count);
			}
			if (this.ProxyDisplayList.Count > count)
			{
				this.ProxyDisplayList.RemoveRange(count, this.ProxyDisplayList.Count - count);
			}
			this.RefreshDisplayProxyListSync();
			return true;
		}

		// Token: 0x06032F4A RID: 208714 RVA: 0x00CC3954 File Offset: 0x00CC1B54
		public void RefreshByData(IReadOnlyList<TData> data, [Nullable(2)] Action callBack = null, bool playGridAnim = false)
		{
			if (this.IsLock)
			{
				GenericLayout<TProxy, TData>.OperationParam element = new GenericLayout<TProxy, TData>.OperationParam(data, callBack, playGridAnim);
				this.OperationQueue.Push(element);
				return;
			}
			this.Lock();
			this.RefreshByDataAsync(data, playGridAnim, null).ContinueWith(delegate()
			{
				Action callBack2 = callBack;
				if (callBack2 != null)
				{
					callBack2();
				}
				this.Unlock();
			}).Forget();
		}

		// Token: 0x06032F4B RID: 208715 RVA: 0x00CC39C8 File Offset: 0x00CC1BC8
		public UniTask RefreshByDataAsync(IReadOnlyList<TData> data, bool playGridAnim = false, int? length = null)
		{
			GenericLayout<TProxy, TData>.<RefreshByDataAsync>d__28 <RefreshByDataAsync>d__;
			<RefreshByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshByDataAsync>d__.<>4__this = this;
			<RefreshByDataAsync>d__.data = data;
			<RefreshByDataAsync>d__.playGridAnim = playGridAnim;
			<RefreshByDataAsync>d__.length = length;
			<RefreshByDataAsync>d__.<>1__state = -1;
			<RefreshByDataAsync>d__.<>t__builder.Start<GenericLayout<TProxy, TData>.<RefreshByDataAsync>d__28>(ref <RefreshByDataAsync>d__);
			return <RefreshByDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032F4C RID: 208716 RVA: 0x00CC3A23 File Offset: 0x00CC1C23
		public void RefreshWithoutDataSync()
		{
			this.RefreshDisplayProxyListSync();
		}

		// Token: 0x06032F4D RID: 208717 RVA: 0x00CC3A2C File Offset: 0x00CC1C2C
		private void RefreshDisplayProxyListSync()
		{
			if (this.GridDisplayItemList.Count == 0)
			{
				return;
			}
			for (int i = 0; i < this.GridDisplayItemList.Count; i++)
			{
				this.RefreshDisplayProxyInternalSync(i);
			}
		}

		// Token: 0x06032F4E RID: 208718 RVA: 0x00CC3A64 File Offset: 0x00CC1C64
		private UniTask RefreshDisplayProxyListAsync()
		{
			GenericLayout<TProxy, TData>.<RefreshDisplayProxyListAsync>d__31 <RefreshDisplayProxyListAsync>d__;
			<RefreshDisplayProxyListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshDisplayProxyListAsync>d__.<>4__this = this;
			<RefreshDisplayProxyListAsync>d__.<>1__state = -1;
			<RefreshDisplayProxyListAsync>d__.<>t__builder.Start<GenericLayout<TProxy, TData>.<RefreshDisplayProxyListAsync>d__31>(ref <RefreshDisplayProxyListAsync>d__);
			return <RefreshDisplayProxyListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032F4F RID: 208719 RVA: 0x00CC3AA8 File Offset: 0x00CC1CA8
		private void RefreshDisplayProxyInternalSync(int index)
		{
			this.Delegate.RefreshGridProxy(index, index);
			TProxy value = this.ProxyDisplayList[index];
			object key = this.GetKey(index);
			if (key != null)
			{
				this.ProxyMap[key] = value;
			}
		}

		// Token: 0x06032F50 RID: 208720 RVA: 0x00CC3AE8 File Offset: 0x00CC1CE8
		private UniTask RefreshDisplayProxyInternalAsync(int index)
		{
			GenericLayout<TProxy, TData>.<RefreshDisplayProxyInternalAsync>d__33 <RefreshDisplayProxyInternalAsync>d__;
			<RefreshDisplayProxyInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshDisplayProxyInternalAsync>d__.<>4__this = this;
			<RefreshDisplayProxyInternalAsync>d__.index = index;
			<RefreshDisplayProxyInternalAsync>d__.<>1__state = -1;
			<RefreshDisplayProxyInternalAsync>d__.<>t__builder.Start<GenericLayout<TProxy, TData>.<RefreshDisplayProxyInternalAsync>d__33>(ref <RefreshDisplayProxyInternalAsync>d__);
			return <RefreshDisplayProxyInternalAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032F51 RID: 208721 RVA: 0x00CC3B34 File Offset: 0x00CC1D34
		private UniTask UpdateDataInternal(IReadOnlyList<TData> data, int length)
		{
			GenericLayout<TProxy, TData>.<UpdateDataInternal>d__34 <UpdateDataInternal>d__;
			<UpdateDataInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateDataInternal>d__.<>4__this = this;
			<UpdateDataInternal>d__.data = data;
			<UpdateDataInternal>d__.length = length;
			<UpdateDataInternal>d__.<>1__state = -1;
			<UpdateDataInternal>d__.<>t__builder.Start<GenericLayout<TProxy, TData>.<UpdateDataInternal>d__34>(ref <UpdateDataInternal>d__);
			return <UpdateDataInternal>d__.<>t__builder.Task;
		}

		// Token: 0x06032F52 RID: 208722 RVA: 0x00CC3B87 File Offset: 0x00CC1D87
		[NullableContext(2)]
		public UUIItem GetItemByIndex(int index)
		{
			if (index < 0 || index >= this.GridDisplayItemList.Count)
			{
				return null;
			}
			return this.GridDisplayItemList[index];
		}

		// Token: 0x06032F53 RID: 208723 RVA: 0x00CC3BAC File Offset: 0x00CC1DAC
		[return: Nullable(2)]
		public UUIItem GetItemByKey(object key)
		{
			TProxy layoutItemByKey = this.GetLayoutItemByKey(key);
			return this.GridDisplayItemList[layoutItemByKey.GridIndex];
		}

		// Token: 0x06032F54 RID: 208724 RVA: 0x00CC3BD8 File Offset: 0x00CC1DD8
		[return: Nullable(2)]
		public TProxy GetLayoutItemByKey(object key)
		{
			TProxy result;
			if (this.ProxyMap.TryGetValue(key, out result))
			{
				return result;
			}
			return default(TProxy);
		}

		// Token: 0x06032F55 RID: 208725 RVA: 0x00CC3C00 File Offset: 0x00CC1E00
		public Dictionary<object, TProxy> GetLayoutItemMap()
		{
			return this.ProxyMap;
		}

		// Token: 0x06032F56 RID: 208726 RVA: 0x00CC3C08 File Offset: 0x00CC1E08
		public List<TProxy> GetLayoutItemList()
		{
			return this.ProxyDisplayList;
		}

		// Token: 0x06032F57 RID: 208727 RVA: 0x00CC3C10 File Offset: 0x00CC1E10
		[NullableContext(2)]
		public TProxy GetLayoutItemByIndex(int index)
		{
			if (index < 0 || index >= this.ProxyDisplayList.Count)
			{
				return default(TProxy);
			}
			return this.ProxyDisplayList[index];
		}

		// Token: 0x06032F58 RID: 208728 RVA: 0x00CC3C45 File Offset: 0x00CC1E45
		public IReadOnlyList<TData> GetDatas()
		{
			return this.Delegate.GetDatas();
		}

		// Token: 0x06032F59 RID: 208729 RVA: 0x00CC3C52 File Offset: 0x00CC1E52
		public void SelectGridProxy(int gridIndex, bool fireEvent = false)
		{
			this.Delegate.SelectGridProxy(gridIndex, gridIndex, fireEvent);
		}

		// Token: 0x06032F5A RID: 208730 RVA: 0x00CC3C64 File Offset: 0x00CC1E64
		public void SelectGridProxyByKey(object key, bool fireEvent = false)
		{
			int? gridIndexByKey = this.GetGridIndexByKey<object>(key);
			if (gridIndexByKey != null)
			{
				this.SelectGridProxy(gridIndexByKey.Value, fireEvent);
			}
		}

		// Token: 0x06032F5B RID: 208731 RVA: 0x00CC3C90 File Offset: 0x00CC1E90
		public void DeselectCurrentGridProxy()
		{
			this.Delegate.DeselectCurrentGridProxy(false);
		}

		// Token: 0x06032F5C RID: 208732 RVA: 0x00CC3C9E File Offset: 0x00CC1E9E
		public int GetSelectedGridIndex()
		{
			return this.Delegate.GetSelectedGridIndex();
		}

		// Token: 0x06032F5D RID: 208733 RVA: 0x00CC3CAB File Offset: 0x00CC1EAB
		[NullableContext(2)]
		public TProxy GetSelectedProxy()
		{
			return this.Delegate.GetSelectedProxy();
		}

		// Token: 0x06032F5E RID: 208734 RVA: 0x00CC3CB8 File Offset: 0x00CC1EB8
		public void BindLateUpdate(Action<float> callBack)
		{
			this.Layout.OnLateUpdate.Bind(callBack);
		}

		// Token: 0x06032F5F RID: 208735 RVA: 0x00CC3CCB File Offset: 0x00CC1ECB
		public void UnBindLateUpdate()
		{
			this.Layout.OnLateUpdate.Unbind();
		}

		// Token: 0x06032F60 RID: 208736 RVA: 0x00CC3CE0 File Offset: 0x00CC1EE0
		public void SetActive(bool bActive)
		{
			UUILayoutBase layout = this.Layout;
			if (layout == null)
			{
				return;
			}
			layout.RootUIComp.Get().SetUIActive(bActive);
		}

		// Token: 0x06032F61 RID: 208737 RVA: 0x00CC3D0B File Offset: 0x00CC1F0B
		[NullableContext(2)]
		private void OnDestroy(AActor actor)
		{
			this.UnBindLateUpdate();
		}

		// Token: 0x06032F62 RID: 208738 RVA: 0x00CC3D13 File Offset: 0x00CC1F13
		public int GetDisplayGridNum()
		{
			return this.ProxyDisplayList.Count;
		}

		// Token: 0x06032F63 RID: 208739 RVA: 0x00CC3D20 File Offset: 0x00CC1F20
		public int GetPreservedGridNum()
		{
			return this.GridItemList.Count;
		}

		// Token: 0x06032F64 RID: 208740 RVA: 0x00CC3D2D File Offset: 0x00CC1F2D
		public int GetDisplayGridStartIndex()
		{
			return 0;
		}

		// Token: 0x06032F65 RID: 208741 RVA: 0x00CC3D30 File Offset: 0x00CC1F30
		public int GetDisplayGridEndIndex()
		{
			return this.GetDisplayGridNum() - 1;
		}

		// Token: 0x06032F66 RID: 208742 RVA: 0x00CC3D3A File Offset: 0x00CC1F3A
		public UUIItem GetGrid(int gridIndex)
		{
			if (gridIndex < 0 || gridIndex >= this.GridDisplayItemList.Count)
			{
				return null;
			}
			return this.GridDisplayItemList[gridIndex];
		}

		// Token: 0x06032F67 RID: 208743 RVA: 0x00CC3D5C File Offset: 0x00CC1F5C
		public UUIItem GetGridByDisplayIndex(int displayIndex)
		{
			return this.GetGrid(displayIndex);
		}

		// Token: 0x06032F68 RID: 208744 RVA: 0x00CC3D65 File Offset: 0x00CC1F65
		public float GetGridAnimationInterval()
		{
			return this.Layout.GetGridAnimationInterval();
		}

		// Token: 0x06032F69 RID: 208745 RVA: 0x00CC3D72 File Offset: 0x00CC1F72
		public float GetGridAnimationStartTime()
		{
			return this.Layout.GetGridAnimationStartTime();
		}

		// Token: 0x06032F6A RID: 208746 RVA: 0x00CC3D7F File Offset: 0x00CC1F7F
		public void NotifyAnimationStart()
		{
			this.Layout.SetInAnimation(true);
		}

		// Token: 0x06032F6B RID: 208747 RVA: 0x00CC3D8D File Offset: 0x00CC1F8D
		public void NotifyAnimationEnd()
		{
			this.Layout.SetInAnimation(false);
		}

		// Token: 0x06032F6C RID: 208748 RVA: 0x00CC3D9B File Offset: 0x00CC1F9B
		[NullableContext(2)]
		public UUIInturnAnimController GetUiAnimController()
		{
			if (this.AnimControllerComponent == null)
			{
				UUILayoutBase layout = this.Layout;
				this.AnimControllerComponent = (((layout != null) ? layout.GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) : null) as UUIInturnAnimController);
			}
			return this.AnimControllerComponent;
		}

		// Token: 0x06032F6D RID: 208749 RVA: 0x00CC3DD7 File Offset: 0x00CC1FD7
		public void PlayGridAnim()
		{
			if (this.GridsController != null)
			{
				this.GridsController.PlayGridAnim(this.GetDisplayGridNum(), false);
			}
		}

		// Token: 0x06032F6E RID: 208750 RVA: 0x00CC3DF4 File Offset: 0x00CC1FF4
		public void RefreshGridProxyByKey<[Nullable(2)] T>(T key)
		{
			int? gridIndexByKey = this.GetGridIndexByKey<T>(key);
			if (gridIndexByKey != null)
			{
				this.Delegate.RefreshGridProxy(gridIndexByKey.Value, gridIndexByKey.Value);
			}
		}

		// Token: 0x0401DA6D RID: 121453
		[Nullable(2)]
		private readonly UUILayoutBase Layout;

		// Token: 0x0401DA6E RID: 121454
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private readonly ScrollViewDelegate<TProxy, TData> Delegate;

		// Token: 0x0401DA6F RID: 121455
		[Nullable(2)]
		private GridAppearAnimationBase GridsController;

		// Token: 0x0401DA70 RID: 121456
		[Nullable(2)]
		public UUIInturnAnimController AnimControllerComponent;

		// Token: 0x0401DA71 RID: 121457
		private readonly List<UUIItem> GridItemList = new List<UUIItem>();

		// Token: 0x0401DA72 RID: 121458
		private readonly List<UUIItem> GridDisplayItemList = new List<UUIItem>();

		// Token: 0x0401DA73 RID: 121459
		private readonly List<TProxy> ProxyDisplayList = new List<TProxy>();

		// Token: 0x0401DA74 RID: 121460
		private readonly Dictionary<object, TProxy> ProxyMap = new Dictionary<object, TProxy>();

		// Token: 0x0401DA75 RID: 121461
		[Nullable(2)]
		private readonly AUIBaseActor TemplateGridActor;

		// Token: 0x0401DA76 RID: 121462
		[Nullable(new byte[]
		{
			1,
			1,
			0,
			0
		})]
		private readonly Queue<GenericLayout<TProxy, TData>.OperationParam> OperationQueue = new Queue<GenericLayout<TProxy, TData>.OperationParam>(4);

		// Token: 0x0401DA77 RID: 121463
		private bool Operating;

		// Token: 0x0401DA78 RID: 121464
		public readonly bool IsRefreshAsync;

		// Token: 0x0401DA79 RID: 121465
		public readonly bool IsGridShowWhenCreate = true;

		// Token: 0x0200AD20 RID: 44320
		[NullableContext(2)]
		[Nullable(0)]
		private class OperationParam
		{
			// Token: 0x0604BE37 RID: 310839 RVA: 0x014AD75A File Offset: 0x014AB95A
			public OperationParam([Nullable(new byte[]
			{
				2,
				1
			})] IReadOnlyList<TData> data = null, Action callBack = null, bool playGridAnim = false)
			{
				this.Data = data;
				this.CallBack = callBack;
				this.PlayGridAnim = playGridAnim;
			}

			// Token: 0x04035C17 RID: 220183
			[Nullable(new byte[]
			{
				2,
				1
			})]
			public IReadOnlyList<TData> Data;

			// Token: 0x04035C18 RID: 220184
			public Action CallBack;

			// Token: 0x04035C19 RID: 220185
			public bool PlayGridAnim;
		}
	}
}
