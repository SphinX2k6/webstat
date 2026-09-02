using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Manipulate;

// Token: 0x020004BD RID: 1213
// (Invoke) Token: 0x060014A7 RID: 5287
[EventRule(EEventName.OnManipulatableItemStateModified)]
internal delegate void Delegate_OnManipulatableItemStateModified(SceneItemManipulatableComponent.EManipulatableState oldStateEnum, SceneItemManipulatableComponent.EManipulatableState newStateEnum, [Nullable(1)] Entity entity, SceneItemManipulableBaseState oldState, SceneItemManipulableBaseState newState);
