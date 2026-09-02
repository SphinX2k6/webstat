using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F60 RID: 8032
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryMainButtonItem : UiPanelBase
{
	// Token: 0x0600F071 RID: 61553 RVA: 0x0041B8F0 File Offset: 0x00419AF0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClick))
		};
	}

	// Token: 0x0600F072 RID: 61554 RVA: 0x0041B96D File Offset: 0x00419B6D
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600F073 RID: 61555 RVA: 0x0041B980 File Offset: 0x00419B80
	[NullableContext(1)]
	public void SetConfigData(IHonamiStoryMainButtonConfig config)
	{
		if (config.FunctionId != null)
		{
			int value = (int)config.FunctionId.Value;
			if (value != 0)
			{
				this.FunctionId = value;
			}
		}
		if (config.SetTextCallback != null)
		{
			this.SetTextCallback = delegate(UUIText text)
			{
				config.SetTextCallback(text);
			};
		}
		if (config.ShowRedDot != null)
		{
			this.ShowRedDotCallback = (() => config.ShowRedDot());
		}
		if (config.ShowCallback != null)
		{
			this.ShowCallback = (() => config.ShowCallback());
		}
		if (config.SpecialParamName != null)
		{
			this.SpecialParamName = config.SpecialParamName;
		}
		if (config.SpecialSequenceName != null)
		{
			this.SpecialSequenceName = config.SpecialSequenceName;
		}
	}

	// Token: 0x0600F074 RID: 61556 RVA: 0x0041BA66 File Offset: 0x00419C66
	[NullableContext(1)]
	public void SetClickCallback(Action callback)
	{
		this.ClickCallBack = callback;
	}

	// Token: 0x0600F075 RID: 61557 RVA: 0x0041BA6F File Offset: 0x00419C6F
	public bool CheckIsSpecialSet()
	{
		return this.ShowRedDotCallback != null && this.ShowRedDotCallback() && this.SpecialSequenceName != null;
	}

	// Token: 0x0600F076 RID: 61558 RVA: 0x0041BA94 File Offset: 0x00419C94
	public void SetButtonState()
	{
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(this.FunctionId);
		bool flag2 = this.ShowCallback == null || this.ShowCallback();
		if (!flag || !flag2)
		{
			base.SetUiActive(false);
			return;
		}
		base.SetUiActive(true);
		HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryMainButtonUnlockSet, new HashSet<int>());
		if (!player.Contains(this.FunctionId))
		{
			this.LevelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
			player.Add(this.FunctionId);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryMainButtonUnlockSet, player);
		}
	}

	// Token: 0x0600F077 RID: 61559 RVA: 0x0041BB2F File Offset: 0x00419D2F
	public void SetText()
	{
		if (this.SetTextCallback != null)
		{
			this.SetTextCallback(base.GetText(1));
			return;
		}
		base.GetText(1).SetText("", true);
	}

	// Token: 0x0600F078 RID: 61560 RVA: 0x0041BB5E File Offset: 0x00419D5E
	public void SetRedDot()
	{
		if (this.ShowRedDotCallback != null)
		{
			base.GetItem(2).SetUIActive(this.ShowRedDotCallback());
			return;
		}
		base.GetItem(2).SetUIActive(false);
	}

	// Token: 0x0600F079 RID: 61561 RVA: 0x0041BB8D File Offset: 0x00419D8D
	public void Clear()
	{
		this.ClickCallBack = null;
		this.SetTextCallback = null;
		this.ShowRedDotCallback = null;
		this.ShowCallback = null;
		this.SpecialParamName = null;
		this.SpecialSequenceName = null;
	}

	// Token: 0x0600F07A RID: 61562 RVA: 0x0041BBB9 File Offset: 0x00419DB9
	private void OnBtnClick()
	{
		Action clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack();
	}

	// Token: 0x0400738C RID: 29580
	private int FunctionId;

	// Token: 0x0400738D RID: 29581
	private Action ClickCallBack;

	// Token: 0x0400738E RID: 29582
	private Func<bool> ShowCallback;

	// Token: 0x0400738F RID: 29583
	private Action<UUIText> SetTextCallback;

	// Token: 0x04007390 RID: 29584
	private Func<bool> ShowRedDotCallback;

	// Token: 0x04007391 RID: 29585
	public string SpecialParamName;

	// Token: 0x04007392 RID: 29586
	public string SpecialSequenceName;

	// Token: 0x04007393 RID: 29587
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x020082ED RID: 33517
	[NullableContext(0)]
	private enum EHonamiStoryMainButtonItemComponent
	{
		// Token: 0x0402C645 RID: 181829
		Button,
		// Token: 0x0402C646 RID: 181830
		ProgressText,
		// Token: 0x0402C647 RID: 181831
		RedDotItem
	}
}
