using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200583D RID: 22589
	public class DreamLinkRunMarkItem : SceneGameplayMarkItem
	{
		// Token: 0x060396D6 RID: 235222 RVA: 0x00E94530 File Offset: 0x00E92730
		[NullableContext(1)]
		public DreamLinkRunMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource? trackSource = null) : base(markId, markConfig, parent, mapType, markScale, trackSource)
		{
		}

		// Token: 0x060396D7 RID: 235223 RVA: 0x00E94541 File Offset: 0x00E92741
		public override bool CheckCanShowView()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityMapMarkState(26, this.MarkId);
		}
	}
}
