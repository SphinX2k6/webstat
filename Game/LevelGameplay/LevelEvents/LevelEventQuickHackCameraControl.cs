using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.QuickHack;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BD0 RID: 27600
	public class LevelEventQuickHackCameraControl : LevelEventBase
	{
		// Token: 0x06044081 RID: 278657 RVA: 0x011A5583 File Offset: 0x011A3783
		public LevelEventQuickHackCameraControl(int id) : base(id)
		{
		}

		// Token: 0x06044082 RID: 278658 RVA: 0x011A558C File Offset: 0x011A378C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			OpenQuickHackSystem openQuickHackSystem = inParams as OpenQuickHackSystem;
			if (openQuickHackSystem == null)
			{
				return;
			}
			if (openQuickHackSystem.CameraConfig == null || openQuickHackSystem.Entities == null)
			{
				EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				if (getCurrentEntity != null && getCurrentEntity.Valid)
				{
					ControllerBase<QuickHackController>.Instance.CloseQuickHack();
					ControllerBase<QuickHackController>.Instance.OpenQuickHack(openQuickHackSystem.DeviceId, getCurrentEntity.Id, true, null, null);
				}
				return;
			}
			EntityContext entityContext = context as EntityContext;
			if (entityContext == null)
			{
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityContext.EntityId.GetValueOrDefault());
			if (entityById == null || !entityById.Valid)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "QuickHackCameraControl 实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityContext.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ControllerBase<QuickHackController>.Instance.OpenQuickHackCameraControl(entityById.Entity.GetComponent<CreatureDataComponent>().GetPbDataId(), openQuickHackSystem);
		}
	}
}
