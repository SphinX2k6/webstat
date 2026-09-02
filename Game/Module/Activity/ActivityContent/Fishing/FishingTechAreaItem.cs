using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200682D RID: 26669
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingTechAreaItem : UiPanelBase
	{
		// Token: 0x060427E8 RID: 272360 RVA: 0x01110FF4 File Offset: 0x0110F1F4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060427E9 RID: 272361 RVA: 0x01111104 File Offset: 0x0110F304
		protected override UniTask OnBeforeStartAsync()
		{
			FishingTechAreaItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingTechAreaItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060427EA RID: 272362 RVA: 0x01111148 File Offset: 0x0110F348
		public void RefreshNodeList(IFishingTechNode[] nodeList)
		{
			int num = 0;
			int num2 = 0;
			foreach (IFishingTechNode fishingTechNode in nodeList)
			{
				if (fishingTechNode.NodeType == EFishingTechNodeType.Secondary)
				{
					this.SecondaryNodeItemList[num2++].RefreshNode(fishingTechNode);
				}
				else
				{
					this.CoreAndImportantNodeItemList[num++].RefreshNode(fishingTechNode);
				}
			}
			foreach (FishingTechNodeItem fishingTechNodeItem in this.CoreAndImportantNodeItemList)
			{
				fishingTechNodeItem.OnClickToggleBack = new Action<IFishingTechNode, UUIExtendToggle>(this.OnClickToggle);
			}
			foreach (FishingTechSecondaryNodeItem fishingTechSecondaryNodeItem in this.SecondaryNodeItemList)
			{
				fishingTechSecondaryNodeItem.OnClickToggleBack = new Action<IFishingTechNode, UUIExtendToggle>(this.OnClickToggle);
			}
		}

		// Token: 0x060427EB RID: 272363 RVA: 0x01111244 File Offset: 0x0110F444
		public void FindAndSelectNode(IFishingTechNode node)
		{
			foreach (FishingTechNodeItem fishingTechNodeItem in this.CoreAndImportantNodeItemList)
			{
				if (fishingTechNodeItem.CurrentNode == node)
				{
					fishingTechNodeItem.SelectNode();
					return;
				}
			}
			foreach (FishingTechSecondaryNodeItem fishingTechSecondaryNodeItem in this.SecondaryNodeItemList)
			{
				if (fishingTechSecondaryNodeItem.CurrentNode == node)
				{
					fishingTechSecondaryNodeItem.SelectNode();
					break;
				}
			}
		}

		// Token: 0x060427EC RID: 272364 RVA: 0x011112F0 File Offset: 0x0110F4F0
		private void OnClickToggle(IFishingTechNode node, UUIExtendToggle toggle)
		{
			Action<IFishingTechNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(node, toggle);
		}

		// Token: 0x04025033 RID: 151603
		private readonly List<FishingTechNodeItem> CoreAndImportantNodeItemList = new List<FishingTechNodeItem>();

		// Token: 0x04025034 RID: 151604
		private readonly List<FishingTechSecondaryNodeItem> SecondaryNodeItemList = new List<FishingTechSecondaryNodeItem>();

		// Token: 0x04025035 RID: 151605
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<IFishingTechNode, UUIExtendToggle> OnClickToggleBack;

		// Token: 0x0200C86C RID: 51308
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DB04 RID: 252676
			public const int CoreNodeItem = 0;

			// Token: 0x0403DB05 RID: 252677
			public const int ImportantNodeOneItem = 1;

			// Token: 0x0403DB06 RID: 252678
			public const int ImportantNodeTwoItem = 2;

			// Token: 0x0403DB07 RID: 252679
			public const int ImportantNodeThreeItem = 3;

			// Token: 0x0403DB08 RID: 252680
			public const int SecondaryNodeOneItem = 4;

			// Token: 0x0403DB09 RID: 252681
			public const int SecondaryNodeTwoItem = 5;

			// Token: 0x0403DB0A RID: 252682
			public const int TitleSprite = 13;
		}
	}
}
