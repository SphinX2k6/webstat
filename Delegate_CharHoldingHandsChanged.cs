using System;

// Token: 0x02000158 RID: 344
// (Invoke) Token: 0x06000713 RID: 1811
[EventRule(EEventName.CharHoldingHandsChanged)]
internal delegate void Delegate_CharHoldingHandsChanged(int entityId, bool isEnter, EHoldingHandsRoleState state, EHandType handType);
