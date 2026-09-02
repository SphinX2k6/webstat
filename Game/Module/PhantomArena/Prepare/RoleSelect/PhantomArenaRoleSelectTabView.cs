using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.RoleSelect
{
	// Token: 0x020054B7 RID: 21687
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaRoleSelectTabView : PhantomArenaChildViewBase
	{
		// Token: 0x17008E85 RID: 36485
		// (get) Token: 0x060373CF RID: 226255 RVA: 0x00E03154 File Offset: 0x00E01354
		// (set) Token: 0x060373D0 RID: 226256 RVA: 0x00E03161 File Offset: 0x00E01361
		public new IPhantomArenaRoleSelectTabViewModel ViewModel
		{
			get
			{
				return this.ViewModel as IPhantomArenaRoleSelectTabViewModel;
			}
			set
			{
				this.ViewModel = value;
			}
		}

		// Token: 0x060373D1 RID: 226257 RVA: 0x00E0316C File Offset: 0x00E0136C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(8, new Action(this.OnConfirmBtnClick))
			};
		}

		// Token: 0x060373D2 RID: 226258 RVA: 0x00E032CC File Offset: 0x00E014CC
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaRoleSelectTabView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaRoleSelectTabView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060373D3 RID: 226259 RVA: 0x00E03310 File Offset: 0x00E01510
		protected override void OnBeforeShow()
		{
			this.ViewModel.SetViewTitle("PhantomArenaRoleSelectTabView_Name");
			this.ViewModel.SetViewHelpId(337);
			this.ViewModel.SetViewHelpBtnActive(true);
			this.ViewModel.SetViewIcon("SP_IconSoundRemnantArena4");
			this.ViewModel.TextureCardRoleId = this.GetSelectedCardRoleId();
			this.ViewModel.RefreshRoleTexture();
			this.ViewModel.ShowRoleTexture(true);
		}

		// Token: 0x060373D4 RID: 226260 RVA: 0x00E033A0 File Offset: 0x00E015A0
		protected IPhantomArenaRoleSelectionItemData CreateCardRoleItemData(int cardRoleId)
		{
			bool flag = ModelBase<PhantomArenaModel>.Instance.IsRoleUnlock(cardRoleId);
			bool canShowSelectBtnInRoleSelectTabView = this.ViewModel.CanShowSelectBtnInRoleSelectTabView;
			bool canShowRewardInRoleSelectTabView = this.ViewModel.CanShowRewardInRoleSelectTabView;
			bool flag2 = ModelBase<PhantomArenaModel>.Instance.IsRoleReward(cardRoleId);
			return new PhantomArenaRoleSelectionItemData
			{
				CardRoleId = cardRoleId,
				CanReceived = (canShowRewardInRoleSelectTabView && flag && !flag2),
				IsLocked = !flag,
				CanSelect = (flag && canShowSelectBtnInRoleSelectTabView)
			};
		}

		// Token: 0x060373D5 RID: 226261 RVA: 0x00E0340E File Offset: 0x00E0160E
		protected int GetSelectedCardRoleId()
		{
			return this.CardRoleDataList[this.SelectedRoleIndex].CardRoleId;
		}

		// Token: 0x060373D6 RID: 226262 RVA: 0x00E03426 File Offset: 0x00E01626
		protected IPhantomArenaRoleSelectionItemData GetSelectedCardRoleData()
		{
			return this.CardRoleDataList[this.SelectedRoleIndex];
		}

		// Token: 0x060373D7 RID: 226263 RVA: 0x00E0343C File Offset: 0x00E0163C
		public void SelectCardRoleByCardRoleId(int cardRoleId, bool bPlayRoleChangeAnim)
		{
			int num = this.CardRoleDataList.FindIndex((IPhantomArenaRoleSelectionItemData value) => value.CardRoleId == cardRoleId);
			if (num == -1)
			{
				return;
			}
			this.SelectCardRoleByIndex(num, bPlayRoleChangeAnim);
		}

		// Token: 0x060373D8 RID: 226264 RVA: 0x00E0347C File Offset: 0x00E0167C
		public void SelectCardRoleByIndex(int index, bool bPlayRoleChangeAnim)
		{
			if (index == -1)
			{
				return;
			}
			this.SelectedRoleIndex = index;
			LoopScrollView<PhantomArenaRoleSelectionItem, IPhantomArenaRoleSelectionItemData> roleLoopScrollView = this.RoleLoopScrollView;
			if (roleLoopScrollView != null)
			{
				roleLoopScrollView.SelectGridProxy(index, false);
			}
			int cardRoleId = this.CardRoleDataList[index].CardRoleId;
			this.ViewModel.ChangeRoleTexture(cardRoleId, bPlayRoleChangeAnim);
			this.RefreshDetailView();
		}

		// Token: 0x060373D9 RID: 226265 RVA: 0x00E034D4 File Offset: 0x00E016D4
		protected void RefreshDetailView()
		{
			if (this.SelectedRoleIndex == -1 || this.SelectedRoleIndex >= this.CardRoleDataList.Count)
			{
				return;
			}
			int selectedCardRoleId = this.GetSelectedCardRoleId();
			PhantomBattleCardRole phantomBattleCardRole = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(selectedCardRoleId);
			int roleConfigId = phantomBattleCardRole.RoleConfigId;
			RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.Name, Array.Empty<object>());
			MiniElementItem elementItem = this.ElementItem;
			if (elementItem != null)
			{
				elementItem.RefreshMiniElement(value.ElementId);
			}
			this.RefreshStates();
			List<string> list = new List<string>();
			list.AddRange(phantomBattleCardRole.PassiveSkillIconList());
			list.AddRange(phantomBattleCardRole.SkillIconList());
			this.SelectedSkillIndex = 0;
			int count = list.Count;
			this.SkillItemDataList.Clear();
			foreach (string iconPath in list)
			{
				PhantomArenaRoleSkillItemData item = new PhantomArenaRoleSkillItemData
				{
					IconPath = iconPath
				};
				this.SkillItemDataList.Add(item);
			}
			for (int i = 0; i < count; i++)
			{
				PhantomArenaRoleSkillItem phantomArenaRoleSkillItem = this.SkillItemList[i];
				PhantomArenaRoleSkillItemData data = this.SkillItemDataList[i];
				phantomArenaRoleSkillItem.SetActive(true);
				phantomArenaRoleSkillItem.Refresh(data, this.SelectedSkillIndex == i, i);
			}
			if (this.SkillItemList.Count > count)
			{
				for (int j = count; j < this.SkillItemList.Count; j++)
				{
					this.SkillItemList[j].SetActive(false);
				}
			}
			this.RefreshSkillDetailView();
		}

		// Token: 0x060373DA RID: 226266 RVA: 0x00E03684 File Offset: 0x00E01884
		public void RefreshStates()
		{
			IPhantomArenaRoleSelectionItemData selectedCardRoleData = this.GetSelectedCardRoleData();
			int cardRoleId = selectedCardRoleData.CardRoleId;
			PhantomBattleCardRole phantomBattleCardRole = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(cardRoleId);
			base.GetItem(11).SetUIActive(selectedCardRoleData.IsLocked);
			base.GetItem(9).SetUIActive(selectedCardRoleData.CanReceived);
			base.GetButton(8).RootUIComp.Get().SetUIActive(selectedCardRoleData.CanSelect);
			if (selectedCardRoleData.IsLocked)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), phantomBattleCardRole.UnlockConditionTip, Array.Empty<object>());
			}
			if (selectedCardRoleData.CanReceived)
			{
				int dropId = phantomBattleCardRole.DropId;
				if (dropId > 0)
				{
					Dictionary<int, int> dictionary = ConfigDropPackageById.GetConfig(dropId, true).Value.DropPreview();
					if (dictionary.Count > 1)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.PhantomArena;
						ELogAuthor author = ELogAuthor.LZK;
						string message = "奖励物品数量大于1，请检查配置";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cardRoleConfig", cardRoleId);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					using (Dictionary<int, int>.Enumerator enumerator = dictionary.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							KeyValuePair<int, int> keyValuePair = enumerator.Current;
							int key = keyValuePair.Key;
							int value = keyValuePair.Value;
							TItem data = new TItem
							{
								ItemData = new InventoryDefine.GetItemData(key, 0),
								Count = value
							};
							CommonItemSmallItemGrid rewardItem = this.RewardItem;
							if (rewardItem != null)
							{
								rewardItem.Refresh(data);
							}
							CommonItemSmallItemGrid rewardItem2 = this.RewardItem;
							if (rewardItem2 != null)
							{
								rewardItem2.SetReceivableVisible(true);
							}
						}
					}
				}
			}
		}

		// Token: 0x060373DB RID: 226267 RVA: 0x00E03820 File Offset: 0x00E01A20
		public void RefreshSkillDetailView()
		{
			if (this.SelectedSkillIndex == -1)
			{
				return;
			}
			int selectedCardRoleId = this.GetSelectedCardRoleId();
			PhantomBattleCardRole phantomBattleCardRole = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(selectedCardRoleId);
			List<string> list = new List<string>();
			list.AddRange(phantomBattleCardRole.PassiveSkillNameList());
			list.AddRange(phantomBattleCardRole.SkillNameList());
			List<Tuple<string, string[]>> list2 = new List<Tuple<string, string[]>>();
			for (int i = 0; i < phantomBattleCardRole.PassiveSkillDescList().Length; i++)
			{
				string item = phantomBattleCardRole.PassiveSkillDescList()[i];
				string[] item2 = (phantomBattleCardRole.PassiveSkillDescParamsList() != null && phantomBattleCardRole.PassiveSkillDescParamsList().Length > i) ? phantomBattleCardRole.PassiveSkillDescParamsList()[i].ArrayString() : new string[0];
				list2.Add(new Tuple<string, string[]>(item, item2));
			}
			for (int j = 0; j < phantomBattleCardRole.SkillDescList().Length; j++)
			{
				string item3 = phantomBattleCardRole.SkillDescList()[j];
				string[] item4 = (phantomBattleCardRole.SkillDescParamsList().Length > j) ? phantomBattleCardRole.SkillDescParamsList()[j].ArrayString() : new string[0];
				list2.Add(new Tuple<string, string[]>(item3, item4));
			}
			if (list.Count != this.SkillItemDataList.Count || list2.Count != this.SkillItemDataList.Count)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "技能名称、技能描述数量不一致，请检查配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cardRoleConfig", selectedCardRoleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), list[this.SelectedSkillIndex], Array.Empty<object>());
			Tuple<string, string[]> tuple = list2[this.SelectedSkillIndex];
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), tuple.Item1, tuple.Item2);
		}

		// Token: 0x060373DC RID: 226268 RVA: 0x00E039D8 File Offset: 0x00E01BD8
		private PhantomArenaRoleSelectionItem CreateRoleItem()
		{
			PhantomArenaRoleSelectionItem phantomArenaRoleSelectionItem = new PhantomArenaRoleSelectionItem();
			phantomArenaRoleSelectionItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
			phantomArenaRoleSelectionItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChange));
			return phantomArenaRoleSelectionItem;
		}

		// Token: 0x060373DD RID: 226269 RVA: 0x00E03A04 File Offset: 0x00E01C04
		private void ToggleFunction(MediumItemGridExtendCallback callbackParameter)
		{
			if (callbackParameter.State == EToggleState.ETT_Checked)
			{
				IPhantomArenaRoleSelectionItemData phantomArenaRoleSelectionItemData = callbackParameter.Data as IPhantomArenaRoleSelectionItemData;
				this.SelectCardRoleByCardRoleId(phantomArenaRoleSelectionItemData.CardRoleId, true);
			}
		}

		// Token: 0x060373DE RID: 226270 RVA: 0x00E03A33 File Offset: 0x00E01C33
		protected bool CanExecuteChange(object data, bool isForceSelected, EToggleState state)
		{
			return state != EToggleState.ETT_Checked || (data as IPhantomArenaRoleSelectionItemData).CardRoleId != this.GetSelectedCardRoleId();
		}

		// Token: 0x060373DF RID: 226271 RVA: 0x00E03A54 File Offset: 0x00E01C54
		private void OnSkillItemSelect(int gridIndex)
		{
			if (gridIndex == this.SelectedSkillIndex)
			{
				return;
			}
			if (this.SelectedSkillIndex >= 0)
			{
				this.SkillItemList[this.SelectedSkillIndex].SetSelected(false);
			}
			this.SelectedSkillIndex = gridIndex;
			this.SkillItemList[this.SelectedSkillIndex].SetSelected(true);
			this.RefreshSkillDetailView();
		}

		// Token: 0x060373E0 RID: 226272 RVA: 0x00E03AAF File Offset: 0x00E01CAF
		private void OnConfirmBtnClick()
		{
			this.ViewModel.SelectedCardRoleId = this.GetSelectedCardRoleId();
			this.ViewModel.RoleSelectedConfirmFlag = true;
			base.CloseMe();
		}

		// Token: 0x060373E1 RID: 226273 RVA: 0x00E03AD4 File Offset: 0x00E01CD4
		private void OnRewardItemClicked(MediumItemGridExtendCallback _)
		{
			int selectedCardRoleId = this.GetSelectedCardRoleId();
			ControllerBase<PhantomArenaController>.Instance.RoleRewardRequest(selectedCardRoleId, new Action<int>(this.OnRoleReward));
		}

		// Token: 0x060373E2 RID: 226274 RVA: 0x00E03B00 File Offset: 0x00E01D00
		private void OnRoleReward(int cardRoleId)
		{
			int i = 0;
			while (i < this.CardRoleDataList.Count)
			{
				IPhantomArenaRoleSelectionItemData phantomArenaRoleSelectionItemData = this.CardRoleDataList[i];
				if (phantomArenaRoleSelectionItemData.CardRoleId == cardRoleId)
				{
					PhantomArenaRoleSelectionItemData phantomArenaRoleSelectionItemData2 = phantomArenaRoleSelectionItemData as PhantomArenaRoleSelectionItemData;
					if (phantomArenaRoleSelectionItemData2 != null)
					{
						phantomArenaRoleSelectionItemData2.CanReceived = false;
					}
					LoopScrollView<PhantomArenaRoleSelectionItem, IPhantomArenaRoleSelectionItemData> roleLoopScrollView = this.RoleLoopScrollView;
					if (roleLoopScrollView == null)
					{
						break;
					}
					roleLoopScrollView.RefreshGridProxy(i);
					break;
				}
				else
				{
					i++;
				}
			}
			this.RefreshDetailView();
		}

		// Token: 0x0401FC1D RID: 130077
		private readonly List<IPhantomArenaRoleSelectionItemData> CardRoleDataList = new List<IPhantomArenaRoleSelectionItemData>();

		// Token: 0x0401FC1E RID: 130078
		private int SelectedRoleIndex = -1;

		// Token: 0x0401FC1F RID: 130079
		private int SelectedSkillIndex = -1;

		// Token: 0x0401FC20 RID: 130080
		private MiniElementItem ElementItem;

		// Token: 0x0401FC21 RID: 130081
		private LoopScrollView<PhantomArenaRoleSelectionItem, IPhantomArenaRoleSelectionItemData> RoleLoopScrollView;

		// Token: 0x0401FC22 RID: 130082
		private readonly List<PhantomArenaRoleSkillItem> SkillItemList = new List<PhantomArenaRoleSkillItem>();

		// Token: 0x0401FC23 RID: 130083
		private readonly List<PhantomArenaRoleSkillItemData> SkillItemDataList = new List<PhantomArenaRoleSkillItemData>();

		// Token: 0x0401FC24 RID: 130084
		private CommonItemSmallItemGrid RewardItem;

		// Token: 0x0200B422 RID: 46114
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037BD4 RID: 228308
			public const int RoleScrollView = 0;

			// Token: 0x04037BD5 RID: 228309
			public const int RoleItem = 1;

			// Token: 0x04037BD6 RID: 228310
			public const int RoleNameText = 2;

			// Token: 0x04037BD7 RID: 228311
			public const int ElementItem = 3;

			// Token: 0x04037BD8 RID: 228312
			public const int SkillItem1 = 4;

			// Token: 0x04037BD9 RID: 228313
			public const int SkillItem2 = 5;

			// Token: 0x04037BDA RID: 228314
			public const int SkillNameText = 6;

			// Token: 0x04037BDB RID: 228315
			public const int SkillDescText = 7;

			// Token: 0x04037BDC RID: 228316
			public const int ConfirmBtn = 8;

			// Token: 0x04037BDD RID: 228317
			public const int RewardItem = 9;

			// Token: 0x04037BDE RID: 228318
			public const int RewardGridItem = 10;

			// Token: 0x04037BDF RID: 228319
			public const int LockItem = 11;

			// Token: 0x04037BE0 RID: 228320
			public const int LockText = 12;
		}
	}
}
