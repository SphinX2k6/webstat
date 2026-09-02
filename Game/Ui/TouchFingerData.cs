using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A38 RID: 19000
	public class TouchFingerData
	{
		// Token: 0x06031A5F RID: 203359 RVA: 0x00C5E7FE File Offset: 0x00C5C9FE
		public TouchFingerData(EFingerIndex fingerIndex)
		{
			this.FingerIndex = fingerIndex;
		}

		// Token: 0x06031A60 RID: 203360 RVA: 0x00C5E80D File Offset: 0x00C5CA0D
		public void StartTouch(FVector touchPosition)
		{
			this.TouchPosition = new FVector?(touchPosition);
			this.LastTouchPosition = new FVector?(touchPosition);
			this.IsTouch = true;
		}

		// Token: 0x06031A61 RID: 203361 RVA: 0x00C5E82E File Offset: 0x00C5CA2E
		public void EndTouch()
		{
			this.TouchPosition = null;
			this.LastTouchPosition = null;
			this.IsTouch = false;
		}

		// Token: 0x06031A62 RID: 203362 RVA: 0x00C5E84F File Offset: 0x00C5CA4F
		public void MoveTouch(FVector touchPosition)
		{
			if (this.CurrentFrameNumber != UKismetSystemLibrary.GetFrameCount())
			{
				this.LastTouchPosition = this.TouchPosition;
				this.CurrentFrameNumber = UKismetSystemLibrary.GetFrameCount();
			}
			this.TouchPosition = new FVector?(touchPosition);
		}

		// Token: 0x06031A63 RID: 203363 RVA: 0x00C5E881 File Offset: 0x00C5CA81
		public EFingerIndex GetFingerIndex()
		{
			return this.FingerIndex;
		}

		// Token: 0x06031A64 RID: 203364 RVA: 0x00C5E889 File Offset: 0x00C5CA89
		public FVector? GetTouchPosition()
		{
			return this.TouchPosition;
		}

		// Token: 0x06031A65 RID: 203365 RVA: 0x00C5E891 File Offset: 0x00C5CA91
		public FVector? GetLastTouchPosition()
		{
			return this.LastTouchPosition;
		}

		// Token: 0x06031A66 RID: 203366 RVA: 0x00C5E899 File Offset: 0x00C5CA99
		public bool IsInTouch()
		{
			return this.IsTouch;
		}

		// Token: 0x06031A67 RID: 203367 RVA: 0x00C5E8A1 File Offset: 0x00C5CAA1
		public bool IsTouchEmpty()
		{
			return !Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid((int)this.FingerIndex);
		}

		// Token: 0x06031A68 RID: 203368 RVA: 0x00C5E8B6 File Offset: 0x00C5CAB6
		[NullableContext(2)]
		public ULGUIPointerEventData GetPointerEventData()
		{
			return Singleton<LguiEventSystemManager>.Instance.GetPointerEventData((int)this.FingerIndex, false);
		}

		// Token: 0x06031A69 RID: 203369 RVA: 0x00C5E8CC File Offset: 0x00C5CACC
		public bool IsTouchComponentContainTag(FName tag)
		{
			ULGUIPointerEventData pointerEventData = this.GetPointerEventData();
			USceneComponent usceneComponent = (pointerEventData != null) ? pointerEventData.pressComponent : null;
			USceneComponent usceneComponent2 = (pointerEventData != null) ? pointerEventData.enterComponent : null;
			if (usceneComponent != null && usceneComponent.IsValid())
			{
				return usceneComponent.ComponentHasTag(tag);
			}
			return usceneComponent2 != null && usceneComponent2.IsValid() && usceneComponent2.ComponentHasTag(tag);
		}

		// Token: 0x0401CE4E RID: 118350
		private readonly EFingerIndex FingerIndex;

		// Token: 0x0401CE4F RID: 118351
		private FVector? TouchPosition;

		// Token: 0x0401CE50 RID: 118352
		private FVector? LastTouchPosition;

		// Token: 0x0401CE51 RID: 118353
		private bool IsTouch;

		// Token: 0x0401CE52 RID: 118354
		private long CurrentFrameNumber;
	}
}
