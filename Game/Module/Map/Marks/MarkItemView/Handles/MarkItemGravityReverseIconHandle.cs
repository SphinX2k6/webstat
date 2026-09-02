using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x02005894 RID: 22676
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemGravityReverseIconHandle : MarkItemComponentHandle<MarkGravityReverseIconComponent>
	{
		// Token: 0x06039A36 RID: 236086 RVA: 0x00E9E124 File Offset: 0x00E9C324
		public MarkItemGravityReverseIconHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A37 RID: 236087 RVA: 0x00E9E130 File Offset: 0x00E9C330
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkGravityReverseIconComponent> LoadComponentAsync()
		{
			MarkItemGravityReverseIconHandle.<LoadComponentAsync>d__1 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkGravityReverseIconComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemGravityReverseIconHandle.<LoadComponentAsync>d__1>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A38 RID: 236088 RVA: 0x00E9E173 File Offset: 0x00E9C373
		protected override MarkGravityReverseIconComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkGravityReverseIconComponent _)
				{
					MarkGravityReverseIconComponent componentInternal = this.ComponentInternal;
					if (componentInternal != null)
					{
						UUIItem rootItem = componentInternal.GetRootItem();
						if (rootItem != null)
						{
							FVectorDouble fvectorDouble = this.Context.MarkItem.CornerScaleVector.ToUeVector(false);
							FVector fvector = fvectorDouble;
							rootItem.SetUIRelativeScale3D(fvector);
						}
					}
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A39 RID: 236089 RVA: 0x00E9E19B File Offset: 0x00E9C39B
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.GravityReverse, active);
		}

		// Token: 0x06039A3A RID: 236090 RVA: 0x00E9E1B8 File Offset: 0x00E9C3B8
		protected override void OnApplyModified()
		{
			MarkItemEntity markItemEntity = this.Context.MarkItemEntity;
			MarkViewLifeCircleComponent viewLifeCircle = markItemEntity.ViewLifeCircle;
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.GravityReverse))
			{
				MarkGravityReverseIconComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				bool active = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.GravityReverse, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.GravityReverse);
				orCreateComponent.Gravity = markItemEntity.GamePlay.Gravity;
				MarkItemComponentHandle<MarkGravityReverseIconComponent>.SetComponentActive(orCreateComponent, active);
			}
		}
	}
}
