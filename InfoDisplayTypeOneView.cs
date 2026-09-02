using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002003 RID: 8195
public class InfoDisplayTypeOneView : UiTickViewBase
{
	// Token: 0x0600F782 RID: 63362 RVA: 0x0043C40B File Offset: 0x0043A60B
	[NullableContext(1)]
	public InfoDisplayTypeOneView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F783 RID: 63363 RVA: 0x0043C414 File Offset: 0x0043A614
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITextureTransitionComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickInformationDetailBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickCloseBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickSwitchLeftBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickSwitchRightBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F784 RID: 63364 RVA: 0x0043C6B8 File Offset: 0x0043A8B8
	protected override void OnStart()
	{
		this.AudioPlayer = new InfoDisplayAudioPlayer();
		UUIItem item = base.GetItem(8);
		if (((item != null) ? item.GetOwner() : null) == null)
		{
			return;
		}
		this.AudioPlayer.Initialize(item.GetOwner());
		UUIText text = base.GetText(6);
		if (text != null)
		{
			this.AudioPlayer.SetShowTextComponent(text);
		}
		int id = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		this.RefreshElement(id);
		this.AudioPlayer.Refresh(ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayAudio(id));
		this.RefreshPageSwitch();
	}

	// Token: 0x0600F785 RID: 63365 RVA: 0x0043C73E File Offset: 0x0043A93E
	private void RefreshElement(int id)
	{
		this.RefreshShowImg(id);
		this.RefreshShowText(id);
		this.RefreshAudioShow(id);
	}

	// Token: 0x0600F786 RID: 63366 RVA: 0x0043C758 File Offset: 0x0043A958
	private void RefreshShowImg(int id)
	{
		string[] infoDisplayPictures = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayPictures(id);
		if (infoDisplayPictures != null && infoDisplayPictures.Length != 0)
		{
			string text = infoDisplayPictures[0];
			if (text != "")
			{
				UUITextureTransitionComponent tempTexture = base.GetUiTextureTransitionComponent(1);
				if (tempTexture != null)
				{
					Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(text, delegate([Nullable(2)] UTexture texture, string path)
					{
						if (texture != null && texture.IsValid() && tempTexture != null && tempTexture.IsValid())
						{
							tempTexture.SetAllStateTexture(texture);
							UUITexture texture2 = this.GetTexture(10);
							if (texture2 != null)
							{
								texture2.SetTexture(texture);
								texture2.SetSizeFromTexture();
							}
						}
					}, 100, this.MemoryTag);
				}
			}
		}
	}

	// Token: 0x0600F787 RID: 63367 RVA: 0x0043C7CC File Offset: 0x0043A9CC
	private void RefreshShowText(int id)
	{
		string infoDisplayTitle = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayTitle(id);
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(infoDisplayTitle, true);
		}
		string infoDisplayDesc = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayDesc(id);
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.SetText(infoDisplayDesc, true);
		}
	}

	// Token: 0x0600F788 RID: 63368 RVA: 0x0043C818 File Offset: 0x0043AA18
	private void RefreshAudioShow(int id)
	{
		string infoDisplayAudio = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayAudio(id);
		UUIItem item = base.GetItem(8);
		UUIItem item2 = base.GetItem(9);
		if (infoDisplayAudio != "")
		{
			if (item != null)
			{
				item.SetUIActive(true);
			}
			if (item2 != null)
			{
				item2.SetUIActive(true);
				return;
			}
		}
		else
		{
			if (item != null)
			{
				item.SetUIActive(false);
			}
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
	}

	// Token: 0x0600F789 RID: 63369 RVA: 0x0043C876 File Offset: 0x0043AA76
	protected override void OnTick(float delta)
	{
		InfoDisplayAudioPlayer audioPlayer = this.AudioPlayer;
		if (audioPlayer == null)
		{
			return;
		}
		audioPlayer.OnTick(delta);
	}

	// Token: 0x0600F78A RID: 63370 RVA: 0x0043C88C File Offset: 0x0043AA8C
	protected override void OnBeforeDestroy()
	{
		InfoDisplayAudioPlayer audioPlayer = this.AudioPlayer;
		if (audioPlayer != null)
		{
			audioPlayer.Destroy(null);
		}
		int displayId = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		ControllerBase<InfoDisplayController>.Instance.RequestReadDisplayInfo(displayId);
	}

	// Token: 0x0600F78B RID: 63371 RVA: 0x0043C8C1 File Offset: 0x0043AAC1
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F78C RID: 63372 RVA: 0x0043C8CA File Offset: 0x0043AACA
	private void OnClickSwitchLeftBtn()
	{
		this.SwitchGroupPage(-1);
	}

	// Token: 0x0600F78D RID: 63373 RVA: 0x0043C8D3 File Offset: 0x0043AAD3
	private void OnClickSwitchRightBtn()
	{
		this.SwitchGroupPage(1);
	}

	// Token: 0x0600F78E RID: 63374 RVA: 0x0043C8DC File Offset: 0x0043AADC
	private void SwitchGroupPage(int offset)
	{
		InfoDisplayModel instance = ModelBase<InfoDisplayModel>.Instance;
		int groupPageIndex = instance.GetGroupPageIndex() + offset;
		int displayId = instance.CurrentInformationId();
		if (!instance.SetGroupPageIndex(groupPageIndex))
		{
			return;
		}
		ControllerBase<InfoDisplayController>.Instance.RequestReadDisplayInfo(displayId);
		int id = instance.CurrentInformationId();
		this.RefreshElement(id);
		InfoDisplayAudioPlayer audioPlayer = this.AudioPlayer;
		if (audioPlayer != null)
		{
			audioPlayer.Refresh(ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayAudio(id));
		}
		this.RefreshPageSwitch();
	}

	// Token: 0x0600F78F RID: 63375 RVA: 0x0043C948 File Offset: 0x0043AB48
	private void RefreshPageSwitch()
	{
		InfoDisplayModel instance = ModelBase<InfoDisplayModel>.Instance;
		bool flag = instance.IsInGroupMode();
		int groupPageIndex = instance.GetGroupPageIndex();
		int groupPageCount = instance.GetGroupPageCount();
		UUIButtonComponent button = base.GetButton(11);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag && groupPageIndex > 0);
		}
		UUIButtonComponent button2 = base.GetButton(12);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(flag && groupPageIndex < groupPageCount - 1);
		}
		UUIText text = base.GetText(13);
		if (text != null)
		{
			text.SetUIActive(flag);
		}
		if (flag && text != null)
		{
			UUIText uuitext = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(groupPageIndex + 1);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(groupPageCount);
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
	}

	// Token: 0x0600F790 RID: 63376 RVA: 0x0043CA14 File Offset: 0x0043AC14
	private void OnClickInformationDetailBtn()
	{
		int id = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		string[] infoDisplayPictures = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayPictures(id);
		if (infoDisplayPictures != null && infoDisplayPictures.Length != 0)
		{
			ModelBase<InfoDisplayModel>.Instance.SetCurrentOpenInformationTexture(infoDisplayPictures[0]);
			ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplayImgView();
		}
	}

	// Token: 0x0600F791 RID: 63377 RVA: 0x0043CA58 File Offset: 0x0043AC58
	protected override UniTask OnBeforeHideAsync()
	{
		InfoDisplayTypeOneView.<OnBeforeHideAsync>d__17 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<InfoDisplayTypeOneView.<OnBeforeHideAsync>d__17>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400778C RID: 30604
	[Nullable(2)]
	private InfoDisplayAudioPlayer AudioPlayer;

	// Token: 0x02008386 RID: 33670
	private class EInfoDisplayTypeOneComponents
	{
		// Token: 0x0402C9A7 RID: 182695
		public const int InformationBtn = 0;

		// Token: 0x0402C9A8 RID: 182696
		public const int InformationTexture = 1;

		// Token: 0x0402C9A9 RID: 182697
		public const int Name = 2;

		// Token: 0x0402C9AA RID: 182698
		public const int BackBtn = 3;

		// Token: 0x0402C9AB RID: 182699
		public const int Desc = 4;

		// Token: 0x0402C9AC RID: 182700
		public const int DescItem = 5;

		// Token: 0x0402C9AD RID: 182701
		public const int TimeText = 6;

		// Token: 0x0402C9AE RID: 182702
		public const int BgStampImg = 7;

		// Token: 0x0402C9AF RID: 182703
		public const int PlayItem = 8;

		// Token: 0x0402C9B0 RID: 182704
		public const int TimeLineItem = 9;

		// Token: 0x0402C9B1 RID: 182705
		public const int Texture = 10;

		// Token: 0x0402C9B2 RID: 182706
		public const int BtnSwitchLeft = 11;

		// Token: 0x0402C9B3 RID: 182707
		public const int BtnSwitchRight = 12;

		// Token: 0x0402C9B4 RID: 182708
		public const int TextPageCount = 13;
	}
}
