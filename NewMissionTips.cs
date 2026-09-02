using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002666 RID: 9830
[NullableContext(1)]
[Nullable(0)]
public class NewMissionTips : UiTickViewBase
{
	// Token: 0x060135C3 RID: 79299 RVA: 0x0056334C File Offset: 0x0056154C
	public NewMissionTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060135C4 RID: 79300 RVA: 0x00563378 File Offset: 0x00561578
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060135C5 RID: 79301 RVA: 0x005633E4 File Offset: 0x005615E4
	protected override void OnBeforeCreate()
	{
		base.OnBeforeCreate();
		object openParam = this.OpenParam;
		if (openParam is int)
		{
			int num = (int)openParam;
			Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(num);
			if (quest == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Quest;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "Quest:NewMissionTips.OnBeforeCreate 找不到任务";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.CloseMe(null);
				return;
			}
			this.MarkIconPath = (ConfigBase<QuestNewConfig>.Instance.GetQuestTypeMark(quest.QuestMarkId) ?? "");
			this.QuestNameTid = quest.NameKey;
			this.RemainTime = (float)ConfigBase<QuestNewConfig>.Instance.GetNewTipsShowTime((int)quest.Type).GetValueOrDefault();
		}
	}

	// Token: 0x060135C6 RID: 79302 RVA: 0x005634A0 File Offset: 0x005616A0
	protected override void OnStart()
	{
		base.OnStart();
		UUISprite sprite = base.GetSprite(1);
		if (sprite != null && !StringUtils.IsBlank(this.MarkIconPath))
		{
			this.SetSpriteByPath(this.MarkIconPath, sprite, false, null, null);
			sprite.SetUIActive(true);
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.OnSelfLanguageChange.Bind(new Action(this.UpdateQuestNameText));
			this.UpdateQuestNameText();
			text.SetUIActive(true);
		}
	}

	// Token: 0x060135C7 RID: 79303 RVA: 0x0056351C File Offset: 0x0056171C
	private void UpdateQuestNameText()
	{
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.QuestNameTid);
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetText(configTextByKey, true);
	}

	// Token: 0x060135C8 RID: 79304 RVA: 0x00563550 File Offset: 0x00561750
	protected override void OnTick(float delta)
	{
		this.RemainTime = Math.Max(this.RemainTime - delta / 1000f * Singleton<Time>.Instance.TimeDilation, 0f);
		if (this.RemainTime <= 0f && !this.CloseCalled)
		{
			this.CloseView();
		}
	}

	// Token: 0x060135C9 RID: 79305 RVA: 0x005635A1 File Offset: 0x005617A1
	private void CloseView()
	{
		this.CloseCalled = true;
		base.CloseMe(null);
	}

	// Token: 0x04009722 RID: 38690
	private string MarkIconPath = "";

	// Token: 0x04009723 RID: 38691
	private string QuestNameTid = "";

	// Token: 0x04009724 RID: 38692
	private float RemainTime = 5f;

	// Token: 0x04009725 RID: 38693
	private bool CloseCalled;

	// Token: 0x020089F8 RID: 35320
	[NullableContext(0)]
	private class EChildComponent
	{
		// Token: 0x0402E892 RID: 190610
		public const int QuestNameText = 0;

		// Token: 0x0402E893 RID: 190611
		public const int Icon = 1;
	}
}
