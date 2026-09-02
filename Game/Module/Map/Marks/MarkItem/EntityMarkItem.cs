using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005842 RID: 22594
	[NullableContext(1)]
	[Nullable(0)]
	public class EntityMarkItem : ConfigMarkItem
	{
		// Token: 0x0603970A RID: 235274 RVA: 0x00E94FB7 File Offset: 0x00E931B7
		public EntityMarkItem(int markId, MapMark markConfig, UUIItem parent, TTrackTarget trackTarget, EMapType mapType, float markScale) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(ETrackSource.MapMark))
		{
			base.TrackTarget = trackTarget;
		}

		// Token: 0x0603970B RID: 235275 RVA: 0x00E94FD4 File Offset: 0x00E931D4
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.EntityMarkItemView;
		}

		// Token: 0x0603970C RID: 235276 RVA: 0x00E94FD8 File Offset: 0x00E931D8
		protected override MarkItemView CreateView()
		{
			return new EntityMarkItemView(this);
		}

		// Token: 0x0603970D RID: 235277 RVA: 0x00E94FE0 File Offset: 0x00E931E0
		protected override void InitPosition()
		{
			if (base.TrackTarget == null)
			{
				base.SetTrackData(ModelBase<MapModel>.Instance.GetConfigMarkTrackTarget(this.MarkId));
			}
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x0603970E RID: 235278 RVA: 0x00E95006 File Offset: 0x00E93206
		public override bool CheckCanShowView()
		{
			if (!(base.TrackTarget is TTrackTarget_Int))
			{
				return base.CheckCanShowView();
			}
			return ModelBase<CreatureModel>.Instance.CheckEntityVisible((TTrackTarget_Int)base.TrackTarget) && base.CheckCanShowView();
		}

		// Token: 0x1700928F RID: 37519
		// (get) Token: 0x0603970F RID: 235279 RVA: 0x00E95040 File Offset: 0x00E93240
		public override int MapId
		{
			get
			{
				if (this.MarkType != EMarkType.SoundBox)
				{
					return this.MarkConfig.Value.MapId;
				}
				return ModelBase<MapModel>.Instance.CurrentMapConfigId;
			}
		}
	}
}
