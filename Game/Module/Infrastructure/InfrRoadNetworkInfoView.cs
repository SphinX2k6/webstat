using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C68 RID: 23656
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrRoadNetworkInfoView : UiViewBase
	{
		// Token: 0x0603BC49 RID: 244809 RVA: 0x00F25B37 File Offset: 0x00F23D37
		public InfrRoadNetworkInfoView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603BC4A RID: 244810 RVA: 0x00F25B4C File Offset: 0x00F23D4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BC4B RID: 244811 RVA: 0x00F25B94 File Offset: 0x00F23D94
		protected override UniTask OnBeforeStartAsync()
		{
			InfrRoadNetworkInfoView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrRoadNetworkInfoView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC4C RID: 244812 RVA: 0x00F25BD7 File Offset: 0x00F23DD7
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<InfrastructureDefine.IInfrRoadNetworkInfoOpenParam>(EEventName.InfrastructureSelectRoadNetworkMark, new Action<InfrastructureDefine.IInfrRoadNetworkInfoOpenParam>(this.OnSelectMark));
		}

		// Token: 0x0603BC4D RID: 244813 RVA: 0x00F25BF5 File Offset: 0x00F23DF5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<InfrastructureDefine.IInfrRoadNetworkInfoOpenParam>(EEventName.InfrastructureSelectRoadNetworkMark, new Action<InfrastructureDefine.IInfrRoadNetworkInfoOpenParam>(this.OnSelectMark));
		}

		// Token: 0x0603BC4E RID: 244814 RVA: 0x00F25C14 File Offset: 0x00F23E14
		private UniTask CreateInfoPanel()
		{
			InfrRoadNetworkInfoView.<CreateInfoPanel>d__8 <CreateInfoPanel>d__;
			<CreateInfoPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateInfoPanel>d__.<>4__this = this;
			<CreateInfoPanel>d__.<>1__state = -1;
			<CreateInfoPanel>d__.<>t__builder.Start<InfrRoadNetworkInfoView.<CreateInfoPanel>d__8>(ref <CreateInfoPanel>d__);
			return <CreateInfoPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC4F RID: 244815 RVA: 0x00F25C57 File Offset: 0x00F23E57
		protected override void OnStart()
		{
			this.SetOpenParam(this.OpenParam as InfrastructureDefine.IInfrRoadNetworkInfoOpenParam);
		}

		// Token: 0x0603BC50 RID: 244816 RVA: 0x00F25C6C File Offset: 0x00F23E6C
		private void SetOpenParam(InfrastructureDefine.IInfrRoadNetworkInfoOpenParam openParam)
		{
			this.CloseCb = openParam.CloseCb;
			this.InfoPanel.SetClickBtnBuildCb(openParam.BuildCb);
			this.InfoPanel.SetClickCaptionCloseBtnCb(delegate
			{
				this.CloseSelfAsync().Forget();
			});
			this.InfoPanel.Refresh(openParam.InfoParam);
		}

		// Token: 0x0603BC51 RID: 244817 RVA: 0x00F25CC0 File Offset: 0x00F23EC0
		private UniTask CloseSelfAsync()
		{
			InfrRoadNetworkInfoView.<CloseSelfAsync>d__11 <CloseSelfAsync>d__;
			<CloseSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseSelfAsync>d__.<>4__this = this;
			<CloseSelfAsync>d__.<>1__state = -1;
			<CloseSelfAsync>d__.<>t__builder.Start<InfrRoadNetworkInfoView.<CloseSelfAsync>d__11>(ref <CloseSelfAsync>d__);
			return <CloseSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC52 RID: 244818 RVA: 0x00F25D03 File Offset: 0x00F23F03
		private void OnSelectMark(InfrastructureDefine.IInfrRoadNetworkInfoOpenParam param)
		{
			this.SetOpenParam(param);
		}

		// Token: 0x04021969 RID: 137577
		private readonly InfrMaterialsDeliveryInfoPanel InfoPanel = new InfrMaterialsDeliveryInfoPanel();

		// Token: 0x0402196A RID: 137578
		private Action CloseCb;

		// Token: 0x0200BD04 RID: 48388
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A3DD RID: 238557
			public const int MarkInfoPanel = 0;
		}
	}
}
