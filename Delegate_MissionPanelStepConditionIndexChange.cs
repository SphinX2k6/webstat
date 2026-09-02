using System;
using CSharpScript.Game.Module.BattleUi.Views;

// Token: 0x020003AA RID: 938
// (Invoke) Token: 0x0600105B RID: 4187
[EventRule(EEventName.MissionPanelStepConditionIndexChange)]
internal delegate void Delegate_MissionPanelStepConditionIndexChange(EMissionItemView viewId, int stepId, int? curConditionTextIndex);
