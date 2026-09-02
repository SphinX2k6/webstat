using System;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020003AF RID: 943
// (Invoke) Token: 0x0600106F RID: 4207
[EventRule(EEventName.AddInteractOptionByAction)]
internal delegate void Delegate_AddInteractOptionByAction(GeneralContext context, int optionId, IAddInteractOption addOption);
