using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.RoleUnlock
{
	// Token: 0x02005524 RID: 21796
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaRoleUnlockView : UiViewBase
	{
		// Token: 0x0603799F RID: 227743 RVA: 0x00E1BBD3 File Offset: 0x00E19DD3
		public PhantomArenaRoleUnlockView(UiViewInfo uiViewInfo) : base(uiViewInfo)
		{
		}

		// Token: 0x060379A0 RID: 227744 RVA: 0x00E1BBDC File Offset: 0x00E19DDC
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

		// Token: 0x060379A1 RID: 227745 RVA: 0x00E1BCC8 File Offset: 0x00E19EC8
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaRoleUnlockView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaRoleUnlockView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060379A2 RID: 227746 RVA: 0x00E1BD0B File Offset: 0x00E19F0B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnSeqEvent));
		}

		// Token: 0x060379A3 RID: 227747 RVA: 0x00E1BD29 File Offset: 0x00E19F29
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnSeqEvent));
		}

		// Token: 0x060379A4 RID: 227748 RVA: 0x00E1BD48 File Offset: 0x00E19F48
		protected void RefreshViewByCardRoleId(int cardRoleId)
		{
			PhantomBattleCardRole phantomBattleCardRole = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(cardRoleId);
			int roleConfigId = phantomBattleCardRole.RoleConfigId;
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), roleConfig.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), phantomBattleCardRole.BgDesc, Array.Empty<object>());
			base.GetTexture(2).SetTexture(this.RoleTexture);
		}

		// Token: 0x060379A5 RID: 227749 RVA: 0x00E1BDCC File Offset: 0x00E19FCC
		public void ShowNext()
		{
			UiAsyncTask task = new UiAsyncTask("PhantomArenaRoleUnlockView", delegate()
			{
				PhantomArenaRoleUnlockView.<<ShowNext>b__11_0>d <<ShowNext>b__11_0>d;
				<<ShowNext>b__11_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<ShowNext>b__11_0>d.<>4__this = this;
				<<ShowNext>b__11_0>d.<>1__state = -1;
				<<ShowNext>b__11_0>d.<>t__builder.Start<PhantomArenaRoleUnlockView.<<ShowNext>b__11_0>d>(ref <<ShowNext>b__11_0>d);
				return <<ShowNext>b__11_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x060379A6 RID: 227750 RVA: 0x00E1BE00 File Offset: 0x00E1A000
		public UniTask ShowNextAsync()
		{
			PhantomArenaRoleUnlockView.<ShowNextAsync>d__12 <ShowNextAsync>d__;
			<ShowNextAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowNextAsync>d__.<>4__this = this;
			<ShowNextAsync>d__.<>1__state = -1;
			<ShowNextAsync>d__.<>t__builder.Start<PhantomArenaRoleUnlockView.<ShowNextAsync>d__12>(ref <ShowNextAsync>d__);
			return <ShowNextAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060379A7 RID: 227751 RVA: 0x00E1BE43 File Offset: 0x00E1A043
		private void OnCloseBtnClick()
		{
			if (ModelBase<PhantomArenaModel>.Instance.RoleUnlockQueue.Count > 0)
			{
				this.ShowNext();
				return;
			}
			base.CloseMe(delegate(bool _)
			{
				Action callbackOnClose = this.CallbackOnClose;
				if (callbackOnClose == null)
				{
					return;
				}
				callbackOnClose();
			});
		}

		// Token: 0x060379A8 RID: 227752 RVA: 0x00E1BE70 File Offset: 0x00E1A070
		protected override void OnAfterDestroy()
		{
			ControllerBase<PhantomArenaController>.Instance.PostUnlockView();
		}

		// Token: 0x060379A9 RID: 227753 RVA: 0x00E1BE7D File Offset: 0x00E1A07D
		private void OnSeqEvent(string param)
		{
			if (this.IsWaitingChange && param == "Change")
			{
				this.RefreshViewByCardRoleId(this.CardRoleId);
			}
		}

		// Token: 0x0401FE0C RID: 130572
		protected int CardRoleId;

		// Token: 0x0401FE0D RID: 130573
		protected bool IsWaitingChange;

		// Token: 0x0401FE0E RID: 130574
		protected UTexture RoleTexture;

		// Token: 0x0401FE0F RID: 130575
		[Nullable(2)]
		private Action CallbackOnClose;

		// Token: 0x0200B4BB RID: 46267
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037F3F RID: 229183
			public const int CloseBtn = 0;

			// Token: 0x04037F40 RID: 229184
			public const int RoleRootItem = 1;

			// Token: 0x04037F41 RID: 229185
			public const int RoleTexture = 2;

			// Token: 0x04037F42 RID: 229186
			public const int BadgeRootItem = 3;

			// Token: 0x04037F43 RID: 229187
			public const int BadgeSprite = 4;

			// Token: 0x04037F44 RID: 229188
			public const int TitleText = 5;

			// Token: 0x04037F45 RID: 229189
			public const int NameText = 6;

			// Token: 0x04037F46 RID: 229190
			public const int BgDescText = 7;
		}
	}
}
