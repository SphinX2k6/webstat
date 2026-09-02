using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001F9C RID: 8092
[NullableContext(1)]
[Nullable(0)]
public class RoleSideEnergyHandle : HudUnitHandleBase
{
	// Token: 0x0600F316 RID: 62230 RVA: 0x00427250 File Offset: 0x00425450
	protected override void OnInitialize()
	{
		base.OnInitialize();
		this.Refresh();
	}

	// Token: 0x0600F317 RID: 62231 RVA: 0x00427260 File Offset: 0x00425460
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, GameplayCue, bool, int>(EEventName.CharOnBuffAddRoleSideEnergyBar, new Action<int, GameplayCue, bool, int>(this.OnAddRoleSideEnergy));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.SeamlessTravelUIRefresh, new Action(this.RefreshShow));
		Singleton<EventSystem>.Instance.Add<Entity>(EEventName.BattleUiRemoveRoleData, new Action<Entity>(this.OnRemoveEntity));
	}

	// Token: 0x0600F318 RID: 62232 RVA: 0x004272E0 File Offset: 0x004254E0
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, GameplayCue, bool, int>(EEventName.CharOnBuffAddRoleSideEnergyBar, new Action<int, GameplayCue, bool, int>(this.OnAddRoleSideEnergy));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.BattleUiCurRoleDataChangedNextTick, new Action<int, int>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.SeamlessTravelUIRefresh, new Action(this.RefreshShow));
		Singleton<EventSystem>.Instance.Remove<Entity>(EEventName.BattleUiRemoveRoleData, new Action<Entity>(this.OnRemoveEntity));
	}

	// Token: 0x0600F319 RID: 62233 RVA: 0x0042735D File Offset: 0x0042555D
	private void OnAddRoleSideEnergy(int entityId, GameplayCue cue, bool isAdd, int handleId)
	{
		if (this.EntityId != entityId)
		{
			return;
		}
		if (isAdd)
		{
			this.AddEnergyBar(cue, handleId);
			return;
		}
		this.RemoveEnergyBar(handleId);
	}

	// Token: 0x0600F31A RID: 62234 RVA: 0x0042737E File Offset: 0x0042557E
	private void OnChangeRole(int newEntityId, int oldEntityId)
	{
		this.Refresh();
		this.RefreshAllUnitVisible();
	}

	// Token: 0x0600F31B RID: 62235 RVA: 0x0042738C File Offset: 0x0042558C
	private void RefreshShow()
	{
		this.Refresh();
		this.RefreshAllUnitVisible();
	}

	// Token: 0x0600F31C RID: 62236 RVA: 0x0042739C File Offset: 0x0042559C
	private void OnRemoveEntity(Entity entity)
	{
		foreach (KeyValuePair<int, RoleSideEnergyBarInfo> keyValuePair in this.BarInfoMap)
		{
			int num;
			RoleSideEnergyBarInfo roleSideEnergyBarInfo;
			keyValuePair.Deconstruct(out num, out roleSideEnergyBarInfo);
			int handleId = num;
			if (roleSideEnergyBarInfo.RoleSideEnergyUnit != null)
			{
				this.RemoveEnergyBar(handleId);
			}
		}
	}

	// Token: 0x0600F31D RID: 62237 RVA: 0x00427408 File Offset: 0x00425608
	private void RefreshAllUnitVisible()
	{
		foreach (RoleSideEnergyBarInfo roleSideEnergyBarInfo in this.BarInfoMap.Values)
		{
			if (roleSideEnergyBarInfo.RoleSideEnergyUnit != null)
			{
				roleSideEnergyBarInfo.RoleSideEnergyUnit.SetVisible(roleSideEnergyBarInfo.EntityId == this.EntityId, 0);
			}
		}
	}

	// Token: 0x0600F31E RID: 62238 RVA: 0x0042747C File Offset: 0x0042567C
	private void Refresh()
	{
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData == this.RoleData)
		{
			return;
		}
		if (curRoleData != null)
		{
			EntityHandle entityHandle = curRoleData.EntityHandle;
			if (((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault())
			{
				this.RoleData = curRoleData;
				WorldEntity entity = curRoleData.EntityHandle.Entity;
				this.EntityId = ((entity != null) ? entity.Id : 0);
				goto IL_75;
			}
		}
		this.RoleData = null;
		this.EntityId = 0;
		IL_75:
		this.RefreshEnergyBar();
	}

	// Token: 0x0600F31F RID: 62239 RVA: 0x00427504 File Offset: 0x00425704
	private void RefreshEnergyBar()
	{
		if (this.RoleData == null)
		{
			return;
		}
		foreach (GameplayCueBase gameplayCueBase in this.RoleData.EntityHandle.Entity.GetComponent<CharacterGameplayCueComponent>().GetAllCurrentCueRef())
		{
			GameplayCue cueConfig = gameplayCueBase.CueConfig;
			if (cueConfig.CueType == 20)
			{
				this.AddEnergyBar(cueConfig, gameplayCueBase.BuffHandleId);
			}
		}
	}

	// Token: 0x0600F320 RID: 62240 RVA: 0x00427588 File Offset: 0x00425788
	private void AddEnergyBar(GameplayCue cueConfig, int handleId)
	{
		if (this.BarInfoMap.ContainsKey(handleId))
		{
			return;
		}
		RoleSideEnergyBarInfo barInfo = new RoleSideEnergyBarInfo();
		barInfo.EntityId = this.EntityId;
		barInfo.BuffCueConfig = new GameplayCue?(cueConfig);
		this.BarInfoMap[handleId] = barInfo;
		Type type2;
		Type type = RoleSideEnergyHandle._roleSideEnergyUnitClassMap.TryGetValue(cueConfig.Path, out type2) ? type2 : null;
		if (type == null)
		{
			type = typeof(RoleSideEnergyUnit);
		}
		base.NewHudUnit<RoleSideEnergyUnit>(type, cueConfig.Path, true, false).ContinueWith(delegate(RoleSideEnergyUnit unit)
		{
			if (unit == null)
			{
				return;
			}
			if (barInfo.BuffCueConfig == null)
			{
				this.DestroyHudUnit(unit);
				return;
			}
			BattleUiRoleData roleData = ModelBase<BattleUiModel>.Instance.GetRoleData(barInfo.EntityId);
			if (roleData == null)
			{
				this.DestroyHudUnit(unit);
				return;
			}
			barInfo.RoleSideEnergyUnit = unit;
			unit.InitInfo(barInfo.BuffCueConfig.Value, roleData);
			unit.SetVisible(barInfo.EntityId == this.EntityId, 0);
		});
	}

	// Token: 0x0600F321 RID: 62241 RVA: 0x00427640 File Offset: 0x00425840
	private void RemoveEnergyBar(int handleId)
	{
		RoleSideEnergyBarInfo roleSideEnergyBarInfo;
		if (!this.BarInfoMap.TryGetValue(handleId, out roleSideEnergyBarInfo))
		{
			return;
		}
		this.BarInfoMap.Remove(handleId);
		roleSideEnergyBarInfo.BuffCueConfig = null;
		if (roleSideEnergyBarInfo.RoleSideEnergyUnit != null)
		{
			base.DestroyHudUnit(roleSideEnergyBarInfo.RoleSideEnergyUnit);
			roleSideEnergyBarInfo.RoleSideEnergyUnit = null;
		}
	}

	// Token: 0x0600F322 RID: 62242 RVA: 0x00427694 File Offset: 0x00425894
	protected override void OnTick(float delta)
	{
		this.IsCalcScreenPos = false;
		foreach (RoleSideEnergyBarInfo roleSideEnergyBarInfo in this.BarInfoMap.Values)
		{
			if (roleSideEnergyBarInfo.RoleSideEnergyUnit != null && roleSideEnergyBarInfo.EntityId == this.EntityId)
			{
				if (!this.IsCalcScreenPos)
				{
					this.CalcScreenPos();
					this.IsCalcScreenPos = true;
				}
				if (this.InScreen)
				{
					roleSideEnergyBarInfo.RoleSideEnergyUnit.RefreshTargetPosition(delta, this.ScreenPos);
				}
			}
		}
	}

	// Token: 0x0600F323 RID: 62243 RVA: 0x00427734 File Offset: 0x00425934
	private void CalcScreenPos()
	{
		this.InScreen = false;
		BattleUiRoleData roleData = this.RoleData;
		CharacterActorComponent characterActorComponent;
		if (roleData == null)
		{
			characterActorComponent = null;
		}
		else
		{
			EntityHandle entityHandle = roleData.EntityHandle;
			if (entityHandle == null)
			{
				characterActorComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
			}
		}
		CharacterActorComponent characterActorComponent2 = characterActorComponent;
		if (characterActorComponent2 == null)
		{
			return;
		}
		TsBaseCharacter actor = characterActorComponent2.Actor;
		if (actor == null || !actor.IsValid())
		{
			return;
		}
		FVectorDouble actorLocation = characterActorComponent2.ActorLocation;
		this.InScreen = HudUnitUtils.PositionUtil.ProjectWorldToScreen(actorLocation, this.ScreenPos);
	}

	// Token: 0x040074CA RID: 29898
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<string, Type> _roleSideEnergyUnitClassMap = new Dictionary<string, Type>
	{
		{
			"UiItem_LupaEmerge",
			typeof(RoleSideEnergyUnit)
		}
	};

	// Token: 0x040074CB RID: 29899
	[Nullable(2)]
	private BattleUiRoleData RoleData;

	// Token: 0x040074CC RID: 29900
	private int EntityId;

	// Token: 0x040074CD RID: 29901
	private readonly Dictionary<int, RoleSideEnergyBarInfo> BarInfoMap = new Dictionary<int, RoleSideEnergyBarInfo>();

	// Token: 0x040074CE RID: 29902
	private bool IsCalcScreenPos;

	// Token: 0x040074CF RID: 29903
	private readonly Vector2D ScreenPos = new Vector2D();

	// Token: 0x040074D0 RID: 29904
	private bool InScreen;
}
