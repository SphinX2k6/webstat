using System;
using System.Runtime.CompilerServices;

// Token: 0x02000226 RID: 550
// (Invoke) Token: 0x06000A4B RID: 2635
[EventRule(EEventName.BulletHit)]
internal delegate void Delegate_BulletHit(HitInformation hitData, [Nullable(2)] IAttributeSet attackerAttribute);
