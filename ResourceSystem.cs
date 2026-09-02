using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;

// Token: 0x02000BE3 RID: 3043
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ResourceSystem : Singleton<ResourceSystem>
{
	// Token: 0x0600320C RID: 12812 RVA: 0x000205CF File Offset: 0x0001E7CF
	public bool IsMemoryTagOpen()
	{
		return this.IsOpenMemoryTag;
	}

	// Token: 0x0600320D RID: 12813 RVA: 0x000205D8 File Offset: 0x0001E7D8
	public void Initialize()
	{
		this.IsOpenMemoryTag = !KuroApplication.IsBuildShipping();
		this.KuroResourceManager = new UKuroResourceManager();
		this.KuroResourceManager.LoadResourceDelegate.Bind(delegate(int id)
		{
			Singleton<ResourceSystem>.Instance.OnLoadComplete(id);
		});
		this.LoadingTaskMap.Clear();
		this.TypeCache.Clear();
		this.InternalIsAsyncLoadingThreadEnabled = KuroApplication.IsAsyncLoadingThreadEnabled();
	}

	// Token: 0x0600320E RID: 12814 RVA: 0x0002064E File Offset: 0x0001E84E
	public void SetCallbackTimeLimit(int millisecond)
	{
		this.TaskTimeLimit.Limit = (long)(millisecond * 1000);
	}

	// Token: 0x0600320F RID: 12815 RVA: 0x00020664 File Offset: 0x0001E864
	public unsafe void UpdateDelayCallback(bool reset = true)
	{
		if (this.Updating)
		{
			return;
		}
		this.Updating = true;
		while (!this.DelayTaskQueue.Empty && !this.TaskTimeLimit.IsTimeLimitExceeded())
		{
			ResourceSystem.LoadCallbackTask loadCallbackTask = this.DelayTaskQueue.Pop();
			if (this.CancelIdSet.Remove(loadCallbackTask.Id))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Resource;
				ELogAuthor author = ELogAuthor.LCC;
				string message = "预加载回调执行失败，任务已被取消";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ResourceSystem.Instance.Instance.DelayTaskQueue.Empty", this.DelayTaskQueue.Empty);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsTimeLimitExceeded", this.TaskTimeLimit.IsTimeLimitExceeded());
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				loadCallbackTask.Callback();
			}
		}
		if (reset)
		{
			this.TaskTimeLimit.ResetCost();
		}
		this.Updating = false;
	}

	// Token: 0x06003210 RID: 12816 RVA: 0x00020754 File Offset: 0x0001E954
	private unsafe void PreloadTypes(HashSet<string> set, [Nullable(2)] Action callback = null, string memoyTag = "js_undefined")
	{
		if (set.Count == 0)
		{
			Action callback2 = callback;
			if (callback2 != null)
			{
				callback2();
			}
		}
		long startTime = DateTime.Now.Ticks / 10000L;
		using (HashSet<string>.Enumerator enumerator = set.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				string key = enumerator.Current;
				this.LoadTypeAsync(key, delegate
				{
					set.Remove(key);
					if (set.Count == 0)
					{
						long num = DateTime.Now.Ticks / 10000L;
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Resource;
						ELogAuthor author = ELogAuthor.LCC;
						string message = "预加载类型结束 ";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("count", set.Count);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("cost", num - startTime);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						Action callback3 = callback;
						if (callback3 == null)
						{
							return;
						}
						callback3();
					}
				}, memoyTag);
			}
		}
	}

	// Token: 0x06003211 RID: 12817 RVA: 0x00020818 File Offset: 0x0001EA18
	[NullableContext(2)]
	public void PreloadSimpleTypes(Action callback = null)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string text in ClassDefine.typeDefined.Keys)
		{
			if (!this.TypeCache.ContainsKey(text) && ClassDefine.typeDefined[text].Item3 == ETypeLoadKind.Preload && ClassDefine.typeDefined[text].Item1 != ClassDefine.EType.Class)
			{
				hashSet.Add(text);
			}
		}
		this.PreloadTypes(hashSet, callback, "PreloadSimpleTypes");
	}

	// Token: 0x06003212 RID: 12818 RVA: 0x000208B8 File Offset: 0x0001EAB8
	[NullableContext(2)]
	public void PreloadOtherTypes(Action callback = null)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string text in ClassDefine.typeDefined.Keys)
		{
			if (!this.TypeCache.ContainsKey(text) && ClassDefine.typeDefined[text].Item3 == ETypeLoadKind.Preload)
			{
				hashSet.Add(text);
			}
		}
		this.PreloadTypes(hashSet, callback, "PreloadOtherTypes");
	}

	// Token: 0x06003213 RID: 12819 RVA: 0x00020944 File Offset: 0x0001EB44
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private ValueTuple<ClassDefine.EType, string, ETypeLoadKind>? GetTypeDefined(string name)
	{
		ValueTuple<ClassDefine.EType, string, ETypeLoadKind> value;
		if (!ClassDefine.typeDefined.TryGetValue(name, out value))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "该类型没有注册";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new ValueTuple<ClassDefine.EType, string, ETypeLoadKind>?(value);
	}

	// Token: 0x06003214 RID: 12820 RVA: 0x00020998 File Offset: 0x0001EB98
	[return: Nullable(2)]
	private unsafe string GetTypePath(string name, [Nullable(new byte[]
	{
		0,
		1
	})] ValueTuple<ClassDefine.EType, string, ETypeLoadKind> define)
	{
		string item = define.Item2;
		if (string.IsNullOrEmpty(item))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "加载类型路径为空";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("type", define.Item1);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return item;
	}

	// Token: 0x06003215 RID: 12821 RVA: 0x00020A14 File Offset: 0x0001EC14
	private unsafe void LoadType(string name)
	{
		if (this.TypeCache.ContainsKey(name))
		{
			return;
		}
		ValueTuple<ClassDefine.EType, string, ETypeLoadKind>? typeDefined = this.GetTypeDefined(name);
		if (typeDefined == null)
		{
			return;
		}
		string typePath = this.GetTypePath(name, typeDefined.Value);
		if (string.IsNullOrEmpty(typePath))
		{
			return;
		}
		ClassDefine.EType item = typeDefined.Value.Item1;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Resource;
		ELogAuthor author = ELogAuthor.LCC;
		string message = "运行时加载类型";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", name);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("type", item);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("path", typePath);
		instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		UObject uobject;
		switch (item)
		{
		case ClassDefine.EType.Class:
			uobject = this.Load<UBlueprintGeneratedClass>(typePath, "js_undefined");
			break;
		case ClassDefine.EType.Struct:
			uobject = this.Load<UUserDefinedStruct>(typePath, "js_undefined");
			break;
		case ClassDefine.EType.Enum:
			uobject = this.Load<UUserDefinedEnum>(typePath, "js_undefined");
			break;
		default:
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Resource;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "加载类型错误";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("name", name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("type", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("path", typePath);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return;
		}
		}
		if (uobject == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Resource;
			ELogAuthor author3 = ELogAuthor.LCC;
			string message3 = "加载类型失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("name", name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("type", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("path", typePath);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return;
		}
		this.TypeCache[name] = uobject;
	}

	// Token: 0x06003216 RID: 12822 RVA: 0x00020C0C File Offset: 0x0001EE0C
	[return: Nullable(2)]
	public UObject GetLoadedType(string name)
	{
		UObject result;
		if (!this.TypeCache.TryGetValue(name, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "获取已加载类型失败，调用前请先加载";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return result;
	}

	// Token: 0x06003217 RID: 12823 RVA: 0x00020C50 File Offset: 0x0001EE50
	public unsafe void LoadTypeAsync(string name, Action callback, string memoryTag = "js_undefined")
	{
		if (this.TypeCache.ContainsKey(name))
		{
			callback();
			return;
		}
		ValueTuple<ClassDefine.EType, string, ETypeLoadKind>? typeDefined = this.GetTypeDefined(name);
		if (typeDefined == null)
		{
			return;
		}
		string typePath = this.GetTypePath(name, typeDefined.Value);
		if (string.IsNullOrEmpty(typePath))
		{
			return;
		}
		ClassDefine.EType type = typeDefined.Value.Item1;
		Action<UObject, string> callback2 = delegate([Nullable(2)] UObject asset, string p)
		{
			if (asset == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Resource;
				ELogAuthor author2 = ELogAuthor.LCC;
				string message2 = "预加载类型失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("name", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("type", type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("path", p);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
			else
			{
				this.TypeCache[name] = asset;
			}
			callback();
		};
		switch (type)
		{
		case ClassDefine.EType.Class:
			this.LoadAsync<UBlueprintGeneratedClass>(typePath, callback2, 100, memoryTag);
			return;
		case ClassDefine.EType.Struct:
			this.LoadAsync<UUserDefinedStruct>(typePath, callback2, 100, memoryTag);
			return;
		case ClassDefine.EType.Enum:
			this.LoadAsync<UUserDefinedEnum>(typePath, callback2, 100, memoryTag);
			return;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "预加载类型错误";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("type", type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("path", typePath);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			callback();
			return;
		}
		}
	}

	// Token: 0x06003218 RID: 12824 RVA: 0x00020DB4 File Offset: 0x0001EFB4
	private void OnLoadComplete(int id)
	{
		ResourceSystem.LoadCallbackTask item;
		if (!this.LoadingTaskMap.TryGetValue(id, out item))
		{
			return;
		}
		this.LoadingTaskMap.Remove(id);
		this.DelayTaskQueue.Push(item);
		this.UpdateDelayCallback(false);
	}

	// Token: 0x06003219 RID: 12825 RVA: 0x00020DF4 File Offset: 0x0001EFF4
	private bool CheckPath(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			Singleton<Log>.Instance.Error(ELogModule.Resource, ELogAuthor.LCC, "路径为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (!path.StartsWith("/"))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "传入资源路径不符合规范";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return true;
	}

	// Token: 0x0600321A RID: 12826 RVA: 0x00020E5C File Offset: 0x0001F05C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private TWeakObjectPtr<UClass>? GetClass<[Nullable(0)] T>(string path) where T : UObject, IUnrealUObject
	{
		if (!this.CheckPath(path))
		{
			return null;
		}
		UClassStackOnlyPtr ptr = IUnrealUObject.StaticClass();
		if (!ptr.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "传入类型获取到的 UE Class 无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new TWeakObjectPtr<UClass>?(ptr.ToWeakClass());
	}

	// Token: 0x0600321B RID: 12827 RVA: 0x00020ECC File Offset: 0x0001F0CC
	[return: Nullable(2)]
	private T GetAsset<[Nullable(0)] T>(string path, int id) where T : UObject, IUnrealUObject
	{
		UObject asset = this.KuroResourceManager.GetAsset(id);
		this.KuroResourceManager.Release(id);
		if (!this.CheckAsset<T>(asset, path))
		{
			return default(T);
		}
		return asset as T;
	}

	// Token: 0x0600321C RID: 12828 RVA: 0x00020F14 File Offset: 0x0001F114
	private unsafe bool CheckAsset<[Nullable(0)] T>([Nullable(2)] UObject asset, string path) where T : UObject, IUnrealUObject
	{
		if (asset == null || !asset.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "资源加载资产无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (!(asset is T))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Resource;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "传入类型与资产类型不匹配";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", path);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("type", typeof(T).Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("asset", asset.GetClass().GetName());
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		if (UKuroResourceSystemFunctionLibrary.IsAssetBlocked(path))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Resource;
			ELogAuthor author3 = ELogAuthor.LCC;
			string message3 = "标记为废弃资源被加载";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("path", path);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		return true;
	}

	// Token: 0x0600321D RID: 12829 RVA: 0x00021018 File Offset: 0x0001F218
	[return: Nullable(2)]
	public T Load<[Nullable(0)] T>(string path, string memoryTag = "js_undefined") where T : UObject
	{
		if (memoryTag == null)
		{
			memoryTag = "js_undefined";
		}
		if (this.GetClass<T>(path) == null)
		{
			return default(T);
		}
		int num = this.HandleId + 1;
		this.HandleId = num;
		int num2 = num;
		ResourceSystem.EAsyncLoadResult easyncLoadResult;
		if (this.IsOpenMemoryTag)
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName(memoryTag);
			easyncLoadResult = (ResourceSystem.EAsyncLoadResult)this.KuroResourceManager.LoadWithIdAndTag(path, num2, dynamicFName.Value);
		}
		else
		{
			easyncLoadResult = (ResourceSystem.EAsyncLoadResult)this.KuroResourceManager.LoadWithId(path, num2);
		}
		if (easyncLoadResult == ResourceSystem.EAsyncLoadResult.Error)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "资源加载异常";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return default(T);
		}
		return this.GetAsset<T>(path, num2);
	}

	// Token: 0x0600321E RID: 12830 RVA: 0x000210D4 File Offset: 0x0001F2D4
	[return: Nullable(2)]
	public T GetLoadedAsset<[Nullable(0)] T>(string path) where T : UObject
	{
		TWeakObjectPtr<UClass>? @class = this.GetClass<T>(path);
		if (@class == null)
		{
			return default(T);
		}
		UClass uclass = @class.Value.Get();
		if (uclass == null || !uclass.IsValid())
		{
			return default(T);
		}
		UObject loadedAsset = this.KuroResourceManager.GetLoadedAsset(path);
		if (!this.CheckAsset<T>(loadedAsset, path))
		{
			return default(T);
		}
		return loadedAsset as T;
	}

	// Token: 0x0600321F RID: 12831 RVA: 0x00021154 File Offset: 0x0001F354
	public bool CheckAssetLoaded<[Nullable(0)] T>(string path) where T : UObject
	{
		TWeakObjectPtr<UClass>? @class = this.GetClass<T>(path);
		if (@class == null)
		{
			return false;
		}
		if (!@class.Value.IsValid(false, false))
		{
			return false;
		}
		UObject loadedAsset = this.KuroResourceManager.GetLoadedAsset(path);
		return loadedAsset != null && loadedAsset.IsValid() && loadedAsset.IsA(@class.Value.GetClass<UClass>());
	}

	// Token: 0x06003220 RID: 12832 RVA: 0x000211BE File Offset: 0x0001F3BE
	public int LoadAsync<[Nullable(0)] T>(string path, [Nullable(new byte[]
	{
		2,
		2,
		1
	})] Action<T, string> callback, ResourceSystem.EResourceLoadPriority priority, string memoryTag = "js_undefined") where T : UObject, IUnrealUObject
	{
		return this.LoadAsync<T>(path, callback, (int)priority, memoryTag);
	}

	// Token: 0x06003221 RID: 12833 RVA: 0x000211CC File Offset: 0x0001F3CC
	public unsafe int LoadAsync<[Nullable(0)] T>(string path, [Nullable(new byte[]
	{
		2,
		2,
		1
	})] Action<T, string> callback, int priority = 100, string memoryTag = "js_undefined") where T : UObject, IUnrealUObject
	{
		ResourceSystem.<>c__DisplayClass47_0<T> CS$<>8__locals1 = new ResourceSystem.<>c__DisplayClass47_0<T>();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.callback = callback;
		CS$<>8__locals1.path = path;
		if (CS$<>8__locals1.callback == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "资源加载回调方法为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", CS$<>8__locals1.path);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return -1;
		}
		if (priority < 100 || priority >= 106)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Resource;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "资源加载优先级错误";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", CS$<>8__locals1.path);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("priority", priority);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return -1;
		}
		ResourceSystem.<>c__DisplayClass47_0<T> CS$<>8__locals2 = CS$<>8__locals1;
		int num = this.HandleId + 1;
		this.HandleId = num;
		CS$<>8__locals2.id = num;
		CS$<>8__locals1.callbackStat = null;
		if (this.GetClass<T>(CS$<>8__locals1.path) == null)
		{
			this.DelayTaskQueue.Push(new ResourceSystem.LoadCallbackTask(CS$<>8__locals1.id, priority, null, delegate()
			{
				CS$<>8__locals1.<>4__this.TryCallback<T>(CS$<>8__locals1.callback, default(T), CS$<>8__locals1.path, CS$<>8__locals1.callbackStat);
			}));
			return -1;
		}
		ResourceSystem.EAsyncLoadResult easyncLoadResult;
		if (this.IsOpenMemoryTag)
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName(memoryTag ?? "js_undefined");
			easyncLoadResult = (ResourceSystem.EAsyncLoadResult)this.KuroResourceManager.LoadAsyncWithIdAndTag(CS$<>8__locals1.path, CS$<>8__locals1.id, priority, dynamicFName.Value);
		}
		else
		{
			easyncLoadResult = (ResourceSystem.EAsyncLoadResult)this.KuroResourceManager.LoadAsyncWithId(CS$<>8__locals1.path, CS$<>8__locals1.id, priority);
		}
		switch (easyncLoadResult)
		{
		case ResourceSystem.EAsyncLoadResult.Error:
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Resource;
			ELogAuthor author3 = ELogAuthor.LCC;
			string message3 = "资源加载错误";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("path", CS$<>8__locals1.path);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.DelayTaskQueue.Push(new ResourceSystem.LoadCallbackTask(CS$<>8__locals1.id, priority, null, delegate()
			{
				CS$<>8__locals1.<>4__this.TryCallback<T>(CS$<>8__locals1.callback, default(T), CS$<>8__locals1.path, CS$<>8__locals1.callbackStat);
			}));
			CS$<>8__locals1.id = -1;
			break;
		}
		case ResourceSystem.EAsyncLoadResult.Loading:
		{
			TimerHandle timerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Resource;
				ELogAuthor author4 = ELogAuthor.MZJ;
				string message4 = "资源加载超时";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("path", CS$<>8__locals1.path);
				instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}, 60000f, null, null, true, 1f);
			this.LoadingTaskMap[CS$<>8__locals1.id] = new ResourceSystem.LoadCallbackTask(CS$<>8__locals1.id, priority, timerHandle, delegate()
			{
				if (timerHandle != null && timerHandle.Valid())
				{
					TimerSystem.Instance.Remove(timerHandle);
				}
				CS$<>8__locals1.<>4__this.TryCallback<T>(CS$<>8__locals1.callback, CS$<>8__locals1.<>4__this.GetAsset<T>(CS$<>8__locals1.path, CS$<>8__locals1.id), CS$<>8__locals1.path, CS$<>8__locals1.callbackStat);
			});
			break;
		}
		case ResourceSystem.EAsyncLoadResult.Completed:
			this.DelayTaskQueue.Push(new ResourceSystem.LoadCallbackTask(CS$<>8__locals1.id, priority, null, delegate()
			{
				CS$<>8__locals1.<>4__this.TryCallback<T>(CS$<>8__locals1.callback, CS$<>8__locals1.<>4__this.GetAsset<T>(CS$<>8__locals1.path, CS$<>8__locals1.id), CS$<>8__locals1.path, CS$<>8__locals1.callbackStat);
			}));
			this.UpdateDelayCallback(false);
			break;
		}
		return CS$<>8__locals1.id;
	}

	// Token: 0x06003222 RID: 12834 RVA: 0x0002148C File Offset: 0x0001F68C
	[NullableContext(2)]
	private unsafe void TryCallback<T>([Nullable(new byte[]
	{
		1,
		2,
		1
	})] Action<T, string> callback, T asset, [Nullable(1)] string path, Stat stat)
	{
		double microseconds = KuroTime.GetMicroseconds64();
		try
		{
			callback(asset, path);
		}
		catch (Exception ex) when (1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "资源加载回调方法执行异常";
			Exception error = ex;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", path);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		double microseconds2 = KuroTime.GetMicroseconds64();
		this.TaskTimeLimit.AddCost(microseconds2 - microseconds);
	}

	// Token: 0x06003223 RID: 12835 RVA: 0x0002153C File Offset: 0x0001F73C
	public void CancelAsyncLoad(int id)
	{
		this.KuroResourceManager.Release(id);
		ResourceSystem.LoadCallbackTask loadCallbackTask;
		if (this.LoadingTaskMap.TryGetValue(id, out loadCallbackTask))
		{
			if (loadCallbackTask.TimeoutTimer != null && loadCallbackTask.TimeoutTimer.Valid())
			{
				TimerSystem.Instance.Remove(loadCallbackTask.TimeoutTimer);
			}
			this.LoadingTaskMap.Remove(id);
			return;
		}
		this.CancelIdSet.Add(id);
	}

	// Token: 0x06003224 RID: 12836 RVA: 0x000215A6 File Offset: 0x0001F7A6
	public bool IsAsyncLoadingThreadEnabled()
	{
		return this.InternalIsAsyncLoadingThreadEnabled;
	}

	// Token: 0x06003225 RID: 12837 RVA: 0x000215AE File Offset: 0x0001F7AE
	public void DebugDumpLoadingAssets()
	{
		this.KuroResourceManager.DebugDumpLoadingAssets();
	}

	// Token: 0x040004F1 RID: 1265
	public const int CHECK_STREAMING_INTERVAL = 100;

	// Token: 0x040004F2 RID: 1266
	public const int CHECK_RENDERASSETS_INTERVAL = 100;

	// Token: 0x040004F3 RID: 1267
	public const float STREAMING_SOURCE_RADIUS = 7000f;

	// Token: 0x040004F4 RID: 1268
	public const float RENDER_ASSETS_RADIUS = 7000f;

	// Token: 0x040004F5 RID: 1269
	public const int RENDER_ASSETS_TIMEOUT = 40000;

	// Token: 0x040004F6 RID: 1270
	public const int WAIT_RENDER_ASSET_DURATION = 42;

	// Token: 0x040004F7 RID: 1271
	public const int SYNC_LOAD_PRIORITY = 1073741823;

	// Token: 0x040004F8 RID: 1272
	public const int ASYNC_LOAD_TIMEOUT_MS = 60000;

	// Token: 0x040004F9 RID: 1273
	private UKuroResourceManager KuroResourceManager;

	// Token: 0x040004FA RID: 1274
	private readonly Dictionary<int, ResourceSystem.LoadCallbackTask> LoadingTaskMap = new Dictionary<int, ResourceSystem.LoadCallbackTask>();

	// Token: 0x040004FB RID: 1275
	private readonly PriorityQueue<ResourceSystem.LoadCallbackTask> DelayTaskQueue = new PriorityQueue<ResourceSystem.LoadCallbackTask>(delegate(ResourceSystem.LoadCallbackTask a, ResourceSystem.LoadCallbackTask b)
	{
		if (a.Priority != b.Priority)
		{
			return b.Priority - a.Priority;
		}
		return a.Id - b.Id;
	});

	// Token: 0x040004FC RID: 1276
	private readonly HashSet<int> CancelIdSet = new HashSet<int>();

	// Token: 0x040004FD RID: 1277
	private readonly TimeLimit TaskTimeLimit = new TimeLimit(null);

	// Token: 0x040004FE RID: 1278
	private bool Updating;

	// Token: 0x040004FF RID: 1279
	private readonly Dictionary<string, UObject> TypeCache = new Dictionary<string, UObject>();

	// Token: 0x04000500 RID: 1280
	private readonly Stat StatLoad = Stat.Create("RS.Load", "", "");

	// Token: 0x04000501 RID: 1281
	private readonly Stat StatLoadAsync = Stat.Create("RS.LoadASync", "", "");

	// Token: 0x04000502 RID: 1282
	private readonly Stat StatLoadAsyncCallback = Stat.Create("RS.LoadAsyncCallback", "", "");

	// Token: 0x04000503 RID: 1283
	private readonly Stat StatUpdateDelayCallback = Stat.Create("RS.UpdateDelayCallback", "", "");

	// Token: 0x04000504 RID: 1284
	private int HandleId;

	// Token: 0x04000505 RID: 1285
	private bool InternalIsAsyncLoadingThreadEnabled;

	// Token: 0x04000506 RID: 1286
	public const int InvalidId = -1;

	// Token: 0x04000507 RID: 1287
	private bool IsOpenMemoryTag = true;

	// Token: 0x020071B9 RID: 29113
	[NullableContext(0)]
	public enum EResourceLoadPriority
	{
		// Token: 0x0402796A RID: 162154
		Default = 100,
		// Token: 0x0402796B RID: 162155
		Preload,
		// Token: 0x0402796C RID: 162156
		Ui,
		// Token: 0x0402796D RID: 162157
		BattleUi,
		// Token: 0x0402796E RID: 162158
		Catapult,
		// Token: 0x0402796F RID: 162159
		BeginSkill,
		// Token: 0x04027970 RID: 162160
		Max
	}

	// Token: 0x020071BA RID: 29114
	[NullableContext(0)]
	public enum EAsyncLoadResult
	{
		// Token: 0x04027972 RID: 162162
		Error = -1,
		// Token: 0x04027973 RID: 162163
		Loading,
		// Token: 0x04027974 RID: 162164
		Completed
	}

	// Token: 0x020071BB RID: 29115
	[Nullable(0)]
	public class LoadCallbackTask
	{
		// Token: 0x1700A76F RID: 42863
		// (get) Token: 0x060467E6 RID: 288742 RVA: 0x012ADDAA File Offset: 0x012ABFAA
		// (set) Token: 0x060467E7 RID: 288743 RVA: 0x012ADDB2 File Offset: 0x012ABFB2
		public int Id { get; private set; }

		// Token: 0x1700A770 RID: 42864
		// (get) Token: 0x060467E8 RID: 288744 RVA: 0x012ADDBB File Offset: 0x012ABFBB
		// (set) Token: 0x060467E9 RID: 288745 RVA: 0x012ADDC3 File Offset: 0x012ABFC3
		public int Priority { get; private set; }

		// Token: 0x1700A771 RID: 42865
		// (get) Token: 0x060467EA RID: 288746 RVA: 0x012ADDCC File Offset: 0x012ABFCC
		// (set) Token: 0x060467EB RID: 288747 RVA: 0x012ADDD4 File Offset: 0x012ABFD4
		[Nullable(2)]
		public TimerHandle TimeoutTimer { [NullableContext(2)] get; [NullableContext(2)] private set; }

		// Token: 0x1700A772 RID: 42866
		// (get) Token: 0x060467EC RID: 288748 RVA: 0x012ADDDD File Offset: 0x012ABFDD
		// (set) Token: 0x060467ED RID: 288749 RVA: 0x012ADDE5 File Offset: 0x012ABFE5
		public Action Callback { get; private set; }

		// Token: 0x060467EE RID: 288750 RVA: 0x012ADDEE File Offset: 0x012ABFEE
		public LoadCallbackTask(int id, int priority, [Nullable(2)] TimerHandle timeoutTimer, Action callback)
		{
			this.Id = id;
			this.Priority = priority;
			this.TimeoutTimer = timeoutTimer;
			this.Callback = callback;
		}
	}
}
