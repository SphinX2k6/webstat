using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006834 RID: 26676
	[NullableContext(2)]
	[Nullable(0)]
	public class FishingTechSecondaryNodeItem : UiPanelBase
	{
		// Token: 0x1700A189 RID: 41353
		// (get) Token: 0x0604281D RID: 272413 RVA: 0x0111218C File Offset: 0x0111038C
		public IFishingTechNode CurrentNode
		{
			get
			{
				return this.Node;
			}
		}

		// Token: 0x0604281E RID: 272414 RVA: 0x01112194 File Offset: 0x01110394
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604281F RID: 272415 RVA: 0x01112300 File Offset: 0x01110500
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFishingTechNodeRefresh, new Action<int>(this.OnFishingTechNodeRefresh));
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnUndeterminedClicked.Add(new Action(this.OnClickToggleOnUndetermined));
		}

		// Token: 0x06042820 RID: 272416 RVA: 0x01112340 File Offset: 0x01110540
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFishingTechNodeRefresh, new Action<int>(this.OnFishingTechNodeRefresh));
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingNormalTechNode, base.GetItem(7), this.Node.ConfigId);
		}

		// Token: 0x06042821 RID: 272417 RVA: 0x0111237F File Offset: 0x0111057F
		private void OnClickToggle(EToggleState toggleState)
		{
			Action<IFishingTechNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(this.Node, base.GetExtendToggle(0));
		}

		// Token: 0x06042822 RID: 272418 RVA: 0x0111239E File Offset: 0x0111059E
		private void OnClickToggleOnUndetermined()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			Action<IFishingTechNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(this.Node, base.GetExtendToggle(0));
		}

		// Token: 0x06042823 RID: 272419 RVA: 0x011123D0 File Offset: 0x011105D0
		private void OnFishingTechNodeRefresh(int nodeId)
		{
			IFishingTechNode node = this.Node;
			if (node == null || node.ConfigId != nodeId)
			{
				IFishingTechNode node2 = this.Node;
				if (node2 == null || node2.PreNode != nodeId)
				{
					return;
				}
			}
			this.RefreshNode(this.Node);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingTechNodeRedDotRefresh, this.Node.ConfigId);
		}

		// Token: 0x06042824 RID: 272420 RVA: 0x01112434 File Offset: 0x01110634
		[NullableContext(1)]
		public void RefreshNode(IFishingTechNode node)
		{
			this.Node = node;
			base.SetTextureByPath(ConfigBase<FishingConfig>.Instance.GetFishingTechById(this.Node.ConfigId).Icon, base.GetTexture(1), null, null);
			bool nodePreNodeUnlock = ModelBase<FishingModel>.Instance.GetNodePreNodeUnlock(this.Node.ConfigId);
			base.GetItem(6).SetUIActive(!nodePreNodeUnlock);
			if (!ModelBase<FishingModel>.Instance.GetFishingTechUnlock(this.Node.ConfigId))
			{
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
			}
			else
			{
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.RefreshStarItem();
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FishingNormalTechNode, base.GetItem(7), null, this.Node.ConfigId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingTechNodeRedDotRefresh, this.Node.ConfigId);
		}

		// Token: 0x06042825 RID: 272421 RVA: 0x01112520 File Offset: 0x01110720
		public void SelectNode()
		{
			if (ModelBase<FishingModel>.Instance.GetFishingTechUnlock(this.Node.ConfigId))
			{
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
				return;
			}
			Action<IFishingTechNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(this.Node, base.GetExtendToggle(0));
		}

		// Token: 0x06042826 RID: 272422 RVA: 0x01112574 File Offset: 0x01110774
		private void RefreshStarItem()
		{
			int techNodeCurrentLevel = ModelBase<FishingModel>.Instance.GetTechNodeCurrentLevel(this.Node.ConfigId);
			int techNodeMaxLevel = ModelBase<FishingModel>.Instance.GetTechNodeMaxLevel(this.Node.ConfigId);
			UUIText text = base.GetText(5);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Lv ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(techNodeCurrentLevel);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(techNodeMaxLevel);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			base.GetItem(2).SetUIActive(techNodeCurrentLevel > 0);
			base.GetItem(3).SetUIActive(techNodeCurrentLevel > 1);
			base.GetItem(4).SetUIActive(techNodeCurrentLevel > 2);
		}

		// Token: 0x04025041 RID: 151617
		private IFishingTechNode Node;

		// Token: 0x04025042 RID: 151618
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<IFishingTechNode, UUIExtendToggle> OnClickToggleBack;

		// Token: 0x0200C877 RID: 51319
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DB38 RID: 252728
			public const int Toggle = 0;

			// Token: 0x0403DB39 RID: 252729
			public const int IconTexture = 1;

			// Token: 0x0403DB3A RID: 252730
			public const int StarOneItem = 2;

			// Token: 0x0403DB3B RID: 252731
			public const int StarTwoItem = 3;

			// Token: 0x0403DB3C RID: 252732
			public const int StarThreeItem = 4;

			// Token: 0x0403DB3D RID: 252733
			public const int StarText = 5;

			// Token: 0x0403DB3E RID: 252734
			public const int LockItem = 6;

			// Token: 0x0403DB3F RID: 252735
			public const int RedDotItem = 7;
		}
	}
}
