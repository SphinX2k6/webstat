using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005846 RID: 22598
	[NullableContext(1)]
	[Nullable(0)]
	public class FloatLightForestMarkItem : ConfigMarkItem
	{
		// Token: 0x17009296 RID: 37526
		// (get) Token: 0x06039733 RID: 235315 RVA: 0x00E95614 File Offset: 0x00E93814
		// (set) Token: 0x06039734 RID: 235316 RVA: 0x00E9561C File Offset: 0x00E9381C
		public override bool IsStreaming { get; set; }

		// Token: 0x06039735 RID: 235317 RVA: 0x00E95625 File Offset: 0x00E93825
		public FloatLightForestMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource? trackSource = null) : base(markId, markConfig, parent, mapType, markScale, trackSource)
		{
		}

		// Token: 0x06039736 RID: 235318 RVA: 0x00E95636 File Offset: 0x00E93836
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.FloatLightForestMarkItemView;
		}

		// Token: 0x06039737 RID: 235319 RVA: 0x00E9563A File Offset: 0x00E9383A
		[PreserveBaseOverrides]
		protected new virtual FloatLightForestMarkItemView CreateView()
		{
			return new FloatLightForestMarkItemView(this);
		}

		// Token: 0x06039738 RID: 235320 RVA: 0x00E95642 File Offset: 0x00E93842
		public override bool GetInteractiveFlag()
		{
			return false;
		}
	}
}
