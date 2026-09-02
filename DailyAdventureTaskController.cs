using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;

// Token: 0x020012CD RID: 4813
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class DailyAdventureTaskController : UiControllerBase<DailyAdventureTaskController>
{
	// Token: 0x06008142 RID: 33090 RVA: 0x00222B08 File Offset: 0x00220D08
	public void TrackTaskByType(EDailyAdventureTaskJumpType type, string[] paramsList)
	{
		switch (type)
		{
		case EDailyAdventureTaskJumpType.Normal:
			break;
		case EDailyAdventureTaskJumpType.Map:
		{
			List<int> list = new List<int>();
			foreach (string s in paramsList)
			{
				list.Add(int.Parse(s));
			}
			this.OpenAndTrackMap(list.ToArray());
			return;
		}
		case EDailyAdventureTaskJumpType.Role:
		{
			EUiTabViewName value = EUiTabViewName.DailyActivityTabView;
			if (paramsList != null && paramsList.Length >= 1)
			{
				value = (EUiTabViewName)paramsList[0];
			}
			this.JumpRoleRootView(new EUiTabViewName?(value));
			return;
		}
		case EDailyAdventureTaskJumpType.SkipTask:
		{
			int skipTaskId = int.Parse(paramsList[0]);
			this.RunSkipTask(skipTaskId);
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x06008143 RID: 33091 RVA: 0x00222B9C File Offset: 0x00220D9C
	private void OpenAndTrackMap(int[] markIdList)
	{
		int value = 0;
		if (markIdList.Length > 1)
		{
			value = (ModelBase<MapModel>.Instance.IsConfigMarkIdUnlock(markIdList[0]) ? markIdList[0] : markIdList[1]);
		}
		WorldMapViewOpenParams data = new WorldMapViewOpenParams
		{
			MarkId = new int?(value),
			MarkType = EMarkType.None,
			OpenFogId = new int?(0)
		};
		ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
	}

	// Token: 0x06008144 RID: 33092 RVA: 0x00222BFC File Offset: 0x00220DFC
	private void JumpRoleRootView(EUiTabViewName? tabViewName = null)
	{
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, 0, new List<int>(), tabViewName, null);
	}

	// Token: 0x06008145 RID: 33093 RVA: 0x00222C11 File Offset: 0x00220E11
	private void RunSkipTask(int skipTaskId)
	{
		SkipTaskManager.RunByConfigId(skipTaskId, null);
	}
}
