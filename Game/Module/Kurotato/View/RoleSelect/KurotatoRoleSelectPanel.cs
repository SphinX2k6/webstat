using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Kurotato.View.Components;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.RoleSelect
{
	// Token: 0x02005A88 RID: 23176
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoRoleSelectPanel : UiPanelBase
	{
		// Token: 0x0603AA38 RID: 240184 RVA: 0x00EDB0F8 File Offset: 0x00ED92F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 21;
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
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnArchiveBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AA39 RID: 240185 RVA: 0x00EDB420 File Offset: 0x00ED9620
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoRoleSelectPanel.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoRoleSelectPanel.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA3A RID: 240186 RVA: 0x00EDB463 File Offset: 0x00ED9663
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x0603AA3B RID: 240187 RVA: 0x00EDB478 File Offset: 0x00ED9678
		protected override void OnBeforeShow()
		{
			this.SeqPlayer.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x0603AA3C RID: 240188 RVA: 0x00EDB49F File Offset: 0x00ED969F
		protected override void OnBeforeHide()
		{
			this.SeqPlayer.StopPlayingSequence(false, false);
		}

		// Token: 0x0603AA3D RID: 240189 RVA: 0x00EDB4B0 File Offset: 0x00ED96B0
		protected override void OnAfterShow()
		{
			bool flag = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.LevelId).Value.LevelGroup == 3;
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, flag ? "KurotatoRoleSelectEndless" : "KurotatoRoleSelectTeach");
		}

		// Token: 0x0603AA3E RID: 240190 RVA: 0x00EDB500 File Offset: 0x00ED9700
		private UniTask RefreshView()
		{
			KurotatoRoleSelectPanel.<RefreshView>d__20 <RefreshView>d__;
			<RefreshView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshView>d__.<>4__this = this;
			<RefreshView>d__.<>1__state = -1;
			<RefreshView>d__.<>t__builder.Start<KurotatoRoleSelectPanel.<RefreshView>d__20>(ref <RefreshView>d__);
			return <RefreshView>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA3F RID: 240191 RVA: 0x00EDB544 File Offset: 0x00ED9744
		private void RefreshRecordPanel()
		{
			KurotatoRoleData kurotatoRoleData = this.KurotatoActivityData.GetKurotatoRoleData(this.RoleId);
			bool flag = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.LevelId).Value.LevelGroup == 3 && kurotatoRoleData.HasHistory;
			UUIItem item = base.GetItem(11);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (!flag)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), "PrefabTextItem_2694577864_Text", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), "Kurotato_Settle_TotalKills", Array.Empty<object>());
			UUIText text = base.GetText(12);
			if (text != null)
			{
				text.SetText(kurotatoRoleData.HistoryWave.ToString(), true);
			}
			UUIText text2 = base.GetText(18);
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

		// Token: 0x0603AA40 RID: 240192 RVA: 0x00EDB6C4 File Offset: 0x00ED98C4
		private IReadOnlyList<int> GetInitWeaponIds(KurotatoRoleData kurotatoRoleData)
		{
			KurotatoLevelCharacter? levelCharacterByRoleIdAndLevelId = ConfigBase<KurotatoConfig>.Instance.GetLevelCharacterByRoleIdAndLevelId(this.RoleId, this.LevelId);
			if (levelCharacterByRoleIdAndLevelId == null)
			{
				return kurotatoRoleData.InitWeaponIds;
			}
			return levelCharacterByRoleIdAndLevelId.Value.InitWeaponIdsIter().ToList<int>();
		}

		// Token: 0x0603AA41 RID: 240193 RVA: 0x00EDB70C File Offset: 0x00ED990C
		private IReadOnlyList<int> GetInitItemIds(KurotatoRoleData kurotatoRoleData)
		{
			KurotatoLevelCharacter? levelCharacterByRoleIdAndLevelId = ConfigBase<KurotatoConfig>.Instance.GetLevelCharacterByRoleIdAndLevelId(this.RoleId, this.LevelId);
			if (levelCharacterByRoleIdAndLevelId == null)
			{
				return kurotatoRoleData.InitItemIds;
			}
			List<int> list = new List<int>();
			foreach (int num in levelCharacterByRoleIdAndLevelId.Value.InitItemIdsIter())
			{
				KurotatoItem? itemConfigByItemId = ConfigBase<KurotatoConfig>.Instance.GetItemConfigByItemId(num);
				if (itemConfigByItemId != null && itemConfigByItemId.GetValueOrDefault().Type == 2)
				{
					list.Add(num);
				}
			}
			return list;
		}

		// Token: 0x0603AA42 RID: 240194 RVA: 0x00EDB7C4 File Offset: 0x00ED99C4
		private UniTask OnRoleToggleClickCallback(int roleId)
		{
			KurotatoRoleSelectPanel.<OnRoleToggleClickCallback>d__24 <OnRoleToggleClickCallback>d__;
			<OnRoleToggleClickCallback>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnRoleToggleClickCallback>d__.<>4__this = this;
			<OnRoleToggleClickCallback>d__.roleId = roleId;
			<OnRoleToggleClickCallback>d__.<>1__state = -1;
			<OnRoleToggleClickCallback>d__.<>t__builder.Start<KurotatoRoleSelectPanel.<OnRoleToggleClickCallback>d__24>(ref <OnRoleToggleClickCallback>d__);
			return <OnRoleToggleClickCallback>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA43 RID: 240195 RVA: 0x00EDB810 File Offset: 0x00ED9A10
		private KurotatoRoleGridItem CreateRoleItem()
		{
			KurotatoRoleGridItem kurotatoRoleGridItem = new KurotatoRoleGridItem();
			KurotatoLevel value = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.LevelId).Value;
			kurotatoRoleGridItem.LimitRoleList = new List<int>(value.CharactersIter());
			kurotatoRoleGridItem.RecommendRoleList = new List<int>(value.RecommendCharactersIter());
			kurotatoRoleGridItem.IsEndlessLevel = (value.LevelGroup == 3);
			kurotatoRoleGridItem.SetToggleClickCallback(delegate(int roleId)
			{
				this.SeqPlayer.PlayOrReplaySequenceByName("Switch", false, null);
				this.OnRoleToggleClickCallback(roleId).Forget();
			});
			return kurotatoRoleGridItem;
		}

		// Token: 0x0603AA44 RID: 240196 RVA: 0x00EDB884 File Offset: 0x00ED9A84
		private void OnWeaponToggleClickCallback(IKurotatoSmallItemGridData data)
		{
			KurotatoRoleData kurotatoRoleData = this.KurotatoActivityData.GetKurotatoRoleData(this.RoleId);
			IReadOnlyList<int> initWeaponIds = this.GetInitWeaponIds(kurotatoRoleData);
			IReadOnlyList<int> initItemIds = this.GetInitItemIds(kurotatoRoleData);
			List<KurotatoCardTip> list = new List<KurotatoCardTip>();
			foreach (int selectId in initWeaponIds)
			{
				list.Add(new KurotatoCardTip
				{
					CardType = EKurotatoCardType.Weapon,
					SelectId = selectId,
					IsConfigId = new bool?(true)
				});
			}
			List<KurotatoCardTip> list2 = new List<KurotatoCardTip>();
			foreach (int selectId2 in initItemIds)
			{
				list2.Add(new KurotatoCardTip
				{
					CardType = EKurotatoCardType.Item,
					SelectId = selectId2,
					IsConfigId = new bool?(true)
				});
			}
			List<KurotatoCardTip> list3 = new List<KurotatoCardTip>();
			list3.AddRange(list);
			list3.AddRange(list2);
			List<int> list4 = new List<int>();
			list4.AddRange(initWeaponIds);
			list4.AddRange(initItemIds);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPopupWeaponDetailView, new KurotatoPopupItemDetailOpenParam
			{
				Index = list4.FindIndex((int id) => id == data.Id),
				CardData = list3,
				IsOutSide = new bool?(true)
			}, null);
		}

		// Token: 0x0603AA45 RID: 240197 RVA: 0x00EDBA00 File Offset: 0x00ED9C00
		private KurotatoWeaponSmallItemGrid CreateWeapon()
		{
			KurotatoWeaponSmallItemGrid item = new KurotatoWeaponSmallItemGrid(false);
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

		// Token: 0x0603AA46 RID: 240198 RVA: 0x00EDBA44 File Offset: 0x00ED9C44
		private unsafe void OnArchiveBtnClick()
		{
			KurotatoRoleData kurotatoRoleData = this.KurotatoActivityData.GetKurotatoRoleData(this.RoleId);
			if (kurotatoRoleData.ArchivedData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Kurotato;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "点击存档按钮时角色无存档数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", this.RoleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			KurotatoSaveViewOpenParam kurotatoSaveViewOpenParam = new KurotatoSaveViewOpenParam();
			int num = 1;
			List<KurotatoInstInfo> list = new List<KurotatoInstInfo>(num);
			CollectionsMarshal.SetCount<KurotatoInstInfo>(list, num);
			Span<KurotatoInstInfo> span = CollectionsMarshal.AsSpan<KurotatoInstInfo>(list);
			int index = 0;
			*span[index] = kurotatoRoleData.ArchivedData;
			kurotatoSaveViewOpenParam.InstInfos = list;
			kurotatoSaveViewOpenParam.DefaultIndex = 0;
			KurotatoSaveViewOpenParam param = kurotatoSaveViewOpenParam;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoTabMainView, param, null);
		}

		// Token: 0x0603AA47 RID: 240199 RVA: 0x00EDBAEE File Offset: 0x00ED9CEE
		private void OnGotoBtnClick()
		{
			ControllerBase<KurotatoController>.Instance.RequestEnterInst(this.LevelId, this.RoleId, false);
		}

		// Token: 0x0603AA48 RID: 240200 RVA: 0x00EDBB07 File Offset: 0x00ED9D07
		private void OnContinueBtnClick()
		{
			ControllerBase<KurotatoController>.Instance.RequestEnterInst(this.LevelId, this.RoleId, true);
		}

		// Token: 0x0603AA49 RID: 240201 RVA: 0x00EDBB20 File Offset: 0x00ED9D20
		private void OnRestartBtnClick()
		{
			ControllerBase<KurotatoController>.Instance.RequestEnterInst(this.LevelId, this.RoleId, false);
		}

		// Token: 0x0603AA4A RID: 240202 RVA: 0x00EDBB3C File Offset: 0x00ED9D3C
		private void OnLockBtnClick()
		{
			int conditionId = this.KurotatoActivityData.GetKurotatoRoleData(this.RoleId).ConditionId;
			int[] groupConditionIds = ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(conditionId);
			List<IActivityConditionData> list = new List<IActivityConditionData>();
			foreach (int conditionId2 in groupConditionIds)
			{
				Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId2);
				int accessType = -1;
				if (conditionConfig.Value.AccessId > 0)
				{
					accessType = ConfigBase<GetWayConfig>.Instance.GetConfigById(conditionConfig.Value.AccessId).Value.SkipName;
				}
				list.Add(new ActivityConditionData
				{
					ConditionId = conditionId2,
					ConditionTextId = conditionConfig.Value.Description,
					IsFinished = ControllerBase<LevelGeneralController>.Instance.CheckCondition(conditionId2.ToString(), null, false, Array.Empty<object>()),
					AccessId = conditionConfig.Value.AccessId,
					AccessType = accessType
				});
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, new ConditionGroupData(conditionId, list, "", false), null);
		}

		// Token: 0x040212AD RID: 135853
		private const int INIT_WEAPON_MAX_NUM = 4;

		// Token: 0x040212AE RID: 135854
		private CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData KurotatoActivityData;

		// Token: 0x040212AF RID: 135855
		private int RoleId;

		// Token: 0x040212B0 RID: 135856
		private int LevelId;

		// Token: 0x040212B1 RID: 135857
		private List<int> RoleIdList = new List<int>();

		// Token: 0x040212B2 RID: 135858
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoopScrollView<KurotatoRoleGridItem, int> RoleLoopScrollView;

		// Token: 0x040212B3 RID: 135859
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData> WeaponLayout;

		// Token: 0x040212B4 RID: 135860
		[Nullable(2)]
		private ButtonItem GotoBtn;

		// Token: 0x040212B5 RID: 135861
		[Nullable(2)]
		private ButtonItem ContinueBtn;

		// Token: 0x040212B6 RID: 135862
		[Nullable(2)]
		private ButtonItem RestartBtn;

		// Token: 0x040212B7 RID: 135863
		[Nullable(2)]
		private FunctionalPanelConditionLock LockPanel;

		// Token: 0x040212B8 RID: 135864
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x040212B9 RID: 135865
		[Nullable(2)]
		public Action OnCloseView;

		// Token: 0x0200BA64 RID: 47716
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x040398CE RID: 235726
			LoopScrollRole,
			// Token: 0x040398CF RID: 235727
			ItemRole,
			// Token: 0x040398D0 RID: 235728
			SpineRole,
			// Token: 0x040398D1 RID: 235729
			TextRoleName,
			// Token: 0x040398D2 RID: 235730
			TextRoleDesc,
			// Token: 0x040398D3 RID: 235731
			LayoutWeapon,
			// Token: 0x040398D4 RID: 235732
			ItemWeapon,
			// Token: 0x040398D5 RID: 235733
			ItemGotoBtn,
			// Token: 0x040398D6 RID: 235734
			ItemContinueBtn,
			// Token: 0x040398D7 RID: 235735
			ItemLockPanel,
			// Token: 0x040398D8 RID: 235736
			BtnArchive,
			// Token: 0x040398D9 RID: 235737
			ItemRecordPanel,
			// Token: 0x040398DA RID: 235738
			TextWaveNum,
			// Token: 0x040398DB RID: 235739
			TextureWaveLevel,
			// Token: 0x040398DC RID: 235740
			ItemBtnPanel,
			// Token: 0x040398DD RID: 235741
			TextLevelName,
			// Token: 0x040398DE RID: 235742
			ItemLimitRolePanel,
			// Token: 0x040398DF RID: 235743
			ItemRestartBtn,
			// Token: 0x040398E0 RID: 235744
			TextKillNum,
			// Token: 0x040398E1 RID: 235745
			TextWaveTitle,
			// Token: 0x040398E2 RID: 235746
			TextKillTitle
		}
	}
}
