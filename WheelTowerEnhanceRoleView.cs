using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016C8 RID: 5832
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerEnhanceRoleView : UiViewBase
{
	// Token: 0x0600A1E5 RID: 41445 RVA: 0x002A98E5 File Offset: 0x002A7AE5
	public WheelTowerEnhanceRoleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A1E6 RID: 41446 RVA: 0x002A98FC File Offset: 0x002A7AFC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIMultiTemplateLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A1E7 RID: 41447 RVA: 0x002A9A70 File Offset: 0x002A7C70
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerEnhanceRoleView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerEnhanceRoleView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A1E8 RID: 41448 RVA: 0x002A9AB4 File Offset: 0x002A7CB4
	private void RefreshRightPanel()
	{
		Aki.Config.RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.SelectedRoleId);
		if (roleConfig == null)
		{
			return;
		}
		base.SetTextureShowUntilLoaded(roleConfig.Value.FormationRoleCard, base.GetTexture(3), null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), roleConfig.Value.Name, Array.Empty<object>());
		int[] roleTagByRoleInfo = ModelBase<RoleModel>.Instance.GetRoleTagByRoleInfo(roleConfig.Value);
		bool flag = roleTagByRoleInfo != null && roleTagByRoleInfo.Length != 0;
		GenericLayout<RoleTagMediumIconItem, int> tagLayout = this.TagLayout;
		if (tagLayout != null)
		{
			UUIItem rootUiItem = tagLayout.GetRootUiItem();
			if (rootUiItem != null)
			{
				rootUiItem.SetUIActive(flag);
			}
		}
		if (flag && roleTagByRoleInfo != null)
		{
			GenericLayout<RoleTagMediumIconItem, int> tagLayout2 = this.TagLayout;
			if (tagLayout2 != null)
			{
				tagLayout2.RefreshByData(new <>z__ReadOnlyArray<int>(roleTagByRoleInfo.ToArray<int>()), null, false);
			}
		}
		List<WheelTowerRoleEnhanceSkillData> enhanceSkillInfoList = ModelBase<WheelTowerModel>.Instance.GetEnhanceSkillInfoList(this.SelectedRoleId);
		GenericLayout<WheelTowerRoleEnhanceSkillItem, WheelTowerRoleEnhanceSkillData> skillLayout = this.SkillLayout;
		if (skillLayout != null)
		{
			skillLayout.RefreshByData(enhanceSkillInfoList, null, false);
		}
		int specialUpRoleAddEnergy = ModelBase<WheelTowerModel>.Instance.GetSpecialUpRoleAddEnergy(this.SelectedRoleId);
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(specialUpRoleAddEnergy > 0);
		}
		UUIText text = base.GetText(8);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("+");
			defaultInterpolatedStringHandler.AppendFormatted<int>(specialUpRoleAddEnergy);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "NewTower_Addenergy", new <>z__ReadOnlySingleElementList<object>(specialUpRoleAddEnergy));
	}

	// Token: 0x0600A1E9 RID: 41449 RVA: 0x002A9C28 File Offset: 0x002A7E28
	private void OnRoleItemClick(int roleId)
	{
		this.SelectedRoleId = roleId;
		int gridIndex = this.RoleIdList.FindIndex((int id) => id == roleId);
		LoopScrollView<WheelTowerEnhanceRoleGridItem, int> roleLoopScrollView = this.RoleLoopScrollView;
		if (roleLoopScrollView != null)
		{
			roleLoopScrollView.SelectGridProxy(gridIndex, false);
		}
		base.PlayOrReplaySequence("Switch", false, null);
		this.RefreshRightPanel();
	}

	// Token: 0x0600A1EA RID: 41450 RVA: 0x002A9C94 File Offset: 0x002A7E94
	private WheelTowerEnhanceRoleGridItem CreateRoleItem()
	{
		WheelTowerEnhanceRoleGridItem wheelTowerEnhanceRoleGridItem = new WheelTowerEnhanceRoleGridItem();
		wheelTowerEnhanceRoleGridItem.SetToggleClickCallback(new Action<int>(this.OnRoleItemClick));
		return wheelTowerEnhanceRoleGridItem;
	}

	// Token: 0x0600A1EB RID: 41451 RVA: 0x002A9CAD File Offset: 0x002A7EAD
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x04004C01 RID: 19457
	private const string TEXT_SPECIAL_UP_ROLE_TIPS = "NewTower_Addenergy";

	// Token: 0x04004C02 RID: 19458
	private int SelectedRoleId;

	// Token: 0x04004C03 RID: 19459
	private List<int> RoleIdList = new List<int>();

	// Token: 0x04004C04 RID: 19460
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004C05 RID: 19461
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<WheelTowerEnhanceRoleGridItem, int> RoleLoopScrollView;

	// Token: 0x04004C06 RID: 19462
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RoleTagMediumIconItem, int> TagLayout;

	// Token: 0x04004C07 RID: 19463
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerRoleEnhanceSkillItem, WheelTowerRoleEnhanceSkillData> SkillLayout;
}
