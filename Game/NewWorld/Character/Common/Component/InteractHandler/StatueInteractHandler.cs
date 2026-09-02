using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.InteractHandler
{
	// Token: 0x0200494F RID: 18767
	public class StatueInteractHandler : ManipulateInteractHandlerBase
	{
		// Token: 0x0603110A RID: 200970 RVA: 0x00C331B1 File Offset: 0x00C313B1
		[NullableContext(1)]
		public StatueInteractHandler(IManipulateInteractContext context) : base(context)
		{
		}

		// Token: 0x0603110B RID: 200971 RVA: 0x00C331BC File Offset: 0x00C313BC
		public override bool Start()
		{
			this.Context.SelectedTargetInternal = (this.Context.ChooseTargetOnStartSkill ?? this.Context.BestTargetInternal);
			if (!this.Context.CheckBeforeInteract(EExploreSkillInteractType.StatueInteractPoint))
			{
				return false;
			}
			this.Context.Interacting = true;
			SceneItemExploreInteractComponent selectedTargetInternal = this.Context.SelectedTargetInternal;
			if (selectedTargetInternal != null)
			{
				selectedTargetInternal.TryChangeManipulateInteractPointState(SceneItemExploreInteractComponent.EManipulateInteractPointState.Interacting);
			}
			base.ApplyInteractBuff();
			return true;
		}

		// Token: 0x0603110C RID: 200972 RVA: 0x00C33228 File Offset: 0x00C31428
		public override void End()
		{
			SceneItemExploreInteractComponent curTarget = this.Context.SelectedTargetInternal;
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.Context.Interacting = false;
				SceneItemExploreInteractComponent curTarget3 = curTarget;
				if (curTarget3 != null)
				{
					curTarget3.EndInteractPullStatue();
				}
				this.RemoveInteractBuffImmediate();
			}, 200f, null, null, true, 1f);
			SceneItemExploreInteractComponent curTarget4 = curTarget;
			if (curTarget4 != null)
			{
				curTarget4.TryChangeManipulateInteractPointState(SceneItemExploreInteractComponent.EManipulateInteractPointState.Normal);
			}
			SceneItemExploreInteractComponent curTarget2 = curTarget;
			if (curTarget2 != null)
			{
				curTarget2.MoveToOutlet();
			}
			this.Context.SelectedTargetInternal = null;
		}
	}
}
