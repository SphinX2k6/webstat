using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002E73 RID: 11891
[NullableContext(2)]
public interface IBuffComponent
{
	// Token: 0x06018737 RID: 100151
	[NullableContext(1)]
	void AddBuff(long buffId, AddBuffParam buffParams);

	// Token: 0x06018738 RID: 100152
	[NullableContext(1)]
	int AddBuffLocal(long buffId, AddBuffParam buffParams);

	// Token: 0x06018739 RID: 100153
	bool HasBuff(long buffId, bool excludeRequestRemove = false);

	// Token: 0x0601873A RID: 100154
	void AddIterativeBuff(long buffId, IActiveBuff preBuff, int? stackCount, bool isIterable, [Nullable(1)] string reason, long? bulletMessageId = null, IBuffComponent instigator = null);

	// Token: 0x0601873B RID: 100155
	[NullableContext(1)]
	void RemoveBuff(long buffId, int stackCount, string reason, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null);

	// Token: 0x0601873C RID: 100156
	int RemoveBuffByHandle(int handle, int removeStackCount = -1, string reason = null, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null);

	// Token: 0x0601873D RID: 100157
	[NullableContext(1)]
	void RemoveBuffWhenTimeout(ActiveBuffInternal buff);

	// Token: 0x0601873E RID: 100158
	int? GetBuffLevel(long buffId);

	// Token: 0x0601873F RID: 100159
	int GetBuffTotalStackById(long buffId, bool onlyActiveBuff = false);

	// Token: 0x06018740 RID: 100160
	[NullableContext(1)]
	string GetDebugName();

	// Token: 0x170020F7 RID: 8439
	// (get) Token: 0x06018741 RID: 100161
	bool Valid { get; }

	// Token: 0x170020F8 RID: 8440
	// (get) Token: 0x06018742 RID: 100162
	ExtraEffectManager BuffEffectManager { get; }

	// Token: 0x06018743 RID: 100163
	Entity GetEntity();

	// Token: 0x06018744 RID: 100164
	Entity GetExactEntity();

	// Token: 0x06018745 RID: 100165
	BaseAttributeComponent GetAttributeComponent();

	// Token: 0x06018746 RID: 100166
	BaseTagComponent GetTagComponent();

	// Token: 0x06018747 RID: 100167
	BaseSkillComponent GetSkillComponent();

	// Token: 0x06018748 RID: 100168
	CharacterPassiveSkillComponent GetPassiveSkillComponent();

	// Token: 0x06018749 RID: 100169
	BaseActorComponent GetActorComponent();

	// Token: 0x0601874A RID: 100170
	ActiveBuffInternal GetBuffById(long buffId);

	// Token: 0x0601874B RID: 100171
	IActiveBuff GetBuffByHandle(int handleId);

	// Token: 0x0601874C RID: 100172
	IActiveBuff GetPendingBuffByHandle(int handleId);

	// Token: 0x0601874D RID: 100173
	bool HasBuffAuthority();

	// Token: 0x0601874E RID: 100174
	void RemoveTrigger(int handleId, EBuffTriggerType extraEffectType);

	// Token: 0x0601874F RID: 100175
	void SetBuffEffectCd(long buffId, int index, float remainCd);

	// Token: 0x06018750 RID: 100176
	void SetBuffEffectCdForTarget(long buffId, int index, int targetEntityId, float remainCd);

	// Token: 0x06018751 RID: 100177
	double GetBuffEffectCd(long buffId, int index);

	// Token: 0x06018752 RID: 100178
	[NullableContext(1)]
	string GetTargetCdDebugStr(long buffId, int index);

	// Token: 0x06018753 RID: 100179
	double GetBuffEffectCdForTarget(long buffId, int index, int targetEntityId);

	// Token: 0x06018754 RID: 100180
	[NullableContext(1)]
	void ApplyPeriodExecution(ActiveBuffInternal buff);

	// Token: 0x06018755 RID: 100181
	void AddBuffStackModifier(long targetBuffId, int handle, int value, EBuffStackModifierType modifierType);

	// Token: 0x06018756 RID: 100182
	int? CalculateBuffStackMax(long buffId);

	// Token: 0x06018757 RID: 100183
	void RemoveBuffStackModifier(long targetBuffId, int handle);

	// Token: 0x06018758 RID: 100184
	void AddBuffRoutineExpirationLock(long buffId);

	// Token: 0x06018759 RID: 100185
	void RemoveBuffRoutineExpirationLock(long buffId);

	// Token: 0x0601875A RID: 100186
	void AddBuffTimeModifier(long targetBuffId, int handle, float period, float duration, bool asInstigator);

	// Token: 0x0601875B RID: 100187
	void RemoveBuffTimeModifier(long targetBuffId, int handle, bool asInstigator);

	// Token: 0x0601875C RID: 100188
	[NullableContext(1)]
	void ChangeBuffStack(long buffId, EBuffStackDurationOverride StackDurationRefreshPolicy, EBuffStackPeriodResetOverride StackPeriodResetPolicy, int stackChange, string reason, long? instigatorId = null);

	// Token: 0x0601875D RID: 100189
	[NullableContext(1)]
	HashSet<int> GetBuffHandleByEffectId(int effectId);

	// Token: 0x0601875E RID: 100190
	[NullableContext(1)]
	IEnumerable<ActiveBuffInternal> GetAllBuffById(long buffId);

	// Token: 0x0601875F RID: 100191
	float GetLogicTimeScale();

	// Token: 0x06018760 RID: 100192
	[NullableContext(1)]
	IActiveBuff[] GetAllBuffs();

	// Token: 0x06018761 RID: 100193
	[NullableContext(1)]
	bool AddReplaceBuff(long originBuffId, BuffReplace replaceBuffInfo);

	// Token: 0x06018762 RID: 100194
	bool RemoveReplaceBuff(long originBuffId);
}
