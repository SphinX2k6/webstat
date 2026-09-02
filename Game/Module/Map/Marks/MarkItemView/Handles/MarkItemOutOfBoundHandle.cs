using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x02005896 RID: 22678
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemOutOfBoundHandle : MarkItemComponentHandle<MarkOutOfBoundComponent>
	{
		// Token: 0x06039A43 RID: 236099 RVA: 0x00E9E377 File Offset: 0x00E9C577
		public MarkItemOutOfBoundHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A44 RID: 236100 RVA: 0x00E9E380 File Offset: 0x00E9C580
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkOutOfBoundComponent> LoadComponentAsync()
		{
			MarkItemOutOfBoundHandle.<LoadComponentAsync>d__1 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkOutOfBoundComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemOutOfBoundHandle.<LoadComponentAsync>d__1>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A45 RID: 236101 RVA: 0x00E9E3C3 File Offset: 0x00E9C5C3
		protected override MarkOutOfBoundComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkOutOfBoundComponent _)
				{
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A46 RID: 236102 RVA: 0x00E9E3EB File Offset: 0x00E9C5EB
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.OutOfBound, active);
		}

		// Token: 0x06039A47 RID: 236103 RVA: 0x00E9E404 File Offset: 0x00E9C604
		protected override void OnApplyModified()
		{
			MarkItemEntity markItemEntity = this.Context.MarkItemEntity;
			MarkResourceComponent resource = markItemEntity.Resource;
			MarkViewLifeCircleComponent viewLifeCircle = markItemEntity.ViewLifeCircle;
			bool isOutOfBoundDirectionDirty = resource.IsOutOfBoundDirectionDirty;
			bool flag = viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.OutOfBound);
			if (isOutOfBoundDirectionDirty || flag)
			{
				MarkOutOfBoundComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				if (isOutOfBoundDirectionDirty)
				{
					Vector uiPosition = this.Context.MarkItem.UiPosition;
					Vector2D vector2D = Vector2D.Create(uiPosition.X, uiPosition.Y);
					Vector2D outOfBoundDirection = resource.OutOfBoundDirection;
					vector2D.SubtractionEqual(outOfBoundDirection);
					orCreateComponent.SetOutOfBoundDirection(vector2D);
					resource.SetOutOfBoundDirectionClean();
				}
				if (flag)
				{
					bool active = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.OutOfBound, false);
					viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.OutOfBound);
					MarkItemComponentHandle<MarkOutOfBoundComponent>.SetComponentActive(orCreateComponent, active);
				}
			}
		}

		// Token: 0x06039A48 RID: 236104 RVA: 0x00E9E4B8 File Offset: 0x00E9C6B8
		public void ApplyDirectionModified()
		{
			MarkResourceComponent resource = this.Context.MarkItemEntity.Resource;
			if (resource.IsOutOfBoundDirectionDirty)
			{
				MarkOutOfBoundComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				Vector uiPosition = this.Context.MarkItem.UiPosition;
				Vector2D vector2D = Vector2D.Create(uiPosition.X, uiPosition.Y);
				Vector2D outOfBoundDirection = resource.OutOfBoundDirection;
				vector2D.SubtractionEqual(outOfBoundDirection);
				orCreateComponent.SetOutOfBoundDirection(vector2D);
				resource.SetOutOfBoundDirectionClean();
			}
		}
	}
}
