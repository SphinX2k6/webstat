using System;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020003C1 RID: 961
// (Invoke) Token: 0x060010B7 RID: 4279
[EventRule(EEventName.AfterLogicTreeChildQuestNodeStatusChange)]
internal delegate void Delegate_AfterLogicTreeChildQuestNodeStatusChange(GeneralContext contextType, ChildQuestNodeStatus oldStatus, ChildQuestNodeStatus newStatus);
