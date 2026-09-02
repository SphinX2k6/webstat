using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A05 RID: 27141
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventRestorePhantomFormation : LevelEventBase
	{
		// Token: 0x060433D4 RID: 275412 RVA: 0x01149C70 File Offset: 0x01147E70
		public LevelEventRestorePhantomFormation(int id) : base(id)
		{
		}

		// Token: 0x060433D5 RID: 275413 RVA: 0x01149C79 File Offset: 0x01147E79
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x060433D6 RID: 275414 RVA: 0x01149C84 File Offset: 0x01147E84
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
			if (!instance.IsPhantomTeam && instance.IsTeamReady)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.LYY, "[RestorePhantomFormation] 当前已是角色队伍", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(true, false, true);
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.LYY, "[RestorePhantomFormation] 开始等待队伍更新", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		}

		// Token: 0x060433D7 RID: 275415 RVA: 0x01149D14 File Offset: 0x01147F14
		private void OnUpdateSceneTeam()
		{
			bool flag = !ModelBase<SceneTeamModel>.Instance.IsPhantomTeam;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "[RestorePhantomFormation] 队伍更新完成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("isRole", flag);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
			base.FinishExecute(flag, false, true);
		}
	}
}
