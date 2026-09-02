using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl.SiganalDeviceUIItem
{
	// Token: 0x02006AFF RID: 27391
	[NullableContext(1)]
	[Nullable(0)]
	public class LinkingEmptyToggle : UiPanelBase
	{
		// Token: 0x06043B44 RID: 277316 RVA: 0x01176C0F File Offset: 0x01174E0F
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle))
			};
		}

		// Token: 0x06043B45 RID: 277317 RVA: 0x01176C32 File Offset: 0x01174E32
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<bool, IReadOnlyList<int>>(EEventName.OnSignalDeviceLinkingCheck, new Action<bool, IReadOnlyList<int>>(this.OnSignalDeviceLinkingCheck));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSignalDeviceReset, new Action(this.OnSignalDeviceReset));
		}

		// Token: 0x06043B46 RID: 277318 RVA: 0x01176C6C File Offset: 0x01174E6C
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceLinkingCheck, new Action<bool, IReadOnlyList<int>>(this.OnSignalDeviceLinkingCheck));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceReset, new Action(this.OnSignalDeviceReset));
		}

		// Token: 0x06043B47 RID: 277319 RVA: 0x01176CA6 File Offset: 0x01174EA6
		public void InitData(int index)
		{
			this.Index = index;
			base.GetExtendToggle(0).OnHover.Add(new Action(this.OnToggleHover));
		}

		// Token: 0x06043B48 RID: 277320 RVA: 0x01176CCC File Offset: 0x01174ECC
		public void SetDotData(UUIItem item, EPieceColorType color)
		{
			this.LinkingDotItem = new LinkingDotItem();
			this.LinkingDotItem.CreateThenShowByActor(item.GetOwner(), null);
			this.LinkingDotItem.InitIcon(color);
			this.Color = color;
			this.LongPress = new LongPressButtonItem(null, new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), null);
			this.LongPress.Initialize(base.GetExtendToggle(0), null, new Action(this.OnTogglePress), new Action(this.OnToggleRelease), new Action(this.OnToggleCancel));
		}

		// Token: 0x06043B49 RID: 277321 RVA: 0x01176D60 File Offset: 0x01174F60
		public void SetLineData(UUIItem item, LinkingLineItem itemClass, ENeighborType neighborType, int from, bool isFromDot)
		{
			this.LinkingLineItem = itemClass;
			this.LinkingLineItem.CreateThenShowByActor(item.GetOwner(), null);
			this.LinkingLineItem.InitIcon(neighborType, true);
			this.FromIndex = from;
			this.IsFromDot = isFromDot;
		}

		// Token: 0x06043B4A RID: 277322 RVA: 0x01176D98 File Offset: 0x01174F98
		public void ResetStraightLineData(UUIItem item, LinkingLineItem itemClass, int to)
		{
			this.LinkingLineItem.Destroy(null);
			this.LinkingLineItem = itemClass;
			this.LinkingLineItem.CreateThenShowByActor(item.GetOwner(), null);
			if (itemClass.LineType == ELineType.LinkingLineStraight)
			{
				this.LinkingLineItem.InitIcon((Math.Abs(this.FromIndex - to) == 2) ? ENeighborType.ToLeft : ENeighborType.ToDown, false);
				return;
			}
			if (itemClass.LineType == ELineType.LinkingLineWithDotStraight)
			{
				if (this.FromIndex - to == -SignalDeviceModel.ROWNUM * 2)
				{
					this.LinkingLineItem.InitIcon(this.IsFromDot ? ENeighborType.ToDown : ENeighborType.ToUp, false);
					return;
				}
				if (this.FromIndex - to == SignalDeviceModel.ROWNUM * 2)
				{
					this.LinkingLineItem.InitIcon(this.IsFromDot ? ENeighborType.ToUp : ENeighborType.ToDown, false);
					return;
				}
				if (this.FromIndex - to == 2)
				{
					this.LinkingLineItem.InitIcon(this.IsFromDot ? ENeighborType.ToLeft : ENeighborType.ToRight, false);
					return;
				}
				this.LinkingLineItem.InitIcon(this.IsFromDot ? ENeighborType.ToRight : ENeighborType.ToLeft, false);
			}
		}

		// Token: 0x06043B4B RID: 277323 RVA: 0x01176E91 File Offset: 0x01175091
		public void ClearLineData()
		{
			this.LinkingLineItem.Destroy(null);
			this.LinkingLineItem = null;
		}

		// Token: 0x06043B4C RID: 277324 RVA: 0x01176EA8 File Offset: 0x011750A8
		public void SetLineHalf()
		{
			ENeighborType lineHalf = ModelBase<SignalDeviceModel>.Instance.NeighboringType(this.FromIndex, this.Index);
			this.LinkingLineItem.SetLineHalf(lineHalf);
		}

		// Token: 0x06043B4D RID: 277325 RVA: 0x01176ED8 File Offset: 0x011750D8
		public void ResetCornerLineData(UUIItem item, LinkingLineItem itemClass, int from, int to, bool isToDot)
		{
			this.LinkingLineItem.Destroy(null);
			this.LinkingLineItem = itemClass;
			this.LinkingLineItem.CreateThenShowByActor(item.GetOwner(), null);
			int num = from - this.FromIndex;
			int num2 = to - from;
			if (itemClass.LineType == ELineType.LinkingLineCorner)
			{
				if (num * num2 == -SignalDeviceModel.ROWNUM)
				{
					this.LinkingLineItem.InitIcon((num < num2) ? ENeighborType.ToLeft : ENeighborType.ToRight, false);
					return;
				}
				this.LinkingLineItem.InitIcon((num < num2) ? ENeighborType.ToUp : ENeighborType.ToDown, false);
				return;
			}
			else if (itemClass.LineType == ELineType.LinkingLineWithDotCornerLeft)
			{
				if (num * num2 == -SignalDeviceModel.ROWNUM)
				{
					this.LinkingLineItem.InitIcon((num < num2) ? ENeighborType.ToLeft : ENeighborType.ToRight, false);
					return;
				}
				this.LinkingLineItem.InitIcon((num < num2) ? ENeighborType.ToUp : ENeighborType.ToDown, false);
				return;
			}
			else
			{
				if (num * num2 == SignalDeviceModel.ROWNUM)
				{
					this.LinkingLineItem.InitIcon((num < num2) ? ENeighborType.ToLeft : ENeighborType.ToRight, false);
					return;
				}
				this.LinkingLineItem.InitIcon((num < num2) ? ENeighborType.ToDown : ENeighborType.ToUp, false);
				return;
			}
		}

		// Token: 0x06043B4E RID: 277326 RVA: 0x01176FC8 File Offset: 0x011751C8
		private void OnToggleHover()
		{
			if (ModelBase<SignalDeviceModel>.Instance.CurrentColor > EPieceColorType.White)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_amb_interact_signal_ui_drag");
			}
			else
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_amb_interact_signal_ui_move");
			}
			ControllerBase<SignalDeviceController>.Instance.OnHovering(this.Index);
		}

		// Token: 0x06043B4F RID: 277327 RVA: 0x01177018 File Offset: 0x01175218
		private void OnTogglePress()
		{
			this.LinkingDotItem.OnPressed(true);
			ControllerBase<SignalDeviceController>.Instance.OnDotPressed(this.Index, this.Color);
			if (ModelBase<SignalDeviceModel>.Instance.CurrentColor > EPieceColorType.White)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_amb_interact_signal_ui_choose");
			}
		}

		// Token: 0x06043B50 RID: 277328 RVA: 0x01177067 File Offset: 0x01175267
		private void OnToggleRelease()
		{
			ControllerBase<SignalDeviceController>.Instance.CheckLinking(this.Index);
		}

		// Token: 0x06043B51 RID: 277329 RVA: 0x01177079 File Offset: 0x01175279
		private void OnToggleCancel()
		{
			ControllerBase<SignalDeviceController>.Instance.CheckLinking(this.Index);
		}

		// Token: 0x06043B52 RID: 277330 RVA: 0x0117708C File Offset: 0x0117528C
		private void OnSignalDeviceLinkingCheck(bool isSuccess, IReadOnlyList<int> indexArray)
		{
			if (isSuccess && indexArray.Contains(this.Index))
			{
				LinkingDotItem linkingDotItem = this.LinkingDotItem;
				if (linkingDotItem != null)
				{
					linkingDotItem.OnLinked();
				}
				LinkingDotItem linkingDotItem2 = this.LinkingDotItem;
				if (linkingDotItem2 != null)
				{
					linkingDotItem2.SetFxBoost(true);
				}
				base.GetExtendToggle(0).SetEnable(false);
			}
			if (!isSuccess && indexArray.Contains(this.Index))
			{
				LinkingDotItem linkingDotItem3 = this.LinkingDotItem;
				if (linkingDotItem3 != null)
				{
					linkingDotItem3.OnPressed(false);
				}
				LinkingDotItem linkingDotItem4 = this.LinkingDotItem;
				if (linkingDotItem4 != null)
				{
					linkingDotItem4.RotateLine(false, ENeighborType.None);
				}
				LinkingLineItem linkingLineItem = this.LinkingLineItem;
				if (linkingLineItem == null)
				{
					return;
				}
				linkingLineItem.Destroy(null);
			}
		}

		// Token: 0x06043B53 RID: 277331 RVA: 0x01177124 File Offset: 0x01175324
		private void OnSignalDeviceReset()
		{
			base.GetExtendToggle(0).SetEnable(true);
			LinkingDotItem linkingDotItem = this.LinkingDotItem;
			if (linkingDotItem != null)
			{
				linkingDotItem.ResetIcon();
			}
			LinkingDotItem linkingDotItem2 = this.LinkingDotItem;
			if (linkingDotItem2 != null)
			{
				linkingDotItem2.RotateLine(false, ENeighborType.None);
			}
			LinkingLineItem linkingLineItem = this.LinkingLineItem;
			if (linkingLineItem == null)
			{
				return;
			}
			linkingLineItem.Destroy(null);
		}

		// Token: 0x06043B54 RID: 277332 RVA: 0x01177174 File Offset: 0x01175374
		public void SetDotRay(bool isActive, ENeighborType neighborType = ENeighborType.None)
		{
			LinkingDotItem linkingDotItem = this.LinkingDotItem;
			if (linkingDotItem == null)
			{
				return;
			}
			linkingDotItem.RotateLine(isActive, neighborType);
		}

		// Token: 0x04025D55 RID: 154965
		private int Index = -1;

		// Token: 0x04025D56 RID: 154966
		public int FromIndex = -1;

		// Token: 0x04025D57 RID: 154967
		public bool IsFromDot;

		// Token: 0x04025D58 RID: 154968
		private EPieceColorType Color;

		// Token: 0x04025D59 RID: 154969
		[Nullable(2)]
		private LongPressButtonItem LongPress;

		// Token: 0x04025D5A RID: 154970
		[Nullable(2)]
		private LinkingDotItem LinkingDotItem;

		// Token: 0x04025D5B RID: 154971
		[Nullable(2)]
		private LinkingLineItem LinkingLineItem;

		// Token: 0x0200CA04 RID: 51716
		[NullableContext(0)]
		public enum EComponents
		{
			// Token: 0x0403E120 RID: 254240
			UiItem_LinkEmpty
		}
	}
}
