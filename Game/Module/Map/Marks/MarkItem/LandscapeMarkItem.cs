using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200584C RID: 22604
	[NullableContext(1)]
	[Nullable(0)]
	public class LandscapeMarkItem : ConfigMarkItem
	{
		// Token: 0x06039764 RID: 235364 RVA: 0x00E95C3F File Offset: 0x00E93E3F
		public LandscapeMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x06039765 RID: 235365 RVA: 0x00E95C55 File Offset: 0x00E93E55
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.LandscapeMarkItemView;
		}

		// Token: 0x06039766 RID: 235366 RVA: 0x00E95C59 File Offset: 0x00E93E59
		[PreserveBaseOverrides]
		protected new virtual LandscapeMarkItemView CreateView()
		{
			return new LandscapeMarkItemView(this);
		}

		// Token: 0x06039767 RID: 235367 RVA: 0x00E95C61 File Offset: 0x00E93E61
		public override bool GetInteractiveFlag()
		{
			return false;
		}
	}
}
