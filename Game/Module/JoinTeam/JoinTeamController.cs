using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.JoinTeam
{
	// Token: 0x02005AFE RID: 23294
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class JoinTeamController : UiControllerBase<JoinTeamController>
	{
		// Token: 0x0603AE73 RID: 241267 RVA: 0x00EF0050 File Offset: 0x00EEE250
		protected override void OnAddEvents()
		{
		}

		// Token: 0x0603AE74 RID: 241268 RVA: 0x00EF0052 File Offset: 0x00EEE252
		protected override void OnRemoveEvents()
		{
		}

		// Token: 0x0603AE75 RID: 241269 RVA: 0x00EF0054 File Offset: 0x00EEE254
		public UniTask<bool> OpenJoinTeamView(int roleDescriptionId, bool isTrial = false)
		{
			JoinTeamController.<OpenJoinTeamView>d__2 <OpenJoinTeamView>d__;
			<OpenJoinTeamView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenJoinTeamView>d__.roleDescriptionId = roleDescriptionId;
			<OpenJoinTeamView>d__.isTrial = isTrial;
			<OpenJoinTeamView>d__.<>1__state = -1;
			<OpenJoinTeamView>d__.<>t__builder.Start<JoinTeamController.<OpenJoinTeamView>d__2>(ref <OpenJoinTeamView>d__);
			return <OpenJoinTeamView>d__.<>t__builder.Task;
		}

		// Token: 0x0603AE76 RID: 241270 RVA: 0x00EF00A0 File Offset: 0x00EEE2A0
		public void CloseJoinTeamView()
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.JoinTeamView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.JoinTeamView, null);
			}
			ModelBase<JoinTeamModel>.Instance.SetRoleDescriptionId(null);
		}
	}
}
