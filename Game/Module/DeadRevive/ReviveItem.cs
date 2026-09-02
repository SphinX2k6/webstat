using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DC9 RID: 24009
	[NullableContext(1)]
	[Nullable(0)]
	public class ReviveItem : UiPanelBase
	{
		// Token: 0x0603C711 RID: 247569 RVA: 0x00F5902C File Offset: 0x00F5722C
		public ReviveItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C712 RID: 247570 RVA: 0x00F59090 File Offset: 0x00F57290
		public void ShowReviveItem(int itemId, int itemCount)
		{
			this.ItemId = new int?(itemId);
			base.SetItemIcon(base.GetTexture(1), this.ItemId.Value, null, null);
			base.GetText(4).SetText("x" + itemCount.ToString(), true);
			base.SetItemQualityIcon(base.GetSprite(2), this.ItemId.Value, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
			this.CountDownInit();
		}

		// Token: 0x0603C713 RID: 247571 RVA: 0x00F59114 File Offset: 0x00F57314
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.ToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C714 RID: 247572 RVA: 0x00F59264 File Offset: 0x00F57464
		protected override void OnStart()
		{
			this.Toggle = base.GetExtendToggle(9);
		}

		// Token: 0x0603C715 RID: 247573 RVA: 0x00F59274 File Offset: 0x00F57474
		protected override void OnBeforeDestroy()
		{
			this.ItemId = null;
			this.Toggle = null;
			if (this.Timer != null)
			{
				this.Timer.Remove();
			}
			this.Timer = null;
			this.RemainCdTime = -1.0;
			this.TotalCdTime = 1.0;
		}

		// Token: 0x0603C716 RID: 247574 RVA: 0x00F592CD File Offset: 0x00F574CD
		protected void ToggleClick(EToggleState state)
		{
			if (this.ClickCallback == null)
			{
				return;
			}
			if (state == EToggleState.ETT_Checked)
			{
				this.ClickCallback(this.ItemId.Value);
			}
		}

		// Token: 0x0603C717 RID: 247575 RVA: 0x00F592F4 File Offset: 0x00F574F4
		private void CountDownInit()
		{
			double buffItemRemainCdTime = ModelBase<BuffItemModel>.Instance.GetBuffItemRemainCdTime(this.ItemId.Value);
			if (buffItemRemainCdTime <= 0.0)
			{
				return;
			}
			this.RemainCdTime = buffItemRemainCdTime;
			this.TotalCdTime = ModelBase<BuffItemModel>.Instance.GetBuffItemTotalCdTime(this.ItemId.Value);
			base.GetItem(14).SetUIActive(true);
			base.GetText(15).SetText(Singleton<TimeUtil>.Instance.GetCoolDown(this.RemainCdTime), true);
			base.GetSprite(16).SetFillAmount((float)(this.RemainCdTime / this.TotalCdTime));
			if (this.Timer != null)
			{
				this.Timer.Remove();
			}
			this.Timer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.TimerHandle), 20f, 1f, null, null, true);
		}

		// Token: 0x0603C718 RID: 247576 RVA: 0x00F593CC File Offset: 0x00F575CC
		public void SetToggleState(bool bSelected, bool bFire = true)
		{
			EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			this.Toggle.SetToggleState(state, bFire, false, false);
		}

		// Token: 0x0603C719 RID: 247577 RVA: 0x00F593F1 File Offset: 0x00F575F1
		public void BindClickCallback(TItemClickCallback bindClickCallback)
		{
			this.ClickCallback = bindClickCallback;
		}

		// Token: 0x0603C71A RID: 247578 RVA: 0x00F593FC File Offset: 0x00F575FC
		private void TimerHandle(float delta)
		{
			if (this.RemainCdTime <= 0.0)
			{
				if (this.Timer != null)
				{
					this.Timer.Remove();
				}
				this.Timer = null;
				if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.UseReviveItemView))
				{
					base.GetItem(14).SetUIActive(false);
				}
				return;
			}
			base.GetText(15).SetText(Singleton<TimeUtil>.Instance.GetCoolDown(this.RemainCdTime), true);
			base.GetSprite(16).SetFillAmount((float)(this.RemainCdTime / this.TotalCdTime));
			this.RemainCdTime -= 0.02;
		}

		// Token: 0x04021FB3 RID: 139187
		private int? ItemId;

		// Token: 0x04021FB4 RID: 139188
		private TItemClickCallback ClickCallback = delegate(int itemConfigId)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemConfigId, true, null);
		};

		// Token: 0x04021FB5 RID: 139189
		[Nullable(2)]
		private UUIExtendToggle Toggle;

		// Token: 0x04021FB6 RID: 139190
		[Nullable(2)]
		private TimerHandle Timer;

		// Token: 0x04021FB7 RID: 139191
		private double RemainCdTime = -1.0;

		// Token: 0x04021FB8 RID: 139192
		private double TotalCdTime = 1.0;

		// Token: 0x0200BE17 RID: 48663
		[NullableContext(0)]
		private class EReviveItemDefine
		{
			// Token: 0x0403A865 RID: 239717
			public const int IconTexture = 1;

			// Token: 0x0403A866 RID: 239718
			public const int IconSprite = 2;

			// Token: 0x0403A867 RID: 239719
			public const int TextCount = 4;

			// Token: 0x0403A868 RID: 239720
			public const int Toggle = 9;

			// Token: 0x0403A869 RID: 239721
			public const int ItemCountDown = 14;

			// Token: 0x0403A86A RID: 239722
			public const int TextCountDown = 15;

			// Token: 0x0403A86B RID: 239723
			public const int SpriteCountDown = 16;
		}
	}
}
