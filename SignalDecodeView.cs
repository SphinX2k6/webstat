using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A20 RID: 10784
[NullableContext(1)]
[Nullable(0)]
public class SignalDecodeView : UiTickViewBase
{
	// Token: 0x06015865 RID: 88165 RVA: 0x005F7CC0 File Offset: 0x005F5EC0
	public SignalDecodeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015866 RID: 88166 RVA: 0x005F7CD4 File Offset: 0x005F5ED4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUITexture)),
			new ValueTuple<int, Type>(11, typeof(UUITexture)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnCatchBtnClick)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnCloseBtnClick))
		};
	}

	// Token: 0x06015867 RID: 88167 RVA: 0x005F7E4C File Offset: 0x005F604C
	protected override void OnStart()
	{
		base.GetItem(5).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(7).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		UUITexture texture = base.GetTexture(11);
		this.WaveformWidth = (int)texture.GetWidth();
		UUISprite sprite = base.GetSprite(2);
		this.SignalSprites = new List<UUISprite>();
		this.SignalSprites.Add(sprite);
		this.MoveSignals = new List<UUISprite>();
		this.MoveSignalCaches = new List<UUISprite>();
		this.MoveSignalsSlotIndexes = new Dictionary<int, int>();
		this.CurrentProcessTabIndex = 1;
		this.CurAnimStep = 0;
		this.LaseTimeElapse = 0f;
		this.CurTimeElapse = 0f;
		this.LastClickTime = 0f;
		this.SignalDecodeFailStopTime = ConfigCommonParamById.GetFloatConfig("SignalDecodeFailStopTime").GetValueOrDefault(0.8f);
		this.SignalDecodeSuccessRange = ConfigCommonParamById.GetFloatConfig("SignalDecodeSuccessRange").GetValueOrDefault(50f);
		string text = this.OpenParam as string;
		this.GameplayId = ((text != null) ? text : "");
		if (string.IsNullOrEmpty(this.GameplayId))
		{
			return;
		}
		SignalDecodeGamePlay? config = ConfigSignalDecodeGamePlayById.GetConfig(this.GameplayId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到信号破译配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", this.GameplayId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.CreateTabs(config.Value);
	}

	// Token: 0x06015868 RID: 88168 RVA: 0x005F7FCC File Offset: 0x005F61CC
	protected override void OnAfterShow()
	{
		int num = this.CurAnimStep + 1;
		this.CurAnimStep = num;
		this.PlayAnim(num);
	}

	// Token: 0x06015869 RID: 88169 RVA: 0x005F7FF0 File Offset: 0x005F61F0
	protected override void OnTick(float delta)
	{
		this.CurTimeElapse += delta;
		this.UpdateAnim();
		this.UpdateMoveSignal(delta);
		this.LaseTimeElapse = this.CurTimeElapse;
	}

	// Token: 0x0601586A RID: 88170 RVA: 0x005F801C File Offset: 0x005F621C
	private void UpdateAnim()
	{
		if (this.CurTimeElapse > 1500f && this.LaseTimeElapse <= 1500f)
		{
			int num = this.CurAnimStep + 1;
			this.CurAnimStep = num;
			this.PlayAnim(num);
			this.CurTimeElapse = 0f;
			this.LaseTimeElapse = 0f;
		}
	}

	// Token: 0x0601586B RID: 88171 RVA: 0x005F8070 File Offset: 0x005F6270
	private void UpdateMoveSignal(float delta)
	{
		this.SignalMoving = (Singleton<TimeUtil>.Instance.GetServerTime() - (double)this.LastClickTime > (double)this.SignalDecodeFailStopTime);
		if (this.MoveSignals == null || this.MoveSignals.Count == 0 || !this.SignalMoving)
		{
			return;
		}
		foreach (UUISprite uuisprite in this.MoveSignals)
		{
			float anchorOffsetX = uuisprite.GetAnchorOffsetX();
			uuisprite.SetAnchorOffsetX(anchorOffsetX + delta / 1000f * 250f * this.CurrentSpectralMoveSpeed);
			float anchorOffsetX2 = uuisprite.GetAnchorOffsetX();
			if (anchorOffsetX2 >= (float)this.WaveformWidth)
			{
				uuisprite.SetAnchorOffsetX(anchorOffsetX2 - (float)this.WaveformWidth - 85f);
				uuisprite.SetUIActive(true);
			}
		}
	}

	// Token: 0x0601586C RID: 88172 RVA: 0x005F814C File Offset: 0x005F634C
	private void PlayAnim(int step)
	{
		switch (step)
		{
		case -1:
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(true);
			TimerSystem.Instance.Delay(new TTimerAction(this.OnSignalDecodeFinished), 1000f, null, null, true, 1f);
			break;
		case 0:
			break;
		case 1:
			base.GetItem(5).SetUIActive(true);
			return;
		case 2:
			base.GetItem(5).SetUIActive(false);
			base.GetItem(6).SetUIActive(true);
			return;
		case 3:
			base.GetItem(6).SetUIActive(false);
			base.GetItem(7).SetUIActive(true);
			this.ProcessTab(this.CurrentProcessTabIndex);
			return;
		default:
			return;
		}
	}

	// Token: 0x0601586D RID: 88173 RVA: 0x005F8204 File Offset: 0x005F6404
	private void CreateTabs(SignalDecodeGamePlay signalDecodeConfig)
	{
		if (signalDecodeConfig.SignalData1 == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到信号1";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", this.GameplayId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.TabItems = new List<SignalDecodeTabItem>();
		UUIItem item = base.GetItem(1);
		UUIItem item2 = base.GetItem(0);
		SignalDecodeTabItem item3 = new SignalDecodeTabItem(1, signalDecodeConfig.SignalData1, item);
		this.TabItems.Add(item3);
		item.SetUIActive(true);
		if (signalDecodeConfig.SignalData2 != 0)
		{
			UUIItem item4 = Singleton<LguiUtil>.Instance.CopyItem(item, item2);
			SignalDecodeTabItem item5 = new SignalDecodeTabItem(2, signalDecodeConfig.SignalData2, item4);
			this.TabItems.Add(item5);
		}
		if (signalDecodeConfig.SignalData3 != 0)
		{
			UUIItem item6 = Singleton<LguiUtil>.Instance.CopyItem(item, item2);
			SignalDecodeTabItem item7 = new SignalDecodeTabItem(3, signalDecodeConfig.SignalData3, item6);
			this.TabItems.Add(item7);
		}
		if (signalDecodeConfig.SignalData4 != 0)
		{
			UUIItem item8 = Singleton<LguiUtil>.Instance.CopyItem(item, item2);
			SignalDecodeTabItem item9 = new SignalDecodeTabItem(4, signalDecodeConfig.SignalData4, item8);
			this.TabItems.Add(item9);
		}
	}

	// Token: 0x0601586E RID: 88174 RVA: 0x005F8324 File Offset: 0x005F6524
	private void ProcessTab(int tabIndex)
	{
		if (this.TabItems == null || this.TabItems.Count == 0)
		{
			return;
		}
		int waveformId = this.TabItems[tabIndex - 1].WaveformId;
		SignalDecodeWaveform? config = ConfigSignalDecodeWaveformById.GetConfig(waveformId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到信号谱面配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", waveformId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		SignalDecodeTabColor? config2 = ConfigSignalDecodeTabColorById.GetConfig(tabIndex, true);
		if (config2 == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Quest;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "找不到信号破译页签的颜色配置";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("tabIndex", tabIndex);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		this.UpdateTabsExpression(config2.Value);
		this.UpdateBgColor(config2.Value);
		this.UpdateWaveform(config.Value);
		this.UpdateWaveformColorAndMoveSignal(config.Value, config2.Value);
		this.UpdateMoveSignalStartPosition();
	}

	// Token: 0x0601586F RID: 88175 RVA: 0x005F8418 File Offset: 0x005F6618
	private void UpdateTabsExpression(SignalDecodeTabColor tabColorConfig)
	{
		foreach (SignalDecodeTabItem signalDecodeTabItem in this.TabItems)
		{
			signalDecodeTabItem.UpdateColor(tabColorConfig);
			signalDecodeTabItem.OnProcess(this.CurrentProcessTabIndex);
		}
	}

	// Token: 0x06015870 RID: 88176 RVA: 0x005F8478 File Offset: 0x005F6678
	private void UpdateBgColor(SignalDecodeTabColor tabColorConfig)
	{
		base.GetTexture(9).SetColor(FColor.FromHex(tabColorConfig.VacancyColor ?? ""));
		base.GetTexture(10).SetColor(FColor.FromHex(tabColorConfig.VacancyColor ?? ""));
		base.GetTexture(11).SetColor(FColor.FromHex(tabColorConfig.DefaultColor ?? ""));
	}

	// Token: 0x06015871 RID: 88177 RVA: 0x005F84EC File Offset: 0x005F66EC
	private void UpdateWaveform(SignalDecodeWaveform signalDecodeConfig)
	{
		UUISprite sprite = base.GetSprite(2);
		UUIItem parentAsUIItem = sprite.GetParentAsUIItem();
		this.CurrentSpectralMoveSpeed = signalDecodeConfig.SpeedRate;
		int[] array = Json.Decode<int[]>(signalDecodeConfig.SignalFragment ?? "[]", null) ?? Array.Empty<int>();
		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i];
			UUISprite uuisprite;
			if (i < this.SignalSprites.Count)
			{
				uuisprite = this.SignalSprites[i];
			}
			else
			{
				uuisprite = this.CopySignalSprite(sprite, parentAsUIItem);
				this.SignalSprites.Add(uuisprite);
			}
			float anchorOffsetX = this.CalculateSignalOffsetX(i);
			uuisprite.SetAnchorOffsetX(anchorOffsetX);
			uuisprite.SetHeight((float)(100 * num));
		}
	}

	// Token: 0x06015872 RID: 88178 RVA: 0x005F859C File Offset: 0x005F679C
	private void UpdateWaveformColorAndMoveSignal(SignalDecodeWaveform signalDecodeConfig, SignalDecodeTabColor tabColorConfig)
	{
		UUIItem item = base.GetItem(12);
		int[] array = Json.Decode<int[]>(signalDecodeConfig.MissingParts ?? "[]", null) ?? Array.Empty<int>();
		this.StartOffset = signalDecodeConfig.Offset;
		for (int i = array.Length - 1; i >= 0; i--)
		{
			bool flag = array[i] == 1;
			UUISprite uuisprite = this.SignalSprites[i];
			if (!flag)
			{
				uuisprite.SetUIActive(false);
			}
			else
			{
				uuisprite.SetUIActive(true);
				uuisprite.SetColor(FColor.FromHex(tabColorConfig.VacancyColor ?? ""));
				UUISprite moveSignalSprite = this.GetMoveSignalSprite(uuisprite, item);
				moveSignalSprite.SetColor(FColor.FromHex(tabColorConfig.HighlightColor ?? ""));
				float anchorOffsetX = this.CalculateSignalOffsetX(i);
				moveSignalSprite.SetAnchorOffsetX(anchorOffsetX);
				this.MoveSignals.Add(moveSignalSprite);
				this.MoveSignalsSlotIndexes[this.MoveSignals.Count - 1] = i;
				if (this.StartOffset > this.MoveSignals.Count)
				{
					moveSignalSprite.SetUIActive(false);
				}
			}
		}
	}

	// Token: 0x06015873 RID: 88179 RVA: 0x005F86B4 File Offset: 0x005F68B4
	private void UpdateMoveSignalStartPosition()
	{
		int num = this.MoveSignalsSlotIndexes[this.StartOffset];
		float num2 = this.CalculateSignalOffsetX(num + 1);
		foreach (UUISprite uuisprite in this.MoveSignals)
		{
			float anchorOffsetX = uuisprite.GetAnchorOffsetX();
			uuisprite.SetAnchorOffsetX(anchorOffsetX - num2);
		}
	}

	// Token: 0x06015874 RID: 88180 RVA: 0x005F872C File Offset: 0x005F692C
	private float CalculateSignalOffsetX(int slotIndex)
	{
		return (float)(slotIndex * 85 + 10 + 3);
	}

	// Token: 0x06015875 RID: 88181 RVA: 0x005F8738 File Offset: 0x005F6938
	private void OnCatchBtnClick()
	{
		if (this.MoveSignals == null || this.MoveSignals.Count == 0)
		{
			return;
		}
		if (Singleton<TimeUtil>.Instance.GetServerTime() - (double)this.LastClickTime <= (double)this.SignalDecodeFailStopTime)
		{
			return;
		}
		this.LastClickTime = (float)Singleton<TimeUtil>.Instance.GetServerTime();
		float anchorOffsetX = this.MoveSignals[0].GetAnchorOffsetX();
		int slotIndex = this.MoveSignalsSlotIndexes[0];
		if (Math.Abs(this.CalculateSignalOffsetX(slotIndex) - anchorOffsetX) > this.SignalDecodeSuccessRange)
		{
			return;
		}
		for (int i = 0; i < this.MoveSignals.Count; i++)
		{
			UUISprite uuisprite = this.MoveSignals[i];
			if (!uuisprite.IsUIActiveInHierarchy())
			{
				return;
			}
			int slotIndex2 = this.MoveSignalsSlotIndexes[i];
			float anchorOffsetX2 = this.CalculateSignalOffsetX(slotIndex2);
			uuisprite.SetAnchorOffsetX(anchorOffsetX2);
		}
		this.TabItems[this.CurrentProcessTabIndex - 1].SetComplete();
		TimerSystem.Instance.Delay(delegate(float _)
		{
			foreach (UUISprite signal in this.MoveSignals)
			{
				this.RecycleSignalSprite(signal);
			}
			this.MoveSignals.Clear();
			this.MoveSignalsSlotIndexes.Clear();
			int num = this.CurrentProcessTabIndex + 1;
			this.CurrentProcessTabIndex = num;
			int num2 = num;
			if (num2 <= 4)
			{
				this.ProcessTab(num2);
				return;
			}
			this.PlayAnim(-1);
		}, (float)((int)(this.SignalDecodeFailStopTime * 1000f)), null, null, true, 1f);
	}

	// Token: 0x06015876 RID: 88182 RVA: 0x005F8850 File Offset: 0x005F6A50
	private UUISprite GetMoveSignalSprite(UUISprite template, UUIItem parent)
	{
		if (this.MoveSignalCaches.Count == 0)
		{
			return this.CopySignalSprite(template, parent);
		}
		UUISprite uuisprite = this.MoveSignalCaches[this.MoveSignalCaches.Count - 1];
		this.MoveSignalCaches.RemoveAt(this.MoveSignalCaches.Count - 1);
		uuisprite.SetHeight(template.GetHeight());
		return uuisprite;
	}

	// Token: 0x06015877 RID: 88183 RVA: 0x005F88AF File Offset: 0x005F6AAF
	private UUISprite CopySignalSprite(UUISprite template, UUIItem parent)
	{
		return (UUISprite)Singleton<LguiUtil>.Instance.DuplicateActor(template.GetOwner(), parent).GetComponentByClass(UUISprite.StaticClass());
	}

	// Token: 0x06015878 RID: 88184 RVA: 0x005F88D6 File Offset: 0x005F6AD6
	private void RecycleSignalSprite(UUISprite signal)
	{
		signal.SetAnchorOffsetX(-10000f);
		this.MoveSignalCaches.Add(signal);
	}

	// Token: 0x06015879 RID: 88185 RVA: 0x005F88EF File Offset: 0x005F6AEF
	private void OnCloseBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.SignalDecodeView, null);
	}

	// Token: 0x0601587A RID: 88186 RVA: 0x005F8901 File Offset: 0x005F6B01
	private void OnSignalDecodeFinished(float _)
	{
		ControllerBase<GeneralLogicTreeController>.Instance.RequestFinishUiGameplay(UiGamePlayType.SignalBreak, this.GameplayId);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.SignalDecodeView, null);
	}

	// Token: 0x0400A5BF RID: 42431
	private const int ANIM_TIME = 1500;

	// Token: 0x0400A5C0 RID: 42432
	private const int SLOT_OUTLINE_WIDTH = 3;

	// Token: 0x0400A5C1 RID: 42433
	private const int SLOT_WIDTH = 60;

	// Token: 0x0400A5C2 RID: 42434
	private const int SLOT_INTERVAL = 19;

	// Token: 0x0400A5C3 RID: 42435
	private const int SLOT_PADDING_LEFT = 10;

	// Token: 0x0400A5C4 RID: 42436
	private const int UNIT_HEIGHT = 100;

	// Token: 0x0400A5C5 RID: 42437
	private string GameplayId = "";

	// Token: 0x0400A5C6 RID: 42438
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<SignalDecodeTabItem> TabItems;

	// Token: 0x0400A5C7 RID: 42439
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<UUISprite> SignalSprites;

	// Token: 0x0400A5C8 RID: 42440
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<UUISprite> MoveSignals;

	// Token: 0x0400A5C9 RID: 42441
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<UUISprite> MoveSignalCaches;

	// Token: 0x0400A5CA RID: 42442
	[Nullable(2)]
	private Dictionary<int, int> MoveSignalsSlotIndexes;

	// Token: 0x0400A5CB RID: 42443
	private int WaveformWidth;

	// Token: 0x0400A5CC RID: 42444
	private float CurrentSpectralMoveSpeed;

	// Token: 0x0400A5CD RID: 42445
	private int CurrentProcessTabIndex;

	// Token: 0x0400A5CE RID: 42446
	private float LaseTimeElapse;

	// Token: 0x0400A5CF RID: 42447
	private float CurTimeElapse;

	// Token: 0x0400A5D0 RID: 42448
	private int CurAnimStep;

	// Token: 0x0400A5D1 RID: 42449
	private int StartOffset;

	// Token: 0x0400A5D2 RID: 42450
	private bool SignalMoving;

	// Token: 0x0400A5D3 RID: 42451
	private float LastClickTime;

	// Token: 0x0400A5D4 RID: 42452
	private float SignalDecodeFailStopTime;

	// Token: 0x0400A5D5 RID: 42453
	private float SignalDecodeSuccessRange;

	// Token: 0x02008DA4 RID: 36260
	[NullableContext(0)]
	private static class EChildComponent
	{
		// Token: 0x0402FA03 RID: 195075
		public const int TabParentItem = 0;

		// Token: 0x0402FA04 RID: 195076
		public const int TabItem = 1;

		// Token: 0x0402FA05 RID: 195077
		public const int SignalSprite = 2;

		// Token: 0x0402FA06 RID: 195078
		public const int CatchBtn = 3;

		// Token: 0x0402FA07 RID: 195079
		public const int CloseBtn = 4;

		// Token: 0x0402FA08 RID: 195080
		public const int DecodeStartAnim1Node = 5;

		// Token: 0x0402FA09 RID: 195081
		public const int DecodeStartAnim2Node = 6;

		// Token: 0x0402FA0A RID: 195082
		public const int DecodeContentNode = 7;

		// Token: 0x0402FA0B RID: 195083
		public const int DecodeFinishAnimNode = 8;

		// Token: 0x0402FA0C RID: 195084
		public const int TopTexture = 9;

		// Token: 0x0402FA0D RID: 195085
		public const int BottomTexture = 10;

		// Token: 0x0402FA0E RID: 195086
		public const int WaveformBgTexture = 11;

		// Token: 0x0402FA0F RID: 195087
		public const int MoveSignalRoot = 12;
	}
}
