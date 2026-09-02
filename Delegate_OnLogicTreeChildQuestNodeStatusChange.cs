using System;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020003C0 RID: 960
// (Invoke) Token: 0x060010B3 RID: 4275
[EventRule(EEventName.OnLogicTreeChildQuestNodeStatusChange)]
internal delegate void Delegate_OnLogicTreeChildQuestNodeStatusChange(GeneralContext contextType, ChildQuestNodeStatus oldStatus, ChildQuestNodeStatus newStatus, ENodeStatusUpdateReason reason);
