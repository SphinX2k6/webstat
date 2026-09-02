using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F8E RID: 28558
	public class LevelFlowEnableHookMark : LevelFlowActionBase
	{
		// Token: 0x06045192 RID: 283026 RVA: 0x012061EC File Offset: 0x012043EC
		[NullableContext(1)]
		public LevelFlowEnableHookMark Init(bool isEnable)
		{
			this.IsEnable = isEnable;
			return this;
		}

		// Token: 0x06045193 RID: 283027 RVA: 0x012061F6 File Offset: 0x012043F6
		protected override void OnExecute()
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.EnableGrapplingHookMark, this.IsEnable);
			base.FinishExecute(true);
		}

		// Token: 0x040268ED RID: 157933
		private bool IsEnable;
	}
}
