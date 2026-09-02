using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200156C RID: 5484
[NullableContext(1)]
[Nullable(0)]
public class RoleGiftData : ActivityBaseData
{
	// Token: 0x060099EE RID: 39406 RVA: 0x00284CBF File Offset: 0x00282EBF
	protected override void OnInit(ActivityData data)
	{
		this.InitConfig();
	}

	// Token: 0x060099EF RID: 39407 RVA: 0x00284CC8 File Offset: 0x00282EC8
	private void InitConfig()
	{
		if (this.ConfigInitialized)
		{
			return;
		}
		this.ConfigInitialized = true;
		RoleGiftConfig? config = ConfigRoleGiftConfigByActivityId.GetConfig(base.Id, true);
		string message = "InitConfig";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleGiftConfig", (config != null) ? new int?(config.GetValueOrDefault().DropId) : null);
		RoleGiftUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (config != null)
		{
			RoleGiftConfig value = config.Value;
			this.DropIdInternal = value.DropId;
			this.ResolveRoleIdFromDrop(this.DropIdInternal);
			this.RoleGiftConfigIdInternal = value.Id;
		}
	}

	// Token: 0x060099F0 RID: 39408 RVA: 0x00284D74 File Offset: 0x00282F74
	private unsafe void ResolveRoleIdFromDrop(int dropId)
	{
		this.RoleIdInternal = 0;
		this.RoleTrialIdInternal = 0;
		if (dropId == 0)
		{
			string message = "ResolveRoleIdFromDrop";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", "empty_dropId");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("dropId", dropId);
			RoleGiftUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		DropPackage? config = ConfigDropPackageById.GetConfig(dropId, true);
		if (config == null)
		{
			string message2 = "ResolveRoleIdFromDrop";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("reason", "no_drop_or_preview");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("dropId", dropId);
			RoleGiftUtil.Debug(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		DropPackage value = config.Value;
		int dropPreviewLength = value.DropPreviewLength;
		if (dropPreviewLength <= 0)
		{
			string message3 = "ResolveRoleIdFromDrop";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("reason", "no_drop_or_preview");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("dropId", dropId);
			RoleGiftUtil.Debug(message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return;
		}
		for (int i = 0; i < dropPreviewLength; i++)
		{
			DicIntInt? dicIntInt = value.DropPreview(i);
			if (dicIntInt != null)
			{
				int key = dicIntInt.Value.Key;
				if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key)) == InventoryDefine.EItemDataType.RoleItem)
				{
					this.RoleIdInternal = key;
					this.RoleTrialIdInternal = RoleGiftData.RoleIdToTrialId(key);
					string message4 = "ResolveRoleIdFromDrop";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("reason", "resolved");
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("dropId", dropId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("roleId", this.RoleIdInternal);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("roleTrialId", this.RoleTrialIdInternal);
					RoleGiftUtil.Debug(message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 4));
					return;
				}
			}
		}
		string message5 = "ResolveRoleIdFromDrop";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("reason", "no_role_in_preview");
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("dropId", dropId);
		RoleGiftUtil.Debug(message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
	}

	// Token: 0x060099F1 RID: 39409 RVA: 0x0028500C File Offset: 0x0028320C
	private static int RoleIdToTrialId(int roleId)
	{
		GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(roleId);
		if (gachaTextureInfo == null)
		{
			return 0;
		}
		return gachaTextureInfo.GetValueOrDefault().TrialId;
	}

	// Token: 0x060099F2 RID: 39410 RVA: 0x0028503F File Offset: 0x0028323F
	public int GetDropId()
	{
		return this.DropIdInternal;
	}

	// Token: 0x060099F3 RID: 39411 RVA: 0x00285047 File Offset: 0x00283247
	public int GetRoleId()
	{
		return this.RoleIdInternal;
	}

	// Token: 0x060099F4 RID: 39412 RVA: 0x0028504F File Offset: 0x0028324F
	public int GetRoleTrialId()
	{
		return this.RoleTrialIdInternal;
	}

	// Token: 0x060099F5 RID: 39413 RVA: 0x00285057 File Offset: 0x00283257
	public int GetRoleGiftConfigId()
	{
		return this.RoleGiftConfigIdInternal;
	}

	// Token: 0x060099F6 RID: 39414 RVA: 0x0028505F File Offset: 0x0028325F
	public void SetHadGetReward(bool hadGet)
	{
		this.RewardHadGet = hadGet;
	}

	// Token: 0x060099F7 RID: 39415 RVA: 0x00285068 File Offset: 0x00283268
	protected override void PhraseEx(ActivityData data)
	{
		RoleGiftActivityData roleGiftActivityData = data.RoleGiftActivityData;
		if (roleGiftActivityData == null)
		{
			return;
		}
		this.InitConfig();
		this.RewardHadGet = roleGiftActivityData.RewardHadGet;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, base.Id);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060099F8 RID: 39416 RVA: 0x002850BE File Offset: 0x002832BE
	public bool GetRewardHadGet()
	{
		return this.RewardHadGet;
	}

	// Token: 0x060099F9 RID: 39417 RVA: 0x002850C8 File Offset: 0x002832C8
	public unsafe bool CanReceiveReward()
	{
		bool flag = base.IsUnLock();
		bool flag2 = flag && !this.RewardHadGet;
		string message = "CanReceiveReward";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("activityId", base.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isUnLock", flag);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("rewardHadGet", this.RewardHadGet);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("canReceive", flag2);
		RoleGiftUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		return flag2;
	}

	// Token: 0x060099FA RID: 39418 RVA: 0x00285185 File Offset: 0x00283385
	public bool NeedSplash()
	{
		return this.CanReceiveReward();
	}

	// Token: 0x060099FB RID: 39419 RVA: 0x0028518D File Offset: 0x0028338D
	public override bool GetExDataRedPointShowState()
	{
		return !this.RewardHadGet && base.IsUnLock();
	}

	// Token: 0x060099FC RID: 39420 RVA: 0x0028519F File Offset: 0x0028339F
	protected override bool GetExDataFinishShowState()
	{
		return this.RewardHadGet;
	}

	// Token: 0x04004703 RID: 18179
	private bool RewardHadGet;

	// Token: 0x04004704 RID: 18180
	private bool ConfigInitialized;

	// Token: 0x04004705 RID: 18181
	private int DropIdInternal;

	// Token: 0x04004706 RID: 18182
	private int RoleIdInternal;

	// Token: 0x04004707 RID: 18183
	private int RoleTrialIdInternal;

	// Token: 0x04004708 RID: 18184
	private int RoleGiftConfigIdInternal;
}
