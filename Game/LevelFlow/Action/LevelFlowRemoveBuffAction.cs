using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FA4 RID: 28580
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowRemoveBuffAction : LevelFlowActionBase
	{
		// Token: 0x0604520F RID: 283151 RVA: 0x012093DD File Offset: 0x012075DD
		public LevelFlowRemoveBuffAction Init(int entityId, List<long> buffIds)
		{
			this.EntityId = entityId;
			this.BuffIds = buffIds;
			return this;
		}

		// Token: 0x06045210 RID: 283152 RVA: 0x012093EE File Offset: 0x012075EE
		protected override void OnExecute()
		{
			ControllerBase<LevelFlowController>.Instance.LevelFlowRemoveBuffRequest(this.BuffIds);
			base.FinishExecute(true);
		}

		// Token: 0x06045211 RID: 283153 RVA: 0x01209408 File Offset: 0x01207608
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

		// Token: 0x0402691F RID: 157983
		private int EntityId;

		// Token: 0x04026920 RID: 157984
		private List<long> BuffIds = new List<long>();
	}
}
