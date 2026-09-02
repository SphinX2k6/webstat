using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.View.Astrology
{
	// Token: 0x02006E50 RID: 28240
	[NullableContext(2)]
	[Nullable(0)]
	public class AstrologyPointView : UiPanelBase
	{
		// Token: 0x060448C5 RID: 280773 RVA: 0x011D27C0 File Offset: 0x011D09C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnInteractClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060448C6 RID: 280774 RVA: 0x011D2887 File Offset: 0x011D0A87
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x060448C7 RID: 280775 RVA: 0x011D28B1 File Offset: 0x011D0AB1
		protected override void OnBeforeHide()
		{
			this.InteractPoint();
		}

		// Token: 0x060448C8 RID: 280776 RVA: 0x011D28B9 File Offset: 0x011D0AB9
		protected override void OnBeforeDestroy()
		{
			this.OnPreInteractPoint = null;
			this.OnInteractPoint = null;
			this.PointTagId = 0;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x060448C9 RID: 280777 RVA: 0x011D28E8 File Offset: 0x011D0AE8
		[NullableContext(1)]
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.SetActive(false);
				return;
			}
			if (sequenceName == "Start2")
			{
				this.InteractPoint();
			}
		}

		// Token: 0x060448CA RID: 280778 RVA: 0x011D2912 File Offset: 0x011D0B12
		private void InteractPoint()
		{
			if (this.IsWaitInteract)
			{
				this.IsWaitInteract = false;
				Action<int> onInteractPoint = this.OnInteractPoint;
				if (onInteractPoint == null)
				{
					return;
				}
				onInteractPoint(this.PointTagId);
			}
		}

		// Token: 0x060448CB RID: 280779 RVA: 0x011D2939 File Offset: 0x011D0B39
		[NullableContext(1)]
		public void Init(Action onPreInteractPoint, Action<int> onInteractPoint, Func<bool> isInteractEnable)
		{
			this.OnPreInteractPoint = onPreInteractPoint;
			this.OnInteractPoint = onInteractPoint;
			this.IsInteractEnable = isInteractEnable;
		}

		// Token: 0x060448CC RID: 280780 RVA: 0x011D2950 File Offset: 0x011D0B50
		public void BindPoint(int tagId, bool isChecked)
		{
			this.PointTagId = tagId;
			base.GetItem(1).SetUIActive(!isChecked);
			base.GetItem(2).SetUIActive(isChecked);
		}

		// Token: 0x060448CD RID: 280781 RVA: 0x011D2978 File Offset: 0x011D0B78
		public void SetPointActive(bool isActive)
		{
			if (isActive == this.IsActive)
			{
				return;
			}
			this.IsActive = isActive;
			this.SequencePlayer.StopPrevSequence(false, true);
			if (isActive)
			{
				this.SetActive(true);
				this.SequencePlayer.PlaySequencePurely("Start", false, false);
				this.SequencePlayer.PlaySequencePurely("Loop", false, false);
				return;
			}
			this.SequencePlayer.PlaySequencePurely("Close", false, false);
		}

		// Token: 0x060448CE RID: 280782 RVA: 0x011D29E4 File Offset: 0x011D0BE4
		private void OnInteractClick()
		{
			if (this.IsInteractEnable == null || !this.IsInteractEnable())
			{
				return;
			}
			Action onPreInteractPoint = this.OnPreInteractPoint;
			if (onPreInteractPoint != null)
			{
				onPreInteractPoint();
			}
			this.IsWaitInteract = true;
			this.SequencePlayer.PlaySequencePurely("Start2", false, false);
		}

		// Token: 0x04026294 RID: 156308
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04026295 RID: 156309
		private Action OnPreInteractPoint;

		// Token: 0x04026296 RID: 156310
		private Action<int> OnInteractPoint;

		// Token: 0x04026297 RID: 156311
		private Func<bool> IsInteractEnable;

		// Token: 0x04026298 RID: 156312
		private int PointTagId;

		// Token: 0x04026299 RID: 156313
		private bool IsActive;

		// Token: 0x0402629A RID: 156314
		private bool IsWaitInteract;

		// Token: 0x0200CB45 RID: 52037
		[NullableContext(0)]
		private class EComponentType
		{
			// Token: 0x0403E638 RID: 255544
			public const int InteractButton = 0;

			// Token: 0x0403E639 RID: 255545
			public const int YellowItem = 1;

			// Token: 0x0403E63A RID: 255546
			public const int WhiteItem = 2;
		}
	}
}
