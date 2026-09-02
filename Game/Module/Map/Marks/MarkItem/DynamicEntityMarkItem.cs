using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200583F RID: 22591
	[NullableContext(1)]
	[Nullable(0)]
	public class DynamicEntityMarkItem : DynamicConfigMarkItem
	{
		// Token: 0x060396EE RID: 235246 RVA: 0x00E94A45 File Offset: 0x00E92C45
		public DynamicEntityMarkItem(int markId, DynamicMapMark markConfig, UUIItem parent, TTrackTarget trackTarget, EMapType mapType, float markScale) : base(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark)
		{
			base.TrackTarget = trackTarget;
		}

		// Token: 0x060396EF RID: 235247 RVA: 0x00E94A60 File Offset: 0x00E92C60
		protected override void OnInitialize()
		{
			if (this.MarkConfig != null && this.MarkConfig.Value.Scale != 0f)
			{
				base.SetConfigScale(this.MarkConfig.Value.Scale);
			}
			base.InitShowCondition();
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x060396F0 RID: 235248 RVA: 0x00E94AB9 File Offset: 0x00E92CB9
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.DynamicEntityMarkItemView;
		}

		// Token: 0x060396F1 RID: 235249 RVA: 0x00E94ABC File Offset: 0x00E92CBC
		[PreserveBaseOverrides]
		protected new virtual DynamicEntityMarkItemView CreateView()
		{
			return new DynamicEntityMarkItemView(this);
		}

		// Token: 0x060396F2 RID: 235250 RVA: 0x00E94AC4 File Offset: 0x00E92CC4
		public override bool CheckCanShowView()
		{
			if (!(base.TrackTarget is TTrackTarget_Int))
			{
				return base.CheckCanShowView();
			}
			return ModelBase<CreatureModel>.Instance.CheckEntityVisible((TTrackTarget_Int)base.TrackTarget) && base.CheckCanShowView();
		}
	}
}
