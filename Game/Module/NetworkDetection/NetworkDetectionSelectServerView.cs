using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.NetworkDetection
{
	// Token: 0x020056C8 RID: 22216
	[NullableContext(1)]
	[Nullable(0)]
	public class NetworkDetectionSelectServerView : UiViewBase
	{
		// Token: 0x060388AF RID: 231599 RVA: 0x00E52D54 File Offset: 0x00E50F54
		public NetworkDetectionSelectServerView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060388B0 RID: 231600 RVA: 0x00E52D60 File Offset: 0x00E50F60
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

		// Token: 0x060388B1 RID: 231601 RVA: 0x00E52E6C File Offset: 0x00E5106C
		protected override UniTask OnBeforeStartAsync()
		{
			NetworkDetectionSelectServerView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<NetworkDetectionSelectServerView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060388B2 RID: 231602 RVA: 0x00E52EAF File Offset: 0x00E510AF
		private NetworkDetectionSelectServerItem OnItemCreate(ILoginServersData data, UUIItem uiItem, int index)
		{
			return new NetworkDetectionSelectServerItem();
		}

		// Token: 0x060388B3 RID: 231603 RVA: 0x00E52EB6 File Offset: 0x00E510B6
		private void OnClickExitBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x060388B4 RID: 231604 RVA: 0x00E52EC0 File Offset: 0x00E510C0
		private void OnClickComfirmBtn()
		{
			ILoginServersData currentUiSelectSeverData = ModelBase<NetworkDetectionModel>.Instance.CurrentUiSelectSeverData;
			ModelBase<NetworkDetectionModel>.Instance.CurrentSelectServerData = currentUiSelectSeverData;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnConfirmNetworkDetectionItem);
			base.CloseMe(null);
		}

		// Token: 0x060388B5 RID: 231605 RVA: 0x00E52EF7 File Offset: 0x00E510F7
		protected override void OnAddEventListener()
		{
		}

		// Token: 0x060388B6 RID: 231606 RVA: 0x00E52EF9 File Offset: 0x00E510F9
		protected override void OnRemoveEventListener()
		{
		}

		// Token: 0x060388B7 RID: 231607 RVA: 0x00E52EFC File Offset: 0x00E510FC
		private UniTask TryMoveToItem(List<ILoginServersData> dataList)
		{
			NetworkDetectionSelectServerView.<TryMoveToItem>d__10 <TryMoveToItem>d__;
			<TryMoveToItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryMoveToItem>d__.<>4__this = this;
			<TryMoveToItem>d__.dataList = dataList;
			<TryMoveToItem>d__.<>1__state = -1;
			<TryMoveToItem>d__.<>t__builder.Start<NetworkDetectionSelectServerView.<TryMoveToItem>d__10>(ref <TryMoveToItem>d__);
			return <TryMoveToItem>d__.<>t__builder.Task;
		}

		// Token: 0x060388B8 RID: 231608 RVA: 0x00E52F48 File Offset: 0x00E51148
		private int GetRecommendedServerIndex(List<ILoginServersData> dataList)
		{
			int result = 0;
			int count = dataList.Count;
			for (int i = 0; i < count; i++)
			{
				if (ModelBase<NetworkDetectionModel>.Instance.CurrentUiSelectSeverData == dataList[i])
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x060388B9 RID: 231609 RVA: 0x00E52F82 File Offset: 0x00E51182
		protected override void OnBeforeDestroy()
		{
			this.ScrollView.ClearChildren();
			this.ScrollView = null;
		}

		// Token: 0x0402044B RID: 132171
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<NetworkDetectionSelectServerItem, NetworkDetectionSelectServerDynItem, ILoginServersData> ScrollView;

		// Token: 0x0200B735 RID: 46901
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04038AB7 RID: 232119
			ExitBtn,
			// Token: 0x04038AB8 RID: 232120
			ComfirmBtn,
			// Token: 0x04038AB9 RID: 232121
			ScrollView,
			// Token: 0x04038ABA RID: 232122
			ScrollItem
		}
	}
}
