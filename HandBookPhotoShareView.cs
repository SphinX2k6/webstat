using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E72 RID: 7794
public class HandBookPhotoShareView : UiPanelBase
{
	// Token: 0x0600E682 RID: 59010 RVA: 0x003E36DC File Offset: 0x003E18DC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIArtText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0600E683 RID: 59011 RVA: 0x003E3778 File Offset: 0x003E1978
	protected override void OnBeforeShowImplement()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhotoSaveViewPersonalInfoShowRefresh, new Action(this.OnPersonalInfoShowRefresh));
	}

	// Token: 0x0600E684 RID: 59012 RVA: 0x003E3796 File Offset: 0x003E1996
	protected override void OnAfterHideImplement()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhotoSaveViewPersonalInfoShowRefresh, new Action(this.OnPersonalInfoShowRefresh));
	}

	// Token: 0x0600E685 RID: 59013 RVA: 0x003E37B4 File Offset: 0x003E19B4
	private void OnPersonalInfoShowRefresh()
	{
		this.UpdatePersonalInfoShowView();
	}

	// Token: 0x0600E686 RID: 59014 RVA: 0x003E37BC File Offset: 0x003E19BC
	private void UpdatePersonalInfoShowView()
	{
		bool global = LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.PhotoAndShareShowPlayerName, true);
		base.GetItem(1).SetUIActive(global);
		base.GetItem(4).SetUIActive(global);
	}

	// Token: 0x0600E687 RID: 59015 RVA: 0x003E37EC File Offset: 0x003E19EC
	protected override void OnStart()
	{
		this.HandBookPhotoData = (this.OpenParam as HandBookPhotoData);
		if (this.HandBookPhotoData == null)
		{
			return;
		}
		int index = this.HandBookPhotoData.Index;
		base.GetText(2).SetText(this.HandBookPhotoData.TypeText[index], true);
		base.GetText(3).SetText(this.HandBookPhotoData.NameText[index], true);
		EHandBookTabType handBookType = this.HandBookPhotoData.HandBookType;
		int id = this.HandBookPhotoData.ConfigId[index];
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(handBookType, id);
		string text = Singleton<TimeUtil>.Instance.DateFormat9String(handBookInfo.CreateTimeStampSecond);
		UUIArtText artText = base.GetArtText(5);
		if (artText != null)
		{
			artText.SetText(text);
		}
		UUITexture texture = base.GetTexture(0);
		base.SetTextureByPath(this.HandBookPhotoData.TextureList[index], texture, null, null);
		this.UpdatePersonalInfoShowView();
	}

	// Token: 0x04006F22 RID: 28450
	[Nullable(2)]
	private HandBookPhotoData HandBookPhotoData;

	// Token: 0x020081BE RID: 33214
	private enum EComponents
	{
		// Token: 0x0402C074 RID: 180340
		Texture,
		// Token: 0x0402C075 RID: 180341
		TitleItem,
		// Token: 0x0402C076 RID: 180342
		TypeText,
		// Token: 0x0402C077 RID: 180343
		NameText,
		// Token: 0x0402C078 RID: 180344
		DateItem,
		// Token: 0x0402C079 RID: 180345
		DateArtText
	}
}
