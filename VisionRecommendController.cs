using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x020024A0 RID: 9376
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionRecommendController : UiControllerBase<VisionRecommendController>
{
	// Token: 0x0601230E RID: 74510 RVA: 0x005014DC File Offset: 0x004FF6DC
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleInfoUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.RoleInfoUpdate, new Action(this.OnRoleInfoUpdate));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ActiveRole, new Action<int>(this.OnActiveRole));
	}

	// Token: 0x0601230F RID: 74511 RVA: 0x00501540 File Offset: 0x004FF740
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleInfoUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleInfoUpdate, new Action(this.OnRoleInfoUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActiveRole, new Action<int>(this.OnActiveRole));
	}

	// Token: 0x06012310 RID: 74512 RVA: 0x005015A4 File Offset: 0x004FF7A4
	private void OnRoleInfoUpdate()
	{
		foreach (RoleInstance roleInstance in ModelBase<RoleModel>.Instance.GetRoleList())
		{
			this.RequestRoleVisionRecommendData(roleInstance.GetRoleId());
			this.RequestRoleVisionRecommendAttr(roleInstance.GetRoleId());
		}
	}

	// Token: 0x06012311 RID: 74513 RVA: 0x005015E6 File Offset: 0x004FF7E6
	private void OnActiveRole(int roleId)
	{
		this.RequestRoleVisionRecommendData(roleId);
		this.RequestRoleVisionRecommendAttr(roleId);
	}

	// Token: 0x06012312 RID: 74514 RVA: 0x005015F8 File Offset: 0x004FF7F8
	public void RequestRoleVisionRecommendData(int roleId)
	{
		PhantomFetterRecommendRequest phantomFetterRecommendRequest = PhantomFetterRecommendRequest.Create();
		phantomFetterRecommendRequest.RoleId = roleId;
		Singleton<Net>.Instance.Call<PhantomFetterRecommendResponse>(ERequestMessageId.PhantomFetterRecommendRequest, phantomFetterRecommendRequest, delegate(PhantomFetterRecommendResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<VisionRecommendModel>.Instance.OnRoleRecommendData(roleId, response);
		}, 0);
	}

	// Token: 0x06012313 RID: 74515 RVA: 0x00501644 File Offset: 0x004FF844
	public void RequestRoleVisionRecommendAttr(int roleId)
	{
		PhantomAttrRecommendRequest phantomAttrRecommendRequest = PhantomAttrRecommendRequest.Create();
		phantomAttrRecommendRequest.RoleId = roleId;
		Singleton<Net>.Instance.Call<PhantomAttrRecommendResponse>(ERequestMessageId.PhantomAttrRecommendRequest, phantomAttrRecommendRequest, delegate(PhantomAttrRecommendResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<VisionRecommendModel>.Instance.OnRoleRecommendAttrData(roleId, response);
		}, 0);
	}
}
