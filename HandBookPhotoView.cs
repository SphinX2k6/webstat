using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E74 RID: 7796
[NullableContext(1)]
[Nullable(0)]
public class HandBookPhotoView : UiViewBase
{
	// Token: 0x0600E68A RID: 59018 RVA: 0x003E38ED File Offset: 0x003E1AED
	public HandBookPhotoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E68B RID: 59019 RVA: 0x003E38F8 File Offset: 0x003E1AF8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickLeftButton)),
			new ValueTuple<int, Delegate>(10, new Action(this.OnClickRightButton)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickCloseButton)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickCloseButton))
		};
	}

	// Token: 0x0600E68C RID: 59020 RVA: 0x003E3AA0 File Offset: 0x003E1CA0
	protected override UniTask OnBeforeStartAsync()
	{
		HandBookPhotoView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HandBookPhotoView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E68D RID: 59021 RVA: 0x003E3AE3 File Offset: 0x003E1CE3
	protected override void OnStart()
	{
		this.HandBookPhotoData = (this.OpenParam as HandBookPhotoData);
		if (this.HandBookPhotoData == null)
		{
			return;
		}
		this.CurIndex = this.HandBookPhotoData.Index;
		this.RefreshAllInfoByIndex(this.CurIndex);
		this.UpdateShareBtnItem();
	}

	// Token: 0x0600E68E RID: 59022 RVA: 0x003E3B22 File Offset: 0x003E1D22
	private void UpdateShareBtnItem()
	{
		if (this.ShareBtnItem == null)
		{
			return;
		}
		this.ShareBtnItem.SetShareActionId(EShareActionId.HandBookPhoto);
		this.ShareBtnItem.SetClickCallBack(delegate
		{
			EHandBookTabType handBookType = this.HandBookPhotoData.HandBookType;
			EShareReportExtraType value = EShareReportExtraType.None;
			if (handBookType == EHandBookTabType.Geography)
			{
				value = EShareReportExtraType.HandBookGeography;
			}
			else if (handBookType == EHandBookTabType.Quest)
			{
				value = EShareReportExtraType.HandBookQuest;
			}
			this.HandBookPhotoData.Index = this.CurIndex;
			PhotoSaveViewParam param = new PhotoSaveViewParam
			{
				ScreenShot = false,
				IsHiddenBattleView = false,
				ShareId = 15,
				HandBookPhotoData = this.HandBookPhotoData,
				ReportExtraType = new EShareReportExtraType?(value)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhotoSaveView, param, null);
		});
	}

	// Token: 0x0600E68F RID: 59023 RVA: 0x003E3B54 File Offset: 0x003E1D54
	private void RefreshAllInfoByIndex(int index)
	{
		int count = this.HandBookPhotoData.TextureList.Count;
		base.GetButton(9).RootUIComp.Get().SetUIActive(index != 0);
		base.GetButton(10).RootUIComp.Get().SetUIActive(index != count - 1);
		UUIText text = base.GetText(6);
		if (this.HandBookPhotoData.DateText != null)
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "DateOfAcquisition", new <>z__ReadOnlySingleElementList<object>(this.HandBookPhotoData.DateText[index]));
		}
		else
		{
			text.SetUIActive(false);
		}
		UUIText text2 = base.GetText(5);
		if (this.HandBookPhotoData.NameText != null)
		{
			text2.SetUIActive(true);
			text2.SetText(this.HandBookPhotoData.NameText[index], true);
		}
		else
		{
			text2.SetUIActive(false);
		}
		UUIText text3 = base.GetText(4);
		if (this.HandBookPhotoData.TypeText != null)
		{
			text3.SetUIActive(true);
			text3.SetText(this.HandBookPhotoData.TypeText[index], true);
		}
		else
		{
			text3.SetUIActive(false);
		}
		UUIText text4 = base.GetText(8);
		if (this.HandBookPhotoData.DescrtptionText != null)
		{
			text4.SetUIActive(true);
			text4.SetText(this.HandBookPhotoData.DescrtptionText[index], true);
		}
		else
		{
			text4.SetUIActive(false);
		}
		UUITexture texture = base.GetTexture(3);
		if (this.HandBookPhotoData.TextureList != null)
		{
			texture.SetUIActive(true);
			this.SetTexture(this.HandBookPhotoData.TextureList[index]);
			return;
		}
		texture.SetUIActive(false);
	}

	// Token: 0x0600E690 RID: 59024 RVA: 0x003E3CFC File Offset: 0x003E1EFC
	private void SetTexture(string texturePath)
	{
		base.SetTextureByPath(texturePath, base.GetTexture(3), null, null);
	}

	// Token: 0x0600E691 RID: 59025 RVA: 0x003E3D21 File Offset: 0x003E1F21
	private void OnClickLeftButton()
	{
		if (this.HandBookPhotoData == null)
		{
			return;
		}
		if (this.CurIndex == 0)
		{
			return;
		}
		this.CurIndex--;
		this.Refresh();
	}

	// Token: 0x0600E692 RID: 59026 RVA: 0x003E3D49 File Offset: 0x003E1F49
	private void OnClickRightButton()
	{
		if (this.HandBookPhotoData == null)
		{
			return;
		}
		if (this.CurIndex == this.HandBookPhotoData.TextureList.Count - 1)
		{
			return;
		}
		this.CurIndex++;
		this.Refresh();
	}

	// Token: 0x0600E693 RID: 59027 RVA: 0x003E3D84 File Offset: 0x003E1F84
	private void Refresh()
	{
		if (this.HandBookPhotoData.HandBookType == EHandBookTabType.Geography)
		{
			this.RefreshGeographyPhoto(this.CurIndex);
			return;
		}
		if (this.HandBookPhotoData.HandBookType == EHandBookTabType.Chip)
		{
			this.RefreshChipPhoto(this.CurIndex);
			return;
		}
		if (this.HandBookPhotoData.HandBookType == EHandBookTabType.Quest)
		{
			this.RefreshPlotPhoto(this.CurIndex);
		}
	}

	// Token: 0x0600E694 RID: 59028 RVA: 0x003E3DE4 File Offset: 0x003E1FE4
	private void RefreshChipPhoto(int index)
	{
		string texture = this.HandBookPhotoData.TextureList[index];
		this.SetTexture(texture);
	}

	// Token: 0x0600E695 RID: 59029 RVA: 0x003E3E0A File Offset: 0x003E200A
	private void RefreshGeographyPhoto(int index)
	{
		this.ReadGeographyHandBook(index);
		this.RefreshAllInfoByIndex(index);
	}

	// Token: 0x0600E696 RID: 59030 RVA: 0x003E3E1C File Offset: 0x003E201C
	private void ReadGeographyHandBook(int index)
	{
		int id = this.HandBookPhotoData.ConfigId[index];
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Geography, id);
		if (handBookInfo == null)
		{
			return;
		}
		if (!handBookInfo.IsRead)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Geography, id);
		}
	}

	// Token: 0x0600E697 RID: 59031 RVA: 0x003E3E5C File Offset: 0x003E205C
	private void RefreshPlotPhoto(int index)
	{
		this.ReadPlotHandBook(index);
		this.RefreshAllInfoByIndex(index);
	}

	// Token: 0x0600E698 RID: 59032 RVA: 0x003E3E6C File Offset: 0x003E206C
	private void ReadPlotHandBook(int index)
	{
		int id = this.HandBookPhotoData.ConfigId[index];
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Quest, id);
		if (handBookInfo == null)
		{
			return;
		}
		if (!handBookInfo.IsRead)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Quest, id);
		}
	}

	// Token: 0x0600E699 RID: 59033 RVA: 0x003E3EAC File Offset: 0x003E20AC
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E69A RID: 59034 RVA: 0x003E3EB5 File Offset: 0x003E20B5
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhotoSelect, this.HandBookPhotoData.ConfigId[this.CurIndex]);
		this.HandBookPhotoData = null;
		this.CurIndex = 0;
	}

	// Token: 0x04006F30 RID: 28464
	[Nullable(2)]
	private HandBookPhotoData HandBookPhotoData;

	// Token: 0x04006F31 RID: 28465
	[Nullable(2)]
	private ShareBtnItem ShareBtnItem;

	// Token: 0x04006F32 RID: 28466
	private int CurIndex;
}
