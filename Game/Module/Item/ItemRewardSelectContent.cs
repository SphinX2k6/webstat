using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B72 RID: 23410
	[NullableContext(1)]
	[Nullable(0)]
	internal class ItemRewardSelectContent : UiPanelBase
	{
		// Token: 0x0603B30F RID: 242447 RVA: 0x00EFA3F7 File Offset: 0x00EF85F7
		public void SetOnClickBackButtonCallBack(Action callback)
		{
			this.OnClickBackButtonCallBack = callback;
		}

		// Token: 0x0603B310 RID: 242448 RVA: 0x00EFA400 File Offset: 0x00EF8600
		public void SetOnSelectItemCallBack(Action<int, int> callback)
		{
			this.OnSelectItemCallBack = callback;
		}

		// Token: 0x0603B311 RID: 242449 RVA: 0x00EFA409 File Offset: 0x00EF8609
		public void SetOnConfirmButtonCallBack(Action<int, int> callback)
		{
			this.OnConfirmButtonCallBack = callback;
		}

		// Token: 0x0603B312 RID: 242450 RVA: 0x00EFA414 File Offset: 0x00EF8614
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B313 RID: 242451 RVA: 0x00EFA568 File Offset: 0x00EF8768
		protected override UniTask OnBeforeStartAsync()
		{
			ItemRewardSelectContent.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ItemRewardSelectContent.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B314 RID: 242452 RVA: 0x00EFA5AC File Offset: 0x00EF87AC
		protected override void OnStart()
		{
			this.UiSequencePlayerInstance = new UiSequencePlayer(this.RootItem);
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.ButtonItem = new ButtonItem(base.GetItem(6));
			this.Layout = new GenericLayout<ItemSelectRewardItem, ItemSelectRewardItemData>(base.GetHorizontalLayout(1), new Func<ItemSelectRewardItem>(this.OnCreateRewardItem), null, false, true);
			this.CaptionItem.SetCloseCallBack(delegate
			{
				this.OnClickBackButtonCallBack();
			});
			this.CaptionItem.SetHelpCallBack(delegate
			{
				SelectRolePerformance? selectRolePerformanceConfig = ConfigBase<GachaAccumulateConfig>.Instance.GetSelectRolePerformanceConfig(this.GiftPackageId);
				if (selectRolePerformanceConfig != null)
				{
					ControllerBase<HelpController>.Instance.OpenHelpById(selectRolePerformanceConfig.Value.HelpId);
				}
			});
			this.ButtonItem.SetFunction(new Action<int>(this.OnClickConfirmButton));
		}

		// Token: 0x0603B315 RID: 242453 RVA: 0x00EFA654 File Offset: 0x00EF8854
		private void OnClickConfirmButton(int _)
		{
			this.OnConfirmButtonCallBack(this.CurrentSelectIndex, this.CurrentRewardList[this.CurrentSelectIndex]);
		}

		// Token: 0x0603B316 RID: 242454 RVA: 0x00EFA678 File Offset: 0x00EF8878
		private ItemSelectRewardItem OnCreateRewardItem()
		{
			return new ItemSelectRewardItem();
		}

		// Token: 0x0603B317 RID: 242455 RVA: 0x00EFA67F File Offset: 0x00EF887F
		private void OnClickToggle(int index)
		{
			this.CurrentSelectIndex = index;
			this.Refresh(this.GiftPackageId);
		}

		// Token: 0x0603B318 RID: 242456 RVA: 0x00EFA694 File Offset: 0x00EF8894
		private bool IfHaveRoleCallBackItemNeedRole(int itemId)
		{
			int[] resonantItemRoleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(itemId);
			if (resonantItemRoleId == null)
			{
				return false;
			}
			int id = resonantItemRoleId[0];
			return ModelBase<RoleModel>.Instance.GetRoleInstanceById(id) != null;
		}

		// Token: 0x0603B319 RID: 242457 RVA: 0x00EFA6C8 File Offset: 0x00EF88C8
		private bool IfCanResonant(int itemId)
		{
			ResonantChainOptionLimitInfo limitInfo = this.LimitInfo;
			if (limitInfo == null)
			{
				return true;
			}
			foreach (ResonantChainOptionLimitItemInfo resonantChainOptionLimitItemInfo in limitInfo.ItemInfos)
			{
				if (resonantChainOptionLimitItemInfo.ItemId == itemId)
				{
					return resonantChainOptionLimitItemInfo.Count < limitInfo.LimitNum;
				}
			}
			return true;
		}

		// Token: 0x0603B31A RID: 242458 RVA: 0x00EFA740 File Offset: 0x00EF8940
		private void RefreshResonantItem()
		{
			int num = this.CurrentRewardList[this.CurrentSelectIndex];
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(num);
			if (itemConfigData == null)
			{
				return;
			}
			int[] showTypes = itemConfigData.ShowTypes;
			if (showTypes == null || !showTypes.Contains(30))
			{
				return;
			}
			if (!this.IfHaveRoleCallBackItemNeedRole(num) || !this.IfCanResonant(num))
			{
				base.GetItem(3).SetUIActive(false);
				return;
			}
			int[] resonantItemRoleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(num);
			if (resonantItemRoleId == null || resonantItemRoleId.Length == 0)
			{
				return;
			}
			string textStringId = (ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(resonantItemRoleId[0]) <= 0) ? "CurrentResonantCountMax" : "CurrentResonantCount";
			base.GetItem(3).SetUIActive(true);
			RoleResonanceConfig instance = ConfigBase<RoleResonanceConfig>.Instance;
			int num2 = ((instance != null) ? instance.GetResonanceMaxLevel() : 0) - ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(resonantItemRoleId[0]);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textStringId, new <>z__ReadOnlySingleElementList<object>(num2));
		}

		// Token: 0x0603B31B RID: 242459 RVA: 0x00EFA834 File Offset: 0x00EF8A34
		private void RefreshInActiveItem()
		{
			int itemId = this.CurrentRewardList[this.CurrentSelectIndex];
			if (this.IfHaveRoleCallBackItemNeedRole(itemId) && this.IfCanResonant(itemId))
			{
				base.GetItem(5).SetUIActive(false);
				ButtonItem buttonItem = this.ButtonItem;
				if (buttonItem == null)
				{
					return;
				}
				buttonItem.SetActive(true);
				return;
			}
			else
			{
				base.GetItem(5).SetUIActive(true);
				ButtonItem buttonItem2 = this.ButtonItem;
				if (buttonItem2 == null)
				{
					return;
				}
				buttonItem2.SetActive(false);
				return;
			}
		}

		// Token: 0x0603B31C RID: 242460 RVA: 0x00EFA8A5 File Offset: 0x00EF8AA5
		[NullableContext(2)]
		public void SetLimitInfo(ResonantChainOptionLimitInfo limitInfo)
		{
			this.LimitInfo = limitInfo;
		}

		// Token: 0x0603B31D RID: 242461 RVA: 0x00EFA8B0 File Offset: 0x00EF8AB0
		public void Refresh(int giftPackageId)
		{
			GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(giftPackageId);
			if (giftPackageConfig == null || giftPackageConfig.GetValueOrDefault().Type != GiftType.ResonantChainOptional)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Inventory;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "找不到礼包配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("GiftPackageId", giftPackageId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.CurrentRewardList.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in giftPackageConfig.Value.Content())
			{
				this.CurrentRewardList.Add(keyValuePair.Key);
			}
			this.GiftPackageId = giftPackageId;
			List<ItemSelectRewardItemData> list = new List<ItemSelectRewardItemData>();
			for (int i = 0; i < this.CurrentRewardList.Count; i++)
			{
				ItemSelectRewardItemData item = new ItemSelectRewardItemData
				{
					Index = i,
					ItemId = this.CurrentRewardList[i],
					SelectState = (i == this.CurrentSelectIndex),
					LimitInfo = this.LimitInfo,
					OnClickToggleCallBack = new Action<int>(this.OnClickToggle)
				};
				list.Add(item);
			}
			this.Layout.RefreshByData(list, null, false);
			this.RefreshResonantItem();
			this.RefreshInActiveItem();
			int arg = this.CurrentRewardList[this.CurrentSelectIndex];
			this.OnSelectItemCallBack(arg, this.CurrentSelectIndex);
			this.RefreshRoleSpine();
			this.RefreshRoleDescribe();
			this.PlaySelectSequence();
		}

		// Token: 0x0603B31E RID: 242462 RVA: 0x00EFAA54 File Offset: 0x00EF8C54
		private void RefreshRoleSpine()
		{
			int itemId = this.CurrentRewardList[this.CurrentSelectIndex];
			USpineSkeletonAnimationComponent spine = base.GetSpine(7);
			SelectRoleItemPerformance? selectRoleItemPerformance = ConfigBase<GachaAccumulateConfig>.Instance.GetSelectRoleItemPerformance(itemId);
			string spineAtlasPath = selectRoleItemPerformance.Value.SpineAtlasPath;
			string spineDataPath = selectRoleItemPerformance.Value.SpineDataPath;
			base.SetSpineAssetByPath(spineAtlasPath, spineDataPath, spine).Forget();
		}

		// Token: 0x0603B31F RID: 242463 RVA: 0x00EFAABC File Offset: 0x00EF8CBC
		private void RefreshRoleDescribe()
		{
			int itemId = this.CurrentRewardList[this.CurrentSelectIndex];
			int[] resonantItemRoleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(itemId);
			if (resonantItemRoleId == null)
			{
				return;
			}
			int roleId = resonantItemRoleId[0];
			this.RoleDescribeComp.Update(roleId);
		}

		// Token: 0x0603B320 RID: 242464 RVA: 0x00EFAAFB File Offset: 0x00EF8CFB
		private void PlaySelectSequence()
		{
			this.UiSequencePlayerInstance.PlaySequencePurely("SwitchIn", false, false);
			this.UiSequencePlayerInstance.PlaySequencePurely("SwitchOut", false, false);
		}

		// Token: 0x0603B321 RID: 242465 RVA: 0x00EFAB24 File Offset: 0x00EF8D24
		public UniTask PlayStartSequenceAsync()
		{
			ItemRewardSelectContent.<PlayStartSequenceAsync>d__30 <PlayStartSequenceAsync>d__;
			<PlayStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequenceAsync>d__.<>4__this = this;
			<PlayStartSequenceAsync>d__.<>1__state = -1;
			<PlayStartSequenceAsync>d__.<>t__builder.Start<ItemRewardSelectContent.<PlayStartSequenceAsync>d__30>(ref <PlayStartSequenceAsync>d__);
			return <PlayStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B322 RID: 242466 RVA: 0x00EFAB68 File Offset: 0x00EF8D68
		public UniTask PlayCloseSequenceAsync()
		{
			ItemRewardSelectContent.<PlayCloseSequenceAsync>d__31 <PlayCloseSequenceAsync>d__;
			<PlayCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseSequenceAsync>d__.<>4__this = this;
			<PlayCloseSequenceAsync>d__.<>1__state = -1;
			<PlayCloseSequenceAsync>d__.<>t__builder.Start<ItemRewardSelectContent.<PlayCloseSequenceAsync>d__31>(ref <PlayCloseSequenceAsync>d__);
			return <PlayCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040215DC RID: 136668
		[Nullable(2)]
		private UiSequencePlayer UiSequencePlayerInstance;

		// Token: 0x040215DD RID: 136669
		[Nullable(2)]
		private RoleDescribeComponent RoleDescribeComp;

		// Token: 0x040215DE RID: 136670
		private Action OnClickBackButtonCallBack = delegate()
		{
		};

		// Token: 0x040215DF RID: 136671
		private Action<int, int> OnSelectItemCallBack = delegate(int _, int __)
		{
		};

		// Token: 0x040215E0 RID: 136672
		private Action<int, int> OnConfirmButtonCallBack = delegate(int _, int __)
		{
		};

		// Token: 0x040215E1 RID: 136673
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040215E2 RID: 136674
		[Nullable(2)]
		private ButtonItem ButtonItem;

		// Token: 0x040215E3 RID: 136675
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<ItemSelectRewardItem, ItemSelectRewardItemData> Layout;

		// Token: 0x040215E4 RID: 136676
		private int CurrentSelectIndex;

		// Token: 0x040215E5 RID: 136677
		private int GiftPackageId;

		// Token: 0x040215E6 RID: 136678
		private readonly List<int> CurrentRewardList = new List<int>();

		// Token: 0x040215E7 RID: 136679
		[Nullable(2)]
		private ResonantChainOptionLimitInfo LimitInfo;
	}
}
