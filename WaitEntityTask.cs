using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

// Token: 0x020034A7 RID: 13479
[NullableContext(1)]
[Nullable(0)]
public class WaitEntityTask
{
	// Token: 0x0601C6C9 RID: 116425 RVA: 0x00884828 File Offset: 0x00882A28
	public unsafe void AddEntities(long creatureDataId, Action<bool?> callBack, int timeout = 60000, bool checkExist = true, bool waitUntil = false)
	{
		this.AddCustomEntity(creatureDataId);
		this.LoadResultSet.Add(creatureDataId);
		this.CallBack = callBack;
		if (timeout >= 0)
		{
			this.TimeoutId = TimerSystem.Instance.Delay(delegate(float id)
			{
				if (waitUntil)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.LFJW;
					string message = "等待实体超时，强行等待";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id类型", "CreatureDataId");
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("实体", creatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", this.Reason);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Entity;
				ELogAuthor author2 = ELogAuthor.LFJW;
				string message2 = "等待实体超时，强行回调";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id类型", "CreatureDataId");
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("实体列表", creatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Reason", this.Reason);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				this.DoCallback(null);
			}, (float)timeout, null, null, true, 1f);
		}
		else
		{
			this.TimeoutId = null;
		}
		this.FilterEntity(creatureDataId, checkExist);
		if (this.LoadCustomEntitySet != null)
		{
			foreach (long id2 in this.LoadCustomEntitySet)
			{
				this.FilterEntity(id2, checkExist);
			}
			this.LoadCustomEntitySet = null;
		}
		if (this.LoadResultSet.Count > 0)
		{
			return;
		}
		this.DoCallback(new bool?(true));
	}

	// Token: 0x0601C6CA RID: 116426 RVA: 0x0088492C File Offset: 0x00882B2C
	public unsafe void AddEntities(IList<long> creatureDataIds, Action<bool?> callBack, int timeout = 60000, bool checkExist = true, bool waitUntil = false)
	{
		foreach (long num in creatureDataIds)
		{
			this.AddCustomEntity(num);
			this.LoadResultSet.Add(num);
		}
		this.CallBack = callBack;
		if (timeout >= 0)
		{
			this.TimeoutId = TimerSystem.Instance.Delay(delegate(float id)
			{
				if (waitUntil)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.LFJW;
					string message = "等待实体超时，强行等待";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id类型", "CreatureDataId");
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("实体列表", string.Join<long>(",", creatureDataIds));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", this.Reason);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Entity;
				ELogAuthor author2 = ELogAuthor.LFJW;
				string message2 = "等待实体超时，强行回调";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id类型", "CreatureDataId");
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("实体列表", string.Join<long>(",", creatureDataIds));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Reason", this.Reason);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				this.DoCallback(null);
			}, (float)timeout, null, null, true, 1f);
		}
		else
		{
			this.TimeoutId = null;
		}
		foreach (long id3 in creatureDataIds)
		{
			this.FilterEntity(id3, checkExist);
		}
		if (this.LoadCustomEntitySet != null)
		{
			foreach (long id2 in this.LoadCustomEntitySet)
			{
				this.FilterEntity(id2, checkExist);
			}
			this.LoadCustomEntitySet = null;
		}
		if (this.LoadResultSet.Count > 0)
		{
			return;
		}
		this.DoCallback(new bool?(true));
	}

	// Token: 0x0601C6CB RID: 116427 RVA: 0x00884A8C File Offset: 0x00882C8C
	public unsafe void AddEntitiesWithPbDataId(int pbDataId, Action<bool?> callBack, int timeout = 60000, bool checkExist = true, bool waitUntil = false)
	{
		this.LoadResultSet.Add((long)pbDataId);
		this.CallBack = callBack;
		if (timeout >= 0)
		{
			this.TimeoutId = TimerSystem.Instance.Delay(delegate(float _)
			{
				if (waitUntil)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.LFJW;
					string message = "等待实体超时，强行等待";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id类型", "PbDataId");
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("实体", pbDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", this.Reason);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Entity;
				ELogAuthor author2 = ELogAuthor.LFJW;
				string message2 = "等待实体超时，强行回调";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id类型", "PbDataId");
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("实体", pbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Reason", this.Reason);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				this.DoCallback(new bool?(false));
			}, (float)timeout, null, null, true, 1f);
		}
		else
		{
			this.TimeoutId = null;
		}
		this.FilterEntity((long)pbDataId, checkExist);
		if (this.LoadResultSet.Count > 0)
		{
			return;
		}
		this.DoCallback(new bool?(true));
	}

	// Token: 0x0601C6CC RID: 116428 RVA: 0x00884B2C File Offset: 0x00882D2C
	public unsafe void AddEntitiesWithPbDataId(IList<int> pbDataIds, Action<bool?> callBack, int timeout = 60000, bool checkExist = true, bool waitUntil = false)
	{
		foreach (int num in pbDataIds)
		{
			this.LoadResultSet.Add((long)num);
		}
		this.CallBack = callBack;
		if (timeout >= 0)
		{
			this.TimeoutId = TimerSystem.Instance.Delay(delegate(float _)
			{
				if (waitUntil)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.LFJW;
					string message = "等待实体超时，强行等待";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id类型", "PbDataId");
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("实体列表", JsonSerializer.Serialize<IList<int>>(pbDataIds, null));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", this.Reason);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Entity;
				ELogAuthor author2 = ELogAuthor.LFJW;
				string message2 = "等待实体超时，强行回调";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id类型", "PbDataId");
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("实体列表", JsonSerializer.Serialize<IList<int>>(pbDataIds, null));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Reason", this.Reason);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				this.DoCallback(new bool?(false));
			}, (float)timeout, null, null, true, 1f);
		}
		else
		{
			this.TimeoutId = null;
		}
		foreach (int num2 in pbDataIds)
		{
			this.FilterEntity((long)num2, checkExist);
		}
		if (this.LoadResultSet.Count > 0)
		{
			return;
		}
		this.DoCallback(new bool?(true));
	}

	// Token: 0x0601C6CD RID: 116429 RVA: 0x00884C30 File Offset: 0x00882E30
	private void FilterEntity(long id, bool checkExist = true)
	{
		EntityHandle entityHandle;
		if (this.WaitType.GetValueOrDefault() == EWaitType.PbDataId)
		{
			entityHandle = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId((int)id);
		}
		else
		{
			entityHandle = ModelBase<CreatureModel>.Instance.GetEntity(id);
		}
		if (entityHandle == null && checkExist)
		{
			this.LoadResultSet.Remove(id);
			return;
		}
		if (entityHandle != null)
		{
			if (entityHandle.IsInit)
			{
				this.LoadResultSet.Remove(id);
				return;
			}
			if (entityHandle.Priority < ResourceSystem.EResourceLoadPriority.Preload)
			{
				entityHandle.Priority = ResourceSystem.EResourceLoadPriority.Preload;
			}
			ControllerBase<CharacterController>.Instance.SortItem(entityHandle);
		}
	}

	// Token: 0x0601C6CE RID: 116430 RVA: 0x00884CB4 File Offset: 0x00882EB4
	public void OnAddEntity(long creatureDataId, int pbDataId)
	{
		EWaitType? waitType = this.WaitType;
		EWaitType ewaitType = EWaitType.CreatureDataId;
		if (waitType.GetValueOrDefault() == ewaitType & waitType != null)
		{
			this.LoadResultSet.Remove(creatureDataId);
		}
		else if (this.WaitType.GetValueOrDefault() == EWaitType.PbDataId)
		{
			this.LoadResultSet.Remove((long)pbDataId);
		}
		if (this.LoadResultSet.Count > 0)
		{
			return;
		}
		this.DoCallback(new bool?(!this.HasRemoveEntity));
	}

	// Token: 0x0601C6CF RID: 116431 RVA: 0x00884D2C File Offset: 0x00882F2C
	public void OnRemoveEntity(long creatureDataId, int pbDataId)
	{
		EWaitType? waitType = this.WaitType;
		EWaitType ewaitType = EWaitType.CreatureDataId;
		if (waitType.GetValueOrDefault() == ewaitType & waitType != null)
		{
			if (!this.LoadResultSet.Contains(creatureDataId))
			{
				return;
			}
			this.LoadResultSet.Remove(creatureDataId);
		}
		else if (this.WaitType.GetValueOrDefault() == EWaitType.PbDataId)
		{
			if (!this.LoadResultSet.Contains((long)pbDataId))
			{
				return;
			}
			this.LoadResultSet.Remove((long)pbDataId);
		}
		this.HasRemoveEntity = true;
		if (this.LoadResultSet.Count > 0)
		{
			return;
		}
		this.DoCallback(new bool?(false));
	}

	// Token: 0x0601C6D0 RID: 116432 RVA: 0x00884DC4 File Offset: 0x00882FC4
	private void DoCallback(bool? result)
	{
		if (this.TimeoutId != null)
		{
			TimerSystem.Instance.Remove(this.TimeoutId);
			this.TimeoutId = null;
		}
		this.LoadResultSet.Clear();
		ControllerBase<WaitEntityTaskController>.Instance.RemoveTask(this.TaskId);
		Action<bool?> callBack = this.CallBack;
		if (callBack == null)
		{
			return;
		}
		callBack(result);
	}

	// Token: 0x0601C6D1 RID: 116433 RVA: 0x00884E20 File Offset: 0x00883020
	[return: Nullable(2)]
	public unsafe static WaitEntityTask Create(string reason, long creatureDataId, Action<bool?> callBack, int timeout = 60000, bool checkExist = true, bool waitUntil = false)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.LFJW, "WaitEntityTask的Reason不能使用undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (reason.Length < 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "WaitEntityTask的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		WaitEntityTask waitEntityTask = new WaitEntityTask();
		waitEntityTask.WaitType = new EWaitType?(EWaitType.CreatureDataId);
		waitEntityTask.Reason = reason;
		waitEntityTask.TaskId = ControllerBase<WaitEntityTaskController>.Instance.AddTask(waitEntityTask);
		waitEntityTask.AddEntities(creatureDataId, callBack, timeout, checkExist, waitUntil);
		return waitEntityTask;
	}

	// Token: 0x0601C6D2 RID: 116434 RVA: 0x00884EEC File Offset: 0x008830EC
	[return: Nullable(2)]
	public unsafe static WaitEntityTask Create(string reason, IList<long> creatureDataIds, Action<bool?> callBack, int timeout = 60000, bool checkExist = true, bool waitUntil = false)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.LFJW, "WaitEntityTask的Reason不能使用undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (reason.Length < 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "WaitEntityTask的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		WaitEntityTask waitEntityTask = new WaitEntityTask();
		waitEntityTask.WaitType = new EWaitType?(EWaitType.CreatureDataId);
		waitEntityTask.Reason = reason;
		waitEntityTask.TaskId = ControllerBase<WaitEntityTaskController>.Instance.AddTask(waitEntityTask);
		waitEntityTask.AddEntities(creatureDataIds, callBack, timeout, checkExist, waitUntil);
		return waitEntityTask;
	}

	// Token: 0x0601C6D3 RID: 116435 RVA: 0x00884FB8 File Offset: 0x008831B8
	[return: Nullable(2)]
	public unsafe static WaitEntityTask CreateWithPbDataId(string reason, int pbDataId, Action<bool?> callBack, int timeout = 60000, bool checkExist = true, bool waitUntil = false)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.LFJW, "WaitEntityTask的Reason不能使用undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (reason.Length < 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "WaitEntityTask的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		WaitEntityTask waitEntityTask = new WaitEntityTask();
		waitEntityTask.WaitType = new EWaitType?(EWaitType.PbDataId);
		waitEntityTask.Reason = reason;
		waitEntityTask.TaskId = ControllerBase<WaitEntityTaskController>.Instance.AddTask(waitEntityTask);
		waitEntityTask.AddEntitiesWithPbDataId(pbDataId, callBack, timeout, checkExist, waitUntil);
		return waitEntityTask;
	}

	// Token: 0x0601C6D4 RID: 116436 RVA: 0x00885084 File Offset: 0x00883284
	[return: Nullable(2)]
	public unsafe static WaitEntityTask CreateWithPbDataId(string reason, IList<int> pbDataIds, Action<bool?> callBack, int timeout = 60000, bool checkExist = true, bool waitUntil = false)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.LFJW, "WaitEntityTask的Reason不能使用undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (reason.Length < 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "WaitEntityTask的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		WaitEntityTask waitEntityTask = new WaitEntityTask();
		waitEntityTask.WaitType = new EWaitType?(EWaitType.PbDataId);
		waitEntityTask.Reason = reason;
		waitEntityTask.TaskId = ControllerBase<WaitEntityTaskController>.Instance.AddTask(waitEntityTask);
		waitEntityTask.AddEntitiesWithPbDataId(pbDataIds, callBack, timeout, checkExist, waitUntil);
		return waitEntityTask;
	}

	// Token: 0x0601C6D5 RID: 116437 RVA: 0x00885150 File Offset: 0x00883350
	public void Cancel()
	{
		if (this.TimeoutId != null)
		{
			TimerSystem.Instance.Remove(this.TimeoutId);
			this.TimeoutId = null;
		}
		this.LoadResultSet.Clear();
		ControllerBase<WaitEntityTaskController>.Instance.RemoveTask(this.TaskId);
	}

	// Token: 0x0601C6D6 RID: 116438 RVA: 0x00885190 File Offset: 0x00883390
	private void AddCustomEntity(long entityId)
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
		if (entity != null)
		{
			WorldEntity entity2 = entity.Entity;
			bool flag;
			if (entity2 == null)
			{
				flag = false;
			}
			else
			{
				BaseActorComponent component = entity2.GetComponent<BaseActorComponent>();
				flag = ((component != null) ? new bool?(!component.IsAutonomousProxy) : null).GetValueOrDefault();
			}
			if (!flag)
			{
				WorldEntity entity3 = entity.Entity;
				IList<long> list;
				if (entity3 == null)
				{
					list = null;
				}
				else
				{
					CreatureDataComponent component2 = entity3.GetComponent<CreatureDataComponent>();
					list = ((component2 != null) ? component2.CustomServerEntityIds : null);
				}
				IList<long> list2 = list;
				if (list2 != null)
				{
					if (this.LoadCustomEntitySet == null)
					{
						this.LoadCustomEntitySet = new HashSet<long>();
					}
					foreach (long item in list2)
					{
						this.LoadCustomEntitySet.Add(item);
						this.LoadResultSet.Add(item);
					}
				}
				WorldEntity entity4 = entity.Entity;
				long? num;
				if (entity4 == null)
				{
					num = null;
				}
				else
				{
					CreatureDataComponent component3 = entity4.GetComponent<CreatureDataComponent>();
					num = ((component3 != null) ? new long?(component3.GetSummonerId()) : null);
				}
				long? num2 = num;
				if (num2 != null && num2.Value != 0L)
				{
					if (this.LoadCustomEntitySet == null)
					{
						this.LoadCustomEntitySet = new HashSet<long>();
					}
					this.LoadCustomEntitySet.Add(num2.Value);
					this.LoadResultSet.Add(num2.Value);
				}
				return;
			}
		}
	}

	// Token: 0x0400E4B6 RID: 58550
	public const int REASON_LENGTH_LIMIT = 4;

	// Token: 0x0400E4B7 RID: 58551
	public const int WAIT_TIME = 60000;

	// Token: 0x0400E4B8 RID: 58552
	[Nullable(2)]
	private HashSet<long> LoadCustomEntitySet;

	// Token: 0x0400E4B9 RID: 58553
	private readonly HashSet<long> LoadResultSet = new HashSet<long>();

	// Token: 0x0400E4BA RID: 58554
	public EWaitType? WaitType;

	// Token: 0x0400E4BB RID: 58555
	[Nullable(2)]
	private TimerHandle TimeoutId;

	// Token: 0x0400E4BC RID: 58556
	private int TaskId;

	// Token: 0x0400E4BD RID: 58557
	private bool HasRemoveEntity;

	// Token: 0x0400E4BE RID: 58558
	[Nullable(2)]
	public string Reason;

	// Token: 0x0400E4BF RID: 58559
	[Nullable(2)]
	private Action<bool?> CallBack;
}
