using System;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x020005E1 RID: 1505
// (Invoke) Token: 0x06001937 RID: 6455
[EventRule(EEventName.CameraModeChanged)]
internal delegate void Delegate_CameraModeChanged(ECustomCameraMode newMode, ECustomCameraMode? oldMode, string cameraName);
