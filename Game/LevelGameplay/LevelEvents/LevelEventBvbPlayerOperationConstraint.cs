using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Guide;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B6E RID: 27502
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventBvbPlayerOperationConstraint : LevelEventBase, IPhantomArenaGuideFunc
	{
		// Token: 0x06043EC1 RID: 278209 RVA: 0x01193860 File Offset: 0x01191A60
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			BvbPlayerOperationConstraint bvbPlayerOperationConstraint = inParams as BvbPlayerOperationConstraint;
			if (bvbPlayerOperationConstraint == null)
			{
				return;
			}
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomArenaBattleView);
			if (viewByName != null)
			{
				PhantomArenaBattleProxy phantomArenaBattleProxy = viewByName.OpenParam as PhantomArenaBattleProxy;
				phantomArenaBattleProxy.GuideManager.RegisterGuideInterface(this);
				phantomArenaBattleProxy.GuideManager.RegisterBehaviorTreeGuideData(bvbPlayerOperationConstraint);
			}
		}

		// Token: 0x06043EC2 RID: 278210 RVA: 0x011938AD File Offset: 0x01191AAD
		public void FinishCurrentGuide()
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043EC3 RID: 278211 RVA: 0x011938B8 File Offset: 0x01191AB8
		public void ExitCurrentGuide()
		{
			base.FinishExecute(false, false, true);
		}

		// Token: 0x06043EC4 RID: 278212 RVA: 0x011938C3 File Offset: 0x01191AC3
		public LevelEventBvbPlayerOperationConstraint(int id) : base(id)
		{
		}

		// Token: 0x04025FC6 RID: 155590
		private Action FinishCurrentGuide1;

		// Token: 0x04025FC7 RID: 155591
		private Action ExitCurrentGuide1;
	}
}
