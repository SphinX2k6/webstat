using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;

// Token: 0x020032C0 RID: 12992
[NullableContext(1)]
[Nullable(0)]
public class PlotAssetManager
{
	// Token: 0x0601B3AA RID: 111530 RVA: 0x0082E3D2 File Offset: 0x0082C5D2
	public void Init()
	{
		this.HoldPreloadObject = new UHoldPreloadObject(GlobalData.GameInstance, null, EObjectFlags.RF_NoFlags);
	}

	// Token: 0x0601B3AB RID: 111531 RVA: 0x0082E3E6 File Offset: 0x0082C5E6
	public bool CheckCanLoad(string id, int priority)
	{
		return priority > 100 || this.LoadStateMap.Count == 0;
	}

	// Token: 0x0601B3AC RID: 111532 RVA: 0x0082E400 File Offset: 0x0082C600
	public void AddPending(string id, int priority)
	{
		if (this.IdAssetElementMap.ContainsKey(id))
		{
			return;
		}
		if (this.IdPendingMap.ContainsKey(id))
		{
			IPreloadPlot preloadPlot = this.IdPendingMap[id];
			((PreloadPlot)preloadPlot).Priority = priority;
			this.PendingList.Update(preloadPlot);
			return;
		}
		PreloadPlot preloadPlot2 = new PreloadPlot
		{
			Id = id,
			Priority = priority
		};
		this.IdPendingMap[id] = preloadPlot2;
		this.PendingList.Push(preloadPlot2);
	}

	// Token: 0x0601B3AD RID: 111533 RVA: 0x0082E47E File Offset: 0x0082C67E
	public void RemovePending(string id)
	{
		if (!this.IdPendingMap.ContainsKey(id))
		{
			return;
		}
		this.PendingList.Remove(this.IdPendingMap[id]);
		this.IdPendingMap.Remove(id);
	}

	// Token: 0x0601B3AE RID: 111534 RVA: 0x0082E4B4 File Offset: 0x0082C6B4
	[NullableContext(2)]
	public IPreloadPlot CheckAndGetPendingPreload()
	{
		if (this.PendingList.Size == 0)
		{
			return null;
		}
		IPreloadPlot top = this.PendingList.Top;
		if (top != null && this.CheckCanLoad(top.Id, top.Priority))
		{
			this.IdPendingMap.Remove(top.Id);
			return this.PendingList.Pop();
		}
		return null;
	}

	// Token: 0x0601B3AF RID: 111535 RVA: 0x0082E514 File Offset: 0x0082C714
	[return: Nullable(2)]
	public AssetElement AddPlotAssetElement(string id)
	{
		if (this.IdAssetElementMap.ContainsKey(id))
		{
			return null;
		}
		AssetElement assetElement = new AssetElement(null);
		assetElement.AddObjectCallback = new Action<UObject, string>(this.OnObjectCallback);
		this.IdAssetElementMap[id] = assetElement;
		return assetElement;
	}

	// Token: 0x0601B3B0 RID: 111536 RVA: 0x0082E558 File Offset: 0x0082C758
	public bool RemovePlotAssetElement(string id)
	{
		if (!this.IdAssetElementMap.ContainsKey(id))
		{
			return false;
		}
		AssetElement assetElement = this.IdAssetElementMap[id];
		foreach (string key in assetElement.LoadingSet)
		{
			this.PathKeyMap.Remove(key);
		}
		foreach (string text in assetElement.LoadedSet)
		{
			int entityId;
			if (!this.PathKeyMap.TryGetValue(text, out entityId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Preload;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "[预加载][Plot] 卸载资源时Key已丢失，跳过";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", text);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				this.HoldPreloadObject.RemoveEntityAssets(entityId);
				this.PathKeyMap.Remove(text);
			}
		}
		this.IdAssetElementMap.Remove(id);
		PlotAssetExtra valueOrDefault = this.ExtraAssetMap.GetValueOrDefault(id);
		this.ExtraAssetMap.Remove(id);
		if (!string.IsNullOrEmpty((valueOrDefault != null) ? valueOrDefault.VideoPath : null))
		{
			this.VideoPathSet.Remove(valueOrDefault.VideoPath);
		}
		bool flag = true;
		using (Dictionary<string, PlotAssetExtra>.ValueCollection.Enumerator enumerator2 = this.ExtraAssetMap.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				if (!string.IsNullOrEmpty(enumerator2.Current.VideoPath))
				{
					flag = false;
					break;
				}
			}
		}
		if (flag && this.VideoViewActor != null)
		{
			Singleton<UiActorPool>.Instance.RecycleAsync(this.VideoViewActor, this.VideoViewActor.Path);
			this.VideoViewActor = null;
		}
		if (((valueOrDefault != null) ? valueOrDefault.QteIds : null) != null)
		{
			foreach (int item in valueOrDefault.QteIds)
			{
				this.QteIdSet.Remove(item);
			}
		}
		ControllerBase<CommonQteController>.Instance.ClearPreloadQteRes();
		return true;
	}

	// Token: 0x0601B3B1 RID: 111537 RVA: 0x0082E794 File Offset: 0x0082C994
	public void AddPath(AssetElement assetElement, string path)
	{
		if (assetElement.AddOther(path))
		{
			int assetKey = this.AssetKey;
			this.AssetKey = assetKey + 1;
			int value = assetKey;
			this.PathKeyMap[path] = value;
		}
	}

	// Token: 0x0601B3B2 RID: 111538 RVA: 0x0082E7CC File Offset: 0x0082C9CC
	private void OnObjectCallback(UObject @object, string path)
	{
		if (!this.PathKeyMap.ContainsKey(path))
		{
			return;
		}
		int entityId = this.PathKeyMap[path];
		this.HoldPreloadObject.AddEntityAsset(entityId, @object);
	}

	// Token: 0x0601B3B3 RID: 111539 RVA: 0x0082E804 File Offset: 0x0082CA04
	public void RemoveAllPreload()
	{
		this.ExtraAssetMap.Clear();
		this.QteIdSet.Clear();
		ControllerBase<CommonQteController>.Instance.ClearPreloadQteRes();
		this.VideoPathSet.Clear();
		UiPoolActor videoViewActor = this.VideoViewActor;
		if (videoViewActor != null)
		{
			videoViewActor.Clear();
		}
		this.VideoViewActor = null;
		this.PendingList.Clear();
		this.IdPendingMap.Clear();
		this.IdAssetElementMap.Clear();
		this.PathKeyMap.Clear();
		if (this.HoldPreloadObject != null)
		{
			this.HoldPreloadObject.Clear();
		}
	}

	// Token: 0x0601B3B4 RID: 111540 RVA: 0x0082E893 File Offset: 0x0082CA93
	public void Clear()
	{
		this.RemoveAllPreload();
		this.HoldPreloadObject = null;
	}

	// Token: 0x0601B3B5 RID: 111541 RVA: 0x0082E8A4 File Offset: 0x0082CAA4
	public int GetAsset<[Nullable(0)] T>(string path, [Nullable(new byte[]
	{
		1,
		2,
		1
	})] Action<T, string> callback) where T : UObject
	{
		T assetInternal = this.GetAssetInternal<T>(path);
		if (assetInternal != null)
		{
			callback(assetInternal, path);
			return -1;
		}
		return Singleton<ResourceSystem>.Instance.LoadAsync<T>(path, callback, 100, "js_undefined");
	}

	// Token: 0x0601B3B6 RID: 111542 RVA: 0x0082E8E0 File Offset: 0x0082CAE0
	[return: Nullable(2)]
	private T GetAssetInternal<[Nullable(0)] T>(string path) where T : UObject
	{
		if (this.PathKeyMap.ContainsKey(path))
		{
			int key = this.PathKeyMap[path];
			FPreloadObjectCollection fpreloadObjectCollection;
			if (this.HoldPreloadObject.EntityAssetMap.TryGetValue(key, out fpreloadObjectCollection) && fpreloadObjectCollection != null && fpreloadObjectCollection.Assets.Num() > 0)
			{
				return (T)((object)fpreloadObjectCollection.Assets.Get(0));
			}
		}
		return default(T);
	}

	// Token: 0x0601B3B7 RID: 111543 RVA: 0x0082E950 File Offset: 0x0082CB50
	public List<UObject> GetAllLoadedAssets(string id)
	{
		List<UObject> list = new List<UObject>();
		AssetElement valueOrDefault = this.IdAssetElementMap.GetValueOrDefault(id);
		if (valueOrDefault == null)
		{
			return list;
		}
		foreach (string key in valueOrDefault.LoadedSet)
		{
			int key2;
			FPreloadObjectCollection fpreloadObjectCollection;
			if (this.PathKeyMap.TryGetValue(key, out key2) && this.HoldPreloadObject != null && this.HoldPreloadObject.EntityAssetMap.TryGetValue(key2, out fpreloadObjectCollection) && fpreloadObjectCollection != null && fpreloadObjectCollection.Assets.Num() > 0)
			{
				list.Add(fpreloadObjectCollection.Assets.Get(0));
			}
		}
		return list;
	}

	// Token: 0x0601B3B8 RID: 111544 RVA: 0x0082EA10 File Offset: 0x0082CC10
	[NullableContext(0)]
	public UniTask<bool> LoadExtraAsset([Nullable(1)] PlotAssetExtra extraData)
	{
		PlotAssetManager.<LoadExtraAsset>d__25 <LoadExtraAsset>d__;
		<LoadExtraAsset>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadExtraAsset>d__.<>4__this = this;
		<LoadExtraAsset>d__.extraData = extraData;
		<LoadExtraAsset>d__.<>1__state = -1;
		<LoadExtraAsset>d__.<>t__builder.Start<PlotAssetManager.<LoadExtraAsset>d__25>(ref <LoadExtraAsset>d__);
		return <LoadExtraAsset>d__.<>t__builder.Task;
	}

	// Token: 0x0601B3B9 RID: 111545 RVA: 0x0082EA5C File Offset: 0x0082CC5C
	[return: Nullable(2)]
	private static T TryGetComponentByIndex<[Nullable(0)] T>([Nullable(2)] AActor actor, int index) where T : UActorComponent, IUnrealUObject
	{
		if (actor == null)
		{
			return default(T);
		}
		AUIBaseActor auibaseActor = (AUIBaseActor)actor;
		ULGUIComponentsRegistry componentsRegistry = Singleton<LguiUtil>.Instance.GetComponentsRegistry(auibaseActor);
		if (componentsRegistry == null)
		{
			AUIBaseActor childActorByHierarchyIndex = Singleton<LguiUtil>.Instance.GetChildActorByHierarchyIndex(auibaseActor, 0);
			if (childActorByHierarchyIndex != null)
			{
				componentsRegistry = Singleton<LguiUtil>.Instance.GetComponentsRegistry(childActorByHierarchyIndex);
				if (componentsRegistry == null)
				{
					childActorByHierarchyIndex = Singleton<LguiUtil>.Instance.GetChildActorByHierarchyIndex(childActorByHierarchyIndex, 0);
					if (childActorByHierarchyIndex != null)
					{
						componentsRegistry = Singleton<LguiUtil>.Instance.GetComponentsRegistry(childActorByHierarchyIndex);
					}
				}
			}
		}
		if (componentsRegistry == null)
		{
			return default(T);
		}
		AActor aactor = componentsRegistry.Components.Get(index);
		return ((aactor != null) ? aactor.GetComponentByClass(IUnrealUObject.StaticClass()) : null) as T;
	}

	// Token: 0x0601B3BA RID: 111546 RVA: 0x0082EB08 File Offset: 0x0082CD08
	[NullableContext(0)]
	public UniTask<bool> LoadVideoViewAsync([Nullable(1)] string videoPath)
	{
		PlotAssetManager.<LoadVideoViewAsync>d__27 <LoadVideoViewAsync>d__;
		<LoadVideoViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadVideoViewAsync>d__.<>4__this = this;
		<LoadVideoViewAsync>d__.videoPath = videoPath;
		<LoadVideoViewAsync>d__.<>1__state = -1;
		<LoadVideoViewAsync>d__.<>t__builder.Start<PlotAssetManager.<LoadVideoViewAsync>d__27>(ref <LoadVideoViewAsync>d__);
		return <LoadVideoViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601B3BB RID: 111547 RVA: 0x0082EB54 File Offset: 0x0082CD54
	[NullableContext(0)]
	public UniTask<int?> OpenVideoViewAsync([Nullable(2)] object param)
	{
		PlotAssetManager.<OpenVideoViewAsync>d__28 <OpenVideoViewAsync>d__;
		<OpenVideoViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<int?>.Create();
		<OpenVideoViewAsync>d__.<>4__this = this;
		<OpenVideoViewAsync>d__.param = param;
		<OpenVideoViewAsync>d__.<>1__state = -1;
		<OpenVideoViewAsync>d__.<>t__builder.Start<PlotAssetManager.<OpenVideoViewAsync>d__28>(ref <OpenVideoViewAsync>d__);
		return <OpenVideoViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601B3BC RID: 111548 RVA: 0x0082EB9F File Offset: 0x0082CD9F
	public bool HasPreloadVideo(string cgPath)
	{
		return this.VideoPathSet.Contains(cgPath);
	}

	// Token: 0x0601B3BD RID: 111549 RVA: 0x0082EBB0 File Offset: 0x0082CDB0
	public bool HasPreloadQte(List<int> qteIds)
	{
		foreach (int item in qteIds)
		{
			if (!this.QteIdSet.Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601B3BE RID: 111550 RVA: 0x0082EC0C File Offset: 0x0082CE0C
	public void DebugLog()
	{
	}

	// Token: 0x0400DDF4 RID: 56820
	public readonly Dictionary<string, ELoadResultType> LoadStateMap = new Dictionary<string, ELoadResultType>();

	// Token: 0x0400DDF5 RID: 56821
	private readonly Dictionary<string, AssetElement> IdAssetElementMap = new Dictionary<string, AssetElement>();

	// Token: 0x0400DDF6 RID: 56822
	private readonly Dictionary<string, int> PathKeyMap = new Dictionary<string, int>();

	// Token: 0x0400DDF7 RID: 56823
	private int AssetKey = 1;

	// Token: 0x0400DDF8 RID: 56824
	[Nullable(2)]
	private UHoldPreloadObject HoldPreloadObject;

	// Token: 0x0400DDF9 RID: 56825
	public Dictionary<string, IPreloadPlot> IdPendingMap = new Dictionary<string, IPreloadPlot>();

	// Token: 0x0400DDFA RID: 56826
	public readonly PriorityQueue<IPreloadPlot> PendingList = new PriorityQueue<IPreloadPlot>((IPreloadPlot a, IPreloadPlot b) => b.Priority - a.Priority);

	// Token: 0x0400DDFB RID: 56827
	private readonly Dictionary<string, PlotAssetExtra> ExtraAssetMap = new Dictionary<string, PlotAssetExtra>();

	// Token: 0x0400DDFC RID: 56828
	private readonly HashSet<string> VideoPathSet = new HashSet<string>();

	// Token: 0x0400DDFD RID: 56829
	[Nullable(2)]
	public UiPoolActor VideoViewActor;

	// Token: 0x0400DDFE RID: 56830
	private HashSet<int> QteIdSet = new HashSet<int>();
}
