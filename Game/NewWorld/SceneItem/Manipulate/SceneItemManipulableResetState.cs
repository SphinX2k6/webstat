using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200485B RID: 18523
	internal class SceneItemManipulableResetState : SceneItemManipulableBaseState
	{
		// Token: 0x060302EF RID: 197359 RVA: 0x00BB2530 File Offset: 0x00BB0730
		[NullableContext(1)]
		public SceneItemManipulableResetState(SceneItemManipulatableComponent sceneItem) : base(sceneItem)
		{
		}

		// Token: 0x060302F0 RID: 197360 RVA: 0x00BB253C File Offset: 0x00BB073C
		protected override void OnEnter()
		{
			base.OnEnter();
			this.SceneItem.TryAddTagById(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.未被控"]);
			if (!FNameUtil.IsNothing(this.SceneItem.ManipulateBaseConfig.待机状态碰撞预设))
			{
				this.SceneItem.ActorComp.GetPrimitiveComponent().SetCollisionProfileName(this.SceneItem.ManipulateBaseConfig.待机状态碰撞预设, true);
			}
			base.OpenPhysicsSplit();
			this.PropComp.IsMoving = false;
			if (this.SceneItem.FinishCheckInitAttach && this.SceneItem.EnableDynamicAttach)
			{
				this.SceneItem.TryReqAttachToFloor();
			}
		}

		// Token: 0x060302F1 RID: 197361 RVA: 0x00BB25DD File Offset: 0x00BB07DD
		protected override void OnExit()
		{
			base.OnExit();
			this.SceneItem.TryRemoveTagById(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.未被控"]);
			base.ClosePhysicsSplit();
			this.PropComp.IsMoving = true;
		}
	}
}
