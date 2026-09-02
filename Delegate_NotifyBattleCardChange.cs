using System;

// Token: 0x02000910 RID: 2320
// (Invoke) Token: 0x060025F3 RID: 9715
[EventRule(EEventName.NotifyBattleCardChange)]
internal delegate void Delegate_NotifyBattleCardChange(bool isOwn, int indexA, int indexB);
