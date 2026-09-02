using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x02003392 RID: 13202
public class RedDotPhantomArenaMapUnlockDropDownItem : RedDotBase
{
	// Token: 0x0601B80F RID: 112655 RVA: 0x008399A1 File Offset: 0x00837BA1
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPhantomArenaMapUnlock);
	}

	// Token: 0x0601B810 RID: 112656 RVA: 0x008399AD File Offset: 0x00837BAD
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaMapUnlockUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B811 RID: 112657 RVA: 0x008399CB File Offset: 0x00837BCB
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhantomArenaMapUnlockUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B812 RID: 112658 RVA: 0x008399E9 File Offset: 0x00837BE9
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomArenaModel>.Instance.GetMapUnlockRedDotById(uId);
	}

	// Token: 0x0601B813 RID: 112659 RVA: 0x008399F6 File Offset: 0x00837BF6
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B814 RID: 112660 RVA: 0x008399F9 File Offset: 0x00837BF9
	protected override int GetParentCheckUid(int uId)
	{
		PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
		if (permanentPhantomArenaActivityData == null)
		{
			return 0;
		}
		return permanentPhantomArenaActivityData.Id;
	}
}
