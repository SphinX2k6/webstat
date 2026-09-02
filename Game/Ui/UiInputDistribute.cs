using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A07 RID: 18951
	public class UiInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318D3 RID: 202963 RVA: 0x00C59CAC File Offset: 0x00C57EAC
		public override bool OnRefresh()
		{
			if (Singleton<UiManager>.Instance.IsViewShow(Singleton<UiModel>.Instance.MainViewName))
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新UI输入时，主界面已经打开，设置输入分发Tag为 UiInputRootTag", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTag("UiInputRoot");
				return true;
			}
			Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新UI输入时，主界面没有打开，设置输入分发Tag为 ShortcutKeyTag，MouseInputTag，NavigationTag", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.SetInputDistributeTags(new string[]
			{
				"UiInputRoot.ShortcutKeyTag",
				"UiInputRoot.MouseInputTag",
				"UiInputRoot.Navigation"
			});
			return true;
		}
	}
}
