using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x020008AF RID: 2223
// (Invoke) Token: 0x0600246F RID: 9327
[EventRule(EEventName.StartMoveWithSpline)]
internal delegate void Delegate_StartMoveWithSpline(MoveWithSpline eventParam, bool noSyncPoint, [Nullable(2)] Action<bool> callback);
