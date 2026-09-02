using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.InteractHandler
{
	// Token: 0x0200494B RID: 18763
	public class MechascoutDragInteractHandler : ManipulateInteractHandlerBase
	{
		// Token: 0x060310E7 RID: 200935 RVA: 0x00C3225B File Offset: 0x00C3045B
		[NullableContext(1)]
		public MechascoutDragInteractHandler(IManipulateInteractContext context) : base(context)
		{
		}

		// Token: 0x060310E8 RID: 200936 RVA: 0x00C32264 File Offset: 0x00C30464
		public override bool Start()
		{
			if (!this.Context.CheckBeforeInteract(EExploreSkillInteractType.MechascoutDrag))
			{
				return false;
			}
			this.Context.SelectedTargetInternal = (this.Context.ChooseTargetOnStartSkill ?? this.Context.BestTargetInternal);
			this.Context.Interacting = true;
			SceneItemExploreInteractComponent selectedTargetInternal = this.Context.SelectedTargetInternal;
			if (selectedTargetInternal != null)
			{
				selectedTargetInternal.TryChangeManipulateInteractPointState(SceneItemExploreInteractComponent.EManipulateInteractPointState.Interacting);
			}
			return true;
		}

		// Token: 0x060310E9 RID: 200937 RVA: 0x00C322CA File Offset: 0x00C304CA
		public override void End()
		{
			this.Context.Interacting = false;
			SceneItemExploreInteractComponent selectedTargetInternal = this.Context.SelectedTargetInternal;
			if (selectedTargetInternal != null)
			{
				selectedTargetInternal.TryChangeManipulateInteractPointState(SceneItemExploreInteractComponent.EManipulateInteractPointState.Normal);
			}
			this.Context.RequestInteractAction();
		}
	}
}
