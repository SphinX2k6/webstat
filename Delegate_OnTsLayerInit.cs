using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02000A41 RID: 2625
// (Invoke) Token: 0x06002AB7 RID: 10935
[EventRule(EEventName.OnTsLayerInit)]
internal delegate void Delegate_OnTsLayerInit(IReadOnlyList<AActor> actorList, IReadOnlyList<UUIItem> itemList, IReadOnlyDictionary<ELayerType, List<UUIItem>> floatUnitMap, UUIItem pureBattleFloatUnitItem);
