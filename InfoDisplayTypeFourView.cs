using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002002 RID: 8194
public class InfoDisplayTypeFourView : UiTickViewBase
{
	// Token: 0x0600F775 RID: 63349 RVA: 0x0043BE8C File Offset: 0x0043A08C
	[NullableContext(1)]
	public InfoDisplayTypeFourView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F776 RID: 63350 RVA: 0x0043BE98 File Offset: 0x0043A098
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
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
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickInformationDetailBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickCloseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F777 RID: 63351 RVA: 0x0043C090 File Offset: 0x0043A290
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
		this.AudioPlayer.SetSpectrumCallBack(new Action<TArray<float>, float>(this.OnSpectrumCall));
		this.ShowAudioItems = new List<UUIItem>();
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			for (int i = 0; i < item2.UIChildren.Num(); i++)
			{
				UUIItem uuiitem = item2.UIChildren.Get(i);
				if (uuiitem != null)
				{
					this.ShowAudioItems.Add(uuiitem);
					if (i == 0)
					{
						this.OriginalHeight = uuiitem.Height;
					}
				}
			}
		}
		int id = ModelBase<InfoDisplayModel>.Instance.CurrentInformationId();
		this.RefreshElement(id);
		this.AudioPlayer.Refresh(ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayAudio(id));
	}

	// Token: 0x0600F778 RID: 63352 RVA: 0x0043C189 File Offset: 0x0043A389
	private void RefreshElement(int id)
	{
		this.RefreshShowImg(id);
		this.RefreshShowText(id);
		this.RefreshAudioShow(id);
	}

	// Token: 0x0600F779 RID: 63353 RVA: 0x0043C1A0 File Offset: 0x0043A3A0
	[NullableContext(1)]
	private void OnSpectrumCall(TArray<float> array, float deltaTime)
	{
		if (this.ShowAudioItems == null)
		{
			return;
		}
		for (int i = 0; i < array.Num(); i++)
		{
			if (this.ShowAudioItems.Count > i)
			{
				float height = this.ShowAudioItems[i].Height;
				string s = array.Get(i).ToString("F1");
				float to = this.OriginalHeight * float.Parse(s);
				float height2 = Singleton<MathUtils>.Instance.Lerp(height, to, 0.3f);
				this.ShowAudioItems[i].SetHeight(height2);
			}
		}
	}

	// Token: 0x0600F77A RID: 63354 RVA: 0x0043C234 File Offset: 0x0043A434
	private void RefreshShowImg(int id)
	{
		string[] infoDisplayPictures = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayPictures(id);
		if (infoDisplayPictures != null && infoDisplayPictures.Length != 0)
		{
			string text = infoDisplayPictures[0];
			if (text != "")
			{
				UUITexture texture = base.GetTexture(1);
				if (texture != null)
				{
					base.SetTextureByPath(text, texture, null, null);
				}
			}
		}
	}

	// Token: 0x0600F77B RID: 63355 RVA: 0x0043C284 File Offset: 0x0043A484
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

	// Token: 0x0600F77C RID: 63356 RVA: 0x0043C2CF File Offset: 0x0043A4CF
	protected override void OnTick(float delta)
	{
		InfoDisplayAudioPlayer audioPlayer = this.AudioPlayer;
		if (audioPlayer == null)
		{
			return;
		}
		audioPlayer.OnTick(delta);
	}

	// Token: 0x0600F77D RID: 63357 RVA: 0x0043C2E4 File Offset: 0x0043A4E4
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

	// Token: 0x0600F77E RID: 63358 RVA: 0x0043C344 File Offset: 0x0043A544
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

	// Token: 0x0600F77F RID: 63359 RVA: 0x0043C379 File Offset: 0x0043A579
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F780 RID: 63360 RVA: 0x0043C384 File Offset: 0x0043A584
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

	// Token: 0x0600F781 RID: 63361 RVA: 0x0043C3C8 File Offset: 0x0043A5C8
	protected override UniTask OnBeforeHideAsync()
	{
		InfoDisplayTypeFourView.<OnBeforeHideAsync>d__17 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<InfoDisplayTypeFourView.<OnBeforeHideAsync>d__17>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04007788 RID: 30600
	private const float LERP_PERCENTAGE = 0.3f;

	// Token: 0x04007789 RID: 30601
	[Nullable(2)]
	private InfoDisplayAudioPlayer AudioPlayer;

	// Token: 0x0400778A RID: 30602
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<UUIItem> ShowAudioItems;

	// Token: 0x0400778B RID: 30603
	private float OriginalHeight;

	// Token: 0x02008384 RID: 33668
	private class EInfoDisplayTypeFourComponents
	{
		// Token: 0x0402C998 RID: 182680
		public const int InformationBtn = 0;

		// Token: 0x0402C999 RID: 182681
		public const int InformationTexture = 1;

		// Token: 0x0402C99A RID: 182682
		public const int Name = 2;

		// Token: 0x0402C99B RID: 182683
		public const int BackBtn = 3;

		// Token: 0x0402C99C RID: 182684
		public const int Desc = 4;

		// Token: 0x0402C99D RID: 182685
		public const int DescItem = 5;

		// Token: 0x0402C99E RID: 182686
		public const int TimeText = 6;

		// Token: 0x0402C99F RID: 182687
		public const int BgStampImg = 7;

		// Token: 0x0402C9A0 RID: 182688
		public const int PlayItem = 8;

		// Token: 0x0402C9A1 RID: 182689
		public const int TimeLineItem = 9;

		// Token: 0x0402C9A2 RID: 182690
		public const int Puzzle = 10;
	}
}
