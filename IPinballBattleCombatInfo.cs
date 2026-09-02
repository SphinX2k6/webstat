using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000F5F RID: 3935
[NullableContext(2)]
public interface IPinballBattleCombatInfo
{
	// Token: 0x17000765 RID: 1893
	// (get) Token: 0x06006339 RID: 25401
	// (set) Token: 0x0600633A RID: 25402
	EPinballBattleEntityType EntityType { get; set; }

	// Token: 0x17000766 RID: 1894
	// (get) Token: 0x0600633B RID: 25403
	// (set) Token: 0x0600633C RID: 25404
	int Uid { get; set; }

	// Token: 0x17000767 RID: 1895
	// (get) Token: 0x0600633D RID: 25405
	// (set) Token: 0x0600633E RID: 25406
	int OwnerId { get; set; }

	// Token: 0x17000768 RID: 1896
	// (get) Token: 0x0600633F RID: 25407
	// (set) Token: 0x06006340 RID: 25408
	int TemplateId { get; set; }

	// Token: 0x17000769 RID: 1897
	// (get) Token: 0x06006341 RID: 25409
	// (set) Token: 0x06006342 RID: 25410
	int CombatId { get; set; }

	// Token: 0x1700076A RID: 1898
	// (get) Token: 0x06006343 RID: 25411
	// (set) Token: 0x06006344 RID: 25412
	int SubTypeId { get; set; }

	// Token: 0x1700076B RID: 1899
	// (get) Token: 0x06006345 RID: 25413
	// (set) Token: 0x06006346 RID: 25414
	string PrefabPath { get; set; }

	// Token: 0x1700076C RID: 1900
	// (get) Token: 0x06006347 RID: 25415
	// (set) Token: 0x06006348 RID: 25416
	string AssetPath { get; set; }

	// Token: 0x1700076D RID: 1901
	// (get) Token: 0x06006349 RID: 25417
	// (set) Token: 0x0600634A RID: 25418
	int PropertyId { get; set; }

	// Token: 0x1700076E RID: 1902
	// (get) Token: 0x0600634B RID: 25419
	// (set) Token: 0x0600634C RID: 25420
	int? SplineId { get; set; }

	// Token: 0x1700076F RID: 1903
	// (get) Token: 0x0600634D RID: 25421
	// (set) Token: 0x0600634E RID: 25422
	Dictionary<int, int> BuffIdLayers { get; set; }

	// Token: 0x17000770 RID: 1904
	// (get) Token: 0x0600634F RID: 25423
	// (set) Token: 0x06006350 RID: 25424
	Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x17000771 RID: 1905
	// (get) Token: 0x06006351 RID: 25425
	// (set) Token: 0x06006352 RID: 25426
	[Nullable(1)]
	Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000772 RID: 1906
	// (get) Token: 0x06006353 RID: 25427
	// (set) Token: 0x06006354 RID: 25428
	[Nullable(1)]
	Rotator Rotation { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x06006355 RID: 25429
	[NullableContext(1)]
	void Update(IPinballBattleCombatInfo other);

	// Token: 0x06006356 RID: 25430
	bool IsValid();

	// Token: 0x06006357 RID: 25431
	void Reset();

	// Token: 0x06006358 RID: 25432
	void Release();

	// Token: 0x06006359 RID: 25433
	[NullableContext(1)]
	IPinballBattleCombatInfo Clone();
}
