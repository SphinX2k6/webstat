using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TreasureHunt;

// Token: 0x02001FA1 RID: 8097
public class TreasureCompassHandle : HudUnitHandleBase
{
	// Token: 0x0600F35D RID: 62301 RVA: 0x00428724 File Offset: 0x00426924
	protected override void OnInitialize()
	{
		base.OnInitialize();
		this.IsEnableTick = ModelBase<TreasureHuntModel>.Instance.IsCompassActive();
		this.TrackingEntityId = 0;
		this.LoadCompassView();
	}

	// Token: 0x0600F35E RID: 62302 RVA: 0x00428749 File Offset: 0x00426949
	protected override void OnDestroyed()
	{
		if (this.TreasureCompassUnit != null)
		{
			base.DestroyHudUnit(this.TreasureCompassUnit);
			this.TreasureCompassUnit = null;
		}
		ControllerBase<TreasureHuntController>.Instance.ClearNearbyTrack();
	}

	// Token: 0x0600F35F RID: 62303 RVA: 0x00428770 File Offset: 0x00426970
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnUpdateCompassActive, new Action<bool>(this.OnUpdateCompassActive));
	}

	// Token: 0x0600F360 RID: 62304 RVA: 0x0042878E File Offset: 0x0042698E
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnUpdateCompassActive, new Action<bool>(this.OnUpdateCompassActive));
	}

	// Token: 0x0600F361 RID: 62305 RVA: 0x004287AC File Offset: 0x004269AC
	private void OnUpdateCompassActive(bool isActive)
	{
		this.IsEnableTick = isActive;
		if (!isActive)
		{
			TreasureCompassUnit treasureCompassUnit = this.TreasureCompassUnit;
			if (treasureCompassUnit == null)
			{
				return;
			}
			treasureCompassUnit.SetActive(false);
		}
	}

	// Token: 0x0600F362 RID: 62306 RVA: 0x004287C9 File Offset: 0x004269C9
	private void LoadCompassView()
	{
		base.NewHudUnitWithReturn<TreasureCompassUnit>(typeof(TreasureCompassUnit), "UiItem_ShipRing", out this.TreasureCompassUnit, false, delegate(TreasureCompassUnit _)
		{
			TreasureCompassUnit treasureCompassUnit = this.TreasureCompassUnit;
			if (treasureCompassUnit == null)
			{
				return;
			}
			treasureCompassUnit.InitHide();
		}, true);
	}

	// Token: 0x0600F363 RID: 62307 RVA: 0x004287F4 File Offset: 0x004269F4
	protected override void OnTick(float delta)
	{
		if (!this.IsEnableTick)
		{
			return;
		}
		List<ITreasureData> treasureList = ModelBase<TreasureHuntModel>.Instance.GetTreasureList(true);
		if (treasureList == null || treasureList.Count == 0)
		{
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		Vector vector;
		if (baseCharacter == null)
		{
			vector = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			vector = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
		}
		Vector vector2 = vector;
		if (vector2 == null)
		{
			return;
		}
		ITreasureData treasureData = null;
		foreach (ITreasureData treasureData2 in treasureList)
		{
			if (treasureData2.IsEnableCompassTracking.GetValueOrDefault())
			{
				treasureData = treasureData2;
				break;
			}
		}
		if (treasureData == null)
		{
			this.TrackingEntityId = 0;
			ControllerBase<TreasureHuntController>.Instance.ClearNearbyTrack();
		}
		else if (treasureData.IsNearbyTracking.GetValueOrDefault())
		{
			double? num = treasureData.DistSquared;
			double? num2 = treasureData.NearbyTrackHideRangeSquared;
			if (num.GetValueOrDefault() > num2.GetValueOrDefault() & (num != null & num2 != null))
			{
				this.TrackingEntityId = 0;
				ControllerBase<TreasureHuntController>.Instance.ClearNearbyTrack();
			}
		}
		else
		{
			double? num2 = treasureData.DistSquared;
			double? num = treasureData.NearbyTrackShowRangeSquared;
			if ((num2.GetValueOrDefault() < num.GetValueOrDefault() & (num2 != null & num != null)) && treasureData.EntityId != this.TrackingEntityId)
			{
				this.TrackingEntityId = treasureData.EntityId;
				ControllerBase<TreasureHuntController>.Instance.SetNearbyTrack(treasureData.EntityId);
			}
		}
		TreasureCompassUnit treasureCompassUnit = this.TreasureCompassUnit;
		if (treasureCompassUnit == null)
		{
			return;
		}
		treasureCompassUnit.RefreshCompass(treasureList, vector2);
	}

	// Token: 0x040074E6 RID: 29926
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat TickStatsObject = Stat.Create("TreasureCompassHandleTick", "", "");

	// Token: 0x040074E7 RID: 29927
	[Nullable(2)]
	private TreasureCompassUnit TreasureCompassUnit;

	// Token: 0x040074E8 RID: 29928
	private bool IsEnableTick;

	// Token: 0x040074E9 RID: 29929
	private int TrackingEntityId;
}
