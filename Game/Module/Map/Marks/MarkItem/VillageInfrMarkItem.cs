using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005860 RID: 22624
	public class VillageInfrMarkItem : ConfigMarkItem
	{
		// Token: 0x060398C7 RID: 235719 RVA: 0x00E9A20E File Offset: 0x00E9840E
		[NullableContext(1)]
		public VillageInfrMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x04020AB1 RID: 133809
		[Nullable(2)]
		public VillageInfrMarkItemView InnerView;
	}
}
