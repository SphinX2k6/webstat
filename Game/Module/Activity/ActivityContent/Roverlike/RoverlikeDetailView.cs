using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E1 RID: 25569
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeDetailView : UiViewBase
	{
		// Token: 0x06040356 RID: 262998 RVA: 0x01074C6F File Offset: 0x01072E6F
		public RoverlikeDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040357 RID: 262999 RVA: 0x01074C84 File Offset: 0x01072E84
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040358 RID: 263000 RVA: 0x01074CF0 File Offset: 0x01072EF0
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeDetailView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeDetailView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040359 RID: 263001 RVA: 0x01074D33 File Offset: 0x01072F33
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0604035A RID: 263002 RVA: 0x01074D38 File Offset: 0x01072F38
		private void InitTabComponent()
		{
			CommonTabComponentData<RoverlikeTabItem> data = new CommonTabComponentData<RoverlikeTabItem>(new Func<UUIItem, int?, RoverlikeTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
			this.TabComponent = new TabComponentWithCaptionItem<RoverlikeTabItem>(base.GetItem(0), data, new Action(this.OnCloseClicked), false);
			this.TabComponent.SetHelpButtonShowState(false);
			this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
		}

		// Token: 0x0604035B RID: 263003 RVA: 0x01074DB0 File Offset: 0x01072FB0
		private UniTask RefreshTabListAsync()
		{
			RoverlikeDetailView.<RefreshTabListAsync>d__10 <RefreshTabListAsync>d__;
			<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTabListAsync>d__.<>4__this = this;
			<RefreshTabListAsync>d__.<>1__state = -1;
			<RefreshTabListAsync>d__.<>t__builder.Start<RoverlikeDetailView.<RefreshTabListAsync>d__10>(ref <RefreshTabListAsync>d__);
			return <RefreshTabListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604035C RID: 263004 RVA: 0x01074DF3 File Offset: 0x01072FF3
		private RoverlikeTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new RoverlikeTabItem();
		}

		// Token: 0x0604035D RID: 263005 RVA: 0x01074DFC File Offset: 0x01072FFC
		private CommonTabData GetCommonData(int index)
		{
			UiDynamicTab uiDynamicTab = this.TabDataList[index];
			return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x0604035E RID: 263006 RVA: 0x01074E34 File Offset: 0x01073034
		private void ToggleCallBack(int index)
		{
			UiDynamicTab data = this.TabDataList[index];
			EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
			RoverlikeTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, null, null);
			this.CurSelectTabView = new EUiTabViewName?(euiTabViewName);
		}

		// Token: 0x0604035F RID: 263007 RVA: 0x01074E8C File Offset: 0x0107308C
		private void OnCloseClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x0402401F RID: 147487
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TabComponentWithCaptionItem<RoverlikeTabItem> TabComponent;

		// Token: 0x04024020 RID: 147488
		[Nullable(2)]
		private TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x04024021 RID: 147489
		private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x04024022 RID: 147490
		private EUiTabViewName? CurSelectTabView;

		// Token: 0x0200C447 RID: 50247
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403C6C4 RID: 247492
			CaptionItem,
			// Token: 0x0403C6C5 RID: 247493
			Content
		}
	}
}
