using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FB9 RID: 28601
	public class LevelFlowWaitTeleportEnd : LevelFlowActionBase
	{
		// Token: 0x0604526C RID: 283244 RVA: 0x0120B810 File Offset: 0x01209A10
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		}

		// Token: 0x0604526D RID: 283245 RVA: 0x0120B82E File Offset: 0x01209A2E
		protected override void OnExecute()
		{
			if (ModelBase<LevelFlowModel>.Instance.IsEnd)
			{
				base.FinishExecute(true);
			}
		}

		// Token: 0x0604526E RID: 283246 RVA: 0x0120B843 File Offset: 0x01209A43
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		}

		// Token: 0x0604526F RID: 283247 RVA: 0x0120B861 File Offset: 0x01209A61
		[NullableContext(2)]
		private void OnTeleportComplete(TeleportContext context)
		{
			base.FinishExecute(true);
		}
	}
}
