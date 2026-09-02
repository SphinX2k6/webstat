using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

// Token: 0x02001A84 RID: 6788
[NullableContext(1)]
[Nullable(0)]
public class ConfirmBoxDataNew : UiPopViewData, IViewOpenParamMultipleView
{
	// Token: 0x17000FEC RID: 4076
	// (get) Token: 0x0600C22B RID: 49707 RVA: 0x00332AA2 File Offset: 0x00330CA2
	// (set) Token: 0x0600C22C RID: 49708 RVA: 0x00332AAA File Offset: 0x00330CAA
	public bool IsMultipleView { get; set; }

	// Token: 0x0600C22D RID: 49709 RVA: 0x00332AB4 File Offset: 0x00330CB4
	public ConfirmBoxDataNew(EConfirmBoxConfigId configId)
	{
		this.ConfigId = configId;
	}

	// Token: 0x0600C22E RID: 49710 RVA: 0x00332B38 File Offset: 0x00330D38
	public void SetTitle(string title)
	{
		this.Title = title;
	}

	// Token: 0x0600C22F RID: 49711 RVA: 0x00332B41 File Offset: 0x00330D41
	public string GetTitle()
	{
		return this.Title;
	}

	// Token: 0x0600C230 RID: 49712 RVA: 0x00332B49 File Offset: 0x00330D49
	public void SetBtnText(int index, string text)
	{
		this.BtnTextMap[index] = text;
	}

	// Token: 0x0600C231 RID: 49713 RVA: 0x00332B58 File Offset: 0x00330D58
	public string GetBtnText(int index)
	{
		if (this.BtnTextMap.ContainsKey(index))
		{
			return this.BtnTextMap[index];
		}
		return "";
	}

	// Token: 0x0600C232 RID: 49714 RVA: 0x00332B7A File Offset: 0x00330D7A
	public void SetTableTextArgNew(string id, params object[] args)
	{
		this.TableTxtArgNew = new TableTextArgNew(id, args);
	}

	// Token: 0x0600C233 RID: 49715 RVA: 0x00332B89 File Offset: 0x00330D89
	public void SetTextArgs(params string[] args)
	{
		this.TextArgs = args;
	}

	// Token: 0x0600C234 RID: 49716 RVA: 0x00332B92 File Offset: 0x00330D92
	public void SetCloseFunction(Action closeFunction)
	{
		this.CloseFunction = closeFunction;
	}

	// Token: 0x0600C235 RID: 49717 RVA: 0x00332B9B File Offset: 0x00330D9B
	[NullableContext(2)]
	public Action GetCloseFunction()
	{
		return this.CloseFunction;
	}

	// Token: 0x0600C236 RID: 49718 RVA: 0x00332BA3 File Offset: 0x00330DA3
	public void SetToggleFunction(Action<bool> toggleFunction)
	{
		this.ToggleFunction = toggleFunction;
	}

	// Token: 0x0600C237 RID: 49719 RVA: 0x00332BAC File Offset: 0x00330DAC
	[NullableContext(2)]
	public Action<bool> GetToggleFunction()
	{
		return this.ToggleFunction;
	}

	// Token: 0x0600C238 RID: 49720 RVA: 0x00332BB4 File Offset: 0x00330DB4
	public void SetAfterShowFunction(Action afterShowFunction)
	{
		this.AfterShowFunction = afterShowFunction;
	}

	// Token: 0x0600C239 RID: 49721 RVA: 0x00332BBD File Offset: 0x00330DBD
	[NullableContext(2)]
	public Action GetAfterShowFunction()
	{
		return this.AfterShowFunction;
	}

	// Token: 0x0600C23A RID: 49722 RVA: 0x00332BC8 File Offset: 0x00330DC8
	[NullableContext(2)]
	public string GetContentText()
	{
		ConfirmBox? confirmBoxConfig = ConfigBase<ConfirmBoxConfig>.Instance.GetConfirmBoxConfig((int)this.ConfigId);
		if (confirmBoxConfig == null)
		{
			return null;
		}
		string text = ConfigBase<ConfirmBoxConfig>.Instance.GetContent(confirmBoxConfig.Value.Content);
		if (this.TextArgs != null)
		{
			text = StringUtils.Format(text, this.TextArgs);
		}
		return text;
	}

	// Token: 0x04005D06 RID: 23814
	public EConfirmBoxConfigId ConfigId = EConfirmBoxConfigId.Default;

	// Token: 0x04005D07 RID: 23815
	[Nullable(2)]
	public string CustomResourceId;

	// Token: 0x04005D08 RID: 23816
	public EUiBehaviourPopType? CustomPopType;

	// Token: 0x04005D09 RID: 23817
	public Dictionary<int, int> ItemIdMap = new Dictionary<int, int>();

	// Token: 0x04005D0A RID: 23818
	[Nullable(new byte[]
	{
		1,
		2
	})]
	public Dictionary<int, Action> FunctionMap = new Dictionary<int, Action>();

	// Token: 0x04005D0B RID: 23819
	public Dictionary<int, bool> InteractionMap = new Dictionary<int, bool>();

	// Token: 0x04005D0C RID: 23820
	public ELayerType CanvasLayer = ELayerType.Pop;

	// Token: 0x04005D0D RID: 23821
	[Nullable(2)]
	public Func<int, bool> CanExecuteCloseFunc;

	// Token: 0x04005D0E RID: 23822
	protected string Title = "";

	// Token: 0x04005D0F RID: 23823
	protected Dictionary<int, string> BtnTextMap = new Dictionary<int, string>();

	// Token: 0x04005D10 RID: 23824
	public bool HasToggle;

	// Token: 0x04005D11 RID: 23825
	public string ToggleText = "";

	// Token: 0x04005D12 RID: 23826
	public string ToggleTextKey = "";

	// Token: 0x04005D13 RID: 23827
	[Nullable(2)]
	public string Tip;

	// Token: 0x04005D14 RID: 23828
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] TextArgs;

	// Token: 0x04005D15 RID: 23829
	[Nullable(2)]
	public TableTextArgNew TableTxtArgNew;

	// Token: 0x04005D16 RID: 23830
	public bool SetTipsBgRed;

	// Token: 0x04005D17 RID: 23831
	public bool CanClickDuringTimer = true;

	// Token: 0x04005D18 RID: 23832
	public bool IsEscViewTriggerCallBack = true;

	// Token: 0x04005D19 RID: 23833
	public bool ShowPowerItem;

	// Token: 0x04005D1A RID: 23834
	[Nullable(2)]
	public UiViewBase AttachView;

	// Token: 0x04005D1B RID: 23835
	[Nullable(2)]
	private Action CloseFunction;

	// Token: 0x04005D1C RID: 23836
	[Nullable(2)]
	private Action AfterShowFunction;

	// Token: 0x04005D1D RID: 23837
	[Nullable(2)]
	private Action<bool> ToggleFunction;

	// Token: 0x04005D1E RID: 23838
	[Nullable(2)]
	public TOpenViewCallBack FinishOpenFunction;

	// Token: 0x04005D1F RID: 23839
	[Nullable(2)]
	public Action DestroyFunction;

	// Token: 0x04005D20 RID: 23840
	[Nullable(2)]
	public Action BeforePlayCloseFunction;
}
