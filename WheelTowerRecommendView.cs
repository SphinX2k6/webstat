using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016DA RID: 5850
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerRecommendView : UiViewBase
{
	// Token: 0x0600A277 RID: 41591 RVA: 0x002ADA73 File Offset: 0x002ABC73
	public WheelTowerRecommendView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A278 RID: 41592 RVA: 0x002ADA7C File Offset: 0x002ABC7C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A279 RID: 41593 RVA: 0x002ADAE8 File Offset: 0x002ABCE8
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerRecommendView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerRecommendView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A27A RID: 41594 RVA: 0x002ADB2B File Offset: 0x002ABD2B
	private WheelTowerRecommendTeam CreateTeamItem()
	{
		return new WheelTowerRecommendTeam
		{
			OnApplyBtnClick = new Action<NewTowerRecommendTeam>(this.OnApplyBtnClick)
		};
	}

	// Token: 0x0600A27B RID: 41595 RVA: 0x002ADB44 File Offset: 0x002ABD44
	private void OnApplyBtnClick(NewTowerRecommendTeam data)
	{
		List<int> list = new List<int>();
		foreach (int num in data.RoleIds)
		{
			MainRoleConfig? correctMainRoleConfig = ModelBase<RoleModel>.Instance.GetCorrectMainRoleConfig(num);
			list.Add((correctMainRoleConfig != null) ? correctMainRoleConfig.Value.Id : num);
		}
		ModelBase<WheelTowerModel>.Instance.SelectedRoleList = list;
		ModelBase<WheelTowerModel>.Instance.SelectedBuff = ((data.BuffIds.Count > 0) ? data.BuffIds[0] : 0);
		int num2 = 0;
		while (num2 < data.SkillBranchIds.Count && num2 < list.Count)
		{
			ModelBase<RoleModel>.Instance.SetRoleSkillBranchGamePlayCache(list[num2], data.SkillBranchIds[num2], ESkillBranchCacheType.WheelTower);
			num2++;
		}
		base.CloseMe(null);
	}

	// Token: 0x04004CC5 RID: 19653
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<WheelTowerRecommendTeam, NewTowerRecommendTeam> TeamScrollView;
}
