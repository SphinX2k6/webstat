using System;
using System.Collections.Generic;

// Token: 0x02000354 RID: 852
// (Invoke) Token: 0x06000F03 RID: 3843
[EventRule(EEventName.OnLevelTagChanged)]
internal delegate void Delegate_OnLevelTagChanged(IReadOnlyList<int> addedTags, IReadOnlyList<int> removedTags);
