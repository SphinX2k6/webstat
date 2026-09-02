using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.ServerStorage.Container;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.ServerStorage
{
	// Token: 0x0200472A RID: 18218
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ServerStorageModel : ModelBase<ServerStorageModel>
	{
		// Token: 0x0602F4E3 RID: 193763 RVA: 0x00B37808 File Offset: 0x00B35A08
		[NullableContext(2)]
		private ServerStorageEntryBase CreateContainer(EClientStorageSystemIdType key)
		{
			ServerStorageEntryBase result;
			if (this.Cache.TryGetValue(key, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "Container is already created";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return result;
			}
			Func<EClientStorageSystemIdType, ServerStorageEntryBase> func;
			if (!ServerStorageDefine.ServerStorageEntryRegistry.TryGetValue(key, out func))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.ServerStorage;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "Container ctor not found";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("key", key);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			ServerStorageEntryBase serverStorageEntryBase = func(key);
			this.Cache[key] = serverStorageEntryBase;
			return serverStorageEntryBase;
		}

		// Token: 0x0602F4E4 RID: 193764 RVA: 0x00B378AC File Offset: 0x00B35AAC
		public void InitStorageInfo(RepeatedField<ClientStorageInfo> storageInfoList)
		{
			this.Cache.Clear();
			foreach (ClientStorageInfo clientStorageInfo in storageInfoList)
			{
				ServerStorageEntryBase serverStorageEntryBase = this.Get((EClientStorageSystemIdType)clientStorageInfo.SystemId);
				if (serverStorageEntryBase == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.ServerStorage;
					ELogAuthor author = ELogAuthor.BB;
					string message = "Container is undefined";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", clientStorageInfo.SystemId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					serverStorageEntryBase.Serialize(clientStorageInfo);
					this.Cache[(EClientStorageSystemIdType)clientStorageInfo.SystemId] = serverStorageEntryBase;
				}
			}
		}

		// Token: 0x0602F4E5 RID: 193765 RVA: 0x00B37958 File Offset: 0x00B35B58
		[NullableContext(2)]
		public ServerStorageEntryBase Get(EClientStorageSystemIdType key)
		{
			ServerStorageEntryBase result;
			if (this.Cache.TryGetValue(key, out result))
			{
				return result;
			}
			return this.CreateContainer(key);
		}

		// Token: 0x0602F4E6 RID: 193766 RVA: 0x00B37980 File Offset: 0x00B35B80
		public void MarkDirty(EClientStorageSystemIdType key)
		{
			this.DirtyCache.Add(key);
			if (this.DelayTimerHandle != null)
			{
				return;
			}
			this.DelayTimerHandle = TimerSystem.RealTimeInstance.Delay(new TTimerAction(this.DelaySaveDirtyCache), 3000f, null, null, true, 1f);
		}

		// Token: 0x0602F4E7 RID: 193767 RVA: 0x00B379CC File Offset: 0x00B35BCC
		protected override bool OnClear()
		{
			if (this.DelayTimerHandle == null)
			{
				return true;
			}
			TimerSystem.RealTimeInstance.Remove(this.DelayTimerHandle);
			this.SaveDirtyCache();
			this.DelayTimerHandle = null;
			return true;
		}

		// Token: 0x0602F4E8 RID: 193768 RVA: 0x00B379F8 File Offset: 0x00B35BF8
		private void SaveDirtyCache()
		{
			if (this.DirtyCache.Count == 0)
			{
				return;
			}
			StorageInfoUpdateRequest storageInfoUpdateRequest = StorageInfoUpdateRequest.Create();
			foreach (EClientStorageSystemIdType eclientStorageSystemIdType in this.DirtyCache)
			{
				ClientStorageInfo clientStorageInfo = ModelBase<ServerStorageModel>.Instance.Get(eclientStorageSystemIdType).Deserialize();
				if (clientStorageInfo == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.ServerStorage;
					ELogAuthor author = ELogAuthor.BB;
					string message = "Deserialize Info is undefined";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", eclientStorageSystemIdType);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					storageInfoUpdateRequest.Infos.Add(clientStorageInfo);
				}
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.ServerStorage;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "DelaySaveDirtyCache";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("storageInfo", storageInfoUpdateRequest.Infos);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			ControllerBase<ServerStorageController>.Instance.SendStorageInfoUpdateRequest(storageInfoUpdateRequest);
			this.DirtyCache.Clear();
		}

		// Token: 0x0602F4E9 RID: 193769 RVA: 0x00B37AF4 File Offset: 0x00B35CF4
		private void DelaySaveDirtyCache(float delta)
		{
			this.SaveDirtyCache();
			this.DelayTimerHandle = null;
		}

		// Token: 0x0401AF17 RID: 110359
		private readonly Dictionary<EClientStorageSystemIdType, ServerStorageEntryBase> Cache = new Dictionary<EClientStorageSystemIdType, ServerStorageEntryBase>();

		// Token: 0x0401AF18 RID: 110360
		private readonly HashSet<EClientStorageSystemIdType> DirtyCache = new HashSet<EClientStorageSystemIdType>();

		// Token: 0x0401AF19 RID: 110361
		[Nullable(2)]
		private TimerHandle DelayTimerHandle;
	}
}
