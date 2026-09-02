using System;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020003BF RID: 959
// (Invoke) Token: 0x060010AF RID: 4271
[EventRule(EEventName.OnLogicTreeNodeStatusChange)]
internal delegate void Delegate_OnLogicTreeNodeStatusChange(GeneralContext contextType, NodeStatus oldStatus, NodeStatus newStatus, ENodeStatusUpdateReason reason);
