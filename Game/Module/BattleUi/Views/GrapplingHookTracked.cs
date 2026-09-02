using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006017 RID: 24599
	public class GrapplingHookTracked : UiPanelBase
	{
		// Token: 0x0603DFCD RID: 253901 RVA: 0x00FD15BA File Offset: 0x00FCF7BA
		[NullableContext(1)]
		public GrapplingHookTracked(UUIItem parentItem)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_GsTracked", parentItem, true).ContinueWith(delegate()
			{
				this.IsTrackedActivated = true;
			}).Forget();
		}

		// Token: 0x0603DFCE RID: 253902 RVA: 0x00FD15E8 File Offset: 0x00FCF7E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedTrackedButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603DFCF RID: 253903 RVA: 0x00FD1690 File Offset: 0x00FCF890
		[NullableContext(1)]
		public void Refresh(in FVector2D screenPosition, Vector targetLocation)
		{
			if (!this.IsTrackedActivated)
			{
				return;
			}
			UUIItem item = base.GetItem(0);
			FRotator frotator = new FRotator();
			frotator.Yaw = (float)(Math.Atan2((double)screenPosition.Y, (double)screenPosition.X) * 57.2957763671875 - 90.0);
			item.SetUIRelativeRotation(frotator);
			this.RootItem.SetAnchorOffset(screenPosition);
			this.TargetLocation = targetLocation;
		}

		// Token: 0x0603DFD0 RID: 253904 RVA: 0x00FD1702 File Offset: 0x00FCF902
		private void OnClickedTrackedButton()
		{
			if (this.TargetLocation == null)
			{
				return;
			}
			ControllerBase<BattleUiControl>.Instance.FocusToTargetLocation(this.TargetLocation);
		}

		// Token: 0x0603DFD1 RID: 253905 RVA: 0x00FD171D File Offset: 0x00FCF91D
		public bool GetIsTrackedActivated()
		{
			return this.IsTrackedActivated;
		}

		// Token: 0x0603DFD2 RID: 253906 RVA: 0x00FD1725 File Offset: 0x00FCF925
		protected override void OnBeforeDestroy()
		{
			this.IsTrackedActivated = false;
			this.TargetLocation = null;
		}

		// Token: 0x04022C34 RID: 142388
		private bool IsTrackedActivated;

		// Token: 0x04022C35 RID: 142389
		[Nullable(2)]
		private Vector TargetLocation;

		// Token: 0x0200C0BF RID: 49343
		private enum EChildType
		{
			// Token: 0x0403B579 RID: 243065
			DirectionItem,
			// Token: 0x0403B57A RID: 243066
			TrackedButton
		}
	}
}
