using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.InteractHandler
{
	// Token: 0x0200494C RID: 18764
	public class PullGiantInteractHandler : ManipulateInteractHandlerBase
	{
		// Token: 0x060310EA RID: 200938 RVA: 0x00C322FA File Offset: 0x00C304FA
		[NullableContext(1)]
		public PullGiantInteractHandler(IManipulateInteractContext context) : base(context)
		{
		}

		// Token: 0x060310EB RID: 200939 RVA: 0x00C32304 File Offset: 0x00C30504
		public override bool Start()
		{
			if (!this.Context.CheckBeforeInteract(EExploreSkillInteractType.PullGiant))
			{
				return false;
			}
			this.Context.SelectedTargetInternal = (this.Context.ChooseTargetOnStartSkill ?? this.Context.BestTargetInternal);
			this.Context.Interacting = true;
			this.Context.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.拉取巨物"]));
			SceneItemExploreInteractComponent selectedTargetInternal = this.Context.SelectedTargetInternal;
			if (selectedTargetInternal != null)
			{
				selectedTargetInternal.TryChangeManipulateInteractPointState(SceneItemExploreInteractComponent.EManipulateInteractPointState.Interacting);
			}
			base.ApplyInteractBuff();
			return true;
		}

		// Token: 0x060310EC RID: 200940 RVA: 0x00C32394 File Offset: 0x00C30594
		public override void End()
		{
			this.Context.Interacting = false;
			this.Context.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.拉取巨物"]));
			this.Context.SpawnEffect();
			if (this.Context.CurBuffId != null)
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					base.RemoveInteractBuffImmediate();
				}, 200f, null, null, true, 1f);
			}
			SceneItemExploreInteractComponent selectedTargetInternal = this.Context.SelectedTargetInternal;
			if (selectedTargetInternal != null)
			{
				selectedTargetInternal.TryChangeManipulateInteractPointState(SceneItemExploreInteractComponent.EManipulateInteractPointState.Normal);
			}
			this.Context.RequestInteractAction();
		}

		// Token: 0x0401C3D7 RID: 115671
		private const int BUFF_REMOVE_DELAY_MS = 200;
	}
}
