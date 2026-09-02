using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x020058A1 RID: 22689
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TreasureBoxDetectorItemRangeHandle : MarkItemComponentHandle<MarkDetectorRangeImageComponent>
	{
		// Token: 0x06039A7B RID: 236155 RVA: 0x00E9EFA9 File Offset: 0x00E9D1A9
		public TreasureBoxDetectorItemRangeHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A7C RID: 236156 RVA: 0x00E9EFB4 File Offset: 0x00E9D1B4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkDetectorRangeImageComponent> LoadComponentAsync()
		{
			TreasureBoxDetectorItemRangeHandle.<LoadComponentAsync>d__1 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkDetectorRangeImageComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<TreasureBoxDetectorItemRangeHandle.<LoadComponentAsync>d__1>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A7D RID: 236157 RVA: 0x00E9EFF7 File Offset: 0x00E9D1F7
		protected override MarkDetectorRangeImageComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkDetectorRangeImageComponent _)
				{
					MarkDetectorRangeImageComponent componentInternal = this.ComponentInternal;
					Vector2D vector2D = Vector2D.Create(this.Context.MarkItem.UiPosition.X, this.Context.MarkItem.UiPosition.Y);
					UUIItem rootItem = componentInternal.GetRootItem();
					if (rootItem != null)
					{
						rootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
					}
					float num = (float)ConfigCommonParamById.GetIntConfig("TreasureBoxDetectionMaxDistance").Value / 100f * 2f;
					componentInternal.RangeImage.SetWidth(num);
					componentInternal.RangeImage.SetHeight(num);
					UUIItem rootItem2 = componentInternal.GetRootItem();
					if (rootItem2 != null)
					{
						rootItem2.SetHierarchyIndex(0);
					}
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A7E RID: 236158 RVA: 0x00E9F01F File Offset: 0x00E9D21F
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.Range, active);
		}

		// Token: 0x06039A7F RID: 236159 RVA: 0x00E9F038 File Offset: 0x00E9D238
		public void UpdateRangeScale()
		{
			if (this.Context.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.Range, false))
			{
				MarkDetectorRangeImageComponent orCreateComponent = this.GetOrCreateComponent();
				orCreateComponent.SetRangeScale(1.0, 1.0, 1.0);
				Vector2D vector2D = Vector2D.Create(this.Context.MarkItem.UiPosition.X, this.Context.MarkItem.UiPosition.Y);
				UUIItem rootItem = orCreateComponent.GetRootItem();
				if (rootItem == null)
				{
					return;
				}
				rootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
			}
		}

		// Token: 0x06039A80 RID: 236160 RVA: 0x00E9F0CC File Offset: 0x00E9D2CC
		protected override void OnApplyModified()
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.Range))
			{
				MarkDetectorRangeImageComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				bool active = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.Range, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.Range);
				this.UpdateRangeScale();
				MarkItemComponentHandle<MarkDetectorRangeImageComponent>.SetComponentActive(orCreateComponent, active);
			}
		}
	}
}
