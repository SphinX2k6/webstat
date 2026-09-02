using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025BC RID: 9660
public class FightPhotoResultView : UiViewBase
{
	// Token: 0x06012E0F RID: 77327 RVA: 0x005388FF File Offset: 0x00536AFF
	[NullableContext(1)]
	public FightPhotoResultView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06012E10 RID: 77328 RVA: 0x00538908 File Offset: 0x00536B08
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(16, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClicked)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnContinueBtnClicked)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnBackBtnClicked)),
			new ValueTuple<int, Delegate>(15, new Action(this.OnLevelSelectBtnClicked))
		};
	}

	// Token: 0x06012E11 RID: 77329 RVA: 0x00538B0C File Offset: 0x00536D0C
	protected override void OnStart()
	{
		List<UTexture2D> savedFightPhotos = ControllerBase<PhotographController>.Instance.GetSavedFightPhotos();
		int count = savedFightPhotos.Count;
		for (int i = 0; i < count; i++)
		{
			UTexture2D texture = savedFightPhotos[i];
			UUITexture texture2 = base.GetTexture(6 + i);
			this.SetTextureWithAutoFit(texture2, texture);
			UUITexture texture3 = base.GetTexture(2 + i);
			this.SetTextureWithAutoFit(texture3, texture);
		}
		FightPhotoActivityData activityData = ControllerBase<FightPhotoController>.Instance.GetActivityData();
		FightPhotoLevelData currentLevelData = activityData.GetCurrentLevelData(true);
		base.SetTextureByPath(currentLevelData.NpcHeadIcon, base.GetTexture(9), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), currentLevelData.NpcDialogue, Array.Empty<object>());
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(currentLevelData.Name, null);
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(currentLevelData.IsDifficulty ? "FightPhotoDifficulty" : "FightPhotoEasy", null);
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetText(localTextNew + "-" + localTextNew2, true);
		}
		FightPhotoLevelData nextLevelData = activityData.GetNextLevelData(currentLevelData.LevelId);
		bool flag = nextLevelData != null && nextLevelData.IsUnLock;
		UUIButtonComponent button = base.GetButton(15);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(flag);
			}
		}
		if (flag)
		{
			string localTextNew3 = ConfigMultiTextLang.GetLocalTextNew(nextLevelData.LevelSimpleName, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "FightPhoto_Nextlevel_Buttun", new <>z__ReadOnlySingleElementList<object>(localTextNew3));
		}
	}

	// Token: 0x06012E12 RID: 77330 RVA: 0x00538C80 File Offset: 0x00536E80
	[NullableContext(1)]
	private void SetTextureWithAutoFit(UUITexture uiTexture, UTexture2D texture)
	{
		uiTexture.SetTexture(texture);
		int num = texture.Blueprint_GetSizeX();
		int num2 = texture.Blueprint_GetSizeY();
		float width = uiTexture.GetWidth();
		float height = uiTexture.GetHeight();
		int num3 = num / num2;
		float num4 = width / height;
		FVector4 uvrect = new FVector4(0f, 0f, 1f, 1f);
		if ((float)num3 > num4)
		{
			float num5 = height / (float)num2;
			float num6 = width / num5;
			float x = ((float)num - num6) / 2f / (float)num;
			float z = num6 / (float)num;
			uvrect = new FVector4(x, 0f, z, 1f);
		}
		else
		{
			float num7 = width / (float)num;
			float num8 = height / num7;
			float y = ((float)num2 - num8) / 2f / (float)num2;
			float w = num8 / (float)num2;
			uvrect = new FVector4(0f, y, 1f, w);
		}
		uiTexture.SetUVRect(uvrect);
	}

	// Token: 0x06012E13 RID: 77331 RVA: 0x00538D56 File Offset: 0x00536F56
	protected override void OnBeforeDestroy()
	{
		ControllerBase<PhotographController>.Instance.ClearAllSavedFightPhotos();
	}

	// Token: 0x06012E14 RID: 77332 RVA: 0x00538D62 File Offset: 0x00536F62
	private void OnCloseBtnClicked()
	{
		ControllerBase<PhotographController>.Instance.CloseFightPhotographMode();
	}

	// Token: 0x06012E15 RID: 77333 RVA: 0x00538D6E File Offset: 0x00536F6E
	private void OnContinueBtnClicked()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012E16 RID: 77334 RVA: 0x00538D77 File Offset: 0x00536F77
	protected override void OnAfterPlayStartSequence()
	{
		UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.RepeatMove();
	}

	// Token: 0x06012E17 RID: 77335 RVA: 0x00538D88 File Offset: 0x00536F88
	private void OnBackBtnClicked()
	{
		ControllerBase<FightPhotoController>.Instance.LeaveInstanceDungeon(true);
	}

	// Token: 0x06012E18 RID: 77336 RVA: 0x00538D98 File Offset: 0x00536F98
	private void OnLevelSelectBtnClicked()
	{
		FightPhotoActivityData activityData = ControllerBase<FightPhotoController>.Instance.GetActivityData();
		if (activityData == null)
		{
			return;
		}
		FightPhotoLevelData currentLevelData = activityData.GetCurrentLevelData(true);
		if (currentLevelData == null)
		{
			return;
		}
		FightPhotoLevelData nextLevelData = activityData.GetNextLevelData(currentLevelData.LevelId);
		FightPhotoLevelData fightPhotoLevelData = (nextLevelData != null && nextLevelData.IsUnLock) ? nextLevelData : currentLevelData;
		activityData.SetCurrentLevelId(fightPhotoLevelData.LevelId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FightPhotoMainView, activityData, null);
	}

	// Token: 0x02008916 RID: 35094
	private enum EComponents
	{
		// Token: 0x0402E412 RID: 189458
		BtnClose,
		// Token: 0x0402E413 RID: 189459
		ItemPhotoSingleShowPanel,
		// Token: 0x0402E414 RID: 189460
		TextureBigPhoto1,
		// Token: 0x0402E415 RID: 189461
		TextureBigPhoto2,
		// Token: 0x0402E416 RID: 189462
		TextureBigPhoto3,
		// Token: 0x0402E417 RID: 189463
		TextTitle,
		// Token: 0x0402E418 RID: 189464
		TextureSmallPhoto1,
		// Token: 0x0402E419 RID: 189465
		TextureSmallPhoto2,
		// Token: 0x0402E41A RID: 189466
		TextureSmallPhoto3,
		// Token: 0x0402E41B RID: 189467
		TextureRoleHead,
		// Token: 0x0402E41C RID: 189468
		TextDialogue,
		// Token: 0x0402E41D RID: 189469
		BtnContinue,
		// Token: 0x0402E41E RID: 189470
		BtnBack,
		// Token: 0x0402E41F RID: 189471
		ItemPhotoAllShowPanel,
		// Token: 0x0402E420 RID: 189472
		ItemSuccessPanel,
		// Token: 0x0402E421 RID: 189473
		BtnLevelSelect,
		// Token: 0x0402E422 RID: 189474
		TextBtn
	}
}
