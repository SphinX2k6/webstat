using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005837 RID: 22583
	[NullableContext(1)]
	[Nullable(0)]
	public class AreaMarkItem : ConfigMarkItem
	{
		// Token: 0x06039686 RID: 235142 RVA: 0x00E93629 File Offset: 0x00E91829
		public AreaMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource? trackSource = null) : base(markId, markConfig, parent, mapType, markScale, trackSource)
		{
		}

		// Token: 0x06039687 RID: 235143 RVA: 0x00E9363A File Offset: 0x00E9183A
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.AreaMarkItemView;
		}

		// Token: 0x06039688 RID: 235144 RVA: 0x00E9363D File Offset: 0x00E9183D
		protected override MarkItemView CreateView()
		{
			return new AreaMarkItemView(this);
		}

		// Token: 0x06039689 RID: 235145 RVA: 0x00E93645 File Offset: 0x00E91845
		public override bool GetInteractiveFlag()
		{
			return false;
		}
	}
}
