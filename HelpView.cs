using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EBA RID: 7866
public class HelpView : UiViewBase, IExtraUiPopFrameType
{
	// Token: 0x0600E88F RID: 59535 RVA: 0x003EE259 File Offset: 0x003EC459
	[NullableContext(1)]
	public HelpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E890 RID: 59536 RVA: 0x003EE270 File Offset: 0x003EC470
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E891 RID: 59537 RVA: 0x003EE2FA File Offset: 0x003EC4FA
	protected override void OnStart()
	{
		base.GetItem(2).SetUIActive(false);
		this.Init();
	}

	// Token: 0x0600E892 RID: 59538 RVA: 0x003EE310 File Offset: 0x003EC510
	[NullableContext(2)]
	public EUiBehaviourPopType? GetExtraPopFrameType(object param)
	{
		if (param != null)
		{
			IReadOnlyList<HelpText> helpContentInfoByGroupId = ConfigBase<HelpConfig>.Instance.GetHelpContentInfoByGroupId((int)param);
			if (helpContentInfoByGroupId != null && helpContentInfoByGroupId.Count > 0)
			{
				return HelpStylizeDefine.helpStylizeType2PopFrameType[(EHelpStylizeType)helpContentInfoByGroupId[0].Style];
			}
		}
		return null;
	}

	// Token: 0x0600E893 RID: 59539 RVA: 0x003EE360 File Offset: 0x003EC560
	private void Init()
	{
		int groupId = (int)this.OpenParam;
		IReadOnlyList<HelpText> helpContentInfoByGroupId = ConfigBase<HelpConfig>.Instance.GetHelpContentInfoByGroupId(groupId);
		if (helpContentInfoByGroupId != null && helpContentInfoByGroupId.Count > 0)
		{
			base.GetText(0).ShowTextNew(helpContentInfoByGroupId[0].Title);
			int count = helpContentInfoByGroupId.Count;
			foreach (Paragraph paragraph in this.Paragraphs)
			{
				paragraph.SetActive(false);
			}
			UUIItem item = base.GetItem(2);
			UUIItem item2 = base.GetItem(1);
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				Paragraph paragraph2;
				if (num > this.Paragraphs.Count - 1)
				{
					paragraph2 = new Paragraph(Singleton<LguiUtil>.Instance.CopyItem(item, item2).GetOwner());
					this.Paragraphs.Add(paragraph2);
				}
				else
				{
					paragraph2 = this.Paragraphs[num];
				}
				paragraph2.Refresh(helpContentInfoByGroupId[i]);
				paragraph2.SetActive(true);
				num++;
			}
		}
	}

	// Token: 0x0400700C RID: 28684
	[Nullable(1)]
	private readonly List<Paragraph> Paragraphs = new List<Paragraph>();

	// Token: 0x020081FD RID: 33277
	private enum EHelpViewComponents
	{
		// Token: 0x0402C188 RID: 180616
		Title,
		// Token: 0x0402C189 RID: 180617
		Content,
		// Token: 0x0402C18A RID: 180618
		ParagraphItem
	}
}
