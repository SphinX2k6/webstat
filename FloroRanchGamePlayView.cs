using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C31 RID: 7217
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchGamePlayView : UiViewBase
{
	// Token: 0x0600D1F1 RID: 53745 RVA: 0x0037C14B File Offset: 0x0037A34B
	public FloroRanchGamePlayView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D1F2 RID: 53746 RVA: 0x0037C180 File Offset: 0x0037A380
	protected unsafe override void OnRegisterComponent()
	{
		int num = 61;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(52, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(51, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(54, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(40, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(41, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(42, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(43, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(44, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(45, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(46, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(47, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(48, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(49, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(50, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(53, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(55, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(56, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(57, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(58, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(59, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(60, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 11;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBackButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickSpeedChangeButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickHelpButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(20, new Action(this.OnClickUseSkillButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(17, new Action(this.OnClickNewDayButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(54, new Action(this.OnClickLastDayDetailButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(49, new Action(this.HideTips));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(55, new Action(this.OnClickLevelDetailButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickShowButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(56, new Action(this.OnClickDebugButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(59, new Action(this.OnClickCardCountButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D1F3 RID: 53747 RVA: 0x0037CB5C File Offset: 0x0037AD5C
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchGamePlayView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchGamePlayView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1F4 RID: 53748 RVA: 0x0037CBA0 File Offset: 0x0037ADA0
	protected override void OnBeforeShow()
	{
		this.SetNewDayButtonActive(false);
		this.SetMaskPanelActive(false);
		this.SetShowButtonActive(false);
		this.RefreshCurrencyInfo();
		this.RefreshStageInfo();
		base.GetSpine(18).SetAnimation(0, "idle", true);
		base.GetItem(45).SetUIActive(false);
		base.GetItem(47).SetUIActive(false);
		foreach (FloroRanchEntityBase floroRanchEntityBase in ModelBase<FloroRanchGamePlayModel>.Instance.GetShowTerrainEntityList())
		{
			floroRanchEntityBase.GetUiItemComponent().PlayShowAnim();
		}
		foreach (FloroRanchEntityBase floroRanchEntityBase2 in ModelBase<FloroRanchGamePlayModel>.Instance.GetShowToyEntityList())
		{
			floroRanchEntityBase2.GetUiItemComponent().PlayShowAnim();
		}
		ModelBase<FloroRanchGamePlayModel>.Instance.RoleEntity.GetUiItemComponent().PlayShowAnim();
	}

	// Token: 0x0600D1F5 RID: 53749 RVA: 0x0037CCAC File Offset: 0x0037AEAC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFloroRanchStageInfoRefresh, new Action(this.OnFloroRanchBasicInfoRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFloroRanchCardEntityCountChange, new Action(this.OnFloroRanchCardEntityCountChange));
	}

	// Token: 0x0600D1F6 RID: 53750 RVA: 0x0037CCE6 File Offset: 0x0037AEE6
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFloroRanchStageInfoRefresh, new Action(this.OnFloroRanchBasicInfoRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFloroRanchCardEntityCountChange, new Action(this.OnFloroRanchCardEntityCountChange));
	}

	// Token: 0x0600D1F7 RID: 53751 RVA: 0x0037CD20 File Offset: 0x0037AF20
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<FloroRanchUiTerrainItem> BindTerrainItem(FloroRanchEntityBase terrainEntity)
	{
		FloroRanchGamePlayView.<BindTerrainItem>d__29 <BindTerrainItem>d__;
		<BindTerrainItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiTerrainItem>.Create();
		<BindTerrainItem>d__.<>4__this = this;
		<BindTerrainItem>d__.terrainEntity = terrainEntity;
		<BindTerrainItem>d__.<>1__state = -1;
		<BindTerrainItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<BindTerrainItem>d__29>(ref <BindTerrainItem>d__);
		return <BindTerrainItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1F8 RID: 53752 RVA: 0x0037CD6C File Offset: 0x0037AF6C
	private UniTask CreateTerrainItem(int point)
	{
		FloroRanchGamePlayView.<CreateTerrainItem>d__30 <CreateTerrainItem>d__;
		<CreateTerrainItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateTerrainItem>d__.<>4__this = this;
		<CreateTerrainItem>d__.point = point;
		<CreateTerrainItem>d__.<>1__state = -1;
		<CreateTerrainItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<CreateTerrainItem>d__30>(ref <CreateTerrainItem>d__);
		return <CreateTerrainItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1F9 RID: 53753 RVA: 0x0037CDB8 File Offset: 0x0037AFB8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<FloroRanchUiToyItem> BindToyItem(FloroRanchEntityBase toyEntity)
	{
		FloroRanchGamePlayView.<BindToyItem>d__31 <BindToyItem>d__;
		<BindToyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiToyItem>.Create();
		<BindToyItem>d__.<>4__this = this;
		<BindToyItem>d__.toyEntity = toyEntity;
		<BindToyItem>d__.<>1__state = -1;
		<BindToyItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<BindToyItem>d__31>(ref <BindToyItem>d__);
		return <BindToyItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1FA RID: 53754 RVA: 0x0037CE04 File Offset: 0x0037B004
	private UniTask CreateToyItem(int point)
	{
		FloroRanchGamePlayView.<CreateToyItem>d__32 <CreateToyItem>d__;
		<CreateToyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateToyItem>d__.<>4__this = this;
		<CreateToyItem>d__.point = point;
		<CreateToyItem>d__.<>1__state = -1;
		<CreateToyItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<CreateToyItem>d__32>(ref <CreateToyItem>d__);
		return <CreateToyItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1FB RID: 53755 RVA: 0x0037CE50 File Offset: 0x0037B050
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<FloroRanchUiCardItem> BindSpineItem(FloroRanchEntityBase cardEntity)
	{
		FloroRanchGamePlayView.<BindSpineItem>d__33 <BindSpineItem>d__;
		<BindSpineItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiCardItem>.Create();
		<BindSpineItem>d__.<>4__this = this;
		<BindSpineItem>d__.cardEntity = cardEntity;
		<BindSpineItem>d__.<>1__state = -1;
		<BindSpineItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<BindSpineItem>d__33>(ref <BindSpineItem>d__);
		return <BindSpineItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1FC RID: 53756 RVA: 0x0037CE9C File Offset: 0x0037B09C
	private UniTask CreateSpineItem(int point)
	{
		FloroRanchGamePlayView.<CreateSpineItem>d__34 <CreateSpineItem>d__;
		<CreateSpineItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateSpineItem>d__.<>4__this = this;
		<CreateSpineItem>d__.point = point;
		<CreateSpineItem>d__.<>1__state = -1;
		<CreateSpineItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<CreateSpineItem>d__34>(ref <CreateSpineItem>d__);
		return <CreateSpineItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1FD RID: 53757 RVA: 0x0037CEE8 File Offset: 0x0037B0E8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<FloroRanchUiRoleSkillItem> BindRoleSkillItem(FloroRanchEntityBase skillEntity)
	{
		FloroRanchGamePlayView.<BindRoleSkillItem>d__35 <BindRoleSkillItem>d__;
		<BindRoleSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiRoleSkillItem>.Create();
		<BindRoleSkillItem>d__.<>4__this = this;
		<BindRoleSkillItem>d__.skillEntity = skillEntity;
		<BindRoleSkillItem>d__.<>1__state = -1;
		<BindRoleSkillItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<BindRoleSkillItem>d__35>(ref <BindRoleSkillItem>d__);
		return <BindRoleSkillItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1FE RID: 53758 RVA: 0x0037CF34 File Offset: 0x0037B134
	private UniTask CreateRoleSkillItem()
	{
		FloroRanchGamePlayView.<CreateRoleSkillItem>d__36 <CreateRoleSkillItem>d__;
		<CreateRoleSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRoleSkillItem>d__.<>4__this = this;
		<CreateRoleSkillItem>d__.<>1__state = -1;
		<CreateRoleSkillItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<CreateRoleSkillItem>d__36>(ref <CreateRoleSkillItem>d__);
		return <CreateRoleSkillItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1FF RID: 53759 RVA: 0x0037CF78 File Offset: 0x0037B178
	private UniTask InitRightInfoTipItem()
	{
		FloroRanchGamePlayView.<InitRightInfoTipItem>d__37 <InitRightInfoTipItem>d__;
		<InitRightInfoTipItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRightInfoTipItem>d__.<>4__this = this;
		<InitRightInfoTipItem>d__.<>1__state = -1;
		<InitRightInfoTipItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<InitRightInfoTipItem>d__37>(ref <InitRightInfoTipItem>d__);
		return <InitRightInfoTipItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D200 RID: 53760 RVA: 0x0037CFBC File Offset: 0x0037B1BC
	private UniTask InitPopupRewardPanel()
	{
		FloroRanchGamePlayView.<InitPopupRewardPanel>d__38 <InitPopupRewardPanel>d__;
		<InitPopupRewardPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPopupRewardPanel>d__.<>4__this = this;
		<InitPopupRewardPanel>d__.<>1__state = -1;
		<InitPopupRewardPanel>d__.<>t__builder.Start<FloroRanchGamePlayView.<InitPopupRewardPanel>d__38>(ref <InitPopupRewardPanel>d__);
		return <InitPopupRewardPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600D201 RID: 53761 RVA: 0x0037D000 File Offset: 0x0037B200
	private void InitSpeedInfo()
	{
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		this.SpeedList = (ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData().GetFloroRanchSubDungeonData(subInstanceId).IsEndlessMode ? FloroRanchDefine.FloroRanchEndlessSpeedList : FloroRanchDefine.FloroRanchSpeedList);
		int num = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.FloroRanchSpeed, 1);
		if (num != 0)
		{
			this.CurSpeedIndex = this.SpeedList.IndexOf(num);
			if (this.CurSpeedIndex == -1)
			{
				this.CurSpeedIndex = this.SpeedList.Count - 1;
			}
		}
		num = this.SpeedList[this.CurSpeedIndex];
		LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.FloroRanchSpeed, num);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.LRC;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
		defaultInterpolatedStringHandler.AppendLiteral("speed: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		defaultInterpolatedStringHandler.AppendLiteral(", CurSpeedIndex: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurSpeedIndex);
		instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		ModelBase<FloroRanchGamePlayModel>.Instance.SetTimeDilation(num);
		if (num == 50)
		{
			base.GetText(2).SetText("MAX", true);
		}
		else
		{
			base.GetText(2).SetText("×" + num.ToString("F1"), true);
		}
		base.GetSprite(4).SetUIActive(this.CurSpeedIndex != 0);
	}

	// Token: 0x0600D202 RID: 53762 RVA: 0x0037D154 File Offset: 0x0037B354
	private UniTask InitDayProgressItem()
	{
		FloroRanchGamePlayView.<InitDayProgressItem>d__40 <InitDayProgressItem>d__;
		<InitDayProgressItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDayProgressItem>d__.<>4__this = this;
		<InitDayProgressItem>d__.<>1__state = -1;
		<InitDayProgressItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<InitDayProgressItem>d__40>(ref <InitDayProgressItem>d__);
		return <InitDayProgressItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D203 RID: 53763 RVA: 0x0037D198 File Offset: 0x0037B398
	private UniTask InitEndlessDayProgressItem()
	{
		FloroRanchGamePlayView.<InitEndlessDayProgressItem>d__41 <InitEndlessDayProgressItem>d__;
		<InitEndlessDayProgressItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitEndlessDayProgressItem>d__.<>4__this = this;
		<InitEndlessDayProgressItem>d__.<>1__state = -1;
		<InitEndlessDayProgressItem>d__.<>t__builder.Start<FloroRanchGamePlayView.<InitEndlessDayProgressItem>d__41>(ref <InitEndlessDayProgressItem>d__);
		return <InitEndlessDayProgressItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D204 RID: 53764 RVA: 0x0037D1DC File Offset: 0x0037B3DC
	private UniTask InitCurve()
	{
		FloroRanchGamePlayView.<InitCurve>d__42 <InitCurve>d__;
		<InitCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCurve>d__.<>4__this = this;
		<InitCurve>d__.<>1__state = -1;
		<InitCurve>d__.<>t__builder.Start<FloroRanchGamePlayView.<InitCurve>d__42>(ref <InitCurve>d__);
		return <InitCurve>d__.<>t__builder.Task;
	}

	// Token: 0x0600D205 RID: 53765 RVA: 0x0037D220 File Offset: 0x0037B420
	public void RefreshCurrencyInfo()
	{
		FloroRanchCurrencyData coinData = ModelBase<FloroRanchGamePlayModel>.Instance.CoinData;
		FloroRanchCurrencyData diamondData = ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData;
		int amount = coinData.GetAmount();
		int stageTarget = ModelBase<FloroRanchGamePlayModel>.Instance.StageTarget;
		base.GetText(12).SetText(ModelBase<FloroRanchModel>.Instance.GetCoinText(amount) + "/" + ModelBase<FloroRanchModel>.Instance.GetCoinText(stageTarget), true);
		base.GetTexture(14).SetFillAmount((float)amount * 1f / (float)stageTarget);
		this.ItemCost.SetCurrencyData(diamondData);
		int lastDayIncome = ModelBase<FloroRanchGamePlayModel>.Instance.GetLastDayIncome();
		base.GetText(52).SetText(ModelBase<FloroRanchModel>.Instance.GetCoinText(lastDayIncome), true);
		base.SetTextureByPath(coinData.ConfigData.GetSmallIcon(), base.GetTexture(51), null, null);
		base.SetTextureByPath(coinData.ConfigData.GetSmallIcon(), base.GetTexture(13), null, null);
	}

	// Token: 0x0600D206 RID: 53766 RVA: 0x0037D318 File Offset: 0x0037B518
	private void RefreshStageInfo()
	{
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		FloroRanchSubDungeonData floroRanchSubDungeonData = this.ActivityData.GetFloroRanchSubDungeonData(subInstanceId);
		FloroRanchDungeonData floroRanchDungeonData = this.ActivityData.GetFloroRanchDungeonData(floroRanchSubDungeonData.InstanceId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), floroRanchDungeonData.GetDungeonName(), Array.Empty<object>());
		int curStage = ModelBase<FloroRanchGamePlayModel>.Instance.CurStage;
		bool isEndlessMode = ModelBase<FloroRanchGamePlayModel>.Instance.IsEndlessMode;
		if (isEndlessMode)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Farm_Stage1", new <>z__ReadOnlySingleElementList<object>(curStage));
		}
		else
		{
			int maxStage = floroRanchSubDungeonData.GetMaxStage();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Farm_Stage2", new <>z__ReadOnlyArray<object>(new object[]
			{
				curStage,
				maxStage
			}));
		}
		this.EndlessDayProgressItem.SetUiActive(isEndlessMode);
		this.DayProgressItem.SetUiActive(!isEndlessMode);
		int remindDay = ModelBase<FloroRanchGamePlayModel>.Instance.RemindDay;
		int stageDayCount = ModelBase<FloroRanchGamePlayModel>.Instance.StageDayCount;
		if (isEndlessMode)
		{
			this.EndlessDayProgressItem.RefreshDay(remindDay, (long)stageDayCount);
		}
		else
		{
			this.DayProgressItem.RefreshDay(remindDay, (long)stageDayCount);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Farm_DaySum", new <>z__ReadOnlySingleElementList<object>(ModelBase<FloroRanchGamePlayModel>.Instance.TotalDayCount));
		this.SetCardNumText();
	}

	// Token: 0x0600D207 RID: 53767 RVA: 0x0037D474 File Offset: 0x0037B674
	private void OnBindEntityChanged(int point)
	{
		FloroRanchUiTerrainItem floroRanchUiTerrainItem = this.TerrainItemMap[point];
		bool flag = ((floroRanchUiTerrainItem != null) ? floroRanchUiTerrainItem.GetEntity() : null) != null;
		FloroRanchUiCardItem floroRanchUiCardItem = this.CardItemMap[point];
		FloroRanchEntityBase floroRanchEntityBase = (floroRanchUiCardItem != null) ? floroRanchUiCardItem.GetEntity() : null;
		bool flag2 = !flag && floroRanchEntityBase == null;
		FloroRanchUiTerrainItem floroRanchUiTerrainItem2 = this.TerrainItemMap[point];
		if (floroRanchUiTerrainItem2 == null)
		{
			return;
		}
		floroRanchUiTerrainItem2.SetInteractive(!flag2);
	}

	// Token: 0x0600D208 RID: 53768 RVA: 0x0037D4D8 File Offset: 0x0037B6D8
	public void SetNewDayButtonActive(bool bActive)
	{
		UUIButtonComponent button = base.GetButton(17);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(bActive);
	}

	// Token: 0x0600D209 RID: 53769 RVA: 0x0037D508 File Offset: 0x0037B708
	public void SetShowButtonActive(bool bActive)
	{
		UUIButtonComponent button = base.GetButton(6);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(bActive);
	}

	// Token: 0x0600D20A RID: 53770 RVA: 0x0037D534 File Offset: 0x0037B734
	public void SetMaskPanelActive(bool bActive)
	{
		UUIItem item = base.GetItem(50);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bActive);
	}

	// Token: 0x0600D20B RID: 53771 RVA: 0x0037D549 File Offset: 0x0037B749
	public void SetToyPanelActive(bool bActive)
	{
		UUIItem item = base.GetItem(21);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bActive);
	}

	// Token: 0x0600D20C RID: 53772 RVA: 0x0037D560 File Offset: 0x0037B760
	public UniTask PlayNewDayAnim()
	{
		FloroRanchGamePlayView.<PlayNewDayAnim>d__50 <PlayNewDayAnim>d__;
		<PlayNewDayAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayNewDayAnim>d__.<>4__this = this;
		<PlayNewDayAnim>d__.<>1__state = -1;
		<PlayNewDayAnim>d__.<>t__builder.Start<FloroRanchGamePlayView.<PlayNewDayAnim>d__50>(ref <PlayNewDayAnim>d__);
		return <PlayNewDayAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D20D RID: 53773 RVA: 0x0037D5A4 File Offset: 0x0037B7A4
	private void OnRemoveEntity(FloroRanchEntityBase entity)
	{
		EFloroRanchEntityType entityType = entity.EntityType;
		int point = entity.CheckGetComponent<FloroRanchEntityDataComponent>().Point;
		if (entityType == EFloroRanchEntityType.Card)
		{
			FloroRanchEntityBase terrainEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetTerrainEntityByPoint(point);
			this.ChangeTerrainSelectTipByEntity(null, terrainEntityByPoint);
		}
		else if (entityType == EFloroRanchEntityType.Toy)
		{
			this.ChangeToySelectTipByEntity(null);
		}
		this.RefreshCurrencyInfo();
	}

	// Token: 0x0600D20E RID: 53774 RVA: 0x0037D5EF File Offset: 0x0037B7EF
	[NullableContext(2)]
	private void ChangeTerrainSelectTipByEntity(FloroRanchEntityBase mainEntity, FloroRanchEntityBase subEntity)
	{
		this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.Terrain, mainEntity, subEntity);
		this.ShowTips();
	}

	// Token: 0x0600D20F RID: 53775 RVA: 0x0037D608 File Offset: 0x0037B808
	private void ChangeTerrainSelectTip(int point)
	{
		FloroRanchEntityBase terrainEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetTerrainEntityByPoint(point);
		FloroRanchEntityBase cardEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetCardEntityByPoint(point);
		this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.Terrain, cardEntityByPoint, terrainEntityByPoint);
		this.ShowTips();
	}

	// Token: 0x0600D210 RID: 53776 RVA: 0x0037D641 File Offset: 0x0037B841
	[NullableContext(2)]
	private void ChangeToySelectTipByEntity(FloroRanchEntityBase mainEntity)
	{
		this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.Toy, mainEntity, null);
		this.ShowTips();
	}

	// Token: 0x0600D211 RID: 53777 RVA: 0x0037D658 File Offset: 0x0037B858
	private void ChangeToySelectTip(int point)
	{
		FloroRanchEntityBase toyEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetToyEntityByPoint(point);
		this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.Toy, toyEntityByPoint, null);
		this.ShowTips();
	}

	// Token: 0x0600D212 RID: 53778 RVA: 0x0037D688 File Offset: 0x0037B888
	private void ChangeCardItemSelectState(int point)
	{
		FloroRanchEntityBase cardEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetCardEntityByPoint(point);
		if (cardEntityByPoint == null)
		{
			this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.None, null, null);
		}
		else
		{
			this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.Terrain, cardEntityByPoint, null);
		}
		this.ChangeItemSelectState();
	}

	// Token: 0x0600D213 RID: 53779 RVA: 0x0037D6C8 File Offset: 0x0037B8C8
	private void ShowTips()
	{
		FloroRanchEntityBase lastMainEntityData = this.SelectTipData.LastMainEntityData;
		FloroRanchEntityBase lastSubEntityData = this.SelectTipData.LastSubEntityData;
		bool mainEntityData = this.SelectTipData.MainEntityData != null;
		FloroRanchEntityBase subEntityData = this.SelectTipData.SubEntityData;
		bool lastTipType = this.SelectTipData.LastTipType != EFloroRanchTipType.None;
		EFloroRanchTipType tipType = this.SelectTipData.TipType;
		bool playAnim = !lastTipType || tipType == EFloroRanchTipType.None;
		if (mainEntityData)
		{
			this.ShowMainTip(playAnim);
		}
		else if (lastMainEntityData != null)
		{
			this.HideMainTip(playAnim);
		}
		if (subEntityData != null)
		{
			this.ShowSubTip(playAnim);
		}
		else if (lastSubEntityData != null)
		{
			this.HideSubTip(playAnim);
		}
		this.ChangeItemSelectState();
	}

	// Token: 0x0600D214 RID: 53780 RVA: 0x0037D75B File Offset: 0x0037B95B
	private void HideTips()
	{
		this.SelectTipData.Clear();
		this.ShowTips();
		this.HideMaskButton();
	}

	// Token: 0x0600D215 RID: 53781 RVA: 0x0037D774 File Offset: 0x0037B974
	private void HideSubTip(bool playAnim = true)
	{
		this.SubTipLevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		if (!playAnim)
		{
			this.SubTipLevelSequencePlayer.EndSequenceLastFrame("Close");
			FloroRanchTerrainTipItem subTipInfoItem = this.SubTipInfoItem;
			if (subTipInfoItem == null)
			{
				return;
			}
			subTipInfoItem.SetUiActive(false);
		}
	}

	// Token: 0x0600D216 RID: 53782 RVA: 0x0037D7C0 File Offset: 0x0037B9C0
	private void HideMainTip(bool playAnim = true)
	{
		this.MainTipLevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		if (!playAnim)
		{
			this.MainTipLevelSequencePlayer.EndSequenceLastFrame("Close");
			FloroRanchCommonTipItem mainTipInfoItem = this.MainTipInfoItem;
			if (mainTipInfoItem == null)
			{
				return;
			}
			mainTipInfoItem.SetUiActive(false);
		}
	}

	// Token: 0x0600D217 RID: 53783 RVA: 0x0037D80C File Offset: 0x0037BA0C
	private void ShowSubTip(bool playAnim = true)
	{
		FloroRanchEntityBase subEntityData = this.SelectTipData.SubEntityData;
		this.SubTipInfoItem.RefreshInfoTipByEntity(subEntityData);
		this.SetSubTipHeight((float)((this.SelectTipData.MainEntityData != null) ? 240 : 380));
		this.SubTipLevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		if (!playAnim)
		{
			this.SubTipLevelSequencePlayer.EndSequenceLastFrame("Start");
		}
		this.ShowMaskButton();
	}

	// Token: 0x0600D218 RID: 53784 RVA: 0x0037D88C File Offset: 0x0037BA8C
	private void ShowMainTip(bool playAnim = true)
	{
		FloroRanchEntityBase mainEntityData = this.SelectTipData.MainEntityData;
		FloroRanchCommonTipItem mainTipInfoItem = this.MainTipInfoItem;
		if (mainTipInfoItem != null)
		{
			mainTipInfoItem.RefreshInfoTipByParam(new FloroRanchCommonTipParam
			{
				TipType = EFloroRanchCommonTipType.Entity,
				EntityData = mainEntityData,
				RemoveCallback = new Action<FloroRanchEntityBase>(this.OnRemoveEntity),
				CurrencyData = null
			});
		}
		this.MainTipLevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		if (!playAnim)
		{
			this.MainTipLevelSequencePlayer.EndSequenceLastFrame("Start");
		}
		this.ShowMaskButton();
	}

	// Token: 0x0600D219 RID: 53785 RVA: 0x0037D918 File Offset: 0x0037BB18
	private void SetSubTipHeight(float height)
	{
		FloroRanchTerrainTipItem subTipInfoItem = this.SubTipInfoItem;
		UUIItem uuiitem = (subTipInfoItem != null) ? subTipInfoItem.GetRootItem() : null;
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetHeight(height);
	}

	// Token: 0x0600D21A RID: 53786 RVA: 0x0037D943 File Offset: 0x0037BB43
	private void MainTipSequenceFinishEvent(string sequenceName)
	{
		if (sequenceName == "Close")
		{
			FloroRanchCommonTipItem mainTipInfoItem = this.MainTipInfoItem;
			if (mainTipInfoItem == null)
			{
				return;
			}
			mainTipInfoItem.SetUiActive(false);
		}
	}

	// Token: 0x0600D21B RID: 53787 RVA: 0x0037D963 File Offset: 0x0037BB63
	private void SubTipSequenceFinishEvent(string sequenceName)
	{
		if (sequenceName == "Close")
		{
			FloroRanchTerrainTipItem subTipInfoItem = this.SubTipInfoItem;
			if (subTipInfoItem == null)
			{
				return;
			}
			subTipInfoItem.SetUiActive(false);
		}
	}

	// Token: 0x0600D21C RID: 53788 RVA: 0x0037D984 File Offset: 0x0037BB84
	private void ChangeItemSelectState()
	{
		this.SetItemSelectState(this.SelectTipData.LastTipType, this.SelectTipData.LastMainEntityData, this.SelectTipData.LastSubEntityData, false);
		this.SetItemSelectState(this.SelectTipData.TipType, this.SelectTipData.MainEntityData, this.SelectTipData.SubEntityData, true);
	}

	// Token: 0x0600D21D RID: 53789 RVA: 0x0037D9E4 File Offset: 0x0037BBE4
	[NullableContext(2)]
	private void SetItemSelectState(EFloroRanchTipType tipType, FloroRanchEntityBase mainEntityData, FloroRanchEntityBase subEntityData, bool isSelect)
	{
		if (tipType == EFloroRanchTipType.Terrain)
		{
			int key = -1;
			if (mainEntityData != null)
			{
				key = mainEntityData.GetPoint();
			}
			else if (subEntityData != null)
			{
				key = subEntityData.GetPoint();
			}
			FloroRanchUiTerrainItem floroRanchUiTerrainItem;
			if (this.TerrainItemMap.TryGetValue(key, out floroRanchUiTerrainItem))
			{
				floroRanchUiTerrainItem.SetSelectState(isSelect);
			}
		}
		if (tipType == EFloroRanchTipType.Toy)
		{
			int key2 = (mainEntityData != null) ? mainEntityData.GetPoint() : -1;
			FloroRanchUiToyItem floroRanchUiToyItem;
			if (this.ToyItemMap.TryGetValue(key2, out floroRanchUiToyItem))
			{
				floroRanchUiToyItem.SetSelectState(isSelect);
			}
		}
	}

	// Token: 0x0600D21E RID: 53790 RVA: 0x0037DA50 File Offset: 0x0037BC50
	private void ShowMaskButton()
	{
		base.GetButton(49).RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x0600D21F RID: 53791 RVA: 0x0037DA78 File Offset: 0x0037BC78
	private void HideMaskButton()
	{
		base.GetButton(49).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600D220 RID: 53792 RVA: 0x0037DAA0 File Offset: 0x0037BCA0
	public UniTask ShowPopupReward(FloroRanchUiItemBase item, EFloroRanchPopupRewardType rewardType, long count)
	{
		FloroRanchGamePlayView.<ShowPopupReward>d__70 <ShowPopupReward>d__;
		<ShowPopupReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowPopupReward>d__.<>4__this = this;
		<ShowPopupReward>d__.item = item;
		<ShowPopupReward>d__.rewardType = rewardType;
		<ShowPopupReward>d__.count = count;
		<ShowPopupReward>d__.<>1__state = -1;
		<ShowPopupReward>d__.<>t__builder.Start<FloroRanchGamePlayView.<ShowPopupReward>d__70>(ref <ShowPopupReward>d__);
		return <ShowPopupReward>d__.<>t__builder.Task;
	}

	// Token: 0x0600D221 RID: 53793 RVA: 0x0037DAFB File Offset: 0x0037BCFB
	protected override void OnBeforeDestroy()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.SetTimeDilation(1);
		if (!ModelBase<FloroRanchGamePlayModel>.Instance.IsExit)
		{
			ModelBase<FloroRanchGamePlayModel>.Instance.ExitGame(false);
		}
	}

	// Token: 0x0600D222 RID: 53794 RVA: 0x0037DB20 File Offset: 0x0037BD20
	private void OnCoinChangeCallBack(long _)
	{
		this.RefreshCurrencyInfo();
		LevelSequencePlayer progressLevelSequencePlayer = this.ProgressLevelSequencePlayer;
		if (((progressLevelSequencePlayer != null) ? progressLevelSequencePlayer.GetCurrentSequence() : null) == "Hit")
		{
			LevelSequencePlayer progressLevelSequencePlayer2 = this.ProgressLevelSequencePlayer;
			if (progressLevelSequencePlayer2 == null)
			{
				return;
			}
			progressLevelSequencePlayer2.ReplaySequenceByKey("Hit");
			return;
		}
		else
		{
			LevelSequencePlayer progressLevelSequencePlayer3 = this.ProgressLevelSequencePlayer;
			if (progressLevelSequencePlayer3 == null)
			{
				return;
			}
			progressLevelSequencePlayer3.PlayLevelSequenceByName("Hit", false, null, false);
			return;
		}
	}

	// Token: 0x0600D223 RID: 53795 RVA: 0x0037DB87 File Offset: 0x0037BD87
	private void OnDiamondChangeCallBack(long _)
	{
		this.RefreshCurrencyInfo();
	}

	// Token: 0x0600D224 RID: 53796 RVA: 0x0037DB90 File Offset: 0x0037BD90
	public void PlayFloroAudio(EFloroRanchAudioType type)
	{
		if (this.EventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.EventHandle, EAudioActionType.Stop, null);
		}
		if (this.ChatPanelHideTimer != null && TimerSystem.GameplayTimeInstance.Has(this.ChatPanelHideTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.ChatPanelHideTimer);
			this.ChatPanelHideTimer = null;
		}
		FloroRanchAudioData floroRanchRandomAudioDataByType = ModelBase<FloroRanchModel>.Instance.GetFloroRanchRandomAudioDataByType(type, this.ActivityData.GetVoiceCharacterType());
		string audioText = floroRanchRandomAudioDataByType.GetAudioText();
		string audioEvent = floroRanchRandomAudioDataByType.GetAudioEvent();
		if (audioText == "")
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(48), audioText, Array.Empty<object>());
		base.GetItem(47).SetUIActive(true);
		if (audioEvent != "")
		{
			FTransformDouble? target = null;
			this.EventHandle = Singleton<AudioSystem>.Instance.PostEvent(audioEvent, target, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (callbackType == EAkCallbackType.EndOfEvent)
					{
						UUIItem item = base.GetItem(47);
						if (item == null)
						{
							return;
						}
						item.SetUIActive(false);
					}
				}
			}));
		}
		else
		{
			this.ChatPanelHideTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				UUIItem item = base.GetItem(47);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				this.ChatPanelHideTimer = null;
			}, 3000f, null, null, true, 1f);
		}
		if (type == EFloroRanchAudioType.Skill)
		{
			FloroRanchEntityBase roleEntity = ModelBase<FloroRanchGamePlayModel>.Instance.RoleEntity;
			if (roleEntity != null)
			{
				roleEntity.GetUiItemComponent().PlaySkillAnim();
			}
		}
	}

	// Token: 0x0600D225 RID: 53797 RVA: 0x0037DCEC File Offset: 0x0037BEEC
	private void SetCardNumText()
	{
		int ownCardEntityCount = ModelBase<FloroRanchGamePlayModel>.Instance.OwnCardEntityCount;
		string value = "#ffffff";
		if (ownCardEntityCount >= this.ActivityData.CardLimitCount)
		{
			value = "#ff5d5d";
		}
		else if (ownCardEntityCount >= 20)
		{
			value = "#fec455";
		}
		UUIText text = base.GetText(53);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
		defaultInterpolatedStringHandler.AppendLiteral("<color=");
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral(">");
		defaultInterpolatedStringHandler.AppendFormatted<int>(ownCardEntityCount);
		defaultInterpolatedStringHandler.AppendLiteral("</color>/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(20);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600D226 RID: 53798 RVA: 0x0037DD87 File Offset: 0x0037BF87
	private void OnClickToyItem(int point)
	{
		this.ChangeToySelectTip(point);
	}

	// Token: 0x0600D227 RID: 53799 RVA: 0x0037DD90 File Offset: 0x0037BF90
	private void OnClickTerrainItem(int point)
	{
		this.ChangeTerrainSelectTip(point);
	}

	// Token: 0x0600D228 RID: 53800 RVA: 0x0037DD99 File Offset: 0x0037BF99
	private void OnClickUseSkillButton()
	{
		this.OnClickSkillButton(null);
	}

	// Token: 0x0600D229 RID: 53801 RVA: 0x0037DDA2 File Offset: 0x0037BFA2
	private void OnClickSkillButton(FloroRanchEntityBase entity)
	{
		if (!ModelBase<FloroRanchGamePlayModel>.Instance.CanFsmInsertSkillTask())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FloroRanchSkillCantUse", Array.Empty<object>());
			return;
		}
		this.HideTips();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchSkillTipView, entity, null);
	}

	// Token: 0x0600D22A RID: 53802 RVA: 0x0037DDDC File Offset: 0x0037BFDC
	private void OnClickNewDayButton()
	{
		if (!ModelBase<FloroRanchGamePlayModel>.Instance.CanFsmInsertSkillTask())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_NextDayLock", Array.Empty<object>());
			return;
		}
		this.HideTips();
		this.SetMaskPanelActive(true);
		this.SetNewDayButtonActive(false);
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchPlayNextDayRequest(this.ActivityData.Id, subInstanceId, delegate(FloroRanchPlayNextDayResponse response)
		{
			if (response != null)
			{
				this.RefreshCurrencyInfo();
				this.RefreshStageInfo();
			}
		});
	}

	// Token: 0x0600D22B RID: 53803 RVA: 0x0037DE4B File Offset: 0x0037C04B
	private void OnClickLastDayDetailButton()
	{
		this.HideTips();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchIncomeDetailView, new Action<int>(this.ChangeCardItemSelectState), null);
	}

	// Token: 0x0600D22C RID: 53804 RVA: 0x0037DE6F File Offset: 0x0037C06F
	private void OnClickLevelDetailButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchGamePlayExplainView, null, null);
	}

	// Token: 0x0600D22D RID: 53805 RVA: 0x0037DE82 File Offset: 0x0037C082
	private void OnClickShowButton()
	{
		this.HideTips();
		ModelBase<FloroRanchGamePlayModel>.Instance.ShowRecordView();
	}

	// Token: 0x0600D22E RID: 53806 RVA: 0x0037DE94 File Offset: 0x0037C094
	private void OnClickDebugButton()
	{
		if (this.DebugInfoPanel.IsShowOrShowing)
		{
			this.DebugInfoPanel.Hide(null);
			return;
		}
		this.DebugInfoPanel.Show(null);
	}

	// Token: 0x0600D22F RID: 53807 RVA: 0x0037DEBC File Offset: 0x0037C0BC
	private void OnClickCardCountButton()
	{
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_AnimalAllFull", Array.Empty<object>());
	}

	// Token: 0x0600D230 RID: 53808 RVA: 0x0037DED2 File Offset: 0x0037C0D2
	private void OnClickBackButton()
	{
		this.HideTips();
		ModelBase<FloroRanchGamePlayModel>.Instance.PauseGame();
		ModelBase<FloroRanchGamePlayModel>.Instance.OpenAndRecordView(EUiViewName.FloroRanchPauseView, null, null);
	}

	// Token: 0x0600D231 RID: 53809 RVA: 0x0037DEF8 File Offset: 0x0037C0F8
	private void OnClickSpeedChangeButton()
	{
		this.HideTips();
		this.CurSpeedIndex = (this.CurSpeedIndex + 1) % this.SpeedList.Count;
		int num = this.SpeedList[this.CurSpeedIndex];
		LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.FloroRanchSpeed, num);
		ModelBase<FloroRanchGamePlayModel>.Instance.SetTimeDilation(num);
		if (num >= 50)
		{
			base.GetText(2).SetText("MAX", true);
		}
		else
		{
			base.GetText(2).SetText("×" + num.ToString("F1"), true);
		}
		base.GetSprite(4).SetUIActive(this.CurSpeedIndex != 0);
	}

	// Token: 0x0600D232 RID: 53810 RVA: 0x0037DFA4 File Offset: 0x0037C1A4
	private void OnClickHelpButton()
	{
		this.HideTips();
		global::FloroRanchActivityData activityData = this.ActivityData;
		if (activityData != null && activityData.ActivityDataType == EFloroRanchActivityDataType.Weekly)
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(629);
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(354);
	}

	// Token: 0x0600D233 RID: 53811 RVA: 0x0037DFE2 File Offset: 0x0037C1E2
	private void OnFloroRanchBasicInfoRefresh()
	{
		this.RefreshCurrencyInfo();
		this.RefreshStageInfo();
	}

	// Token: 0x0600D234 RID: 53812 RVA: 0x0037DFF0 File Offset: 0x0037C1F0
	private void OnFloroRanchCardEntityCountChange()
	{
		this.SetCardNumText();
	}

	// Token: 0x0600D235 RID: 53813 RVA: 0x0037DFF8 File Offset: 0x0037C1F8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "FirstTerrainWithCard")
		{
			int i = 0;
			while (i < 20)
			{
				if (ModelBase<FloroRanchGamePlayModel>.Instance.GetCardEntityByPoint(i) != null)
				{
					FloroRanchUiTerrainItem valueOrDefault = this.TerrainItemMap.GetValueOrDefault(i);
					UUIItem uuiitem = (valueOrDefault != null) ? valueOrDefault.GetRootItem() : null;
					if (uuiitem == null)
					{
						return null;
					}
					return new UUIItem[]
					{
						uuiitem,
						uuiitem
					};
				}
				else
				{
					i++;
				}
			}
		}
		if (a == "Tips")
		{
			FloroRanchCommonTipItem mainTipInfoItem = this.MainTipInfoItem;
			UUIItem uuiitem2 = (mainTipInfoItem != null) ? mainTipInfoItem.GetRootItem() : null;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}
		else if (a == "RemoveBtn")
		{
			FloroRanchCommonTipItem mainTipInfoItem2 = this.MainTipInfoItem;
			UUIItem uuiitem3 = (mainTipInfoItem2 != null) ? mainTipInfoItem2.GetGuideUiItem("0") : null;
			if (uuiitem3 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem3,
				uuiitem3
			};
		}
		else
		{
			if (a == "FirstTerrainWithRedCard")
			{
				for (int j = 0; j < 20; j++)
				{
					FloroRanchEntityBase cardEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetCardEntityByPoint(j);
					if (cardEntityByPoint != null)
					{
						FloroRanchCardDataComponent floroRanchCardDataComponent = cardEntityByPoint.CheckGetComponent<FloroRanchCardDataComponent>();
						if (floroRanchCardDataComponent != null)
						{
							FloroRanchCardData cardData = floroRanchCardDataComponent.CardData;
							if (cardData != null && cardData.GetCardSpecialEffect() == EFloroRanchSpecialEffectType.Red)
							{
								FloroRanchUiTerrainItem valueOrDefault2 = this.TerrainItemMap.GetValueOrDefault(j);
								UUIItem uuiitem4 = (valueOrDefault2 != null) ? valueOrDefault2.GetRootItem() : null;
								if (uuiitem4 == null)
								{
									return null;
								}
								return new UUIItem[]
								{
									uuiitem4,
									uuiitem4
								};
							}
						}
					}
				}
			}
			if (!(a == "ToyItem"))
			{
				return null;
			}
			int key = int.Parse(configParams[1]);
			FloroRanchUiToyItem floroRanchUiToyItem;
			this.ToyItemMap.TryGetValue(key, out floroRanchUiToyItem);
			if (floroRanchUiToyItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				floroRanchUiToyItem.GetRootItem(),
				floroRanchUiToyItem.GetRootItem()
			};
		}
	}

	// Token: 0x0400641F RID: 25631
	private const int TERRAIN_ITEM_START_INDEX = 24;

	// Token: 0x04006420 RID: 25632
	private int CurSpeedIndex;

	// Token: 0x04006421 RID: 25633
	private List<int> SpeedList = new List<int>();

	// Token: 0x04006422 RID: 25634
	private UCurveFloat CardMoveCurve;

	// Token: 0x04006423 RID: 25635
	[Nullable(2)]
	private global::FloroRanchActivityData ActivityData;

	// Token: 0x04006424 RID: 25636
	private FloroRanchTipData SelectTipData;

	// Token: 0x04006425 RID: 25637
	[Nullable(2)]
	private FloroRanchCurrencyItem ItemCost;

	// Token: 0x04006426 RID: 25638
	[Nullable(2)]
	private FloroRanchDayProgressItem DayProgressItem;

	// Token: 0x04006427 RID: 25639
	[Nullable(2)]
	private FloroRanchDayProgressItem EndlessDayProgressItem;

	// Token: 0x04006428 RID: 25640
	[Nullable(2)]
	private FloroRanchCommonTipItem MainTipInfoItem;

	// Token: 0x04006429 RID: 25641
	[Nullable(2)]
	private FloroRanchTerrainTipItem SubTipInfoItem;

	// Token: 0x0400642A RID: 25642
	[Nullable(2)]
	private LevelSequencePlayer MainTipLevelSequencePlayer;

	// Token: 0x0400642B RID: 25643
	[Nullable(2)]
	private LevelSequencePlayer SubTipLevelSequencePlayer;

	// Token: 0x0400642C RID: 25644
	[Nullable(2)]
	private LevelSequencePlayer ProgressLevelSequencePlayer;

	// Token: 0x0400642D RID: 25645
	private int EventHandle;

	// Token: 0x0400642E RID: 25646
	[Nullable(2)]
	private TimerHandle ChatPanelHideTimer;

	// Token: 0x0400642F RID: 25647
	private readonly Dictionary<int, FloroRanchUiTerrainItem> TerrainItemMap = new Dictionary<int, FloroRanchUiTerrainItem>();

	// Token: 0x04006430 RID: 25648
	private readonly Dictionary<int, FloroRanchUiCardItem> CardItemMap = new Dictionary<int, FloroRanchUiCardItem>();

	// Token: 0x04006431 RID: 25649
	private readonly Dictionary<int, FloroRanchUiToyItem> ToyItemMap = new Dictionary<int, FloroRanchUiToyItem>();

	// Token: 0x04006432 RID: 25650
	[Nullable(2)]
	private FloroRanchPopupRewardPanel PopupRewardPanel;

	// Token: 0x04006433 RID: 25651
	[Nullable(2)]
	private FloroRanchUiRoleSkillItem RoleSkillItem;

	// Token: 0x04006434 RID: 25652
	[Nullable(2)]
	private FloroRanchDebugInfoPanel DebugInfoPanel;

	// Token: 0x02007F19 RID: 32537
	[NullableContext(0)]
	public class EComponentDefine
	{
		// Token: 0x0402B3EC RID: 177132
		public const int CloseButton = 0;

		// Token: 0x0402B3ED RID: 177133
		public const int ItemCost = 1;

		// Token: 0x0402B3EE RID: 177134
		public const int SpeedText = 2;

		// Token: 0x0402B3EF RID: 177135
		public const int SpeedChangeButton = 3;

		// Token: 0x0402B3F0 RID: 177136
		public const int SpeedSprite = 4;

		// Token: 0x0402B3F1 RID: 177137
		public const int HelpButton = 5;

		// Token: 0x0402B3F2 RID: 177138
		public const int ShowButton = 6;

		// Token: 0x0402B3F3 RID: 177139
		public const int RightInfoRoot = 7;

		// Token: 0x0402B3F4 RID: 177140
		public const int BasicInfoPanel = 8;

		// Token: 0x0402B3F5 RID: 177141
		public const int LevelNameText = 9;

		// Token: 0x0402B3F6 RID: 177142
		public const int StageText = 10;

		// Token: 0x0402B3F7 RID: 177143
		public const int DayText = 11;

		// Token: 0x0402B3F8 RID: 177144
		public const int TargetText = 12;

		// Token: 0x0402B3F9 RID: 177145
		public const int TargetIconTexture = 13;

		// Token: 0x0402B3FA RID: 177146
		public const int TargetProgressTexture = 14;

		// Token: 0x0402B3FB RID: 177147
		public const int TargetProgressItem = 15;

		// Token: 0x0402B3FC RID: 177148
		public const int DayProgressItem = 16;

		// Token: 0x0402B3FD RID: 177149
		public const int NewDayButton = 17;

		// Token: 0x0402B3FE RID: 177150
		public const int FloroSpine = 18;

		// Token: 0x0402B3FF RID: 177151
		public const int FloroPanel = 19;

		// Token: 0x0402B400 RID: 177152
		public const int UseSkillButton = 20;

		// Token: 0x0402B401 RID: 177153
		public const int ToyItemRoot = 21;

		// Token: 0x0402B402 RID: 177154
		public const int ToyItemTemplate = 22;

		// Token: 0x0402B403 RID: 177155
		public const int TerrainItemRoot = 23;

		// Token: 0x0402B404 RID: 177156
		public const int TerrainItem1 = 24;

		// Token: 0x0402B405 RID: 177157
		public const int TerrainItem2 = 25;

		// Token: 0x0402B406 RID: 177158
		public const int TerrainItem3 = 26;

		// Token: 0x0402B407 RID: 177159
		public const int TerrainItem4 = 27;

		// Token: 0x0402B408 RID: 177160
		public const int TerrainItem5 = 28;

		// Token: 0x0402B409 RID: 177161
		public const int TerrainItem6 = 29;

		// Token: 0x0402B40A RID: 177162
		public const int TerrainItem7 = 30;

		// Token: 0x0402B40B RID: 177163
		public const int TerrainItem8 = 31;

		// Token: 0x0402B40C RID: 177164
		public const int TerrainItem9 = 32;

		// Token: 0x0402B40D RID: 177165
		public const int TerrainItem10 = 33;

		// Token: 0x0402B40E RID: 177166
		public const int TerrainItem11 = 34;

		// Token: 0x0402B40F RID: 177167
		public const int TerrainItem12 = 35;

		// Token: 0x0402B410 RID: 177168
		public const int TerrainItem13 = 36;

		// Token: 0x0402B411 RID: 177169
		public const int TerrainItem14 = 37;

		// Token: 0x0402B412 RID: 177170
		public const int TerrainItem15 = 38;

		// Token: 0x0402B413 RID: 177171
		public const int TerrainItem16 = 39;

		// Token: 0x0402B414 RID: 177172
		public const int TerrainItem17 = 40;

		// Token: 0x0402B415 RID: 177173
		public const int TerrainItem18 = 41;

		// Token: 0x0402B416 RID: 177174
		public const int TerrainItem19 = 42;

		// Token: 0x0402B417 RID: 177175
		public const int TerrainItem20 = 43;

		// Token: 0x0402B418 RID: 177176
		public const int SpineRootItem = 44;

		// Token: 0x0402B419 RID: 177177
		public const int SpineItemTemplate = 45;

		// Token: 0x0402B41A RID: 177178
		public const int PopupRewardPanel = 46;

		// Token: 0x0402B41B RID: 177179
		public const int ChatPanel = 47;

		// Token: 0x0402B41C RID: 177180
		public const int ChatText = 48;

		// Token: 0x0402B41D RID: 177181
		public const int ClickMaskButton = 49;

		// Token: 0x0402B41E RID: 177182
		public const int MaskPanel = 50;

		// Token: 0x0402B41F RID: 177183
		public const int LastDayIncomeTexture = 51;

		// Token: 0x0402B420 RID: 177184
		public const int LastDayIncomeText = 52;

		// Token: 0x0402B421 RID: 177185
		public const int CardNumText = 53;

		// Token: 0x0402B422 RID: 177186
		public const int LastDayDetailButton = 54;

		// Token: 0x0402B423 RID: 177187
		public const int LevelDetailButton = 55;

		// Token: 0x0402B424 RID: 177188
		public const int DebugButton = 56;

		// Token: 0x0402B425 RID: 177189
		public const int RightDebugRoot = 57;

		// Token: 0x0402B426 RID: 177190
		public const int RightMaskTexture = 58;

		// Token: 0x0402B427 RID: 177191
		public const int CardCountButton = 59;

		// Token: 0x0402B428 RID: 177192
		public const int LeafItem = 60;
	}
}
