using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D21 RID: 7457
[NullableContext(1)]
[Nullable(0)]
public class KurotatoFightInfoPanel : UiPanelBase
{
	// Token: 0x17001164 RID: 4452
	// (get) Token: 0x0600DB1E RID: 56094 RVA: 0x003AD85E File Offset: 0x003ABA5E
	private float ComboDurationTime
	{
		get
		{
			if (this.ComboDurationTimeInternal != 0f)
			{
				return this.ComboDurationTimeInternal;
			}
			return 5000f;
		}
	}

	// Token: 0x0600DB1F RID: 56095 RVA: 0x003AD87C File Offset: 0x003ABA7C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIArtText)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnQuitButtonClicked)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnSettingButtonClicked)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnBtnInfoClicked)),
			new ValueTuple<int, Delegate>(13, new Action(this.OnBtnMonsterClicked))
		};
	}

	// Token: 0x0600DB20 RID: 56096 RVA: 0x003ADA3A File Offset: 0x003ABC3A
	private void OnQuitButtonClicked()
	{
		ControllerBase<KurotatoController>.Instance.LeaveInstanceDungeon();
	}

	// Token: 0x0600DB21 RID: 56097 RVA: 0x003ADA46 File Offset: 0x003ABC46
	private void OnSettingButtonClicked()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MenuView, null, null);
	}

	// Token: 0x0600DB22 RID: 56098 RVA: 0x003ADA59 File Offset: 0x003ABC59
	private void OnBtnInfoClicked()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoTabMainView, null, null);
	}

	// Token: 0x0600DB23 RID: 56099 RVA: 0x003ADA6C File Offset: 0x003ABC6C
	private void OnBtnMonsterClicked()
	{
	}

	// Token: 0x0600DB24 RID: 56100 RVA: 0x003ADA70 File Offset: 0x003ABC70
	protected override UniTask OnBeforeStartAsync()
	{
		KurotatoFightInfoPanel.<OnBeforeStartAsync>d__30 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoFightInfoPanel.<OnBeforeStartAsync>d__30>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB25 RID: 56101 RVA: 0x003ADAB4 File Offset: 0x003ABCB4
	protected unsafe override void OnStart()
	{
		base.GetButton(12).RootUIComp.Get().SetUIActive(true);
		base.GetButton(13).RootUIComp.Get().SetUIActive(true);
		this.ComboArea = base.GetItem(9);
		this.PositiveArea = base.GetItem(10);
		this.ComboNumText = base.GetArtText(4);
		this.ComboRemainTimeBarSprite = base.GetSprite(3);
		this.PositiveIcon = base.GetTexture(5);
		this.PositiveText = base.GetText(6);
		this.PositiveArrow = base.GetSprite(7);
		this.CurrencyEfficiencyEnhancePlayer = new LevelSequencePlayer(this.CurrencyCollectionItem.GetRootItem());
		this.CurrencyEfficiencyEnhancePlayer.BindSequenceCloseEvent(delegate(string _)
		{
			this.CurrencyEfficiencyEnhancePlayer.PlayOrReplaySequenceByName("Close", false, null);
		}, false);
		this.ComboPlayer = new LevelSequencePlayer(this.ComboArea);
		this.ComboPlayer.BindSequenceCloseEvent(delegate(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.ComboArea.SetUIActive(false);
			}
		}, false);
		this.PositiveAreaPlayer = new LevelSequencePlayer(this.PositiveArea);
		this.PositiveAreaPlayer.BindSequenceCloseEvent(delegate(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.PositiveArea.SetUIActive(false);
			}
		}, false);
		this.ComboAnimHandle = new List<Action>
		{
			delegate()
			{
				this.ComboPlayer.StopPlayingSequence(false, true);
				this.ComboPlayer.PlayOrReplaySequenceByName("KillNor", false, null);
			},
			delegate()
			{
				this.ComboPlayer.StopPlayingSequence(false, true);
				this.ComboPlayer.PlayOrReplaySequenceByName("KillMore", false, null);
			},
			delegate()
			{
				this.ComboPlayer.StopPlayingSequence(false, true);
				this.ComboPlayer.PlayOrReplaySequenceByName("KillMost", false, null);
			},
			delegate()
			{
				this.ComboPlayer.StopPlayingSequence(false, true);
				this.ComboPlayer.PlayOrReplaySequenceByName("KillMost", false, null);
			}
		};
		if (this.ComboAnimHandle.Count != 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Kurotato;
			ELogAuthor author = ELogAuthor.LYX;
			string message = "连杀等级配置数量不匹配";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("合法数量", 4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("实际数量", this.ComboAnimHandle.Count);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.ComboArea.SetUIActive(false);
		this.PositiveArea.SetUIActive(false);
		this.CurrencyCollectionItem.SetUiActive(true);
		this.ChestCollectionItem.SetUiActive(true);
	}

	// Token: 0x0600DB26 RID: 56102 RVA: 0x003ADCD0 File Offset: 0x003ABED0
	protected override void OnBeforeShow()
	{
		KurotatoBattleData battleData = ModelBase<KurotatoModel>.Instance.BattleData;
		this.RefreshCurrencyNum(battleData.GetCurrencyCount(), false);
		this.RefreshSpareGold(battleData.GetSpareGold(), false);
		this.TickEnabled = true;
	}

	// Token: 0x0600DB27 RID: 56103 RVA: 0x003ADD09 File Offset: 0x003ABF09
	protected override void OnBeforeHide()
	{
		this.TickEnabled = false;
	}

	// Token: 0x0600DB28 RID: 56104 RVA: 0x003ADD14 File Offset: 0x003ABF14
	public unsafe void OnTick(float delta)
	{
		if (!this.TickEnabled || !this.NeedTick)
		{
			return;
		}
		if (this.FreezeTime > 0f)
		{
			this.FreezeTime -= delta;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Kurotato;
			ELogAuthor author = ELogAuthor.LYX;
			string message = "连杀时间冻结中";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("剩余冻结时间", this.FreezeTime);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.RemainTime -= delta;
		if (this.RemainTime <= 0f)
		{
			this.NeedTick = false;
			this.SetComboRemainTimeBarPercent(0f);
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Kurotato;
		ELogAuthor author2 = ELogAuthor.LYX;
		string message2 = "连杀时间进度更新";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RemainTime", this.RemainTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComboDurationTime", this.ComboDurationTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Percent", this.RemainTime / this.ComboDurationTime);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		this.SetComboRemainTimeBarPercent(this.RemainTime / this.ComboDurationTime);
	}

	// Token: 0x0600DB29 RID: 56105 RVA: 0x003ADE56 File Offset: 0x003AC056
	public void ResetFightInfo()
	{
		this.RefreshComboNum(0);
		this.RefreshPositiveArea(0);
	}

	// Token: 0x0600DB2A RID: 56106 RVA: 0x003ADE68 File Offset: 0x003AC068
	public void RefreshComboNum(int comboNum)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Kurotato;
		ELogAuthor author = ELogAuthor.LYX;
		string message = "RefreshComboNum";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComboNum", comboNum);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (comboNum == 0)
		{
			this.FreezeTime = 0f;
			this.RemainTime = 0f;
			this.SetComboRemainTimeBarPercent(0f);
			this.SetComboAreaActive(false, this.CurComboNum > 0);
			this.NeedTick = false;
			this.CurComboNum = 0;
			return;
		}
		this.ComboNumText.SetText(comboNum.ToString());
		this.SetComboRemainTimeBarPercent(1f);
		this.SetComboAreaActive(true, this.CurComboNum == 0);
		this.NeedTick = true;
		this.CurComboNum = comboNum;
	}

	// Token: 0x0600DB2B RID: 56107 RVA: 0x003ADF24 File Offset: 0x003AC124
	public void RefreshCurrencyNum(int currencyNum, bool playSequence = true)
	{
		bool efficiencyEnhance = ModelBase<KurotatoModel>.Instance.BattleData.GetGoldGainEfficiency() > 0;
		this.CurrencyCollectionItem.Refresh(currencyNum, efficiencyEnhance, playSequence);
	}

	// Token: 0x0600DB2C RID: 56108 RVA: 0x003ADF52 File Offset: 0x003AC152
	public void RefreshSpareGold(int spareGold, bool playSequence = true)
	{
		this.ChestCollectionItem.Refresh(spareGold, false, playSequence);
	}

	// Token: 0x0600DB2D RID: 56109 RVA: 0x003ADF62 File Offset: 0x003AC162
	public void RefreshChestNum(int chestNum, bool playSequence = true)
	{
	}

	// Token: 0x0600DB2E RID: 56110 RVA: 0x003ADF64 File Offset: 0x003AC164
	public void SetChestActive(bool active)
	{
		this.ChestCollectionItem.SetUiActive(active);
		this.ComboPlayer.StopPlayingSequence(false, true);
		this.ComboPlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0600DB2F RID: 56111 RVA: 0x003ADFA4 File Offset: 0x003AC1A4
	public unsafe void SetComboAreaActive(bool active, bool playSequence = true)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Kurotato;
		ELogAuthor author = ELogAuthor.LYX;
		string message = "SetComboAreaActive";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Active", active);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlaySequence", playSequence);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.ComboPlayer.StopPlayingSequence(false, true);
		if (active)
		{
			this.ComboArea.SetUIActive(true);
			if (playSequence)
			{
				this.ComboPlayer.PlayOrReplaySequenceByName("Start", false, null);
				return;
			}
		}
		else
		{
			if (playSequence)
			{
				this.ComboPlayer.StopPlayingSequence(false, true);
				this.ComboPlayer.PlayOrReplaySequenceByName("Close", false, null);
				return;
			}
			this.ComboArea.SetUIActive(false);
		}
	}

	// Token: 0x0600DB30 RID: 56112 RVA: 0x003AE084 File Offset: 0x003AC284
	public unsafe void SetPositiveAreaActive(bool active, bool playSequence = true)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Kurotato;
		ELogAuthor author = ELogAuthor.LYX;
		string message = "SetPositiveAreaActive";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Active", active);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlaySequence", playSequence);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.PositiveAreaPlayer.StopPlayingSequence(false, true);
		if (active)
		{
			this.PositiveArea.SetUIActive(true);
			this.PositiveIcon.SetUIActive(true);
			this.PositiveArrow.SetUIActive(true);
			this.PositiveAreaPlayer.PlayOrReplaySequenceByName("Start", false, null);
		}
		else if (playSequence)
		{
			this.PositiveAreaPlayer.PlayOrReplaySequenceByName("Close", false, null);
		}
		else
		{
			this.PositiveArea.SetUIActive(false);
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.SurvivorsRogueComboBuffShow, active);
	}

	// Token: 0x0600DB31 RID: 56113 RVA: 0x003AE180 File Offset: 0x003AC380
	public void RefreshPositiveArea(int value)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Kurotato;
		ELogAuthor author = ELogAuthor.LYX;
		string message = "RefreshPositiveArea";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Value", value);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		bool flag = value > 0;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(this.PositiveText, "SurvivorsCombat_IncomeBuff", new <>z__ReadOnlySingleElementList<object>((int)Math.Ceiling((double)((float)value / 100f))));
		this.SetPositiveAreaActive(flag, this.CurPositiveEffectActive != flag);
		this.CurPositiveEffectActive = flag;
	}

	// Token: 0x0600DB32 RID: 56114 RVA: 0x003AE209 File Offset: 0x003AC409
	private void SetComboRemainTimeBarPercent(float percent)
	{
		if (this.ComboRemainTimeBarSprite.bIsUIActive)
		{
			this.ComboRemainTimeBarSprite.SetFillAmount(percent);
		}
	}

	// Token: 0x040068A6 RID: 26790
	private const int DEFAULT_COMBO_DURATION_TIME = 5000;

	// Token: 0x040068A7 RID: 26791
	private readonly SurvivorsRogueCollectionItem CurrencyCollectionItem = new SurvivorsRogueCollectionItem();

	// Token: 0x040068A8 RID: 26792
	private LevelSequencePlayer CurrencyEfficiencyEnhancePlayer;

	// Token: 0x040068A9 RID: 26793
	private readonly SurvivorsRogueCollectionItem ChestCollectionItem = new SurvivorsRogueCollectionItem();

	// Token: 0x040068AA RID: 26794
	private UUIItem ComboArea;

	// Token: 0x040068AB RID: 26795
	private LevelSequencePlayer ComboPlayer;

	// Token: 0x040068AC RID: 26796
	private UUIItem PositiveArea;

	// Token: 0x040068AD RID: 26797
	private LevelSequencePlayer PositiveAreaPlayer;

	// Token: 0x040068AE RID: 26798
	private UUIArtText ComboNumText;

	// Token: 0x040068AF RID: 26799
	private UUISprite ComboRemainTimeBarSprite;

	// Token: 0x040068B0 RID: 26800
	private UUITexture PositiveIcon;

	// Token: 0x040068B1 RID: 26801
	private UUIText PositiveText;

	// Token: 0x040068B2 RID: 26802
	private UUISprite PositiveArrow;

	// Token: 0x040068B3 RID: 26803
	private readonly float ComboDurationTimeInternal;

	// Token: 0x040068B4 RID: 26804
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<Action> ComboAnimHandle;

	// Token: 0x040068B5 RID: 26805
	private float RemainTime;

	// Token: 0x040068B6 RID: 26806
	private float FreezeTime;

	// Token: 0x040068B7 RID: 26807
	protected int LastComboLevelIndex;

	// Token: 0x040068B8 RID: 26808
	private bool NeedTick;

	// Token: 0x040068B9 RID: 26809
	private bool TickEnabled;

	// Token: 0x040068BA RID: 26810
	private int CurComboNum;

	// Token: 0x040068BB RID: 26811
	private bool CurPositiveEffectActive;

	// Token: 0x02008099 RID: 32921
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BBBC RID: 179132
		public const int QuitButton = 0;

		// Token: 0x0402BBBD RID: 179133
		public const int CurrencyItem = 1;

		// Token: 0x0402BBBE RID: 179134
		public const int ChestItem = 2;

		// Token: 0x0402BBBF RID: 179135
		public const int ComboRemainTimeBar = 3;

		// Token: 0x0402BBC0 RID: 179136
		public const int ComboNum = 4;

		// Token: 0x0402BBC1 RID: 179137
		public const int PositiveIcon = 5;

		// Token: 0x0402BBC2 RID: 179138
		public const int PositiveText = 6;

		// Token: 0x0402BBC3 RID: 179139
		public const int PositiveTip = 7;

		// Token: 0x0402BBC4 RID: 179140
		public const int SettingButton = 8;

		// Token: 0x0402BBC5 RID: 179141
		public const int ComboArea = 9;

		// Token: 0x0402BBC6 RID: 179142
		public const int PositiveArea = 10;

		// Token: 0x0402BBC7 RID: 179143
		public const int PanelBox = 11;

		// Token: 0x0402BBC8 RID: 179144
		public const int BtnInfo = 12;

		// Token: 0x0402BBC9 RID: 179145
		public const int BtnMonster = 13;
	}
}
