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
	// Token: 0x02005897 RID: 22679
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemRangeHandle<[Nullable(0)] T> : MarkItemComponentHandle<T> where T : MarkPanelBase, new()
	{
		// Token: 0x06039A4A RID: 236106 RVA: 0x00E9E538 File Offset: 0x00E9C738
		public MarkItemRangeHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A4B RID: 236107 RVA: 0x00E9E544 File Offset: 0x00E9C744
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<T> LoadComponentAsync()
		{
			MarkItemRangeHandle<T>.<LoadComponentAsync>d__1 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemRangeHandle<T>.<LoadComponentAsync>d__1>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A4C RID: 236108 RVA: 0x00E9E587 File Offset: 0x00E9C787
		protected override T GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(T _)
				{
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A4D RID: 236109 RVA: 0x00E9E5B4 File Offset: 0x00E9C7B4
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.Range, active);
		}

		// Token: 0x06039A4E RID: 236110 RVA: 0x00E9E5D0 File Offset: 0x00E9C7D0
		protected override void OnApplyModified()
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.Range))
			{
				MarkRangeImageComponent markRangeImageComponent = this.GetOrCreateComponent() as MarkRangeImageComponent;
				if (!this.IsComponentValid(markRangeImageComponent as T))
				{
					return;
				}
				bool active = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.Range, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.Range);
				this.ResetRangeComponent(markRangeImageComponent);
				MarkItemComponentHandle<T>.SetComponentActive(markRangeImageComponent, active);
			}
		}

		// Token: 0x06039A4F RID: 236111 RVA: 0x00E9E63C File Offset: 0x00E9C83C
		protected void ResetRangeComponent(MarkRangeImageComponent rangeComponent)
		{
			float num = this.Context.MarkItemEntity.GetComponent<MarkResourceComponent>(EMapComponent.MarkResource).RangeSize * 2f;
			UUIItem rangeArea = rangeComponent.RangeArea;
			if (rangeArea != null)
			{
				rangeArea.SetWidth(num);
			}
			UUIItem rangeArea2 = rangeComponent.RangeArea;
			if (rangeArea2 != null)
			{
				rangeArea2.SetHeight(num);
			}
			UUITexture rangeImage = rangeComponent.RangeImage;
			if (rangeImage != null)
			{
				rangeImage.SetWidth(num);
			}
			UUITexture rangeImage2 = rangeComponent.RangeImage;
			if (rangeImage2 != null)
			{
				rangeImage2.SetHeight(num);
			}
			this.OnResetRangeComponent(rangeComponent);
		}

		// Token: 0x06039A50 RID: 236112 RVA: 0x00E9E6B6 File Offset: 0x00E9C8B6
		protected virtual void OnResetRangeComponent(MarkRangeImageComponent rangeComponent)
		{
		}
	}
}
