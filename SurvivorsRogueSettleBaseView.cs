using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B81 RID: 11137
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueSettleBaseView : UiViewBase
{
	// Token: 0x060162C1 RID: 90817 RVA: 0x00627037 File Offset: 0x00625237
	public SurvivorsRogueSettleBaseView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060162C2 RID: 90818 RVA: 0x0062704C File Offset: 0x0062524C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(18, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(17, new Action(this.OnClickBtnReturn)),
			new ValueTuple<int, Delegate>(18, new Action(this.OnClickBtnReturnMain))
		};
	}

	// Token: 0x060162C3 RID: 90819 RVA: 0x00627250 File Offset: 0x00625450
	protected void SetBtnReturnMainVisible(bool bVisible)
	{
		base.GetButton(18).RootUIComp.Get().SetUIActive(bVisible);
	}

	// Token: 0x060162C4 RID: 90820 RVA: 0x00627278 File Offset: 0x00625478
	protected virtual void OnClickBtnReturn()
	{
	}

	// Token: 0x060162C5 RID: 90821 RVA: 0x0062727A File Offset: 0x0062547A
	protected virtual void OnClickBtnReturnMain()
	{
	}

	// Token: 0x060162C6 RID: 90822 RVA: 0x0062727C File Offset: 0x0062547C
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueSettleBaseView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueSettleBaseView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060162C7 RID: 90823 RVA: 0x006272BF File Offset: 0x006254BF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x060162C8 RID: 90824 RVA: 0x006272DD File Offset: 0x006254DD
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x060162C9 RID: 90825 RVA: 0x006272FC File Offset: 0x006254FC
	protected override void OnAfterShow()
	{
		foreach (SurvivorsRogueWeaponSettleItem survivorsRogueWeaponSettleItem in this.WeaponList.GetLayoutItemList())
		{
			survivorsRogueWeaponSettleItem.PlayAnim();
		}
	}

	// Token: 0x060162CA RID: 90826 RVA: 0x00627354 File Offset: 0x00625554
	protected override void OnBeforeDestroyImplement()
	{
		this.ScrollingNumberTool.Clear();
	}

	// Token: 0x060162CB RID: 90827 RVA: 0x00627361 File Offset: 0x00625561
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "InturnAni")
		{
			UUIInturnAnimController uiAnimController = this.WeaponList.GetUiAnimController();
			if (uiAnimController != null)
			{
				uiAnimController.Play("", -1, false);
			}
			this.ScrollingNumberTool.StartScrolling();
		}
	}

	// Token: 0x060162CC RID: 90828 RVA: 0x00627398 File Offset: 0x00625598
	private SurvivorsRogueWeaponSettleItem CreateWeaponInfo()
	{
		return new SurvivorsRogueWeaponSettleItem();
	}

	// Token: 0x060162CD RID: 90829 RVA: 0x0062739F File Offset: 0x0062559F
	[NullableContext(2)]
	protected virtual ResultView GetViewInfo()
	{
		return null;
	}

	// Token: 0x060162CE RID: 90830 RVA: 0x006273A4 File Offset: 0x006255A4
	private List<ISurvivorsWeaponGridData> GetAllWeaponGridData(IList<Aki.Protocol.SurvivorsGainData> dataList, int weaponMaxCount)
	{
		List<SurvivorsWeaponGainData> list = new List<SurvivorsWeaponGainData>();
		foreach (Aki.Protocol.SurvivorsGainData survivorsGainData in dataList)
		{
			Aki.Protocol.SurvivorsGainData survivorsGainData2 = survivorsGainData;
			if (survivorsGainData2.DataCase.ToString() == "Proto_SurvivorsWeapon")
			{
				SurvivorsWeaponGainData item = new SurvivorsWeaponGainData(survivorsGainData.IncId, survivorsGainData.ConfigId, survivorsGainData2.SurvivorsWeapon, ESurvivorsRogueItemType.Weapon);
				list.Add(item);
			}
		}
		List<ISurvivorsWeaponWithBondInfo> weaponGainListWithBondInfo = ModelBase<SurvivorsRogueModel>.Instance.GainData.GetWeaponGainListWithBondInfo(list);
		return ModelBase<SurvivorsRogueModel>.Instance.GainData.GetWeaponGridDataList(weaponGainListWithBondInfo, new int?(weaponMaxCount));
	}

	// Token: 0x060162CF RID: 90831 RVA: 0x0062745C File Offset: 0x0062565C
	protected UniTask RefreshAsync()
	{
		SurvivorsRogueSettleBaseView.<RefreshAsync>d__19 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<SurvivorsRogueSettleBaseView.<RefreshAsync>d__19>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400ABA1 RID: 43937
	private const string ENDLESS_NO_ACHIEVED_ICON = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Settlement/SP_SurvivorSettlementIconWuJin01.SP_SurvivorSettlementIconWuJin01";

	// Token: 0x0400ABA2 RID: 43938
	private const string ENDLESS_ACHIEVED_ICON = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity27/Survivor/Settlement/SP_SurvivorSettlementIconWuJin02.SP_SurvivorSettlementIconWuJin02";

	// Token: 0x0400ABA3 RID: 43939
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SurvivorsRogueWeaponSettleItem, ISurvivorsWeaponGridData> WeaponList;

	// Token: 0x0400ABA4 RID: 43940
	[Nullable(2)]
	private SurvivorsRogueRoleInfoItem RoleInfo;

	// Token: 0x0400ABA5 RID: 43941
	private readonly ScrollingNumberTool ScrollingNumberTool = new ScrollingNumberTool();
}
