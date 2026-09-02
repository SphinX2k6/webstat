using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003440 RID: 13376
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LguiResourceManager : Singleton<LguiResourceManager>
{
	// Token: 0x0601C0C0 RID: 114880 RVA: 0x0085C7C0 File Offset: 0x0085A9C0
	public int LoadPrefabByResourceId(string resourceId, [Nullable(2)] UUIItem parent = null, [Nullable(new byte[]
	{
		2,
		2,
		1
	})] Action<AActor, string, ELguiLoadResultType> callback = null, string memoryTag = "js_undefined")
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		return this.LoadPrefab(resourcePath, parent, callback, memoryTag);
	}

	// Token: 0x0601C0C1 RID: 114881 RVA: 0x0085C7E4 File Offset: 0x0085A9E4
	public int LoadPrefab(string path, [Nullable(2)] UUIItem parent = null, [Nullable(new byte[]
	{
		2,
		2,
		1
	})] Action<AActor, string, ELguiLoadResultType> callback = null, string memoryTag = "js_undefined")
	{
		string realMemoryTag = Singleton<LguiUtil>.Instance.GetRootActorMemoryTag(parent, memoryTag);
		bool isCompleted = false;
		int handleId = this.InvalidId;
		handleId = Singleton<ResourceSystem>.Instance.LoadAsync<UPrefabAsset>(path, delegate([Nullable(2)] UPrefabAsset result, string loadedPath)
		{
			isCompleted = true;
			if (handleId != this.InvalidId)
			{
				this.LguiResourceLoadMap.Remove(handleId);
			}
			if (result == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LguiUtil;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "资源加载失败,资源不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action<AActor, string, ELguiLoadResultType> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(null, path, ELguiLoadResultType.Fail);
				return;
			}
			else
			{
				if (GlobalData.World != null)
				{
					AActor aactor = ULGUIBPLibrary.LoadPrefabWithAsset(GlobalData.World, result, parent);
					LguiUtil.SetRootActorMemoryTag(aactor, realMemoryTag);
					if (callback != null)
					{
						callback(aactor, path, ELguiLoadResultType.Success);
					}
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LguiUtil;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "资源加载失败,Game.World为空";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("path", path);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				Action<AActor, string, ELguiLoadResultType> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(null, path, ELguiLoadResultType.Fail);
				return;
			}
		}, 100, realMemoryTag);
		if (!isCompleted && handleId != this.InvalidId)
		{
			this.LguiResourceLoadMap[handleId] = path;
		}
		return handleId;
	}

	// Token: 0x0601C0C2 RID: 114882 RVA: 0x0085C89C File Offset: 0x0085AA9C
	public void CancelLoadPrefab(int handleId)
	{
		if (this.InvalidId == handleId)
		{
			return;
		}
		string text;
		if (!this.LguiResourceLoadMap.TryGetValue(handleId, out text))
		{
			return;
		}
		this.LguiResourceLoadMap.Remove(handleId);
		Singleton<ResourceSystem>.Instance.CancelAsyncLoad(handleId);
	}

	// Token: 0x0400E28C RID: 57996
	private readonly Dictionary<int, string> LguiResourceLoadMap = new Dictionary<int, string>();

	// Token: 0x0400E28D RID: 57997
	public readonly int InvalidId = -1;
}
