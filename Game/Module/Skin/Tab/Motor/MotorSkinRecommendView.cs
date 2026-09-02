using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Tab.Motor
{
	// Token: 0x02004F6D RID: 20333
	public class MotorSkinRecommendView : UiTabViewBase
	{
		// Token: 0x06034711 RID: 214801 RVA: 0x00D1F51B File Offset: 0x00D1D71B
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x06034712 RID: 214802 RVA: 0x00D1F540 File Offset: 0x00D1D740
		protected override UniTask OnBeforeStartAsync()
		{
			MotorSkinRecommendView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorSkinRecommendView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034713 RID: 214803 RVA: 0x00D1F583 File Offset: 0x00D1D783
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnRefreshGoods));
		}

		// Token: 0x06034714 RID: 214804 RVA: 0x00D1F5A1 File Offset: 0x00D1D7A1
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnRefreshGoods));
		}

		// Token: 0x06034715 RID: 214805 RVA: 0x00D1F5BF File Offset: 0x00D1D7BF
		[NullableContext(1)]
		private void OnRefreshGoods(PayItemSuccess _)
		{
			this.RefreshView();
		}

		// Token: 0x06034716 RID: 214806 RVA: 0x00D1F5C8 File Offset: 0x00D1D7C8
		protected override void OnBeforeShow()
		{
			this.RefreshView();
			UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
			((tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null).PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06034717 RID: 214807 RVA: 0x00D1F602 File Offset: 0x00D1D802
		private void RefreshView()
		{
			this.MotorSkinItemContent.Refresh(this.RecommendData.Id);
		}

		// Token: 0x0401E358 RID: 123736
		[Nullable(2)]
		private MotorSkinItemContent MotorSkinItemContent;

		// Token: 0x0401E359 RID: 123737
		[Nullable(2)]
		private PayShopRecommendData RecommendData;

		// Token: 0x0200AF8A RID: 44938
		private enum EComponent
		{
			// Token: 0x0403678D RID: 223117
			Content
		}
	}
}
