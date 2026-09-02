using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB7 RID: 23991
	[NullableContext(2)]
	[Nullable(0)]
	public class DreamLinkWhiteCatView : UiTickViewBase
	{
		// Token: 0x0603C66B RID: 247403 RVA: 0x00F54B86 File Offset: 0x00F52D86
		[NullableContext(1)]
		public DreamLinkWhiteCatView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603C66C RID: 247404 RVA: 0x00F54B90 File Offset: 0x00F52D90
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C66D RID: 247405 RVA: 0x00F54D6C File Offset: 0x00F52F6C
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkWhiteCatView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkWhiteCatView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C66E RID: 247406 RVA: 0x00F54DB0 File Offset: 0x00F52FB0
		protected override void OnStart()
		{
			bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female;
			EDreamLinkSpineDefine edreamLinkSpineDefine = flag ? EDreamLinkSpineDefine.MainFemale : EDreamLinkSpineDefine.MainMale;
			base.GetSpine(4).SetAnimation(0, edreamLinkSpineDefine.ToString(), true);
			base.GetItem(5).SetUIActive(!flag);
			base.GetItem(6).SetUIActive(flag);
		}

		// Token: 0x0603C66F RID: 247407 RVA: 0x00F54E14 File Offset: 0x00F53014
		protected override void OnBeforeShow()
		{
			this.RefreshRedDot();
		}

		// Token: 0x0603C670 RID: 247408 RVA: 0x00F54E1C File Offset: 0x00F5301C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
			Singleton<EventSystem>.Instance.Add(EEventName.ActivityCrossDayRefresh, new Action(this.OnActivityCrossDayRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.DreamLinkRewardRefresh, new Action(this.RefreshRedDot));
		}

		// Token: 0x0603C671 RID: 247409 RVA: 0x00F54E80 File Offset: 0x00F53080
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.ActivityCrossDayRefresh, new Action(this.OnActivityCrossDayRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.DreamLinkRewardRefresh, new Action(this.RefreshRedDot));
		}

		// Token: 0x0603C672 RID: 247410 RVA: 0x00F54EE1 File Offset: 0x00F530E1
		protected override void OnTick(float delta)
		{
			if (!this.NeedTickState)
			{
				return;
			}
			this.RefreshFunctionCondition();
		}

		// Token: 0x0603C673 RID: 247411 RVA: 0x00F54EF4 File Offset: 0x00F530F4
		[NullableContext(1)]
		private void OnActivitySequenceEmitEvent(string param)
		{
			if (param == "Start")
			{
				base.GetSpine(3).SetAnimation(0, EDreamLinkSpineDefine.Start.ToString(), false);
				return;
			}
			if (param == "idle")
			{
				base.GetSpine(3).SetAnimation(0, EDreamLinkSpineDefine.Idle.ToString(), true);
			}
		}

		// Token: 0x0603C674 RID: 247412 RVA: 0x00F54F5A File Offset: 0x00F5315A
		private void OnActivityCrossDayRefresh()
		{
			if (this.SelectOnData != null)
			{
				this.LoopScrollView.RefreshAllGridProxies();
				this.RefreshFunctionArea(this.SelectOnData);
			}
		}

		// Token: 0x0603C675 RID: 247413 RVA: 0x00F54F7B File Offset: 0x00F5317B
		private void RefreshRedDot()
		{
			this.ButtonItem.SetRedDotVisible(this.ActivityBaseData.CheckHasBossReward());
		}

		// Token: 0x0603C676 RID: 247414 RVA: 0x00F54F93 File Offset: 0x00F53193
		[NullableContext(1)]
		private DreamLinkBossInstanceItem OnCreateInstanceItem()
		{
			return new DreamLinkBossInstanceItem
			{
				ToggleFunction = new Action<DreamLinkBossInstanceData, int>(this.InstItemSelectOnFunction)
			};
		}

		// Token: 0x0603C677 RID: 247415 RVA: 0x00F54FAC File Offset: 0x00F531AC
		[NullableContext(1)]
		private void InstItemSelectOnFunction(DreamLinkBossInstanceData data, int index)
		{
			this.SelectOnData = data;
			this.RefreshFunctionArea(data);
			if (this.SelectOnIndex == index)
			{
				return;
			}
			this.LoopScrollView.DeselectCurrentGridProxy(true);
			this.SelectOnIndex = index;
			this.LoopScrollView.SelectGridProxy(this.SelectOnIndex, false);
		}

		// Token: 0x0603C678 RID: 247416 RVA: 0x00F54FEC File Offset: 0x00F531EC
		[NullableContext(1)]
		private void RefreshFunctionArea(DreamLinkBossInstanceData data)
		{
			this.SelectOnData = data;
			this.NeedTickState = data.GetTickState();
			this.SelectRolePanel.SetActive(data.IsUnlock);
			this.ActivityBaseData.FixBossRoleId(data.InstId);
			this.SelectRolePanel.RefreshInstId(data.InstId);
			this.FunctionalComponent.FunctionButton.SetActive(data.IsUnlock);
			this.FunctionalComponent.SetPanelConditionVisible(!data.IsUnlock);
			this.RefreshFunctionCondition();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(data.InstId);
			if (config == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), config.Value.MapName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), config.Value.DungeonDesc, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), config.Value.MonsterTips, Array.Empty<object>());
		}

		// Token: 0x0603C679 RID: 247417 RVA: 0x00F550FC File Offset: 0x00F532FC
		private void RefreshFunctionCondition()
		{
			if (this.SelectOnData != null)
			{
				this.FunctionalComponent.SetLockTextByText(this.SelectOnData.GetUnlockText());
			}
		}

		// Token: 0x0603C67A RID: 247418 RVA: 0x00F5511C File Offset: 0x00F5331C
		private UniTask RefreshLayout()
		{
			DreamLinkWhiteCatView.<RefreshLayout>d__25 <RefreshLayout>d__;
			<RefreshLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshLayout>d__.<>4__this = this;
			<RefreshLayout>d__.<>1__state = -1;
			<RefreshLayout>d__.<>t__builder.Start<DreamLinkWhiteCatView.<RefreshLayout>d__25>(ref <RefreshLayout>d__);
			return <RefreshLayout>d__.<>t__builder.Task;
		}

		// Token: 0x0603C67B RID: 247419 RVA: 0x00F55160 File Offset: 0x00F53360
		private void OnBtnConfirmClick()
		{
			int[] bossRoleIdList = this.SelectOnData.GetBossRoleIdList();
			int[] array = bossRoleIdList;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == 0)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DaMaoTips_NotEnough", Array.Empty<object>());
					return;
				}
			}
			int instId = this.SelectOnData.InstId;
			RogueWhiteCatCtx rogueWhiteCatCtx = new RogueWhiteCatCtx();
			rogueWhiteCatCtx.ActivityId = this.ActivityBaseData.Id;
			rogueWhiteCatCtx.IsFirst = false;
			rogueWhiteCatCtx.Idnex = this.SelectOnData.TypeId;
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.RogueWhiteCatCtx = rogueWhiteCatCtx;
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instId, bossRoleIdList.ToList<int>(), 0, 0, null, null);
		}

		// Token: 0x0603C67C RID: 247420 RVA: 0x00F55209 File Offset: 0x00F53409
		private void OpenBossReward(int _)
		{
			this.ActivityBaseData.SaveFirstCheckRedDotState(7, 0);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, this.ActivityBaseData.GetBossRewardData(), null);
			this.RefreshRedDot();
		}

		// Token: 0x04021F59 RID: 139097
		protected DreamLinkData ActivityBaseData;

		// Token: 0x04021F5A RID: 139098
		private PopupCaptionItem CaptionComponent;

		// Token: 0x04021F5B RID: 139099
		private DreamLinkRoleSelectPanel SelectRolePanel;

		// Token: 0x04021F5C RID: 139100
		private ButtonItem ButtonItem;

		// Token: 0x04021F5D RID: 139101
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<DreamLinkBossInstanceItem, DreamLinkBossInstanceData> LoopScrollView;

		// Token: 0x04021F5E RID: 139102
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x04021F5F RID: 139103
		private DreamLinkBossInstanceData SelectOnData;

		// Token: 0x04021F60 RID: 139104
		private bool NeedTickState;

		// Token: 0x04021F61 RID: 139105
		private int SelectOnIndex;

		// Token: 0x0200BE03 RID: 48643
		[NullableContext(0)]
		private class EDreamLinkWhiteCatViewDefine
		{
			// Token: 0x0403A7E5 RID: 239589
			public const int CaptionItem = 0;

			// Token: 0x0403A7E6 RID: 239590
			public const int SelectRolePanel = 1;

			// Token: 0x0403A7E7 RID: 239591
			public const int FunctionArea = 2;

			// Token: 0x0403A7E8 RID: 239592
			public const int SpineCat = 3;

			// Token: 0x0403A7E9 RID: 239593
			public const int SpineCharacter = 4;

			// Token: 0x0403A7EA RID: 239594
			public const int CharacterMaleItem = 5;

			// Token: 0x0403A7EB RID: 239595
			public const int CharacterFemaleItem = 6;

			// Token: 0x0403A7EC RID: 239596
			public const int PanelLayout = 7;

			// Token: 0x0403A7ED RID: 239597
			public const int InstanceItem = 8;

			// Token: 0x0403A7EE RID: 239598
			public const int ButtonReward = 9;

			// Token: 0x0403A7EF RID: 239599
			public const int InstTitle = 10;

			// Token: 0x0403A7F0 RID: 239600
			public const int InstDescription = 11;

			// Token: 0x0403A7F1 RID: 239601
			public const int InstAttribute = 12;
		}
	}
}
