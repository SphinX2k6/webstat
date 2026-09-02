using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200515D RID: 20829
	[NullableContext(1)]
	[Nullable(0)]
	public class EventResultViewAll : RogueSelectResultBaseView
	{
		// Token: 0x060359BD RID: 219581 RVA: 0x00D7732B File Offset: 0x00D7552B
		public EventResultViewAll(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060359BE RID: 219582 RVA: 0x00D77334 File Offset: 0x00D75534
		protected override void CloseBtn()
		{
			base.CloseMe(delegate(bool success)
			{
				EventResult eventResult = this.EventResult;
				if (eventResult == null)
				{
					return;
				}
				Action<bool?> callback = eventResult.Callback;
				if (callback == null)
				{
					return;
				}
				callback(new bool?(success));
			});
		}

		// Token: 0x060359BF RID: 219583 RVA: 0x00D77348 File Offset: 0x00D75548
		protected override UniTask OnBeforeStartAsync()
		{
			EventResultViewAll.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EventResultViewAll.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060359C0 RID: 219584 RVA: 0x00D7738B File Offset: 0x00D7558B
		protected CommonSelectItem CreateCommonSelectItem()
		{
			return new CommonSelectItem();
		}

		// Token: 0x060359C1 RID: 219585 RVA: 0x00D77394 File Offset: 0x00D75594
		protected override void OnStart()
		{
			base.OnStart();
			this.EventResult = (this.OpenParam as EventResult);
			UUIItem rootComponent = base.GetHorizontalLayout(3).GetRootComponent();
			this.CommonItemActor.UiItem.SetUIParent(rootComponent, false);
			this.Refresh();
		}

		// Token: 0x060359C2 RID: 219586 RVA: 0x00D773DD File Offset: 0x00D755DD
		protected override void OnBeforeDestroy()
		{
			GenericLayout<CommonSelectItem, RogueGainEntry> commonSelectItemLayout = this.CommonSelectItemLayout;
			if (commonSelectItemLayout != null)
			{
				commonSelectItemLayout.ClearChildren();
			}
			if (this.CommonItemActor != null)
			{
				Singleton<UiActorPool>.Instance.RecycleAsync(this.CommonItemActor, "UiItem_CommonSelectItem_Prefab");
			}
		}

		// Token: 0x060359C3 RID: 219587 RVA: 0x00D7740D File Offset: 0x00D7560D
		protected override void OnDescModelChange()
		{
			this.Refresh();
		}

		// Token: 0x060359C4 RID: 219588 RVA: 0x00D77418 File Offset: 0x00D75618
		protected override void Refresh()
		{
			this.CommonSelectItemLayout.RefreshByDataAsync(this.EventResult.RogueGainEntryArray, false, null).ContinueWith(delegate()
			{
				this.CommonSelectItemLayout.GetLayoutItemList().ForEach(delegate(CommonSelectItem item)
				{
					item.SetToggleUnDetermined();
				});
			});
			this.RefreshTitleText();
		}

		// Token: 0x060359C5 RID: 219589 RVA: 0x00D7745D File Offset: 0x00D7565D
		protected void RefreshTitleText()
		{
			base.GetText(4).ShowTextNew("RoguelikeView_20_Text");
		}

		// Token: 0x0401ECA9 RID: 126121
		private EventResult EventResult;

		// Token: 0x0401ECAA RID: 126122
		private UiPoolActor CommonItemActor;

		// Token: 0x0401ECAB RID: 126123
		protected GenericLayout<CommonSelectItem, RogueGainEntry> CommonSelectItemLayout;
	}
}
