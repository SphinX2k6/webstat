using System;

// Token: 0x02000E39 RID: 3641
public interface IGameCapability
{
	// Token: 0x06005721 RID: 22305
	bool ShouldActivate();

	// Token: 0x06005722 RID: 22306
	void Activate();

	// Token: 0x06005723 RID: 22307
	void OnActivated();

	// Token: 0x06005724 RID: 22308
	bool ShouldDeactivate();

	// Token: 0x06005725 RID: 22309
	void Deactivate();

	// Token: 0x06005726 RID: 22310 RVA: 0x001053FF File Offset: 0x001035FF
	bool? ShouldTickActive()
	{
		return new bool?(false);
	}

	// Token: 0x06005727 RID: 22311
	void OnDeactivated();

	// Token: 0x06005728 RID: 22312
	void TickActive(float deltaTime);
}
