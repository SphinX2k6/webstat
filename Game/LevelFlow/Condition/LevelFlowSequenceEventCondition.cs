using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelFlow.Condition
{
	// Token: 0x02006F82 RID: 28546
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowSequenceEventCondition : LevelFlowConditionBase
	{
		// Token: 0x06045150 RID: 282960 RVA: 0x01203A7B File Offset: 0x01201C7B
		public LevelFlowSequenceEventCondition Init(string param)
		{
			this.Param = param;
			return this;
		}

		// Token: 0x06045151 RID: 282961 RVA: 0x01203A85 File Offset: 0x01201C85
		protected override void OnEnter()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.LevelFlowSequenceTriggerEvent, new Action<string>(this.OnTriggerEvent));
		}

		// Token: 0x06045152 RID: 282962 RVA: 0x01203AA3 File Offset: 0x01201CA3
		protected override void OnExit()
		{
			Singleton<EventSystem>.Instance.Remove<string>(EEventName.LevelFlowSequenceTriggerEvent, new Action<string>(this.OnTriggerEvent));
		}

		// Token: 0x06045153 RID: 282963 RVA: 0x01203AC1 File Offset: 0x01201CC1
		protected override void OnReset()
		{
			Singleton<EventSystem>.Instance.Remove<string>(EEventName.LevelFlowSequenceTriggerEvent, new Action<string>(this.OnTriggerEvent));
		}

		// Token: 0x06045154 RID: 282964 RVA: 0x01203ADF File Offset: 0x01201CDF
		private void OnTriggerEvent(string param)
		{
			if (param == this.Param)
			{
				base.FinishExecute(true);
			}
		}

		// Token: 0x040268CA RID: 157898
		private string Param = string.Empty;
	}
}
