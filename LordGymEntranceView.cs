using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020021FB RID: 8699
[NullableContext(1)]
[Nullable(0)]
public class LordGymEntranceView : UiViewBase
{
	// Token: 0x0601068F RID: 67215 RVA: 0x0047BFB8 File Offset: 0x0047A1B8
	public LordGymEntranceView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010690 RID: 67216 RVA: 0x0047BFC4 File Offset: 0x0047A1C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(19, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIText)),
			new ValueTuple<int, Type>(23, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(24, typeof(UUIText)),
			new ValueTuple<int, Type>(25, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnClose)),
			new ValueTuple<int, Delegate>(10, new Action(this.OnClickBtnLord)),
			new ValueTuple<int, Delegate>(19, new Action(this.OnClickBtnBegin)),
			new ValueTuple<int, Delegate>(18, new Action(this.OnClickRecord)),
			new ValueTuple<int, Delegate>(23, new Action(this.OnClickShop))
		};
	}

	// Token: 0x06010691 RID: 67217 RVA: 0x0047C2B0 File Offset: 0x0047A4B0
	private UniTask InitScroll()
	{
		LordGymEntranceView.<InitScroll>d__11 <InitScroll>d__;
		<InitScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitScroll>d__.<>4__this = this;
		<InitScroll>d__.<>1__state = -1;
		<InitScroll>d__.<>t__builder.Start<LordGymEntranceView.<InitScroll>d__11>(ref <InitScroll>d__);
		return <InitScroll>d__.<>t__builder.Task;
	}

	// Token: 0x06010692 RID: 67218 RVA: 0x0047C2F4 File Offset: 0x0047A4F4
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymEntranceView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymEntranceView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010693 RID: 67219 RVA: 0x0047C337 File Offset: 0x0047A537
	protected override void OnAfterShow()
	{
		if (!ControllerBase<LordGymController>.Instance.IsInEntranceEntity())
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x06010694 RID: 67220 RVA: 0x0047C34C File Offset: 0x0047A54C
	protected override void OnStart()
	{
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(this.LordList[0]);
		if (lordGymConfig == null)
		{
			return;
		}
		int monsterId = lordGymConfig.Value.MonsterList(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceName(this.LordEntranceId) ?? "", Array.Empty<object>());
		string monsterBigIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterBigIcon(monsterId);
		base.SetTextureByPath(monsterBigIcon, base.GetTexture(9), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "SpecialRule", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "FirstPassReward", Array.Empty<object>());
		this.SetDefaultSelect();
	}

	// Token: 0x06010695 RID: 67221 RVA: 0x0047C420 File Offset: 0x0047A620
	private void SetDefaultSelect()
	{
		this.DefaultLord = this.LordList[0];
		foreach (int num in this.LordList)
		{
			if (ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(num) && ModelBase<LordGymModel>.Instance.GetLastGymFinish(num) && num >= this.DefaultLord)
			{
				this.DefaultLord = num;
			}
		}
		GenericScrollViewNew<LordGymItem, int> lordScroll = this.LordScroll;
		GenericLayout<LordGymItem, int> genericLayout = (lordScroll != null) ? lordScroll.GetGenericLayout() : null;
		LordGymItem lordGymItem = (genericLayout != null) ? genericLayout.GetLayoutItemByKey(this.DefaultLord) : null;
		if (genericLayout != null)
		{
			genericLayout.SelectGridProxy(lordGymItem.GridIndex, false);
		}
		this.OnRefreshView(this.DefaultLord);
	}

	// Token: 0x06010696 RID: 67222 RVA: 0x0047C4F4 File Offset: 0x0047A6F4
	protected override void OnBeforeDestroy()
	{
		this.LordScroll = null;
		this.RewardScroll = null;
	}

	// Token: 0x06010697 RID: 67223 RVA: 0x0047C504 File Offset: 0x0047A704
	private LordGymItem CreateLordItem()
	{
		return new LordGymItem(new Action<int>(this.OnRefreshView), new Func<int, bool>(this.CanChangeLoreToggleState));
	}

	// Token: 0x06010698 RID: 67224 RVA: 0x0047C523 File Offset: 0x0047A723
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06010699 RID: 67225 RVA: 0x0047C52A File Offset: 0x0047A72A
	private void OnClickBtnClose()
	{
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0601069A RID: 67226 RVA: 0x0047C542 File Offset: 0x0047A742
	private void OnClickBtnLord()
	{
		if (this.HelpId > 0)
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.HelpId);
		}
	}

	// Token: 0x0601069B RID: 67227 RVA: 0x0047C55D File Offset: 0x0047A75D
	private void OnClickBtnBegin()
	{
		if (!ControllerBase<LordGymController>.Instance.IsInEntranceEntity())
		{
			return;
		}
		ControllerBase<LordGymController>.Instance.LordGymBeginRequest(this.SelectLordId).ContinueWith(delegate(bool isSuccess)
		{
			if (isSuccess)
			{
				base.CloseMe(null);
			}
		});
	}

	// Token: 0x0601069C RID: 67228 RVA: 0x0047C58E File Offset: 0x0047A78E
	private void OnClickRecord()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymChallengeRecordView, this.LordEntranceId, null);
	}

	// Token: 0x0601069D RID: 67229 RVA: 0x0047C5AB File Offset: 0x0047A7AB
	private void OnClickShop()
	{
		ControllerBase<PayShopController>.Instance.OpenPayShopViewWithTab(PayShopDefine.EPayShopTabType.ActivityShop, 2);
	}

	// Token: 0x0601069E RID: 67230 RVA: 0x0047C5BC File Offset: 0x0047A7BC
	private void OnRefreshView(int lordId)
	{
		this.SelectLordId = lordId;
		GenericScrollViewNew<LordGymItem, int> lordScroll = this.LordScroll;
		GenericLayout<LordGymItem, int> genericLayout = (lordScroll != null) ? lordScroll.GetGenericLayout() : null;
		LordGymItem lordGymItem = (genericLayout != null) ? genericLayout.GetLayoutItemByKey(this.SelectLordId) : null;
		if (genericLayout != null)
		{
			genericLayout.SelectGridProxy(lordGymItem.GridIndex, false);
		}
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId);
		if (lordGymConfig == null)
		{
			return;
		}
		LordGym value = lordGymConfig.Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Text_InstanceDungeonRecommendLevel_Text", new <>z__ReadOnlySingleElementList<object>(value.MonsterLevel.ToString()));
		int rewardId = value.RewardId;
		this.RewardReceived = !ModelBase<ExchangeRewardModel>.Instance.GetRewardIfCanExchange(rewardId);
		List<TItem> exchangeRewardPreviewRewardList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(rewardId, null);
		bool isPass = ModelBase<LordGymModel>.Instance.GetLordGymIsFinish(this.SelectLordId);
		this.RewardScroll.RefreshByDataAsync(exchangeRewardPreviewRewardList, false).Finally(delegate()
		{
			foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.RewardScroll.GetScrollItemList())
			{
				commonItemSmallItemGrid.SetReceivedVisible(isPass);
			}
		});
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), value.PlayDescription, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), value.GymTitle, Array.Empty<object>());
		LordGymPassRecord lordGymPassRecord;
		ModelBase<LordGymModel>.Instance.LordGymRecord.TryGetValue(this.SelectLordId, out lordGymPassRecord);
		if (lordGymPassRecord != null && lordGymPassRecord != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(24), "BestPassTime", new <>z__ReadOnlySingleElementList<object>(Singleton<TimeUtil>.Instance.GetTimeString((double)lordGymPassRecord.PassTime)));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(24), "NoPassRecord", Array.Empty<object>());
		}
		if (value.HelpId != 0)
		{
			UUIItem uuiitem = base.GetButton(10).RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(true);
			}
			this.HelpId = value.HelpId;
		}
		else
		{
			UUIItem uuiitem2 = base.GetButton(10).RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(false);
			}
		}
		bool flag = !ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(this.SelectLordId);
		bool lastGymFinish = ModelBase<LordGymModel>.Instance.GetLastGymFinish(this.SelectLordId);
		bool flag2 = value.MonsterLevel > ModelBase<EditFormationModel>.Instance.GetFormationAverageLevel();
		base.GetItem(20).SetUIActive(flag || !lastGymFinish);
		base.GetItem(25).SetUIActive(flag2 && !flag && lastGymFinish);
		UUIItem uuiitem3 = base.GetButton(19).RootUIComp.Get();
		if (uuiitem3 != null)
		{
			uuiitem3.SetUIActive(!flag && lastGymFinish);
		}
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), value.LockDescription, Array.Empty<object>());
		}
		else if (!lastGymFinish)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), "LordGymLockTips", Array.Empty<object>());
		}
		else if (flag2)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), "LordGymLowLevel", Array.Empty<object>());
		}
		if (this.RewardReceived)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(22), "Text_ButtonTextChallengeOneMore_Text", Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(22), "Text_StartBattle_Text", Array.Empty<object>());
		}
		if (!ModelBase<LordGymModel>.Instance.GetLordGymHasRead(lordId) && !flag && lastGymFinish)
		{
			ControllerBase<LordGymController>.Instance.ReadLordGym(lordId);
			if (lordGymItem != null)
			{
				lordGymItem.RefreshByLordId(lordId);
			}
		}
	}

	// Token: 0x0601069F RID: 67231 RVA: 0x0047C948 File Offset: 0x0047AB48
	private bool CanChangeLoreToggleState(int lordId)
	{
		return this.SelectLordId != lordId;
	}

	// Token: 0x0400815D RID: 33117
	private int LordEntranceId;

	// Token: 0x0400815E RID: 33118
	[Nullable(2)]
	private List<int> LordList;

	// Token: 0x0400815F RID: 33119
	private int SelectLordId;

	// Token: 0x04008160 RID: 33120
	private int HelpId;

	// Token: 0x04008161 RID: 33121
	private bool RewardReceived;

	// Token: 0x04008162 RID: 33122
	private int DefaultLord;

	// Token: 0x04008163 RID: 33123
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<LordGymItem, int> LordScroll;

	// Token: 0x04008164 RID: 33124
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

	// Token: 0x020084C0 RID: 33984
	[NullableContext(0)]
	private class EChildCom
	{
		// Token: 0x0402CF9F RID: 184223
		public const int TextEntranceName = 0;

		// Token: 0x0402CFA0 RID: 184224
		public const int BtnBack = 1;

		// Token: 0x0402CFA1 RID: 184225
		public const int ScrollLord = 2;

		// Token: 0x0402CFA2 RID: 184226
		public const int ScrollLordItem = 3;

		// Token: 0x0402CFA3 RID: 184227
		public const int PnlShopEntrance = 4;

		// Token: 0x0402CFA4 RID: 184228
		public const int TextLordName = 5;

		// Token: 0x0402CFA5 RID: 184229
		public const int TextLordLevel = 6;

		// Token: 0x0402CFA6 RID: 184230
		public const int TexBossBg = 7;

		// Token: 0x0402CFA7 RID: 184231
		public const int TexBossElement = 8;

		// Token: 0x0402CFA8 RID: 184232
		public const int TexBoss = 9;

		// Token: 0x0402CFA9 RID: 184233
		public const int BtnLord = 10;

		// Token: 0x0402CFAA RID: 184234
		public const int PnlContent = 11;

		// Token: 0x0402CFAB RID: 184235
		public const int PnlBuff = 12;

		// Token: 0x0402CFAC RID: 184236
		public const int TextHelpTitle = 13;

		// Token: 0x0402CFAD RID: 184237
		public const int TextRewardTitle = 14;

		// Token: 0x0402CFAE RID: 184238
		public const int TextDesc = 15;

		// Token: 0x0402CFAF RID: 184239
		public const int ScrollReward = 16;

		// Token: 0x0402CFB0 RID: 184240
		public const int ItemReward = 17;

		// Token: 0x0402CFB1 RID: 184241
		public const int BtnChallengeRecord = 18;

		// Token: 0x0402CFB2 RID: 184242
		public const int BtnBegin = 19;

		// Token: 0x0402CFB3 RID: 184243
		public const int ItemLock = 20;

		// Token: 0x0402CFB4 RID: 184244
		public const int TextLock = 21;

		// Token: 0x0402CFB5 RID: 184245
		public const int TextBegin = 22;

		// Token: 0x0402CFB6 RID: 184246
		public const int BtnShop = 23;

		// Token: 0x0402CFB7 RID: 184247
		public const int TxtRecord = 24;

		// Token: 0x0402CFB8 RID: 184248
		public const int PnlLevelTips = 25;
	}
}
