using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.InteractHandler
{
	// Token: 0x02004947 RID: 18759
	public class CustomInteractHandler : ManipulateInteractHandlerBase
	{
		// Token: 0x060310CC RID: 200908 RVA: 0x00C3206F File Offset: 0x00C3026F
		[NullableContext(1)]
		public CustomInteractHandler(IManipulateInteractContext context) : base(context)
		{
		}

		// Token: 0x060310CD RID: 200909 RVA: 0x00C32078 File Offset: 0x00C30278
		public override bool Start()
		{
			if (!this.Context.CheckBeforeInteract(EExploreSkillInteractType.Custom))
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

		// Token: 0x060310CE RID: 200910 RVA: 0x00C320DE File Offset: 0x00C302DE
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
