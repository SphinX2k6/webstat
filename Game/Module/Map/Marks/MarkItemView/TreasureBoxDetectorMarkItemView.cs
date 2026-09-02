using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005887 RID: 22663
	[NullableContext(1)]
	[Nullable(0)]
	public class TreasureBoxDetectorMarkItemView : ServerMarkItemView
	{
		// Token: 0x060399DA RID: 235994 RVA: 0x00E9D88B File Offset: 0x00E9BA8B
		public TreasureBoxDetectorMarkItemView(TreasureBoxDetectorMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060399DB RID: 235995 RVA: 0x00E9D89F File Offset: 0x00E9BA9F
		protected override void OnViewRefresh()
		{
			this.TreasureBoxDetectorItemRangeHandle.SetVisible(true);
		}

		// Token: 0x060399DC RID: 235996 RVA: 0x00E9D8AD File Offset: 0x00E9BAAD
		protected override void CreateComponentHandles()
		{
			base.CreateComponentHandles();
			this.TreasureBoxDetectorItemRangeHandle = this.CreateDetectorRangeHandle(this.MarkComponentContext);
			this.MarkItemComponentHandleMap[EMarkViewComponentType.Range] = this.TreasureBoxDetectorItemRangeHandle;
		}

		// Token: 0x060399DD RID: 235997 RVA: 0x00E9D8D9 File Offset: 0x00E9BAD9
		private TreasureBoxDetectorItemRangeHandle CreateDetectorRangeHandle(IMarkItemComponentContext markComponentContext)
		{
			return new TreasureBoxDetectorItemRangeHandle(markComponentContext);
		}

		// Token: 0x060399DE RID: 235998 RVA: 0x00E9D8E4 File Offset: 0x00E9BAE4
		public override void SetScale(float scale)
		{
			if (!base.IsHolderValid())
			{
				return;
			}
			this.TempRangeScale.Set((double)scale, (double)scale, (double)scale);
			this.RootItem.D_SetWorldScale3D(this.TempRangeScale.ToUeVector(false));
			TreasureBoxDetectorItemRangeHandle treasureBoxDetectorItemRangeHandle = this.TreasureBoxDetectorItemRangeHandle;
			if (treasureBoxDetectorItemRangeHandle == null)
			{
				return;
			}
			treasureBoxDetectorItemRangeHandle.UpdateRangeScale();
		}

		// Token: 0x04020ADF RID: 133855
		private readonly Vector TempRangeScale = Vector.Create();

		// Token: 0x04020AE0 RID: 133856
		private TreasureBoxDetectorItemRangeHandle TreasureBoxDetectorItemRangeHandle;
	}
}
