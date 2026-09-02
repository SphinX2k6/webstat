using System;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;

// Token: 0x0200069C RID: 1692
// (Invoke) Token: 0x06001C23 RID: 7203
[EventRule(EEventName.OnPlayCameraAnimationStart)]
internal delegate void Delegate_OnPlayCameraAnimationStart(UiCameraHandleData fromHandleData, UiCameraHandleData toHandleData, string blendName);
