using System;
using System.Collections.Generic;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine;

// Token: 0x02000B83 RID: 2947
// (Invoke) Token: 0x06002FBF RID: 12223
[EventRule(EEventName.OnDollGrabMachineGrabDoll)]
internal delegate void Delegate_OnDollGrabMachineGrabDoll(int leaveDollCount, List<IGrabItemData> grabItemDataList);
