using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001648 RID: 5704
public class WheelTowerLoadingTeamRoleItem : GridProxyAbstract<int>
{
	// Token: 0x0600A04B RID: 41035 RVA: 0x0029ED38 File Offset: 0x0029CF38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A04C RID: 41036 RVA: 0x0029EE28 File Offset: 0x0029D028
	public override void Refresh(int roleId, bool isSelected, int gridIndex)
	{
		int id = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleId);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
		if (roleDataById == null)
		{
			return;
		}
		bool flag = ModelBase<WheelTowerModel>.Instance.IsTemplateRole(roleId);
		this.RoleDataBase = roleDataById;
		this.IsTemplateRole = flag;
		int num;
		if (flag)
		{
			TrialRoleInfo? trialRoleInfo;
			num = ((ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleConfig(roleId) != null) ? trialRoleInfo.GetValueOrDefault().Level : 90);
		}
		else
		{
			num = roleDataById.GetLevelData().GetLevel();
		}
		RoleInfo roleConfig = roleDataById.GetRoleConfig();
		ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(roleConfig.ElementId);
		if (elementConfig != null)
		{
			base.SetTextureShowUntilLoaded(elementConfig.Value.Icon5, base.GetTexture(2), null);
		}
		int value = gridIndex + 1;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
		defaultInterpolatedStringHandler.AppendLiteral("T_WheelTowerLoadingTeamNum");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureShowUntilLoaded(resourcePath, base.GetTexture(1), null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Text_LevelShow_Text", new <>z__ReadOnlySingleElementList<object>(num));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), roleConfig.Name, Array.Empty<object>());
		int roleSkillBranchIndexInGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInGamePlay(roleId, ESkillBranchCacheType.WheeTowerLoading);
		FVector fvector = new FVector(0f, (float)((roleSkillBranchIndexInGamePlay == 0) ? 0 : 180), 0f);
		FRotator frotator = FRotator.MakeFromEuler(fvector);
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIRelativeRotation(frotator);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(roleSkillBranchIndexInGamePlay > -1);
	}

	// Token: 0x0600A04D RID: 41037 RVA: 0x0029EFD4 File Offset: 0x0029D1D4
	public UniTask RefreshRoleSkinAsync()
	{
		WheelTowerLoadingTeamRoleItem.<RefreshRoleSkinAsync>d__4 <RefreshRoleSkinAsync>d__;
		<RefreshRoleSkinAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleSkinAsync>d__.<>4__this = this;
		<RefreshRoleSkinAsync>d__.<>1__state = -1;
		<RefreshRoleSkinAsync>d__.<>t__builder.Start<WheelTowerLoadingTeamRoleItem.<RefreshRoleSkinAsync>d__4>(ref <RefreshRoleSkinAsync>d__);
		return <RefreshRoleSkinAsync>d__.<>t__builder.Task;
	}

	// Token: 0x040049CF RID: 18895
	[Nullable(2)]
	private RoleDataBase RoleDataBase;

	// Token: 0x040049D0 RID: 18896
	private bool IsTemplateRole;
}
