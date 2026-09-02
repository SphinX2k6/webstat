using System;

// Token: 0x020005A9 RID: 1449
// (Invoke) Token: 0x06001857 RID: 6231
[EventRule(EEventName.OnCharacterCapsuleChanged)]
internal delegate void Delegate_OnCharacterCapsuleChanged(Entity entity, float newRadius, float newHalfHeight, bool bUpdateOverlaps);
