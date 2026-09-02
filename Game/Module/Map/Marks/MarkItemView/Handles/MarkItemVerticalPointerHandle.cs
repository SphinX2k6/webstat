using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200589B RID: 22683
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemVerticalPointerHandle : MarkItemComponentHandle<MarkVerticalPointerComponent>
	{
		// Token: 0x06039A63 RID: 236131 RVA: 0x00E9E9D8 File Offset: 0x00E9CBD8
		public MarkItemVerticalPointerHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A64 RID: 236132 RVA: 0x00E9E9E4 File Offset: 0x00E9CBE4
		public void UpdateVerticalPointerType(Vector selfPosition, Vector playerPosition)
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			if (viewLifeCircle.EnableVerticalPointer)
			{
				EVerticalPointerType verticalPointerType = this.GetVerticalPointerType(selfPosition, playerPosition);
				viewLifeCircle.VerticalPointerType = verticalPointerType;
				base.SetVisible(verticalPointerType > EVerticalPointerType.None);
				return;
			}
			base.SetVisible(false);
		}

		// Token: 0x06039A65 RID: 236133 RVA: 0x00E9EA2C File Offset: 0x00E9CC2C
		private EVerticalPointerType GetVerticalPointerType(Vector selfPosition, Vector playerPosition)
		{
			if (this.Context.MarkItem.MapType == EMapType.WorldMap)
			{
				return EVerticalPointerType.None;
			}
			double num = selfPosition.Z - playerPosition.Z;
			if (Math.Abs(num) < 2000.0)
			{
				return EVerticalPointerType.None;
			}
			if (num < 0.0)
			{
				return EVerticalPointerType.Up;
			}
			return EVerticalPointerType.Down;
		}

		// Token: 0x06039A66 RID: 236134 RVA: 0x00E9EA80 File Offset: 0x00E9CC80
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkVerticalPointerComponent> LoadComponentAsync()
		{
			MarkItemVerticalPointerHandle.<LoadComponentAsync>d__4 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkVerticalPointerComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemVerticalPointerHandle.<LoadComponentAsync>d__4>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A67 RID: 236135 RVA: 0x00E9EAC3 File Offset: 0x00E9CCC3
		protected override MarkVerticalPointerComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkVerticalPointerComponent _)
				{
					if (this.ComponentInternal != null)
					{
						MarkItem markItem = this.Context.MarkItem;
						MarkVerticalPointerComponent componentInternal = this.ComponentInternal;
						if (componentInternal != null)
						{
							UUIItem rootItem = componentInternal.GetRootItem();
							if (rootItem != null)
							{
								FVectorDouble fvectorDouble = markItem.CornerScaleVector.ToUeVector(false);
								FVector fvector = fvectorDouble;
								rootItem.SetUIRelativeScale3D(fvector);
							}
						}
						base.ApplyModified();
					}
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A68 RID: 236136 RVA: 0x00E9EAEB File Offset: 0x00E9CCEB
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.VerticalPointer, active);
		}

		// Token: 0x06039A69 RID: 236137 RVA: 0x00E9EB04 File Offset: 0x00E9CD04
		protected override void OnApplyModified()
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			bool flag = viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.VerticalPointer);
			bool isVerticalPointerTypeDirty = viewLifeCircle.IsVerticalPointerTypeDirty;
			if (flag || isVerticalPointerTypeDirty)
			{
				MarkVerticalPointerComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				bool active = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.VerticalPointer, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.VerticalPointer);
				viewLifeCircle.SetVerticalPointerTypeClean();
				orCreateComponent.SetPointerType(viewLifeCircle.VerticalPointerType);
				MarkItemComponentHandle<MarkVerticalPointerComponent>.SetComponentActive(orCreateComponent, active);
			}
		}

		// Token: 0x06039A6A RID: 236138 RVA: 0x00E9EB6E File Offset: 0x00E9CD6E
		protected override void OnDispose()
		{
			this.DestroyComponent();
			base.OnDispose();
		}

		// Token: 0x04020AEB RID: 133867
		private const float POINTER_RANGE = 2000f;
	}
}
