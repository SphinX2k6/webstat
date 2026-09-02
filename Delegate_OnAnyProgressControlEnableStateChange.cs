using System;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

// Token: 0x020006B6 RID: 1718
// (Invoke) Token: 0x06001C8B RID: 7307
[EventRule(EEventName.OnAnyProgressControlEnableStateChange)]
internal delegate void Delegate_OnAnyProgressControlEnableStateChange(Entity entity, bool isEnable, SceneItemProgressControlComponent.TProgressData progressData);
