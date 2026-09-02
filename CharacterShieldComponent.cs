using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

// Token: 0x02003066 RID: 12390
[NullableContext(2)]
[Nullable(0)]
public class CharacterShieldComponent : EntityComponent
{
	// Token: 0x17002257 RID: 8791
	// (get) Token: 0x0601975C RID: 104284 RVA: 0x0075C3D1 File Offset: 0x0075A5D1
	public float ShieldTotal
	{
		get
		{
			return this.ShieldTotalInternal;
		}
	}

	// Token: 0x0601975D RID: 104285 RVA: 0x0075C3D9 File Offset: 0x0075A5D9
	protected override bool OnStart()
	{
		this.BuffComponent = base.Entity.CheckGetComponent<CharacterBuffComponent>();
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		return true;
	}

	// Token: 0x0601975E RID: 104286 RVA: 0x0075C400 File Offset: 0x0075A600
	protected override void OnActivate()
	{
		this.ShieldMap.Clear();
		this.ShieldTotalInternal = 0f;
		EntityComponentPb valueOrDefault = base.Entity.GetComponent<CreatureDataComponent>().ComponentDataMap.GetValueOrDefault("ShieldComponentPb");
		RepeatedField<ShieldInfoPb> repeatedField;
		if (valueOrDefault == null)
		{
			repeatedField = null;
		}
		else
		{
			ShieldComponentPb shieldComponentPb = valueOrDefault.ShieldComponentPb;
			repeatedField = ((shieldComponentPb != null) ? shieldComponentPb.ShieldInfoPbList : null);
		}
		RepeatedField<ShieldInfoPb> repeatedField2 = repeatedField;
		if (repeatedField2 == null)
		{
			return;
		}
		foreach (ShieldInfoPb shieldInfoPb in repeatedField2)
		{
			this.Add(shieldInfoPb.Handle, shieldInfoPb.ConfigId, (float)shieldInfoPb.ShieldValue, global::EShieldUpdateType.Add);
		}
	}

	// Token: 0x0601975F RID: 104287 RVA: 0x0075C4A8 File Offset: 0x0075A6A8
	private void AddShieldTotal(float value)
	{
		if (this.ShieldTotalInternal == 0f && value > 0f)
		{
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.持有护盾"]));
		}
		else if (this.ShieldTotalInternal > 0f && this.ShieldTotalInternal + value <= 0f)
		{
			this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.持有护盾"]));
		}
		this.ShieldTotalInternal += value;
		Singleton<EventSystem>.Instance.EmitWithTarget<float>(base.Entity, EEventName.CharShieldChange, this.ShieldTotalInternal);
	}

	// Token: 0x06019760 RID: 104288 RVA: 0x0075C550 File Offset: 0x0075A750
	public void Add(int handleId, int templateId, float value, global::EShieldUpdateType updateType = global::EShieldUpdateType.Add)
	{
		if (this.ShieldMap.ContainsKey(handleId))
		{
			this.ChangeValue(handleId, templateId, value, updateType);
		}
		else
		{
			CharacterShield characterShield = new CharacterShield(handleId, templateId, value);
			this.ShieldMap.Add(handleId, characterShield);
			this.AddShieldTotal(characterShield.ShieldValue);
			this.TriggerAbilityEvent(0f, value, updateType, templateId);
		}
		this.BuffComponent.TriggerEvents(EBuffTriggerType.ForWhenAppendShield, this.BuffComponent, new Partial_RequirementPayload());
	}

	// Token: 0x06019761 RID: 104289 RVA: 0x0075C5C0 File Offset: 0x0075A7C0
	public void Remove(int handleId, int templateId, global::EShieldUpdateType updateType = global::EShieldUpdateType.Remove)
	{
		CharacterShield characterShield;
		if (this.ShieldMap.Remove(handleId, out characterShield))
		{
			this.AddShieldTotal(-characterShield.ShieldValue);
			this.OnShieldInvalid();
			this.TriggerAbilityEvent(characterShield.ShieldValue, 0f, updateType, templateId);
		}
	}

	// Token: 0x06019762 RID: 104290 RVA: 0x0075C604 File Offset: 0x0075A804
	public void ChangeValue(int handleId, int templateId, float value, global::EShieldUpdateType updateType = global::EShieldUpdateType.Modify)
	{
		CharacterShield characterShield;
		if (this.ShieldMap.TryGetValue(handleId, out characterShield))
		{
			float shieldValue = characterShield.ShieldValue;
			characterShield.ShieldValue = value;
			this.AddShieldTotal(value - shieldValue);
			this.TriggerAbilityEvent(shieldValue, value, updateType, templateId);
			return;
		}
		this.Add(handleId, templateId, value, global::EShieldUpdateType.Add);
	}

	// Token: 0x06019763 RID: 104291 RVA: 0x0075C650 File Offset: 0x0075A850
	[CombatListen(ENotifyMessageId.ShieldUpdateNotify, false, false)]
	public static void OnShieldUpdateNotify(Entity entity, [Nullable(1)] ShieldUpdateNotify data, CombatCommon combatCommon = null)
	{
		CharacterShieldComponent characterShieldComponent = (entity != null) ? entity.GetComponent<CharacterShieldComponent>() : null;
		if (characterShieldComponent == null)
		{
			return;
		}
		foreach (ShieldUpdateInfo shieldUpdateInfo in data.Shields)
		{
			Aki.Protocol.EShieldUpdateType updateType = shieldUpdateInfo.UpdateType;
			if (updateType == Aki.Protocol.EShieldUpdateType.Add && shieldUpdateInfo.ShieldValue > 0)
			{
				characterShieldComponent.Add(shieldUpdateInfo.Handle, shieldUpdateInfo.ConfigId, (float)shieldUpdateInfo.ShieldValue, global::EShieldUpdateType.Add);
			}
			else if (updateType == Aki.Protocol.EShieldUpdateType.Del && shieldUpdateInfo.ShieldValue == 0)
			{
				characterShieldComponent.Remove(shieldUpdateInfo.Handle, shieldUpdateInfo.ConfigId, global::EShieldUpdateType.Remove);
			}
			else if (updateType == Aki.Protocol.EShieldUpdateType.Modify && shieldUpdateInfo.ShieldValue > 0)
			{
				characterShieldComponent.ChangeValue(shieldUpdateInfo.Handle, shieldUpdateInfo.ConfigId, (float)shieldUpdateInfo.ShieldValue, global::EShieldUpdateType.Modify);
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.ZFJ;
				string message = "护盾更新错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("shield", shieldUpdateInfo);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x06019764 RID: 104292 RVA: 0x0075C750 File Offset: 0x0075A950
	public float GetShieldValue(int shieldCid)
	{
		if (shieldCid == 0)
		{
			return this.ShieldTotal;
		}
		float num = 0f;
		foreach (CharacterShield characterShield in this.ShieldMap.Values)
		{
			if (characterShield.TemplateId == shieldCid)
			{
				num += characterShield.ShieldValue;
			}
		}
		return num;
	}

	// Token: 0x06019765 RID: 104293 RVA: 0x0075C7C4 File Offset: 0x0075A9C4
	private void OnShieldInvalid()
	{
		this.BuffComponent.TriggerEvents(EBuffTriggerType.ForWhenRemoveShield, this.BuffComponent, new Partial_RequirementPayload());
	}

	// Token: 0x06019766 RID: 104294 RVA: 0x0075C7E0 File Offset: 0x0075A9E0
	private void TriggerAbilityEvent(float oldShieldValue, float newShieldValue, global::EShieldUpdateType updateType, int shieldId)
	{
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<Entity, float, float, int, int>(base.Entity, EAbilityEventName.ShieldChange, 0L, base.Entity, oldShieldValue, newShieldValue, (int)updateType, shieldId);
	}

	// Token: 0x06019767 RID: 104295 RVA: 0x0075C80B File Offset: 0x0075AA0B
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public IEnumerable<KeyValuePair<int, CharacterShield>> GetDebugShieldInfo()
	{
		return this.ShieldMap;
	}

	// Token: 0x06019768 RID: 104296 RVA: 0x0075C814 File Offset: 0x0075AA14
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterShieldComponent characterShieldComponent = (CharacterShieldComponent)componentTemplate;
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (characterShieldComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (characterShieldComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ShieldMap") && characterShieldComponent.ShieldMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, CharacterShield>>(this.ShieldMap), "ShieldMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ShieldTotalInternal"))
		{
			this.ShieldTotalInternal = characterShieldComponent.ShieldTotalInternal;
		}
		return true;
	}

	// Token: 0x0400C9C0 RID: 51648
	private CharacterBuffComponent BuffComponent;

	// Token: 0x0400C9C1 RID: 51649
	private BaseTagComponent TagComponent;

	// Token: 0x0400C9C2 RID: 51650
	[Nullable(1)]
	private readonly Dictionary<int, CharacterShield> ShieldMap = new Dictionary<int, CharacterShield>();

	// Token: 0x0400C9C3 RID: 51651
	private float ShieldTotalInternal;
}
