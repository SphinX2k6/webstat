using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049FB RID: 18939
	public class CreateCharacterInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318B3 RID: 202931 RVA: 0x00C5907C File Offset: 0x00C5727C
		public override bool OnRefresh()
		{
			if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CreateCharacterView))
			{
				return false;
			}
			Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]在创角中，则设置输入分发tag为 UiInputRootTag", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.SetInputDistributeTag("UiInputRoot");
			return true;
		}
	}
}
