using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.SpecialRoleData;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F85 RID: 24453
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleUiRoleData
	{
		// Token: 0x0603D65D RID: 251485 RVA: 0x00F9E5EC File Offset: 0x00F9C7EC
		[NullableContext(1)]
		public void Init(EntityHandle handle, bool isCurEntity)
		{
			this.EntityHandle = handle;
			this.IsCurEntity = isCurEntity;
			this.AttributeComponent = handle.Entity.GetComponent<BaseAttributeComponent>();
			this.GameplayTagComponent = handle.Entity.GetComponent<BaseTagComponent>();
			this.RoleElementComponent = handle.Entity.GetComponent<RoleElementComponent>();
			this.BuffComponent = handle.Entity.GetComponent<CharacterBuffComponent>();
			this.ShieldComponent = handle.Entity.GetComponent<CharacterShieldComponent>();
			this.RoleQteComponent = handle.Entity.GetComponent<RoleQteComponent>();
			this.CreatureDataComponent = handle.Entity.GetComponent<CreatureDataComponent>();
			this.BaseDeathComponent = handle.Entity.GetComponent<BaseDeathComponent>();
			this.ActorComp = handle.Entity.GetComponent<CharacterActorComponent>();
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			float? num = (attributeComponent != null) ? new float?(attributeComponent.GetCurrentValue(EAttributeType.ElementPropertyType)) : null;
			this.ElementType = new EElementType?(((num != null) ? new EElementType?((EElementType)num.GetValueOrDefault()) : null).GetValueOrDefault());
			this.ElementConfig = ConfigBase<ElementInfoConfig>.Instance.GetElementInfo((int)this.ElementType.Value);
			this.ElementColor = new FColor?(FColor.FromHex(this.ElementConfig.Value.ElementColor));
			FColor value = this.ElementColor.Value;
			this.ElementLinearColor = new FLinearColor?(new FLinearColor(ref value));
			this.UltimateSkillColor = new FColor?(FColor.FromHex(this.ElementConfig.Value.UltimateSkillColor));
			CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
			this.CreatureRoleId = ((creatureDataComponent != null) ? creatureDataComponent.GetRoleId() : 0);
			CreatureDataComponent creatureDataComponent2 = this.CreatureDataComponent;
			this.CreatureDataId = ((creatureDataComponent2 != null) ? creatureDataComponent2.GetCreatureDataId() : 0L);
			CreatureDataComponent creatureDataComponent3 = this.CreatureDataComponent;
			this.CreatureSkinId = ((creatureDataComponent3 != null) ? new int?(creatureDataComponent3.GetSkinId()) : null);
			CreatureDataComponent creatureDataComponent4 = this.CreatureDataComponent;
			this.RoleConfig = ((creatureDataComponent4 != null) ? creatureDataComponent4.GetRoleConfig() : null);
			if (this.RoleConfig != null)
			{
				if (this.RoleConfig.Value.RoleType == 2)
				{
					this.RoleBattleViewInfo = ConfigRoleBattleViewInfoById.GetConfig(this.RoleConfig.Value.Id, true);
				}
				this.HeadIconEnergyBarConfig = ModelBase<BattleUiModel>.Instance.GetHeadIconEnergyBarConfig(this.RoleConfig.Value.Id);
				Func<BattleUiSpecialRoleDataBase> func;
				if (BattleUiRoleData.SpecialRoleDataClassMap.TryGetValue(this.RoleConfig.Value.Id, out func))
				{
					this.SpecialData = func();
					this.SpecialData.Init(this);
				}
			}
			this.AddEntityEvents();
		}

		// Token: 0x0603D65E RID: 251486 RVA: 0x00F9E89A File Offset: 0x00F9CA9A
		public void OnChangeRole(bool isCurEntity)
		{
			this.IsCurEntity = isCurEntity;
			BattleUiSpecialRoleDataBase specialData = this.SpecialData;
			if (specialData == null)
			{
				return;
			}
			specialData.OnChangeRole(isCurEntity);
		}

		// Token: 0x0603D65F RID: 251487 RVA: 0x00F9E8B4 File Offset: 0x00F9CAB4
		public void Clear()
		{
			this.RemoveEntityEvents();
			if (this.SpecialData != null)
			{
				this.SpecialData.Clear();
				this.SpecialData = null;
			}
			if (this.IsCurEntity)
			{
				this.SpecialStateMap.Clear();
				ModelBase<BattleUiModel>.Instance.RefreshAllRoleSpecialState();
			}
			this.AttributeComponent = null;
			this.GameplayTagComponent = null;
			this.RoleElementComponent = null;
			this.BuffComponent = null;
			this.ShieldComponent = null;
			this.RoleQteComponent = null;
			this.CreatureDataComponent = null;
			this.BaseDeathComponent = null;
			this.ActorComp = null;
			this.ElementType = null;
			this.ElementConfig = null;
			this.ElementColor = null;
			this.ElementLinearColor = null;
			this.UltimateSkillColor = null;
			this.CreatureDataId = 0L;
			this.CreatureRoleId = 0;
			this.RoleConfig = null;
			this.RoleBattleViewInfo = null;
			this.HeadIconEnergyBarConfig = null;
			this.QteCdTagId = 0;
			this.CheckEnergyTag = false;
			this.HasEnergyTag = false;
		}

		// Token: 0x0603D660 RID: 251488 RVA: 0x00F9E9C4 File Offset: 0x00F9CBC4
		private void AddEntityEvents()
		{
			foreach (int tagId in BattleUiRoleData.HideElementTagList)
			{
				this.ListenForTagSignificantChanged(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnElementHideTagChanged), false);
			}
			this.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"], new BaseTagComponent.TTagSwitchedCallback(this.OnDeadTagChanged), false);
			this.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE"], new BaseTagComponent.TTagSwitchedCallback(this.OnQteEnableTagChanged), false);
			this.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.QTE"], new BaseTagComponent.TTagSwitchedCallback(this.OnUseQteTagChanged), false);
			this.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.协奏充能完成"], new BaseTagComponent.TTagSwitchedCallback(this.OnConcertoEnableTagChanged), false);
			this.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["关卡.滑水.专用UI"], new BaseTagComponent.TTagSwitchedCallback(this.OnMigrationTagChanged), true);
			this.ListenForTagSignificantChanged(GameplayTagDefine.EGameplayTagId["关卡.圣火追逐.专用ui"], new BaseTagComponent.TTagSwitchedCallback(this.OnFlyRaceTagChanged), true);
			foreach (int tagId2 in BattleUiRoleData.SpecialStateTagMap.Keys)
			{
				this.ListenForTagSignificantChanged(tagId2, new BaseTagComponent.TTagSwitchedCallback(this.OnRoleSpecialStateTagChanged), true);
			}
			Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(this.CharOnDirectionStateChanged));
			Singleton<EventSystem>.Instance.AddWithTarget<float>(this.EntityHandle.Entity, EEventName.CharShieldChange, new Action<float>(this.OnShieldChanged));
			this.UpdateQteCdTagListen();
			Singleton<EventSystem>.Instance.AddWithTarget(this.EntityHandle.Entity, EEventName.CharQteTagRowNameChanged, new Action(this.OnQteTagRowNameChanged));
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent != null)
			{
				attributeComponent.AddListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHealthChanged), null);
				attributeComponent.AddListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHealthChanged), null);
				attributeComponent.AddListener(EAttributeType.Lv, new Action<EAttributeType, float, float>(this.OnLevelChanged), null);
				attributeComponent.AddListener(EAttributeType.ElementEnergy, new Action<EAttributeType, float, float>(this.OnElementEnergyChanged), null);
				attributeComponent.AddListener(EAttributeType.ElementEnergyMax, new Action<EAttributeType, float, float>(this.OnElementEnergyChanged), null);
				attributeComponent.AddListener(EAttributeType.Energy, new Action<EAttributeType, float, float>(this.OnEnergyChanged), null);
				attributeComponent.AddListener(EAttributeType.EnergyMax, new Action<EAttributeType, float, float>(this.OnEnergyChanged), null);
			}
		}

		// Token: 0x0603D661 RID: 251489 RVA: 0x00F9EC38 File Offset: 0x00F9CE38
		private void RemoveEntityEvents()
		{
			foreach (ITagTask tagTask in this.TagSignificantChangedTaskList)
			{
				tagTask.EndTask();
			}
			this.TagSignificantChangedTaskList.Clear();
			if (this.QteCdTagTask != null)
			{
				this.QteCdTagTask.EndTask();
				this.QteCdTagTask = null;
			}
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle != null && entityHandle.Valid)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(this.CharOnDirectionStateChanged));
				Singleton<EventSystem>.Instance.RemoveWithTarget<float>(this.EntityHandle.Entity, EEventName.CharShieldChange, new Action<float>(this.OnShieldChanged));
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle.Entity, EEventName.CharQteTagRowNameChanged, new Action(this.OnQteTagRowNameChanged));
				BaseAttributeComponent attributeComponent = this.AttributeComponent;
				if (attributeComponent != null)
				{
					attributeComponent.RemoveListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHealthChanged));
					attributeComponent.RemoveListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHealthChanged));
					attributeComponent.RemoveListener(EAttributeType.Lv, new Action<EAttributeType, float, float>(this.OnLevelChanged));
					attributeComponent.RemoveListener(EAttributeType.ElementEnergy, new Action<EAttributeType, float, float>(this.OnElementEnergyChanged));
					attributeComponent.RemoveListener(EAttributeType.ElementEnergyMax, new Action<EAttributeType, float, float>(this.OnElementEnergyChanged));
					return;
				}
			}
			else
			{
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.CFT, "BattelUi清理RoleData时，Entity不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0603D662 RID: 251490 RVA: 0x00F9EDC4 File Offset: 0x00F9CFC4
		[NullableContext(1)]
		public void ListenForTagSignificantChanged(int tagId, BaseTagComponent.TTagSwitchedCallback callback, bool checkExistImmediately = false)
		{
			if (checkExistImmediately)
			{
				BaseTagComponent gameplayTagComponent = this.GameplayTagComponent;
				if (gameplayTagComponent != null && gameplayTagComponent.HasTag(tagId))
				{
					callback(tagId, true);
				}
			}
			ITagTask tagTask = this.GameplayTagComponent.ListenForTagAddOrRemove(new int?(tagId), callback, null);
			if (tagTask == null)
			{
				return;
			}
			this.TagSignificantChangedTaskList.Add(tagTask);
		}

		// Token: 0x0603D663 RID: 251491 RVA: 0x00F9EE15 File Offset: 0x00F9D015
		private void OnElementEnergyChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BattleUiElementEnergyChanged, this.EntityHandle.Id);
		}

		// Token: 0x0603D664 RID: 251492 RVA: 0x00F9EE32 File Offset: 0x00F9D032
		private void OnEnergyChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BattleUiEnergyChanged, this.EntityHandle.Id);
		}

		// Token: 0x0603D665 RID: 251493 RVA: 0x00F9EE4F File Offset: 0x00F9D04F
		private void OnElementHideTagChanged(int tagId, bool tagExist)
		{
			Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.BattleUiElementHideTagChanged, this.EntityHandle.Id, tagId, tagExist);
		}

		// Token: 0x0603D666 RID: 251494 RVA: 0x00F9EE6E File Offset: 0x00F9D06E
		private void OnDeadTagChanged(int tagId, bool tagExist)
		{
			Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.BattleUiDeadTagChanged, this.EntityHandle.Id, tagId, tagExist);
		}

		// Token: 0x0603D667 RID: 251495 RVA: 0x00F9EE8D File Offset: 0x00F9D08D
		private void OnQteEnableTagChanged(int tagId, bool tagExist)
		{
			Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.BattleUiQteEnableTagChanged, this.EntityHandle.Id, tagId, tagExist);
		}

		// Token: 0x0603D668 RID: 251496 RVA: 0x00F9EEAC File Offset: 0x00F9D0AC
		private void OnQteCdTagChanged(int tagId, bool tagExist)
		{
			Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.BattleUiQteCdTagChanged, this.EntityHandle.Id, tagId, tagExist);
		}

		// Token: 0x0603D669 RID: 251497 RVA: 0x00F9EECB File Offset: 0x00F9D0CB
		private void OnUseQteTagChanged(int tagId, bool tagExist)
		{
			Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.BattleUiUseQteTagChanged, this.EntityHandle.Id, tagId, tagExist);
		}

		// Token: 0x0603D66A RID: 251498 RVA: 0x00F9EEEA File Offset: 0x00F9D0EA
		private void OnConcertoEnableTagChanged(int tagId, bool tagExist)
		{
			Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.BattleUiConcertoEnableTagChanged, this.EntityHandle.Id, tagId, tagExist);
		}

		// Token: 0x0603D66B RID: 251499 RVA: 0x00F9EF09 File Offset: 0x00F9D109
		private void OnMigrationTagChanged(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				ControllerBase<HudUnitController>.Instance.TryCreateHud(EHudUnitType.MigrationStrength);
			}
		}

		// Token: 0x0603D66C RID: 251500 RVA: 0x00F9EF19 File Offset: 0x00F9D119
		private void OnFlyRaceTagChanged(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				ControllerBase<HudUnitController>.Instance.TryCreateHud(EHudUnitType.FlyRaceStrength);
			}
		}

		// Token: 0x0603D66D RID: 251501 RVA: 0x00F9EF2C File Offset: 0x00F9D12C
		private void OnRoleSpecialStateTagChanged(int tagId, bool tagExist)
		{
			ERoleSpecialState eroleSpecialState;
			if (BattleUiRoleData.SpecialStateTagMap.TryGetValue(tagId, out eroleSpecialState))
			{
				this.SpecialStateMap[eroleSpecialState] = tagExist;
				if (this.IsCurEntity)
				{
					ModelBase<BattleUiModel>.Instance.RefreshRoleSpecialState(eroleSpecialState);
				}
			}
		}

		// Token: 0x0603D66E RID: 251502 RVA: 0x00F9EF68 File Offset: 0x00F9D168
		private void CharOnDirectionStateChanged(ECharDirectionState oldDirectionState, ECharDirectionState newDirectionState)
		{
			if (!this.IsCurEntity)
			{
				return;
			}
			if (oldDirectionState == newDirectionState)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAimStateChanged);
		}

		// Token: 0x0603D66F RID: 251503 RVA: 0x00F9EF88 File Offset: 0x00F9D188
		private void OnShieldChanged(float shield)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BattleUiShieldChanged, this.EntityHandle.Id);
		}

		// Token: 0x0603D670 RID: 251504 RVA: 0x00F9EFA5 File Offset: 0x00F9D1A5
		private void OnQteTagRowNameChanged()
		{
			this.UpdateQteCdTagListen();
		}

		// Token: 0x0603D671 RID: 251505 RVA: 0x00F9EFB0 File Offset: 0x00F9D1B0
		private void UpdateQteCdTagListen()
		{
			RoleQteComponent roleQteComponent = this.RoleQteComponent;
			int? num;
			if (roleQteComponent == null)
			{
				num = null;
			}
			else
			{
				SQteTag qteTagData = roleQteComponent.GetQteTagData();
				num = ((qteTagData != null) ? new int?(qteTagData.NoTag.TagId()) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			if (valueOrDefault != this.QteCdTagId)
			{
				if (this.QteCdTagTask != null)
				{
					this.QteCdTagTask.EndTask();
					this.QteCdTagTask = null;
				}
				this.QteCdTagId = valueOrDefault;
				if (this.QteCdTagId != 0)
				{
					this.QteCdTagTask = this.GameplayTagComponent.ListenForTagAddOrRemove(new int?(valueOrDefault), new BaseTagComponent.TTagSwitchedCallback(this.OnQteCdTagChanged), null);
				}
			}
		}

		// Token: 0x0603D672 RID: 251506 RVA: 0x00F9F054 File Offset: 0x00F9D254
		private void OnHealthChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BattleUiHealthChanged, this.EntityHandle.Id);
		}

		// Token: 0x0603D673 RID: 251507 RVA: 0x00F9F071 File Offset: 0x00F9D271
		private void OnLevelChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BattleUiLevelChanged, this.EntityHandle.Id);
		}

		// Token: 0x0603D674 RID: 251508 RVA: 0x00F9F090 File Offset: 0x00F9D290
		public bool GetTopButtonVisible()
		{
			return this.RoleBattleViewInfo == null || this.RoleBattleViewInfo.Value.TopButtonVisible;
		}

		// Token: 0x0603D675 RID: 251509 RVA: 0x00F9F0C0 File Offset: 0x00F9D2C0
		public float GetElementAttributePercent()
		{
			if (this.RoleElementComponent == null)
			{
				return 0f;
			}
			float roleElementEnergy = this.RoleElementComponent.RoleElementEnergy;
			float roleElementEnergyMax = this.RoleElementComponent.RoleElementEnergyMax;
			if (roleElementEnergyMax <= 0f)
			{
				return 0f;
			}
			return roleElementEnergy / roleElementEnergyMax;
		}

		// Token: 0x0603D676 RID: 251510 RVA: 0x00F9F104 File Offset: 0x00F9D304
		public bool IsPhantom()
		{
			return this.RoleConfig != null && this.RoleConfig.GetValueOrDefault().RoleType == 2;
		}

		// Token: 0x0603D677 RID: 251511 RVA: 0x00F9F134 File Offset: 0x00F9D334
		public bool CanUseUltraSkill()
		{
			if (this.CheckEnergyTag)
			{
				return this.HasEnergyTag;
			}
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return false;
			}
			float currentValue = attributeComponent.GetCurrentValue(EAttributeType.Energy);
			float currentValue2 = attributeComponent.GetCurrentValue(EAttributeType.EnergyMax);
			return currentValue >= currentValue2;
		}

		// Token: 0x0603D678 RID: 251512 RVA: 0x00F9F175 File Offset: 0x00F9D375
		public void SetHasEnergyTag(bool tagExist)
		{
			if (this.HasEnergyTag == tagExist)
			{
				return;
			}
			this.HasEnergyTag = tagExist;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BattleUiEnergyChanged, this.EntityHandle.Id);
		}

		// Token: 0x0603D67A RID: 251514 RVA: 0x00F9F1C8 File Offset: 0x00F9D3C8
		// Note: this type is marked as 'beforefieldinit'.
		static BattleUiRoleData()
		{
			Dictionary<int, ERoleSpecialState> dictionary = new Dictionary<int, ERoleSpecialState>();
			int key = GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑轨"];
			dictionary[key] = ERoleSpecialState.RailSlide;
			int key2 = GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.滑轨.滑轨移动中"];
			dictionary[key2] = ERoleSpecialState.MotorcycleRailMove;
			int key3 = GameplayTagDefine.EGameplayTagId["关卡.海底试验场.UI显示标识"];
			dictionary[key3] = ERoleSpecialState.SlowTimeWorld;
			int key4 = GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.移动端浮游炮攻击按钮"];
			dictionary[key4] = ERoleSpecialState.MotorcycleCannon;
			int key5 = GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.弱点机制.新手教程.屏蔽弱点"];
			dictionary[key5] = ERoleSpecialState.ForbidWeakness;
			int key6 = GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.功能开关.禁用第一人称"];
			dictionary[key6] = ERoleSpecialState.MotorcycleFirstPersonDisabled;
			int key7 = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏状态功能.隐藏战斗UI仅允许战斗输入"];
			dictionary[key7] = ERoleSpecialState.OnlyAllowFightInput;
			BattleUiRoleData.SpecialStateTagMap = dictionary;
			BattleUiRoleData.SpecialRoleDataClassMap = new Dictionary<int, Func<BattleUiSpecialRoleDataBase>>
			{
				{
					1207,
					() => new BattleUiSpecialRoleDataLuPa()
				},
				{
					1608,
					() => new BattleUiSpecialRoleDataFuLuoLuo()
				},
				{
					1210,
					() => new BattleUiSpecialRoleDataAiMiSi()
				},
				{
					1109,
					() => new BattleUiSpecialRoleDataLuoSeLa()
				},
				{
					1413,
					() => new BattleUiSpecialRoleDataQingXiao()
				}
			};
		}

		// Token: 0x040227D8 RID: 141272
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly int[] HideElementTagList = new int[]
		{
			GameplayTagDefine.EGameplayTagId["功能.人物属性.锁定冷凝能量"],
			GameplayTagDefine.EGameplayTagId["功能.人物属性.锁定导电能量"],
			GameplayTagDefine.EGameplayTagId["功能.人物属性.锁定气动能量"],
			GameplayTagDefine.EGameplayTagId["功能.人物属性.锁定衍射能量"],
			GameplayTagDefine.EGameplayTagId["功能.人物属性.锁定解离能量"],
			GameplayTagDefine.EGameplayTagId["功能.人物属性.锁定高温能量"]
		};

		// Token: 0x040227D9 RID: 141273
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<int, ERoleSpecialState> SpecialStateTagMap;

		// Token: 0x040227DA RID: 141274
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, Func<BattleUiSpecialRoleDataBase>> SpecialRoleDataClassMap;

		// Token: 0x040227DB RID: 141275
		public bool IsCurEntity;

		// Token: 0x040227DC RID: 141276
		public EntityHandle EntityHandle;

		// Token: 0x040227DD RID: 141277
		public BaseAttributeComponent AttributeComponent;

		// Token: 0x040227DE RID: 141278
		public BaseTagComponent GameplayTagComponent;

		// Token: 0x040227DF RID: 141279
		public RoleElementComponent RoleElementComponent;

		// Token: 0x040227E0 RID: 141280
		public CharacterBuffComponent BuffComponent;

		// Token: 0x040227E1 RID: 141281
		public CharacterShieldComponent ShieldComponent;

		// Token: 0x040227E2 RID: 141282
		public RoleQteComponent RoleQteComponent;

		// Token: 0x040227E3 RID: 141283
		public CreatureDataComponent CreatureDataComponent;

		// Token: 0x040227E4 RID: 141284
		public BaseDeathComponent BaseDeathComponent;

		// Token: 0x040227E5 RID: 141285
		public CharacterActorComponent ActorComp;

		// Token: 0x040227E6 RID: 141286
		public EElementType? ElementType;

		// Token: 0x040227E7 RID: 141287
		public ElementInfo? ElementConfig;

		// Token: 0x040227E8 RID: 141288
		public FColor? ElementColor;

		// Token: 0x040227E9 RID: 141289
		public FLinearColor? ElementLinearColor;

		// Token: 0x040227EA RID: 141290
		public FColor? UltimateSkillColor;

		// Token: 0x040227EB RID: 141291
		public long CreatureDataId;

		// Token: 0x040227EC RID: 141292
		public int CreatureRoleId;

		// Token: 0x040227ED RID: 141293
		public int? CreatureSkinId;

		// Token: 0x040227EE RID: 141294
		public RoleInfo? RoleConfig;

		// Token: 0x040227EF RID: 141295
		public RoleBattleViewInfo? RoleBattleViewInfo;

		// Token: 0x040227F0 RID: 141296
		public HeadIconEnergyBar? HeadIconEnergyBarConfig;

		// Token: 0x040227F1 RID: 141297
		public int QteCdTagId;

		// Token: 0x040227F2 RID: 141298
		private ITagTask QteCdTagTask;

		// Token: 0x040227F3 RID: 141299
		[Nullable(1)]
		public Dictionary<ERoleSpecialState, bool> SpecialStateMap = new Dictionary<ERoleSpecialState, bool>();

		// Token: 0x040227F4 RID: 141300
		public bool MorphShowSpecialEnergyBar = true;

		// Token: 0x040227F5 RID: 141301
		public bool OnlyBattleInput;

		// Token: 0x040227F6 RID: 141302
		public bool HasEnergyTag;

		// Token: 0x040227F7 RID: 141303
		public bool CheckEnergyTag;

		// Token: 0x040227F8 RID: 141304
		[Nullable(1)]
		private readonly List<ITagTask> TagSignificantChangedTaskList = new List<ITagTask>();

		// Token: 0x040227F9 RID: 141305
		private BattleUiSpecialRoleDataBase SpecialData;
	}
}
