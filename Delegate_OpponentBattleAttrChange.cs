using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x02000901 RID: 2305
// (Invoke) Token: 0x060025B7 RID: 9655
[EventRule(EEventName.OpponentBattleAttrChange)]
internal delegate void Delegate_OpponentBattleAttrChange(IReadOnlyList<PhantomBattleCardAttr> attrList);
