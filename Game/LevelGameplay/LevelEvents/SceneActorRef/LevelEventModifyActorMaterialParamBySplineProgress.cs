using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.SceneActorRef
{
	// Token: 0x02006C36 RID: 27702
	public class LevelEventModifyActorMaterialParamBySplineProgress : LevelEventBase
	{
		// Token: 0x060441F6 RID: 279030 RVA: 0x011B0EFF File Offset: 0x011AF0FF
		public LevelEventModifyActorMaterialParamBySplineProgress(int id) : base(id)
		{
		}

		// Token: 0x060441F7 RID: 279031 RVA: 0x011B0F08 File Offset: 0x011AF108
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			EntityHandle entityHandle = LevelGamePlayUtils.GetEntityHandle(null, context);
			SceneItemReferenceComponent sceneItemReferenceComponent;
			if (entityHandle == null)
			{
				sceneItemReferenceComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				sceneItemReferenceComponent = ((entity != null) ? entity.CheckGetComponent<SceneItemReferenceComponent>() : null);
			}
			SceneItemReferenceComponent sceneItemReferenceComponent2 = sceneItemReferenceComponent;
			if (sceneItemReferenceComponent2 == null)
			{
				return;
			}
			sceneItemReferenceComponent2.HandleModifyActorMaterialParamBySplineProgress((ModifyActorMaterialParamBySplineProgress)inParams);
		}
	}
}
