using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView.VisionSubView
{
	// Token: 0x0200506C RID: 20588
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleVisionDragHeadItem : RoleVisionCommonItem
	{
		// Token: 0x060350A7 RID: 217255 RVA: 0x00D4D354 File Offset: 0x00D4B554
		[NullableContext(1)]
		public RoleVisionDragHeadItem(UUIItem uiItem, EPhantomItemIndex index, [Nullable(2)] RoleDataBase roleData, bool needRedDot = false, bool needShowOccupyDetail = false, ERoleViewSource source = ERoleViewSource.Normal) : base(uiItem, index, roleData, needRedDot, needShowOccupyDetail, source)
		{
		}

		// Token: 0x060350A8 RID: 217256 RVA: 0x00D4D377 File Offset: 0x00D4B577
		protected override UUIItem GetPlusItem()
		{
			return base.GetItem(6);
		}

		// Token: 0x060350A9 RID: 217257 RVA: 0x00D4D380 File Offset: 0x00D4B580
		protected override UUITexture GetVisionTextureComponent()
		{
			return base.GetTexture(2);
		}

		// Token: 0x060350AA RID: 217258 RVA: 0x00D4D389 File Offset: 0x00D4B589
		protected override UUISprite GetVisionQualitySprite()
		{
			return base.GetSprite(3);
		}

		// Token: 0x060350AB RID: 217259 RVA: 0x00D4D392 File Offset: 0x00D4B592
		protected override UUIText GetVisionCostText()
		{
			return base.GetText(5);
		}

		// Token: 0x060350AC RID: 217260 RVA: 0x00D4D39B File Offset: 0x00D4B59B
		protected override UUIItem GetVisionCostItem()
		{
			return base.GetItem(4);
		}

		// Token: 0x060350AD RID: 217261 RVA: 0x00D4D3A4 File Offset: 0x00D4B5A4
		public override UUIDraggableComponent GetDragComponent()
		{
			return base.GetDraggable(1);
		}

		// Token: 0x060350AE RID: 217262 RVA: 0x00D4D3AD File Offset: 0x00D4B5AD
		protected override UUIExtendToggle GetSelectToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x060350AF RID: 217263 RVA: 0x00D4D3B8 File Offset: 0x00D4B5B8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIText)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, base.OnClickVision)
			};
		}

		// Token: 0x060350B0 RID: 217264 RVA: 0x00D4D584 File Offset: 0x00D4B784
		protected override UniTask OnBeforeStartAsync()
		{
			RoleVisionDragHeadItem.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleVisionDragHeadItem.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060350B1 RID: 217265 RVA: 0x00D4D5C7 File Offset: 0x00D4B7C7
		public override void SetAniLightState(bool state)
		{
			base.GetItem(11).SetUIActive(state);
		}

		// Token: 0x060350B2 RID: 217266 RVA: 0x00D4D5D7 File Offset: 0x00D4B7D7
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetItem(8).SetUIActive(false);
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}

		// Token: 0x060350B3 RID: 217267 RVA: 0x00D4D614 File Offset: 0x00D4B814
		[NullableContext(1)]
		protected void OnSetClickCallBack(Action<int> onFunction)
		{
			this.ClickFunction = onFunction;
		}

		// Token: 0x060350B4 RID: 217268 RVA: 0x00D4D61D File Offset: 0x00D4B81D
		protected override void OnDragBegin()
		{
			this.VisionFetterSuitItem.GetRootItem().SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.RefreshAddItemItem(true);
		}

		// Token: 0x060350B5 RID: 217269 RVA: 0x00D4D658 File Offset: 0x00D4B858
		protected override void OnDragEnd()
		{
			this.CheckAnimationStateAndDataSetElementActiveState();
			this.RefreshAddItemItem(this.CurrentData == null);
		}

		// Token: 0x060350B6 RID: 217270 RVA: 0x00D4D670 File Offset: 0x00D4B870
		protected override void OnUpdateItem(PhantomDataBase data)
		{
			if (data != null)
			{
				base.GetText(5).SetText(data.GetCost().ToString(), true);
				PhantomFetterGroup fetterGroupConfig = data.GetFetterGroupConfig();
				this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupConfig));
			}
			this.CheckAnimationStateAndDataSetElementActiveState();
			this.RefreshCircleBgSprite(data);
			this.RefreshCircleBlackBg(data);
			this.UnBindRedDot();
			this.BindRedDot(data);
			this.RefreshAddItemItem(data == null);
			this.RefreshLevelText(data);
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.RefreshWarning(data);
		}

		// Token: 0x060350B7 RID: 217271 RVA: 0x00D4D700 File Offset: 0x00D4B900
		private void RefreshLevelText(PhantomDataBase data)
		{
			if (data == null || !this.NeedLevelShowState)
			{
				return;
			}
			int phantomLevel = data.GetPhantomLevel();
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIText text = base.GetText(15);
			if (text == null)
			{
				return;
			}
			text.SetText("+" + phantomLevel.ToString(), true);
		}

		// Token: 0x060350B8 RID: 217272 RVA: 0x00D4D758 File Offset: 0x00D4B958
		private void RefreshAddItemItem(bool state)
		{
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(state);
			}
			UUIItem item2 = base.GetItem(13);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(state);
		}

		// Token: 0x060350B9 RID: 217273 RVA: 0x00D4D781 File Offset: 0x00D4B981
		private void RefreshCircleBlackBg(PhantomDataBase data)
		{
			base.GetItem(9).SetUIActive(data != null);
		}

		// Token: 0x060350BA RID: 217274 RVA: 0x00D4D794 File Offset: 0x00D4B994
		private void CheckAnimationStateAndDataSetElementActiveState()
		{
			if (!this.AnimationState && this.CurrentData != null)
			{
				base.GetItem(4).SetUIActive(true);
				this.VisionFetterSuitItem.GetRootItem().SetUIActive(true);
				if (this.NeedLevelShowState)
				{
					UUIItem item = base.GetItem(14);
					if (item == null)
					{
						return;
					}
					item.SetUIActive(true);
					return;
				}
			}
			else
			{
				this.VisionFetterSuitItem.GetRootItem().SetUIActive(false);
				base.GetItem(4).SetUIActive(false);
				UUIItem item2 = base.GetItem(14);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
			}
		}

		// Token: 0x060350BB RID: 217275 RVA: 0x00D4D81C File Offset: 0x00D4BA1C
		protected override void OnScrollToScrollViewEvent()
		{
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			this.RefreshAddItemItem(false);
		}

		// Token: 0x060350BC RID: 217276 RVA: 0x00D4D839 File Offset: 0x00D4BA39
		protected override void OnRemoveFromScrollViewEvent()
		{
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.RefreshAddItemItem(true);
		}

		// Token: 0x060350BD RID: 217277 RVA: 0x00D4D856 File Offset: 0x00D4BA56
		protected override void OnChangeAnimationState()
		{
			this.CheckAnimationStateAndDataSetElementActiveState();
		}

		// Token: 0x060350BE RID: 217278 RVA: 0x00D4D85E File Offset: 0x00D4BA5E
		protected override void OnItemOverlay()
		{
			base.PlaySequence("HighLight");
		}

		// Token: 0x060350BF RID: 217279 RVA: 0x00D4D86B File Offset: 0x00D4BA6B
		protected override void OnItemUnOverlay()
		{
			base.PlaySequence("Normal");
		}

		// Token: 0x060350C0 RID: 217280 RVA: 0x00D4D878 File Offset: 0x00D4BA78
		[NullableContext(1)]
		protected override void OnPlaySequence(string sequence)
		{
			if (this.CurrentSequence != sequence)
			{
				this.CurrentSequence = sequence;
				this.LevelSequencePlayer.PlaySequencePurely(sequence, false, false, null, null, false);
			}
		}

		// Token: 0x060350C1 RID: 217281 RVA: 0x00D4D8B4 File Offset: 0x00D4BAB4
		private void BindRedDot(PhantomDataBase data)
		{
			if (this.RoleData == null)
			{
				UUIItem item = base.GetItem(8);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else if (this.RoleData.IsTrialRole())
			{
				UUIItem item2 = base.GetItem(8);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
			else
			{
				if (!this.RedDotBindState && this.NeedRedDot && data == null)
				{
					this.RedDotBindState = true;
					ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.VisionGridRedDot, base.GetItem(8), null, this.RoleData.GetRoleId());
					this.RedDotType = 0;
					this.CurrentRoleData = this.RoleData;
					return;
				}
				if (!this.RedDotBindState && this.NeedRedDot && data != null)
				{
					this.RedDotBindState = true;
					int incrId = data.GetIncrId();
					ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.VisionIdentifyTab, base.GetItem(8), null, incrId);
					this.RedDotType = 1;
					this.CurrentRedDotBindData = data;
				}
				return;
			}
		}

		// Token: 0x060350C2 RID: 217282 RVA: 0x00D4D990 File Offset: 0x00D4BB90
		private void UnBindRedDot()
		{
			if (this.RedDotBindState)
			{
				this.RedDotBindState = false;
				if (this.RedDotType == 0)
				{
					ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.VisionGridRedDot, base.GetItem(8), this.CurrentRoleData.GetRoleId());
					return;
				}
				RedDotController instance = ControllerBase<RedDotController>.Instance;
				ERedDotName name = ERedDotName.VisionIdentifyTab;
				UUIItem item = base.GetItem(8);
				PhantomDataBase currentRedDotBindData = this.CurrentRedDotBindData;
				instance.UnBindGivenUi(name, item, (currentRedDotBindData != null) ? currentRedDotBindData.GetIncrId() : 0);
			}
		}

		// Token: 0x060350C3 RID: 217283 RVA: 0x00D4D9F8 File Offset: 0x00D4BBF8
		private void RefreshCircleBgSprite(PhantomDataBase data)
		{
			if (data != null)
			{
				int quality = data.GetQuality();
				string phantomQualityBgSprite = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(quality);
				this.SetSpriteByPath(phantomQualityBgSprite, base.GetSprite(3), false, null, null);
				return;
			}
			string phantomQualityBgSprite2 = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(0);
			this.SetSpriteByPath(phantomQualityBgSprite2, base.GetSprite(3), false, null, null);
		}

		// Token: 0x060350C4 RID: 217284 RVA: 0x00D4DA5C File Offset: 0x00D4BC5C
		private void RefreshWarning(PhantomDataBase data)
		{
			RoleDataBase roleData = this.RoleData;
			int? num = (roleData != null) ? new int?(roleData.GetRoleId()) : null;
			if (data != null && num != null && this.Source == ERoleViewSource.WheelTower)
			{
				int incrId = data.GetIncrId();
				EnergyInfo selectedEnergyInfo = ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo;
				bool flag = !selectedEnergyInfo.GetPhantomCanUse(incrId, num.Value);
				if (flag)
				{
					int phantomOccupyRoleId = selectedEnergyInfo.GetPhantomOccupyRoleId(incrId, num.Value);
					Aki.Config.RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(phantomOccupyRoleId);
					CommonWarningItem warningItem = this.WarningItem;
					if (warningItem != null)
					{
						warningItem.SetWarningIcon(roleConfig.Value.Card);
					}
					CommonWarningItem warningItem2 = this.WarningItem;
					if (warningItem2 != null)
					{
						warningItem2.SetLocalTextNew("WheelTower_Occupy_Tip", Array.Empty<object>());
					}
				}
				CommonWarningItem warningItem3 = this.WarningItem;
				if (warningItem3 != null)
				{
					warningItem3.SetUiActive(flag && this.NeedShowOccupyDetail);
				}
				UUIItem item = base.GetItem(17);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(flag && !this.NeedShowOccupyDetail);
				return;
			}
			else
			{
				CommonWarningItem warningItem4 = this.WarningItem;
				if (warningItem4 != null)
				{
					warningItem4.SetUiActive(false);
				}
				UUIItem item2 = base.GetItem(17);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x060350C5 RID: 217285 RVA: 0x00D4DB90 File Offset: 0x00D4BD90
		protected override void OnResetPosition()
		{
			UUIDraggableComponent dragComponent = this.GetDragComponent();
			if (dragComponent != null)
			{
				dragComponent.RootUIComp.Get().SetAsLastHierarchy();
			}
			if (this.CurrentSequence == "HighLight")
			{
				base.PlaySequence("Normal");
				this.LevelSequencePlayer.StopCurrentSequence(false, true);
			}
			else
			{
				this.CurrentSequence = "Normal";
			}
			this.AnimationState = false;
			this.CheckAnimationStateAndDataSetElementActiveState();
		}

		// Token: 0x060350C6 RID: 217286 RVA: 0x00D4DBFF File Offset: 0x00D4BDFF
		protected override void OnBeforeClearComponent()
		{
			this.UnBindRedDot();
		}

		// Token: 0x060350C7 RID: 217287 RVA: 0x00D4DC07 File Offset: 0x00D4BE07
		private bool CanExecuteChange()
		{
			return false;
		}

		// Token: 0x060350C8 RID: 217288 RVA: 0x00D4DC0A File Offset: 0x00D4BE0A
		public void SetLevelItemShowState(bool state)
		{
			this.NeedLevelShowState = state;
		}

		// Token: 0x0401E8A8 RID: 125096
		protected Action<int> ClickFunction;

		// Token: 0x0401E8A9 RID: 125097
		private VisionFetterSuitItem VisionFetterSuitItem;

		// Token: 0x0401E8AA RID: 125098
		private CommonWarningItem WarningItem;

		// Token: 0x0401E8AB RID: 125099
		private bool RedDotBindState;

		// Token: 0x0401E8AC RID: 125100
		private int RedDotType;

		// Token: 0x0401E8AD RID: 125101
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401E8AE RID: 125102
		[Nullable(1)]
		private string CurrentSequence = "";

		// Token: 0x0401E8AF RID: 125103
		private PhantomDataBase CurrentRedDotBindData;

		// Token: 0x0401E8B0 RID: 125104
		private RoleDataBase CurrentRoleData;

		// Token: 0x0401E8B1 RID: 125105
		private bool NeedLevelShowState = true;

		// Token: 0x0200B020 RID: 45088
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04036A26 RID: 223782
			ToggleItem,
			// Token: 0x04036A27 RID: 223783
			CircleItem,
			// Token: 0x04036A28 RID: 223784
			CircleItemTexture,
			// Token: 0x04036A29 RID: 223785
			QualitySprite,
			// Token: 0x04036A2A RID: 223786
			CostItem,
			// Token: 0x04036A2B RID: 223787
			CostNumText,
			// Token: 0x04036A2C RID: 223788
			PlusItem,
			// Token: 0x04036A2D RID: 223789
			SuitElementItem,
			// Token: 0x04036A2E RID: 223790
			RedItem,
			// Token: 0x04036A2F RID: 223791
			CircleTextureBlackBg,
			// Token: 0x04036A30 RID: 223792
			AddIconItem,
			// Token: 0x04036A31 RID: 223793
			AniLight,
			// Token: 0x04036A32 RID: 223794
			RemoveItem,
			// Token: 0x04036A33 RID: 223795
			AddIconItem2,
			// Token: 0x04036A34 RID: 223796
			LevelItem,
			// Token: 0x04036A35 RID: 223797
			LevelText,
			// Token: 0x04036A36 RID: 223798
			ItemOccupyPanel,
			// Token: 0x04036A37 RID: 223799
			ItemWarningIcon
		}
	}
}
