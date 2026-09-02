using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02001FA0 RID: 8096
public class TDFollowShootAimHandle : HudUnitHandleBase
{
	// Token: 0x0600F355 RID: 62293 RVA: 0x0042865B File Offset: 0x0042685B
	protected override void OnInitialize()
	{
		base.OnInitialize();
	}

	// Token: 0x0600F356 RID: 62294 RVA: 0x00428663 File Offset: 0x00426863
	protected override void OnDestroyed()
	{
		this.DestroyCameraAimUnit();
	}

	// Token: 0x0600F357 RID: 62295 RVA: 0x0042866B File Offset: 0x0042686B
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.SetTDFollowShootAimVisible, new Action<bool>(this.OnSetAimVisible));
	}

	// Token: 0x0600F358 RID: 62296 RVA: 0x00428689 File Offset: 0x00426889
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.SetTDFollowShootAimVisible, new Action<bool>(this.OnSetAimVisible));
	}

	// Token: 0x0600F359 RID: 62297 RVA: 0x004286A7 File Offset: 0x004268A7
	private void OnSetAimVisible(bool bVisible)
	{
		if (bVisible && this.AimUnit == null)
		{
			this.NewCameraAimUnit();
			return;
		}
		if (this.AimUnit == null)
		{
			return;
		}
		this.AimUnit.SetVisible(bVisible, 0);
	}

	// Token: 0x0600F35A RID: 62298 RVA: 0x004286D1 File Offset: 0x004268D1
	private void NewCameraAimUnit()
	{
		base.NewHudUnitWithReturn<TDFollowShootAimUnit>(typeof(TDFollowShootAimUnit), "TrapDefenseFollowAim", out this.AimUnit, true, null, false);
		this.AimUnit.SetVisible(true, 0);
	}

	// Token: 0x0600F35B RID: 62299 RVA: 0x004286FE File Offset: 0x004268FE
	private void DestroyCameraAimUnit()
	{
		if (this.AimUnit == null)
		{
			return;
		}
		base.DestroyHudUnit(this.AimUnit);
		this.AimUnit = null;
	}

	// Token: 0x040074E5 RID: 29925
	[Nullable(2)]
	private TDFollowShootAimUnit AimUnit;
}
