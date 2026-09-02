using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001CED RID: 7405
[NullableContext(2)]
[Nullable(0)]
public class GachaPoolItem : UiPanelBase
{
	// Token: 0x0600D954 RID: 55636 RVA: 0x003A4659 File Offset: 0x003A2859
	public GachaPoolItem(GachaDefine.EGachaViewType gachaType)
	{
		this.GachaType = new GachaDefine.EGachaViewType?(gachaType);
	}

	// Token: 0x0600D955 RID: 55637 RVA: 0x003A466D File Offset: 0x003A286D
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600D956 RID: 55638 RVA: 0x003A4680 File Offset: 0x003A2880
	public UniTask PlayStartSeqAsync()
	{
		GachaPoolItem.<PlayStartSeqAsync>d__6 <PlayStartSeqAsync>d__;
		<PlayStartSeqAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayStartSeqAsync>d__.<>4__this = this;
		<PlayStartSeqAsync>d__.<>1__state = -1;
		<PlayStartSeqAsync>d__.<>t__builder.Start<GachaPoolItem.<PlayStartSeqAsync>d__6>(ref <PlayStartSeqAsync>d__);
		return <PlayStartSeqAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D957 RID: 55639 RVA: 0x003A46C4 File Offset: 0x003A28C4
	public void PlayStartSeq()
	{
		this.OnPlayStartSeq();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0600D958 RID: 55640 RVA: 0x003A46F6 File Offset: 0x003A28F6
	protected virtual void OnPlayStartSeq()
	{
	}

	// Token: 0x0600D959 RID: 55641 RVA: 0x003A46F8 File Offset: 0x003A28F8
	public void PlaySwitchSeq()
	{
		this.OnPlaySwitchSeq();
		this.LevelSequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
	}

	// Token: 0x0600D95A RID: 55642 RVA: 0x003A4728 File Offset: 0x003A2928
	public UniTask PlaySwitchSeqAsync()
	{
		GachaPoolItem.<PlaySwitchSeqAsync>d__10 <PlaySwitchSeqAsync>d__;
		<PlaySwitchSeqAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySwitchSeqAsync>d__.<>4__this = this;
		<PlaySwitchSeqAsync>d__.<>1__state = -1;
		<PlaySwitchSeqAsync>d__.<>t__builder.Start<GachaPoolItem.<PlaySwitchSeqAsync>d__10>(ref <PlaySwitchSeqAsync>d__);
		return <PlaySwitchSeqAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D95B RID: 55643 RVA: 0x003A476B File Offset: 0x003A296B
	protected virtual void OnPlaySwitchSeq()
	{
	}

	// Token: 0x0600D95C RID: 55644 RVA: 0x003A476D File Offset: 0x003A296D
	protected virtual UniTask OnPlayingSwitchSeqAsync()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D95D RID: 55645 RVA: 0x003A4774 File Offset: 0x003A2974
	[NullableContext(1)]
	public void Update(GachaPoolData gachaPoolData)
	{
		this.GachaPoolData = gachaPoolData;
		if (this.GachaPoolData == null)
		{
			return;
		}
		int id = this.GachaPoolData.PoolInfo.Id;
		this.GachaViewInfo = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(id);
		this.Refresh();
	}

	// Token: 0x0600D95E RID: 55646 RVA: 0x003A47B9 File Offset: 0x003A29B9
	public virtual void Refresh()
	{
	}

	// Token: 0x040067C0 RID: 26560
	protected GachaPoolData GachaPoolData;

	// Token: 0x040067C1 RID: 26561
	protected GachaViewInfo? GachaViewInfo;

	// Token: 0x040067C2 RID: 26562
	protected readonly GachaDefine.EGachaViewType? GachaType;

	// Token: 0x040067C3 RID: 26563
	protected LevelSequencePlayer LevelSequencePlayer;
}
