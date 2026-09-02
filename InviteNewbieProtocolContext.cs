using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001340 RID: 4928
[NullableContext(2)]
[Nullable(0)]
public class InviteNewbieProtocolContext : ActivityBaseData
{
	// Token: 0x17000B7E RID: 2942
	// (get) Token: 0x0600869F RID: 34463 RVA: 0x002374C7 File Offset: 0x002356C7
	// (set) Token: 0x060086A0 RID: 34464 RVA: 0x002374D0 File Offset: 0x002356D0
	public string InviteCode
	{
		get
		{
			return this.InviteCodeInternal;
		}
		set
		{
			this.InviteCodeInternal = value;
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.InviteNewbieInviteCodeChanged, value);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InviteNewbie;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "邀请码变更";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InviteCode", value);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x060086A1 RID: 34465 RVA: 0x0023751F File Offset: 0x0023571F
	[NullableContext(1)]
	public InviteNewbieProtocolContext(InviteNewbieModel model)
	{
		this.AttachedModel = model;
	}

	// Token: 0x060086A2 RID: 34466 RVA: 0x0023752E File Offset: 0x0023572E
	public void Dispose()
	{
	}

	// Token: 0x060086A3 RID: 34467 RVA: 0x00237530 File Offset: 0x00235730
	[NullableContext(1)]
	protected override void PhraseEx(ActivityData data)
	{
		H5CircumFluenceActivityData h5CircumFluenceData = data.H5CircumFluenceData;
		if (h5CircumFluenceData != null)
		{
			this.InviteCode = h5CircumFluenceData.InviteCode;
			this.Score = h5CircumFluenceData.Score;
			this.ChangeServerRedDotState(h5CircumFluenceData.RedDot);
		}
	}

	// Token: 0x17000B7F RID: 2943
	// (get) Token: 0x060086A4 RID: 34468 RVA: 0x0023756C File Offset: 0x0023576C
	public string BgPath
	{
		get
		{
			H5CircumUrl? config = ConfigH5CircumUrlById.GetConfig(base.Id, true);
			if (config == null)
			{
				return null;
			}
			return config.GetValueOrDefault().BgPath;
		}
	}

	// Token: 0x060086A5 RID: 34469 RVA: 0x002375A0 File Offset: 0x002357A0
	public void SetCurrentLoginClickState(bool state)
	{
		this.CurrentLoginClickState = state;
	}

	// Token: 0x060086A6 RID: 34470 RVA: 0x002375A9 File Offset: 0x002357A9
	public bool GetClickRedDotState()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, 0, 0) == 0;
	}

	// Token: 0x060086A7 RID: 34471 RVA: 0x002375C2 File Offset: 0x002357C2
	public void SaveClickRedDotState()
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 1, 0, 0, 1);
	}

	// Token: 0x060086A8 RID: 34472 RVA: 0x002375D8 File Offset: 0x002357D8
	public void ChangeServerRedDotState(bool state)
	{
		this.RedDotInternal = state;
	}

	// Token: 0x060086A9 RID: 34473 RVA: 0x002375E1 File Offset: 0x002357E1
	public override bool GetExDataRedPointShowState()
	{
		return this.GetClickRedDotState() || (this.RedDotInternal && !this.CurrentLoginClickState);
	}

	// Token: 0x04003F97 RID: 16279
	private const int CLICKKEY = 1;

	// Token: 0x04003F98 RID: 16280
	private string InviteCodeInternal;

	// Token: 0x04003F99 RID: 16281
	private bool RedDotInternal;

	// Token: 0x04003F9A RID: 16282
	private bool CurrentLoginClickState;

	// Token: 0x04003F9B RID: 16283
	public int Score;

	// Token: 0x04003F9C RID: 16284
	protected readonly InviteNewbieModel AttachedModel;
}
