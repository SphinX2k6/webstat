using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200289A RID: 10394
public class RoleLevelUpSuccessEffectView : UiViewBase
{
	// Token: 0x06014952 RID: 84306 RVA: 0x005B2EF5 File Offset: 0x005B10F5
	[NullableContext(1)]
	public RoleLevelUpSuccessEffectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014953 RID: 84307 RVA: 0x005B2F00 File Offset: 0x005B1100
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickButton)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickButton))
		};
	}

	// Token: 0x06014954 RID: 84308 RVA: 0x005B2FD8 File Offset: 0x005B11D8
	protected override void OnBeforeCreate()
	{
		if (this.OpenParam == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.YYZ, "RoleLevelUpSuccessEffectView 打开失败,未传入界面数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.Data = (ILevelUpSuccessEffectData)this.OpenParam;
		this.SetAudioInternal();
	}

	// Token: 0x06014955 RID: 84309 RVA: 0x005B3024 File Offset: 0x005B1224
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(1);
		this.EffectTextLayout = new GenericScrollViewNew<SuccessDescriptionItem, SingleText>(base.GetScrollViewWithScrollbar(0), new Func<SuccessDescriptionItem>(this.CreateTextItem), item.GetOwner() as AUIBaseActor, false, null);
	}

	// Token: 0x06014956 RID: 84310 RVA: 0x005B3064 File Offset: 0x005B1264
	protected override void OnBeforeShow()
	{
		this.SetTitleInternal();
		this.SetViewContentInternal();
		this.SetTipsTextInternal();
	}

	// Token: 0x06014957 RID: 84311 RVA: 0x005B3078 File Offset: 0x005B1278
	private void SetAudioInternal()
	{
		string audioId = this.Data.AudioId;
		if (audioId != null)
		{
			string path = ConfigBase<AudioConfig>.Instance.GetAudioPath(audioId).Value.Path;
			base.SetAudioEvent(path);
		}
	}

	// Token: 0x06014958 RID: 84312 RVA: 0x005B30B8 File Offset: 0x005B12B8
	private void OnClickButton()
	{
		Action clickFunction = this.Data.ClickFunction;
		if (clickFunction != null)
		{
			clickFunction();
		}
		base.CloseMe(null);
	}

	// Token: 0x06014959 RID: 84313 RVA: 0x005B30E1 File Offset: 0x005B12E1
	[NullableContext(1)]
	private SuccessDescriptionItem CreateTextItem()
	{
		return new SuccessDescriptionItem();
	}

	// Token: 0x0601495A RID: 84314 RVA: 0x005B30E8 File Offset: 0x005B12E8
	private void SetTipsTextInternal()
	{
		string key = this.Data.ClickText ?? "Text_BackToView_Text";
		base.GetText(3).ShowTextNew(key);
	}

	// Token: 0x0601495B RID: 84315 RVA: 0x005B3118 File Offset: 0x005B1318
	private void SetTitleInternal()
	{
		string key = this.Data.Title ?? "Text_ActivedSucceed_Text";
		base.GetText(2).ShowTextNew(key);
	}

	// Token: 0x0601495C RID: 84316 RVA: 0x005B3148 File Offset: 0x005B1348
	private void SetViewContentInternal()
	{
		if (this.EffectTextLayout != null)
		{
			List<SingleText> textList = this.Data.TextList;
			if (textList != null)
			{
				this.EffectTextLayout.RefreshByData(textList, null, false);
				return;
			}
			base.GetScrollViewWithScrollbar(0).RootUIComp.Get().SetUIActive(false);
		}
	}

	// Token: 0x04009F1F RID: 40735
	[Nullable(2)]
	private ILevelUpSuccessEffectData Data;

	// Token: 0x04009F20 RID: 40736
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<SuccessDescriptionItem, SingleText> EffectTextLayout;

	// Token: 0x02008BDF RID: 35807
	public enum ERoleSuccessEffectNode
	{
		// Token: 0x0402F1FF RID: 193023
		TextScrollLayout,
		// Token: 0x0402F200 RID: 193024
		TextItem,
		// Token: 0x0402F201 RID: 193025
		Title,
		// Token: 0x0402F202 RID: 193026
		TipsText,
		// Token: 0x0402F203 RID: 193027
		TipsButton,
		// Token: 0x0402F204 RID: 193028
		TipsButton2
	}
}
