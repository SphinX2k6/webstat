using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001A91 RID: 6801
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class CreateCharacterController : UiControllerBase<CreateCharacterController>
{
	// Token: 0x0600C2C9 RID: 49865 RVA: 0x003355DE File Offset: 0x003337DE
	public static void TriggerInputName()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.CreateRoleShowInputName);
	}

	// Token: 0x0600C2CA RID: 49866 RVA: 0x003355F0 File Offset: 0x003337F0
	public static void AddBurstEyeRenderingMaterial(bool isBoy)
	{
		int roleId = ConfigBase<CreateCharacterConfig>.Instance.GetInitialRoles()[(isBoy > false) ? 1 : 0];
		string effectId = isBoy ? "RoleMaleBurstEyeMaterialController" : "RoleFemaleBurstEyeMaterialController";
		int burstEyeMaterialId = Singleton<UiLoginSceneManager>.Instance.SetRoleRenderingMaterial(roleId, effectId);
		Singleton<UiLoginSceneManager>.Instance.SetBurstEyeMaterialId(burstEyeMaterialId);
	}

	// Token: 0x0600C2CB RID: 49867 RVA: 0x0033563C File Offset: 0x0033383C
	public static void RemoveBurstEyeRenderingMaterial(bool isBoy)
	{
		int roleId = ConfigBase<CreateCharacterConfig>.Instance.GetInitialRoles()[(isBoy > false) ? 1 : 0];
		int burstEyeMaterialId = Singleton<UiLoginSceneManager>.Instance.GetBurstEyeMaterialId();
		Singleton<UiLoginSceneManager>.Instance.RemoveRoleRenderingMaterial(roleId, burstEyeMaterialId);
	}
}
