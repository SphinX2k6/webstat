using System;
using Aki.Protocol;

// Token: 0x020003B1 RID: 945
// (Invoke) Token: 0x06001077 RID: 4215
[EventRule(EEventName.OnQuestStateChange)]
internal delegate void Delegate_OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason);
