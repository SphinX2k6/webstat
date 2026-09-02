using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.QuestMultiLine
{
	// Token: 0x02005313 RID: 21267
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class QuestMultiLineController : ControllerBase<QuestMultiLineController>
	{
		// Token: 0x060364A6 RID: 222374 RVA: 0x00DAF3FE File Offset: 0x00DAD5FE
		protected override bool OnInit()
		{
			this.RegisterListeners();
			return true;
		}

		// Token: 0x060364A7 RID: 222375 RVA: 0x00DAF407 File Offset: 0x00DAD607
		protected override bool OnClear()
		{
			this.UnregisterListeners();
			return true;
		}

		// Token: 0x060364A8 RID: 222376 RVA: 0x00DAF410 File Offset: 0x00DAD610
		public void OpenViewWithTestData()
		{
			this.OpenQuestMultiLineView(0, true, false);
		}

		// Token: 0x060364A9 RID: 222377 RVA: 0x00DAF41C File Offset: 0x00DAD61C
		public UniTask SendSelectBranchRequest(int branchPageId, int branchId)
		{
			QuestMultiLineController.<SendSelectBranchRequest>d__3 <SendSelectBranchRequest>d__;
			<SendSelectBranchRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendSelectBranchRequest>d__.branchPageId = branchPageId;
			<SendSelectBranchRequest>d__.branchId = branchId;
			<SendSelectBranchRequest>d__.<>1__state = -1;
			<SendSelectBranchRequest>d__.<>t__builder.Start<QuestMultiLineController.<SendSelectBranchRequest>d__3>(ref <SendSelectBranchRequest>d__);
			return <SendSelectBranchRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060364AA RID: 222378 RVA: 0x00DAF468 File Offset: 0x00DAD668
		public UniTask<int?> OpenQuestMultiLineView(int timePointId = 0, bool playTimePointComponentAnim = false, bool byPlot = false)
		{
			QuestMultiLineController.<OpenQuestMultiLineView>d__4 <OpenQuestMultiLineView>d__;
			<OpenQuestMultiLineView>d__.<>t__builder = AsyncUniTaskMethodBuilder<int?>.Create();
			<OpenQuestMultiLineView>d__.timePointId = timePointId;
			<OpenQuestMultiLineView>d__.playTimePointComponentAnim = playTimePointComponentAnim;
			<OpenQuestMultiLineView>d__.byPlot = byPlot;
			<OpenQuestMultiLineView>d__.<>1__state = -1;
			<OpenQuestMultiLineView>d__.<>t__builder.Start<QuestMultiLineController.<OpenQuestMultiLineView>d__4>(ref <OpenQuestMultiLineView>d__);
			return <OpenQuestMultiLineView>d__.<>t__builder.Task;
		}

		// Token: 0x060364AB RID: 222379 RVA: 0x00DAF4BC File Offset: 0x00DAD6BC
		public UniTask<bool> OpenQuestMultiLineTipsViewAsync(int timePointId, bool byPlot = false, bool enableAnimation = false)
		{
			QuestMultiLineController.<OpenQuestMultiLineTipsViewAsync>d__5 <OpenQuestMultiLineTipsViewAsync>d__;
			<OpenQuestMultiLineTipsViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenQuestMultiLineTipsViewAsync>d__.timePointId = timePointId;
			<OpenQuestMultiLineTipsViewAsync>d__.byPlot = byPlot;
			<OpenQuestMultiLineTipsViewAsync>d__.enableAnimation = enableAnimation;
			<OpenQuestMultiLineTipsViewAsync>d__.<>1__state = -1;
			<OpenQuestMultiLineTipsViewAsync>d__.<>t__builder.Start<QuestMultiLineController.<OpenQuestMultiLineTipsViewAsync>d__5>(ref <OpenQuestMultiLineTipsViewAsync>d__);
			return <OpenQuestMultiLineTipsViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060364AC RID: 222380 RVA: 0x00DAF50F File Offset: 0x00DAD70F
		private void RegisterListeners()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.EnterGameSuccess, new Action(this.OnEnterGameSuccess));
			Singleton<Net>.Instance.Register<QuestBranchUpdateNotify>(ENotifyMessageId.QuestBranchUpdateNotify, new Action<QuestBranchUpdateNotify, Net.CallbackStatus>(this.OnQuestTimePointUpdateNotify));
		}

		// Token: 0x060364AD RID: 222381 RVA: 0x00DAF546 File Offset: 0x00DAD746
		private void UnregisterListeners()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.EnterGameSuccess, new Action(this.OnEnterGameSuccess));
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestBranchUpdateNotify);
		}

		// Token: 0x060364AE RID: 222382 RVA: 0x00DAF571 File Offset: 0x00DAD771
		[NullableContext(1)]
		private void OnQuestTimePointUpdateNotify(QuestBranchUpdateNotify msg, [Nullable(2)] Net.CallbackStatus status)
		{
			if (msg.QuestBranchInfo != null)
			{
				ModelBase<QuestMultiLineModel>.Instance.AddData(msg.QuestBranchInfo);
			}
		}

		// Token: 0x060364AF RID: 222383 RVA: 0x00DAF58B File Offset: 0x00DAD78B
		private void OnEnterGameSuccess()
		{
			this.RequestQuestBranchData();
		}

		// Token: 0x060364B0 RID: 222384 RVA: 0x00DAF594 File Offset: 0x00DAD794
		public UniTask RequestQuestBranchData()
		{
			QuestMultiLineController.<RequestQuestBranchData>d__10 <RequestQuestBranchData>d__;
			<RequestQuestBranchData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestQuestBranchData>d__.<>1__state = -1;
			<RequestQuestBranchData>d__.<>t__builder.Start<QuestMultiLineController.<RequestQuestBranchData>d__10>(ref <RequestQuestBranchData>d__);
			return <RequestQuestBranchData>d__.<>t__builder.Task;
		}
	}
}
