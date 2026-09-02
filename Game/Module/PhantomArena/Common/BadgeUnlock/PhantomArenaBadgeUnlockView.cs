using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.BadgeUnlock
{
	// Token: 0x0200558D RID: 21901
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBadgeUnlockView : UiViewBase
	{
		// Token: 0x06037C78 RID: 228472 RVA: 0x00E22C6D File Offset: 0x00E20E6D
		public PhantomArenaBadgeUnlockView(UiViewInfo uiViewInfo) : base(uiViewInfo)
		{
		}

		// Token: 0x06037C79 RID: 228473 RVA: 0x00E22C78 File Offset: 0x00E20E78
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick))
			};
		}

		// Token: 0x06037C7A RID: 228474 RVA: 0x00E22D64 File Offset: 0x00E20F64
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBadgeUnlockView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBadgeUnlockView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037C7B RID: 228475 RVA: 0x00E22DA7 File Offset: 0x00E20FA7
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnSeqEvent));
		}

		// Token: 0x06037C7C RID: 228476 RVA: 0x00E22DC5 File Offset: 0x00E20FC5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnSeqEvent));
		}

		// Token: 0x06037C7D RID: 228477 RVA: 0x00E22DE4 File Offset: 0x00E20FE4
		public void ShowNext()
		{
			UiAsyncTask task = new UiAsyncTask("PhantomArenaBadgeUnlockView", delegate()
			{
				PhantomArenaBadgeUnlockView.<<ShowNext>b__9_0>d <<ShowNext>b__9_0>d;
				<<ShowNext>b__9_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<ShowNext>b__9_0>d.<>4__this = this;
				<<ShowNext>b__9_0>d.<>1__state = -1;
				<<ShowNext>b__9_0>d.<>t__builder.Start<PhantomArenaBadgeUnlockView.<<ShowNext>b__9_0>d>(ref <<ShowNext>b__9_0>d);
				return <<ShowNext>b__9_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x06037C7E RID: 228478 RVA: 0x00E22E18 File Offset: 0x00E21018
		public UniTask ShowNextAsync()
		{
			PhantomArenaBadgeUnlockView.<ShowNextAsync>d__10 <ShowNextAsync>d__;
			<ShowNextAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowNextAsync>d__.<>4__this = this;
			<ShowNextAsync>d__.<>1__state = -1;
			<ShowNextAsync>d__.<>t__builder.Start<PhantomArenaBadgeUnlockView.<ShowNextAsync>d__10>(ref <ShowNextAsync>d__);
			return <ShowNextAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037C7F RID: 228479 RVA: 0x00E22E5C File Offset: 0x00E2105C
		public void RefreshViewByBadgeId(int badgeId)
		{
			PhantomBattleBadge phantomBattleBadgeById = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBadgeById(badgeId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), phantomBattleBadgeById.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), phantomBattleBadgeById.Desc, Array.Empty<object>());
			base.GetSprite(4).SetSprite(this.BadgeSprite, true);
		}

		// Token: 0x06037C80 RID: 228480 RVA: 0x00E22EC2 File Offset: 0x00E210C2
		private void OnCloseBtnClick()
		{
			if (ModelBase<PhantomArenaModel>.Instance.BadgeUnlockQueue.Count > 0)
			{
				this.ShowNext();
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x06037C81 RID: 228481 RVA: 0x00E22EE4 File Offset: 0x00E210E4
		protected override void OnAfterDestroy()
		{
			ControllerBase<PhantomArenaController>.Instance.PostUnlockView();
		}

		// Token: 0x06037C82 RID: 228482 RVA: 0x00E22EF1 File Offset: 0x00E210F1
		private void OnSeqEvent(string param)
		{
			if (this.IsWaitingChange && param == "Change")
			{
				this.RefreshViewByBadgeId(this.BadgeId);
				this.IsWaitingChange = false;
			}
		}

		// Token: 0x0401FECC RID: 130764
		protected int BadgeId;

		// Token: 0x0401FECD RID: 130765
		protected bool IsWaitingChange;

		// Token: 0x0401FECE RID: 130766
		protected ULGUISpriteData_BaseObject BadgeSprite;

		// Token: 0x0200B528 RID: 46376
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04038133 RID: 229683
			public const int CloseBtn = 0;

			// Token: 0x04038134 RID: 229684
			public const int RoleRootItem = 1;

			// Token: 0x04038135 RID: 229685
			public const int RoleTexture = 2;

			// Token: 0x04038136 RID: 229686
			public const int BadgeRootItem = 3;

			// Token: 0x04038137 RID: 229687
			public const int BadgeSprite = 4;

			// Token: 0x04038138 RID: 229688
			public const int TitleText = 5;

			// Token: 0x04038139 RID: 229689
			public const int NameText = 6;

			// Token: 0x0403813A RID: 229690
			public const int BgDescText = 7;
		}
	}
}
