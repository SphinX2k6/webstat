using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BA4 RID: 11172
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class TermExplanationController : ControllerBase<TermExplanationController>
{
	// Token: 0x17001D46 RID: 7494
	// (get) Token: 0x060163F3 RID: 91123 RVA: 0x00629975 File Offset: 0x00627B75
	protected override bool IsTickEvenPausedInternal
	{
		get
		{
			return true;
		}
	}

	// Token: 0x060163F4 RID: 91124 RVA: 0x00629978 File Offset: 0x00627B78
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnTermExplanationViewClosed, new Action(this.OnTermExplanationViewClosed));
		Singleton<EventSystem>.Instance.Add(EEventName.OnTermExplanationViewBeforeStart, new Action<int>(this.OnTermExplanationViewBeforeStart));
		Singleton<EventSystem>.Instance.Add(EEventName.OnResetToBattleView, new Action(this.OnResetToBattleView));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnTermExplanationRegisteredTextContentChange, new Action<IReadOnlyList<int>>(this.OnTextChange));
		return true;
	}

	// Token: 0x060163F5 RID: 91125 RVA: 0x006299F8 File Offset: 0x00627BF8
	protected override bool OnClear()
	{
		foreach (KeyValuePair<int, TermTextRegistryHandle> keyValuePair in this.RegistryMap)
		{
			this.HandlePool.Put(keyValuePair.Value);
		}
		this.RegistryId = 0;
		this.UsingHandle = null;
		this.RegistryMap.Clear();
		this.HandlePool.Clear();
		this.GroupList.Clear();
		this.CurGroup = ETermExplanationGroup.Default;
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTermExplanationViewClosed, new Action(this.OnTermExplanationViewClosed));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTermExplanationViewBeforeStart, new Action<int>(this.OnTermExplanationViewBeforeStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResetToBattleView, new Action(this.OnResetToBattleView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTermExplanationRegisteredTextContentChange, new Action<IReadOnlyList<int>>(this.OnTextChange));
		return true;
	}

	// Token: 0x060163F6 RID: 91126 RVA: 0x00629B00 File Offset: 0x00627D00
	protected override void OnTick(float delta)
	{
		bool flag = false;
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, TermTextRegistryHandle> keyValuePair in this.RegistryMap)
		{
			TermTextRegistryHandle value = keyValuePair.Value;
			if (value.UiText != null && value.UiText.IsValid() && value.UiText.IsUIActiveInHierarchy())
			{
				if (value.LastText != value.UiText.text)
				{
					value.LastText = value.UiText.text;
					flag = true;
					list.Add(value.Id);
				}
				if (value.IsEnableStateDirty)
				{
					value.IsEnableStateDirty = false;
					flag = true;
					list.Add(value.Id);
				}
				if (!value.LastHierarchyActive)
				{
					value.LastHierarchyActive = true;
					flag = true;
					this.UseGroup(value.Group);
					list.Add(value.Id);
				}
			}
			TermTextRegistryHandle termTextRegistryHandle = value;
			UUIText uiText = value.UiText;
			termTextRegistryHandle.LastHierarchyActive = (uiText != null && uiText.IsUIActiveInHierarchy());
		}
		if (flag)
		{
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OnTermExplanationRegisteredTextContentChange, list);
		}
	}

	// Token: 0x060163F7 RID: 91127 RVA: 0x00629C48 File Offset: 0x00627E48
	public int RegisterTextHyperlinkByParam(ITermExplanationRegistryParam param)
	{
		return this.RegisterTextHyperlink(param.UiText, param.ViewType, param.ReportType, (param.AttachDirection != null) ? param.AttachDirection.Value : ETermExplanationViewAttachDirection.None, param.AttachItem, param.OnDisableClick, param.CustomOffset, (param.Group != null) ? param.Group.Value : ETermExplanationGroup.Default, (param.Priority != null) ? param.Priority.Value : 0, (param.Style != null) ? param.Style.Value : ETermExplanationViewStyle.Default);
	}

	// Token: 0x060163F8 RID: 91128 RVA: 0x00629D04 File Offset: 0x00627F04
	[NullableContext(2)]
	public int RegisterTextHyperlink([Nullable(1)] UUIText uiText, ETermExplanationViewType type, ETermExplanationReportType reportType, ETermExplanationViewAttachDirection attachDir = ETermExplanationViewAttachDirection.None, UUIItem attachItem = null, Action onDisableClick = null, [Nullable(0)] ValueTuple<float, float>? customOffset = null, ETermExplanationGroup group = ETermExplanationGroup.Default, int priority = 0, ETermExplanationViewStyle style = ETermExplanationViewStyle.Default)
	{
		TermExplanationController.<>c__DisplayClass14_0 CS$<>8__locals1 = new TermExplanationController.<>c__DisplayClass14_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.uiText = uiText;
		if (this.GetIdByUiText(CS$<>8__locals1.uiText) != 0)
		{
			Singleton<Log>.Instance.Warn(ELogModule.TermExplanation, ELogAuthor.HYF, "术语解释文本控件注册失败: 控件重复注册", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		this.OnAddGroup(group);
		if (this.CurGroup != group)
		{
			this.UseGroup(group);
		}
		CS$<>8__locals1.handle = (this.HandlePool.Get() ?? this.HandlePool.Create());
		CS$<>8__locals1.handle.SetUiText(CS$<>8__locals1.uiText);
		CS$<>8__locals1.handle.SetType(type);
		CS$<>8__locals1.handle.OnDisableClick = onDisableClick;
		CS$<>8__locals1.handle.AttachDir = attachDir;
		CS$<>8__locals1.handle.AttachItem = (attachItem ?? CS$<>8__locals1.uiText);
		CS$<>8__locals1.handle.Group = group;
		CS$<>8__locals1.handle.Priority = priority;
		CS$<>8__locals1.handle.Style = style;
		CS$<>8__locals1.handle.ReportType = new ETermExplanationReportType?(reportType);
		if (customOffset != null)
		{
			CS$<>8__locals1.handle.Offset = customOffset.Value;
		}
		Dictionary<int, TermTextRegistryHandle> registryMap = this.RegistryMap;
		int num = this.RegistryId + 1;
		this.RegistryId = num;
		registryMap[num] = CS$<>8__locals1.handle;
		CS$<>8__locals1.handle.Id = this.RegistryId;
		CS$<>8__locals1.uiText.OnHyperLinkClickCallBack.Bind(new Func<string, bool>(CS$<>8__locals1.<RegisterTextHyperlink>g__OnHyperLink|0));
		CS$<>8__locals1.uiText.SetRichText(true);
		CS$<>8__locals1.uiText.SetEnableHyperLinksHighlight(true);
		CS$<>8__locals1.uiText.HyperLinksHoverColor = FColor.FromHex("FED93E4C");
		CS$<>8__locals1.uiText.bFilterHyperLinks = false;
		(CS$<>8__locals1.uiText.GetOwner() as AUIBaseActor).OnPreDestroyed.Add(delegate(AActor _)
		{
			Singleton<Log>.Instance.Info(ELogModule.TermExplanation, ELogAuthor.HYF, "存在文本控件销毁前未解注册!", default(ReadOnlySpan<ValueTuple<string, object>>));
			CS$<>8__locals1.<>4__this.UnRegisterTextHyperlink(CS$<>8__locals1.uiText);
		});
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OnTermExplanationRegisteredTextContentChange, new <>z__ReadOnlySingleElementList<int>(CS$<>8__locals1.handle.Id));
		return this.RegistryId;
	}

	// Token: 0x060163F9 RID: 91129 RVA: 0x00629F04 File Offset: 0x00628104
	public void UnRegisterTextHyperlink(UUIText uiText)
	{
		int idByUiText = this.GetIdByUiText(uiText);
		if (idByUiText == 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.TermExplanation, ELogAuthor.HYF, "解注册失败: 未注册的text控件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.UnRegisterTextHyperlinkById(idByUiText);
	}

	// Token: 0x060163FA RID: 91130 RVA: 0x00629F44 File Offset: 0x00628144
	public void UnRegisterTextHyperlinkById(int id)
	{
		TermTextRegistryHandle termTextRegistryHandle;
		if (!this.RegistryMap.TryGetValue(id, out termTextRegistryHandle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TermExplanation;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "解注册失败: 不存在此id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.OnRemoveGroup(termTextRegistryHandle.Group);
		termTextRegistryHandle.Clear();
		this.RegistryMap.Remove(id);
		this.HandlePool.Put(termTextRegistryHandle);
	}

	// Token: 0x060163FB RID: 91131 RVA: 0x00629FC0 File Offset: 0x006281C0
	public void SetEnableHyperLink(UUIText uiText, bool enable)
	{
		int idByUiText = this.GetIdByUiText(uiText);
		if (idByUiText == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.TermExplanation, ELogAuthor.HYF, "设置启禁用失败: 未注册的text控件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SetEnableHyperLinkById(idByUiText, enable);
	}

	// Token: 0x060163FC RID: 91132 RVA: 0x0062A000 File Offset: 0x00628200
	public void SetEnableHyperLinkById(int id, bool enable)
	{
		TermTextRegistryHandle termTextRegistryHandle;
		if (!this.RegistryMap.TryGetValue(id, out termTextRegistryHandle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TermExplanation;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "设置启禁用失败: 不存在此id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (termTextRegistryHandle.Enable == enable)
		{
			return;
		}
		termTextRegistryHandle.SetEnable(enable);
	}

	// Token: 0x060163FD RID: 91133 RVA: 0x0062A060 File Offset: 0x00628260
	public bool OpenTermExplanationView(UUIText uiText)
	{
		int idByUiText = this.GetIdByUiText(uiText);
		if (idByUiText == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.TermExplanation, ELogAuthor.HYF, "术语解释打开失败: 未注册的text控件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		TermTextRegistryHandle handle;
		if (!this.RegistryMap.TryGetValue(idByUiText, out handle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TermExplanation;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "术语解释打开失败: 不存在此id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", idByUiText);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		List<string> list = this.ParseText2HyperLinkList(uiText.text, true);
		if (list.Count == 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.TermExplanation;
			ELogAuthor author2 = ELogAuthor.HYF;
			string message2 = "术语解释打开失败: 文本中无超链接";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", idByUiText);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		return this.OpenTermExplanationViewImp(handle, list[0]);
	}

	// Token: 0x060163FE RID: 91134 RVA: 0x0062A130 File Offset: 0x00628330
	public void OpenTermExplanationViewDirectly()
	{
		List<string> list = new List<string>();
		TermTextRegistryHandle termTextRegistryHandle = null;
		foreach (TermTextRegistryHandle termTextRegistryHandle2 in this.GetHandlesByGroup(this.CurGroup, true))
		{
			List<string> list2 = this.ParseText2HyperLinkList(termTextRegistryHandle2.UiText.text, false);
			foreach (string item in list2)
			{
				list.Add(item);
			}
			if (list2.Count > 0 && termTextRegistryHandle == null)
			{
				termTextRegistryHandle = termTextRegistryHandle2;
			}
		}
		if (list.Count == 0 || termTextRegistryHandle == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.TermExplanation, ELogAuthor.HYF, "术语解释打开失败: 当前文本中无超链接", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!termTextRegistryHandle.Enable)
		{
			Singleton<Log>.Instance.Error(ELogModule.TermExplanation, ELogAuthor.HYF, "术语解释打开失败: 当前文本术语功能已被手动设为失效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		termTextRegistryHandle.NeedHighlight = false;
		if (termTextRegistryHandle.ReportType != null)
		{
			this.ReportClickTermExplanation(termTextRegistryHandle.ReportType.Value);
		}
		this.UsingHandle = termTextRegistryHandle;
		TermExplanationViewParam param = new TermExplanationViewParam
		{
			HyperLinkList = new List<string>(new HashSet<string>(list))
		};
		EUiViewName termViewName = this.GetTermViewName(termTextRegistryHandle);
		Singleton<EventSystem>.Instance.Emit<ETermExplanationViewType>(EEventName.OnTermExplanationViewOpening, termTextRegistryHandle.Type);
		Singleton<UiManager>.Instance.OpenView(termViewName, param, null);
	}

	// Token: 0x060163FF RID: 91135 RVA: 0x0062A2B8 File Offset: 0x006284B8
	public bool HasAnyTermInCurrentTexts()
	{
		foreach (KeyValuePair<int, TermTextRegistryHandle> keyValuePair in this.RegistryMap)
		{
			TermTextRegistryHandle value = keyValuePair.Value;
			if (value.UiText != null && value.UiText.IsValid() && value.UiText.IsUIActiveInHierarchy() && value.Enable && value.Group == this.CurGroup && this.ParseText2HyperLinkList(value.UiText.text, true).Count > 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06016400 RID: 91136 RVA: 0x0062A368 File Offset: 0x00628568
	public bool IsUiTextRegistered(UUIText uiText)
	{
		return this.GetIdByUiText(uiText) != 0;
	}

	// Token: 0x06016401 RID: 91137 RVA: 0x0062A374 File Offset: 0x00628574
	private void OnAddGroup(ETermExplanationGroup inGroup)
	{
		int num = -1;
		for (int i = 0; i < this.GroupList.Count; i++)
		{
			if (this.GroupList[i].Item1 == inGroup)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			this.GroupList.Add(new ValueTuple<ETermExplanationGroup, int>(inGroup, 1));
			return;
		}
		int item = this.GroupList[num].Item2 + 1;
		this.GroupList.RemoveAt(num);
		this.GroupList.Add(new ValueTuple<ETermExplanationGroup, int>(inGroup, item));
	}

	// Token: 0x06016402 RID: 91138 RVA: 0x0062A3FC File Offset: 0x006285FC
	private void OnRemoveGroup(ETermExplanationGroup inGroup)
	{
		int num = -1;
		for (int i = 0; i < this.GroupList.Count; i++)
		{
			if (this.GroupList[i].Item1 == inGroup)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			return;
		}
		int num2 = this.GroupList[num].Item2 - 1;
		if (num2 <= 0)
		{
			this.GroupList.RemoveAt(num);
			if (this.CurGroup == inGroup)
			{
				if (this.GroupList.Count == 0)
				{
					this.CurGroup = ETermExplanationGroup.Default;
					return;
				}
				this.UseGroup(this.GroupList[this.GroupList.Count - 1].Item1);
				return;
			}
		}
		else
		{
			this.GroupList[num] = new ValueTuple<ETermExplanationGroup, int>(this.GroupList[num].Item1, num2);
		}
	}

	// Token: 0x06016403 RID: 91139 RVA: 0x0062A4C8 File Offset: 0x006286C8
	private void UseGroup(ETermExplanationGroup inGroup)
	{
		int num = -1;
		for (int i = 0; i < this.GroupList.Count; i++)
		{
			if (this.GroupList[i].Item1 == inGroup)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TermExplanation;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "术语解释组不存在: ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Group", inGroup);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.CurGroup = inGroup;
		ValueTuple<ETermExplanationGroup, int> item = this.GroupList[num];
		this.GroupList.RemoveAt(num);
		this.GroupList.Add(item);
	}

	// Token: 0x06016404 RID: 91140 RVA: 0x0062A568 File Offset: 0x00628768
	private List<TermTextRegistryHandle> GetHandlesByGroup(ETermExplanationGroup group, bool checkVisible = true)
	{
		List<TermTextRegistryHandle> list = new List<TermTextRegistryHandle>();
		foreach (KeyValuePair<int, TermTextRegistryHandle> keyValuePair in this.RegistryMap)
		{
			TermTextRegistryHandle value = keyValuePair.Value;
			if (value.Group == group && value.UiText != null && value.UiText.IsValid() && (!checkVisible || value.UiText.IsUIActiveInHierarchy()))
			{
				list.Add(value);
			}
		}
		list.Sort(delegate(TermTextRegistryHandle a, TermTextRegistryHandle b)
		{
			int num = a.Priority - b.Priority;
			if (num == 0)
			{
				return a.Id - b.Id;
			}
			return num;
		});
		return list;
	}

	// Token: 0x06016405 RID: 91141 RVA: 0x0062A620 File Offset: 0x00628820
	private int GetIdByUiText(UUIText uiText)
	{
		foreach (KeyValuePair<int, TermTextRegistryHandle> keyValuePair in this.RegistryMap)
		{
			if (keyValuePair.Value.UiText == uiText)
			{
				return keyValuePair.Key;
			}
		}
		return 0;
	}

	// Token: 0x06016406 RID: 91142 RVA: 0x0062A688 File Offset: 0x00628888
	private bool OpenTermExplanationViewImp(TermTextRegistryHandle handle, string hyperLinkId)
	{
		if (handle.ReportType != null)
		{
			this.ReportClickTermExplanation(handle.ReportType.Value);
		}
		if (!handle.Enable)
		{
			if (handle.OnDisableClick != null)
			{
				handle.OnDisableClick();
			}
			return true;
		}
		if (!this.IsHyperLinkValid(hyperLinkId))
		{
			return true;
		}
		handle.NeedHighlight = true;
		this.UseGroup(handle.Group);
		this.UsingHandle = handle;
		EUiViewName termViewName = this.GetTermViewName(handle);
		List<string> list = new List<string>();
		foreach (TermTextRegistryHandle termTextRegistryHandle in this.GetHandlesByGroup(this.CurGroup, true))
		{
			foreach (string text in this.ParseText2HyperLinkList(termTextRegistryHandle.UiText.text, false))
			{
				if (this.IsHyperLinkValid(text) || !Singleton<Info>.Instance.IsBuildShipping)
				{
					list.Add(text);
				}
			}
		}
		TermExplanationViewParam param = new TermExplanationViewParam
		{
			HyperLinkList = new List<string>(new HashSet<string>(list)),
			FocusedHyperLink = hyperLinkId
		};
		Singleton<UiManager>.Instance.OpenView(termViewName, param, null);
		Singleton<EventSystem>.Instance.Emit<ETermExplanationViewType>(EEventName.OnTermExplanationViewOpening, handle.Type);
		return true;
	}

	// Token: 0x06016407 RID: 91143 RVA: 0x0062A7F4 File Offset: 0x006289F4
	private List<string> ParseText2HyperLinkList(string text, bool unique = true)
	{
		MatchCollection matchCollection = new Regex("href\\s*=\\s*([\"]?)([^\"'\\s>]+)\\1", RegexOptions.IgnoreCase).Matches(text);
		List<string> list = new List<string>();
		foreach (object obj in matchCollection)
		{
			Match match = (Match)obj;
			if (match.Groups.Count > 2 && match.Groups[2].Success)
			{
				list.Add(match.Groups[2].Value);
			}
		}
		if (!unique)
		{
			return list;
		}
		return new List<string>(new HashSet<string>(list));
	}

	// Token: 0x06016408 RID: 91144 RVA: 0x0062A8A0 File Offset: 0x00628AA0
	private void OnViewOpen(TermTextRegistryHandle handle)
	{
		if (handle.AttachDir == ETermExplanationViewAttachDirection.None)
		{
			return;
		}
		if (handle.Type == ETermExplanationViewType.Side)
		{
			this.HandleSideViewAttach(handle);
		}
		else if (handle.Type == ETermExplanationViewType.Center)
		{
			this.HandleCenterViewAttach(handle);
		}
		this.HandleOffset(handle);
	}

	// Token: 0x06016409 RID: 91145 RVA: 0x0062A8D4 File Offset: 0x00628AD4
	private bool IsHyperLinkValid(string hyperLink)
	{
		int p0Id;
		if (!int.TryParse(hyperLink, out p0Id))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TermExplanation;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "超链接id无法转换为数字id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", hyperLink);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (ConfigTermConfigById.GetConfig(p0Id, true) == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.TermExplanation;
			ELogAuthor author2 = ELogAuthor.HYF;
			string message2 = "词条未在表s.术语中注册";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("词条", hyperLink);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		return true;
	}

	// Token: 0x0601640A RID: 91146 RVA: 0x0062A958 File Offset: 0x00628B58
	private void HandleSideViewAttach(TermTextRegistryHandle handle)
	{
		TermExplanationView termExplanationView = Singleton<UiManager>.Instance.GetView(handle.ViewId) as TermExplanationView;
		if (termExplanationView == null)
		{
			return;
		}
		if (handle.AttachDir != ETermExplanationViewAttachDirection.Left && handle.AttachDir != ETermExplanationViewAttachDirection.Right)
		{
			Singleton<Log>.Instance.Warn(ELogModule.TermExplanation, ELogAuthor.HYF, "界面吸附失败: 吸附方向与界面类型不匹配", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int num = (handle.AttachDir == ETermExplanationViewAttachDirection.Left) ? -1 : 1;
		UUIItem tipItem = termExplanationView.GetTipItem();
		FVector lguispaceAbsolutePosition = tipItem.GetLGUISpaceAbsolutePosition();
		UUIItem attachItem = handle.AttachItem;
		float num2 = attachItem.GetLGUISpaceAbsolutePosition().X;
		float x = attachItem.K2_GetComponentScale().X;
		float x2 = tipItem.K2_GetComponentScale().X;
		float x3 = attachItem.GetPivot().X;
		num2 += (0.5f - x3) * attachItem.Width * x;
		UUIItem uuiitem = tipItem;
		FVector fvector = new FVector(num2 + (float)num * (attachItem.Width * x + tipItem.Width * x2) / 2f, lguispaceAbsolutePosition.Y, lguispaceAbsolutePosition.Z);
		uuiitem.SetLGUISpaceAbsolutePosition(fvector);
	}

	// Token: 0x0601640B RID: 91147 RVA: 0x0062AA60 File Offset: 0x00628C60
	private void HandleCenterViewAttach(TermTextRegistryHandle handle)
	{
		TermExplanationView termExplanationView = Singleton<UiManager>.Instance.GetView(handle.ViewId) as TermExplanationView;
		if (termExplanationView == null)
		{
			return;
		}
		if (handle.AttachDir != ETermExplanationViewAttachDirection.Up && handle.AttachDir != ETermExplanationViewAttachDirection.Down)
		{
			Singleton<Log>.Instance.Warn(ELogModule.TermExplanation, ELogAuthor.HYF, "界面吸附失败: 吸附方向与界面类型不匹配", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int num = (handle.AttachDir == ETermExplanationViewAttachDirection.Up) ? 1 : -1;
		UUIItem tipItem = termExplanationView.GetTipItem();
		UUIItem parentAsUIItem = tipItem.GetParentAsUIItem();
		FVector lguispaceAbsolutePosition = parentAsUIItem.GetLGUISpaceAbsolutePosition();
		UUIItem attachItem = handle.AttachItem;
		float num2 = attachItem.GetLGUISpaceAbsolutePosition().Y;
		float y = attachItem.K2_GetComponentScale().Y;
		float y2 = tipItem.K2_GetComponentScale().Y;
		float y3 = attachItem.GetPivot().Y;
		num2 += (0.5f - y3) * attachItem.Height * y;
		FVector fvector = new FVector(lguispaceAbsolutePosition.X, num2 + (float)num * (attachItem.Height * y + tipItem.Height * y2) / 2f, lguispaceAbsolutePosition.Z);
		parentAsUIItem.SetLGUISpaceAbsolutePosition(fvector);
	}

	// Token: 0x0601640C RID: 91148 RVA: 0x0062AB70 File Offset: 0x00628D70
	private void HandleOffset(TermTextRegistryHandle handle)
	{
		TermExplanationView termExplanationView = Singleton<UiManager>.Instance.GetView(handle.ViewId) as TermExplanationView;
		if (termExplanationView == null)
		{
			return;
		}
		UUIItem tipItem = termExplanationView.GetTipItem();
		FVector lguispaceAbsolutePosition = tipItem.GetLGUISpaceAbsolutePosition();
		FVector fvector = new FVector(lguispaceAbsolutePosition.X + handle.Offset.Item1, lguispaceAbsolutePosition.Y + handle.Offset.Item2, lguispaceAbsolutePosition.Z);
		tipItem.SetLGUISpaceAbsolutePosition(fvector);
	}

	// Token: 0x0601640D RID: 91149 RVA: 0x0062ABDC File Offset: 0x00628DDC
	private EUiViewName GetTermViewName(TermTextRegistryHandle handle)
	{
		ETermExplanationViewType type = handle.Type;
		ETermExplanationViewStyle style = handle.Style;
		TermExplanationViewStyle? config = ConfigTermExplanationViewStyleById.GetConfig((int)style, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TermExplanation;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "术语解释风格化配置不存在: ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", style);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return this.Type2ViewName[type];
		}
		TermExplanationViewStyle value = config.Value;
		return (EUiViewName)((type == ETermExplanationViewType.Center) ? value.CenterView : value.SideView);
	}

	// Token: 0x0601640E RID: 91150 RVA: 0x0062AC64 File Offset: 0x00628E64
	private void ReportEnterViewWithTerms(ETermExplanationReportType type)
	{
		EnterViewWithTermsEvent enterViewWithTermsEvent = new EnterViewWithTermsEvent();
		enterViewWithTermsEvent.i_scene = (int)type;
		ControllerBase<LogReportController>.Instance.LogReport(enterViewWithTermsEvent);
	}

	// Token: 0x0601640F RID: 91151 RVA: 0x0062AC8C File Offset: 0x00628E8C
	private void ReportClickTermExplanation(ETermExplanationReportType type)
	{
		ClickTermExplanationEvent clickTermExplanationEvent = new ClickTermExplanationEvent();
		clickTermExplanationEvent.i_scene = (int)type;
		ControllerBase<LogReportController>.Instance.LogReport(clickTermExplanationEvent);
	}

	// Token: 0x06016410 RID: 91152 RVA: 0x0062ACB4 File Offset: 0x00628EB4
	private void OnTextChange(IReadOnlyList<int> changeList)
	{
		foreach (int key in changeList)
		{
			TermTextRegistryHandle termTextRegistryHandle;
			if (this.RegistryMap.TryGetValue(key, out termTextRegistryHandle) && this.ParseText2HyperLinkList(termTextRegistryHandle.UiText.text, true).Count > 0)
			{
				this.ReportEnterViewWithTerms(termTextRegistryHandle.ReportType.Value);
			}
		}
	}

	// Token: 0x06016411 RID: 91153 RVA: 0x0062AD30 File Offset: 0x00628F30
	private void OnTermExplanationViewClosed()
	{
		foreach (KeyValuePair<int, TermTextRegistryHandle> keyValuePair in this.RegistryMap)
		{
			TermTextRegistryHandle value = keyValuePair.Value;
			if (value.UiText != null && value.UiText.IsValid())
			{
				value.UiText.SetHyperLinksHoverSpiteActive(false);
				value.UiText.SetEnableHyperLinksHighlight(true);
			}
		}
	}

	// Token: 0x06016412 RID: 91154 RVA: 0x0062ADB4 File Offset: 0x00628FB4
	private void OnTermExplanationViewBeforeStart(int viewId)
	{
		if (this.UsingHandle == null)
		{
			return;
		}
		this.UsingHandle.ViewId = viewId;
		if (this.UsingHandle.NeedHighlight)
		{
			UUIText uiText = this.UsingHandle.UiText;
			if (uiText != null)
			{
				uiText.SetEnableHyperLinksHighlight(false);
			}
			UUIText uiText2 = this.UsingHandle.UiText;
			if (uiText2 != null)
			{
				uiText2.SetHyperLinksHoverSpiteActive(true);
			}
		}
		this.OnViewOpen(this.UsingHandle);
	}

	// Token: 0x06016413 RID: 91155 RVA: 0x0062AE1D File Offset: 0x0062901D
	private void OnResetToBattleView()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.TermExplanationSideView, null);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.TermExplanationCenterView, null);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.FloroRanchTermExplanationCenterView, null);
	}

	// Token: 0x0400AC13 RID: 44051
	private const int POOL_CAPACITY = 5;

	// Token: 0x0400AC14 RID: 44052
	private int RegistryId;

	// Token: 0x0400AC15 RID: 44053
	[Nullable(2)]
	private TermTextRegistryHandle UsingHandle;

	// Token: 0x0400AC16 RID: 44054
	private ETermExplanationGroup CurGroup;

	// Token: 0x0400AC17 RID: 44055
	[Nullable(new byte[]
	{
		1,
		0
	})]
	private readonly List<ValueTuple<ETermExplanationGroup, int>> GroupList = new List<ValueTuple<ETermExplanationGroup, int>>();

	// Token: 0x0400AC18 RID: 44056
	private readonly Dictionary<ETermExplanationViewType, EUiViewName> Type2ViewName = new Dictionary<ETermExplanationViewType, EUiViewName>
	{
		{
			ETermExplanationViewType.Center,
			EUiViewName.TermExplanationCenterView
		},
		{
			ETermExplanationViewType.Side,
			EUiViewName.TermExplanationSideView
		}
	};

	// Token: 0x0400AC19 RID: 44057
	private readonly Dictionary<int, TermTextRegistryHandle> RegistryMap = new Dictionary<int, TermTextRegistryHandle>();

	// Token: 0x0400AC1A RID: 44058
	private readonly Pool<TermTextRegistryHandle> HandlePool = new Pool<TermTextRegistryHandle>(5, () => new TermTextRegistryHandle(), delegate(TermTextRegistryHandle handle)
	{
		handle.Clear();
	});
}
