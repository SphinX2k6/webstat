using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A05 RID: 18949
	public class ReconnectInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318CD RID: 202957 RVA: 0x00C59B74 File Offset: 0x00C57D74
		public override bool OnRefresh()
		{
			if (!this.IsReConnect())
			{
				return false;
			}
			if (this.CanClickInReconnect())
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新重连状态输入Tag时，可点击鼠标", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation"
				});
			}
			else
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新重连状态输入Tag时，禁用所有操作", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTag("BlockAllInputTag");
			}
			return true;
		}

		// Token: 0x060318CE RID: 202958 RVA: 0x00C59BF5 File Offset: 0x00C57DF5
		private bool CanClickInReconnect()
		{
			return Singleton<UiManager>.Instance.GetViewByName(EUiViewName.NetWorkConfirmBoxView) != null;
		}

		// Token: 0x060318CF RID: 202959 RVA: 0x00C59C09 File Offset: 0x00C57E09
		private bool IsReConnect()
		{
			return ModelBase<ReConnectModel>.Instance.GetReConnectStatus() == EReConnectStatus.ReConnectDoing;
		}
	}
}
