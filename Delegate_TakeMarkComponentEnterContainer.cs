using System;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

// Token: 0x02000713 RID: 1811
// (Invoke) Token: 0x06001DFF RID: 7679
[EventRule(EEventName.TakeMarkComponentEnterContainer)]
internal delegate void Delegate_TakeMarkComponentEnterContainer(UUIItem markComponentRootItem, EMarkType markType, EMarkPriorityType showPriority);
