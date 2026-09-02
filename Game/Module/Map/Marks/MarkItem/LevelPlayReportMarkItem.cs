using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200584D RID: 22605
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelPlayReportMarkItem : ConfigMarkItem
	{
		// Token: 0x06039768 RID: 235368 RVA: 0x00E95C64 File Offset: 0x00E93E64
		public LevelPlayReportMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x06039769 RID: 235369 RVA: 0x00E95C7A File Offset: 0x00E93E7A
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.LevelPlayReportMarkItemView;
		}

		// Token: 0x0603976A RID: 235370 RVA: 0x00E95C7E File Offset: 0x00E93E7E
		[PreserveBaseOverrides]
		protected new virtual LevelPlayReportMarkItemView CreateView()
		{
			return new LevelPlayReportMarkItemView(this);
		}

		// Token: 0x0603976B RID: 235371 RVA: 0x00E95C86 File Offset: 0x00E93E86
		public bool IsPunishReportFinish()
		{
			return base.MarkItemEntity.GetComponent<MarkGamePlayComponent>(EMapComponent.MarkGamePlay).IsFinish;
		}

		// Token: 0x0603976C RID: 235372 RVA: 0x00E95C9C File Offset: 0x00E93E9C
		public bool CanGetReward()
		{
			int relativeId = this.MarkConfig.Value.RelativeId;
			return ModelBase<LevelPlayReportModel>.Instance.HaveLevelPlayReportRewardCanGet(this.MarkConfig.Value.RelativeDungeonId, relativeId);
		}

		// Token: 0x0603976D RID: 235373 RVA: 0x00E95CDC File Offset: 0x00E93EDC
		public PunishReportTarget GetPunishReportTarget()
		{
			int relativeId = this.MarkConfig.Value.RelativeId;
			return ModelBase<LevelPlayReportModel>.Instance.GetLevelPlayReportTarget(this.MarkConfig.Value.RelativeDungeonId, relativeId);
		}

		// Token: 0x0603976E RID: 235374 RVA: 0x00E95D1B File Offset: 0x00E93F1B
		protected override void InitIcon()
		{
			this.UpdateIconPath();
		}

		// Token: 0x0603976F RID: 235375 RVA: 0x00E95D24 File Offset: 0x00E93F24
		public override void UpdateIconPath()
		{
			this.IconPath = this.MarkConfig.Value.UnlockMarkPic;
		}

		// Token: 0x06039770 RID: 235376 RVA: 0x00E95D4A File Offset: 0x00E93F4A
		protected override bool GamePlayIsFinish()
		{
			return this.IsPunishReportFinish();
		}
	}
}
