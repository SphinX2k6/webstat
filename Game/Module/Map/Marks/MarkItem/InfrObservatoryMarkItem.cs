using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200584A RID: 22602
	public class InfrObservatoryMarkItem : ConfigMarkItem
	{
		// Token: 0x0603975E RID: 235358 RVA: 0x00E95B9A File Offset: 0x00E93D9A
		[NullableContext(1)]
		public InfrObservatoryMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x04020A54 RID: 133716
		[Nullable(2)]
		public InfrObservatoryMarkItemView InnerView;
	}
}
