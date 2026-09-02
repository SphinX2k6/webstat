using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

// Token: 0x020004AA RID: 1194
// (Invoke) Token: 0x0600145B RID: 5211
[EventRule(EEventName.OnAddMaterialController)]
internal delegate void Delegate_OnAddMaterialController(PD_CharacterControllerData_C data, [Nullable(2)] UObject userData, int handle);
