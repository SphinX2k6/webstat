using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.SlidingBlocks;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CF3 RID: 23795
	public class SlidingBlocksNode : ChildQuestNodeBase
	{
		// Token: 0x0603BFC6 RID: 245702 RVA: 0x00F36418 File Offset: 0x00F34618
		public SlidingBlocksNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFC7 RID: 245703 RVA: 0x00F36424 File Offset: 0x00F34624
		[NullableContext(1)]
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			IFinishTetris finishTetris = childQuestBtNode.Condition as IFinishTetris;
			if (finishTetris == null)
			{
				return false;
			}
			this.Config = finishTetris;
			return true;
		}

		// Token: 0x0603BFC8 RID: 245704 RVA: 0x00F36461 File Offset: 0x00F34661
		protected override void OnNodeActive()
		{
			base.OnNodeActive();
			ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.SlidingBlocks, ELoadingPerform.CameraFade, null, null, Array.Empty<object>());
		}

		// Token: 0x0603BFC9 RID: 245705 RVA: 0x00F3647D File Offset: 0x00F3467D
		protected override void OnStart(ENodeStatusUpdateReason reason)
		{
			base.OnStart(reason);
			this.StartGameAsync().Forget();
		}

		// Token: 0x0603BFCA RID: 245706 RVA: 0x00F36491 File Offset: 0x00F34691
		protected override void OnEnd(bool bFinished)
		{
			ControllerBase<SlidingBlocksController>.Instance.OnGameEnd(bFinished);
		}

		// Token: 0x0603BFCB RID: 245707 RVA: 0x00F3649E File Offset: 0x00F3469E
		protected override void OnDestroy()
		{
			ControllerBase<SlidingBlocksController>.Instance.DestroyGameplay();
		}

		// Token: 0x0603BFCC RID: 245708 RVA: 0x00F364AC File Offset: 0x00F346AC
		private UniTask StartGameAsync()
		{
			SlidingBlocksNode.<StartGameAsync>d__7 <StartGameAsync>d__;
			<StartGameAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartGameAsync>d__.<>4__this = this;
			<StartGameAsync>d__.<>1__state = -1;
			<StartGameAsync>d__.<>t__builder.Start<SlidingBlocksNode.<StartGameAsync>d__7>(ref <StartGameAsync>d__);
			return <StartGameAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04021B3D RID: 138045
		[Nullable(2)]
		private IFinishTetris Config;
	}
}
