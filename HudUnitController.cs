using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.TreasureHunt;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F82 RID: 8066
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class HudUnitController : UiControllerBase<HudUnitController>
{
	// Token: 0x0600F1B4 RID: 61876 RVA: 0x0042060B File Offset: 0x0041E80B
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600F1B5 RID: 61877 RVA: 0x0042060E File Offset: 0x0041E80E
	protected override bool OnClear()
	{
		Singleton<HudUnitManager>.Instance.Clear();
		this.DelayCreateHudList.Clear();
		return true;
	}

	// Token: 0x0600F1B6 RID: 61878 RVA: 0x00420626 File Offset: 0x0041E826
	protected override bool OnLeaveLevel()
	{
		Singleton<HudUnitManager>.Instance.Clear();
		this.DelayCreateHudList.Clear();
		return true;
	}

	// Token: 0x0600F1B7 RID: 61879 RVA: 0x0042063E File Offset: 0x0041E83E
	protected override void OnTick(float delta)
	{
		Singleton<HudUnitManager>.Instance.Tick(delta);
	}

	// Token: 0x0600F1B8 RID: 61880 RVA: 0x0042064B File Offset: 0x0041E84B
	protected override void OnAfterTick(float delta)
	{
		Singleton<HudUnitManager>.Instance.AfterTick(delta);
	}

	// Token: 0x0600F1B9 RID: 61881 RVA: 0x00420658 File Offset: 0x0041E858
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		Singleton<EventSystem>.Instance.Add<VehiclePassengerInfo, bool>(EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
		Singleton<EventSystem>.Instance.Add<VehiclePassengerInfo, bool>(EEventName.OnLeaveVehicle, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
		ModelBase<BattleUiModel>.Instance.ChildViewData.AddCallback(EBattleUiChild.BattleHud, new Action(this.OnBattleUiChildVisibleChanged));
	}

	// Token: 0x0600F1BA RID: 61882 RVA: 0x004206D8 File Offset: 0x0041E8D8
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		Singleton<EventSystem>.Instance.Remove<VehiclePassengerInfo, bool>(EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
		Singleton<EventSystem>.Instance.Remove<VehiclePassengerInfo, bool>(EEventName.OnLeaveVehicle, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
		ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveCallback(EBattleUiChild.BattleHud, new Action(this.OnBattleUiChildVisibleChanged));
	}

	// Token: 0x0600F1BB RID: 61883 RVA: 0x00420758 File Offset: 0x0041E958
	private void OnBattleUiChildVisibleChanged()
	{
		UUIItem battleViewUnit = Singleton<UiLayer>.Instance.GetBattleViewUnit(1);
		UUIItem battleViewUnit2 = Singleton<UiLayer>.Instance.GetBattleViewUnit(3);
		bool childVisible = ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.BattleHud);
		battleViewUnit.SetUIActive(childVisible);
		battleViewUnit2.SetUIActive(childVisible);
		if (childVisible)
		{
			if (!ModelBase<GameModeModel>.Instance.WorldDone)
			{
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.CFT, "WorldDone前不允许打开hud", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<HudUnitManager>.Instance.ShowHud();
			if (this.DelayCreateHudList.Count > 0)
			{
				foreach (EHudUnitType key in this.DelayCreateHudList)
				{
					Type type;
					Singleton<HudUnitManager>.Instance.HudUnitHandleClassMap.TryGetValue(key, out type);
					if (type != null)
					{
						Singleton<HudUnitManager>.Instance.TryNew(type);
					}
				}
				this.DelayCreateHudList.Clear();
				return;
			}
		}
		else
		{
			Singleton<HudUnitManager>.Instance.HideHud();
		}
	}

	// Token: 0x0600F1BC RID: 61884 RVA: 0x00420864 File Offset: 0x0041EA64
	public void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		Singleton<HudUnitManager>.Instance.RefreshHudOnInputControllerChanged(last, now);
	}

	// Token: 0x0600F1BD RID: 61885 RVA: 0x00420872 File Offset: 0x0041EA72
	public void OnEnterVehicle(VehiclePassengerInfo info, bool byChangeRole)
	{
		if (info.IsRolePassenger(true) && ModelBase<TreasureHuntModel>.Instance.IsEnableCompassTrack(info.VehicleType))
		{
			this.TryCreateHud(EHudUnitType.TreasureCompass);
		}
	}

	// Token: 0x0600F1BE RID: 61886 RVA: 0x00420896 File Offset: 0x0041EA96
	public void OnLeaveVehicle(VehiclePassengerInfo info, bool byChangeRole)
	{
		if (info.IsRolePassenger(true) && ModelBase<TreasureHuntModel>.Instance.IsEnableCompassTrack(info.VehicleType))
		{
			this.TryDestroyHud(EHudUnitType.TreasureCompass);
		}
	}

	// Token: 0x0600F1BF RID: 61887 RVA: 0x004208BC File Offset: 0x0041EABC
	public void TryCreateHud(EHudUnitType type)
	{
		if (!ModelBase<GameModeModel>.Instance.WorldDone)
		{
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.CFT, "WorldDone前不允许打开hud, 缓存起来", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.DelayCreateHudList.Add(type);
			return;
		}
		Type type2;
		Singleton<HudUnitManager>.Instance.HudUnitHandleClassMap.TryGetValue(type, out type2);
		if (type2 != null)
		{
			Singleton<HudUnitManager>.Instance.TryNew(type2);
		}
	}

	// Token: 0x0600F1C0 RID: 61888 RVA: 0x00420928 File Offset: 0x0041EB28
	public void TryDestroyHud(EHudUnitType type)
	{
		if (this.DelayCreateHudList.Remove(type))
		{
			return;
		}
		Type type2;
		Singleton<HudUnitManager>.Instance.HudUnitHandleClassMap.TryGetValue(type, out type2);
		if (type2 != null)
		{
			Singleton<HudUnitManager>.Instance.Destroy(type2);
		}
	}

	// Token: 0x040073FF RID: 29695
	private readonly HashSet<EHudUnitType> DelayCreateHudList = new HashSet<EHudUnitType>();
}
