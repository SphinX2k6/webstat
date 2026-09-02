using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.RoleUi;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B7B RID: 27515
	public class LevelEventClientChangeTeamPosition : LevelEventBase
	{
		// Token: 0x06043F00 RID: 278272 RVA: 0x01198441 File Offset: 0x01196641
		public LevelEventClientChangeTeamPosition(int id) : base(id)
		{
		}

		// Token: 0x06043F01 RID: 278273 RVA: 0x0119844C File Offset: 0x0119664C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ClientChangeTeamPosition clientChangeTeamPosition = inParams as ClientChangeTeamPosition;
			int roleId = clientChangeTeamPosition.PositionId;
			if (ModelBase<SceneTeamModel>.Instance.IsTeamReady)
			{
				this.ChangeRole(roleId);
				return;
			}
			this.WaitUpdateSceneTeam().ContinueWith(delegate(bool r)
			{
				this.ChangeRole(roleId);
			});
		}

		// Token: 0x06043F02 RID: 278274 RVA: 0x011984AA File Offset: 0x011966AA
		private UniTask<bool> WaitUpdateSceneTeam()
		{
			GameModePromise loadTeamPromise = ModelBase<SceneTeamModel>.Instance.LoadTeamPromise;
			if (loadTeamPromise == null)
			{
				return UniTask.FromResult<bool>(true);
			}
			return loadTeamPromise.Promise;
		}

		// Token: 0x06043F03 RID: 278275 RVA: 0x011984C8 File Offset: 0x011966C8
		private void ChangeRole(int roleId)
		{
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(true))
			{
				if (ConfigBase<RoleConfig>.Instance.GetBaseRoleId(sceneTeamItem.GetConfigId) == roleId)
				{
					ControllerBase<SceneTeamController>.Instance.RequestChangeRole(sceneTeamItem.GetCreatureDataId(), null);
					break;
				}
			}
			base.FinishExecute(true, false, true);
		}
	}
}
