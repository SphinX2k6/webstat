using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.InteractHandler
{
	// Token: 0x0200494D RID: 18765
	public class QuantumDiffusionInteractHandler : ManipulateInteractHandlerBase
	{
		// Token: 0x060310EE RID: 200942 RVA: 0x00C32440 File Offset: 0x00C30640
		[NullableContext(1)]
		public QuantumDiffusionInteractHandler(IManipulateInteractContext context) : base(context)
		{
		}

		// Token: 0x060310EF RID: 200943 RVA: 0x00C3244C File Offset: 0x00C3064C
		public override bool Start()
		{
			if (!this.Context.CheckBeforeInteract(EExploreSkillInteractType.QuantumDiffusion))
			{
				return false;
			}
			this.Context.SelectedTargetInternal = (this.Context.ChooseTargetOnStartSkill ?? this.Context.BestTargetInternal);
			this.Context.RequestInteractAction();
			return true;
		}

		// Token: 0x060310F0 RID: 200944 RVA: 0x00C3249A File Offset: 0x00C3069A
		public override void End()
		{
		}
	}
}
