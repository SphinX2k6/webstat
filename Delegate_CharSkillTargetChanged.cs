using System;
using System.Runtime.CompilerServices;

// Token: 0x020000F5 RID: 245
// (Invoke) Token: 0x06000587 RID: 1415
[EventRule(EEventName.CharSkillTargetChanged)]
internal delegate void Delegate_CharSkillTargetChanged([Nullable(2)] EntityHandle skillTarget, string skillTargetSocket);
