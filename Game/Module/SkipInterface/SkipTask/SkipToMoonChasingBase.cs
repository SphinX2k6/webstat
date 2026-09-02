using System;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F50 RID: 20304
	public class SkipToMoonChasingBase : SkipTask
	{
		// Token: 0x06034602 RID: 214530 RVA: 0x00D1BD40 File Offset: 0x00D19F40
		public bool CheckMainViewOpen()
		{
			return Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MoonChasingMainView) != null;
		}

		// Token: 0x06034603 RID: 214531 RVA: 0x00D1BD54 File Offset: 0x00D19F54
		public void SkipToMap(int activityId)
		{
			TrackMoonActivity? activityMoonChasingConfig = ConfigBase<ActivityMoonChasingConfig>.Instance.GetActivityMoonChasingConfig(activityId);
			if (activityMoonChasingConfig == null)
			{
				return;
			}
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = new int?(activityMoonChasingConfig.Value.FocusMarkId),
				MarkType = EMarkType.SmallTeleport
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
		}
	}
}
