using System;
using Aki.Protocol;

// Token: 0x02000445 RID: 1093
// (Invoke) Token: 0x060012C7 RID: 4807
[EventRule(EEventName.OnServerAttributeChange)]
internal delegate void Delegate_OnServerAttributeChange(int entityId, AttributeChangedNotify attributeData);
