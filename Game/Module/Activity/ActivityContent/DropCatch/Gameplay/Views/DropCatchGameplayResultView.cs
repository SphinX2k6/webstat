using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x0200690B RID: 26891
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayResultView : UiViewBase
	{
		// Token: 0x06042CA6 RID: 273574 RVA: 0x011240DE File Offset: 0x011222DE
		public DropCatchGameplayResultView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042CA7 RID: 273575 RVA: 0x011240E8 File Offset: 0x011222E8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIArtText)),
				new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.OnButtonBackClick)),
				new ValueTuple<int, Delegate>(7, new Action(this.OnButtonNextClick)),
				new ValueTuple<int, Delegate>(8, new Action(this.OnButtonRestartClick))
			};
			this.Proxy = (this.OpenParam as DropCatchGameplayProxy);
		}

		// Token: 0x06042CA8 RID: 273576 RVA: 0x01124270 File Offset: 0x01122470
		protected override UniTask OnBeforeStartAsync()
		{
			DropCatchGameplayResultView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DropCatchGameplayResultView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042CA9 RID: 273577 RVA: 0x011242B3 File Offset: 0x011224B3
		protected override void OnStart()
		{
			this.RefreshGameplayName();
			this.RefreshResultScore();
			this.InitStarLayout();
			this.InitDropItemListLayout();
			this.RefreshButtonState();
		}

		// Token: 0x06042CAA RID: 273578 RVA: 0x011242D4 File Offset: 0x011224D4
		private void RefreshGameplayName()
		{
			DropCatchGameplay? gameplayConfig = this.Proxy.GetGameplayConfig();
			if (gameplayConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "获取关卡配置失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.Proxy.GetCurGameplayId());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), gameplayConfig.Value.Name, Array.Empty<object>());
		}

		// Token: 0x06042CAB RID: 273579 RVA: 0x01124358 File Offset: 0x01122558
		private void RefreshResultScore()
		{
			UUIArtText artText = base.GetArtText(3);
			if (artText == null)
			{
				return;
			}
			artText.SetText(this.Proxy.GetCurScore().ToString());
		}

		// Token: 0x06042CAC RID: 273580 RVA: 0x0112438C File Offset: 0x0112258C
		private void InitStarLayout()
		{
			DropCatchGameplayViewModel gameplayViewModel = this.Proxy.GetGameplayViewModel();
			List<float> list = (gameplayViewModel != null) ? gameplayViewModel.GetScoreLevels() : null;
			if (list == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "获取关卡配置失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.Proxy.GetCurGameplayId());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.StarLayout = new GenericLayout<DropCatchStarItemView, bool>(base.GetHorizontalLayout(1), () => new DropCatchStarItemView(), null, false, true);
			List<bool> list2 = new List<bool>();
			foreach (float num in list)
			{
				list2.Add(this.Proxy.GetCurScore() >= num);
			}
			this.StarLayout.RefreshByData(list2, null, false);
		}

		// Token: 0x06042CAD RID: 273581 RVA: 0x0112448C File Offset: 0x0112268C
		private void InitDropItemListLayout()
		{
			this.DropItemListLayout = new GenericLayout<DropItemListItem, IDropItemListItemData>(base.GetVerticalLayout(4), () => new DropItemListItem(), null, false, true);
			DropCatchGameplayProxy dropCatchGameplayProxy = this.OpenParam as DropCatchGameplayProxy;
			List<IDropItemListItemData> list = new List<IDropItemListItemData>();
			Dictionary<int, int> dropItemRecord = dropCatchGameplayProxy.GetDropItemRecord();
			if (dropItemRecord != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in dropItemRecord)
				{
					list.Add(new IDropItemListItemData
					{
						Id = keyValuePair.Key,
						Count = keyValuePair.Value
					});
				}
			}
			this.DropItemListLayout.RefreshByData(list, null, true);
		}

		// Token: 0x06042CAE RID: 273582 RVA: 0x01124554 File Offset: 0x01122754
		private UniTask InitRoleView()
		{
			DropCatchGameplayResultView.<InitRoleView>d__11 <InitRoleView>d__;
			<InitRoleView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleView>d__.<>4__this = this;
			<InitRoleView>d__.<>1__state = -1;
			<InitRoleView>d__.<>t__builder.Start<DropCatchGameplayResultView.<InitRoleView>d__11>(ref <InitRoleView>d__);
			return <InitRoleView>d__.<>t__builder.Task;
		}

		// Token: 0x06042CAF RID: 273583 RVA: 0x01124598 File Offset: 0x01122798
		private void RefreshButtonState()
		{
			DropCatchGameplayViewModel gameplayViewModel = this.Proxy.GetGameplayViewModel();
			List<float> list = (gameplayViewModel != null) ? gameplayViewModel.GetScoreLevels() : null;
			if (list == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "获取关卡配置失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.Proxy.GetCurGameplayId());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			bool flag = true;
			foreach (float num in list)
			{
				if (this.Proxy.GetCurScore() < num)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				UUIButtonComponent button = base.GetButton(8);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(false);
				}
				DropCatchGameplay? dropCatchGameplay;
				int? num2 = (this.Proxy.GetGameplayConfig() != null) ? new int?(dropCatchGameplay.GetValueOrDefault().NextGameplayId) : null;
				DropCatchActivityController dropCatchActivityController = ActivityManager.GetActivityController(ActivityType.DropCatchActivity) as DropCatchActivityController;
				UUIButtonComponent button2 = base.GetButton(6);
				if (button2 != null)
				{
					button2.RootUIComp.Get().SetUIActive(true);
				}
				UUIButtonComponent button3 = base.GetButton(7);
				if (button3 == null)
				{
					return;
				}
				button3.RootUIComp.Get().SetUIActive(num2 != null && dropCatchActivityController.CheckLevelUnlock(num2.Value));
				return;
			}
			else
			{
				UUIButtonComponent button4 = base.GetButton(6);
				if (button4 != null)
				{
					button4.RootUIComp.Get().SetUIActive(true);
				}
				UUIButtonComponent button5 = base.GetButton(8);
				if (button5 != null)
				{
					button5.RootUIComp.Get().SetUIActive(true);
				}
				UUIButtonComponent button6 = base.GetButton(7);
				if (button6 == null)
				{
					return;
				}
				button6.RootUIComp.Get().SetUIActive(false);
				return;
			}
		}

		// Token: 0x06042CB0 RID: 273584 RVA: 0x01124778 File Offset: 0x01122978
		private void OnButtonBackClick()
		{
			this.MarkOpenLevelId();
			DropCatchGameplayProxy proxy = this.Proxy;
			if (proxy != null)
			{
				proxy.EndGameplay();
			}
			base.CloseMe(null);
		}

		// Token: 0x06042CB1 RID: 273585 RVA: 0x01124798 File Offset: 0x01122998
		private void OnButtonNextClick()
		{
			if (this.CheckIfActivityClose())
			{
				return;
			}
			DropCatchGameplay? dropCatchGameplay;
			int? num = (this.Proxy.GetGameplayConfig() != null) ? new int?(dropCatchGameplay.GetValueOrDefault().NextGameplayId) : null;
			if (num != null)
			{
				DropCatchGameplayProxy proxy = this.Proxy;
				if (proxy != null)
				{
					proxy.StartGameplay(num.Value);
				}
			}
			else
			{
				this.MarkOpenLevelId();
				DropCatchGameplayProxy proxy2 = this.Proxy;
				if (proxy2 != null)
				{
					proxy2.EndGameplay();
				}
			}
			base.CloseMe(null);
		}

		// Token: 0x06042CB2 RID: 273586 RVA: 0x01124825 File Offset: 0x01122A25
		private void MarkOpenLevelId()
		{
			DropCatchActivityController dropCatchActivityController = ActivityManager.GetActivityController(ActivityType.DropCatchActivity) as DropCatchActivityController;
			if (dropCatchActivityController == null)
			{
				return;
			}
			dropCatchActivityController.SetPreferredOpenLevel(this.Proxy.GetCurGameplayId());
		}

		// Token: 0x06042CB3 RID: 273587 RVA: 0x01124848 File Offset: 0x01122A48
		private void OnButtonRestartClick()
		{
			if (this.CheckIfActivityClose())
			{
				return;
			}
			DropCatchGameplayProxy proxy = this.Proxy;
			if (proxy != null)
			{
				proxy.StartGameplay(this.Proxy.GetCurGameplayId());
			}
			base.CloseMe(null);
		}

		// Token: 0x06042CB4 RID: 273588 RVA: 0x01124877 File Offset: 0x01122A77
		private bool CheckIfActivityClose()
		{
			return (ActivityManager.GetActivityController(ActivityType.DropCatchActivity) as DropCatchActivityController).CheckIfActivityClose(true);
		}

		// Token: 0x0402537C RID: 152444
		private DropCatchGameplayProxy Proxy;

		// Token: 0x0402537D RID: 152445
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<DropCatchStarItemView, bool> StarLayout;

		// Token: 0x0402537E RID: 152446
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DropItemListItem, IDropItemListItemData> DropItemListLayout;
	}
}
