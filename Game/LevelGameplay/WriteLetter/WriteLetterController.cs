using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Letter;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.WriteLetter
{
	// Token: 0x02006A62 RID: 27234
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class WriteLetterController : ControllerBase<WriteLetterController>
	{
		// Token: 0x060435E1 RID: 275937 RVA: 0x01159D52 File Offset: 0x01157F52
		protected override bool OnInit()
		{
			this.OnRegisterNetEvent();
			return true;
		}

		// Token: 0x060435E2 RID: 275938 RVA: 0x01159D5B File Offset: 0x01157F5B
		protected override bool OnClear()
		{
			this.OnUnRegisterNetEvent();
			return true;
		}

		// Token: 0x060435E3 RID: 275939 RVA: 0x01159D64 File Offset: 0x01157F64
		protected void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<MiniWriteLetterLoginNotify>(ENotifyMessageId.MiniWriteLetterLoginNotify, new Action<MiniWriteLetterLoginNotify, Net.CallbackStatus>(this.OnMiniWriteLetterLoginNotify));
		}

		// Token: 0x060435E4 RID: 275940 RVA: 0x01159D82 File Offset: 0x01157F82
		protected void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MiniWriteLetterLoginNotify);
		}

		// Token: 0x060435E5 RID: 275941 RVA: 0x01159D94 File Offset: 0x01157F94
		public void OpenWriteLetter(IWriteLetter gameplayConfig)
		{
			WriteLetter? config = ConfigWriteLetterById.GetConfig(gameplayConfig.Id, true);
			if (config == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[WriteLetterController] 写信配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("WriteLetterId", gameplayConfig.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			string text = config.Value.Flow(0);
			string text2 = config.Value.Flow(1);
			string text3 = config.Value.Flow(2);
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Event;
				ELogAuthor author2 = ELogAuthor.YZH;
				string message2 = "[WriteLetterController] 写信配置Flow为空";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("WriteLetterId", gameplayConfig.Id);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			WriteLetterViewOpenParam writeLetterViewOpenParam = this.ParseWriteLetterFlowInfo(text, text2, text3);
			if (writeLetterViewOpenParam == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.Event;
				ELogAuthor author3 = ELogAuthor.YZH;
				string message3 = "[WriteLetterController] 写信Flow解析失败";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("WriteLetterId", gameplayConfig.Id);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return;
			}
			WriteLetterViewOpenParam param = new WriteLetterViewOpenParam
			{
				FlowListName = writeLetterViewOpenParam.FlowListName,
				FlowId = writeLetterViewOpenParam.FlowId,
				StateId = writeLetterViewOpenParam.StateId,
				LetterStyle = this.ParseWriteLetterStyle(config.Value.Style),
				GameplayId = gameplayConfig.Id.ToString(),
				LetterId = new int?(gameplayConfig.Id)
			};
			TsInteractionUtils.RegisterOpenViewName(EUiViewName.WriteLetterView);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WriteLetterView, param, null);
		}

		// Token: 0x060435E6 RID: 275942 RVA: 0x01159F34 File Offset: 0x01158134
		public bool OpenLetterBackupDisplayByConfig(int letterId, bool inPlot = false)
		{
			WriteLetter? config = ConfigWriteLetterById.GetConfig(letterId, true);
			if (config == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[WriteLetterController] 写信配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("WriteLetterId", letterId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			string text = config.Value.Flow(0);
			string text2 = config.Value.Flow(1);
			string text3 = config.Value.Flow(2);
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Event;
				ELogAuthor author2 = ELogAuthor.YZH;
				string message2 = "[WriteLetterController] 写信配置Flow为空";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("WriteLetterId", letterId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			WriteLetterViewOpenParam writeLetterViewOpenParam = this.ParseWriteLetterFlowInfo(text, text2, text3);
			if (writeLetterViewOpenParam == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.Event;
				ELogAuthor author3 = ELogAuthor.YZH;
				string message3 = "[WriteLetterController] 写信Flow解析失败";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("WriteLetterId", letterId);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return false;
			}
			List<ITalkItem> items = this.CollectDisplayTalkItems(writeLetterViewOpenParam.FlowListName, writeLetterViewOpenParam.FlowId, writeLetterViewOpenParam.StateId);
			LetterBackupDisplayViewOpenParam param = new LetterBackupDisplayViewOpenParam
			{
				LetterId = letterId,
				Items = items,
				LetterStyle = new ELetterStyle?(this.ParseWriteLetterStyle(config.Value.Style))
			};
			if (inPlot)
			{
				Singleton<UiManager>.Instance.OpenViewByPlot(EUiViewName.LetterBackupDisplayView, param, null);
			}
			else
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.LetterBackupDisplayView, param, null);
			}
			return true;
		}

		// Token: 0x060435E7 RID: 275943 RVA: 0x0115A0B4 File Offset: 0x011582B4
		public ELetterStyle GetLetterStyleByLetterId(int letterId)
		{
			WriteLetter? config = ConfigWriteLetterById.GetConfig(letterId, true);
			if (config == null)
			{
				return ELetterStyle.A;
			}
			return this.ParseWriteLetterStyle(config.Value.Style);
		}

		// Token: 0x060435E8 RID: 275944 RVA: 0x0115A0EC File Offset: 0x011582EC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ITalkItem> CollectDisplayTalkItemsByLetterId(int letterId)
		{
			WriteLetter? config = ConfigWriteLetterById.GetConfig(letterId, true);
			if (config == null)
			{
				return null;
			}
			string text = config.Value.Flow(0);
			string text2 = config.Value.Flow(1);
			string text3 = config.Value.Flow(2);
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3))
			{
				return null;
			}
			WriteLetterViewOpenParam writeLetterViewOpenParam = this.ParseWriteLetterFlowInfo(text, text2, text3);
			if (writeLetterViewOpenParam == null)
			{
				return null;
			}
			return this.CollectDisplayTalkItems(writeLetterViewOpenParam.FlowListName, writeLetterViewOpenParam.FlowId, writeLetterViewOpenParam.StateId);
		}

		// Token: 0x060435E9 RID: 275945 RVA: 0x0115A188 File Offset: 0x01158388
		private List<ITalkItem> CollectDisplayTalkItems(string flowListName, int flowId, int stateId)
		{
			List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(flowListName, flowId, stateId);
			if (flowStateActions == null)
			{
				return new List<ITalkItem>();
			}
			List<ITalkItem> list = new List<ITalkItem>();
			foreach (ActionInfo actionInfo in flowStateActions)
			{
				if (actionInfo.Name == EAction.ShowTalk)
				{
					ShowTalk showTalk = actionInfo.Params as ShowTalk;
					if (showTalk != null)
					{
						foreach (ITalkItem talkItem in (showTalk.TalkItems ?? new List<ITalkItem>()))
						{
							List<ITalkOption> options = talkItem.Options;
							if (((options != null) ? options.Count : 0) <= 0)
							{
								ITalkItemDialog talkItemDialog = talkItem as ITalkItemDialog;
								bool flag;
								if (talkItemDialog == null)
								{
									flag = false;
								}
								else
								{
									ITalkItemStyle style = talkItemDialog.Style;
									ETalkItemStyle? etalkItemStyle = (style != null) ? new ETalkItemStyle?(style.Type) : null;
									ETalkItemStyle etalkItemStyle2 = ETalkItemStyle.InnerVoice;
									flag = (etalkItemStyle.GetValueOrDefault() == etalkItemStyle2 & etalkItemStyle != null);
								}
								if (!flag)
								{
									list.Add(talkItem);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060435EA RID: 275946 RVA: 0x0115A2C0 File Offset: 0x011584C0
		public void RequestWriteLetterComplete(string gameplayId)
		{
			UiGamePlayRequest uiGamePlayRequest = UiGamePlayRequest.Create();
			uiGamePlayRequest.GamePlayKey = gameplayId;
			uiGamePlayRequest.Type = UiGamePlayType.WriteLetter;
			Singleton<Net>.Instance.Call<UiGamePlayResponse>(ERequestMessageId.UiGamePlayRequest, uiGamePlayRequest, null, 0);
		}

		// Token: 0x060435EB RID: 275947 RVA: 0x0115A2F4 File Offset: 0x011584F4
		public void RecordWriteLetterContent(int letterId, ITalkItem talkItem)
		{
			WriteLetterModel instance = ModelBase<WriteLetterModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.RecordLetterContent(letterId, talkItem);
		}

		// Token: 0x060435EC RID: 275948 RVA: 0x0115A314 File Offset: 0x01158514
		public unsafe void RequestWriteLetterSaveContent(int letterId)
		{
			WriteLetterModel instance = ModelBase<WriteLetterModel>.Instance;
			if (instance == null || !instance.HasLetterContent(letterId))
			{
				return;
			}
			MiniLetterContentPb letterContentPb = instance.GetLetterContentPb(letterId);
			if (letterContentPb == null)
			{
				return;
			}
			MiniWriteLetterSaveContentRequest miniWriteLetterSaveContentRequest = MiniWriteLetterSaveContentRequest.Create();
			miniWriteLetterSaveContentRequest.LetterContent.Add(letterContentPb);
			Singleton<Net>.Instance.Call<MiniWriteLetterSaveContentResponse>(ERequestMessageId.MiniWriteLetterSaveContentRequest, miniWriteLetterSaveContentRequest, delegate(MiniWriteLetterSaveContentResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.ErrorId == Aki.Protocol.ErrorCode.Success)
				{
					return;
				}
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[WriteLetterController] 保存信件内容失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LetterId", letterId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ErrorId", response.ErrorId);
				instance2.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}, 0);
		}

		// Token: 0x060435ED RID: 275949 RVA: 0x0115A386 File Offset: 0x01158586
		[NullableContext(2)]
		private void OnMiniWriteLetterLoginNotify(MiniWriteLetterLoginNotify message, Net.CallbackStatus status)
		{
			if (message == null)
			{
				return;
			}
			WriteLetterModel instance = ModelBase<WriteLetterModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SetLetterContentsFromProto(message.LetterContent);
		}

		// Token: 0x060435EE RID: 275950 RVA: 0x0115A3A4 File Offset: 0x011585A4
		private ELetterStyle ParseWriteLetterStyle(string style)
		{
			string a = style.Trim();
			if (a == "Rover")
			{
				return ELetterStyle.A;
			}
			if (a == "Yangyang")
			{
				return ELetterStyle.B;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Event;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[WriteLetterController] 未识别的Style，回退A";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Style", style);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return ELetterStyle.A;
		}

		// Token: 0x060435EF RID: 275951 RVA: 0x0115A400 File Offset: 0x01158600
		[return: Nullable(2)]
		private WriteLetterViewOpenParam ParseWriteLetterFlowInfo(string flowListNameRaw, string flowIdRaw, string stateIdRaw)
		{
			string text = flowListNameRaw.Trim();
			int flowId;
			int stateId;
			if (string.IsNullOrEmpty(text) || !int.TryParse(flowIdRaw, out flowId) || !int.TryParse(stateIdRaw, out stateId))
			{
				return null;
			}
			return new WriteLetterViewOpenParam
			{
				FlowListName = text,
				FlowId = flowId,
				StateId = stateId,
				LetterStyle = ELetterStyle.A
			};
		}
	}
}
