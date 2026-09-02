using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A38 RID: 27192
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventBase
	{
		// Token: 0x060434BD RID: 275645 RVA: 0x0114C6A1 File Offset: 0x0114A8A1
		public LevelEventBase(int id)
		{
			this.Id = id;
		}

		// Token: 0x1700A243 RID: 41539
		// (get) Token: 0x060434BE RID: 275646 RVA: 0x0114C6CD File Offset: 0x0114A8CD
		public int Id { get; }

		// Token: 0x060434BF RID: 275647 RVA: 0x0114C6D8 File Offset: 0x0114A8D8
		public unsafe virtual void ExecuteAction(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			this.BaseContext = context;
			if (ControllerBase<LevelGeneralController>.Instance.LevelEventLogOpen)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "LevelEvent:开始执行行为";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("行为类型", this.Type);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode())
			{
				this.ExecuteInGm(inParams, context, actionId);
				return;
			}
			if (!Singleton<LevelGeneralBaseFrameScheduler>.Instance.PushActionToFrameScheduler(this, inParams, context, actionId))
			{
				CombinationContext combinationContext = context as CombinationContext;
				if (combinationContext != null)
				{
					EntityContext contextByType = combinationContext.GetContextByType<EntityContext>(EGeneralContextType.Entity);
					if (contextByType == null)
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.LevelEvent;
						ELogAuthor author2 = ELogAuthor.CK;
						string message2 = "CombinationContext内不包含EntityContext, 直接传递CombinationContext";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("行为类型", this.Type);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionId", actionId);
						instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						this.ExecuteNew(inParams, context, actionId);
						return;
					}
					this.ExecuteNew(inParams, contextByType, actionId);
					return;
				}
				else
				{
					this.ExecuteNew(inParams, context, actionId);
				}
			}
		}

		// Token: 0x060434C0 RID: 275648 RVA: 0x0114C7DC File Offset: 0x0114A9DC
		public virtual void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
		}

		// Token: 0x060434C1 RID: 275649 RVA: 0x0114C7DE File Offset: 0x0114A9DE
		protected virtual void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			this.ExecuteNew(inParams, context, actionId);
		}

		// Token: 0x060434C2 RID: 275650 RVA: 0x0114C7E9 File Offset: 0x0114A9E9
		protected void CreateWaitEntityTask(List<int> entityIds)
		{
			this.CreateWaitEntityTaskInternal(entityIds);
		}

		// Token: 0x060434C3 RID: 275651 RVA: 0x0114C7F7 File Offset: 0x0114A9F7
		protected void CreateWaitEntityTask(int entityId)
		{
			this.CreateWaitEntityTaskInternal(entityId);
		}

		// Token: 0x060434C4 RID: 275652 RVA: 0x0114C808 File Offset: 0x0114AA08
		private unsafe void CreateWaitEntityTaskInternal([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<List<int>, int> entityIds)
		{
			if (ControllerBase<LevelGeneralController>.Instance.LevelEventLogOpen)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "等待实体创建";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("行为类型", this.Type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityIds", entityIds.ToString());
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			int count = 1;
			if (entityIds.IsT1)
			{
				count = entityIds.AsT1.Count;
				WaitEntityTask.CreateWithPbDataId("LevelEventBase.CreateWaitEntityTask", entityIds.AsT1, delegate(bool? result)
				{
					if (!result.GetValueOrDefault())
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.YZH;
						string message2 = "Entity加载超时或已被移除";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityCount", count);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityIds", entityIds.AsT1);
						instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
						this.FinishExecute(false, false, true);
						return;
					}
					this.ExecuteWhenEntitiesReady();
				}, 30000 * count, true, false);
				return;
			}
			WaitEntityTask.CreateWithPbDataId("LevelEventBase.CreateWaitEntityTask", entityIds.AsT2, delegate(bool? result)
			{
				if (!result.GetValueOrDefault())
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.Event;
					ELogAuthor author2 = ELogAuthor.YZH;
					string message2 = "Entity加载超时或已被移除";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityCount", count);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityIds", entityIds.AsT2);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					this.FinishExecute(false, false, true);
					return;
				}
				this.ExecuteWhenEntitiesReady();
			}, 30000 * count, true, false);
		}

		// Token: 0x060434C5 RID: 275653 RVA: 0x0114C927 File Offset: 0x0114AB27
		protected void CreateWaitEntityTaskBigInt(List<long> entityIds)
		{
			this.CreateWaitEntityTaskBigIntInternal(entityIds);
		}

		// Token: 0x060434C6 RID: 275654 RVA: 0x0114C935 File Offset: 0x0114AB35
		protected void CreateWaitEntityTaskBigInt(long entityId)
		{
			this.CreateWaitEntityTaskBigIntInternal(entityId);
		}

		// Token: 0x060434C7 RID: 275655 RVA: 0x0114C944 File Offset: 0x0114AB44
		private unsafe void CreateWaitEntityTaskBigIntInternal([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<List<long>, long> entityIds)
		{
			if (ControllerBase<LevelGeneralController>.Instance.LevelEventLogOpen)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "等待实体创建";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("行为类型", this.Type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityIds", entityIds.ToString());
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			int count = 1;
			if (entityIds.IsT1)
			{
				count = entityIds.AsT1.Count;
				WaitEntityTask.Create("LevelEventBase.CreateWaitEntityTaskBigInt", entityIds.AsT1, delegate(bool? result)
				{
					if (!result.GetValueOrDefault())
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.YZH;
						string message2 = "Entity加载超时或已被移除";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityCount", count);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						this.FinishExecute(false, false, true);
						return;
					}
					this.ExecuteWhenEntitiesReady();
				}, count * 30000, true, false);
				return;
			}
			WaitEntityTask.Create("LevelEventBase.CreateWaitEntityTaskBigInt", entityIds.AsT2, delegate(bool? result)
			{
				if (!result.GetValueOrDefault())
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.Event;
					ELogAuthor author2 = ELogAuthor.YZH;
					string message2 = "Entity加载超时或已被移除";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityCount", count);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.FinishExecute(false, false, true);
					return;
				}
				this.ExecuteWhenEntitiesReady();
			}, count * 30000, true, false);
		}

		// Token: 0x060434C8 RID: 275656 RVA: 0x0114CA48 File Offset: 0x0114AC48
		protected virtual void ExecuteWhenEntitiesReady()
		{
		}

		// Token: 0x060434C9 RID: 275657 RVA: 0x0114CA4A File Offset: 0x0114AC4A
		public void OpenTick()
		{
			this.IsWaitEnd = true;
			this.IsFinished = false;
			Singleton<EventSystem>.Instance.Emit<bool, LevelEventBase>(EEventName.AddToTickList, true, this);
		}

		// Token: 0x060434CA RID: 275658 RVA: 0x0114CA6C File Offset: 0x0114AC6C
		public virtual bool Tick(float deltaTime)
		{
			this.OnTick(deltaTime);
			return this.IsFinished;
		}

		// Token: 0x060434CB RID: 275659 RVA: 0x0114CA7B File Offset: 0x0114AC7B
		protected virtual void OnTick(float deltaTime)
		{
		}

		// Token: 0x060434CC RID: 275660 RVA: 0x0114CA7D File Offset: 0x0114AC7D
		protected void FinishExecute(bool value, bool isError = false, bool showLog = true)
		{
			this.IsFinished = value;
			if (!this.IsFinished)
			{
				this.Failure(isError, showLog);
			}
		}

		// Token: 0x060434CD RID: 275661 RVA: 0x0114CA98 File Offset: 0x0114AC98
		public void Finish()
		{
			this.OnFinish();
			this.UpdateGuarantee();
			this.Release();
			if (ControllerBase<LevelGeneralController>.Instance.LevelEventLogOpen)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "LevelEvent:行为执行完毕_NodeFinished";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("行为类型", this.Type);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.HandleNextAction, this.GroupId);
		}

		// Token: 0x060434CE RID: 275662 RVA: 0x0114CB05 File Offset: 0x0114AD05
		protected virtual void OnFinish()
		{
		}

		// Token: 0x060434CF RID: 275663 RVA: 0x0114CB07 File Offset: 0x0114AD07
		public void UpdateGuarantee()
		{
			this.OnUpdateGuarantee();
		}

		// Token: 0x060434D0 RID: 275664 RVA: 0x0114CB0F File Offset: 0x0114AD0F
		protected virtual void OnUpdateGuarantee()
		{
		}

		// Token: 0x060434D1 RID: 275665 RVA: 0x0114CB14 File Offset: 0x0114AD14
		public void Failure(bool isError = false, bool showLog = true)
		{
			if (GlobalData.IsPlayInEditor)
			{
				Singleton<EventSystem>.Instance.Emit<GeneralContext, int>(EEventName.GmHandleActionFailed, this.BaseContext, this.ActionIndex);
			}
			this.OnFailure();
			this.Release();
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "LevelEvent:行为执行失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("行为类型", this.Type);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<int, string, bool, bool>(EEventName.HandleActionFailure, this.GroupId, this.Type, isError, showLog);
		}

		// Token: 0x060434D2 RID: 275666 RVA: 0x0114CB9A File Offset: 0x0114AD9A
		protected virtual void OnFailure()
		{
		}

		// Token: 0x060434D3 RID: 275667 RVA: 0x0114CB9C File Offset: 0x0114AD9C
		public virtual void Release()
		{
			if (this.IsWaitEnd)
			{
				Singleton<EventSystem>.Instance.Emit<bool, LevelEventBase>(EEventName.AddToTickList, false, this);
			}
		}

		// Token: 0x060434D4 RID: 275668 RVA: 0x0114CBB8 File Offset: 0x0114ADB8
		public void Reset()
		{
			this.OnReset();
			this.GroupId = 0;
			this.IsWaitEnd = false;
			this.IsFinished = true;
			this.IsAsync = false;
			this.SessionId = -1;
			this.ActionIndex = -1;
		}

		// Token: 0x060434D5 RID: 275669 RVA: 0x0114CBEA File Offset: 0x0114ADEA
		protected virtual void OnReset()
		{
		}

		// Token: 0x04025852 RID: 153682
		public const int EACH_WAIT_ENTITY_OVER_TIME = 30000;

		// Token: 0x04025853 RID: 153683
		public int GroupId;

		// Token: 0x04025854 RID: 153684
		public string Type = "";

		// Token: 0x04025855 RID: 153685
		public bool IsWaitEnd;

		// Token: 0x04025856 RID: 153686
		public bool IsAsync;

		// Token: 0x04025857 RID: 153687
		public int SessionId = -1;

		// Token: 0x04025858 RID: 153688
		public int ActionIndex;

		// Token: 0x04025859 RID: 153689
		public string ActionGuid = "";

		// Token: 0x0402585A RID: 153690
		private bool IsFinished;

		// Token: 0x0402585B RID: 153691
		[Nullable(2)]
		public GeneralContext BaseContext;
	}
}
