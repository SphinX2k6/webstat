using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt
{
	// Token: 0x02005CA3 RID: 23715
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class GenericPromptController : UiControllerBase<GenericPromptController>
	{
		// Token: 0x0603BDC4 RID: 245188 RVA: 0x00F2C184 File Offset: 0x00F2A384
		public void ShowPromptByCode(string promptId, params object[] param)
		{
			GenericPrompt? promptInfoByRawId = ConfigBase<GenericPromptConfig>.Instance.GetPromptInfoByRawId(promptId);
			if (promptInfoByRawId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GenericPrompt;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "配置不存在，请检查\"t.通用提示.xlsx\"";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", promptId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			TableTextArgNew promptMainTextObjByRawId = ConfigBase<GenericPromptConfig>.Instance.GetPromptMainTextObjByRawId(promptId);
			this.ShowPromptByItsType<object>((EPromptSubViewType)promptInfoByRawId.Value.TypeId, promptMainTextObjByRawId, null, param, null, null, null, null, null, false, null);
		}

		// Token: 0x0603BDC5 RID: 245189 RVA: 0x00F2C20C File Offset: 0x00F2A40C
		public void ShowPromptByCodeWithCallback(string promptId, Action callback, params object[] param)
		{
			GenericPrompt? promptInfoByRawId = ConfigBase<GenericPromptConfig>.Instance.GetPromptInfoByRawId(promptId);
			if (promptInfoByRawId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GenericPrompt;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "配置不存在，请检查\"t.通用提示.xlsx\"";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", promptId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			TableTextArgNew promptMainTextObjByRawId = ConfigBase<GenericPromptConfig>.Instance.GetPromptMainTextObjByRawId(promptId);
			this.ShowPromptByItsType<object>((EPromptSubViewType)promptInfoByRawId.Value.TypeId, promptMainTextObjByRawId, null, param, null, new int?(int.Parse(promptId)), callback, null, null, false, null);
		}

		// Token: 0x0603BDC6 RID: 245190 RVA: 0x00F2C294 File Offset: 0x00F2A494
		[NullableContext(2)]
		public void ShowPromptByItsType(EPromptSubViewType typeId, TableTextArgNew mainTextObj = null, TableTextArgNew extraTextObj = null, [Nullable(new byte[]
		{
			2,
			1
		})] object[] mainTextParams = null, [Nullable(new byte[]
		{
			2,
			1
		})] object[] extraTextParams = null, int? promptId = null, Action callback = null)
		{
			this.ShowPromptByItsType<object>(typeId, mainTextObj, extraTextObj, mainTextParams, extraTextParams, promptId, callback, null, null, false, null);
		}

		// Token: 0x0603BDC7 RID: 245191 RVA: 0x00F2C2C0 File Offset: 0x00F2A4C0
		[NullableContext(2)]
		public void ShowPromptByItsType<T>(EPromptSubViewType typeId, TableTextArgNew mainTextObj = null, TableTextArgNew extraTextObj = null, [Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<object> mainTextParams = null, [Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<object> extraTextParams = null, int? promptId = null, Action callback = null, T extraParam = default(T), int? duration = null, bool inPlot = false, string promptKey = null)
		{
			PromptParamHub<T> promptParamHub = new PromptParamHub<T>();
			promptParamHub.TypeId = (int)typeId;
			promptParamHub.PromptId = promptId;
			promptParamHub.MainTextObj = mainTextObj;
			promptParamHub.ExtraTextObj = extraTextObj;
			promptParamHub.MainTextParams = mainTextParams;
			promptParamHub.ExtraTextParams = extraTextParams;
			promptParamHub.CloseCallback = callback;
			int? num = duration;
			promptParamHub.Duration = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			promptParamHub.ExtraParam = extraParam;
			promptParamHub.PromptKey = promptKey;
			PromptParamHub<T> promptParamHub2 = promptParamHub;
			if (typeId == EPromptSubViewType.FloatLinePrompt)
			{
				ModelBase<GenericPromptModel>.Instance.ApplyPromptParamHub(promptParamHub2);
				return;
			}
			EUiViewName name;
			if (!GenericPromptDefine.genericPromptView.TryGetValue((int)typeId, out name))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GenericPrompt;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "genericPromptView 缺少映射";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TypeId", (int)typeId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (inPlot)
			{
				Singleton<UiManager>.Instance.OpenViewByPlot(name, promptParamHub2, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(name, promptParamHub2, null);
		}

		// Token: 0x0603BDC8 RID: 245192 RVA: 0x00F2C3B0 File Offset: 0x00F2A5B0
		public EUiViewName? GetViewNameByPromptId(string promptId)
		{
			GenericPrompt? promptInfoByRawId = ConfigBase<GenericPromptConfig>.Instance.GetPromptInfoByRawId(promptId);
			if (promptInfoByRawId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GenericPrompt;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "配置不存在，请检查\"t.通用提示.xlsx\"";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", promptId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			EUiViewName value;
			if (!GenericPromptDefine.genericPromptView.TryGetValue(promptInfoByRawId.Value.TypeId, out value))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.GenericPrompt;
				ELogAuthor author2 = ELogAuthor.HYF;
				string message2 = "genericPromptView 缺少映射";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("TypeId", promptInfoByRawId.Value.TypeId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			return new EUiViewName?(value);
		}

		// Token: 0x0603BDC9 RID: 245193 RVA: 0x00F2C46E File Offset: 0x00F2A66E
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UiManagerInit, new Action(this.CreateGenericPromptView));
			Singleton<EventSystem>.Instance.Add(EEventName.AfterLoadMap, new Action(this.CreateGenericPromptView));
		}

		// Token: 0x0603BDCA RID: 245194 RVA: 0x00F2C4A5 File Offset: 0x00F2A6A5
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UiManagerInit, new Action(this.CreateGenericPromptView));
			Singleton<EventSystem>.Instance.Remove(EEventName.AfterLoadMap, new Action(this.CreateGenericPromptView));
		}

		// Token: 0x0603BDCB RID: 245195 RVA: 0x00F2C4DC File Offset: 0x00F2A6DC
		private void CreateGenericPromptView()
		{
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GenericPromptView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GenericPromptView, null, null);
			}
		}

		// Token: 0x0603BDCC RID: 245196 RVA: 0x00F2C500 File Offset: 0x00F2A700
		public static void CancelPromptByPromptKey(string promptKey)
		{
			ModelBase<GenericPromptModel>.Instance.RemovePromptParamHubByKey(promptKey);
		}
	}
}
