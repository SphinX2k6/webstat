using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E6E RID: 11886
[NullableContext(2)]
public interface IActiveBuff
{
	// Token: 0x170020CD RID: 8397
	// (get) Token: 0x060186BD RID: 100029
	long? InstigatorId { get; }

	// Token: 0x060186BE RID: 100030
	Entity GetInstigator();

	// Token: 0x060186BF RID: 100031
	CharacterBuffComponent GetInstigatorBuffComponent();

	// Token: 0x060186C0 RID: 100032
	CharacterActorComponent GetInstigatorActorComponent();

	// Token: 0x060186C1 RID: 100033
	Entity GetOwner();

	// Token: 0x060186C2 RID: 100034
	IBuffComponent GetOwnerBuffComponent();

	// Token: 0x060186C3 RID: 100035
	[NullableContext(1)]
	string GetOwnerDebugName();

	// Token: 0x060186C4 RID: 100036
	bool IsActive();

	// Token: 0x170020CE RID: 8398
	// (get) Token: 0x060186C5 RID: 100037
	[Nullable(1)]
	BuffDefinition Config { [NullableContext(1)] get; }

	// Token: 0x170020CF RID: 8399
	// (get) Token: 0x060186C6 RID: 100038
	float Duration { get; }

	// Token: 0x060186C7 RID: 100039
	float GetRemainDuration();

	// Token: 0x060186C8 RID: 100040
	bool IsValid();

	// Token: 0x170020D0 RID: 8400
	// (get) Token: 0x060186C9 RID: 100041
	int StackCount { get; }

	// Token: 0x170020D1 RID: 8401
	// (get) Token: 0x060186CA RID: 100042
	long Id { get; }

	// Token: 0x170020D2 RID: 8402
	// (get) Token: 0x060186CB RID: 100043
	int Handle { get; }

	// Token: 0x170020D3 RID: 8403
	// (get) Token: 0x060186CC RID: 100044
	int ServerId { get; }

	// Token: 0x170020D4 RID: 8404
	// (get) Token: 0x060186CD RID: 100045
	int Level { get; }

	// Token: 0x170020D5 RID: 8405
	// (get) Token: 0x060186CE RID: 100046
	long? MessageId { get; }

	// Token: 0x170020D6 RID: 8406
	// (get) Token: 0x060186CF RID: 100047
	long? PreMessageId { get; }

	// Token: 0x060186D0 RID: 100048
	bool IsInstantBuff();

	// Token: 0x060186D1 RID: 100049
	void SetBuffTimeScale(int buffHandle, float timeScale);

	// Token: 0x060186D2 RID: 100050
	void RemoveBuffTimeScale(int buffHandle);

	// Token: 0x170020D7 RID: 8407
	// (get) Token: 0x060186D3 RID: 100051
	float CreateTimestamp { get; }
}
