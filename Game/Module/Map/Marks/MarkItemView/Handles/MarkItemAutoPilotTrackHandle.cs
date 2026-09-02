using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x02005891 RID: 22673
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemAutoPilotTrackHandle : MarkItemComponentHandle<MarkAutoPilotTrackComponent>
	{
		// Token: 0x06039A14 RID: 236052 RVA: 0x00E9DC58 File Offset: 0x00E9BE58
		public MarkItemAutoPilotTrackHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A15 RID: 236053 RVA: 0x00E9DC64 File Offset: 0x00E9BE64
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkAutoPilotTrackComponent> LoadComponentAsync()
		{
			MarkItemAutoPilotTrackHandle.<LoadComponentAsync>d__1 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkAutoPilotTrackComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemAutoPilotTrackHandle.<LoadComponentAsync>d__1>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A16 RID: 236054 RVA: 0x00E9DCA7 File Offset: 0x00E9BEA7
		protected override MarkAutoPilotTrackComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkAutoPilotTrackComponent _)
				{
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A17 RID: 236055 RVA: 0x00E9DCCF File Offset: 0x00E9BECF
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.AutoPilotTrack, active);
		}

		// Token: 0x06039A18 RID: 236056 RVA: 0x00E9DCEC File Offset: 0x00E9BEEC
		protected override void OnApplyModified()
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.AutoPilotTrack))
			{
				MarkAutoPilotTrackComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				bool active = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.AutoPilotTrack, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.AutoPilotTrack);
				MarkItemComponentHandle<MarkAutoPilotTrackComponent>.SetComponentActive(orCreateComponent, active);
			}
		}
	}
}
