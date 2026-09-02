using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x020008FC RID: 2300
// (Invoke) Token: 0x060025A3 RID: 9635
[EventRule(EEventName.OwnBattleAttrChange)]
internal delegate void Delegate_OwnBattleAttrChange(IReadOnlyList<PhantomBattleCardAttr> attrList);
