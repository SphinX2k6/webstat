using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.World.Define
{
	// Token: 0x020046E0 RID: 18144
	[NullableContext(1)]
	[Nullable(0)]
	public class WaitEntityPreloadTask
	{
		// Token: 0x0602F30C RID: 193292 RVA: 0x00B2E2C7 File Offset: 0x00B2C4C7
		public WaitEntityPreloadTask(EntityHandle handle, Action<EWaitEntityPreloadResult> callBack)
		{
			this.Handle = handle;
			this.CallBack = callBack;
		}

		// Token: 0x0602F30D RID: 193293 RVA: 0x00B2E300 File Offset: 0x00B2C500
		public unsafe void Init()
		{
			this.CreatureData = this.Handle.Entity.GetComponent<CreatureDataComponent>();
			Singleton<EventSystem>.Instance.Add<EntityHandle>(EEventName.PreloadEntityFinished, new Action<EntityHandle>(this.OnPreloadEntityFinished));
			Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			TimerSystem.Instance.Delay(delegate(float _)
			{
				EntityHandle handle = this.Handle;
				if (handle != null && !handle.Valid)
				{
					return;
				}
				if ((this.Result & EWaitEntityPreloadResult.Finished) != EWaitEntityPreloadResult.None)
				{
					return;
				}
				this.Result |= EWaitEntityPreloadResult.Timeout;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "等待实体超时";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureData.GetCreatureDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("依赖的实体", this.WaitEntityString);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("没有预加载的实体", this.GetDoNotPreloadEntityString());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.DoCallback();
			}, 60000f, null, null, true, 1f);
			this.FilterEntity();
			if (this.Count != 0)
			{
				return;
			}
			this.DoCallback();
		}

		// Token: 0x17008141 RID: 33089
		// (get) Token: 0x0602F30E RID: 193294 RVA: 0x00B2E394 File Offset: 0x00B2C594
		private int Count
		{
			get
			{
				return this.EntityIdMap.Count + this.PbDataIdMap.Count + this.CreatureDataIdMap.Count;
			}
		}

		// Token: 0x0602F30F RID: 193295 RVA: 0x00B2E3B9 File Offset: 0x00B2C5B9
		public void Clear()
		{
			this.Handle = null;
			this.CreatureDataIdMap.Clear();
			this.PbDataIdMap.Clear();
			this.EntityIdMap.Clear();
			this.WaitEntityString = null;
			this.CallBack = null;
		}

		// Token: 0x0602F310 RID: 193296 RVA: 0x00B2E3F4 File Offset: 0x00B2C5F4
		private void FilterEntity()
		{
			foreach (long num in new List<long>(this.CreatureDataIdMap.Keys))
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num);
				if (entity != null && entity.Valid && (entity.Entity.GetComponent<CreatureDataComponent>().GetPreloadFinished() || entity.IsInit))
				{
					this.CreatureDataIdMap.Remove(num);
				}
			}
			foreach (int num2 in new List<int>(this.PbDataIdMap.Keys))
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num2);
				if (entityByPbDataId != null && entityByPbDataId.Valid && (entityByPbDataId.Entity.GetComponent<CreatureDataComponent>().GetPreloadFinished() || entityByPbDataId.IsInit))
				{
					this.PbDataIdMap.Remove(num2);
				}
			}
			foreach (int num3 in new List<int>(this.EntityIdMap.Keys))
			{
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(num3);
				if (entityById != null && entityById.Valid && (entityById.Entity.GetComponent<CreatureDataComponent>().GetPreloadFinished() || entityById.IsInit))
				{
					this.EntityIdMap.Remove(num3);
				}
			}
		}

		// Token: 0x0602F311 RID: 193297 RVA: 0x00B2E5B0 File Offset: 0x00B2C7B0
		private void DoCallback()
		{
			Singleton<EventSystem>.Instance.Remove<EntityHandle>(EEventName.PreloadEntityFinished, new Action<EntityHandle>(this.OnPreloadEntityFinished));
			Singleton<EventSystem>.Instance.Remove<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			this.Result |= EWaitEntityPreloadResult.Finished;
			this.CallBack(this.Result);
			this.Clear();
		}

		// Token: 0x0602F312 RID: 193298 RVA: 0x00B2E61C File Offset: 0x00B2C81C
		private string GetDoNotPreloadEntityString()
		{
			string text = "";
			if (this.CreatureDataIdMap.Count != 0)
			{
				foreach (KeyValuePair<long, EWaitPreloadId> keyValuePair in this.CreatureDataIdMap)
				{
					long key = keyValuePair.Key;
					string str = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
					defaultInterpolatedStringHandler.AppendLiteral("CreatureDataId:");
					defaultInterpolatedStringHandler.AppendFormatted<long>(key);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					text = str + defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
			if (this.PbDataIdMap.Count != 0)
			{
				foreach (KeyValuePair<int, EWaitPreloadId> keyValuePair2 in this.PbDataIdMap)
				{
					int key2 = keyValuePair2.Key;
					string str2 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
					defaultInterpolatedStringHandler.AppendLiteral("PbDataId:");
					defaultInterpolatedStringHandler.AppendFormatted<int>(key2);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					text = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
			if (this.EntityIdMap.Count != 0)
			{
				foreach (KeyValuePair<int, EWaitPreloadId> keyValuePair3 in this.EntityIdMap)
				{
					int key3 = keyValuePair3.Key;
					string str3 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
					defaultInterpolatedStringHandler.AppendLiteral("EntityId:");
					defaultInterpolatedStringHandler.AppendFormatted<int>(key3);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					text = str3 + defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
			return text;
		}

		// Token: 0x0602F313 RID: 193299 RVA: 0x00B2E7D4 File Offset: 0x00B2C9D4
		private void OnPreloadEntityFinished(EntityHandle handle)
		{
			if ((this.Result & EWaitEntityPreloadResult.Finished) != EWaitEntityPreloadResult.None)
			{
				return;
			}
			CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
			long creatureDataId = component.GetCreatureDataId();
			int pbDataId = component.GetPbDataId();
			int id = handle.Id;
			bool flag = false;
			if (this.CreatureDataIdMap.ContainsKey(creatureDataId))
			{
				flag = true;
				this.CreatureDataIdMap.Remove(creatureDataId);
			}
			if (this.PbDataIdMap.ContainsKey(pbDataId))
			{
				flag = true;
				this.PbDataIdMap.Remove(pbDataId);
			}
			if (this.EntityIdMap.ContainsKey(id))
			{
				flag = true;
				this.EntityIdMap.Remove(id);
			}
			if (!flag)
			{
				return;
			}
			if (this.Count != 0)
			{
				return;
			}
			this.DoCallback();
		}

		// Token: 0x0602F314 RID: 193300 RVA: 0x00B2E878 File Offset: 0x00B2CA78
		private unsafe void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			if ((this.Result & EWaitEntityPreloadResult.Finished) != EWaitEntityPreloadResult.None)
			{
				return;
			}
			if (handle.Id == this.Handle.Id)
			{
				this.Result |= EWaitEntityPreloadResult.Cancel;
				this.DoCallback();
				return;
			}
			CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
			long creatureDataId = component.GetCreatureDataId();
			int pbDataId = component.GetPbDataId();
			int id = handle.Id;
			bool flag = false;
			if (this.CreatureDataIdMap.ContainsKey(creatureDataId))
			{
				flag = true;
				this.CreatureDataIdMap.Remove(creatureDataId);
				if (!ModelBase<CreatureModel>.Instance.LeavingLevel)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.LFJW;
					string message = "实体需要等待的实体被删了";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
					string item = "CreatureDataId";
					CreatureDataComponent creatureData = this.CreatureData;
					ptr = new ValueTuple<string, object>(item, (creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("被删的实体CreatureDataId", creatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("依赖的实体列表", this.WaitEntityString);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
			}
			if (this.PbDataIdMap.ContainsKey(pbDataId))
			{
				flag = true;
				this.PbDataIdMap.Remove(pbDataId);
				if (!ModelBase<CreatureModel>.Instance.LeavingLevel)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Entity;
					ELogAuthor author2 = ELogAuthor.LFJW;
					string message2 = "实体需要等待的实体被删了";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
					string item2 = "CreatureDataId";
					CreatureDataComponent creatureData2 = this.CreatureData;
					ptr2 = new ValueTuple<string, object>(item2, (creatureData2 != null) ? new long?(creatureData2.GetCreatureDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("被删的实体PbDataId", pbDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("依赖的实体列表", this.WaitEntityString);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
			}
			if (this.EntityIdMap.ContainsKey(id))
			{
				flag = true;
				this.EntityIdMap.Remove(id);
				if (!ModelBase<CreatureModel>.Instance.LeavingLevel)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Entity;
					ELogAuthor author3 = ELogAuthor.LFJW;
					string message3 = "实体需要等待的实体被删了";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0);
					string item3 = "CreatureDataId";
					CreatureDataComponent creatureData3 = this.CreatureData;
					ptr3 = new ValueTuple<string, object>(item3, (creatureData3 != null) ? new long?(creatureData3.GetCreatureDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("被删的实体EntityId", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("依赖的实体列表", this.WaitEntityString);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				}
			}
			if (!flag)
			{
				return;
			}
			this.Result |= EWaitEntityPreloadResult.Fail;
			if (this.Count != 0)
			{
				return;
			}
			this.DoCallback();
		}

		// Token: 0x0602F315 RID: 193301 RVA: 0x00B2EB4F File Offset: 0x00B2CD4F
		public static WaitEntityPreloadTask Create(EntityHandle handle, Action<EWaitEntityPreloadResult> callBack)
		{
			WaitEntityPreloadTask waitEntityPreloadTask = new WaitEntityPreloadTask(handle, callBack);
			waitEntityPreloadTask.Init();
			return waitEntityPreloadTask;
		}

		// Token: 0x0401AE33 RID: 110131
		[Nullable(2)]
		private EntityHandle Handle;

		// Token: 0x0401AE34 RID: 110132
		[Nullable(2)]
		private Action<EWaitEntityPreloadResult> CallBack;

		// Token: 0x0401AE35 RID: 110133
		private EWaitEntityPreloadResult Result;

		// Token: 0x0401AE36 RID: 110134
		[Nullable(2)]
		private CreatureDataComponent CreatureData;

		// Token: 0x0401AE37 RID: 110135
		private readonly Dictionary<long, EWaitPreloadId> CreatureDataIdMap = new Dictionary<long, EWaitPreloadId>();

		// Token: 0x0401AE38 RID: 110136
		private readonly Dictionary<int, EWaitPreloadId> PbDataIdMap = new Dictionary<int, EWaitPreloadId>();

		// Token: 0x0401AE39 RID: 110137
		private readonly Dictionary<int, EWaitPreloadId> EntityIdMap = new Dictionary<int, EWaitPreloadId>();

		// Token: 0x0401AE3A RID: 110138
		[Nullable(2)]
		private string WaitEntityString;

		// Token: 0x0401AE3B RID: 110139
		private const int WAIT_TIME = 60000;
	}
}
