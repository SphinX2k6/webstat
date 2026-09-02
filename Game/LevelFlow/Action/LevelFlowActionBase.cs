using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F85 RID: 28549
	public class LevelFlowActionBase : IStaticVariableResetter
	{
		// Token: 0x0604515C RID: 282972 RVA: 0x01203C8B File Offset: 0x01201E8B
		static LevelFlowActionBase()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelFlowActionBase.CreateStaticDefaultValue), new Action(LevelFlowActionBase.ResetStaticDefaultValue));
		}

		// Token: 0x0604515D RID: 282973 RVA: 0x01203CAA File Offset: 0x01201EAA
		public LevelFlowActionBase()
		{
			this.ActionId = LevelFlowActionBase.SelfIncrementId++;
		}

		// Token: 0x0604515E RID: 282974 RVA: 0x01203CC5 File Offset: 0x01201EC5
		[NullableContext(1)]
		public void BindCompleteCallBack(Action<LevelFlowActionBase, bool> completeCallBack)
		{
			this.CompleteCallBack = completeCallBack;
		}

		// Token: 0x0604515F RID: 282975 RVA: 0x01203CCE File Offset: 0x01201ECE
		public void Execute()
		{
			this.IsExecute = true;
			this.LogExecuteInfo();
			this.OnAddEventListener();
			this.OnExecute();
		}

		// Token: 0x06045160 RID: 282976 RVA: 0x01203CEC File Offset: 0x01201EEC
		public unsafe void FinishExecute(bool isSuccess)
		{
			if (!this.IsExecute)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "行为完成";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsSuccess", isSuccess);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.IsExecute = false;
			this.OnRemoveEventListener();
			this.OnComplete(isSuccess);
			Action<LevelFlowActionBase, bool> completeCallBack = this.CompleteCallBack;
			if (completeCallBack != null)
			{
				completeCallBack(this, isSuccess);
			}
			this.CompleteCallBack = null;
		}

		// Token: 0x06045161 RID: 282977 RVA: 0x01203DB7 File Offset: 0x01201FB7
		public void Tick(float deltaTime)
		{
			if (!this.IsExecute)
			{
				return;
			}
			this.OnTick(deltaTime);
		}

		// Token: 0x06045162 RID: 282978 RVA: 0x01203DC9 File Offset: 0x01201FC9
		public void Reset()
		{
			this.IsExecute = false;
			this.OnReset();
		}

		// Token: 0x06045163 RID: 282979 RVA: 0x01203DD8 File Offset: 0x01201FD8
		protected unsafe void CreateWaitEntityTask([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<List<int>, int> entityIds)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "等待实体创建";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("行为Id", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityIds", entityIds.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			int count = 1;
			if (entityIds.IsT1)
			{
				count = entityIds.AsT1.Count;
			}
			if (entityIds.IsT1)
			{
				WaitEntityTask.CreateWithPbDataId("LevelEventBase.CreateWaitEntityTask", entityIds.AsT1, delegate(bool? result)
				{
					if (!result.GetValueOrDefault())
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.YZH;
						string message2 = "Entity加载超时或已被移除";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityCount", count);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityIds", entityIds.AsT1.ToString());
						instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
						this.FinishExecute(false);
						return;
					}
					this.ExecuteWhenEntitiesReady();
				}, 30000 * count, true, false);
			}
			if (entityIds.IsT2)
			{
				WaitEntityTask.CreateWithPbDataId("LevelEventBase.CreateWaitEntityTask", entityIds.AsT2, delegate(bool? result)
				{
					if (!result.GetValueOrDefault())
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.YZH;
						string message2 = "Entity加载超时或已被移除";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityCount", count);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityIds", entityIds.AsT1.ToString());
						instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
						this.FinishExecute(false);
						return;
					}
					this.ExecuteWhenEntitiesReady();
				}, 30000 * count, true, false);
			}
		}

		// Token: 0x06045164 RID: 282980 RVA: 0x01203F10 File Offset: 0x01202110
		protected unsafe void CreateWaitEntityTaskBigInt([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<List<long>, long> entityIds)
		{
			if (ControllerBase<LevelGeneralController>.Instance.LevelEventLogOpen)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "等待实体创建";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("行为Id", this.ActionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityIds", entityIds.ToString());
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			int count = 1;
			if (entityIds.IsT1)
			{
				count = entityIds.AsT1.Count;
			}
			if (entityIds.IsT1)
			{
				WaitEntityTask.Create("LevelEventBase.CreateWaitEntityTaskBigInt", entityIds.AsT1, delegate(bool? result)
				{
					if (!result.GetValueOrDefault())
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.YZH;
						string message2 = "Entity加载超时或已被移除";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityCount", count);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						this.FinishExecute(false);
						return;
					}
					this.ExecuteWhenEntitiesReady();
				}, count * 30000, true, false);
			}
			if (entityIds.IsT2)
			{
				WaitEntityTask.Create("LevelEventBase.CreateWaitEntityTaskBigInt", entityIds.AsT2, delegate(bool? result)
				{
					if (!result.GetValueOrDefault())
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.YZH;
						string message2 = "Entity加载超时或已被移除";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityCount", count);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						this.FinishExecute(false);
						return;
					}
					this.ExecuteWhenEntitiesReady();
				}, count * 30000, true, false);
			}
		}

		// Token: 0x06045165 RID: 282981 RVA: 0x0120402A File Offset: 0x0120222A
		protected virtual void OnExecute()
		{
		}

		// Token: 0x06045166 RID: 282982 RVA: 0x0120402C File Offset: 0x0120222C
		protected virtual void OnAddEventListener()
		{
		}

		// Token: 0x06045167 RID: 282983 RVA: 0x0120402E File Offset: 0x0120222E
		protected virtual void OnTick(float deltaTime)
		{
		}

		// Token: 0x06045168 RID: 282984 RVA: 0x01204030 File Offset: 0x01202230
		protected virtual void ExecuteWhenEntitiesReady()
		{
		}

		// Token: 0x06045169 RID: 282985 RVA: 0x01204032 File Offset: 0x01202232
		protected virtual void OnRemoveEventListener()
		{
		}

		// Token: 0x0604516A RID: 282986 RVA: 0x01204034 File Offset: 0x01202234
		protected virtual void OnComplete(bool isSuccess)
		{
		}

		// Token: 0x0604516B RID: 282987 RVA: 0x01204036 File Offset: 0x01202236
		protected virtual void OnReset()
		{
		}

		// Token: 0x0604516C RID: 282988 RVA: 0x01204038 File Offset: 0x01202238
		protected unsafe virtual void LogExecuteInfo()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0604516D RID: 282989 RVA: 0x012040AF File Offset: 0x012022AF
		public static void CreateStaticDefaultValue()
		{
			LevelFlowActionBase.SelfIncrementId = 0;
		}

		// Token: 0x0604516E RID: 282990 RVA: 0x012040B7 File Offset: 0x012022B7
		public static void ResetStaticDefaultValue()
		{
			LevelFlowActionBase.SelfIncrementId = 0;
		}

		// Token: 0x040268D0 RID: 157904
		public readonly int ActionId;

		// Token: 0x040268D1 RID: 157905
		private static int SelfIncrementId;

		// Token: 0x040268D2 RID: 157906
		private bool IsExecute;

		// Token: 0x040268D3 RID: 157907
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<LevelFlowActionBase, bool> CompleteCallBack;

		// Token: 0x040268D4 RID: 157908
		private const int EACH_WAIT_ENTITY_OVER_TIME = 30000;
	}
}
