using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001197 RID: 4503
public class AdvanceNoticeSubView : ActivitySubViewBase
{
	// Token: 0x06007673 RID: 30323 RVA: 0x001F01E8 File Offset: 0x001EE3E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnUrlButtonClick))
		};
	}

	// Token: 0x06007674 RID: 30324 RVA: 0x001F02EC File Offset: 0x001EE4EC
	protected override UniTask OnBeforeStartAsync()
	{
		AdvanceNoticeSubView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AdvanceNoticeSubView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007675 RID: 30325 RVA: 0x001F032F File Offset: 0x001EE52F
	protected override void OnBeforeShow()
	{
		AdvanceNoticeMultiGridItem multiGridItem = this.MultiGridItem;
		if (multiGridItem == null)
		{
			return;
		}
		multiGridItem.PlayAnim();
	}

	// Token: 0x06007676 RID: 30326 RVA: 0x001F0344 File Offset: 0x001EE544
	protected override void OnRefreshView()
	{
		if (this.ActivityBaseData == null)
		{
			return;
		}
		AdvertisingPageInfo advertisingPageInfoByActivityId = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingPageInfoByActivityId(this.ActivityBaseData.Id);
		base.SetTextureByPath(advertisingPageInfoByActivityId.InscriptionPic, base.GetTexture(8), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), advertisingPageInfoByActivityId.TitleText, Array.Empty<object>());
		base.GetText(5).SetText(advertisingPageInfoByActivityId.TitleVersion, true);
		DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds((this.ActivityBaseData as AdvanceNoticeData).GetUnlockTimeStamp() * (long)Singleton<TimeUtil>.Instance.InverseMillisecond).DateTime;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), AdvanceNoticeDefine.advanceNoticeDateTextList[dateTime.Month - 1], new <>z__ReadOnlySingleElementList<object>(dateTime.Day));
		UUIText text = base.GetText(7);
		bool flag = advertisingPageInfoByActivityId.PVLinkId > 0;
		text.SetUIActive(flag);
		base.GetSprite(2).SetUIActive(!flag);
		base.GetButton(1).RootUIComp.Get().SetUIActive(flag);
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, advertisingPageInfoByActivityId.PVText, Array.Empty<object>());
		}
	}

	// Token: 0x06007677 RID: 30327 RVA: 0x001F047C File Offset: 0x001EE67C
	private void OnUrlButtonClick()
	{
		if (this.ActivityBaseData == null || !ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			return;
		}
		int pvlinkId = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingPageInfoByActivityId(this.ActivityBaseData.Id).PVLinkId;
		if (pvlinkId <= 0)
		{
			return;
		}
		AdvertisingUrlConfig advertisingUrlConfigById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingUrlConfigById(pvlinkId);
		string text = ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk() ? advertisingUrlConfigById.GlobalLinkUrl : advertisingUrlConfigById.LinkUrl;
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		ControllerBase<KuroSdkController>.Instance.OpenWebView("", text, true, true, true, "Default");
	}

	// Token: 0x0400394F RID: 14671
	[Nullable(2)]
	protected AdvanceNoticeMultiGridItem MultiGridItem;

	// Token: 0x020074F5 RID: 29941
	private class EComponentDefine
	{
		// Token: 0x04028616 RID: 165398
		public const int UrlItem = 0;

		// Token: 0x04028617 RID: 165399
		public const int UrlButton = 1;

		// Token: 0x04028618 RID: 165400
		public const int TopRightSprite = 2;

		// Token: 0x04028619 RID: 165401
		public const int ContentRootItem = 3;

		// Token: 0x0402861A RID: 165402
		public const int TitleDescText = 4;

		// Token: 0x0402861B RID: 165403
		public const int VersionText = 5;

		// Token: 0x0402861C RID: 165404
		public const int DateText = 6;

		// Token: 0x0402861D RID: 165405
		public const int UrlDescText = 7;

		// Token: 0x0402861E RID: 165406
		public const int LeftTexture = 8;
	}
}
