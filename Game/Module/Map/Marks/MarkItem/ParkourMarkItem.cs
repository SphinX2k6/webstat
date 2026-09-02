using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005850 RID: 22608
	public class ParkourMarkItem : SceneGameplayMarkItem
	{
		// Token: 0x060397FB RID: 235515 RVA: 0x00E972B6 File Offset: 0x00E954B6
		[NullableContext(1)]
		public ParkourMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource? trackSource = null) : base(markId, markConfig, parent, mapType, markScale, trackSource)
		{
		}

		// Token: 0x060397FC RID: 235516 RVA: 0x00E972C8 File Offset: 0x00E954C8
		public override bool CheckCanShowView()
		{
			ParkourChallenge? config = ConfigParkourChallengeByMarkId.GetConfig(this.MarkId, true);
			if (config != null)
			{
				ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(config.Value.Id);
				return activityRunData != null && activityRunData.GetIsShow();
			}
			return false;
		}
	}
}
