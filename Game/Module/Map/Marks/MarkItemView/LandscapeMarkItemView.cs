using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005875 RID: 22645
	public class LandscapeMarkItemView : ConfigMarkItemView
	{
		// Token: 0x0603991E RID: 235806 RVA: 0x00E9B178 File Offset: 0x00E99378
		[NullableContext(1)]
		public LandscapeMarkItemView(LandscapeMarkItem holder) : base(holder)
		{
		}

		// Token: 0x0603991F RID: 235807 RVA: 0x00E9B181 File Offset: 0x00E99381
		protected override void OnViewRefresh()
		{
			this.DestroyEffect();
			this.LoadEffect();
		}

		// Token: 0x06039920 RID: 235808 RVA: 0x00E9B190 File Offset: 0x00E99390
		public override bool GetInteractiveFlag()
		{
			return false;
		}

		// Token: 0x06039921 RID: 235809 RVA: 0x00E9B194 File Offset: 0x00E99394
		private UniTask LoadEffect()
		{
			LandscapeMarkItemView.<LoadEffect>d__4 <LoadEffect>d__;
			<LoadEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadEffect>d__.<>4__this = this;
			<LoadEffect>d__.<>1__state = -1;
			<LoadEffect>d__.<>t__builder.Start<LandscapeMarkItemView.<LoadEffect>d__4>(ref <LoadEffect>d__);
			return <LoadEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06039922 RID: 235810 RVA: 0x00E9B1D7 File Offset: 0x00E993D7
		private void DestroyEffect()
		{
			if (this.Effect != null)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(this.Effect.GetOwner(), true);
				this.Effect = null;
			}
		}

		// Token: 0x06039923 RID: 235811 RVA: 0x00E9B1F9 File Offset: 0x00E993F9
		protected override void OnBeforeDestroy()
		{
			this.DestroyEffect();
			base.OnBeforeDestroy();
		}

		// Token: 0x06039924 RID: 235812 RVA: 0x00E9B207 File Offset: 0x00E99407
		public override void SetScale(float scale)
		{
		}

		// Token: 0x04020ABB RID: 133819
		[Nullable(2)]
		private UUIItem Effect;
	}
}
