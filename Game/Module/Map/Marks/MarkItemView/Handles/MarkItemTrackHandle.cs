using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200589A RID: 22682
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemTrackHandle : MarkItemComponentHandle<MarkTrackComponent>
	{
		// Token: 0x06039A5D RID: 236125 RVA: 0x00E9E8E8 File Offset: 0x00E9CAE8
		public MarkItemTrackHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A5E RID: 236126 RVA: 0x00E9E8F4 File Offset: 0x00E9CAF4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkTrackComponent> LoadComponentAsync()
		{
			MarkItemTrackHandle.<LoadComponentAsync>d__1 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkTrackComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemTrackHandle.<LoadComponentAsync>d__1>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A5F RID: 236127 RVA: 0x00E9E937 File Offset: 0x00E9CB37
		protected override MarkTrackComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkTrackComponent _)
				{
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A60 RID: 236128 RVA: 0x00E9E95F File Offset: 0x00E9CB5F
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.Track, active);
		}

		// Token: 0x06039A61 RID: 236129 RVA: 0x00E9E978 File Offset: 0x00E9CB78
		protected override void OnApplyModified()
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.Track))
			{
				MarkTrackComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				bool flag = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.Track, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.Track);
				if (orCreateComponent.GetActive() != flag)
				{
					orCreateComponent.SetActive(flag);
				}
			}
		}
	}
}
