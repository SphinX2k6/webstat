using System;
using Aki.Protocol;
using CSharpScript.Game.Module.Roguelike;

// Token: 0x020006E3 RID: 1763
// (Invoke) Token: 0x06001D3F RID: 7487
[EventRule(EEventName.RoguelikeChooseDataResult)]
internal delegate void Delegate_RoguelikeChooseDataResult(CSharpScript.Game.Module.Roguelike.RogueGainEntry newRogueGainEntry, CSharpScript.Game.Module.Roguelike.RogueGainEntry oldRogueGainEntry, bool isSuccess, int bindId, RoguelikeChooseDataResultResponse response);
