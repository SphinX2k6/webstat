using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;

// Token: 0x02002A49 RID: 10825
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class CalabashSkinModel : ModelBase<CalabashSkinModel>
{
	// Token: 0x06015ACF RID: 88783 RVA: 0x006048C9 File Offset: 0x00602AC9
	protected override bool OnClear()
	{
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.CalabashSkinRedDot);
		return true;
	}

	// Token: 0x06015AD0 RID: 88784 RVA: 0x006048DC File Offset: 0x00602ADC
	private bool TryAddCalabashSkinRedDot(int configId)
	{
		if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.CalabashSkinRedDot, configId))
		{
			return false;
		}
		ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.CalabashSkinRedDot, configId);
		int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
		if (curSelectMainRoleId != null)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleSkinRedDotRefresh, curSelectMainRoleId.Value);
			Singleton<EventSystem>.Instance.Emit(EEventName.HuluSkinRedDotRefresh);
		}
		return true;
	}

	// Token: 0x06015AD1 RID: 88785 RVA: 0x00604944 File Offset: 0x00602B44
	private void SetCurrentEquippedSkinId(int skinId)
	{
		this.CurrentEquippedSkinId = skinId;
	}

	// Token: 0x06015AD2 RID: 88786 RVA: 0x00604950 File Offset: 0x00602B50
	private void SetUnLockSkinData(int[] skinIdList)
	{
		this.UnLockSkinSet.Clear();
		foreach (int item in skinIdList)
		{
			this.UnLockSkinSet.Add(item);
		}
	}

	// Token: 0x06015AD3 RID: 88787 RVA: 0x0060498C File Offset: 0x00602B8C
	public void RemoveCalabashSkinRedDot(int configId)
	{
		ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.CalabashSkinRedDot, configId);
		int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
		if (curSelectMainRoleId != null)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleSkinRedDotRefresh, curSelectMainRoleId.Value);
			Singleton<EventSystem>.Instance.Emit(EEventName.HuluSkinRedDotRefresh);
		}
	}

	// Token: 0x06015AD4 RID: 88788 RVA: 0x006049E2 File Offset: 0x00602BE2
	public int GetCurrentEquipSkinId()
	{
		return this.CurrentEquippedSkinId;
	}

	// Token: 0x06015AD5 RID: 88789 RVA: 0x006049EA File Offset: 0x00602BEA
	public int GetSkinCountById(int skinId)
	{
		return (this.UnLockSkinSet.Contains(skinId) > false) ? 1 : 0;
	}

	// Token: 0x06015AD6 RID: 88790 RVA: 0x006049FC File Offset: 0x00602BFC
	public unsafe void NotifyCalabashSkinData(int equipSkinId, int[] skinIdList)
	{
		this.SetCurrentEquippedSkinId(equipSkinId);
		this.SetUnLockSkinData(skinIdList);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CalabashSkin;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "葫芦皮肤全量推送";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("equipSkinId", equipSkinId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skinIdList", skinIdList);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06015AD7 RID: 88791 RVA: 0x00604A74 File Offset: 0x00602C74
	public void NotifyAddUnlockSkinData(int[] skinIdList)
	{
		foreach (int num in skinIdList)
		{
			this.UnLockSkinSet.Add(num);
			this.TryAddCalabashSkinRedDot(num);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CalabashSkin;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "葫芦皮肤增量推送";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skinIdList", skinIdList);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015AD8 RID: 88792 RVA: 0x00604AD4 File Offset: 0x00602CD4
	public void NotifyCurrentEquippedSkinId(int skinId)
	{
		this.SetCurrentEquippedSkinId(skinId);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CalabashSkin;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "葫芦皮肤装备";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skinId", skinId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015AD9 RID: 88793 RVA: 0x00604B18 File Offset: 0x00602D18
	public bool CheckCalabashSkinHasRedDotByRoleId(int roleId)
	{
		int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
		return (roleId == curSelectMainRoleId.GetValueOrDefault() & curSelectMainRoleId != null) && this.CheckCalabashSkinHasRedDot();
	}

	// Token: 0x06015ADA RID: 88794 RVA: 0x00604B4C File Offset: 0x00602D4C
	public bool CheckCalabashSkinHasRedDot()
	{
		foreach (int value in this.UnLockSkinSet)
		{
			if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.CalabashSkinRedDot, value))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400A674 RID: 42612
	private readonly HashSet<int> UnLockSkinSet = new HashSet<int>();

	// Token: 0x0400A675 RID: 42613
	private int CurrentEquippedSkinId;
}
