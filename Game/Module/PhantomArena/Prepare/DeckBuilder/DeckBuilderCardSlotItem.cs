using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054FA RID: 21754
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DeckBuilderCardSlotItem : GridProxyAbstract<IDeckBuilderCardSlotItemData>
	{
		// Token: 0x060376D8 RID: 227032 RVA: 0x00E0F9B0 File Offset: 0x00E0DBB0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUISprite))
			};
		}

		// Token: 0x060376D9 RID: 227033 RVA: 0x00E0FAA8 File Offset: 0x00E0DCA8
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderCardSlotItem.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderCardSlotItem.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060376DA RID: 227034 RVA: 0x00E0FAEC File Offset: 0x00E0DCEC
		[NullableContext(1)]
		public override void Refresh(IDeckBuilderCardSlotItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			DeckCardSlotInfo slotInfo = data.SlotInfo;
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(slotInfo.CardId);
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			this.RefreshLockState();
			this.RefreshRedDot();
			base.GetText(3).SetText(phantomBattleCardConfig.Cost.ToString(), true);
			UUIText text = base.GetText(4);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("×");
			defaultInterpolatedStringHandler.AppendFormatted<int>(slotInfo.Count);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phantomBattleCardConfig.Name, Array.Empty<object>());
			base.SetTextureByPath(phantomBattleCardConfig.DeckFaceTexture, base.GetTexture(1), null, null);
			this.RefreshElement(slotInfo.Element);
			this.RefreshOutlookState();
			if (data.NeedPlayAddAnim)
			{
				data.NeedPlayAddAnim = false;
				this.SequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
			}
		}

		// Token: 0x060376DB RID: 227035 RVA: 0x00E0FC05 File Offset: 0x00E0DE05
		public void RefreshLockState()
		{
			base.GetItem(6).SetUIActive(this.Data.Locked);
		}

		// Token: 0x060376DC RID: 227036 RVA: 0x00E0FC20 File Offset: 0x00E0DE20
		public void RefreshOutlookState()
		{
			string path = this.Data.OutlookUnlocked ? "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity24/SoundRemnantArena/Outside/SP_IconOutsideTeamListGold.SP_IconOutsideTeamListGold" : "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity24/SoundRemnantArena/Outside/SP_IconOutsideTeamListNor.SP_IconOutsideTeamListNor";
			this.SetSpriteByPath(path, base.GetSprite(9), false, null, null);
		}

		// Token: 0x060376DD RID: 227037 RVA: 0x00E0FC61 File Offset: 0x00E0DE61
		public void RefreshRedDot()
		{
			base.GetItem(7).SetUIActive(this.Data.RedDotState);
		}

		// Token: 0x060376DE RID: 227038 RVA: 0x00E0FC7A File Offset: 0x00E0DE7A
		private void RefreshElement(int elementId)
		{
			this.ElementItem.Refresh((ECardElement)elementId, false, 0);
		}

		// Token: 0x060376DF RID: 227039 RVA: 0x00E0FC8A File Offset: 0x00E0DE8A
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x060376E0 RID: 227040 RVA: 0x00E0FC9D File Offset: 0x00E0DE9D
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060376E1 RID: 227041 RVA: 0x00E0FCB0 File Offset: 0x00E0DEB0
		private bool CanToggleExecuteChangeInternal()
		{
			return this.CanToggleChange == null || this.CanToggleChange(this);
		}

		// Token: 0x060376E2 RID: 227042 RVA: 0x00E0FCC8 File Offset: 0x00E0DEC8
		private void OnItemTogglePointDownCallBack(EToggleState _)
		{
			if (this.TickHandleId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickHandleId);
				this.TickHandleId = -1;
			}
			this.HoldTime = 0f;
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.PressTick), "DeckBuilderCardSlotItem", ETickingGroup.TG_PrePhysics, true, 0, true);
			this.TickHandleId = ((ticker != null) ? ticker.Id : -1);
		}

		// Token: 0x060376E3 RID: 227043 RVA: 0x00E0FD34 File Offset: 0x00E0DF34
		private void OnItemTogglePointUpCallBackWithEventData(EToggleState state, ULGUIPointerEventData eventData)
		{
			USceneComponent usceneComponent = (eventData != null) ? eventData.dragComponent : null;
			if (usceneComponent != null && usceneComponent.IsValid())
			{
				return;
			}
			if (this.TickHandleId != -1)
			{
				Action longPressEndCallback = this.LongPressEndCallback;
				if (longPressEndCallback != null)
				{
					longPressEndCallback();
				}
				Singleton<TickSystem>.Instance.Remove(this.TickHandleId);
				this.TickHandleId = -1;
			}
			this.TickHandleId = -1;
			if (this.HoldTime < this.LongPressStartTime)
			{
				Action<DeckBuilderCardSlotItem> shortClickCallback = this.ShortClickCallback;
				if (shortClickCallback != null)
				{
					shortClickCallback(this);
				}
			}
			this.HoldTime = 0f;
		}

		// Token: 0x060376E4 RID: 227044 RVA: 0x00E0FDBE File Offset: 0x00E0DFBE
		private void OnToggleStateChangeInternal(EToggleState state)
		{
			Action<DeckBuilderCardSlotItem, EToggleState> onToggleStateChange = this.OnToggleStateChange;
			if (onToggleStateChange == null)
			{
				return;
			}
			onToggleStateChange(this, state);
		}

		// Token: 0x060376E5 RID: 227045 RVA: 0x00E0FDD4 File Offset: 0x00E0DFD4
		private void PressTick(float deltaTime)
		{
			this.HoldTime += deltaTime;
			if (this.HoldTime >= this.LongPressStartTime)
			{
				float arg = (this.HoldTime - this.LongPressStartTime) / (this.LongPressEndTime - this.LongPressStartTime);
				Action<DeckBuilderCardSlotItem, float> longPressCallback = this.LongPressCallback;
				if (longPressCallback != null)
				{
					longPressCallback(this, arg);
				}
			}
			if (this.HoldTime > this.LongPressEndTime)
			{
				Action longPressEndCallback = this.LongPressEndCallback;
				if (longPressEndCallback != null)
				{
					longPressEndCallback();
				}
				if (this.TickHandleId != -1)
				{
					Singleton<TickSystem>.Instance.Remove(this.TickHandleId);
					this.TickHandleId = -1;
				}
			}
		}

		// Token: 0x060376E6 RID: 227046 RVA: 0x00E0FE6C File Offset: 0x00E0E06C
		private bool OnItemTogglePointerBeginDragCallBack(ULGUIPointerEventData _)
		{
			Action longPressEndCallback = this.LongPressEndCallback;
			if (longPressEndCallback != null)
			{
				longPressEndCallback();
			}
			if (this.TickHandleId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickHandleId);
				this.TickHandleId = -1;
			}
			return true;
		}

		// Token: 0x060376E7 RID: 227047 RVA: 0x00E0FEA1 File Offset: 0x00E0E0A1
		private void OnPointEnter(EToggleState _)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			Action<int> onPointEnterCallback = this.OnPointEnterCallback;
			if (onPointEnterCallback == null)
			{
				return;
			}
			onPointEnterCallback(this.Data.SlotInfo.CardId);
		}

		// Token: 0x060376E8 RID: 227048 RVA: 0x00E0FED0 File Offset: 0x00E0E0D0
		private void OnPointExit(EToggleState _)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			Action onPointExitCallback = this.OnPointExitCallback;
			if (onPointExitCallback == null)
			{
				return;
			}
			onPointExitCallback();
		}

		// Token: 0x060376E9 RID: 227049 RVA: 0x00E0FEEF File Offset: 0x00E0E0EF
		public DeckCardSlotInfo GetData()
		{
			IDeckBuilderCardSlotItemData data = this.Data;
			if (data == null)
			{
				return null;
			}
			return data.SlotInfo;
		}

		// Token: 0x060376EA RID: 227050 RVA: 0x00E0FF02 File Offset: 0x00E0E102
		public void TriggerLongPress()
		{
			Action<DeckBuilderCardSlotItem, float> longPressCallback = this.LongPressCallback;
			if (longPressCallback == null)
			{
				return;
			}
			longPressCallback(this, -1f);
		}

		// Token: 0x0401FD15 RID: 130325
		protected IDeckBuilderCardSlotItemData Data;

		// Token: 0x0401FD16 RID: 130326
		private CardElementItem ElementItem;

		// Token: 0x0401FD17 RID: 130327
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0401FD18 RID: 130328
		private float HoldTime;

		// Token: 0x0401FD19 RID: 130329
		private int TickHandleId = -1;

		// Token: 0x0401FD1A RID: 130330
		public float LongPressStartTime;

		// Token: 0x0401FD1B RID: 130331
		public float LongPressEndTime;

		// Token: 0x0401FD1C RID: 130332
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<DeckBuilderCardSlotItem, bool> CanToggleChange;

		// Token: 0x0401FD1D RID: 130333
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem, float> LongPressCallback;

		// Token: 0x0401FD1E RID: 130334
		public Action LongPressEndCallback;

		// Token: 0x0401FD1F RID: 130335
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem> ShortClickCallback;

		// Token: 0x0401FD20 RID: 130336
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem, EToggleState> OnToggleStateChange;

		// Token: 0x0401FD21 RID: 130337
		public Action<int> OnPointEnterCallback;

		// Token: 0x0401FD22 RID: 130338
		public Action OnPointExitCallback;

		// Token: 0x0200B472 RID: 46194
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037DB7 RID: 228791
			public const int ItemToggle = 0;

			// Token: 0x04037DB8 RID: 228792
			public const int CardSlotTexture = 1;

			// Token: 0x04037DB9 RID: 228793
			public const int NameText = 2;

			// Token: 0x04037DBA RID: 228794
			public const int CostText = 3;

			// Token: 0x04037DBB RID: 228795
			public const int CountText = 4;

			// Token: 0x04037DBC RID: 228796
			public const int ElementItem = 5;

			// Token: 0x04037DBD RID: 228797
			public const int LockItem = 6;

			// Token: 0x04037DBE RID: 228798
			public const int RedDotItem = 7;

			// Token: 0x04037DBF RID: 228799
			public const int LineItem = 8;

			// Token: 0x04037DC0 RID: 228800
			public const int BgSprite = 9;
		}
	}
}
