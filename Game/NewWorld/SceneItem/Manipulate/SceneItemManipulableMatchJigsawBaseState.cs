using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem.Jigsaw;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x02004858 RID: 18520
	public class SceneItemManipulableMatchJigsawBaseState : SceneItemManipulableMatchOutletState
	{
		// Token: 0x060302E0 RID: 197344 RVA: 0x00BB1FED File Offset: 0x00BB01ED
		[NullableContext(1)]
		public SceneItemManipulableMatchJigsawBaseState(SceneItemManipulatableComponent SceneItem) : base(SceneItem)
		{
		}

		// Token: 0x060302E1 RID: 197345 RVA: 0x00BB1FF8 File Offset: 0x00BB01F8
		protected override void OnEnter()
		{
			this.SceneItem.TryAddTagById(this.GetIsCorrect() ? GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.正确"] : GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.错误"]);
			this.SceneItem.IsCanBeHeld = true;
			base.OpenPhysicsSplit();
		}

		// Token: 0x060302E2 RID: 197346 RVA: 0x00BB204A File Offset: 0x00BB024A
		protected override void OnExit()
		{
			this.SceneItem.TryRemoveTagById(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.正确"]);
			this.SceneItem.TryRemoveTagById(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.错误"]);
			base.ClosePhysicsSplit();
		}

		// Token: 0x060302E3 RID: 197347 RVA: 0x00BB2088 File Offset: 0x00BB0288
		private bool GetIsCorrect()
		{
			SceneItemJigsawItemComponent component = this.SceneItem.Entity.GetComponent<SceneItemJigsawItemComponent>();
			return this.SceneItem.ActivatedOutlet.GetIsCorrect(this.SceneItem.Entity, component.PutDownIndex);
		}
	}
}
