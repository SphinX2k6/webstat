using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02002A07 RID: 10759
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MoonTogetherModel : ModelBase<MoonTogetherModel>
{
	// Token: 0x17001BFC RID: 7164
	// (get) Token: 0x06015782 RID: 87938 RVA: 0x005F3A19 File Offset: 0x005F1C19
	public int CurInviteRoleId
	{
		get
		{
			return this.CurInviteRole;
		}
	}

	// Token: 0x06015783 RID: 87939 RVA: 0x005F3A21 File Offset: 0x005F1C21
	public void InviteRole(int roleId)
	{
		this.SelectRole = roleId;
	}

	// Token: 0x06015784 RID: 87940 RVA: 0x005F3A2C File Offset: 0x005F1C2C
	public void ExitAndClear()
	{
		this.IsInMoonTogether = false;
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MoonTogetherMainView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.MoonTogetherMainView, null);
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MoonTogetherInviteView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.MoonTogetherInviteView, null);
		}
	}

	// Token: 0x06015785 RID: 87941 RVA: 0x005F3A84 File Offset: 0x005F1C84
	public void SendAndSave()
	{
		this.IsInMoonTogether = true;
		if (this.CurInviteRole == this.SelectRole)
		{
			return;
		}
		if (this.CurInviteRole != 0)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnRemoveRideSharingPassenger, this.CurInviteRole, 1);
		}
		if (this.SelectRole != 0)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnChangeRideSharingPassenger, this.SelectRole, 1);
		}
		this.CurInviteRole = this.SelectRole;
	}

	// Token: 0x06015786 RID: 87942 RVA: 0x005F3AF4 File Offset: 0x005F1CF4
	public bool IsLinkageRole(int roleId)
	{
		VehicleRidingRoles? vehicleRidingRolesById = ConfigBase<MoonTogetherConfig>.Instance.GetVehicleRidingRolesById(roleId);
		return vehicleRidingRolesById != null && vehicleRidingRolesById.GetValueOrDefault().RegionId == 1006;
	}

	// Token: 0x06015787 RID: 87943 RVA: 0x005F3B2E File Offset: 0x005F1D2E
	public bool IsLinkageRegion(int regionId)
	{
		return regionId == 1006;
	}

	// Token: 0x06015788 RID: 87944 RVA: 0x005F3B38 File Offset: 0x005F1D38
	public void ClearCurInviteRole()
	{
		this.CurInviteRole = 0;
		this.SelectRole = 0;
	}

	// Token: 0x0400A532 RID: 42290
	private const int LINKAGE_ROLE_REGION = 1006;

	// Token: 0x0400A533 RID: 42291
	public bool IsInMoonTogether;

	// Token: 0x0400A534 RID: 42292
	private int CurInviteRole;

	// Token: 0x0400A535 RID: 42293
	private int SelectRole;

	// Token: 0x0400A536 RID: 42294
	public int HandleEntityId;
}
