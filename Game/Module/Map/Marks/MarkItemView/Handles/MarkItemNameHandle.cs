using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x02005895 RID: 22677
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemNameHandle : MarkItemComponentHandle<MarkNameComponent>
	{
		// Token: 0x06039A3C RID: 236092 RVA: 0x00E9E270 File Offset: 0x00E9C470
		public MarkItemNameHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A3D RID: 236093 RVA: 0x00E9E27C File Offset: 0x00E9C47C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkNameComponent> LoadComponentAsync()
		{
			MarkItemNameHandle.<LoadComponentAsync>d__2 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkNameComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemNameHandle.<LoadComponentAsync>d__2>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A3E RID: 236094 RVA: 0x00E9E2BF File Offset: 0x00E9C4BF
		protected override MarkNameComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkNameComponent _)
				{
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A3F RID: 236095 RVA: 0x00E9E2E7 File Offset: 0x00E9C4E7
		public void SetName(IMarkItemParam param)
		{
			this.Param = param;
		}

		// Token: 0x06039A40 RID: 236096 RVA: 0x00E9E2F0 File Offset: 0x00E9C4F0
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.Name, active);
		}

		// Token: 0x06039A41 RID: 236097 RVA: 0x00E9E30C File Offset: 0x00E9C50C
		protected override void OnApplyModified()
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.Name))
			{
				MarkNameComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				bool active = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.Name, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.Name);
				if (this.Param != null)
				{
					orCreateComponent.SetNameParam(this.Param);
				}
				MarkItemComponentHandle<MarkNameComponent>.SetComponentActive(orCreateComponent, active);
			}
		}

		// Token: 0x04020AEA RID: 133866
		[Nullable(2)]
		private IMarkItemParam Param;
	}
}
