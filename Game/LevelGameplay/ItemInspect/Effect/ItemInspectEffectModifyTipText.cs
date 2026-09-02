using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.ItemInspect.View;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Effect
{
	// Token: 0x02006E58 RID: 28248
	public class ItemInspectEffectModifyTipText : ItemInspectEffectBase
	{
		// Token: 0x060448FC RID: 280828 RVA: 0x011D321C File Offset: 0x011D141C
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
			itemInspectViewBase.ExecuteModifyTipText(((IModifyTipText)@params).TipText, delegate
			{
				base.FinishExecute(true);
			});
		}
	}
}
