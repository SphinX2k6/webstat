using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A02 RID: 18946
	public class LoginInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318C6 RID: 202950 RVA: 0x00C5990C File Offset: 0x00C57B0C
		public override bool OnRefresh()
		{
			if (ModelBase<WorldModel>.Instance.IsStandalone || !this.IsLogin())
			{
				return false;
			}
			Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新登录状态输入Tag时", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.SetInputDistributeTags(new string[]
			{
				"UiInputRoot.MouseInputTag",
				"UiInputRoot.Navigation"
			});
			return true;
		}

		// Token: 0x060318C7 RID: 202951 RVA: 0x00C59968 File Offset: 0x00C57B68
		private bool IsLogin()
		{
			return !ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.EnterGameRet);
		}
	}
}
