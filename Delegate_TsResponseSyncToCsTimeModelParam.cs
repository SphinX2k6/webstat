using System;

// Token: 0x02000AA6 RID: 2726
// (Invoke) Token: 0x06002C4B RID: 11339
[EventRule(EEventName.TsResponseSyncToCsTimeModelParam)]
internal delegate void Delegate_TsResponseSyncToCsTimeModelParam(bool freezeTimeScale, bool timeRunLockStateClient, bool timeRunLockStateServer, bool timeSyncLockStateClient, bool timeSyncLockStateServer);
