using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000152 RID: 338
// (Invoke) Token: 0x060006FB RID: 1787
[EventRule(EEventName.CharPossessed)]
internal delegate void Delegate_CharPossessed(Entity entity, [Nullable(2)] AController newController);
