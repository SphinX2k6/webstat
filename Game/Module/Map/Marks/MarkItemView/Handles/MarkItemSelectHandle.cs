using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x02005898 RID: 22680
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemSelectHandle : MarkItemComponentHandle<MarkSelectComponent>
	{
		// Token: 0x06039A52 RID: 236114 RVA: 0x00E9E6C0 File Offset: 0x00E9C8C0
		public MarkItemSelectHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A53 RID: 236115 RVA: 0x00E9E6CC File Offset: 0x00E9C8CC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkSelectComponent> LoadComponentAsync()
		{
			MarkItemSelectHandle.<LoadComponentAsync>d__1 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkSelectComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemSelectHandle.<LoadComponentAsync>d__1>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A54 RID: 236116 RVA: 0x00E9E70F File Offset: 0x00E9C90F
		protected override MarkSelectComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkSelectComponent _)
				{
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A55 RID: 236117 RVA: 0x00E9E737 File Offset: 0x00E9C937
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.Select, active);
		}

		// Token: 0x06039A56 RID: 236118 RVA: 0x00E9E750 File Offset: 0x00E9C950
		protected override void OnApplyModified()
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.Select))
			{
				MarkSelectComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				bool active = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.Select, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.Select);
				MarkItemComponentHandle<MarkSelectComponent>.SetComponentActive(orCreateComponent, active);
			}
		}
	}
}
