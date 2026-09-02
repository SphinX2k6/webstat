using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.Sheriff;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005856 RID: 22614
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffAnomalyMarkItem : ConfigMarkItem
	{
		// Token: 0x06039842 RID: 235586 RVA: 0x00E98301 File Offset: 0x00E96501
		public SheriffAnomalyMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x06039843 RID: 235587 RVA: 0x00E98317 File Offset: 0x00E96517
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.SheriffAnomalyMarkItemView;
		}

		// Token: 0x06039844 RID: 235588 RVA: 0x00E9831B File Offset: 0x00E9651B
		[PreserveBaseOverrides]
		protected new virtual SheriffAnomalyMarkItemView CreateView()
		{
			return new SheriffAnomalyMarkItemView(this);
		}

		// Token: 0x06039845 RID: 235589 RVA: 0x00E98323 File Offset: 0x00E96523
		public override bool CheckCanShowView()
		{
			return ModelBase<MapModel>.Instance.IsExtraUiMarkType(base.MapType, this.MarkType);
		}

		// Token: 0x06039846 RID: 235590 RVA: 0x00E9833C File Offset: 0x00E9653C
		public override bool CheckCanShowViewInExtraUi()
		{
			SheriffAnomaly? anomalyConfigByMarkId = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigByMarkId(this.MarkId);
			SheriffAnomalyInfo anomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(anomalyConfigByMarkId.Value.Id);
			return anomalyInfo.State != ESheriffAnomalyState.Lock && (anomalyInfo.State != ESheriffAnomalyState.Completed || !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SheriffHideCompletedMarkItem, false));
		}

		// Token: 0x06039847 RID: 235591 RVA: 0x00E98397 File Offset: 0x00E96597
		protected override bool IsTracking()
		{
			return !ModelBase<MapModel>.Instance.IsExtraUiMarkType(base.MapType, this.MarkType) && base.IsTracking();
		}

		// Token: 0x04020A80 RID: 133760
		[Nullable(2)]
		public SheriffAnomalyMarkItemView InnerView;
	}
}
