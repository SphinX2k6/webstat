using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005190 RID: 20880
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeRandomEventView : UiViewBase
	{
		// Token: 0x06035B68 RID: 220008 RVA: 0x00D7F1EE File Offset: 0x00D7D3EE
		public RoguelikeRandomEventView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035B69 RID: 220009 RVA: 0x00D7F210 File Offset: 0x00D7D410
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnConfirm));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035B6A RID: 220010 RVA: 0x00D7F2F8 File Offset: 0x00D7D4F8
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<RogueGainEntry, RogueGainEntry, bool, int, RoguelikeChooseDataResultResponse>(EEventName.RoguelikeChooseDataResult, new Action<RogueGainEntry, RogueGainEntry, bool, int, RoguelikeChooseDataResultResponse>(this.RoguelikeChooseDataResult));
		}

		// Token: 0x06035B6B RID: 220011 RVA: 0x00D7F316 File Offset: 0x00D7D516
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeChooseDataResult, new Action<RogueGainEntry, RogueGainEntry, bool, int, RoguelikeChooseDataResultResponse>(this.RoguelikeChooseDataResult));
		}

		// Token: 0x06035B6C RID: 220012 RVA: 0x00D7F334 File Offset: 0x00D7D534
		protected void OnBtnConfirm()
		{
			ControllerBase<RoguelikeController>.Instance.RogueChooseDataResultRequest(EPerkType.Event);
		}

		// Token: 0x06035B6D RID: 220013 RVA: 0x00D7F341 File Offset: 0x00D7D541
		protected override void OnStart()
		{
			this.GenericLayout = new GenericLayout<RoguelikeRandomEventItem, RogueGainEntry>(base.GetVerticalLayout(0), new Func<RoguelikeRandomEventItem>(this.CreateElement), null, false, true);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06035B6E RID: 220014 RVA: 0x00D7F375 File Offset: 0x00D7D575
		private RoguelikeRandomEventItem CreateElement()
		{
			return new RoguelikeRandomEventItem
			{
				OnSelectHandle = new Action<RoguelikeRandomEventItem, EToggleState>(this.OnSelectHandle)
			};
		}

		// Token: 0x06035B6F RID: 220015 RVA: 0x00D7F390 File Offset: 0x00D7D590
		protected void RoguelikeChooseDataResult(RogueGainEntry newRogueGainEntry, RogueGainEntry oldRogueGainEntry, bool isSuccess, int bindId, RoguelikeChooseDataResultResponse response)
		{
			RoguelikeChooseData data = ModelBase<RoguelikeModel>.Instance.GetRoguelikeChooseDataById(-2);
			RoguelikeChooseData data2 = data;
			int? num = (data2 != null) ? new int?(data2.Index) : null;
			if (!(bindId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			Action <>9__1;
			Action <>9__2;
			Action<bool?> action = ControllerBase<RoguelikeController>.Instance.CreateCloseViewCallBack(response, delegate(bool? _)
			{
				RogueSelectResult rogueSelectResult = new RogueSelectResult(ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry, oldRogueGainEntry, null, false);
				RogueSelectResult rogueSelectResult2 = rogueSelectResult;
				Action callBack;
				if ((callBack = <>9__1) == null)
				{
					callBack = (<>9__1 = delegate()
					{
						this.UpdateEventList(data, false);
					});
				}
				rogueSelectResult2.CallBack = callBack;
				if (rogueSelectResult.GetNewUnlockAffixEntry().Count > 0)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonSelectResultView, rogueSelectResult, null);
					return;
				}
				RoguelikeRandomEventView <>4__this = this;
				Action callback;
				if ((callback = <>9__2) == null)
				{
					callback = (<>9__2 = delegate()
					{
						this.UpdateEventList(data, false);
					});
				}
				if (<>4__this.CheckEventRoleBuff(callback))
				{
					return;
				}
				if (!this.IsEnd)
				{
					this.UpdateEventList(data, false);
				}
			});
			if (action == null)
			{
				return;
			}
			action(null);
		}

		// Token: 0x06035B70 RID: 220016 RVA: 0x00D7F424 File Offset: 0x00D7D624
		protected void OnSelectHandle(RoguelikeRandomEventItem item, EToggleState state)
		{
			if (this.LastSelectItem != null && this.LastSelectItem != item && state == EToggleState.ETT_Checked)
			{
				this.LastSelectItem.SetToggleState(false);
			}
			this.LastSelectItem = item;
			bool isSelect = false;
			GenericLayout<RoguelikeRandomEventItem, RogueGainEntry> genericLayout = this.GenericLayout;
			if (genericLayout != null)
			{
				genericLayout.GetLayoutItemList().ForEach(delegate(RoguelikeRandomEventItem eventItem)
				{
					if (eventItem.GetToggleState() == EToggleState.ETT_Checked)
					{
						isSelect = true;
					}
				});
			}
			base.GetButton(2).SetSelfInteractive(isSelect);
		}

		// Token: 0x06035B71 RID: 220017 RVA: 0x00D7F49C File Offset: 0x00D7D69C
		protected override void OnBeforeShow()
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(false);
			base.GetButton(2).SetSelfInteractive(false);
			RoguelikeChooseData data = ModelBase<RoguelikeModel>.Instance.GetRoguelikeChooseDataById(-2);
			if (this.CheckEventRoleBuff(delegate
			{
				this.UpdateEventList(data, true);
			}))
			{
				return;
			}
			this.UpdateEventList(data, true);
		}

		// Token: 0x06035B72 RID: 220018 RVA: 0x00D7F514 File Offset: 0x00D7D714
		protected override void OnBeforeDestroy()
		{
			this.EventItemList.ForEach(delegate(RoguelikeRandomEventItem item)
			{
				item.Destroy(null);
			});
			if (this.DelayShowTimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayShowTimerId);
			}
			this.EventItemList.Clear();
			this.EventActorList.Clear();
			Action<int> selectCallback = ((IRoguelikeRandomEventOpenParam)this.OpenParam).SelectCallback;
			if (selectCallback == null)
			{
				return;
			}
			selectCallback((this.LastSelectItem != null) ? this.LastSelectItem.Data.ConfigId : 0);
		}

		// Token: 0x06035B73 RID: 220019 RVA: 0x00D7F5B0 File Offset: 0x00D7D7B0
		public void UpdateEventList(RoguelikeChooseData data, bool isPlayPlot = true)
		{
			RoguelikeRandomEventView.<>c__DisplayClass19_0 CS$<>8__locals1 = new RoguelikeRandomEventView.<>c__DisplayClass19_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			bool flag = CS$<>8__locals1.data.RogueGainEntryList.Count == 0;
			this.SetPanelActive(false);
			if (flag)
			{
				base.CloseMe(null);
				return;
			}
			CS$<>8__locals1.<UpdateEventList>g__EventFunc|0().AsTask();
		}

		// Token: 0x06035B74 RID: 220020 RVA: 0x00D7F604 File Offset: 0x00D7D804
		private void SetPanelActive(bool isActive)
		{
			base.GetItem(3).SetUIActive(isActive);
			base.GetButton(2).RootUIComp.Get().SetUIActive(isActive);
		}

		// Token: 0x06035B75 RID: 220021 RVA: 0x00D7F638 File Offset: 0x00D7D838
		[NullableContext(2)]
		private bool CheckEventRoleBuff(Action callback = null)
		{
			RoguelikeChooseData roguelikeChooseDataById = ModelBase<RoguelikeModel>.Instance.GetRoguelikeChooseDataById(-3);
			if (roguelikeChooseDataById != null && !roguelikeChooseDataById.IsSelect.GetValueOrDefault())
			{
				int? layer = roguelikeChooseDataById.Layer;
				int curRoomCount = ModelBase<RoguelikeModel>.Instance.CurRoomCount;
				if (layer.GetValueOrDefault() == curRoomCount & layer != null)
				{
					roguelikeChooseDataById.CallBack = callback;
					Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleBuffSelectView, roguelikeChooseDataById, null);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0401ED2E RID: 126254
		public List<RoguelikeRandomEventItem> EventItemList = new List<RoguelikeRandomEventItem>();

		// Token: 0x0401ED2F RID: 126255
		public List<UUIItem> EventActorList = new List<UUIItem>();

		// Token: 0x0401ED30 RID: 126256
		public TimerHandle DelayShowTimerId;

		// Token: 0x0401ED31 RID: 126257
		public RoguelikeRandomEventItem LastSelectItem;

		// Token: 0x0401ED32 RID: 126258
		public GenericLayout<RoguelikeRandomEventItem, RogueGainEntry> GenericLayout;

		// Token: 0x0401ED33 RID: 126259
		public LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401ED34 RID: 126260
		private readonly bool IsEnd;

		// Token: 0x0200B150 RID: 45392
		[NullableContext(0)]
		private class ERoguelikeRandomEventViewDefine
		{
			// Token: 0x04036FD3 RID: 225235
			public const int EventContainer = 0;

			// Token: 0x04036FD4 RID: 225236
			public const int EventItem = 1;

			// Token: 0x04036FD5 RID: 225237
			public const int BtnConfirm = 2;

			// Token: 0x04036FD6 RID: 225238
			public const int BgPanel = 3;
		}
	}
}
