using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x0200586F RID: 22639
	public class FloatLightForestMarkItemView : ConfigMarkItemView
	{
		// Token: 0x060398FF RID: 235775 RVA: 0x00E9AC65 File Offset: 0x00E98E65
		[NullableContext(1)]
		public FloatLightForestMarkItemView(FloatLightForestMarkItem holder) : base(holder)
		{
		}

		// Token: 0x06039900 RID: 235776 RVA: 0x00E9AC70 File Offset: 0x00E98E70
		protected override UniTask OnBeforeStartAsync()
		{
			FloatLightForestMarkItemView.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FloatLightForestMarkItemView.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039901 RID: 235777 RVA: 0x00E9ACB3 File Offset: 0x00E98EB3
		protected override void OnBeforeDestroy()
		{
			this.DestroyEffect();
			base.OnBeforeDestroy();
		}

		// Token: 0x06039902 RID: 235778 RVA: 0x00E9ACC4 File Offset: 0x00E98EC4
		private UniTask LoadEffect()
		{
			FloatLightForestMarkItemView.<LoadEffect>d__4 <LoadEffect>d__;
			<LoadEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadEffect>d__.<>4__this = this;
			<LoadEffect>d__.<>1__state = -1;
			<LoadEffect>d__.<>t__builder.Start<FloatLightForestMarkItemView.<LoadEffect>d__4>(ref <LoadEffect>d__);
			return <LoadEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06039903 RID: 235779 RVA: 0x00E9AD07 File Offset: 0x00E98F07
		private void DestroyEffect()
		{
			if (this.Effect != null)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(this.Effect.GetOwner(), true);
				this.Effect = null;
			}
		}

		// Token: 0x06039904 RID: 235780 RVA: 0x00E9AD29 File Offset: 0x00E98F29
		public override void SetScale(float scale)
		{
		}

		// Token: 0x06039905 RID: 235781 RVA: 0x00E9AD2B File Offset: 0x00E98F2B
		public override bool GetInteractiveFlag()
		{
			return false;
		}

		// Token: 0x04020AB7 RID: 133815
		[Nullable(2)]
		private UUIItem Effect;
	}
}
