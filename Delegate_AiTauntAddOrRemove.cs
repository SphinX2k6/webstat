using System;

// Token: 0x02000167 RID: 359
// (Invoke) Token: 0x0600074F RID: 1871
[EventRule(EEventName.AiTauntAddOrRemove)]
internal delegate void Delegate_AiTauntAddOrRemove(bool addOrRemove, int instigatorEntityId, int handleId);
