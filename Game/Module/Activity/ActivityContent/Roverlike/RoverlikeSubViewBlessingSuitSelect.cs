using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063D4 RID: 25556
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSubViewBlessingSuitSelect : RoverlikeActionSubViewBase
	{
		// Token: 0x17009DB6 RID: 40374
		// (get) Token: 0x060402AA RID: 262826 RVA: 0x01071BDC File Offset: 0x0106FDDC
		public override ERoverActionSubViewType SubViewType
		{
			get
			{
				return ERoverActionSubViewType.BlessingSuitSelect;
			}
		}

		// Token: 0x17009DB7 RID: 40375
		// (get) Token: 0x060402AB RID: 262827 RVA: 0x01071BDF File Offset: 0x0106FDDF
		public override string ResourceId
		{
			get
			{
				return "UiItem_RoverlikeBlessingSetChoose";
			}
		}

		// Token: 0x060402AC RID: 262828 RVA: 0x01071BE8 File Offset: 0x0106FDE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnArrowRightClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnArrowLeftClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060402AD RID: 262829 RVA: 0x01071D58 File Offset: 0x0106FF58
		protected override void OnStart()
		{
			this.ConfirmBtn = new ButtonItem(base.GetItem(6));
			this.ConfirmBtn.SetFunction(delegate(int _)
			{
				this.OnConfirmClick();
			});
			this.AttributeScroll = new GenericScrollViewNew<RoverlikeBlessingCardItem, IRoverlikeBlessingItemData>(base.GetScrollViewWithScrollbar(0), new Func<RoverlikeBlessingCardItem>(this.CreateAttributeItem), null, false, null);
			this.RoleLayout = new GenericLayout<RoverlikeBlessingRoleItem, IRoverlikeBlessingRoleData>(base.GetVerticalLayout(4), new Func<RoverlikeBlessingRoleItem>(this.CreateRoleItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x060402AE RID: 262830 RVA: 0x01071DE0 File Offset: 0x0106FFE0
		private void OnBtnArrowRightClick()
		{
			if (this.AllSuitDataList.Count <= 1)
			{
				return;
			}
			this.CurrentSuitIndex = (this.CurrentSuitIndex + 1) % this.AllSuitDataList.Count;
			this.RefreshCurrentSuit();
		}

		// Token: 0x060402AF RID: 262831 RVA: 0x01071E11 File Offset: 0x01070011
		private void OnBtnArrowLeftClick()
		{
			if (this.AllSuitDataList.Count <= 1)
			{
				return;
			}
			this.CurrentSuitIndex = (this.CurrentSuitIndex - 1 + this.AllSuitDataList.Count) % this.AllSuitDataList.Count;
			this.RefreshCurrentSuit();
		}

		// Token: 0x060402B0 RID: 262832 RVA: 0x01071E4E File Offset: 0x0107004E
		private void OnConfirmClick()
		{
			base.TryInteractAction(delegate
			{
				IRoverlikeBlessingSuitData roverlikeBlessingSuitData = this.AllSuitDataList[this.CurrentSuitIndex];
				if (roverlikeBlessingSuitData == null)
				{
					return;
				}
				RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
				if (currentActivityData == null)
				{
					return;
				}
				ControllerBase<RoverlikeController>.Instance.RoverRogueBlessGroupSelectRequest(currentActivityData.Id, roverlikeBlessingSuitData.SuitId, delegate(bool isSuccess)
				{
					if (isSuccess)
					{
						ControllerBase<RoverlikeController>.Instance.FinishActionSubView(this.IncId);
					}
				});
			});
		}

		// Token: 0x060402B1 RID: 262833 RVA: 0x01071E64 File Offset: 0x01070064
		private void OnRoleItemClick(IRoverlikeBlessingRoleData data)
		{
			if (this.GetCurrentRoleId() == data.RoleId)
			{
				return;
			}
			int currentSuitIndex;
			if (this.RoleIdToSuitIndexMap.TryGetValue(data.RoleId, out currentSuitIndex))
			{
				this.CurrentSuitIndex = currentSuitIndex;
				this.RefreshCurrentSuit();
			}
		}

		// Token: 0x060402B2 RID: 262834 RVA: 0x01071EA2 File Offset: 0x010700A2
		private RoverlikeBlessingCardItem CreateAttributeItem()
		{
			return new RoverlikeBlessingCardItem();
		}

		// Token: 0x060402B3 RID: 262835 RVA: 0x01071EA9 File Offset: 0x010700A9
		private RoverlikeBlessingRoleItem CreateRoleItem()
		{
			RoverlikeBlessingRoleItem roverlikeBlessingRoleItem = new RoverlikeBlessingRoleItem();
			roverlikeBlessingRoleItem.BindOnRoleClick(new Action<IRoverlikeBlessingRoleData>(this.OnRoleItemClick));
			return roverlikeBlessingRoleItem;
		}

		// Token: 0x060402B4 RID: 262836 RVA: 0x01071EC2 File Offset: 0x010700C2
		private void RefreshCurrentSuit()
		{
			this.SelectCurrentRole();
			this.RefreshAttributeScroll();
		}

		// Token: 0x060402B5 RID: 262837 RVA: 0x01071ED0 File Offset: 0x010700D0
		private void InitRoleSlots()
		{
			HashSet<int> hashSet = new HashSet<int>();
			this.RoleDataList = new List<IRoverlikeBlessingRoleData>();
			this.RoleIdToSuitIndexMap.Clear();
			for (int i = 0; i < this.AllSuitDataList.Count; i++)
			{
				RoverRogueBlessGroup? blessGroupConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessGroupConfig(this.AllSuitDataList[i].SuitId);
				if (blessGroupConfig != null && !hashSet.Contains(blessGroupConfig.Value.BlessRoleId))
				{
					hashSet.Add(blessGroupConfig.Value.BlessRoleId);
					this.RoleIdToSuitIndexMap[blessGroupConfig.Value.BlessRoleId] = i;
					RoverlikeBlessingRoleData item = new RoverlikeBlessingRoleData
					{
						RoleId = blessGroupConfig.Value.BlessRoleId,
						IsSelected = false
					};
					this.RoleDataList.Add(item);
				}
			}
			this.RefreshRoleLayout();
		}

		// Token: 0x060402B6 RID: 262838 RVA: 0x01071FB8 File Offset: 0x010701B8
		private void RefreshRoleLayout()
		{
			bool uiactive = this.RoleDataList.Count > 1;
			base.GetButton(2).RootUIComp.Get().SetUIActive(uiactive);
			base.GetButton(3).RootUIComp.Get().SetUIActive(uiactive);
			GenericLayout<RoverlikeBlessingRoleItem, IRoverlikeBlessingRoleData> roleLayout = this.RoleLayout;
			if (roleLayout == null)
			{
				return;
			}
			roleLayout.RefreshByData(this.RoleDataList, delegate
			{
				this.SelectCurrentRole();
			}, true);
		}

		// Token: 0x060402B7 RID: 262839 RVA: 0x0107202C File Offset: 0x0107022C
		private void SelectCurrentRole()
		{
			int currentRoleId = this.GetCurrentRoleId();
			if (currentRoleId > 0)
			{
				GenericLayout<RoverlikeBlessingRoleItem, IRoverlikeBlessingRoleData> roleLayout = this.RoleLayout;
				if (roleLayout == null)
				{
					return;
				}
				roleLayout.SelectGridProxyByKey(currentRoleId, false);
			}
		}

		// Token: 0x060402B8 RID: 262840 RVA: 0x0107205C File Offset: 0x0107025C
		private int GetCurrentRoleId()
		{
			IRoverlikeBlessingSuitData roverlikeBlessingSuitData = this.AllSuitDataList[this.CurrentSuitIndex];
			if (roverlikeBlessingSuitData == null)
			{
				return 0;
			}
			RoverRogueBlessGroup? blessGroupConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessGroupConfig(roverlikeBlessingSuitData.SuitId);
			if (blessGroupConfig == null)
			{
				return 0;
			}
			return blessGroupConfig.GetValueOrDefault().BlessRoleId;
		}

		// Token: 0x060402B9 RID: 262841 RVA: 0x010720AC File Offset: 0x010702AC
		private void RefreshAttributeScroll()
		{
			IRoverlikeBlessingSuitData roverlikeBlessingSuitData = this.AllSuitDataList[this.CurrentSuitIndex];
			if (roverlikeBlessingSuitData == null)
			{
				return;
			}
			List<IRoverlikeBlessingItemData> list = new List<IRoverlikeBlessingItemData>();
			foreach (int blessId in roverlikeBlessingSuitData.BlessingIdList)
			{
				list.Add(new RoverlikeBlessingItemData
				{
					BlessId = blessId,
					AllowToggleInteract = new bool?(false)
				});
			}
			this.AttributeScroll.RefreshByData(list, new Action(this.OnAttributeScrollRefreshed), true);
		}

		// Token: 0x060402BA RID: 262842 RVA: 0x0107214C File Offset: 0x0107034C
		private void OnAttributeScrollRefreshed()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RoverlikeBlessingSuitSelect");
		}

		// Token: 0x060402BB RID: 262843 RVA: 0x01072164 File Offset: 0x01070364
		public override void OnRefreshSubView()
		{
			IRoverlikeBlessingSuitSelectParam roverlikeBlessingSuitSelectParam = this.OpenParam as IRoverlikeBlessingSuitSelectParam;
			if (roverlikeBlessingSuitSelectParam == null || roverlikeBlessingSuitSelectParam.SuitDataList.Count == 0)
			{
				return;
			}
			this.AllSuitDataList = roverlikeBlessingSuitSelectParam.SuitDataList;
			this.CurrentSuitIndex = roverlikeBlessingSuitSelectParam.SelectedIndex;
			this.InitRoleSlots();
			this.RefreshAttributeScroll();
		}

		// Token: 0x04023FFA RID: 147450
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoverlikeBlessingCardItem, IRoverlikeBlessingItemData> AttributeScroll;

		// Token: 0x04023FFB RID: 147451
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeBlessingRoleItem, IRoverlikeBlessingRoleData> RoleLayout;

		// Token: 0x04023FFC RID: 147452
		private List<IRoverlikeBlessingRoleData> RoleDataList = new List<IRoverlikeBlessingRoleData>();

		// Token: 0x04023FFD RID: 147453
		[Nullable(2)]
		private ButtonItem ConfirmBtn;

		// Token: 0x04023FFE RID: 147454
		private List<IRoverlikeBlessingSuitData> AllSuitDataList = new List<IRoverlikeBlessingSuitData>();

		// Token: 0x04023FFF RID: 147455
		private int CurrentSuitIndex;

		// Token: 0x04024000 RID: 147456
		private readonly Dictionary<int, int> RoleIdToSuitIndexMap = new Dictionary<int, int>();

		// Token: 0x0200C437 RID: 50231
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C66E RID: 247406
			public const int ScrollView = 0;

			// Token: 0x0403C66F RID: 247407
			public const int ItemAttribute = 1;

			// Token: 0x0403C670 RID: 247408
			public const int BtnArrowRight = 2;

			// Token: 0x0403C671 RID: 247409
			public const int BtnArrowLeft = 3;

			// Token: 0x0403C672 RID: 247410
			public const int RoleLayout = 4;

			// Token: 0x0403C673 RID: 247411
			public const int ItemRoleTemplate = 5;

			// Token: 0x0403C674 RID: 247412
			public const int ItemConfirm = 6;
		}
	}
}
