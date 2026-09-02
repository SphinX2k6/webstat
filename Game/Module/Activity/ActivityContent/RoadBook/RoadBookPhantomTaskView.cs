using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064A1 RID: 25761
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookPhantomTaskView : UiViewBase
	{
		// Token: 0x06040978 RID: 264568 RVA: 0x0108E88C File Offset: 0x0108CA8C
		public RoadBookPhantomTaskView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040979 RID: 264569 RVA: 0x0108E898 File Offset: 0x0108CA98
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0604097A RID: 264570 RVA: 0x0108E900 File Offset: 0x0108CB00
		protected override UniTask OnBeforeStartAsync()
		{
			RoadBookPhantomTaskView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoadBookPhantomTaskView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604097B RID: 264571 RVA: 0x0108E943 File Offset: 0x0108CB43
		private PhantomCardItem OnCreateItem()
		{
			return new PhantomCardItem(this.ActivityBaseData);
		}

		// Token: 0x0604097C RID: 264572 RVA: 0x0108E950 File Offset: 0x0108CB50
		protected UniTask Refresh()
		{
			RoadBookPhantomTaskView.<Refresh>d__8 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<RoadBookPhantomTaskView.<Refresh>d__8>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x0604097D RID: 264573 RVA: 0x0108E994 File Offset: 0x0108CB94
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.ActivityBaseData.LocalConfig.Value.HelpId);
		}

		// Token: 0x0604097E RID: 264574 RVA: 0x0108E9C4 File Offset: 0x0108CBC4
		private void ScrollToCenter(int index)
		{
			UUIItem item = this.AreaLayoutList.GetItemByIndex(Math.Max(index, 0));
			if (item != null)
			{
				TTimerAction <>9__1;
				this.AreaLayoutList.BindLateUpdate(delegate(float delta)
				{
					TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
					TTimerAction action;
					if ((action = <>9__1) == null)
					{
						action = (<>9__1 = delegate(float _)
						{
							UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = this.GetScrollViewWithScrollbar(2);
							int num = (int)Math.Floor((double)(this.AreaLayoutList.ScrollWidth / item.Width / 2f));
							UUIItem itemByIndex = this.AreaLayoutList.GetItemByIndex(Math.Max(index - num, 0));
							FVector relativeLocation = scrollViewWithScrollbar.ContentUIItem.Get().RelativeLocation;
							FVector2D fvector2D = new FVector2D(ref relativeLocation);
							scrollViewWithScrollbar.ScrollToLeft(ref fvector2D, itemByIndex, false);
						});
					}
					gameplayTimeInstance.Next(action, null, null);
					this.AreaLayoutList.UnBindLateUpdate();
				});
			}
		}

		// Token: 0x0402429C RID: 148124
		[Nullable(2)]
		private PopupCaptionItem CaptionComponent;

		// Token: 0x0402429D RID: 148125
		private ActivityRoadBookData ActivityBaseData;

		// Token: 0x0402429E RID: 148126
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402429F RID: 148127
		private GenericScrollViewNew<PhantomCardItem, int> AreaLayoutList;
	}
}
