using System;
using System.Collections.Generic;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x02003346 RID: 13126
public class RedDotPhotoSetup : RedDotBase
{
	// Token: 0x0601B6B0 RID: 112304 RVA: 0x00836EFD File Offset: 0x008350FD
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotPhotoSetup, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnServerStorageInfoInited, new Action(base.EventCheck));
	}

	// Token: 0x0601B6B1 RID: 112305 RVA: 0x00836F37 File Offset: 0x00835137
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotPhotoSetup, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnServerStorageInfoInited, new Action(base.EventCheck));
	}

	// Token: 0x0601B6B2 RID: 112306 RVA: 0x00836F71 File Offset: 0x00835171
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionPhotograph);
	}

	// Token: 0x0601B6B3 RID: 112307 RVA: 0x00836F7C File Offset: 0x0083517C
	protected override bool OnCheck(int uId = 0)
	{
		IReadOnlyList<PhotoSetup> allPhotoSetupConfig = ConfigBase<PhotographConfig>.Instance.GetAllPhotoSetupConfig();
		if (allPhotoSetupConfig == null || allPhotoSetupConfig.Count == 0)
		{
			return false;
		}
		ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.Photography) as ServerStorageSet;
		bool flag = Singleton<Info>.Instance.IsPs5Platform();
		foreach (PhotoSetup photoSetup in allPhotoSetupConfig)
		{
			if ((!flag || photoSetup.IsShowInPS5) && photoSetup.IsShowRedDot && !serverStorageSet.Has(photoSetup.Id))
			{
				return true;
			}
		}
		return false;
	}
}
