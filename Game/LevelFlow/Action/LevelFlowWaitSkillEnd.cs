using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FB7 RID: 28599
	public class LevelFlowWaitSkillEnd : LevelFlowActionBase
	{
		// Token: 0x0604525F RID: 283231 RVA: 0x0120B31C File Offset: 0x0120951C
		[NullableContext(1)]
		public LevelFlowWaitSkillEnd Init(int skillId, int entityId)
		{
			this.SkillId = skillId;
			this.EntityId = entityId;
			return this;
		}

		// Token: 0x06045260 RID: 283232 RVA: 0x0120B32D File Offset: 0x0120952D
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
		}

		// Token: 0x06045261 RID: 283233 RVA: 0x0120B348 File Offset: 0x01209548
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
		}

		// Token: 0x06045262 RID: 283234 RVA: 0x0120B363 File Offset: 0x01209563
		private void OnSkillEnd(int entityId, int skillId)
		{
			if (skillId != this.SkillId || entityId != this.EntityId)
			{
				return;
			}
			base.FinishExecute(true);
		}

		// Token: 0x06045263 RID: 283235 RVA: 0x0120B380 File Offset: 0x01209580
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
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("SkillId", this.SkillId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x04026943 RID: 158019
		private int SkillId;

		// Token: 0x04026944 RID: 158020
		private int EntityId;
	}
}
