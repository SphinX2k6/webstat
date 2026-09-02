using System;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FB6 RID: 28598
	public class LevelFlowWaitQteStart : LevelFlowActionBase
	{
		// Token: 0x0604525A RID: 283226 RVA: 0x0120B2BA File Offset: 0x012094BA
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int?>(EEventName.CommonQteStart, new Action<int?>(this.OnCommonQteStart));
		}

		// Token: 0x0604525B RID: 283227 RVA: 0x0120B2D8 File Offset: 0x012094D8
		protected override void OnExecute()
		{
			if (ModelBase<LevelFlowModel>.Instance.IsEnd)
			{
				base.FinishExecute(true);
			}
		}

		// Token: 0x0604525C RID: 283228 RVA: 0x0120B2ED File Offset: 0x012094ED
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int?>(EEventName.CommonQteStart, new Action<int?>(this.OnCommonQteStart));
		}

		// Token: 0x0604525D RID: 283229 RVA: 0x0120B30B File Offset: 0x0120950B
		private void OnCommonQteStart(int? handleId)
		{
			base.FinishExecute(true);
		}
	}
}
