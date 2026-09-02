using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;
using UnrealEngine;
using UnrealEngine.Interface;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044A5 RID: 17573
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherResourceLib : Singleton<LauncherResourceLib>
	{
		// Token: 0x0602E554 RID: 189780 RVA: 0x00AE0C30 File Offset: 0x00ADEE30
		public FName GetDynamicFName(string key)
		{
			FName fname;
			if (!this.CacheNameMap.TryGetValue(key, out fname))
			{
				fname = new FName(key);
				this.CacheNameMap[key] = fname;
			}
			return fname;
		}

		// Token: 0x0602E555 RID: 189781 RVA: 0x00AE0C64 File Offset: 0x00ADEE64
		public void Initialize()
		{
			if (this.IsInit)
			{
				return;
			}
			this.IsInit = true;
			this.IsOpenMemoryTag = !KuroApplication.IsBuildShipping();
			this.CallbackMap = new Dictionary<int, Action>();
			this.ResourceManager = new UKuroResourceManager();
			this.ResourceManager.LoadResourceDelegate.Bind(new Action<int>(this.OnLoadComplete));
		}

		// Token: 0x0602E556 RID: 189782 RVA: 0x00AE0CC4 File Offset: 0x00ADEEC4
		[return: Nullable(2)]
		public T Load<[Nullable(0)] T>(string path, int priority = 0, string memoryTag = "js_call_launch") where T : UObject, IUnrealUObject
		{
			T result = default(T);
			if (this.ResourceManager == null || !this.ResourceManager.IsValid())
			{
				Singleton<LauncherLog>.Instance.Error("LauncherResourceLib尚未初始化，就使用了Load接口！", default(ReadOnlySpan<ValueTuple<string, object>>));
				return result;
			}
			if (!this.CheckPath(path))
			{
				return result;
			}
			int globalId = this.GlobalId;
			this.GlobalId = globalId + 1;
			int num = globalId;
			int num2;
			if (this.IsOpenMemoryTag)
			{
				FName dynamicFName = this.GetDynamicFName(memoryTag);
				num2 = this.ResourceManager.LoadAsyncWithIdAndTag(path, num, priority, dynamicFName);
			}
			else
			{
				num2 = this.ResourceManager.LoadAsyncWithId(path, num, priority);
			}
			if (num2 == -1)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "LauncherResourceLib.Load()传入的handleId重复！";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handleId", num);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return result;
			}
			UClassStackOnlyPtr uclassStackOnlyPtr = IUnrealUObject.StaticClass();
			if (!uclassStackOnlyPtr.IsValid())
			{
				Singleton<LauncherLog>.Instance.Error("LauncherResourceLib.Load()传入的目标类型为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return result;
			}
			if (!uclassStackOnlyPtr.IsValid())
			{
				Singleton<LauncherLog>.Instance.Error("LauncherResourceLib.Load()传入的目标类型无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return result;
			}
			if (num2 == 1)
			{
				return this.GetAsset<T>(path, num);
			}
			if (!this.ResourceManager.WaitComplete(num, 0f))
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "LauncherResourceLib.Load()加载资源失败！";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Path", path);
				instance2.Error(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return result;
			}
			return this.GetAsset<T>(path, num);
		}

		// Token: 0x0602E557 RID: 189783 RVA: 0x00AE0E30 File Offset: 0x00ADF030
		public int LoadAsync<[Nullable(0)] T>([Nullable(2)] string path, [Nullable(new byte[]
		{
			1,
			2,
			1
		})] Action<T, string> callback, int priority = 0, string memoryTag = "js_call_launch") where T : UObject, IUnrealUObject
		{
			LauncherResourceLib.<>c__DisplayClass9_0<T> CS$<>8__locals1 = new LauncherResourceLib.<>c__DisplayClass9_0<T>();
			CS$<>8__locals1.callback = callback;
			CS$<>8__locals1.path = path;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.id = -1;
			if (this.ResourceManager == null || !this.ResourceManager.IsValid())
			{
				Singleton<LauncherLog>.Instance.Error("LauncherResourceLib尚未初始化，就使用了Load接口！", default(ReadOnlySpan<ValueTuple<string, object>>));
				return CS$<>8__locals1.id;
			}
			if (!this.CheckPath(CS$<>8__locals1.path))
			{
				return CS$<>8__locals1.id;
			}
			LauncherResourceLib.<>c__DisplayClass9_0<T> CS$<>8__locals2 = CS$<>8__locals1;
			int globalId = this.GlobalId;
			this.GlobalId = globalId + 1;
			CS$<>8__locals2.id = globalId;
			int num;
			if (this.IsOpenMemoryTag)
			{
				FName dynamicFName = this.GetDynamicFName(memoryTag);
				num = this.ResourceManager.LoadAsyncWithIdAndTag(CS$<>8__locals1.path, CS$<>8__locals1.id, priority, dynamicFName);
			}
			else
			{
				num = this.ResourceManager.LoadAsyncWithId(CS$<>8__locals1.path, CS$<>8__locals1.id, priority);
			}
			if (num == 1)
			{
				CS$<>8__locals1.<LoadAsync>g__Cb|1();
			}
			else
			{
				this.CallbackMap[CS$<>8__locals1.id] = new Action(CS$<>8__locals1.<LoadAsync>g__Cb|1);
			}
			return CS$<>8__locals1.id;
		}

		// Token: 0x0602E558 RID: 189784 RVA: 0x00AE0F38 File Offset: 0x00ADF138
		[return: Nullable(2)]
		private unsafe T GetAsset<[Nullable(0)] T>(string path, int handleId) where T : UObject, IUnrealUObject
		{
			UObject asset = this.ResourceManager.GetAsset(handleId);
			this.ResourceManager.Release(handleId);
			UClassStackOnlyPtr uclassStackOnlyPtr = IUnrealUObject.StaticClass();
			if (!uclassStackOnlyPtr.IsValid())
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "LauncherResourceLib.Load()加载的asset的type无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return default(T);
			}
			if (asset == null)
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "LauncherResourceLib.Load()加载到的资源为空";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("path", path);
				instance2.Error(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return default(T);
			}
			if (!asset.IsValid())
			{
				LauncherLog instance3 = Singleton<LauncherLog>.Instance;
				string message3 = "LauncherResourceLib.Load()加载到的资源无效";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("path", path);
				instance3.Error(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return default(T);
			}
			if (!(asset is T))
			{
				LauncherLog instance4 = Singleton<LauncherLog>.Instance;
				string message4 = "LauncherResourceLib.Load()加载到的资源与传入类型不匹配";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", path);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("assetType", asset.GetClass().GetName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("desireType", uclassStackOnlyPtr.GetName());
				instance4.Error(message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return default(T);
			}
			return asset as T;
		}

		// Token: 0x0602E559 RID: 189785 RVA: 0x00AE10A4 File Offset: 0x00ADF2A4
		[NullableContext(2)]
		private bool CheckPath(string path)
		{
			if (path == null)
			{
				Singleton<LauncherLog>.Instance.Error("路径为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (path.Length == 0)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "路径长度为零";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("路径", path);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (!path.StartsWith("/"))
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "传入资源路径不符合规范";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("路径", path);
				instance2.Error(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			return true;
		}

		// Token: 0x0602E55A RID: 189786 RVA: 0x00AE1130 File Offset: 0x00ADF330
		private void OnLoadComplete(int handleId)
		{
			Action action;
			if (this.CallbackMap != null && this.CallbackMap.TryGetValue(handleId, out action))
			{
				this.CallbackMap.Remove(handleId);
				action();
			}
		}

		// Token: 0x0401A51E RID: 107806
		private int GlobalId;

		// Token: 0x0401A51F RID: 107807
		[Nullable(2)]
		private UKuroResourceManager ResourceManager;

		// Token: 0x0401A520 RID: 107808
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, Action> CallbackMap;

		// Token: 0x0401A521 RID: 107809
		private bool IsInit;

		// Token: 0x0401A522 RID: 107810
		private bool IsOpenMemoryTag = true;

		// Token: 0x0401A523 RID: 107811
		private readonly Dictionary<string, FName> CacheNameMap = new Dictionary<string, FName>();
	}
}
