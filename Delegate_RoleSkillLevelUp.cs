using System;
using Aki.Protocol;

// Token: 0x020001DA RID: 474
// (Invoke) Token: 0x0600091B RID: 2331
[EventRule(EEventName.RoleSkillLevelUp)]
internal delegate void Delegate_RoleSkillLevelUp(int roleId, ArrayIntInt skillInfo);
