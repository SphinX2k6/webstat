using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F93 RID: 28563
	public class LevelFlowExitMoveWithSpline : LevelFlowActionBase
	{
		// Token: 0x060451B6 RID: 283062 RVA: 0x01206C5D File Offset: 0x01204E5D
		[NullableContext(1)]
		public LevelFlowExitMoveWithSpline Init(int entityId)
		{
			this.EntityId = entityId;
			return this;
		}

		// Token: 0x060451B7 RID: 283063 RVA: 0x01206C68 File Offset: 0x01204E68
		protected override void OnExecute()
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.EntityId);
			if (entityById == null || entityById.Entity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "LevelFlowExitMoveWithSpline 实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", this.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false);
				return;
			}
			CreatureDataComponent component = entityById.Entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelFlow;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "LevelFlowExitMoveWithSpline 实体不存在CreatureDataComponent";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", this.EntityId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			if (component.GetEntityType() != EEntityType.Vehicle)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelFlow;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "LevelFlowExitMoveWithSpline 实体类型错误";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("entityId", this.EntityId);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				base.FinishExecute(false);
				return;
			}
			VehicleMoveComponent component2 = entityById.Entity.GetComponent<VehicleMoveComponent>();
			if (component2 == null)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.LevelFlow;
				ELogAuthor author4 = ELogAuthor.BB;
				string message4 = "LevelFlowExitMoveWithSpline 实体不存在VehicleMoveComponent";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("entityId", this.EntityId);
				instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				base.FinishExecute(false);
				return;
			}
			component2.StopMove();
			base.FinishExecute(true);
		}

		// Token: 0x060451B8 RID: 283064 RVA: 0x01206DB8 File Offset: 0x01204FB8
		protected unsafe override void LogExecuteInfo()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", this.EntityId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x040268F5 RID: 157941
		private int EntityId;
	}
}
