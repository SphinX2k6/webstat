using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200267C RID: 9852
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestReviewController : ControllerBase<QuestReviewController>
{
	// Token: 0x060136F2 RID: 79602 RVA: 0x0056A246 File Offset: 0x00568446
	protected override bool OnInit()
	{
		this.AddListeners();
		this.BurnFinishPromise = new CustomPromise<object>();
		this.FusionFinishPromise = new CustomPromise<object>();
		this.NewTabUnlockPromise = new CustomPromise<object>();
		return true;
	}

	// Token: 0x060136F3 RID: 79603 RVA: 0x0056A270 File Offset: 0x00568470
	protected override bool OnClear()
	{
		this.ViewRefreshDelegates.Clear();
		this.RemoveListeners();
		return true;
	}

	// Token: 0x060136F4 RID: 79604 RVA: 0x0056A284 File Offset: 0x00568484
	public void AddViewRefreshDelegate(Action<int?> @delegate)
	{
		this.ViewRefreshDelegates.Add(@delegate);
	}

	// Token: 0x060136F5 RID: 79605 RVA: 0x0056A294 File Offset: 0x00568494
	public void RemoveViewRefreshDelegate(Action<int?> @delegate)
	{
		int num = this.ViewRefreshDelegates.IndexOf(@delegate);
		if (num >= 0)
		{
			this.ViewRefreshDelegates.RemoveAt(num);
		}
	}

	// Token: 0x060136F6 RID: 79606 RVA: 0x0056A2C0 File Offset: 0x005684C0
	public void TriggerViewRefresh(int tabId = 0)
	{
		foreach (Action<int?> action in this.ViewRefreshDelegates)
		{
			action(new int?(tabId));
		}
	}

	// Token: 0x060136F7 RID: 79607 RVA: 0x0056A318 File Offset: 0x00568518
	public void OpenQuestReview(int entryId, bool useLoopMusic = true)
	{
		QuestReviewEntryData questReviewEntryDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewEntryDataById(entryId);
		if (questReviewEntryDataById != null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestReviewMainView, new object[]
			{
				questReviewEntryDataById,
				useLoopMusic
			}, null);
		}
	}

	// Token: 0x060136F8 RID: 79608 RVA: 0x0056A358 File Offset: 0x00568558
	[NullableContext(0)]
	public UniTask<bool> OpenQuestReviewAsync(int entryId, bool useLoopMusic = true)
	{
		QuestReviewController.<OpenQuestReviewAsync>d__7 <OpenQuestReviewAsync>d__;
		<OpenQuestReviewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenQuestReviewAsync>d__.entryId = entryId;
		<OpenQuestReviewAsync>d__.useLoopMusic = useLoopMusic;
		<OpenQuestReviewAsync>d__.<>1__state = -1;
		<OpenQuestReviewAsync>d__.<>t__builder.Start<QuestReviewController.<OpenQuestReviewAsync>d__7>(ref <OpenQuestReviewAsync>d__);
		return <OpenQuestReviewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060136F9 RID: 79609 RVA: 0x0056A3A4 File Offset: 0x005685A4
	[NullableContext(0)]
	public UniTask<bool> OpenQuestReviewTipsViewAsync(int entryId, int nodeId)
	{
		QuestReviewController.<OpenQuestReviewTipsViewAsync>d__8 <OpenQuestReviewTipsViewAsync>d__;
		<OpenQuestReviewTipsViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenQuestReviewTipsViewAsync>d__.entryId = entryId;
		<OpenQuestReviewTipsViewAsync>d__.nodeId = nodeId;
		<OpenQuestReviewTipsViewAsync>d__.<>1__state = -1;
		<OpenQuestReviewTipsViewAsync>d__.<>t__builder.Start<QuestReviewController.<OpenQuestReviewTipsViewAsync>d__8>(ref <OpenQuestReviewTipsViewAsync>d__);
		return <OpenQuestReviewTipsViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060136FA RID: 79610 RVA: 0x0056A3F0 File Offset: 0x005685F0
	public void OpenQuestNodeDetail(int nodeId)
	{
		QuestReviewNodeData questReviewNodeDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewNodeDataById(nodeId);
		if (questReviewNodeDataById != null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestReviewDetailView, questReviewNodeDataById, null);
		}
	}

	// Token: 0x060136FB RID: 79611 RVA: 0x0056A41D File Offset: 0x0056861D
	private void AddListeners()
	{
		Singleton<Net>.Instance.Register<QuestReviewInfoNotify>(ENotifyMessageId.QuestReviewInfoNotify, this.OnQuestReviewInfoNotify);
		Singleton<EventSystem>.Instance.Add(EEventName.EnterGameSuccess, this.OnEnterGameSuccess);
	}

	// Token: 0x060136FC RID: 79612 RVA: 0x0056A448 File Offset: 0x00568648
	private void RemoveListeners()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.EnterGameSuccess, this.OnEnterGameSuccess);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestReviewInfoNotify);
	}

	// Token: 0x060136FD RID: 79613 RVA: 0x0056A470 File Offset: 0x00568670
	public UniTask RequestQuestReviewData()
	{
		QuestReviewController.<RequestQuestReviewData>d__13 <RequestQuestReviewData>d__;
		<RequestQuestReviewData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestQuestReviewData>d__.<>1__state = -1;
		<RequestQuestReviewData>d__.<>t__builder.Start<QuestReviewController.<RequestQuestReviewData>d__13>(ref <RequestQuestReviewData>d__);
		return <RequestQuestReviewData>d__.<>t__builder.Task;
	}

	// Token: 0x1700185E RID: 6238
	// (get) Token: 0x060136FE RID: 79614 RVA: 0x0056A4AB File Offset: 0x005686AB
	// (set) Token: 0x060136FF RID: 79615 RVA: 0x0056A4B3 File Offset: 0x005686B3
	public CustomPromise<object> BurnFinishPromise { get; set; }

	// Token: 0x1700185F RID: 6239
	// (get) Token: 0x06013700 RID: 79616 RVA: 0x0056A4BC File Offset: 0x005686BC
	// (set) Token: 0x06013701 RID: 79617 RVA: 0x0056A4C4 File Offset: 0x005686C4
	public CustomPromise<object> FusionFinishPromise { get; set; }

	// Token: 0x17001860 RID: 6240
	// (get) Token: 0x06013702 RID: 79618 RVA: 0x0056A4CD File Offset: 0x005686CD
	// (set) Token: 0x06013703 RID: 79619 RVA: 0x0056A4D5 File Offset: 0x005686D5
	public CustomPromise<object> NewTabUnlockPromise { get; set; }

	// Token: 0x06013704 RID: 79620 RVA: 0x0056A4DE File Offset: 0x005686DE
	public void SetBurnFinish()
	{
		if (this.BurnFinishPromise != null)
		{
			this.BurnFinishPromise.SetResult(null);
			this.BurnFinishPromise = null;
		}
	}

	// Token: 0x06013705 RID: 79621 RVA: 0x0056A4FB File Offset: 0x005686FB
	public void SetFusionFinish()
	{
		if (this.FusionFinishPromise != null)
		{
			this.FusionFinishPromise.SetResult(null);
			this.FusionFinishPromise = null;
			ControllerBase<QuestReviewController>.Instance.TriggerViewRefresh(-1);
		}
	}

	// Token: 0x06013706 RID: 79622 RVA: 0x0056A523 File Offset: 0x00568723
	public void SetNewTabUnlockFinish()
	{
		if (this.NewTabUnlockPromise != null)
		{
			this.NewTabUnlockPromise.SetResult(null);
			this.NewTabUnlockPromise = null;
			ControllerBase<QuestReviewController>.Instance.TriggerViewRefresh(-2);
		}
	}

	// Token: 0x06013707 RID: 79623 RVA: 0x0056A54C File Offset: 0x0056874C
	public void GmResetBurn()
	{
		this.SetBurnFinish();
		this.SetFusionFinish();
		this.BurnFinishPromise = new CustomPromise<object>();
		this.FusionFinishPromise = new CustomPromise<object>();
		this.NewTabUnlockPromise = new CustomPromise<object>();
		ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3200).HasFused = false;
		ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3200).IsFirstTimeShow = true;
		ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3100).IsFirstTimeDestroy = true;
		ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3400).IsFirstTimeDestroy = true;
		ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3500).IsFirstTimeDestroy = true;
		ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3600).IsFirstTimeDestroy = true;
		ModelBase<QuestReviewModel>.Instance.GetQuestReviewTabDataById(3).IsFirstTimeShow = true;
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.QuestReviewHasFused, false);
	}

	// Token: 0x0400977F RID: 38783
	private readonly List<Action<int?>> ViewRefreshDelegates = new List<Action<int?>>();

	// Token: 0x04009780 RID: 38784
	private readonly Action OnEnterGameSuccess = delegate()
	{
		ControllerBase<QuestReviewController>.Instance.RequestQuestReviewData();
	};

	// Token: 0x04009781 RID: 38785
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private readonly Action<QuestReviewInfoNotify, Net.CallbackStatus> OnQuestReviewInfoNotify = delegate(QuestReviewInfoNotify msg, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<QuestReviewModel>.Instance.UpdateAllQuestReviewEntryData(msg.EntryInfos.ToList<QuestReviewEntryInfo>());
		ModelBase<QuestReviewModel>.Instance.UpdateAllQuestReviewTabData(msg.TabInfos.ToList<QuestReviewTabInfo>());
		ModelBase<QuestReviewModel>.Instance.UpdateAllQuestReviewLineData(msg.LineInfos.ToList<QuestReviewLineInfo>());
		ModelBase<QuestReviewModel>.Instance.UpdateAllQuestReviewNodeData(msg.NodeInfos.ToList<QuestReviewNodeInfo>());
	};
}
