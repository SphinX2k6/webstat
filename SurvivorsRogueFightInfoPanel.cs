using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D83 RID: 7555
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueFightInfoPanel : UiPanelBase
{
	// Token: 0x17001178 RID: 4472
	// (get) Token: 0x0600DE53 RID: 56915 RVA: 0x003BCC00 File Offset: 0x003BAE00
	private float ComboDurationTime
	{
		get
		{
			if (this.ComboDurationTimeInternal == 0f)
			{
				return 5000f;
			}
			return this.ComboDurationTimeInternal;
		}
	}

	// Token: 0x0600DE54 RID: 56916 RVA: 0x003BCC1C File Offset: 0x003BAE1C
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
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnQuitButtonClicked)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnSettingButtonClicked))
		};
	}

	// Token: 0x0600DE55 RID: 56917 RVA: 0x003BCD63 File Offset: 0x003BAF63
	private void OnQuitButtonClicked()
	{
		ControllerBase<SurvivorsRogueController>.Instance.OpenLeaveInstanceView();
	}

	// Token: 0x0600DE56 RID: 56918 RVA: 0x003BCD6F File Offset: 0x003BAF6F
	private void OnSettingButtonClicked()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MenuView, null, null);
	}

	// Token: 0x0600DE57 RID: 56919 RVA: 0x003BCD84 File Offset: 0x003BAF84
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueFightInfoPanel.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueFightInfoPanel.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE58 RID: 56920 RVA: 0x003BCDC8 File Offset: 0x003BAFC8
	protected unsafe override void OnStart()
	{
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
			ELogModule module = ELogModule.SurvivorsRogue;
			ELogAuthor author = ELogAuthor.CK;
			string message = "幸存者连杀等级配置数量不匹配";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("合法数量", 4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("实际数量", this.ComboAnimHandle.Count);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.ComboArea.SetUIActive(false);
		this.PositiveArea.SetUIActive(false);
		this.CurrencyCollectionItem.SetUiActive(true);
		this.ChestCollectionItem.SetUiActive(false);
	}

	// Token: 0x0600DE59 RID: 56921 RVA: 0x003BCFB0 File Offset: 0x003BB1B0
	protected override void OnBeforeShow()
	{
		SurvivorsRogueBattleData battleData = ModelBase<SurvivorsRogueModel>.Instance.BattleData;
		this.RefreshCurrencyNum(battleData.GetCurrencyCount(), false);
		this.RefreshChestNum(battleData.GetChestCount(), false);
		this.TickEnabled = true;
	}

	// Token: 0x0600DE5A RID: 56922 RVA: 0x003BCFE9 File Offset: 0x003BB1E9
	protected override void OnBeforeHide()
	{
		this.TickEnabled = false;
	}

	// Token: 0x0600DE5B RID: 56923 RVA: 0x003BCFF4 File Offset: 0x003BB1F4
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
			ELogModule module = ELogModule.SurvivorsRogue;
			ELogAuthor author = ELogAuthor.CK;
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
		ELogModule module2 = ELogModule.SurvivorsRogue;
		ELogAuthor author2 = ELogAuthor.CK;
		string message2 = "连杀时间进度更新";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RemainTime", this.RemainTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComboDurationTime", this.ComboDurationTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Percent", this.RemainTime / this.ComboDurationTime);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		this.SetComboRemainTimeBarPercent(this.RemainTime / this.ComboDurationTime);
	}

	// Token: 0x0600DE5C RID: 56924 RVA: 0x003BD136 File Offset: 0x003BB336
	public void ResetFightInfo()
	{
		this.RefreshComboNum(0);
		this.RefreshPositiveArea(0);
	}

	// Token: 0x0600DE5D RID: 56925 RVA: 0x003BD148 File Offset: 0x003BB348
	public void RefreshComboNum(int comboNum)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.CK;
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
		}
		else
		{
			this.ComboNumText.SetText(comboNum.ToString());
			this.SetComboRemainTimeBarPercent(1f);
			this.SetComboAreaActive(true, this.CurComboNum == 0);
			this.NeedTick = true;
			this.CurComboNum = comboNum;
		}
		this.UpdateComboDurationInfo(comboNum);
	}

	// Token: 0x0600DE5E RID: 56926 RVA: 0x003BD20C File Offset: 0x003BB40C
	private unsafe void UpdateComboDurationInfo(int comboNum)
	{
		SurvivorsRogueModel instance = ModelBase<SurvivorsRogueModel>.Instance;
		SurvivorsCombo? curComboConfig = instance.CurComboConfig;
		if (curComboConfig == null)
		{
			return;
		}
		int[] comboNumArray = curComboConfig.Value.GetComboNumArray();
		int[] comboDurationArray = curComboConfig.Value.GetComboDurationArray();
		if (comboDurationArray.Length != comboNumArray.Length || comboNumArray.Length != 4)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SurvivorsRogue;
			ELogAuthor author = ELogAuthor.CK;
			string message = "幸存者连杀等级配置数量不匹配";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("连杀阈值配置数量", comboNumArray.Length);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("连杀时间配置数量", comboDurationArray.Length);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("合法数量", 4);
			instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		int[] comboTimerFreezeTimeCfg = instance.ComboTimerFreezeTimeCfg;
		int num = 3;
		for (int i = 0; i < num; i++)
		{
			if (comboNum >= comboNumArray[i] && comboNum < comboNumArray[i + 1])
			{
				this.ApplyComboDuration(i, (float)comboDurationArray[i], (float)instance.ComboDurationAdditionCfg[i], (float)comboTimerFreezeTimeCfg[i]);
				return;
			}
		}
		this.ApplyComboDuration(num, (float)comboDurationArray[num], (float)instance.ComboDurationAdditionCfg[num], (float)comboTimerFreezeTimeCfg[num]);
	}

	// Token: 0x0600DE5F RID: 56927 RVA: 0x003BD34C File Offset: 0x003BB54C
	private unsafe void ApplyComboDuration(int level, float baseDuration, float extraDuration, float freezeTime)
	{
		this.ComboAnimHandle[level]();
		this.ComboDurationTimeInternal = (baseDuration + extraDuration) * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		if (this.LastComboLevelIndex != level)
		{
			this.LastComboLevelIndex = level;
			this.FreezeTime += freezeTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
		this.RemainTime = this.ComboDurationTimeInternal;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.CK;
		string message = "幸存者连杀时间刷新";
		<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("基础时间", baseDuration);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("额外时间", extraDuration);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("冻结时间", freezeTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("剩余时间", this.RemainTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("最大时间", this.ComboDurationTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("连杀进度条百分比", this.RemainTime / this.ComboDurationTime);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
	}

	// Token: 0x0600DE60 RID: 56928 RVA: 0x003BD4A4 File Offset: 0x003BB6A4
	public void RefreshCurrencyNum(int currencyNum, bool playSequence = true)
	{
		bool efficiencyEnhance = ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetGoldGainEfficiency() > 0;
		this.CurrencyCollectionItem.Refresh(currencyNum, efficiencyEnhance, playSequence);
	}

	// Token: 0x0600DE61 RID: 56929 RVA: 0x003BD4D2 File Offset: 0x003BB6D2
	public void RefreshChestNum(int chestNum, bool playSequence = true)
	{
		this.ChestCollectionItem.Refresh(chestNum, false, playSequence);
	}

	// Token: 0x0600DE62 RID: 56930 RVA: 0x003BD4E4 File Offset: 0x003BB6E4
	public void SetChestActive(bool active)
	{
		this.ChestCollectionItem.SetUiActive(active);
		this.ComboPlayer.StopPlayingSequence(false, true);
		this.ComboPlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0600DE63 RID: 56931 RVA: 0x003BD524 File Offset: 0x003BB724
	public unsafe void SetComboAreaActive(bool active, bool playSequence = true)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.CK;
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

	// Token: 0x0600DE64 RID: 56932 RVA: 0x003BD604 File Offset: 0x003BB804
	public unsafe void SetPositiveAreaActive(bool active, bool playSequence = true)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.CK;
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

	// Token: 0x0600DE65 RID: 56933 RVA: 0x003BD700 File Offset: 0x003BB900
	public void RefreshPositiveArea(int value)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.CK;
		string message = "RefreshPositiveArea";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Value", value);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		bool flag = value > 0;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(this.PositiveText, "SurvivorsCombat_IncomeBuff", new <>z__ReadOnlySingleElementList<object>((int)Math.Ceiling((double)((float)value / 100f))));
		this.SetPositiveAreaActive(flag, this.CurPositiveEffectActive != flag);
		this.CurPositiveEffectActive = flag;
	}

	// Token: 0x0600DE66 RID: 56934 RVA: 0x003BD789 File Offset: 0x003BB989
	private void SetComboRemainTimeBarPercent(float percent)
	{
		if (this.ComboRemainTimeBarSprite.bIsUIActive)
		{
			this.ComboRemainTimeBarSprite.SetFillAmount(percent);
		}
	}

	// Token: 0x04006AD7 RID: 27351
	private const int DEFAULT_COMBO_DURATION_TIME = 5000;

	// Token: 0x04006AD8 RID: 27352
	private SurvivorsRogueCollectionItem CurrencyCollectionItem;

	// Token: 0x04006AD9 RID: 27353
	private LevelSequencePlayer CurrencyEfficiencyEnhancePlayer;

	// Token: 0x04006ADA RID: 27354
	private SurvivorsRogueCollectionItem ChestCollectionItem;

	// Token: 0x04006ADB RID: 27355
	private UUIItem ComboArea;

	// Token: 0x04006ADC RID: 27356
	private LevelSequencePlayer ComboPlayer;

	// Token: 0x04006ADD RID: 27357
	private UUIItem PositiveArea;

	// Token: 0x04006ADE RID: 27358
	private LevelSequencePlayer PositiveAreaPlayer;

	// Token: 0x04006ADF RID: 27359
	private UUIArtText ComboNumText;

	// Token: 0x04006AE0 RID: 27360
	private UUISprite ComboRemainTimeBarSprite;

	// Token: 0x04006AE1 RID: 27361
	private UUITexture PositiveIcon;

	// Token: 0x04006AE2 RID: 27362
	private UUIText PositiveText;

	// Token: 0x04006AE3 RID: 27363
	private UUISprite PositiveArrow;

	// Token: 0x04006AE4 RID: 27364
	private float ComboDurationTimeInternal;

	// Token: 0x04006AE5 RID: 27365
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<Action> ComboAnimHandle;

	// Token: 0x04006AE6 RID: 27366
	private float RemainTime;

	// Token: 0x04006AE7 RID: 27367
	private float FreezeTime;

	// Token: 0x04006AE8 RID: 27368
	private int LastComboLevelIndex;

	// Token: 0x04006AE9 RID: 27369
	private bool NeedTick;

	// Token: 0x04006AEA RID: 27370
	private bool TickEnabled;

	// Token: 0x04006AEB RID: 27371
	private int CurComboNum;

	// Token: 0x04006AEC RID: 27372
	private bool CurPositiveEffectActive;

	// Token: 0x0200810B RID: 33035
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BDF6 RID: 179702
		public const int QuitButton = 0;

		// Token: 0x0402BDF7 RID: 179703
		public const int CurrencyItem = 1;

		// Token: 0x0402BDF8 RID: 179704
		public const int ChestItem = 2;

		// Token: 0x0402BDF9 RID: 179705
		public const int ComboRemainTimeBar = 3;

		// Token: 0x0402BDFA RID: 179706
		public const int ComboNum = 4;

		// Token: 0x0402BDFB RID: 179707
		public const int PositiveIcon = 5;

		// Token: 0x0402BDFC RID: 179708
		public const int PositiveText = 6;

		// Token: 0x0402BDFD RID: 179709
		public const int PositiveTip = 7;

		// Token: 0x0402BDFE RID: 179710
		public const int SettingButton = 8;

		// Token: 0x0402BDFF RID: 179711
		public const int ComboArea = 9;

		// Token: 0x0402BE00 RID: 179712
		public const int PositiveArea = 10;
	}
}
