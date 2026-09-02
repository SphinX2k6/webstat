using System;

// Token: 0x02000103 RID: 259
// (Invoke) Token: 0x060005BF RID: 1471
[EventRule(EEventName.OnBeforeSkillSimulateMontage)]
internal delegate void Delegate_OnBeforeSkillSimulateMontage(int entityId, int skillId, int montageIndex, float startTimeSeconds);
