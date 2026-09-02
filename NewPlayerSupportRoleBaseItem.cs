using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001477 RID: 5239
public class NewPlayerSupportRoleBaseItem : UiPanelBase
{
	// Token: 0x060092A7 RID: 37543 RVA: 0x0026B0FB File Offset: 0x002692FB
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x060092A8 RID: 37544 RVA: 0x0026B110 File Offset: 0x00269310
	public UniTask PlayStartSeqAsync()
	{
		NewPlayerSupportRoleBaseItem.<PlayStartSeqAsync>d__4 <PlayStartSeqAsync>d__;
		<PlayStartSeqAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayStartSeqAsync>d__.<>4__this = this;
		<PlayStartSeqAsync>d__.<>1__state = -1;
		<PlayStartSeqAsync>d__.<>t__builder.Start<NewPlayerSupportRoleBaseItem.<PlayStartSeqAsync>d__4>(ref <PlayStartSeqAsync>d__);
		return <PlayStartSeqAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060092A9 RID: 37545 RVA: 0x0026B154 File Offset: 0x00269354
	public void PlayStartSeq()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x060092AA RID: 37546 RVA: 0x0026B180 File Offset: 0x00269380
	public void PlaySwitchSeq()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
	}

	// Token: 0x060092AB RID: 37547 RVA: 0x0026B1AC File Offset: 0x002693AC
	public UniTask PlaySwitchSeqAsync()
	{
		NewPlayerSupportRoleBaseItem.<PlaySwitchSeqAsync>d__7 <PlaySwitchSeqAsync>d__;
		<PlaySwitchSeqAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySwitchSeqAsync>d__.<>4__this = this;
		<PlaySwitchSeqAsync>d__.<>1__state = -1;
		<PlaySwitchSeqAsync>d__.<>t__builder.Start<NewPlayerSupportRoleBaseItem.<PlaySwitchSeqAsync>d__7>(ref <PlaySwitchSeqAsync>d__);
		return <PlaySwitchSeqAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060092AC RID: 37548 RVA: 0x0026B1F0 File Offset: 0x002693F0
	public void Update(TrialRoleInfo trialRoleInfo)
	{
		bool flag = this.TrialRoleInfo != null && this.TrialRoleInfo.Value.GroupId == trialRoleInfo.GroupId;
		this.TrialRoleInfo = new TrialRoleInfo?(trialRoleInfo);
		if (flag)
		{
			return;
		}
		this.Refresh();
	}

	// Token: 0x060092AD RID: 37549 RVA: 0x0026B23E File Offset: 0x0026943E
	public void UpdateByRoleId(int roleId)
	{
		bool flag = this.RoleId == roleId;
		this.RoleId = roleId;
		if (flag)
		{
			return;
		}
		this.Refresh();
	}

	// Token: 0x060092AE RID: 37550 RVA: 0x0026B259 File Offset: 0x00269459
	public virtual void Refresh()
	{
	}

	// Token: 0x040043DA RID: 17370
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040043DB RID: 17371
	protected TrialRoleInfo? TrialRoleInfo;

	// Token: 0x040043DC RID: 17372
	protected int RoleId;
}
