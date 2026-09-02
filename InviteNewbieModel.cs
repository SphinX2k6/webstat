using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x0200133F RID: 4927
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class InviteNewbieModel : ModelBase<InviteNewbieModel>
{
	// Token: 0x06008691 RID: 34449 RVA: 0x00237266 File Offset: 0x00235466
	protected override bool OnInit()
	{
		this.ProtocolContext = new InviteNewbieProtocolContext(this);
		return true;
	}

	// Token: 0x06008692 RID: 34450 RVA: 0x00237275 File Offset: 0x00235475
	protected override bool OnClear()
	{
		InviteNewbieProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext != null)
		{
			protocolContext.Dispose();
		}
		this.ProtocolContext = null;
		return true;
	}

	// Token: 0x17000B75 RID: 2933
	// (get) Token: 0x06008693 RID: 34451 RVA: 0x00237290 File Offset: 0x00235490
	public ActivityBaseData ActivityData
	{
		get
		{
			if (this.ProtocolContext == null)
			{
				this.ProtocolContext = new InviteNewbieProtocolContext(this);
			}
			return this.ProtocolContext;
		}
	}

	// Token: 0x17000B76 RID: 2934
	// (get) Token: 0x06008694 RID: 34452 RVA: 0x002372AC File Offset: 0x002354AC
	public int CurrentActivityId
	{
		get
		{
			InviteNewbieProtocolContext protocolContext = this.ProtocolContext;
			if (protocolContext == null)
			{
				return 0;
			}
			return protocolContext.Id;
		}
	}

	// Token: 0x17000B77 RID: 2935
	// (get) Token: 0x06008695 RID: 34453 RVA: 0x002372BF File Offset: 0x002354BF
	public bool HasRedDot
	{
		get
		{
			InviteNewbieProtocolContext protocolContext = this.ProtocolContext;
			return protocolContext != null && protocolContext.RedPointShowState;
		}
	}

	// Token: 0x06008696 RID: 34454 RVA: 0x002372D2 File Offset: 0x002354D2
	public void SaveClickState()
	{
		InviteNewbieProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext == null)
		{
			return;
		}
		protocolContext.SaveClickRedDotState();
	}

	// Token: 0x17000B78 RID: 2936
	// (get) Token: 0x06008697 RID: 34455 RVA: 0x002372E4 File Offset: 0x002354E4
	public int HelpId
	{
		get
		{
			InviteNewbieProtocolContext protocolContext = this.ProtocolContext;
			if (protocolContext == null)
			{
				return 0;
			}
			return protocolContext.GetHelpId();
		}
	}

	// Token: 0x17000B79 RID: 2937
	// (get) Token: 0x06008698 RID: 34456 RVA: 0x002372F7 File Offset: 0x002354F7
	public string InviteCode
	{
		get
		{
			InviteNewbieProtocolContext protocolContext = this.ProtocolContext;
			return ((protocolContext != null) ? protocolContext.InviteCode : null) ?? "";
		}
	}

	// Token: 0x17000B7A RID: 2938
	// (get) Token: 0x06008699 RID: 34457 RVA: 0x00237314 File Offset: 0x00235514
	public string ScoreTextId
	{
		get
		{
			if (this.ProtocolContext == null)
			{
				return "";
			}
			H5CircumUrl? config = ConfigH5CircumUrlById.GetConfig(this.ProtocolContext.Id, true);
			return ((config != null) ? config.GetValueOrDefault().ScoreText : null) ?? " ";
		}
	}

	// Token: 0x17000B7B RID: 2939
	// (get) Token: 0x0600869A RID: 34458 RVA: 0x00237365 File Offset: 0x00235565
	public int Score
	{
		get
		{
			InviteNewbieProtocolContext protocolContext = this.ProtocolContext;
			if (protocolContext == null)
			{
				return 0;
			}
			return protocolContext.Score;
		}
	}

	// Token: 0x17000B7C RID: 2940
	// (get) Token: 0x0600869B RID: 34459 RVA: 0x00237378 File Offset: 0x00235578
	[Nullable(2)]
	public string RootUrl
	{
		[NullableContext(2)]
		get
		{
			if (this.GmUrl != null && this.GmUrl != "")
			{
				return this.GmUrl;
			}
			if (this.ProtocolContext == null)
			{
				return null;
			}
			H5CircumUrl? config = ConfigH5CircumUrlById.GetConfig(this.ProtocolContext.Id, true);
			if (!ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
			{
				if (config == null)
				{
					return null;
				}
				return config.GetValueOrDefault().RootUrl;
			}
			else
			{
				if (config == null)
				{
					return null;
				}
				return config.GetValueOrDefault().OverseaRootUrl;
			}
		}
	}

	// Token: 0x17000B7D RID: 2941
	// (get) Token: 0x0600869C RID: 34460 RVA: 0x00237404 File Offset: 0x00235604
	public bool IsInternalBrowser
	{
		get
		{
			if (this.ProtocolContext == null)
			{
				return false;
			}
			H5CircumUrl? config = ConfigH5CircumUrlById.GetConfig(this.ProtocolContext.Id, true);
			return config != null && config.GetValueOrDefault().IsInternalBrowser;
		}
	}

	// Token: 0x0600869D RID: 34461 RVA: 0x00237448 File Offset: 0x00235648
	public void SyncActivityNotify(H5CircumFluenceActivityDataNotify notify)
	{
		H5CircumFluenceActivityData activityData = notify.ActivityData;
		if (this.ProtocolContext != null)
		{
			this.ProtocolContext.InviteCode = ((activityData != null) ? activityData.InviteCode : null);
			this.ProtocolContext.Score = ((activityData != null) ? activityData.Score : 0);
			this.ProtocolContext.ChangeServerRedDotState(activityData != null && activityData.RedDot);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.CurrentActivityId);
	}

	// Token: 0x04003F95 RID: 16277
	[Nullable(2)]
	public string GmUrl;

	// Token: 0x04003F96 RID: 16278
	[Nullable(2)]
	private InviteNewbieProtocolContext ProtocolContext;
}
