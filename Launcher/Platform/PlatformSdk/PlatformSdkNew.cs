using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200456C RID: 17772
	[NullableContext(1)]
	[Nullable(0)]
	public class PlatformSdkNew
	{
		// Token: 0x0602EB8F RID: 191375 RVA: 0x00B11B10 File Offset: 0x00B0FD10
		public virtual bool Initialize(UObject worldContext)
		{
			this.WorldContext = worldContext;
			this.InitTime = (long)this.GetInitTime();
			if (this.IsInitialized)
			{
				Singleton<LauncherLog>.Instance.Error("[PlatformSdkNew]平台SDK重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}
			this.InitPlatformSdkReportData();
			this.SetServerCommonParam();
			this.InitWebComponent();
			if (!this.OnInit())
			{
				Singleton<LauncherLog>.Instance.Error("[PlatformSdkNew]平台SDK初始化失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.IsInitialized = true;
			return true;
		}

		// Token: 0x0602EB90 RID: 191376 RVA: 0x00B11B90 File Offset: 0x00B0FD90
		public virtual bool UnInitialize()
		{
			if (!this.IsInitialized)
			{
				Singleton<LauncherLog>.Instance.Error("[PlatformSdkNew]平台SDK注销失败, 未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!this.OnUnInit())
			{
				Singleton<LauncherLog>.Instance.Error("[PlatformSdkNew]平台SDK注销失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.IsInitialized = false;
			return true;
		}

		// Token: 0x0602EB91 RID: 191377 RVA: 0x00B11BE9 File Offset: 0x00B0FDE9
		protected virtual bool OnInit()
		{
			return true;
		}

		// Token: 0x0602EB92 RID: 191378 RVA: 0x00B11BEC File Offset: 0x00B0FDEC
		protected virtual bool OnUnInit()
		{
			return true;
		}

		// Token: 0x0602EB93 RID: 191379 RVA: 0x00B11BEF File Offset: 0x00B0FDEF
		public virtual void ConnectToServer(TSDKConnectCallback callback)
		{
		}

		// Token: 0x0602EB94 RID: 191380 RVA: 0x00B11BF1 File Offset: 0x00B0FDF1
		public virtual bool NeedPrivacyProtocol()
		{
			return false;
		}

		// Token: 0x0602EB95 RID: 191381 RVA: 0x00B11BF4 File Offset: 0x00B0FDF4
		public virtual bool GetPrivacyAgreeState()
		{
			return false;
		}

		// Token: 0x0602EB96 RID: 191382 RVA: 0x00B11BF7 File Offset: 0x00B0FDF7
		public virtual void SavePrivacyAgreeState(bool state)
		{
		}

		// Token: 0x0602EB97 RID: 191383 RVA: 0x00B11BF9 File Offset: 0x00B0FDF9
		public virtual string GetDeviceId()
		{
			return "DefaultDeviceId";
		}

		// Token: 0x0602EB98 RID: 191384 RVA: 0x00B11C00 File Offset: 0x00B0FE00
		public virtual string GetProductId()
		{
			return "DefaultProductId";
		}

		// Token: 0x0602EB99 RID: 191385 RVA: 0x00B11C07 File Offset: 0x00B0FE07
		public virtual void SetServerCommonParam()
		{
		}

		// Token: 0x0602EB9A RID: 191386 RVA: 0x00B11C09 File Offset: 0x00B0FE09
		public virtual void Login(TSDKLoginCallback callback)
		{
		}

		// Token: 0x0602EB9B RID: 191387 RVA: 0x00B11C0B File Offset: 0x00B0FE0B
		public virtual void BindAccountThenLogin(TSDKLoginCallback callback, string mailAddress = "", string mailCode = "")
		{
		}

		// Token: 0x0602EB9C RID: 191388 RVA: 0x00B11C0D File Offset: 0x00B0FE0D
		public virtual string GetUserId()
		{
			return "NotImplement";
		}

		// Token: 0x0602EB9D RID: 191389 RVA: 0x00B11C14 File Offset: 0x00B0FE14
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public virtual UniTask<Dictionary<string, string>> GetSdkOnlineId(List<string> userIdList)
		{
			PlatformSdkNew.<GetSdkOnlineId>d__25 <GetSdkOnlineId>d__;
			<GetSdkOnlineId>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, string>>.Create();
			<GetSdkOnlineId>d__.<>1__state = -1;
			<GetSdkOnlineId>d__.<>t__builder.Start<PlatformSdkNew.<GetSdkOnlineId>d__25>(ref <GetSdkOnlineId>d__);
			return <GetSdkOnlineId>d__.<>t__builder.Task;
		}

		// Token: 0x0602EB9E RID: 191390 RVA: 0x00B11C50 File Offset: 0x00B0FE50
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public virtual UniTask<Dictionary<string, bool>> GetSdkBlockingUser()
		{
			PlatformSdkNew.<GetSdkBlockingUser>d__26 <GetSdkBlockingUser>d__;
			<GetSdkBlockingUser>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, bool>>.Create();
			<GetSdkBlockingUser>d__.<>1__state = -1;
			<GetSdkBlockingUser>d__.<>t__builder.Start<PlatformSdkNew.<GetSdkBlockingUser>d__26>(ref <GetSdkBlockingUser>d__);
			return <GetSdkBlockingUser>d__.<>t__builder.Task;
		}

		// Token: 0x0602EB9F RID: 191391 RVA: 0x00B11C8C File Offset: 0x00B0FE8C
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public virtual UniTask<Dictionary<string, ESdkRelation>> GetTargetRelation(List<string> accountIdList)
		{
			PlatformSdkNew.<GetTargetRelation>d__27 <GetTargetRelation>d__;
			<GetTargetRelation>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, ESdkRelation>>.Create();
			<GetTargetRelation>d__.<>1__state = -1;
			<GetTargetRelation>d__.<>t__builder.Start<PlatformSdkNew.<GetTargetRelation>d__27>(ref <GetTargetRelation>d__);
			return <GetTargetRelation>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBA0 RID: 191392 RVA: 0x00B11CC8 File Offset: 0x00B0FEC8
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public virtual UniTask<Dictionary<string, string>> GetSdkAccountId(List<string> userIdList)
		{
			PlatformSdkNew.<GetSdkAccountId>d__28 <GetSdkAccountId>d__;
			<GetSdkAccountId>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, string>>.Create();
			<GetSdkAccountId>d__.<>1__state = -1;
			<GetSdkAccountId>d__.<>t__builder.Start<PlatformSdkNew.<GetSdkAccountId>d__28>(ref <GetSdkAccountId>d__);
			return <GetSdkAccountId>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBA1 RID: 191393 RVA: 0x00B11D04 File Offset: 0x00B0FF04
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public virtual UniTask<string> GetSdkUserIdByAccountId(string accountId)
		{
			PlatformSdkNew.<GetSdkUserIdByAccountId>d__29 <GetSdkUserIdByAccountId>d__;
			<GetSdkUserIdByAccountId>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
			<GetSdkUserIdByAccountId>d__.<>1__state = -1;
			<GetSdkUserIdByAccountId>d__.<>t__builder.Start<PlatformSdkNew.<GetSdkUserIdByAccountId>d__29>(ref <GetSdkUserIdByAccountId>d__);
			return <GetSdkUserIdByAccountId>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBA2 RID: 191394 RVA: 0x00B11D3F File Offset: 0x00B0FF3F
		public virtual bool NeedShowShopIcon()
		{
			return false;
		}

		// Token: 0x0602EBA3 RID: 191395 RVA: 0x00B11D42 File Offset: 0x00B0FF42
		public virtual void ShowPlayStationStoreIcon(int positionType)
		{
		}

		// Token: 0x0602EBA4 RID: 191396 RVA: 0x00B11D44 File Offset: 0x00B0FF44
		public virtual void HidePlayStationStoreIcon()
		{
		}

		// Token: 0x0602EBA5 RID: 191397 RVA: 0x00B11D46 File Offset: 0x00B0FF46
		public virtual bool NeedShowThirdPartyId()
		{
			return false;
		}

		// Token: 0x0602EBA6 RID: 191398 RVA: 0x00B11D49 File Offset: 0x00B0FF49
		public virtual bool SupportSwitchFriendSearchByThirdPartyId()
		{
			return false;
		}

		// Token: 0x0602EBA7 RID: 191399 RVA: 0x00B11D4C File Offset: 0x00B0FF4C
		public virtual bool SupportSwitchFriendShowType()
		{
			return false;
		}

		// Token: 0x0602EBA8 RID: 191400 RVA: 0x00B11D50 File Offset: 0x00B0FF50
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public virtual UniTask<List<ISdkTrophyInfo>> GetSdkTrophyInfo(int offset = 0, int length = 0)
		{
			PlatformSdkNew.<GetSdkTrophyInfo>d__36 <GetSdkTrophyInfo>d__;
			<GetSdkTrophyInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<ISdkTrophyInfo>>.Create();
			<GetSdkTrophyInfo>d__.<>1__state = -1;
			<GetSdkTrophyInfo>d__.<>t__builder.Start<PlatformSdkNew.<GetSdkTrophyInfo>d__36>(ref <GetSdkTrophyInfo>d__);
			return <GetSdkTrophyInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBA9 RID: 191401 RVA: 0x00B11D8C File Offset: 0x00B0FF8C
		[NullableContext(0)]
		public virtual UniTask<bool> UnlockSdkTrophy(int trophyId)
		{
			PlatformSdkNew.<UnlockSdkTrophy>d__37 <UnlockSdkTrophy>d__;
			<UnlockSdkTrophy>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UnlockSdkTrophy>d__.<>1__state = -1;
			<UnlockSdkTrophy>d__.<>t__builder.Start<PlatformSdkNew.<UnlockSdkTrophy>d__37>(ref <UnlockSdkTrophy>d__);
			return <UnlockSdkTrophy>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBAA RID: 191402 RVA: 0x00B11DC8 File Offset: 0x00B0FFC8
		[NullableContext(0)]
		public virtual UniTask<bool> UpdateSdkTrophyProgress(int trophyId, int progress)
		{
			PlatformSdkNew.<UpdateSdkTrophyProgress>d__38 <UpdateSdkTrophyProgress>d__;
			<UpdateSdkTrophyProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateSdkTrophyProgress>d__.<>1__state = -1;
			<UpdateSdkTrophyProgress>d__.<>t__builder.Start<PlatformSdkNew.<UpdateSdkTrophyProgress>d__38>(ref <UpdateSdkTrophyProgress>d__);
			return <UpdateSdkTrophyProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBAB RID: 191403 RVA: 0x00B11E03 File Offset: 0x00B10003
		public virtual bool GetSdkFriendOnlyState()
		{
			return false;
		}

		// Token: 0x0602EBAC RID: 191404 RVA: 0x00B11E06 File Offset: 0x00B10006
		public virtual void SaveSdkFriendOnlyState(bool state)
		{
		}

		// Token: 0x0602EBAD RID: 191405 RVA: 0x00B11E08 File Offset: 0x00B10008
		public virtual void OpenWebView(string url, [Nullable(2)] Action endCallBack = null)
		{
		}

		// Token: 0x0602EBAE RID: 191406 RVA: 0x00B11E0A File Offset: 0x00B1000A
		public virtual void CloseWebView()
		{
		}

		// Token: 0x0602EBAF RID: 191407 RVA: 0x00B11E0C File Offset: 0x00B1000C
		public virtual bool PollWebViewClose()
		{
			return true;
		}

		// Token: 0x0602EBB0 RID: 191408 RVA: 0x00B11E0F File Offset: 0x00B1000F
		protected virtual void InitWebComponent()
		{
		}

		// Token: 0x0602EBB1 RID: 191409 RVA: 0x00B11E14 File Offset: 0x00B10014
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public virtual UniTask<IQueryProductResult> QueryProductInfo(List<string> productIds)
		{
			PlatformSdkNew.<QueryProductInfo>d__45 <QueryProductInfo>d__;
			<QueryProductInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<IQueryProductResult>.Create();
			<QueryProductInfo>d__.<>1__state = -1;
			<QueryProductInfo>d__.<>t__builder.Start<PlatformSdkNew.<QueryProductInfo>d__45>(ref <QueryProductInfo>d__);
			return <QueryProductInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBB2 RID: 191410 RVA: 0x00B11E4F File Offset: 0x00B1004F
		public virtual bool OpenCheckoutDialog(string productLabel, string productId, string channelGoodsId)
		{
			return false;
		}

		// Token: 0x0602EBB3 RID: 191411 RVA: 0x00B11E52 File Offset: 0x00B10052
		public virtual bool NeedCheckPlayOnly()
		{
			return false;
		}

		// Token: 0x0602EBB4 RID: 191412 RVA: 0x00B11E55 File Offset: 0x00B10055
		public virtual bool PlayOnly()
		{
			return this.NeedCheckPlayOnly() && this.PlayOnlyState;
		}

		// Token: 0x0602EBB5 RID: 191413 RVA: 0x00B11E67 File Offset: 0x00B10067
		public virtual void SetPlayOnly(bool state)
		{
			this.PlayOnlyState = state;
		}

		// Token: 0x0602EBB6 RID: 191414 RVA: 0x00B11E70 File Offset: 0x00B10070
		public virtual ESdkDialogResult PollCheckoutDialogResult()
		{
			return ESdkDialogResult.No;
		}

		// Token: 0x0602EBB7 RID: 191415 RVA: 0x00B11E73 File Offset: 0x00B10073
		public virtual void RequestCheckoutProduct(ISdkRequestCheckoutProductParam param, TSdkCheckoutProductCallback callback, ECheckoutReason reason)
		{
		}

		// Token: 0x0602EBB8 RID: 191416 RVA: 0x00B11E75 File Offset: 0x00B10075
		public virtual void StartActivity(string activityId)
		{
		}

		// Token: 0x0602EBB9 RID: 191417 RVA: 0x00B11E77 File Offset: 0x00B10077
		public virtual void EndActivity(string activityId)
		{
		}

		// Token: 0x0602EBBA RID: 191418 RVA: 0x00B11E79 File Offset: 0x00B10079
		public virtual void ChangeActivityAvailability([Nullable(new byte[]
		{
			2,
			1
		})] TArray<string> availableActivities, [Nullable(new byte[]
		{
			2,
			1
		})] TArray<string> unavailableActivities)
		{
		}

		// Token: 0x0602EBBB RID: 191419 RVA: 0x00B11E7B File Offset: 0x00B1007B
		public virtual bool NeedConfirmSdkProductInfo()
		{
			return false;
		}

		// Token: 0x0602EBBC RID: 191420 RVA: 0x00B11E7E File Offset: 0x00B1007E
		public virtual bool NeedShowSdkProductInfoBeforePay()
		{
			return false;
		}

		// Token: 0x0602EBBD RID: 191421 RVA: 0x00B11E84 File Offset: 0x00B10084
		[NullableContext(0)]
		public virtual UniTask<bool> OpenMessageBox([Nullable(1)] string accountId, ESdkMessageBoxMode dialogMode, ESdkMessageBoxType msgType)
		{
			PlatformSdkNew.<OpenMessageBox>d__57 <OpenMessageBox>d__;
			<OpenMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenMessageBox>d__.<>1__state = -1;
			<OpenMessageBox>d__.<>t__builder.Start<PlatformSdkNew.<OpenMessageBox>d__57>(ref <OpenMessageBox>d__);
			return <OpenMessageBox>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBBE RID: 191422 RVA: 0x00B11EBF File Offset: 0x00B100BF
		public virtual void GetMessageBoxCurrentState(Action<ESdkMessageBoxState> callBack)
		{
			callBack(ESdkMessageBoxState.None);
		}

		// Token: 0x0602EBBF RID: 191423 RVA: 0x00B11EC8 File Offset: 0x00B100C8
		public virtual void TerminateMessageBox()
		{
		}

		// Token: 0x0602EBC0 RID: 191424 RVA: 0x00B11ECA File Offset: 0x00B100CA
		public virtual void GetCommunicationRestricted([Nullable(2)] string accountId, Action<ESdkCommunicationRestricted> callBack)
		{
			callBack(ESdkCommunicationRestricted.No);
		}

		// Token: 0x0602EBC1 RID: 191425 RVA: 0x00B11ED4 File Offset: 0x00B100D4
		[NullableContext(0)]
		public virtual UniTask<ESdkCommunicationRestricted> GetCommunicationRestrictedAsync([Nullable(2)] string accountId)
		{
			PlatformSdkNew.<GetCommunicationRestrictedAsync>d__61 <GetCommunicationRestrictedAsync>d__;
			<GetCommunicationRestrictedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ESdkCommunicationRestricted>.Create();
			<GetCommunicationRestrictedAsync>d__.<>1__state = -1;
			<GetCommunicationRestrictedAsync>d__.<>t__builder.Start<PlatformSdkNew.<GetCommunicationRestrictedAsync>d__61>(ref <GetCommunicationRestrictedAsync>d__);
			return <GetCommunicationRestrictedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBC2 RID: 191426 RVA: 0x00B11F0F File Offset: 0x00B1010F
		public virtual bool GetIfShowDefaultPrice()
		{
			return true;
		}

		// Token: 0x0602EBC3 RID: 191427 RVA: 0x00B11F12 File Offset: 0x00B10112
		public virtual int CheckUserPremium()
		{
			return 0;
		}

		// Token: 0x0602EBC4 RID: 191428 RVA: 0x00B11F15 File Offset: 0x00B10115
		public virtual bool GetIfNeedQueryProductInfoForce()
		{
			return false;
		}

		// Token: 0x0602EBC5 RID: 191429 RVA: 0x00B11F18 File Offset: 0x00B10118
		public virtual void NotifyPlayStationPremium(bool isPlayStationOnly)
		{
		}

		// Token: 0x0602EBC6 RID: 191430 RVA: 0x00B11F1A File Offset: 0x00B1011A
		public virtual string CreatePlayerSession(int joinAbleUserType, int playerId)
		{
			return "-1";
		}

		// Token: 0x0602EBC7 RID: 191431 RVA: 0x00B11F21 File Offset: 0x00B10121
		public virtual void SetPlayerSessionJoinAbleUserType(int joinAbleUserType)
		{
		}

		// Token: 0x0602EBC8 RID: 191432 RVA: 0x00B11F23 File Offset: 0x00B10123
		public virtual void LeavePlayerSession()
		{
		}

		// Token: 0x0602EBC9 RID: 191433 RVA: 0x00B11F25 File Offset: 0x00B10125
		public virtual void JoinPlayerSession(string playerSession)
		{
		}

		// Token: 0x0602EBCA RID: 191434 RVA: 0x00B11F27 File Offset: 0x00B10127
		public virtual string CheckJoinSession()
		{
			return "-1";
		}

		// Token: 0x0602EBCB RID: 191435 RVA: 0x00B11F2E File Offset: 0x00B1012E
		public virtual string GetPlayerIdByPlayerSessionId(string playerSession)
		{
			return "-1";
		}

		// Token: 0x0602EBCC RID: 191436 RVA: 0x00B11F35 File Offset: 0x00B10135
		public virtual bool IsPlatformNetworkReachable()
		{
			return true;
		}

		// Token: 0x0602EBCD RID: 191437 RVA: 0x00B11F38 File Offset: 0x00B10138
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public virtual UniTask<RequestEmailCodeResponse> RequestEmailCode(string emailAddress)
		{
			PlatformSdkNew.<RequestEmailCode>d__73 <RequestEmailCode>d__;
			<RequestEmailCode>d__.<>t__builder = AsyncUniTaskMethodBuilder<RequestEmailCodeResponse>.Create();
			<RequestEmailCode>d__.<>1__state = -1;
			<RequestEmailCode>d__.<>t__builder.Start<PlatformSdkNew.<RequestEmailCode>d__73>(ref <RequestEmailCode>d__);
			return <RequestEmailCode>d__.<>t__builder.Task;
		}

		// Token: 0x0602EBCE RID: 191438 RVA: 0x00B11F73 File Offset: 0x00B10173
		public virtual bool SupportExternalWebBrowser()
		{
			return true;
		}

		// Token: 0x0602EBCF RID: 191439 RVA: 0x00B11F76 File Offset: 0x00B10176
		public virtual void OpenExternalUrl(string url)
		{
			if (this.SupportExternalWebBrowser())
			{
				UKismetSystemLibrary.LaunchURL(url);
				return;
			}
			this.OpenWebView(url, null);
		}

		// Token: 0x0602EBD0 RID: 191440 RVA: 0x00B11F8F File Offset: 0x00B1018F
		public virtual void OpenUserCenter(string sdkUid, [Nullable(2)] Action endCallBack = null)
		{
		}

		// Token: 0x0602EBD1 RID: 191441 RVA: 0x00B11F91 File Offset: 0x00B10191
		public virtual void RefreshAccessToken(string token)
		{
			this.CurrentAccessToken = token;
		}

		// Token: 0x0602EBD2 RID: 191442 RVA: 0x00B11F9C File Offset: 0x00B1019C
		private int GetInitTime()
		{
			int result = 0;
			if (UKuroVariableFunctionLibrary.GetIntValue("Sdk_InitTime", ref result))
			{
				return result;
			}
			int num = (int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			UKuroVariableFunctionLibrary.SetIntValue("Sdk_InitTime", num);
			return num;
		}

		// Token: 0x0602EBD3 RID: 191443 RVA: 0x00B11FD8 File Offset: 0x00B101D8
		public virtual string GetRunningOnlyCode()
		{
			if (this.RunningInitCode != "")
			{
				return this.RunningInitCode;
			}
			string empty = string.Empty;
			if (UKuroVariableFunctionLibrary.GetStringValue("Sdk_LoginCode", ref empty))
			{
				this.RunningInitCode = (empty ?? "");
			}
			else
			{
				long value = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				long value2 = new Random().NextInt64(0L, 10000000000L);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<long>(value);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted<long>(value2);
				string runningInitCode = defaultInterpolatedStringHandler.ToStringAndClear();
				this.RunningInitCode = runningInitCode;
				UKuroVariableFunctionLibrary.SetStringValue("Sdk_LoginCode", this.RunningInitCode);
			}
			return this.RunningInitCode;
		}

		// Token: 0x0602EBD4 RID: 191444 RVA: 0x00B12094 File Offset: 0x00B10294
		public virtual void OpenCustomerService()
		{
		}

		// Token: 0x0602EBD5 RID: 191445 RVA: 0x00B12096 File Offset: 0x00B10296
		public virtual void ReportToServer(EReportRoleDataType type, ReportRoleData data)
		{
		}

		// Token: 0x0602EBD6 RID: 191446 RVA: 0x00B12098 File Offset: 0x00B10298
		public virtual void ReportToThirdParty(PlatformSdkReportBaseData eventData)
		{
		}

		// Token: 0x0602EBD7 RID: 191447 RVA: 0x00B1209A File Offset: 0x00B1029A
		public virtual void NotifyCurrentLanguage(string language)
		{
		}

		// Token: 0x0602EBD8 RID: 191448 RVA: 0x00B1209C File Offset: 0x00B1029C
		public virtual bool BlockServerArea()
		{
			return false;
		}

		// Token: 0x0602EBD9 RID: 191449 RVA: 0x00B1209F File Offset: 0x00B1029F
		public virtual string GetSdkCountry()
		{
			return "";
		}

		// Token: 0x0602EBDA RID: 191450 RVA: 0x00B120A6 File Offset: 0x00B102A6
		protected virtual string GetGameName()
		{
			return "wutheringwaves";
		}

		// Token: 0x0602EBDB RID: 191451 RVA: 0x00B120AD File Offset: 0x00B102AD
		public virtual string GetGameId()
		{
			if (Singleton<PlatformSdkConfig>.Instance.IsGlobal)
			{
				return "G153";
			}
			return "G152";
		}

		// Token: 0x0602EBDC RID: 191452 RVA: 0x00B120C6 File Offset: 0x00B102C6
		public virtual string GetChannelId()
		{
			return "";
		}

		// Token: 0x0602EBDD RID: 191453 RVA: 0x00B120CD File Offset: 0x00B102CD
		public virtual string GetPackageId()
		{
			return "";
		}

		// Token: 0x0602EBDE RID: 191454 RVA: 0x00B120D4 File Offset: 0x00B102D4
		public virtual void OpenNotice()
		{
		}

		// Token: 0x0602EBDF RID: 191455 RVA: 0x00B120D6 File Offset: 0x00B102D6
		public virtual void Tick(double delta)
		{
		}

		// Token: 0x0602EBE0 RID: 191456 RVA: 0x00B120D8 File Offset: 0x00B102D8
		public virtual void SetTickInnerState(bool state)
		{
			this.TickInnerState = state;
		}

		// Token: 0x0602EBE1 RID: 191457 RVA: 0x00B120E1 File Offset: 0x00B102E1
		public virtual void BindOnWebViewCloseCallBack(Action callback)
		{
			this.OnWebViewCloseCallBack = callback;
		}

		// Token: 0x0602EBE2 RID: 191458 RVA: 0x00B120EA File Offset: 0x00B102EA
		public virtual bool NeedLimitUserInfoWhenSocialLimit()
		{
			return false;
		}

		// Token: 0x0602EBE3 RID: 191459 RVA: 0x00B120ED File Offset: 0x00B102ED
		public virtual void SetThirdUnionId(string unionId)
		{
			this.ThirdUnionId = unionId;
			this.InitPlatformSdkReportData();
		}

		// Token: 0x0602EBE4 RID: 191460 RVA: 0x00B120FC File Offset: 0x00B102FC
		protected virtual void InitPlatformSdkReportData()
		{
		}

		// Token: 0x0602EBE5 RID: 191461 RVA: 0x00B120FE File Offset: 0x00B102FE
		public virtual void InitDataReport()
		{
			this.DataReportInitState = true;
			this.OnInitDataReport();
		}

		// Token: 0x0602EBE6 RID: 191462 RVA: 0x00B1210D File Offset: 0x00B1030D
		protected virtual void OnInitDataReport()
		{
		}

		// Token: 0x0401A8E0 RID: 108768
		private const string LOGINCODE = "Sdk_LoginCode";

		// Token: 0x0401A8E1 RID: 108769
		private bool IsInitialized;

		// Token: 0x0401A8E2 RID: 108770
		private bool PlayOnlyState;

		// Token: 0x0401A8E3 RID: 108771
		[Nullable(2)]
		protected UObject WorldContext;

		// Token: 0x0401A8E4 RID: 108772
		private string RunningInitCode = "";

		// Token: 0x0401A8E5 RID: 108773
		protected long InitTime;

		// Token: 0x0401A8E6 RID: 108774
		protected string CurrentAccessToken = "";

		// Token: 0x0401A8E7 RID: 108775
		protected bool TickInnerState = true;

		// Token: 0x0401A8E8 RID: 108776
		[Nullable(2)]
		protected Action OnWebViewCloseCallBack;

		// Token: 0x0401A8E9 RID: 108777
		protected string ThirdUnionId = "";

		// Token: 0x0401A8EA RID: 108778
		protected bool DataReportInitState;
	}
}
