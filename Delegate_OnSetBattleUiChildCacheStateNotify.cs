using System;
using CSharpScript.Game.Module.BattleUi;

// Token: 0x02000B25 RID: 2853
// (Invoke) Token: 0x06002E47 RID: 11847
[EventRule(EEventName.OnSetBattleUiChildCacheStateNotify)]
internal delegate void Delegate_OnSetBattleUiChildCacheStateNotify(EBattleUiChildCacheType cacheType, bool needCache);
