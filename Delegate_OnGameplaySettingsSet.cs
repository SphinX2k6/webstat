using System;

// Token: 0x0200024A RID: 586
// (Invoke) Token: 0x06000ADB RID: 2779
[EventRule(EEventName.OnGameplaySettingsSet)]
internal delegate void Delegate_OnGameplaySettingsSet(EFunction functionId, int value, bool directly);
