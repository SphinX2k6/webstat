using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.NetworkDetection;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A0E RID: 23054
	[NullableContext(1)]
	[Nullable(0)]
	public class LoginServerView : UiViewBase
	{
		// Token: 0x0603A611 RID: 239121 RVA: 0x00ECD6E6 File Offset: 0x00ECB8E6
		public LoginServerView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A612 RID: 239122 RVA: 0x00ECD6F0 File Offset: 0x00ECB8F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIDynScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickExitBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickComfirmBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A613 RID: 239123 RVA: 0x00ECD7FC File Offset: 0x00ECB9FC
		protected override UniTask OnBeforeStartAsync()
		{
			LoginServerView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LoginServerView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A614 RID: 239124 RVA: 0x00ECD840 File Offset: 0x00ECBA40
		protected override void OnStart()
		{
			ModelBase<LoginServerModel>.Instance.CurrentUiSelectSeverData = ModelBase<LoginServerModel>.Instance.CurrentSelectServerData;
			List<ILoginServersData> loginServersByClientRegion = ModelBase<LoginServerModel>.Instance.GetLoginServersByClientRegion();
			this.ScrollView.RefreshByData(loginServersByClientRegion.ToArray(), false, false);
			this.TryMoveToItem(loginServersByClientRegion);
		}

		// Token: 0x0603A615 RID: 239125 RVA: 0x00ECD886 File Offset: 0x00ECBA86
		private LoginServerItem OnItemCreate(ILoginServersData data, UUIItem uiItem, int index)
		{
			return new LoginServerItem();
		}

		// Token: 0x0603A616 RID: 239126 RVA: 0x00ECD88D File Offset: 0x00ECBA8D
		private void OnClickExitBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603A617 RID: 239127 RVA: 0x00ECD898 File Offset: 0x00ECBA98
		private void OnClickComfirmBtn()
		{
			ILoginServersData currentUiSelectSeverData = ModelBase<LoginServerModel>.Instance.CurrentUiSelectSeverData;
			if (currentUiSelectSeverData == null)
			{
				return;
			}
			ModelBase<LoginServerModel>.Instance.CurrentSelectServerData = currentUiSelectSeverData;
			ModelBase<LoginModel>.Instance.SetServerName(currentUiSelectSeverData.name);
			ModelBase<LoginModel>.Instance.SetServerIp(currentUiSelectSeverData.ip, 3);
			ModelBase<LoginModel>.Instance.SetServerId(currentUiSelectSeverData.id);
			Singleton<LauncherNetworkDetectionController>.Instance.LoginNetworkDetectionConfig = null;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnConfirmServerItem);
			base.CloseMe(null);
		}

		// Token: 0x0603A618 RID: 239128 RVA: 0x00ECD90F File Offset: 0x00ECBB0F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnGetLoginPlayerInfo, new Action(this.OnGetLoginPlayerInfo));
		}

		// Token: 0x0603A619 RID: 239129 RVA: 0x00ECD92A File Offset: 0x00ECBB2A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnGetLoginPlayerInfo, new Action(this.OnGetLoginPlayerInfo));
		}

		// Token: 0x0603A61A RID: 239130 RVA: 0x00ECD948 File Offset: 0x00ECBB48
		private void OnGetLoginPlayerInfo()
		{
			if (this.ScrollView == null)
			{
				return;
			}
			int scrollItemCount = this.ScrollView.GetScrollItemCount();
			for (int i = 0; i < scrollItemCount; i++)
			{
				LoginServerItem scrollItemFromIndex = this.ScrollView.GetScrollItemFromIndex(i);
				if (scrollItemFromIndex != null)
				{
					scrollItemFromIndex.UpdatePlayerInfo();
				}
			}
		}

		// Token: 0x0603A61B RID: 239131 RVA: 0x00ECD990 File Offset: 0x00ECBB90
		private void TryMoveToItem(List<ILoginServersData> dataList)
		{
			if (dataList == null || dataList.Count == 0)
			{
				return;
			}
			int recommendedServerIndex = this.GetRecommendedServerIndex(dataList);
			UUIDynScrollViewComponent uidynScrollViewComponent = base.GetUIDynScrollViewComponent(2);
			if (uidynScrollViewComponent == null)
			{
				return;
			}
			uidynScrollViewComponent.ScrollToItemIndex(recommendedServerIndex, true, 0f, false);
		}

		// Token: 0x0603A61C RID: 239132 RVA: 0x00ECD9CC File Offset: 0x00ECBBCC
		private int GetRecommendedServerIndex(List<ILoginServersData> dataList)
		{
			ILoginServersData currentUiSelectSeverData = ModelBase<LoginServerModel>.Instance.CurrentUiSelectSeverData;
			if (currentUiSelectSeverData == null)
			{
				return 0;
			}
			for (int i = 0; i < dataList.Count; i++)
			{
				if (dataList[i] == currentUiSelectSeverData)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x0603A61D RID: 239133 RVA: 0x00ECDA07 File Offset: 0x00ECBC07
		protected override void OnBeforeDestroy()
		{
			if (this.ScrollView != null)
			{
				this.ScrollView.ClearChildren();
				this.ScrollView = null;
			}
		}

		// Token: 0x040210F8 RID: 135416
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<LoginServerItem, LoginServerDynItem, ILoginServersData> ScrollView;

		// Token: 0x040210F9 RID: 135417
		private LoginServerDynItem LoginServerDynItem;

		// Token: 0x0200B9DA RID: 47578
		[NullableContext(0)]
		public enum EComponents
		{
			// Token: 0x040396E2 RID: 235234
			ExitBtn,
			// Token: 0x040396E3 RID: 235235
			ComfirmBtn,
			// Token: 0x040396E4 RID: 235236
			ScrollView,
			// Token: 0x040396E5 RID: 235237
			ScrollItem
		}
	}
}
