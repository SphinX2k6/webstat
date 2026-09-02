using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063CB RID: 25547
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class RoverlikeActionSubViewBase : UiPanelBase
	{
		// Token: 0x17009DAD RID: 40365
		// (get) Token: 0x06040243 RID: 262723
		public abstract ERoverActionSubViewType SubViewType { get; }

		// Token: 0x17009DAE RID: 40366
		// (get) Token: 0x06040244 RID: 262724
		public abstract string ResourceId { get; }

		// Token: 0x17009DAF RID: 40367
		// (get) Token: 0x06040245 RID: 262725 RVA: 0x01070086 File Offset: 0x0106E286
		public ERoverlikeActionSubViewState State
		{
			get
			{
				return this.ViewState;
			}
		}

		// Token: 0x06040246 RID: 262726 RVA: 0x0107008E File Offset: 0x0106E28E
		public void SetState(ERoverlikeActionSubViewState state)
		{
			this.ViewState = state;
		}

		// Token: 0x17009DB0 RID: 40368
		// (get) Token: 0x06040247 RID: 262727 RVA: 0x01070097 File Offset: 0x0106E297
		public bool Finished
		{
			get
			{
				return this.ViewState == ERoverlikeActionSubViewState.Finished;
			}
		}

		// Token: 0x06040248 RID: 262728 RVA: 0x010700A2 File Offset: 0x0106E2A2
		protected override void OnBeforeCreateImplement()
		{
			this.UiViewSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiViewSequence);
		}

		// Token: 0x06040249 RID: 262729 RVA: 0x010700BC File Offset: 0x0106E2BC
		protected override UniTask OnShowAsyncImplementImplement()
		{
			RoverlikeActionSubViewBase.<OnShowAsyncImplementImplement>d__14 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<RoverlikeActionSubViewBase.<OnShowAsyncImplementImplement>d__14>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0604024A RID: 262730 RVA: 0x01070100 File Offset: 0x0106E300
		protected override UniTask OnHideAsyncImplementImplement()
		{
			RoverlikeActionSubViewBase.<OnHideAsyncImplementImplement>d__15 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<RoverlikeActionSubViewBase.<OnHideAsyncImplementImplement>d__15>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0604024B RID: 262731 RVA: 0x01070144 File Offset: 0x0106E344
		protected UniTask PlaySequenceAsync(string sequenceName, bool blockClick = false, bool playReverse = false, float? playRate = null)
		{
			RoverlikeActionSubViewBase.<PlaySequenceAsync>d__16 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.blockClick = blockClick;
			<PlaySequenceAsync>d__.playReverse = playReverse;
			<PlaySequenceAsync>d__.playRate = playRate;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<RoverlikeActionSubViewBase.<PlaySequenceAsync>d__16>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604024C RID: 262732 RVA: 0x010701A8 File Offset: 0x0106E3A8
		public virtual void OnRefreshSubView()
		{
		}

		// Token: 0x0604024D RID: 262733 RVA: 0x010701AA File Offset: 0x0106E3AA
		public virtual void OnCoveredBySubView()
		{
		}

		// Token: 0x0604024E RID: 262734 RVA: 0x010701AC File Offset: 0x0106E3AC
		public virtual void OnUncoveredSubView()
		{
		}

		// Token: 0x0604024F RID: 262735 RVA: 0x010701B0 File Offset: 0x0106E3B0
		protected bool TryInteractAction(Action action)
		{
			RoverlikeActionStack actionStack = this.GetActionStack();
			return actionStack != null && actionStack.TryAction(this, action);
		}

		// Token: 0x06040250 RID: 262736 RVA: 0x010701D1 File Offset: 0x0106E3D1
		[NullableContext(2)]
		private RoverlikeActionStack GetActionStack()
		{
			RoverlikeModel instance = ModelBase<RoverlikeModel>.Instance;
			if (instance == null)
			{
				return null;
			}
			return instance.ActionStack;
		}

		// Token: 0x04023FE0 RID: 147424
		public int IncId;

		// Token: 0x04023FE1 RID: 147425
		private ERoverlikeActionSubViewState ViewState;

		// Token: 0x04023FE2 RID: 147426
		[Nullable(2)]
		protected UiBehaviorLevelSequence UiViewSequence;

		// Token: 0x04023FE3 RID: 147427
		private bool IsFirstShow = true;
	}
}
