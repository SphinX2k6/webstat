using System;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x020033B9 RID: 13241
public class RedDotRoleFavorTab : RedDotBase
{
	// Token: 0x0601B8CC RID: 112844 RVA: 0x0083B098 File Offset: 0x00839298
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleLangCustomFuncClicked, new Action<int>(this.OnRoleLangCustomFuncClicked));
	}

	// Token: 0x0601B8CD RID: 112845 RVA: 0x0083B0B6 File Offset: 0x008392B6
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleLangCustomFuncClicked, new Action<int>(this.OnRoleLangCustomFuncClicked));
	}

	// Token: 0x0601B8CE RID: 112846 RVA: 0x0083B0D4 File Offset: 0x008392D4
	private void OnRoleLangCustomFuncClicked(int roleId)
	{
		base.EventCheck();
	}

	// Token: 0x0601B8CF RID: 112847 RVA: 0x0083B0DC File Offset: 0x008392DC
	protected override bool OnCheck(int roleId = 0)
	{
		ServerStorageBoolean serverStorageBoolean = (ServerStorageBoolean)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomFuncClicked);
		return !serverStorageBoolean.Get().GetValueOrDefault() || !serverStorageBoolean.Get().Value;
	}
}
