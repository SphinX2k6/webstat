using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.BattleUiSet
{
	// Token: 0x0200613A RID: 24890
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiSetPanelItemData
	{
		// Token: 0x0603EDB8 RID: 257464 RVA: 0x0101ADBC File Offset: 0x01018FBC
		public BattleUiSetPanelItemData(int index, in MobileBattleUiSet config)
		{
			MobileBattleUiSet mobileBattleUiSet = config;
			this.PanelIndex = mobileBattleUiSet.PanelIndex;
			this.PanelItemIndex = index;
			mobileBattleUiSet = config;
			this.ConfigId = mobileBattleUiSet.Id;
			mobileBattleUiSet = config;
			this.Size = mobileBattleUiSet.SourceSize;
			this.EditSize = this.Size;
			this.SourceSize = this.Size;
			mobileBattleUiSet = config;
			this.Alpha = mobileBattleUiSet.SourceAlpha;
			this.EditAlpha = this.Alpha;
			this.SourceAlpha = this.Alpha;
			mobileBattleUiSet = config;
			this.OffsetX = mobileBattleUiSet.SourceOffsetX;
			this.EditOffsetX = this.OffsetX;
			this.SourceOffsetX = this.OffsetX;
			mobileBattleUiSet = config;
			this.OffsetY = mobileBattleUiSet.SourceOffsetY;
			this.EditOffsetY = this.OffsetY;
			this.SourceOffsetY = this.OffsetY;
			mobileBattleUiSet = config;
			this.Name = mobileBattleUiSet.Name;
			mobileBattleUiSet = config;
			this.CanEdit = mobileBattleUiSet.CanEdit;
			mobileBattleUiSet = config;
			this.IsDefaultSelected = mobileBattleUiSet.IsDefaultSelected;
			mobileBattleUiSet = config;
			this.IsCheckOverlap = mobileBattleUiSet.IsCheckOverlap;
			mobileBattleUiSet = config;
			this.HierarchyIndex = mobileBattleUiSet.SourceHierarchyIndex;
			this.EditorHierarchyIndex = this.HierarchyIndex;
			this.SourceHierarchyIndex = this.HierarchyIndex;
		}

		// Token: 0x0603EDB9 RID: 257465 RVA: 0x0101AF2A File Offset: 0x0101912A
		public void ReInit()
		{
			this.EditSize = this.Size;
			this.EditAlpha = this.Alpha;
			this.EditOffsetX = this.OffsetX;
			this.EditOffsetY = this.OffsetY;
		}

		// Token: 0x0603EDBA RID: 257466 RVA: 0x0101AF5C File Offset: 0x0101915C
		public bool IsEdited()
		{
			return this.EditSize != this.Size || this.EditAlpha != this.Alpha || this.EditOffsetY != this.OffsetY || this.EditOffsetX != this.OffsetX;
		}

		// Token: 0x0603EDBB RID: 257467 RVA: 0x0101AF9B File Offset: 0x0101919B
		public bool IsInitialized()
		{
			return this.Size != 0f || this.Alpha != 0f || this.OffsetX != 0f || this.OffsetY != 0f;
		}

		// Token: 0x0603EDBC RID: 257468 RVA: 0x0101AFD8 File Offset: 0x010191D8
		public string GetDebugString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 5);
			defaultInterpolatedStringHandler.AppendLiteral("按键名称：");
			defaultInterpolatedStringHandler.AppendFormatted(this.Name);
			defaultInterpolatedStringHandler.AppendLiteral("，尺寸：");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.Size);
			defaultInterpolatedStringHandler.AppendLiteral("，透明度：");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.Alpha);
			defaultInterpolatedStringHandler.AppendLiteral("，位置：");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.OffsetX);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.OffsetY);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x04023452 RID: 144466
		public readonly int PanelIndex;

		// Token: 0x04023453 RID: 144467
		public readonly int PanelItemIndex;

		// Token: 0x04023454 RID: 144468
		public readonly int ConfigId;

		// Token: 0x04023455 RID: 144469
		public float Size;

		// Token: 0x04023456 RID: 144470
		public float EditSize;

		// Token: 0x04023457 RID: 144471
		public readonly float SourceSize;

		// Token: 0x04023458 RID: 144472
		public float Alpha;

		// Token: 0x04023459 RID: 144473
		public float EditAlpha;

		// Token: 0x0402345A RID: 144474
		public readonly float SourceAlpha;

		// Token: 0x0402345B RID: 144475
		public float OffsetX;

		// Token: 0x0402345C RID: 144476
		public float EditOffsetX;

		// Token: 0x0402345D RID: 144477
		public readonly float SourceOffsetX;

		// Token: 0x0402345E RID: 144478
		public float OffsetY;

		// Token: 0x0402345F RID: 144479
		public float EditOffsetY;

		// Token: 0x04023460 RID: 144480
		public readonly float SourceOffsetY;

		// Token: 0x04023461 RID: 144481
		private readonly string Name;

		// Token: 0x04023462 RID: 144482
		public int HierarchyIndex;

		// Token: 0x04023463 RID: 144483
		public int EditorHierarchyIndex;

		// Token: 0x04023464 RID: 144484
		public int SourceHierarchyIndex;

		// Token: 0x04023465 RID: 144485
		public readonly bool CanEdit;

		// Token: 0x04023466 RID: 144486
		public readonly bool IsDefaultSelected;

		// Token: 0x04023467 RID: 144487
		public readonly bool IsCheckOverlap;
	}
}
