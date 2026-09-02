using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F86 RID: 28550
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowAddBuffAction : LevelFlowActionBase
	{
		// Token: 0x0604516F RID: 282991 RVA: 0x012040BF File Offset: 0x012022BF
		public LevelFlowAddBuffAction Init(int entityId, List<long> buffIds)
		{
			this.EntityId = entityId;
			this.BuffIds = buffIds;
			return this;
		}

		// Token: 0x06045170 RID: 282992 RVA: 0x012040D0 File Offset: 0x012022D0
		protected override void OnExecute()
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.EntityId);
			if (entityById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "Entity加载超时或已被移除";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false);
				return;
			}
			WorldEntity entity = entityById.Entity;
			if (entity == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelFlow;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "未找到实体";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			if (entity.GetComponent<CharacterBuffComponent>() == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelFlow;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "实体没有BuffComponent";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				base.FinishExecute(false);
				return;
			}
			ControllerBase<LevelFlowController>.Instance.LevelFlowAddBuffRequest(this.BuffIds);
			base.FinishExecute(true);
		}

		// Token: 0x06045171 RID: 282993 RVA: 0x012041D0 File Offset: 0x012023D0
		protected unsafe override void LogExecuteInfo()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", this.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("BuffIds", string.Join<long>(",", this.BuffIds));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x040268D5 RID: 157909
		private int EntityId;

		// Token: 0x040268D6 RID: 157910
		private List<long> BuffIds = new List<long>();
	}
}
