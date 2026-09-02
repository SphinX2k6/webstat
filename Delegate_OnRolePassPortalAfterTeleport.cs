using System;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

// Token: 0x02000830 RID: 2096
// (Invoke) Token: 0x06002273 RID: 8819
[EventRule(EEventName.OnRolePassPortalAfterTeleport)]
internal delegate void Delegate_OnRolePassPortalAfterTeleport(EntityHandle roleHandle, SceneItemPortalComponent inPortalComp, SceneItemPortalComponent outPortalComp);
