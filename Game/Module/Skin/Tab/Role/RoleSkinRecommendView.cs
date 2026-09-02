using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Tab.Role
{
	// Token: 0x02004F69 RID: 20329
	public class RoleSkinRecommendView : UiTabViewBase
	{
		// Token: 0x060346F2 RID: 214770 RVA: 0x00D1EA3F File Offset: 0x00D1CC3F
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x060346F3 RID: 214771 RVA: 0x00D1EA64 File Offset: 0x00D1CC64
		protected override UniTask OnBeforeStartAsync()
		{
			RoleSkinRecommendView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkinRecommendView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060346F4 RID: 214772 RVA: 0x00D1EAA7 File Offset: 0x00D1CCA7
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		}

		// Token: 0x060346F5 RID: 214773 RVA: 0x00D1EAC5 File Offset: 0x00D1CCC5
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		}

		// Token: 0x060346F6 RID: 214774 RVA: 0x00D1EAE3 File Offset: 0x00D1CCE3
		private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
		{
			if (this.RecommendData.RecommendId != goodsId)
			{
				return;
			}
			this.RefreshView();
		}

		// Token: 0x060346F7 RID: 214775 RVA: 0x00D1EAFC File Offset: 0x00D1CCFC
		protected override void OnBeforeShow()
		{
			this.RefreshView();
			UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
			((tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null).PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x060346F8 RID: 214776 RVA: 0x00D1EB36 File Offset: 0x00D1CD36
		private void RefreshView()
		{
			this.RoleSkinItemContent.Refresh(this.RecommendData.Id);
		}

		// Token: 0x0401E34E RID: 123726
		[Nullable(2)]
		private RoleSkinItemContent RoleSkinItemContent;

		// Token: 0x0401E34F RID: 123727
		[Nullable(2)]
		private PayShopRecommendData RecommendData;

		// Token: 0x0200AF83 RID: 44931
		private enum EComponent
		{
			// Token: 0x04036769 RID: 223081
			Content
		}
	}
}
