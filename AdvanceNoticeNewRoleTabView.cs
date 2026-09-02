using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.AdvanceNotice;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001193 RID: 4499
[NullableContext(1)]
[Nullable(0)]
public class AdvanceNoticeNewRoleTabView : AdvanceNoticeTabViewBase
{
	// Token: 0x06007655 RID: 30293 RVA: 0x001EF724 File Offset: 0x001ED924
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUINiagara)),
			new ValueTuple<int, Type>(10, typeof(UUINiagara)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x06007656 RID: 30294 RVA: 0x001EF848 File Offset: 0x001EDA48
	protected override UniTask OnBeforeStartAsync()
	{
		AdvanceNoticeNewRoleTabView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AdvanceNoticeNewRoleTabView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007657 RID: 30295 RVA: 0x001EF88C File Offset: 0x001EDA8C
	protected override void RefreshView()
	{
		int currentSubTabId = this.ViewModel.CurrentSubTabId;
		AdvertisingTabCharacter advertisingTabCharacterById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabCharacterById(currentSubTabId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), advertisingTabCharacterById.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), advertisingTabCharacterById.GetWayTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), advertisingTabCharacterById.GetWayDescription, Array.Empty<object>());
		UUITexture texture = base.GetTexture(0);
		UUITexture texture2 = base.GetTexture(7);
		UUITexture texture3 = base.GetTexture(8);
		UUINiagara uiNiagara = base.GetUiNiagara(9);
		UUINiagara uiNiagara2 = base.GetUiNiagara(10);
		string path = string.Empty;
		if (advertisingTabCharacterById.Type == 1)
		{
			texture2.SetUIActive(false);
			texture3.SetUIActive(false);
			texture.SetUIActive(true);
			uiNiagara.SetUIActive(false);
			uiNiagara2.SetUIActive(false);
			this.CheckToSetTextureByPath(advertisingTabCharacterById.MainBgPic, texture);
			path = advertisingTabCharacterById.SpinePrefabResource;
		}
		else
		{
			texture2.SetUIActive(true);
			texture3.SetUIActive(true);
			texture.SetUIActive(true);
			this.CheckToSetTextureByPath(advertisingTabCharacterById.MainPic, texture2);
			this.CheckToSetTextureByPath(advertisingTabCharacterById.MainBgPic, texture);
			this.CheckToSetTextureByPath(advertisingTabCharacterById.MainPic, texture3);
			int qualityId = advertisingTabCharacterById.QualityId;
			uiNiagara.SetUIActive(qualityId == 4);
			uiNiagara2.SetUIActive(qualityId == 5);
			path = advertisingTabCharacterById.WeaponPrefabPath;
		}
		this.DetailItem.Refresh(currentSubTabId);
		this.ShowItem(currentSubTabId, advertisingTabCharacterById.Type, path).Forget();
	}

	// Token: 0x06007658 RID: 30296 RVA: 0x001EFA14 File Offset: 0x001EDC14
	private void CheckToSetTextureByPath(string texturePath, UUITexture textureComp)
	{
		if (StringUtils.IsBlank(texturePath))
		{
			return;
		}
		base.SetTextureByPath(texturePath, textureComp, null, null);
	}

	// Token: 0x06007659 RID: 30297 RVA: 0x001EFA3C File Offset: 0x001EDC3C
	private UniTask ShowItem(int id, int type, string path)
	{
		AdvanceNoticeNewRoleTabView.<ShowItem>d__8 <ShowItem>d__;
		<ShowItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowItem>d__.<>4__this = this;
		<ShowItem>d__.id = id;
		<ShowItem>d__.type = type;
		<ShowItem>d__.path = path;
		<ShowItem>d__.<>1__state = -1;
		<ShowItem>d__.<>t__builder.Start<AdvanceNoticeNewRoleTabView.<ShowItem>d__8>(ref <ShowItem>d__);
		return <ShowItem>d__.<>t__builder.Task;
	}

	// Token: 0x04003947 RID: 14663
	[Nullable(2)]
	private AdvanceNoticeNewRoleDetailItem DetailItem;

	// Token: 0x04003948 RID: 14664
	private readonly Dictionary<int, AdvanceNoticeItemView> AdvanceNoticeItemViewMap = new Dictionary<int, AdvanceNoticeItemView>();

	// Token: 0x04003949 RID: 14665
	[Nullable(2)]
	private AdvanceNoticeItemView CurrentItem;

	// Token: 0x020074ED RID: 29933
	[NullableContext(0)]
	private enum EComponentDefine
	{
		// Token: 0x040285E4 RID: 165348
		BgTexture,
		// Token: 0x040285E5 RID: 165349
		TitleDescText,
		// Token: 0x040285E6 RID: 165350
		NameText,
		// Token: 0x040285E7 RID: 165351
		ContentText,
		// Token: 0x040285E8 RID: 165352
		DetailItem,
		// Token: 0x040285E9 RID: 165353
		GetWayTitleText,
		// Token: 0x040285EA RID: 165354
		GetWayDescText,
		// Token: 0x040285EB RID: 165355
		ContentTexture,
		// Token: 0x040285EC RID: 165356
		ShadowTexture,
		// Token: 0x040285ED RID: 165357
		PurpleEffectNiagara,
		// Token: 0x040285EE RID: 165358
		GoldEffectNiagara,
		// Token: 0x040285EF RID: 165359
		PnlContent
	}
}
