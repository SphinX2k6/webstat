using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025C9 RID: 9673
public class FightPhotoSettingPanel : FightPhotoTabPanelBase
{
	// Token: 0x06012E93 RID: 77459 RVA: 0x0053B720 File Offset: 0x00539920
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06012E94 RID: 77460 RVA: 0x0053B790 File Offset: 0x00539990
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoSettingPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoSettingPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012E95 RID: 77461 RVA: 0x0053B7D4 File Offset: 0x005399D4
	private UniTask InitializeFightPhotoSetup()
	{
		FightPhotoSettingPanel.<InitializeFightPhotoSetup>d__4 <InitializeFightPhotoSetup>d__;
		<InitializeFightPhotoSetup>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeFightPhotoSetup>d__.<>4__this = this;
		<InitializeFightPhotoSetup>d__.<>1__state = -1;
		<InitializeFightPhotoSetup>d__.<>t__builder.Start<FightPhotoSettingPanel.<InitializeFightPhotoSetup>d__4>(ref <InitializeFightPhotoSetup>d__);
		return <InitializeFightPhotoSetup>d__.<>t__builder.Task;
	}

	// Token: 0x06012E96 RID: 77462 RVA: 0x0053B818 File Offset: 0x00539A18
	[NullableContext(1)]
	private UniTask NewSetupItem(int configId, int uiType, UUIItem contentItem, UUIItem itemDropDown, UUIItem itemSlider, UUIItem itemScroll)
	{
		FightPhotoSettingPanel.<NewSetupItem>d__5 <NewSetupItem>d__;
		<NewSetupItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewSetupItem>d__.<>4__this = this;
		<NewSetupItem>d__.configId = configId;
		<NewSetupItem>d__.uiType = uiType;
		<NewSetupItem>d__.contentItem = contentItem;
		<NewSetupItem>d__.itemDropDown = itemDropDown;
		<NewSetupItem>d__.itemSlider = itemSlider;
		<NewSetupItem>d__.itemScroll = itemScroll;
		<NewSetupItem>d__.<>1__state = -1;
		<NewSetupItem>d__.<>t__builder.Start<FightPhotoSettingPanel.<NewSetupItem>d__5>(ref <NewSetupItem>d__);
		return <NewSetupItem>d__.<>t__builder.Task;
	}

	// Token: 0x06012E97 RID: 77463 RVA: 0x0053B890 File Offset: 0x00539A90
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		foreach (FightPhotoSetupBase fightPhotoSetupBase in this.SetupItemMap.Values)
		{
			fightPhotoSetupBase.Destroy(null);
		}
		this.SetupItemMap.Clear();
	}

	// Token: 0x040093BB RID: 37819
	[Nullable(1)]
	private readonly Dictionary<int, FightPhotoSetupBase> SetupItemMap = new Dictionary<int, FightPhotoSetupBase>();

	// Token: 0x02008931 RID: 35121
	private enum EComponents
	{
		// Token: 0x0402E4AB RID: 189611
		Content,
		// Token: 0x0402E4AC RID: 189612
		ItemDropDown,
		// Token: 0x0402E4AD RID: 189613
		ItemSlider,
		// Token: 0x0402E4AE RID: 189614
		ItemScroll
	}
}
