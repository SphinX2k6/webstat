using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002004 RID: 8196
public class InfoDisplayTypeThreeView : UiTickViewBase
{
	// Token: 0x0600F792 RID: 63378 RVA: 0x0043CA9B File Offset: 0x0043AC9B
	[NullableContext(1)]
	public InfoDisplayTypeThreeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F793 RID: 63379 RVA: 0x0043CAA4 File Offset: 0x0043ACA4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickCloseBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickSwitchLeftBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickSwitchRightBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F794 RID: 63380 RVA: 0x0043CD24 File Offset: 0x0043AF24
	protected override void OnStart()
	{
		this.AudioPlayer = new InfoDisplayAudioPlayer();
		UUIItem item = base.GetItem(5);
		if (((item != null) ? item.GetOwner() : null) == null)
		{
			return;
		}
		this.AudioPlayer.Initialize(item.GetOwner());
		UUIText text = base.GetText(3);
		if (text != null)
		{
			this.AudioPlayer.SetShowTextComponent(text);
		}
		int id = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		this.RefreshElement(id);
		this.AudioPlayer.Refresh(ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayAudio(id));
		this.RefreshPageSwitch();
	}

	// Token: 0x0600F795 RID: 63381 RVA: 0x0043CDAC File Offset: 0x0043AFAC
	protected override void OnBeforeShow()
	{
		int id = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		string infoDisplayEntryAudio = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayEntryAudio(id);
		if (infoDisplayEntryAudio != "")
		{
			Singleton<AudioSystem>.Instance.PostEvent(infoDisplayEntryAudio);
		}
	}

	// Token: 0x0600F796 RID: 63382 RVA: 0x0043CDEC File Offset: 0x0043AFEC
	protected override void OnBeforeHide()
	{
		int id = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		string infoDisplayExitAudio = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayExitAudio(id);
		if (infoDisplayExitAudio != "")
		{
			Singleton<AudioSystem>.Instance.PostEvent(infoDisplayExitAudio);
		}
	}

	// Token: 0x0600F797 RID: 63383 RVA: 0x0043CE29 File Offset: 0x0043B029
	private void RefreshElement(int id)
	{
		this.RefreshShowText(id);
		this.RefreshBgStamp(id);
		this.RefreshAudioShow(id);
	}

	// Token: 0x0600F798 RID: 63384 RVA: 0x0043CE40 File Offset: 0x0043B040
	private void RefreshAudioShow(int id)
	{
		string infoDisplayAudio = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayAudio(id);
		UUIItem item = base.GetItem(5);
		UUIItem item2 = base.GetItem(7);
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

	// Token: 0x0600F799 RID: 63385 RVA: 0x0043CEA0 File Offset: 0x0043B0A0
	private void RefreshShowText(int id)
	{
		string infoDisplayTitle = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayTitle(id);
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(infoDisplayTitle, true);
		}
		string infoDisplayDesc = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayDesc(id);
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetText(infoDisplayDesc, true);
		}
	}

	// Token: 0x0600F79A RID: 63386 RVA: 0x0043CEEC File Offset: 0x0043B0EC
	private void RefreshBgStamp(int id)
	{
		string infoDisplayBgStamp = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayBgStamp(id);
		UUIItem item = base.GetItem(9);
		if (infoDisplayBgStamp != "")
		{
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUITexture textureBg = base.GetTexture(8);
			if (textureBg != null)
			{
				base.SetTextureByPath(infoDisplayBgStamp, textureBg, null, delegate(bool success)
				{
					if (success)
					{
						textureBg.SetSizeFromTexture();
						textureBg.SetUIActive(true);
					}
				});
				return;
			}
		}
		else if (item != null)
		{
			item.SetUIActive(false);
		}
	}

	// Token: 0x0600F79B RID: 63387 RVA: 0x0043CF6D File Offset: 0x0043B16D
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F79C RID: 63388 RVA: 0x0043CF76 File Offset: 0x0043B176
	private void OnClickSwitchLeftBtn()
	{
		this.SwitchGroupPage(-1);
	}

	// Token: 0x0600F79D RID: 63389 RVA: 0x0043CF7F File Offset: 0x0043B17F
	private void OnClickSwitchRightBtn()
	{
		this.SwitchGroupPage(1);
	}

	// Token: 0x0600F79E RID: 63390 RVA: 0x0043CF88 File Offset: 0x0043B188
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

	// Token: 0x0600F79F RID: 63391 RVA: 0x0043CFF4 File Offset: 0x0043B1F4
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

	// Token: 0x0600F7A0 RID: 63392 RVA: 0x0043D0C0 File Offset: 0x0043B2C0
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

	// Token: 0x0600F7A1 RID: 63393 RVA: 0x0043D0F5 File Offset: 0x0043B2F5
	protected override void OnTick(float delta)
	{
		InfoDisplayAudioPlayer audioPlayer = this.AudioPlayer;
		if (audioPlayer == null)
		{
			return;
		}
		audioPlayer.OnTick(delta);
	}

	// Token: 0x0600F7A2 RID: 63394 RVA: 0x0043D108 File Offset: 0x0043B308
	protected override UniTask OnBeforeHideAsync()
	{
		InfoDisplayTypeThreeView.<OnBeforeHideAsync>d__18 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<InfoDisplayTypeThreeView.<OnBeforeHideAsync>d__18>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400778D RID: 30605
	[Nullable(2)]
	private InfoDisplayAudioPlayer AudioPlayer;

	// Token: 0x02008389 RID: 33673
	private class EInfoDisplayTypeThreeComponents
	{
		// Token: 0x0402C9BB RID: 182715
		public const int Name = 0;

		// Token: 0x0402C9BC RID: 182716
		public const int BgStampImg = 1;

		// Token: 0x0402C9BD RID: 182717
		public const int Desc = 2;

		// Token: 0x0402C9BE RID: 182718
		public const int TimeText = 3;

		// Token: 0x0402C9BF RID: 182719
		public const int BackBtn = 4;

		// Token: 0x0402C9C0 RID: 182720
		public const int PlayItem = 5;

		// Token: 0x0402C9C1 RID: 182721
		public const int DescItem = 6;

		// Token: 0x0402C9C2 RID: 182722
		public const int TimeLineItem = 7;

		// Token: 0x0402C9C3 RID: 182723
		public const int TexBg = 8;

		// Token: 0x0402C9C4 RID: 182724
		public const int BgMaskItem = 9;

		// Token: 0x0402C9C5 RID: 182725
		public const int BgMaskBlack = 10;

		// Token: 0x0402C9C6 RID: 182726
		public const int BtnSwitchLeft = 11;

		// Token: 0x0402C9C7 RID: 182727
		public const int BtnSwitchRight = 12;

		// Token: 0x0402C9C8 RID: 182728
		public const int TextPageCount = 13;
	}
}
