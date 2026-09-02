using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FA2 RID: 28578
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelFlowQteAction : LevelFlowActionBase
	{
		// Token: 0x06045202 RID: 283138 RVA: 0x012091A7 File Offset: 0x012073A7
		[return: Nullable(1)]
		public LevelFlowQteAction Init(int qteId, LevelFlowActionBase successSequenceAction, LevelFlowActionBase failSequenceAction)
		{
			this.QteId = qteId;
			this.SuccessSequenceAction = successSequenceAction;
			this.FailSequenceAction = failSequenceAction;
			return this;
		}

		// Token: 0x06045203 RID: 283139 RVA: 0x012091C0 File Offset: 0x012073C0
		protected override void OnExecute()
		{
			CommonQteContextBase activeQteContext = this.ActiveQteContext;
			if (activeQteContext != null && activeQteContext.IsActive())
			{
				ControllerBase<CommonQteController>.Instance.StopQte(this.ActiveQteContext.HandleId);
			}
			this.IsQteFinished = false;
			this.IsQteSuccess = false;
			this.ActiveQteContext = ControllerBase<CommonQteController>.Instance.StartQte(this.QteId, new TCommonQteCallback(this.OnQteSuccess), new TCommonQteCallback(this.OnQteFailed), EQteSource.Level, null);
		}

		// Token: 0x06045204 RID: 283140 RVA: 0x01209234 File Offset: 0x01207434
		protected override void OnTick(float deltaTime)
		{
			if (!this.IsQteFinished)
			{
				return;
			}
			if (this.IsQteSuccess)
			{
				if (this.SuccessSequenceAction != null)
				{
					this.SuccessSequenceAction.Tick(deltaTime);
					return;
				}
			}
			else if (this.FailSequenceAction != null)
			{
				this.FailSequenceAction.Tick(deltaTime);
			}
		}

		// Token: 0x06045205 RID: 283141 RVA: 0x01209270 File Offset: 0x01207470
		protected override void OnComplete(bool isSuccess)
		{
			this.IsQteFinished = false;
			this.IsQteSuccess = false;
			this.ActiveQteContext = null;
		}

		// Token: 0x06045206 RID: 283142 RVA: 0x01209288 File Offset: 0x01207488
		private void OnQteSuccess(CommonQteContextBase context)
		{
			Singleton<Log>.Instance.Info(ELogModule.LevelFlow, ELogAuthor.BB, "Qte成功", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsQteFinished = true;
			this.IsQteSuccess = true;
			this.ActiveQteContext = null;
			if (this.SuccessSequenceAction != null)
			{
				this.SuccessSequenceAction.BindCompleteCallBack(new Action<LevelFlowActionBase, bool>(this.OnSuccessActionComplete));
				this.SuccessSequenceAction.Execute();
				return;
			}
			base.FinishExecute(true);
		}

		// Token: 0x06045207 RID: 283143 RVA: 0x012092FC File Offset: 0x012074FC
		private void OnQteFailed(CommonQteContextBase context)
		{
			Singleton<Log>.Instance.Info(ELogModule.LevelFlow, ELogAuthor.BB, "Qte失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsQteFinished = true;
			this.IsQteSuccess = false;
			this.ActiveQteContext = null;
			if (this.FailSequenceAction != null)
			{
				this.FailSequenceAction.BindCompleteCallBack(new Action<LevelFlowActionBase, bool>(this.OnFailActionComplete));
				this.FailSequenceAction.Execute();
				return;
			}
			base.FinishExecute(true);
		}

		// Token: 0x06045208 RID: 283144 RVA: 0x0120936F File Offset: 0x0120756F
		protected override void OnReset()
		{
			LevelFlowActionBase successSequenceAction = this.SuccessSequenceAction;
			if (successSequenceAction != null)
			{
				successSequenceAction.Reset();
			}
			LevelFlowActionBase failSequenceAction = this.FailSequenceAction;
			if (failSequenceAction == null)
			{
				return;
			}
			failSequenceAction.Reset();
		}

		// Token: 0x06045209 RID: 283145 RVA: 0x01209392 File Offset: 0x01207592
		[NullableContext(1)]
		private void OnSuccessActionComplete(LevelFlowActionBase section, bool isSuccess)
		{
			base.FinishExecute(isSuccess);
		}

		// Token: 0x0604520A RID: 283146 RVA: 0x0120939B File Offset: 0x0120759B
		[NullableContext(1)]
		private void OnFailActionComplete(LevelFlowActionBase section, bool isSuccess)
		{
			base.FinishExecute(isSuccess);
		}

		// Token: 0x04026918 RID: 157976
		private int QteId;

		// Token: 0x04026919 RID: 157977
		private bool IsQteFinished;

		// Token: 0x0402691A RID: 157978
		private bool IsQteSuccess;

		// Token: 0x0402691B RID: 157979
		private CommonQteContextBase ActiveQteContext;

		// Token: 0x0402691C RID: 157980
		private LevelFlowActionBase SuccessSequenceAction;

		// Token: 0x0402691D RID: 157981
		private LevelFlowActionBase FailSequenceAction;
	}
}
