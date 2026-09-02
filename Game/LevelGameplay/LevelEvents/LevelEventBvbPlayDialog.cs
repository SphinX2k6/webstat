using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B6D RID: 27501
	public class LevelEventBvbPlayDialog : LevelEventBase
	{
		// Token: 0x06043EBF RID: 278207 RVA: 0x011937C6 File Offset: 0x011919C6
		public LevelEventBvbPlayDialog(int id) : base(id)
		{
		}

		// Token: 0x06043EC0 RID: 278208 RVA: 0x011937D0 File Offset: 0x011919D0
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			BvbPlayDialog bvbPlayDialog = inParams as BvbPlayDialog;
			if (bvbPlayDialog == null)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomArenaBattleDetailsView);
			if (viewByName != null)
			{
				(viewByName.OpenParam as PhantomArenaBattleDetailsViewProxy).DialogManager.NotifyDialogType(bvbPlayDialog.DialogType);
				base.FinishExecute(true, false, true);
				return;
			}
			UiViewBase viewByName2 = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomArenaBattleView);
			if (viewByName2 != null)
			{
				(viewByName2.OpenParam as PhantomArenaBattleProxy).DialogManager.NotifyDialogType(bvbPlayDialog.DialogType);
			}
			base.FinishExecute(true, false, true);
		}
	}
}
