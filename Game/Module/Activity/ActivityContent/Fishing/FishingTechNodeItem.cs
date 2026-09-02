using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006832 RID: 26674
	[NullableContext(2)]
	[Nullable(0)]
	public class FishingTechNodeItem : UiPanelBase
	{
		// Token: 0x1700A188 RID: 41352
		// (get) Token: 0x06042803 RID: 272387 RVA: 0x0111192C File Offset: 0x0110FB2C
		public IFishingTechNode CurrentNode
		{
			get
			{
				return this.Node;
			}
		}

		// Token: 0x06042804 RID: 272388 RVA: 0x01111934 File Offset: 0x0110FB34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042805 RID: 272389 RVA: 0x01111A1C File Offset: 0x0110FC1C
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

		// Token: 0x06042806 RID: 272390 RVA: 0x01111A5C File Offset: 0x0110FC5C
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFishingTechNodeRefresh, new Action<int>(this.OnFishingTechNodeRefresh));
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingNormalTechNode, base.GetItem(3), this.Node.ConfigId);
		}

		// Token: 0x06042807 RID: 272391 RVA: 0x01111A9B File Offset: 0x0110FC9B
		private void OnClickToggle(EToggleState toggleState)
		{
			Action<IFishingTechNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(this.Node, base.GetExtendToggle(0));
		}

		// Token: 0x06042808 RID: 272392 RVA: 0x01111ABA File Offset: 0x0110FCBA
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

		// Token: 0x06042809 RID: 272393 RVA: 0x01111AEC File Offset: 0x0110FCEC
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

		// Token: 0x0604280A RID: 272394 RVA: 0x01111B4E File Offset: 0x0110FD4E
		public void SelectNode()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			Action<IFishingTechNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(this.Node, base.GetExtendToggle(0));
		}

		// Token: 0x0604280B RID: 272395 RVA: 0x01111B80 File Offset: 0x0110FD80
		[NullableContext(1)]
		public void RefreshNode(IFishingTechNode node)
		{
			if (node == null)
			{
				return;
			}
			if (this.Node != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingNormalTechNode, base.GetItem(3), this.Node.ConfigId);
			}
			this.Node = node;
			base.SetTextureByPath(ConfigBase<FishingConfig>.Instance.GetFishingTechById(this.Node.ConfigId).Icon, base.GetTexture(1), null, null);
			bool nodePreNodeUnlock = ModelBase<FishingModel>.Instance.GetNodePreNodeUnlock(this.Node.ConfigId);
			base.GetItem(2).SetUIActive(!nodePreNodeUnlock);
			if (!ModelBase<FishingModel>.Instance.GetFishingTechUnlock(this.Node.ConfigId))
			{
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
			}
			else
			{
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FishingNormalTechNode, base.GetItem(3), null, this.Node.ConfigId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingTechNodeRedDotRefresh, this.Node.ConfigId);
		}

		// Token: 0x04025039 RID: 151609
		private IFishingTechNode Node;

		// Token: 0x0402503A RID: 151610
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<IFishingTechNode, UUIExtendToggle> OnClickToggleBack;

		// Token: 0x0200C872 RID: 51314
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DB21 RID: 252705
			public const int Toggle = 0;

			// Token: 0x0403DB22 RID: 252706
			public const int IconTexture = 1;

			// Token: 0x0403DB23 RID: 252707
			public const int LockItem = 2;

			// Token: 0x0403DB24 RID: 252708
			public const int RedDotItem = 3;
		}
	}
}
