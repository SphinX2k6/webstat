using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02001C20 RID: 7200
public class FloroRanchGameExitState : FloroRanchStateBase
{
	// Token: 0x0600D164 RID: 53604 RVA: 0x00379232 File Offset: 0x00377432
	[NullableContext(1)]
	public FloroRanchGameExitState(FloroRanchStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x0600D165 RID: 53605 RVA: 0x0037923C File Offset: 0x0037743C
	protected override void OnEnter()
	{
		if (ModelBase<FloroRanchGamePlayModel>.Instance.NeedReStart)
		{
			ControllerBase<BlackScreenController>.Instance.AddBlackScreenAsync("Start", "FloroRanch Restart", "Black").ContinueWith(delegate()
			{
				this.CloseView();
			}).Forget();
			return;
		}
		this.CloseView();
	}

	// Token: 0x0600D166 RID: 53606 RVA: 0x0037928C File Offset: 0x0037748C
	private void CloseView()
	{
		int activityId = ModelBase<FloroRanchGamePlayModel>.Instance.ActivityId;
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		List<int> races = new List<int>(ModelBase<FloroRanchGamePlayModel>.Instance.Races);
		int skillId = ModelBase<FloroRanchGamePlayModel>.Instance.SkillId;
		bool needReStart = ModelBase<FloroRanchGamePlayModel>.Instance.NeedReStart;
		bool needSettle = ModelBase<FloroRanchGamePlayModel>.Instance.NeedSettle;
		Singleton<UiManager>.Instance.CloseView(EUiViewName.FloroRanchGamePlayView, delegate(bool _)
		{
			FloroRanchEntityActionSystem.Exit();
			if (needReStart)
			{
				ModelBase<FloroRanchGamePlayModel>.Instance.GameEnd();
				ControllerBase<FloroRanchController>.Instance.SendFloroRanchReStartRequest(activityId, subInstanceId, races.ToArray(), skillId).ContinueWith(delegate()
				{
					ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "FloroRanch Restart");
				}).Forget();
				return;
			}
			if (needSettle)
			{
				ControllerBase<FloroRanchController>.Instance.SendFloroRanchSettleRequest(activityId, subInstanceId, true, delegate(FloroRanchSettleResponse _)
				{
				});
				return;
			}
			ModelBase<FloroRanchGamePlayModel>.Instance.GameEnd();
		});
	}
}
