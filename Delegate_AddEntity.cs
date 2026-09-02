using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x020001B2 RID: 434
// (Invoke) Token: 0x0600087B RID: 2171
[EventRule(EEventName.AddEntity)]
internal delegate void Delegate_AddEntity(EAddEntityType addType, EntityHandle handle, [Nullable(2)] AActor actor);
