using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200225C RID: 8796
[NullableContext(2)]
[Nullable(0)]
public class MarqueeView : UiTickViewBase
{
	// Token: 0x06010970 RID: 67952 RVA: 0x00489168 File Offset: 0x00487368
	[NullableContext(1)]
	public MarqueeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010971 RID: 67953 RVA: 0x00489178 File Offset: 0x00487378
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite))
		};
	}

	// Token: 0x06010972 RID: 67954 RVA: 0x004891D2 File Offset: 0x004873D2
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnChangeLanguage));
	}

	// Token: 0x06010973 RID: 67955 RVA: 0x004891F0 File Offset: 0x004873F0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.OnChangeLanguage));
	}

	// Token: 0x06010974 RID: 67956 RVA: 0x0048920E File Offset: 0x0048740E
	[NullableContext(1)]
	private void OnChangeLanguage(string oldLang, string newLang)
	{
		if (ModelBase<MarqueeModel>.Instance.CurMarquee != null)
		{
			ModelBase<MarqueeModel>.Instance.CurMarquee.RefreshContent();
			this.RefreshText(ModelBase<MarqueeModel>.Instance.CurMarquee);
		}
	}

	// Token: 0x06010975 RID: 67957 RVA: 0x0048923C File Offset: 0x0048743C
	protected override void OnStart()
	{
		MarqueeData marqueeData = ModelBase<MarqueeModel>.Instance.PeekMarqueeData();
		if (marqueeData == null)
		{
			return;
		}
		ModelBase<MarqueeModel>.Instance.CurMarquee = marqueeData;
		this.TextContainer = base.GetItem(1);
		this.Text = base.GetText(0);
		this.RefreshText(marqueeData);
		this.Icon = base.GetSprite(2);
		this.InitOffsetX = (int)(this.TextContainer.GetWidth() / 2f + this.Icon.GetWidth());
		this.CurOffsetX = this.InitOffsetX;
		this.Text.SetAnchorOffsetX((float)this.CurOffsetX);
		this.Speed = ConfigCommonParamById.GetIntConfig("marquee_speed").Value;
	}

	// Token: 0x06010976 RID: 67958 RVA: 0x004892EC File Offset: 0x004874EC
	protected override void OnTick(float deltaTime)
	{
		MarqueeData curMarquee = ModelBase<MarqueeModel>.Instance.CurMarquee;
		if (curMarquee == null || !ControllerBase<MarqueeController>.Instance.CheckCurMarqueeValid(curMarquee))
		{
			ControllerBase<MarqueeController>.Instance.CloseMarqueeView(true);
			return;
		}
		if (!curMarquee.UseLocalTextKey)
		{
			string content = curMarquee.Content;
			MarqueeData currentMarqueeData = this.CurrentMarqueeData;
			if (content != ((currentMarqueeData != null) ? currentMarqueeData.Content : null))
			{
				this.RefreshText(curMarquee);
			}
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		MarqueeData nextMarquee = ModelBase<MarqueeModel>.Instance.GetNextMarquee();
		if (nextMarquee != null && nextMarquee.BeginTime <= serverTime)
		{
			Singleton<Log>.Instance.Info(ELogModule.Marquee, ELogAuthor.ZJC, "下一条跑马灯到播放时间", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<MarqueeController>.Instance.CloseMarqueeView(true);
			return;
		}
		if ((float)this.CurOffsetX < (float)this.InitOffsetX - this.TextContainer.GetWidth() - (this.Text.GetWidth() + this.Icon.GetWidth()) - 10f)
		{
			if (this.PerVisibleTime == null)
			{
				this.PerVisibleTime = new double?(serverTime);
			}
			double num = serverTime;
			double? num2 = this.PerVisibleTime + (double)curMarquee.ScrollInterval;
			if (!(num > num2.GetValueOrDefault() & num2 != null))
			{
				if (this.CurrentShowState)
				{
					UUIItem rootItem = this.RootItem;
					if (rootItem != null)
					{
						rootItem.SetUIActive(false);
					}
					this.CurrentShowState = false;
				}
				return;
			}
			this.CurOffsetX = this.InitOffsetX;
			this.Text.SetAnchorOffsetX((float)this.CurOffsetX);
			ModelBase<MarqueeModel>.Instance.UpdateMarqueeStorageDataByDate(curMarquee);
			this.PerVisibleTime = null;
			if (!this.CurrentShowState)
			{
				UUIItem rootItem2 = this.RootItem;
				if (rootItem2 != null)
				{
					rootItem2.SetUIActive(true);
				}
				this.CurrentShowState = true;
			}
		}
		this.CurOffsetX -= this.Speed;
		this.Text.SetAnchorOffsetX((float)this.CurOffsetX);
	}

	// Token: 0x06010977 RID: 67959 RVA: 0x004894D8 File Offset: 0x004876D8
	[NullableContext(1)]
	private void RefreshText(MarqueeData data)
	{
		this.CurrentMarqueeData = data;
		if (data.UseLocalTextKey)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.Text, data.LocalTextKey, Array.Empty<object>());
			return;
		}
		string text = data.Content.Replace("\r\n", " ");
		if (text.Contains("{EndTime}"))
		{
			int num = (int)Math.Ceiling(ModelBase<MarqueeModel>.Instance.GetMarqueeDataLeftTime(data) / 60.0);
			string text2 = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("ShopMinuteText"), null);
			text2 = text2.Replace("{0}", num.ToString());
			text = text.Replace("{EndTime}", text2);
		}
		this.Text.SetText(text, true);
	}

	// Token: 0x040082A0 RID: 33440
	private const int TARGETPOSITIONOFFSET = 10;

	// Token: 0x040082A1 RID: 33441
	private int InitOffsetX;

	// Token: 0x040082A2 RID: 33442
	private UUIText Text;

	// Token: 0x040082A3 RID: 33443
	private UUIItem TextContainer;

	// Token: 0x040082A4 RID: 33444
	private UUISprite Icon;

	// Token: 0x040082A5 RID: 33445
	private int CurOffsetX;

	// Token: 0x040082A6 RID: 33446
	private double? PerVisibleTime;

	// Token: 0x040082A7 RID: 33447
	private int Speed;

	// Token: 0x040082A8 RID: 33448
	private MarqueeData CurrentMarqueeData;

	// Token: 0x040082A9 RID: 33449
	private bool CurrentShowState = true;

	// Token: 0x02008524 RID: 34084
	[NullableContext(0)]
	private class EMarqueeChildCom
	{
		// Token: 0x0402D114 RID: 184596
		public const int Text = 0;

		// Token: 0x0402D115 RID: 184597
		public const int Container = 1;

		// Token: 0x0402D116 RID: 184598
		public const int Icon = 2;
	}
}
