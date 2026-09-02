using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x02004859 RID: 18521
	public class SceneItemManipulableMatchOutletState : SceneItemManipulableBaseState
	{
		// Token: 0x060302E4 RID: 197348 RVA: 0x00BB20C7 File Offset: 0x00BB02C7
		[NullableContext(1)]
		public SceneItemManipulableMatchOutletState(SceneItemManipulatableComponent SceneItem) : base(SceneItem)
		{
		}

		// Token: 0x060302E5 RID: 197349 RVA: 0x00BB20D0 File Offset: 0x00BB02D0
		protected override void OnEnter()
		{
			this.SceneItem.ClearCastDestroyTimer();
			this.SceneItem.TryAddTagById(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中"]);
			if (!FNameUtil.IsNothing(this.SceneItem.ManipulateBaseConfig.待机状态碰撞预设))
			{
				this.SceneItem.ActorComp.GetPrimitiveComponent().SetCollisionProfileName(this.SceneItem.ManipulateBaseConfig.待机状态碰撞预设, true);
			}
			this.SceneItem.IsCanBeHeld = true;
			base.OpenPhysicsSplit();
			this.PropComp.IsMoving = false;
			this.TryAttachToOutlet();
		}

		// Token: 0x060302E6 RID: 197350 RVA: 0x00BB2163 File Offset: 0x00BB0363
		protected override void OnExit()
		{
			this.SceneItem.TryRemoveTagById(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中"]);
			base.ClosePhysicsSplit();
			this.PropComp.IsMoving = true;
			this.TryDetachFromOutlet();
		}

		// Token: 0x060302E7 RID: 197351 RVA: 0x00BB2198 File Offset: 0x00BB0398
		private void TryAttachToOutlet()
		{
			SceneItemDynamicAttachTargetComponent component = this.SceneItem.Entity.GetComponent<SceneItemDynamicAttachTargetComponent>();
			SceneItemOutletComponent activatedOutlet = this.SceneItem.ActivatedOutlet;
			if (component == null || activatedOutlet == null || !activatedOutlet.GetIsNeedAttach())
			{
				return;
			}
			Vector socketLocationOffset = activatedOutlet.GetSocketLocationOffset(this.SceneItem.Entity);
			Vector matchSequenceOffset = activatedOutlet.GetMatchSequenceOffset(this.SceneItem.Entity);
			SceneItemDynamicAttachTargetComponent.AttachParam attachParam = new SceneItemDynamicAttachTargetComponent.AttachParam();
			attachParam.PosAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.UseZeroRelativeTransform;
			attachParam.PosAttachOffset = socketLocationOffset.Addition(matchSequenceOffset, Vector.Create());
			attachParam.PosAbsolute = false;
			attachParam.RotAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.UseZeroRelativeTransform;
			attachParam.RotAttachOffset = activatedOutlet.GetSocketRotatorOffset(this.SceneItem.Entity);
			attachParam.RotAbsolute = false;
			component.RegEntityTarget(activatedOutlet.Entity.GetComponent<CreatureDataComponent>().GetPbDataId(), activatedOutlet.GetSocketName(this.SceneItem.Entity), attachParam, "[MatchOutletState] TryAttachToOutlet");
		}

		// Token: 0x060302E8 RID: 197352 RVA: 0x00BB2278 File Offset: 0x00BB0478
		private void TryDetachFromOutlet()
		{
			SceneItemDynamicAttachTargetComponent component = this.SceneItem.Entity.GetComponent<SceneItemDynamicAttachTargetComponent>();
			if (component == null)
			{
				return;
			}
			component.UnRegTarget("[MatchOutletState] TryDetachFromOutlet");
		}
	}
}
