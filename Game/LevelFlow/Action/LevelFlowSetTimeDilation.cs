using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FAB RID: 28587
	public class LevelFlowSetTimeDilation : LevelFlowActionBase
	{
		// Token: 0x0604522B RID: 283179 RVA: 0x01209E5B File Offset: 0x0120805B
		[NullableContext(1)]
		public LevelFlowSetTimeDilation Init(int entityId, float timeDilation)
		{
			this.EntityId = entityId;
			this.TimeDilation = timeDilation;
			return this;
		}

		// Token: 0x0604522C RID: 283180 RVA: 0x01209E6C File Offset: 0x0120806C
		protected override void OnExecute()
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.EntityId);
			if (entityById != null && entityById.Valid)
			{
				WorldEntity entity = entityById.Entity;
				if (entity != null && entity.Valid)
				{
					entityById.Entity.SetTimeDilation(this.TimeDilation);
					base.FinishExecute(true);
					return;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "LevelFlowSetTimeDilation 实体不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", this.EntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
		}

		// Token: 0x0604522D RID: 283181 RVA: 0x01209F08 File Offset: 0x01208108
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
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TimeDilation", this.TimeDilation);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x0402692C RID: 157996
		private int EntityId;

		// Token: 0x0402692D RID: 157997
		private float TimeDilation = 1f;
	}
}
