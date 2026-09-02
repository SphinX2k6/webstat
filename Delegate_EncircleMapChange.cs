using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Encircle;

// Token: 0x020009F4 RID: 2548
// (Invoke) Token: 0x06002983 RID: 10627
[EventRule(EEventName.EncircleMapChange)]
internal delegate void Delegate_EncircleMapChange(int mapItemId, IHexPos currentPos, [Nullable(2)] IHexPos oldPos);
