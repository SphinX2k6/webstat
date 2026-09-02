using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003068 RID: 12392
[NullableContext(1)]
[Nullable(0)]
public class CharacterSkinDamageComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x0601976A RID: 104298 RVA: 0x0075C900 File Offset: 0x0075AB00
	static CharacterSkinDamageComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterSkinDamageComponent.CreateStaticDefaultValue), new Action(CharacterSkinDamageComponent.ResetStaticDefaultValue));
	}

	// Token: 0x0601976B RID: 104299 RVA: 0x0075C9A4 File Offset: 0x0075ABA4
	protected override bool OnStart()
	{
		this.CreatureDataComp = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.ActorComp = base.Entity.CheckGetComponent<CharacterActorComponent>();
		this.TagComp = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.SkinDamageType = ESkinDamageType.Normal;
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleGoDown, new Action<int>(this.OnRoleGoDown));
		Singleton<EventSystem>.Instance.Add(EEventName.OnResetSkinDamageMode, new Action(this.OnResetSkinDamageMode));
		Singleton<EventSystem>.Instance.AddWithTarget<HitInformation, HitContext>(base.Entity, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnBeHit));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnRevive, new Action(this.OnRevive));
		Singleton<EventSystem>.Instance.AddWithTarget<bool>(base.Entity, EEventName.TeleportStartEntity, new Action<bool>(this.OnTeleportStart));
		return true;
	}

	// Token: 0x0601976C RID: 104300 RVA: 0x0075CAA4 File Offset: 0x0075ACA4
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleGoDown, new Action<int>(this.OnRoleGoDown));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResetSkinDamageMode, new Action(this.OnResetSkinDamageMode));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnBeHit));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnRevive, new Action(this.OnRevive));
		Singleton<EventSystem>.Instance.RemoveWithTarget<bool>(base.Entity, EEventName.TeleportStartEntity, new Action<bool>(this.OnTeleportStart));
		this.DestroyTimer();
		return true;
	}

	// Token: 0x0601976D RID: 104301 RVA: 0x0075CB70 File Offset: 0x0075AD70
	private void TryAddKuroChangeSkeletalMaterialsComponent()
	{
		this.KuroChangeSkeletalMaterialsComponent = (this.ActorComp.Actor.GetComponentByClass(UKuroChangeSkeletalMaterialsComponent.StaticClass()) as UKuroChangeSkeletalMaterialsComponent);
		UKuroChangeSkeletalMaterialsComponent kuroChangeSkeletalMaterialsComponent = this.KuroChangeSkeletalMaterialsComponent;
		if (kuroChangeSkeletalMaterialsComponent == null || !kuroChangeSkeletalMaterialsComponent.IsValid())
		{
			this.KuroChangeSkeletalMaterialsComponent = (this.ActorComp.Actor.AddComponentByClass(UKuroChangeSkeletalMaterialsComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, Singleton<CharacterNameDefines>.Instance.CHANGE_SKELETAL_MATERIALS_COMP_NAME) as UKuroChangeSkeletalMaterialsComponent);
		}
	}

	// Token: 0x0601976E RID: 104302 RVA: 0x0075CBF4 File Offset: 0x0075ADF4
	private void OnBattleStateChanged(bool inFight)
	{
		this.DestroyTimer();
		if (inFight)
		{
			this.BattleStartTime = Singleton<Time>.Instance.WorldTimeSeconds;
			this.BattleEndTime = 0.0;
		}
		else
		{
			this.BattleStartTime = 0.0;
			this.BattleEndTime = Singleton<Time>.Instance.WorldTimeSeconds;
			this.SetTimer();
		}
		this.BeHitCount = 0;
	}

	// Token: 0x0601976F RID: 104303 RVA: 0x0075CC58 File Offset: 0x0075AE58
	private void OnBeHit(HitInformation hitData, HitContext _)
	{
		if (this.BattleStartTime == 0.0)
		{
			return;
		}
		CharacterActorComponent component = hitData.Attacker.GetComponent<CharacterActorComponent>();
		if (component != null && CampUtils.GetCampRelationship(component.Actor.Camp, this.ActorComp.Actor.Camp) != ERelation.Enemy)
		{
			return;
		}
		this.BeHitCount++;
		this.ApplyBeHitCount();
	}

	// Token: 0x06019770 RID: 104304 RVA: 0x0075CCC0 File Offset: 0x0075AEC0
	private unsafe void ApplyBeHitCount()
	{
		double num = Singleton<Time>.Instance.WorldTimeSeconds - this.BattleStartTime;
		if (num > 20.0)
		{
			if (this.BeHitCount > 14)
			{
				ESkinDamageType type = ESkinDamageType.Damage2;
				bool force = false;
				string message = "加载2级战损贴图（受击）";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("battleStartDuration", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BeHitCount", this.BeHitCount);
				this.ApplySkinDamageByType(type, force, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (this.BeHitCount > 7)
			{
				ESkinDamageType type2 = ESkinDamageType.Damage1;
				bool force2 = false;
				string message2 = "加载1级战损贴图（受击）";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("battleStartDuration", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("BeHitCount", this.BeHitCount);
				this.ApplySkinDamageByType(type2, force2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
		}
	}

	// Token: 0x06019771 RID: 104305 RVA: 0x0075CDBC File Offset: 0x0075AFBC
	private void OnRevive()
	{
		if (ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			this.ApplySkinDamageByType(ESkinDamageType.Damage2, false, "加载2级战损贴图（复活）", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x06019772 RID: 104306 RVA: 0x0075CDEC File Offset: 0x0075AFEC
	private void OnTeleportStart(bool _)
	{
		this.ApplySkinDamageByType(ESkinDamageType.Normal, false, "战损恢复（传送）", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06019773 RID: 104307 RVA: 0x0075CE10 File Offset: 0x0075B010
	private void OnRoleGoDown(int entityId)
	{
		if (entityId != base.Entity.Id)
		{
			return;
		}
		if (this.BattleEndTime == 0.0)
		{
			return;
		}
		if (Singleton<Time>.Instance.WorldTimeSeconds - this.BattleEndTime > 20.0)
		{
			this.ApplySkinDamageByType(ESkinDamageType.Normal, false, "战损恢复（下场）", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x06019774 RID: 104308 RVA: 0x0075CE70 File Offset: 0x0075B070
	private void DestroyTimer()
	{
		if (this.EndSkinDamageTimer != null)
		{
			TimerSystem.Instance.Remove(this.EndSkinDamageTimer);
			this.EndSkinDamageTimer = null;
		}
	}

	// Token: 0x06019775 RID: 104309 RVA: 0x0075CE92 File Offset: 0x0075B092
	private void SetTimer()
	{
		this.EndSkinDamageTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.EndSkinDamageTimer = null;
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			int? num = (getCurrentEntity != null) ? new int?(getCurrentEntity.Id) : null;
			int id = base.Entity.Id;
			if (!(num.GetValueOrDefault() == id & num != null))
			{
				this.ApplySkinDamageByType(ESkinDamageType.Normal, false, "战损恢复（定时器）", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}, 20f, null, null, true, 1f);
	}

	// Token: 0x06019776 RID: 104310 RVA: 0x0075CEC0 File Offset: 0x0075B0C0
	[NullableContext(2)]
	private string GetSkinDamagePath(ESkinDamageType type)
	{
		RoleInfo? roleConfig = this.CreatureDataComp.GetRoleConfig();
		string text = (roleConfig != null) ? roleConfig.GetValueOrDefault().SkinDamage((int)type) : null;
		string text2 = null;
		if (!string.IsNullOrEmpty(text))
		{
			text2 = this.ActorComp.GetReplaceEffect(text);
		}
		if (string.IsNullOrEmpty(text2))
		{
			return text;
		}
		return text2;
	}

	// Token: 0x06019777 RID: 104311 RVA: 0x0075CF18 File Offset: 0x0075B118
	public void ApplySkinDamageByType(ESkinDamageType type, bool force, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		if (this.SkinDamageType == type && !force)
		{
			return;
		}
		if (!CharacterSkinDamageComponent.EnableSkinDamage && !force)
		{
			return;
		}
		this.SkinDamageType = type;
		if (!string.IsNullOrEmpty(this.CuePath) && !force)
		{
			return;
		}
		string skinDamagePath = this.GetSkinDamagePath(type);
		if (!string.IsNullOrEmpty(skinDamagePath))
		{
			this.ApplySkinDamage(skinDamagePath, force, message, pairs);
		}
	}

	// Token: 0x06019778 RID: 104312 RVA: 0x0075CF70 File Offset: 0x0075B170
	public void ApplySkinDamage(string damagePath, bool force, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		if (!CharacterSkinDamageComponent.EnableSkinDamage && !force)
		{
			return;
		}
		if (this.Path == damagePath)
		{
			return;
		}
		this.Path = damagePath;
		Singleton<ResourceSystem>.Instance.LoadAsync<UKuroChangeMaterialsTextures>(damagePath, delegate([Nullable(2)] UKuroChangeMaterialsTextures res, string path)
		{
			if (res == null)
			{
				return;
			}
			Entity entity = base.Entity;
			if (entity == null || !entity.Valid)
			{
				return;
			}
			TsBaseCharacter actor = this.ActorComp.Actor;
			if (actor == null || !actor.IsValid())
			{
				return;
			}
			if (path != this.Path)
			{
				return;
			}
			UKuroChangeSkeletalMaterialsComponent kuroChangeSkeletalMaterialsComponent = this.KuroChangeSkeletalMaterialsComponent;
			if (kuroChangeSkeletalMaterialsComponent == null || !kuroChangeSkeletalMaterialsComponent.IsValid())
			{
				this.TryAddKuroChangeSkeletalMaterialsComponent();
			}
			if (res.ParameterName == CharacterSkinDamageComponent.newDamageOnName)
			{
				CharRenderingComponent charRenderingComponent = this.ActorComp.Actor.CharRenderingComponent;
				if (charRenderingComponent == null)
				{
					return;
				}
				charRenderingComponent.SetMaterialPropertyFloatV2(CharacterSkinDamageComponent.newDamageIntensityName, 1f, EKuroCharBodySpecifiedType.Body, EKuroCharSlotSpecifiedType.Body, EKuroCharMeshPart.ECharacterMeshPart_Max);
				return;
			}
			else if (res.ParameterName == CharacterSkinDamageComponent.newDamageOffName)
			{
				CharRenderingComponent charRenderingComponent2 = this.ActorComp.Actor.CharRenderingComponent;
				if (charRenderingComponent2 == null)
				{
					return;
				}
				charRenderingComponent2.SetMaterialPropertyFloatV2(CharacterSkinDamageComponent.newDamageIntensityName, 0f, EKuroCharBodySpecifiedType.Body, EKuroCharSlotSpecifiedType.Body, EKuroCharMeshPart.ECharacterMeshPart_Max);
				return;
			}
			else
			{
				UKuroChangeSkeletalMaterialsComponent kuroChangeSkeletalMaterialsComponent2 = this.KuroChangeSkeletalMaterialsComponent;
				if (kuroChangeSkeletalMaterialsComponent2 == null)
				{
					return;
				}
				kuroChangeSkeletalMaterialsComponent2.ChangeMaterialsWithDataAsset(res);
				return;
			}
		}, 100, "js_undefined");
	}

	// Token: 0x06019779 RID: 104313 RVA: 0x0075CFC0 File Offset: 0x0075B1C0
	private void OnResetSkinDamageMode()
	{
		if (!string.IsNullOrEmpty(this.CuePath) && this.IsCueIgnoreEnableSetting)
		{
			this.ApplySkinDamage(this.CuePath, true, "战损开关改变, 存在无视开关的Cue战损", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!CharacterSkinDamageComponent.EnableSkinDamage)
		{
			this.ApplySkinDamageByType(ESkinDamageType.Normal, true, "战损开关设置为关闭", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!string.IsNullOrEmpty(this.CuePath))
		{
			this.ApplySkinDamage(this.CuePath, false, "战损开关设置为开启, Cue战损重新生效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.ApplyBeHitCount();
	}

	// Token: 0x0601977A RID: 104314 RVA: 0x0075D04C File Offset: 0x0075B24C
	public void ResetCueSkinDamage()
	{
		if (string.IsNullOrEmpty(this.CuePath))
		{
			return;
		}
		this.CuePath = string.Empty;
		bool isCueIgnoreEnableSetting = this.IsCueIgnoreEnableSetting;
		this.IsCueIgnoreEnableSetting = false;
		if (CharacterSkinDamageComponent.EnableSkinDamage)
		{
			this.ApplySkinDamageByType(this.SkinDamageType, isCueIgnoreEnableSetting, "GameplayCueSkinDamage销毁", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.ApplySkinDamageByType(ESkinDamageType.Normal, isCueIgnoreEnableSetting, "GameplayCueSkinDamage销毁", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x17002258 RID: 8792
	// (get) Token: 0x0601977B RID: 104315 RVA: 0x0075D0B9 File Offset: 0x0075B2B9
	// (set) Token: 0x0601977C RID: 104316 RVA: 0x0075D0C4 File Offset: 0x0075B2C4
	public ESkinDamageType SkinDamageType
	{
		get
		{
			return this.SkinDamageTypeInternal;
		}
		set
		{
			this.TagComp.RemoveTag(new int?(CharacterSkinDamageComponent.skinDamageTagMap[this.SkinDamageTypeInternal]));
			this.SkinDamageTypeInternal = value;
			this.TagComp.AddTag(new int?(CharacterSkinDamageComponent.skinDamageTagMap[this.SkinDamageTypeInternal]));
		}
	}

	// Token: 0x0601977D RID: 104317 RVA: 0x0075D119 File Offset: 0x0075B319
	public static void CreateStaticDefaultValue()
	{
		CharacterSkinDamageComponent.EnableSkinDamage = true;
	}

	// Token: 0x0601977E RID: 104318 RVA: 0x0075D121 File Offset: 0x0075B321
	public static void ResetStaticDefaultValue()
	{
		CharacterSkinDamageComponent.EnableSkinDamage = true;
	}

	// Token: 0x0601977F RID: 104319 RVA: 0x0075D12C File Offset: 0x0075B32C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterSkinDamageComponent characterSkinDamageComponent = (CharacterSkinDamageComponent)componentTemplate;
		if (base.CanResetComponentProperty("CreatureDataComp"))
		{
			if (characterSkinDamageComponent.CreatureDataComp == null)
			{
				this.CreatureDataComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterSkinDamageComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterSkinDamageComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("KuroChangeSkeletalMaterialsComponent"))
		{
			if (characterSkinDamageComponent.KuroChangeSkeletalMaterialsComponent == null)
			{
				this.KuroChangeSkeletalMaterialsComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroChangeSkeletalMaterialsComponent>(this.KuroChangeSkeletalMaterialsComponent), "KuroChangeSkeletalMaterialsComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkinDamageTypeInternal"))
		{
			this.SkinDamageTypeInternal = characterSkinDamageComponent.SkinDamageTypeInternal;
		}
		if (base.CanResetComponentProperty("BattleStartTime"))
		{
			this.BattleStartTime = characterSkinDamageComponent.BattleStartTime;
		}
		if (base.CanResetComponentProperty("BattleEndTime"))
		{
			this.BattleEndTime = characterSkinDamageComponent.BattleEndTime;
		}
		if (base.CanResetComponentProperty("BeHitCount"))
		{
			this.BeHitCount = characterSkinDamageComponent.BeHitCount;
		}
		if (base.CanResetComponentProperty("Path"))
		{
			this.Path = characterSkinDamageComponent.Path;
		}
		if (base.CanResetComponentProperty("EndSkinDamageTimer"))
		{
			if (characterSkinDamageComponent.EndSkinDamageTimer == null)
			{
				this.EndSkinDamageTimer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.EndSkinDamageTimer), "EndSkinDamageTimer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CuePath"))
		{
			this.CuePath = characterSkinDamageComponent.CuePath;
		}
		if (base.CanResetComponentProperty("IsCueIgnoreEnableSetting"))
		{
			this.IsCueIgnoreEnableSetting = characterSkinDamageComponent.IsCueIgnoreEnableSetting;
		}
		return true;
	}

	// Token: 0x0400C9C8 RID: 51656
	private const int SKIN_DAMAGE_TIME = 20;

	// Token: 0x0400C9C9 RID: 51657
	private const int SKIN_DAMAGE_LEVEL1_COUNT = 7;

	// Token: 0x0400C9CA RID: 51658
	private const int SKIN_DAMAGE_LEVEL2_COUNT = 14;

	// Token: 0x0400C9CB RID: 51659
	[StaticVariableRuleIgnore]
	private static readonly FName newDamageIntensityName = new FName("DamageIntensity");

	// Token: 0x0400C9CC RID: 51660
	[StaticVariableRuleIgnore]
	private static readonly FName newDamageOnName = new FName("NewDamageOn");

	// Token: 0x0400C9CD RID: 51661
	[StaticVariableRuleIgnore]
	private static readonly FName newDamageOffName = new FName("NewDamageOff");

	// Token: 0x0400C9CE RID: 51662
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<ESkinDamageType, int> skinDamageTagMap = new Dictionary<ESkinDamageType, int>
	{
		{
			ESkinDamageType.Normal,
			GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.无战损"]
		},
		{
			ESkinDamageType.Damage1,
			GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.战损.一级战损"]
		},
		{
			ESkinDamageType.Damage2,
			GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.战损.二级战损"]
		}
	};

	// Token: 0x0400C9CF RID: 51663
	[Nullable(2)]
	private CreatureDataComponent CreatureDataComp;

	// Token: 0x0400C9D0 RID: 51664
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400C9D1 RID: 51665
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400C9D2 RID: 51666
	[Nullable(2)]
	private UKuroChangeSkeletalMaterialsComponent KuroChangeSkeletalMaterialsComponent;

	// Token: 0x0400C9D3 RID: 51667
	private ESkinDamageType SkinDamageTypeInternal;

	// Token: 0x0400C9D4 RID: 51668
	private double BattleStartTime;

	// Token: 0x0400C9D5 RID: 51669
	private double BattleEndTime;

	// Token: 0x0400C9D6 RID: 51670
	private int BeHitCount;

	// Token: 0x0400C9D7 RID: 51671
	private string Path = "";

	// Token: 0x0400C9D8 RID: 51672
	[Nullable(2)]
	private TimerHandle EndSkinDamageTimer;

	// Token: 0x0400C9D9 RID: 51673
	public string CuePath = "";

	// Token: 0x0400C9DA RID: 51674
	public bool IsCueIgnoreEnableSetting;

	// Token: 0x0400C9DB RID: 51675
	public static bool EnableSkinDamage;
}
