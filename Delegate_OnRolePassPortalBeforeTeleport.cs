using System;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

// Token: 0x0200082F RID: 2095
// (Invoke) Token: 0x0600226F RID: 8815
[EventRule(EEventName.OnRolePassPortalBeforeTeleport)]
internal delegate void Delegate_OnRolePassPortalBeforeTeleport(EntityHandle roleHandle, SceneItemPortalComponent inPortalComp, SceneItemPortalComponent outPortalComp);
