using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A7D RID: 6781
public class CommunicateView : UiTickViewBase
{
	// Token: 0x0600C217 RID: 49687 RVA: 0x00332374 File Offset: 0x00330574
	[NullableContext(1)]
	public CommunicateView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C218 RID: 49688 RVA: 0x00332380 File Offset: 0x00330580
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.ReceiveCommunicate))
		};
	}

	// Token: 0x0600C219 RID: 49689 RVA: 0x00332458 File Offset: 0x00330658
	protected override void OnStart()
	{
		UUIText text = base.GetText(4);
		text.SetRichText(true);
		text.SetHeight(100f);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "QuestCommunicateConnect", Array.Empty<object>());
		this.ConfigCloseTime = ConfigCommonParamById.GetIntConfig("CommunicateViewCloseTime").Value;
		this.RemainStayTime = (float)this.ConfigCloseTime;
		this.CountDownItem = new GuideCountDownItem((float)this.ConfigCloseTime);
		this.CountDownItem.Init(base.GetItem(0));
		this.CommunicateId = (this.OpenParam as int?).GetValueOrDefault();
		if (this.CommunicateId == 0)
		{
			return;
		}
		Communicate? config = ConfigCommunicateById.GetConfig(this.CommunicateId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到通讯配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("communicateId", this.CommunicateId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Speaker? config2 = ConfigSpeakerById.GetConfig(config.Value.Talker, true);
		if (config2 == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Quest;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "找不到通讯对话人配置";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("talkerId", config.Value.Talker);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		this.SetCallContent(config2.Value);
		this.SetHeadTexture(config2.Value);
	}

	// Token: 0x0600C21A RID: 49690 RVA: 0x003325C4 File Offset: 0x003307C4
	private void SetCallContent(Speaker speaker)
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("QuestCommunicateRequest");
		UUIText text = base.GetText(1);
		string configTextByTable = Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, new int?(speaker.Id));
		text.SetText("【" + configTextByTable + "】" + textById, true);
	}

	// Token: 0x0600C21B RID: 49691 RVA: 0x00332618 File Offset: 0x00330818
	private void SetHeadTexture(Speaker speaker)
	{
		UUITexture texture = base.GetTexture(2);
		base.SetTextureByPath(speaker.HeadIconAsset, texture, null, null);
	}

	// Token: 0x0600C21C RID: 49692 RVA: 0x00332648 File Offset: 0x00330848
	protected override void OnTick(float delta)
	{
		if (!this.RootItem.bIsUIActive)
		{
			return;
		}
		if (this.RemainStayTime <= 0f && !this.CountDownTrigger)
		{
			this.CountDownTrigger = true;
			this.CloseView(null);
			return;
		}
		this.RemainStayTime -= delta;
		this.CountDownItem.OnDurationChange(this.RemainStayTime);
	}

	// Token: 0x0600C21D RID: 49693 RVA: 0x003326A6 File Offset: 0x003308A6
	private void ReceiveCommunicate()
	{
		this.CloseView(delegate(bool success)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.CommunicateFinished, this.CommunicateId);
		});
	}

	// Token: 0x0600C21E RID: 49694 RVA: 0x003326BA File Offset: 0x003308BA
	[NullableContext(2)]
	private void CloseView(Action<bool> closeCallback = null)
	{
		base.CloseMe(closeCallback);
	}

	// Token: 0x04005AF1 RID: 23281
	[Nullable(2)]
	private GuideCountDownItem CountDownItem;

	// Token: 0x04005AF2 RID: 23282
	private int ConfigCloseTime;

	// Token: 0x04005AF3 RID: 23283
	private float RemainStayTime;

	// Token: 0x04005AF4 RID: 23284
	private bool CountDownTrigger;

	// Token: 0x04005AF5 RID: 23285
	private int CommunicateId;

	// Token: 0x02007D30 RID: 32048
	private static class EChildComponent
	{
		// Token: 0x0402AACA RID: 174794
		public const int CountDownItem = 0;

		// Token: 0x0402AACB RID: 174795
		public const int CallContentText = 1;

		// Token: 0x0402AACC RID: 174796
		public const int HeadTexture = 2;

		// Token: 0x0402AACD RID: 174797
		public const int ConnectItem = 3;

		// Token: 0x0402AACE RID: 174798
		public const int ConnectText = 4;

		// Token: 0x0402AACF RID: 174799
		public const int ReceiveBtn = 5;

		// Token: 0x0402AAD0 RID: 174800
		public const int CountDownParent = 6;
	}
}
