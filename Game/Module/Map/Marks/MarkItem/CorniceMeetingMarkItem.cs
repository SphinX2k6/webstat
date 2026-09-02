using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x0200583A RID: 22586
	public class CorniceMeetingMarkItem : SceneGameplayMarkItem
	{
		// Token: 0x060396BF RID: 235199 RVA: 0x00E941B7 File Offset: 0x00E923B7
		[NullableContext(1)]
		public CorniceMeetingMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource? trackSource = null) : base(markId, markConfig, parent, mapType, markScale, trackSource)
		{
		}

		// Token: 0x060396C0 RID: 235200 RVA: 0x00E941C8 File Offset: 0x00E923C8
		public override bool CheckCanShowView()
		{
			CorniceChallenge? corniceMeetingChallengeByMarkId = ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeByMarkId(this.MarkId);
			if (corniceMeetingChallengeByMarkId != null)
			{
				ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
				return currentActivityData != null && currentActivityData.GetIsShow(corniceMeetingChallengeByMarkId.Value.Id);
			}
			return false;
		}
	}
}
