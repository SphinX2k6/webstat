using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Google.Protobuf;

// Token: 0x02003033 RID: 12339
[NullableContext(1)]
[Nullable(0)]
public class TCombatMessage
{
	// Token: 0x170021FF RID: 8703
	// (get) Token: 0x060193B3 RID: 103347 RVA: 0x0073945D File Offset: 0x0073765D
	// (set) Token: 0x060193B4 RID: 103348 RVA: 0x00739465 File Offset: 0x00737665
	public CombatCommon CombatCommon { get; set; }

	// Token: 0x17002200 RID: 8704
	// (get) Token: 0x060193B5 RID: 103349 RVA: 0x0073946E File Offset: 0x0073766E
	// (set) Token: 0x060193B6 RID: 103350 RVA: 0x00739476 File Offset: 0x00737676
	public ENotifyMessageId MessageId { get; set; }

	// Token: 0x17002201 RID: 8705
	// (get) Token: 0x060193B7 RID: 103351 RVA: 0x0073947F File Offset: 0x0073767F
	// (set) Token: 0x060193B8 RID: 103352 RVA: 0x00739487 File Offset: 0x00737687
	public IMessage Message { get; set; }

	// Token: 0x17002202 RID: 8706
	// (get) Token: 0x060193B9 RID: 103353 RVA: 0x00739490 File Offset: 0x00737690
	// (set) Token: 0x060193BA RID: 103354 RVA: 0x00739498 File Offset: 0x00737698
	public double ExecuteTime { get; set; }

	// Token: 0x060193BB RID: 103355 RVA: 0x007394A1 File Offset: 0x007376A1
	public TCombatMessage(CombatCommon combatCommon, ENotifyMessageId messageId, IMessage message, double executeTime)
	{
		this.CombatCommon = combatCommon;
		this.MessageId = messageId;
		this.Message = message;
		this.ExecuteTime = executeTime;
	}
}
