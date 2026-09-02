using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.ItemInspect.View;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Effect
{
	// Token: 0x02006E5A RID: 28250
	public class ItemInspectEffectTriggerDialogues : ItemInspectEffectBase
	{
		// Token: 0x06044901 RID: 280833 RVA: 0x011D331C File Offset: 0x011D151C
		[NullableContext(1)]
		protected override void Execute(IInteractEffect @params)
		{
			EUiViewName? viewName = ModelBase<ItemInspectModel>.Instance.GetViewName();
			if (viewName == null)
			{
				base.FinishExecute(true);
				return;
			}
			ItemInspectViewBase itemInspectViewBase = Singleton<UiManager>.Instance.GetViewByName(viewName.Value) as ItemInspectViewBase;
			if (itemInspectViewBase == null)
			{
				return;
			}
			itemInspectViewBase.ExecuteTriggerDialogues((ITriggerDialogues)@params, delegate
			{
				base.FinishExecute(true);
			});
		}
	}
}
