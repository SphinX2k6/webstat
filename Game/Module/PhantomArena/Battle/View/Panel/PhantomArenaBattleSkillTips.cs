using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055B9 RID: 21945
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleSkillTips : UiPanelBase
	{
		// Token: 0x06037E0E RID: 228878 RVA: 0x00E288D4 File Offset: 0x00E26AD4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06037E0F RID: 228879 RVA: 0x00E2890D File Offset: 0x00E26B0D
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x06037E10 RID: 228880 RVA: 0x00E28937 File Offset: 0x00E26B37
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
			this.RemoveTimeHandler();
		}

		// Token: 0x06037E11 RID: 228881 RVA: 0x00E2894A File Offset: 0x00E26B4A
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06037E12 RID: 228882 RVA: 0x00E28960 File Offset: 0x00E26B60
		private void SetPivotAndResetOffset(float pivotX, float pivotY, UIAnchorHorizontalAlign hAlign)
		{
			UUIItem originalItem = this.GetOriginalItem();
			if (originalItem != null)
			{
				originalItem.SetPivot(new FVector2D(pivotX, pivotY));
			}
			if (originalItem != null)
			{
				originalItem.SetAnchorHAlign(hAlign);
			}
			if (originalItem == null)
			{
				return;
			}
			originalItem.SetAnchorOffset(new FVector2D(0f, 0f));
		}

		// Token: 0x06037E13 RID: 228883 RVA: 0x00E289AC File Offset: 0x00E26BAC
		private void AddTimeHandler()
		{
			this.RemoveTimeHandler();
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.CheckMouseInTip();
			}, 100f, 1f, null, null, true);
		}

		// Token: 0x06037E14 RID: 228884 RVA: 0x00E289DD File Offset: 0x00E26BDD
		private void RemoveTimeHandler()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x06037E15 RID: 228885 RVA: 0x00E28A00 File Offset: 0x00E26C00
		private void CheckMouseInTip()
		{
			if (this.RootItem == null)
			{
				this.RemoveTimeHandler();
				return;
			}
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, true);
			if (pointerEventData == null || !pointerEventData.enterComponentStack.Contains(this.RootItem))
			{
				this.HideTips();
			}
		}

		// Token: 0x06037E16 RID: 228886 RVA: 0x00E28A48 File Offset: 0x00E26C48
		private void ShowTips()
		{
			this.RemoveTimeHandler();
			this.SetActive(true);
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequence("Start", false, null);
		}

		// Token: 0x06037E17 RID: 228887 RVA: 0x00E28A8C File Offset: 0x00E26C8C
		private void HideTips()
		{
			this.RemoveTimeHandler();
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequence("Close", false, null);
		}

		// Token: 0x06037E18 RID: 228888 RVA: 0x00E28AC6 File Offset: 0x00E26CC6
		public void Refresh(IPhantomArenaSkillData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.SkillName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.SkillDesc, data.SkillDescParams);
		}

		// Token: 0x06037E19 RID: 228889 RVA: 0x00E28B01 File Offset: 0x00E26D01
		public void SetTipsPosition(UUIItem attachItem, bool isOwn)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIParent(attachItem, false);
			}
			if (isOwn)
			{
				this.SetPivotAndResetOffset(1f, 0f, UIAnchorHorizontalAlign.Right);
				return;
			}
			this.SetPivotAndResetOffset(0f, 1f, UIAnchorHorizontalAlign.Left);
		}

		// Token: 0x06037E1A RID: 228890 RVA: 0x00E28B3C File Offset: 0x00E26D3C
		public void SetTipsActive(bool isActive)
		{
			if (this.IsInActive == isActive)
			{
				return;
			}
			this.IsInActive = isActive;
			if (isActive)
			{
				this.ShowTips();
				return;
			}
			this.AddTimeHandler();
		}

		// Token: 0x0401FFAB RID: 130987
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FFAC RID: 130988
		protected bool IsInActive;

		// Token: 0x0401FFAD RID: 130989
		protected TimerHandle TimerHandle;

		// Token: 0x0200B57A RID: 46458
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038293 RID: 230035
			public const int SkillName = 0;

			// Token: 0x04038294 RID: 230036
			public const int SkillDesc = 1;
		}
	}
}
