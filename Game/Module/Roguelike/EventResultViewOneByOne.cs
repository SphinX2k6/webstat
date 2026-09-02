using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200515C RID: 20828
	[NullableContext(1)]
	[Nullable(0)]
	public class EventResultViewOneByOne : RogueSelectResultBaseView
	{
		// Token: 0x060359B2 RID: 219570 RVA: 0x00D7713A File Offset: 0x00D7533A
		public EventResultViewOneByOne(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060359B3 RID: 219571 RVA: 0x00D77144 File Offset: 0x00D75344
		protected override void CloseBtn()
		{
			if (this.CurIndex + 1 >= this.EventResult.RogueGainEntryArray.Count)
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
				return;
			}
			base.PlaySequence("Start", null, false);
			this.CurIndex++;
			this.Refresh();
		}

		// Token: 0x060359B4 RID: 219572 RVA: 0x00D771A0 File Offset: 0x00D753A0
		protected override UniTask OnBeforeStartAsync()
		{
			EventResultViewOneByOne.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EventResultViewOneByOne.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060359B5 RID: 219573 RVA: 0x00D771E3 File Offset: 0x00D753E3
		protected CommonSelectItem CreateCommonSelectItem()
		{
			return new CommonSelectItem();
		}

		// Token: 0x060359B6 RID: 219574 RVA: 0x00D771EC File Offset: 0x00D753EC
		protected override void OnStart()
		{
			base.OnStart();
			this.EventResult = (this.OpenParam as EventResult);
			UUIItem rootComponent = base.GetHorizontalLayout(3).GetRootComponent();
			this.CommonItemActor.UiItem.SetUIParent(rootComponent, false);
			this.Refresh();
		}

		// Token: 0x060359B7 RID: 219575 RVA: 0x00D77235 File Offset: 0x00D75435
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

		// Token: 0x060359B8 RID: 219576 RVA: 0x00D77265 File Offset: 0x00D75465
		protected override void OnDescModelChange()
		{
			this.Refresh();
		}

		// Token: 0x060359B9 RID: 219577 RVA: 0x00D77270 File Offset: 0x00D75470
		protected override void Refresh()
		{
			this.CommonSelectItemLayout.RefreshByDataAsync(new <>z__ReadOnlySingleElementList<RogueGainEntry>(this.EventResult.RogueGainEntryArray[this.CurIndex]), false, null).ContinueWith(delegate()
			{
				this.CommonSelectItemLayout.GetLayoutItemList().ForEach(delegate(CommonSelectItem item)
				{
					item.SetToggleUnDetermined();
				});
			});
			this.RefreshTitleText();
		}

		// Token: 0x060359BA RID: 219578 RVA: 0x00D772C5 File Offset: 0x00D754C5
		protected void RefreshTitleText()
		{
			base.GetText(4).ShowTextNew("RoguelikeView_20_Text");
		}

		// Token: 0x0401ECA5 RID: 126117
		private EventResult EventResult;

		// Token: 0x0401ECA6 RID: 126118
		private int CurIndex;

		// Token: 0x0401ECA7 RID: 126119
		private UiPoolActor CommonItemActor;

		// Token: 0x0401ECA8 RID: 126120
		protected GenericLayout<CommonSelectItem, RogueGainEntry> CommonSelectItemLayout;
	}
}
