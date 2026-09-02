using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Kurotato.View.Components;
using CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect;
using CSharpScript.Game.Module.Kurotato.View.RoleSelect;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.HandBook
{
	// Token: 0x02005AB8 RID: 23224
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoHandBookRolePanel : UiPanelBase
	{
		// Token: 0x0603AB8F RID: 240527 RVA: 0x00EE2F48 File Offset: 0x00EE1148
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB90 RID: 240528 RVA: 0x00EE3188 File Offset: 0x00EE1388
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoHandBookRolePanel.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoHandBookRolePanel.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB91 RID: 240529 RVA: 0x00EE31CB File Offset: 0x00EE13CB
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603AB92 RID: 240530 RVA: 0x00EE31DE File Offset: 0x00EE13DE
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x0603AB93 RID: 240531 RVA: 0x00EE31F0 File Offset: 0x00EE13F0
		private UniTask RefreshView()
		{
			KurotatoHandBookRolePanel.<RefreshView>d__15 <RefreshView>d__;
			<RefreshView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshView>d__.<>4__this = this;
			<RefreshView>d__.<>1__state = -1;
			<RefreshView>d__.<>t__builder.Start<KurotatoHandBookRolePanel.<RefreshView>d__15>(ref <RefreshView>d__);
			return <RefreshView>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB94 RID: 240532 RVA: 0x00EE3234 File Offset: 0x00EE1434
		private void RefreshRecordInfo()
		{
			KurotatoRoleData kurotatoRoleData = this.KurotatoActivityData.GetKurotatoRoleData(this.RoleId);
			UUIItem item = base.GetItem(11);
			if (item != null)
			{
				item.SetUIActive(kurotatoRoleData.HasHistory);
			}
			if (!kurotatoRoleData.HasHistory)
			{
				return;
			}
			UUIText text = base.GetText(18);
			if (text != null)
			{
				text.SetText(kurotatoRoleData.HistoryWave.ToString(), true);
			}
			UUIText text2 = base.GetText(12);
			if (text2 != null)
			{
				text2.SetText(kurotatoRoleData.HistoryKillNum.ToString(), true);
			}
			foreach (KurotatoWaveLevel kurotatoWaveLevel in ConfigBase<KurotatoConfig>.Instance.GetWaveLevelConfigList())
			{
				if (kurotatoWaveLevel.WaveRangeIter().ToList<int>()[0] <= kurotatoRoleData.HistoryWave && kurotatoRoleData.HistoryWave <= kurotatoWaveLevel.WaveRangeIter().ToList<int>()[1])
				{
					base.SetTextureByPath(kurotatoWaveLevel.Icon, base.GetTexture(13), null, null);
					break;
				}
			}
		}

		// Token: 0x0603AB95 RID: 240533 RVA: 0x00EE334C File Offset: 0x00EE154C
		private UniTask OnRoleToggleClickCallback(int roleId)
		{
			KurotatoHandBookRolePanel.<OnRoleToggleClickCallback>d__17 <OnRoleToggleClickCallback>d__;
			<OnRoleToggleClickCallback>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnRoleToggleClickCallback>d__.<>4__this = this;
			<OnRoleToggleClickCallback>d__.roleId = roleId;
			<OnRoleToggleClickCallback>d__.<>1__state = -1;
			<OnRoleToggleClickCallback>d__.<>t__builder.Start<KurotatoHandBookRolePanel.<OnRoleToggleClickCallback>d__17>(ref <OnRoleToggleClickCallback>d__);
			return <OnRoleToggleClickCallback>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB96 RID: 240534 RVA: 0x00EE3397 File Offset: 0x00EE1597
		public void RefreshRoleList()
		{
			LoopScrollView<KurotatoRoleGridItem, int> roleLoopScrollView = this.RoleLoopScrollView;
			if (roleLoopScrollView == null)
			{
				return;
			}
			roleLoopScrollView.RefreshAllGridProxies();
		}

		// Token: 0x0603AB97 RID: 240535 RVA: 0x00EE33A9 File Offset: 0x00EE15A9
		private KurotatoRoleGridItem CreateRoleItem()
		{
			KurotatoRoleGridItem kurotatoRoleGridItem = new KurotatoRoleGridItem();
			kurotatoRoleGridItem.IsHandBookContext = true;
			kurotatoRoleGridItem.SetToggleClickCallback(delegate(int roleId)
			{
				this.OnRoleToggleClickCallback(roleId).Forget();
			});
			return kurotatoRoleGridItem;
		}

		// Token: 0x0603AB98 RID: 240536 RVA: 0x00EE33CC File Offset: 0x00EE15CC
		private void OnWeaponToggleClickCallback(IKurotatoSmallItemGridData data)
		{
			KurotatoRoleData kurotatoRoleData = this.KurotatoActivityData.GetKurotatoRoleData(this.RoleId);
			List<KurotatoCardTip> collection = (from id in kurotatoRoleData.InitWeaponIds
			select new KurotatoCardTip
			{
				CardType = EKurotatoCardType.Weapon,
				SelectId = id,
				IsConfigId = new bool?(true)
			}).ToList<KurotatoCardTip>();
			List<KurotatoCardTip> collection2 = (from id in kurotatoRoleData.InitItemIds
			select new KurotatoCardTip
			{
				CardType = EKurotatoCardType.Item,
				SelectId = id,
				IsConfigId = new bool?(true)
			}).ToList<KurotatoCardTip>();
			List<KurotatoCardTip> list = new List<KurotatoCardTip>();
			list.AddRange(collection);
			list.AddRange(collection2);
			List<int> list2 = new List<int>();
			list2.AddRange(kurotatoRoleData.InitWeaponIds);
			list2.AddRange(kurotatoRoleData.InitItemIds);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPopupWeaponDetailView, new KurotatoPopupItemDetailOpenParam
			{
				Index = list2.FindIndex((int id) => id == data.Id),
				CardData = list,
				IsOutSide = new bool?(true)
			}, null);
		}

		// Token: 0x0603AB99 RID: 240537 RVA: 0x00EE34D4 File Offset: 0x00EE16D4
		private CSharpScript.Game.Module.Kurotato.View.Components.KurotatoWeaponSmallItemGrid CreateItem()
		{
			CSharpScript.Game.Module.Kurotato.View.Components.KurotatoWeaponSmallItemGrid item = new CSharpScript.Game.Module.Kurotato.View.Components.KurotatoWeaponSmallItemGrid(false);
			item.BindCallback(delegate(IKurotatoSmallItemGridData data, EToggleState state, int gridIndex)
			{
				if (state != EToggleState.ETT_Checked)
				{
					return;
				}
				if (data.Id != 0)
				{
					this.OnWeaponToggleClickCallback(data);
				}
				item.GetItemGridExtendToggle().SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			});
			return item;
		}

		// Token: 0x0603AB9A RID: 240538 RVA: 0x00EE3517 File Offset: 0x00EE1717
		private void OnLockBtnClick()
		{
			this.OpenConditionViewAsync().Forget();
		}

		// Token: 0x0603AB9B RID: 240539 RVA: 0x00EE3524 File Offset: 0x00EE1724
		private UniTask OpenConditionViewAsync()
		{
			KurotatoHandBookRolePanel.<OpenConditionViewAsync>d__23 <OpenConditionViewAsync>d__;
			<OpenConditionViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenConditionViewAsync>d__.<>4__this = this;
			<OpenConditionViewAsync>d__.<>1__state = -1;
			<OpenConditionViewAsync>d__.<>t__builder.Start<KurotatoHandBookRolePanel.<OpenConditionViewAsync>d__23>(ref <OpenConditionViewAsync>d__);
			return <OpenConditionViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04021347 RID: 136007
		private const int INIT_WEAPON_MAX_NUM = 4;

		// Token: 0x04021348 RID: 136008
		private KurotatoActivityData KurotatoActivityData;

		// Token: 0x04021349 RID: 136009
		[Nullable(2)]
		private KurotatoLevelSelectViewData LevelSelectViewData;

		// Token: 0x0402134A RID: 136010
		private int RoleId;

		// Token: 0x0402134B RID: 136011
		private List<int> RoleIdList = new List<int>();

		// Token: 0x0402134C RID: 136012
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoopScrollView<KurotatoRoleGridItem, int> RoleLoopScrollView;

		// Token: 0x0402134D RID: 136013
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CSharpScript.Game.Module.Kurotato.View.Components.KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData> WeaponLayout;

		// Token: 0x0402134E RID: 136014
		[Nullable(2)]
		private FunctionalPanelConditionLock LockPanel;

		// Token: 0x0402134F RID: 136015
		[Nullable(2)]
		public Action OnCloseView;

		// Token: 0x04021350 RID: 136016
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BABE RID: 47806
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04039A5A RID: 236122
			LoopScrollRole,
			// Token: 0x04039A5B RID: 236123
			ItemRole,
			// Token: 0x04039A5C RID: 236124
			SpineRole,
			// Token: 0x04039A5D RID: 236125
			TextRoleName,
			// Token: 0x04039A5E RID: 236126
			TextRoleDesc,
			// Token: 0x04039A5F RID: 236127
			LayoutWeapon,
			// Token: 0x04039A60 RID: 236128
			ItemWeapon,
			// Token: 0x04039A61 RID: 236129
			ItemGotoBtn,
			// Token: 0x04039A62 RID: 236130
			ItemContinueBtn,
			// Token: 0x04039A63 RID: 236131
			ItemLockPanel,
			// Token: 0x04039A64 RID: 236132
			BtnArchive,
			// Token: 0x04039A65 RID: 236133
			ItemRecordPanel,
			// Token: 0x04039A66 RID: 236134
			TextKillNum,
			// Token: 0x04039A67 RID: 236135
			TextureWaveLevel,
			// Token: 0x04039A68 RID: 236136
			ItemBtnPanel,
			// Token: 0x04039A69 RID: 236137
			TextWave = 18
		}
	}
}
