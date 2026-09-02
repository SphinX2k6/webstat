using System;
using UnrealEngine;

// Token: 0x020005E0 RID: 1504
// (Invoke) Token: 0x06001933 RID: 6451
[EventRule(EEventName.PlayCameraLevelSequence)]
internal delegate void Delegate_PlayCameraLevelSequence(ULevelSequence levelSequence, AActor role, ALevelSequenceActor sequenceActor, FTransformDouble startTransform, bool playResult, bool isStopModify, string cameraName);
