using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006543 RID: 25923
	[NullableContext(1)]
	[Nullable(0)]
	public class RealmBetweenPhantomTaskView : UiViewBase
	{
		// Token: 0x06040CCE RID: 265422 RVA: 0x0109DBE8 File Offset: 0x0109BDE8
		public RealmBetweenPhantomTaskView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040CCF RID: 265423 RVA: 0x0109DBF4 File Offset: 0x0109BDF4
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

		// Token: 0x06040CD0 RID: 265424 RVA: 0x0109DC5C File Offset: 0x0109BE5C
		protected override UniTask OnBeforeStartAsync()
		{
			RealmBetweenPhantomTaskView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RealmBetweenPhantomTaskView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040CD1 RID: 265425 RVA: 0x0109DCA0 File Offset: 0x0109BEA0
		protected override void OnBeforeShow()
		{
			foreach (KeyValuePair<int, bool> keyValuePair in this.ActivityData.PhantomDataMap)
			{
				int key = keyValuePair.Key;
				if (keyValuePair.Value)
				{
					int id = key - 6000000;
					this.ActivityData.SaveFirstCheckRedDotState(ERealmBetweenSaveFlag.PhantomCollectNewUnlock, id);
				}
			}
		}

		// Token: 0x06040CD2 RID: 265426 RVA: 0x0109DD18 File Offset: 0x0109BF18
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.ActivityData.LocalConfig.Value.HelpId);
		}

		// Token: 0x06040CD3 RID: 265427 RVA: 0x0109DD47 File Offset: 0x0109BF47
		private RealmBetweenPhantomCardItem OnCreateItem()
		{
			return new RealmBetweenPhantomCardItem(this.ActivityData);
		}

		// Token: 0x06040CD4 RID: 265428 RVA: 0x0109DD54 File Offset: 0x0109BF54
		protected UniTask Refresh()
		{
			RealmBetweenPhantomTaskView.<Refresh>d__10 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<RealmBetweenPhantomTaskView.<Refresh>d__10>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x06040CD5 RID: 265429 RVA: 0x0109DD98 File Offset: 0x0109BF98
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

		// Token: 0x0402459B RID: 148891
		private ActivityRealmBetweenData ActivityData;

		// Token: 0x0402459C RID: 148892
		private GenericScrollViewNew<RealmBetweenPhantomCardItem, int> AreaLayoutList;

		// Token: 0x0402459D RID: 148893
		private PopupCaptionItem CaptionComponent;

		// Token: 0x0402459E RID: 148894
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;
	}
}
