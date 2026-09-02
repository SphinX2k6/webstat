using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A01 RID: 27137
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventChangePhantomFormation : LevelEventBase
	{
		// Token: 0x060433C0 RID: 275392 RVA: 0x0114983C File Offset: 0x01147A3C
		public LevelEventChangePhantomFormation(int id) : base(id)
		{
		}

		// Token: 0x060433C1 RID: 275393 RVA: 0x01149845 File Offset: 0x01147A45
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x060433C2 RID: 275394 RVA: 0x01149850 File Offset: 0x01147A50
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
			if (instance.IsPhantomTeam && instance.IsTeamReady)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.LYY, "[ChangePhantomFormation] 当前已是声骸队伍", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(true, false, true);
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.LYY, "[ChangePhantomFormation] 开始等待队伍更新", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		}

		// Token: 0x060433C3 RID: 275395 RVA: 0x011498E0 File Offset: 0x01147AE0
		private void OnUpdateSceneTeam()
		{
			bool isPhantomTeam = ModelBase<SceneTeamModel>.Instance.IsPhantomTeam;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "[ChangePhantomFormation] 队伍更新完成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("isPhantom", isPhantomTeam);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
			base.FinishExecute(isPhantomTeam, false, true);
		}
	}
}
