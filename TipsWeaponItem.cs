using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A77 RID: 6775
public class TipsWeaponItem : UiPanelBase
{
	// Token: 0x0600C1D4 RID: 49620 RVA: 0x00331348 File Offset: 0x0032F548
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600C1D5 RID: 49621 RVA: 0x003313E4 File Offset: 0x0032F5E4
	protected override UniTask OnBeforeStartAsync()
	{
		TipsWeaponItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TipsWeaponItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C1D6 RID: 49622 RVA: 0x00331428 File Offset: 0x0032F628
	[NullableContext(1)]
	public void UpdateItem(WeaponConf weaponConfig, int resonanceLevel, string descriptionText)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "WeaponResonanceItemLevelText", new <>z__ReadOnlySingleElementList<object>(resonanceLevel));
		WeaponReson? weaponResonanceConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceConfig(weaponConfig.ResonId, resonanceLevel);
		base.GetText(8).SetText(descriptionText, true);
		if (weaponResonanceConfig != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), weaponResonanceConfig.Value.Name, Array.Empty<object>());
		}
		string[] weaponConfigDescParams = ModelBase<WeaponModel>.Instance.GetWeaponConfigDescParams(weaponConfig, resonanceLevel);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), weaponConfig.Desc, weaponConfigDescParams);
		WeaponBreach? weaponBreach = ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(weaponConfig.BreachId, 0);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "ShopWeaponLevelText", new <>z__ReadOnlyArray<object>(new object[]
		{
			1,
			weaponBreach.Value.LevelLimit
		}));
		UiComponentUtil.SetStarActiveNew(this.StarItemList.ToArray(), 0, null, false);
	}

	// Token: 0x04005AD3 RID: 23251
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<CSharpScript.Game.Module.RoleUi.StarItem> StarItemList;

	// Token: 0x02007D28 RID: 32040
	private enum ETipsWeaponItemDefine
	{
		// Token: 0x0402AAAE RID: 174766
		DescribeText = 8,
		// Token: 0x0402AAAF RID: 174767
		ResonanceLevelText = 0,
		// Token: 0x0402AAB0 RID: 174768
		ResonanceDescribeText = 7,
		// Token: 0x0402AAB1 RID: 174769
		SkillNameText = 1,
		// Token: 0x0402AAB2 RID: 174770
		PanelStar = 3,
		// Token: 0x0402AAB3 RID: 174771
		WeaponLevelText = 2
	}
}
