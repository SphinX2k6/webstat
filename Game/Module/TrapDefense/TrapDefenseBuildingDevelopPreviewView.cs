using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E62 RID: 20066
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopPreviewView : UiViewBase
	{
		// Token: 0x06033DD2 RID: 212434 RVA: 0x00CF962C File Offset: 0x00CF782C
		public TrapDefenseBuildingDevelopPreviewView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033DD3 RID: 212435 RVA: 0x00CF9640 File Offset: 0x00CF7840
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickedLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickedRight));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033DD4 RID: 212436 RVA: 0x00CF985C File Offset: 0x00CF7A5C
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBuildingDevelopPreviewView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBuildingDevelopPreviewView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033DD5 RID: 212437 RVA: 0x00CF989F File Offset: 0x00CF7A9F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseOnDevelopUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnLevelUp));
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseOnBranchUpdate, new Action(this.OnOrganNetUpdate));
		}

		// Token: 0x06033DD6 RID: 212438 RVA: 0x00CF98D9 File Offset: 0x00CF7AD9
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseOnDevelopUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnLevelUp));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseOnBranchUpdate, new Action(this.OnOrganNetUpdate));
		}

		// Token: 0x06033DD7 RID: 212439 RVA: 0x00CF9914 File Offset: 0x00CF7B14
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedClose));
			this.LevelLayout = new GenericLayout<TrapDefenseDevelopPreviewLevelPointItem, bool>(base.GetHorizontalLayout(5), new Func<TrapDefenseDevelopPreviewLevelPointItem>(this.CreateLevelPoint), null, false, true);
			this.ScrollView = new GenericScrollViewNew<TrapDefenseDevelopPreviewLevelInfoItem, ITrapDefenseDevelopPreviewLevelInfo>(base.GetScrollViewWithScrollbar(8), new Func<TrapDefenseDevelopPreviewLevelInfoItem>(this.CreateScrollItem), null, false, null);
		}

		// Token: 0x06033DD8 RID: 212440 RVA: 0x00CF998C File Offset: 0x00CF7B8C
		protected override void OnBeforeShow()
		{
			this.UpdateDetailPanel();
		}

		// Token: 0x06033DD9 RID: 212441 RVA: 0x00CF9994 File Offset: 0x00CF7B94
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.ScrollView = null;
			this.LevelLayout = null;
			this.BtnUpgrade = null;
		}

		// Token: 0x06033DDA RID: 212442 RVA: 0x00CF99B4 File Offset: 0x00CF7BB4
		protected void UpdateDetailPanel()
		{
			if (this.CurData == null)
			{
				return;
			}
			TrapDefenseBuildingTypeData developTabByData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetDevelopTabByData(this.CurData);
			if (developTabByData != null)
			{
				developTabByData.TempSelectedData = this.CurData;
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(this.CurData.GetIsUnlock());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.CurData.GetName(), Array.Empty<object>());
			base.SetTextureByPath(this.CurData.GetIconPath(), base.GetTexture(1), null, null);
			int level = this.CurData.GetLevel();
			UUIArtText artText = base.GetArtText(4);
			if (artText != null)
			{
				string text;
				if (level < 10)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
					defaultInterpolatedStringHandler.AppendLiteral("0");
					defaultInterpolatedStringHandler.AppendFormatted<int>(level);
					text = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(level);
					text = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				artText.SetText(text);
			}
			int maxLevel = this.CurData.GetMaxLevel();
			List<bool> list = new List<bool>();
			List<ITrapDefenseDevelopPreviewLevelInfo> list2 = new List<ITrapDefenseDevelopPreviewLevelInfo>();
			ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(this.CurData.Id);
			for (int i = 1; i <= maxLevel; i++)
			{
				list.Add(i <= level);
				ITrapDefenseMachineIdInfo info = new ITrapDefenseMachineIdInfo
				{
					MachineType = trapDefenseMachineIdInfo.MachineType,
					DataType = trapDefenseMachineIdInfo.DataType,
					Level = i,
					Branch = 0
				};
				int num = ModelBase<TrapDefenseModel>.Instance.ComposeMachineId(info);
				TrapDefenseDevelopPreviewLevelInfo item2 = new TrapDefenseDevelopPreviewLevelInfo
				{
					Id = ((i == level) ? this.CurData.Id : num),
					IsCurLevel = (i == level && this.CurData.GetIsUnlock())
				};
				list2.Add(item2);
			}
			this.LevelLayout.RefreshByData(list, null, true);
			this.ScrollView.RefreshByData(list2, delegate
			{
				UUIItem itemByIndex = this.ScrollView.GetItemByIndex(level - 1);
				this.ScrollView.ScrollTo(itemByIndex, false);
			}, true);
			this.CanLevelUp = this.BtnUpgrade.RefreshButton(this.CurData);
			Singleton<EventSystem>.Instance.Emit<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingPreviewSelectUpdate, this.CurData);
		}

		// Token: 0x06033DDB RID: 212443 RVA: 0x00CF9C0C File Offset: 0x00CF7E0C
		private void OnClickedLeft()
		{
			if (this.CurData == null)
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("SwitchL", false, null, false);
			}
			int num = this.ItemList.IndexOf(this.CurData);
			num--;
			if (num < 0)
			{
				num = this.ItemList.Count - 1;
			}
			this.CurData = this.ItemList[num];
			this.UpdateDetailPanel();
		}

		// Token: 0x06033DDC RID: 212444 RVA: 0x00CF9C98 File Offset: 0x00CF7E98
		private void OnClickedRight()
		{
			if (this.CurData == null)
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("SwitchR", false, null, false);
			}
			int num = this.ItemList.IndexOf(this.CurData);
			num++;
			if (num >= this.ItemList.Count)
			{
				num = 0;
			}
			this.CurData = this.ItemList[num];
			this.UpdateDetailPanel();
		}

		// Token: 0x06033DDD RID: 212445 RVA: 0x00CF9D20 File Offset: 0x00CF7F20
		private void OnClickedClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033DDE RID: 212446 RVA: 0x00CF9D29 File Offset: 0x00CF7F29
		private void OnClickedUpgrade()
		{
			if (this.CurData == null)
			{
				return;
			}
			if (!this.CanLevelUp)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TrapDefense_Develop_NoEnoughGold", Array.Empty<object>());
				return;
			}
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseDevelopLevelUp(this.CurData.Id);
		}

		// Token: 0x06033DDF RID: 212447 RVA: 0x00CF9D66 File Offset: 0x00CF7F66
		private void OnLevelUp(TrapDefenseBuildingDevelopItemData data)
		{
			if (data != this.CurData)
			{
				return;
			}
			this.UpdateDetailPanel();
		}

		// Token: 0x06033DE0 RID: 212448 RVA: 0x00CF9D78 File Offset: 0x00CF7F78
		private void OnOrganNetUpdate()
		{
			this.CanLevelUp = this.BtnUpgrade.RefreshButton(this.CurData);
		}

		// Token: 0x06033DE1 RID: 212449 RVA: 0x00CF9D91 File Offset: 0x00CF7F91
		private TrapDefenseDevelopPreviewLevelPointItem CreateLevelPoint()
		{
			return new TrapDefenseDevelopPreviewLevelPointItem();
		}

		// Token: 0x06033DE2 RID: 212450 RVA: 0x00CF9D98 File Offset: 0x00CF7F98
		private TrapDefenseDevelopPreviewLevelInfoItem CreateScrollItem()
		{
			return new TrapDefenseDevelopPreviewLevelInfoItem();
		}

		// Token: 0x06033DE3 RID: 212451 RVA: 0x00CF9DA0 File Offset: 0x00CF7FA0
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "MachineUpgradePreview")
			{
				if (configParams.Length < 2)
				{
					return null;
				}
				int num;
				if (!int.TryParse(configParams[1], out num))
				{
					return null;
				}
				if (num >= 0)
				{
					int num2 = num;
					GenericScrollViewNew<TrapDefenseDevelopPreviewLevelInfoItem, ITrapDefenseDevelopPreviewLevelInfo> scrollView = this.ScrollView;
					int? num3;
					if (scrollView == null)
					{
						num3 = null;
					}
					else
					{
						GenericLayout<TrapDefenseDevelopPreviewLevelInfoItem, ITrapDefenseDevelopPreviewLevelInfo> genericLayout = scrollView.GetGenericLayout();
						num3 = ((genericLayout != null) ? new int?(genericLayout.GetDatas().Count) : null);
					}
					int? num4 = num3;
					if (num2 < num4.GetValueOrDefault())
					{
						GenericScrollViewNew<TrapDefenseDevelopPreviewLevelInfoItem, ITrapDefenseDevelopPreviewLevelInfo> scrollView2 = this.ScrollView;
						UUIItem uuiitem = (scrollView2 != null) ? scrollView2.GetItemByIndex(num) : null;
						if (uuiitem != null)
						{
							GenericScrollViewNew<TrapDefenseDevelopPreviewLevelInfoItem, ITrapDefenseDevelopPreviewLevelInfo> scrollView3 = this.ScrollView;
							if (scrollView3 != null)
							{
								scrollView3.ScrollTo(uuiitem, false);
							}
							return new UUIItem[]
							{
								uuiitem,
								uuiitem
							};
						}
						goto IL_B0;
					}
				}
				return null;
			}
			IL_B0:
			return null;
		}

		// Token: 0x0401DFFA RID: 122874
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0401DFFB RID: 122875
		protected GenericScrollViewNew<TrapDefenseDevelopPreviewLevelInfoItem, ITrapDefenseDevelopPreviewLevelInfo> ScrollView;

		// Token: 0x0401DFFC RID: 122876
		protected GenericLayout<TrapDefenseDevelopPreviewLevelPointItem, bool> LevelLayout;

		// Token: 0x0401DFFD RID: 122877
		protected TrapDefenseBuildingUpgradeItem BtnUpgrade;

		// Token: 0x0401DFFE RID: 122878
		protected List<TrapDefenseBuildingDevelopItemData> ItemList = new List<TrapDefenseBuildingDevelopItemData>();

		// Token: 0x0401DFFF RID: 122879
		protected TrapDefenseBuildingDevelopItemData CurData;

		// Token: 0x0401E000 RID: 122880
		protected bool CanLevelUp;

		// Token: 0x0401E001 RID: 122881
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200AE15 RID: 44565
		[NullableContext(0)]
		internal class EMainDefine
		{
			// Token: 0x040360FF RID: 221439
			public const int CaptionItem = 0;

			// Token: 0x04036100 RID: 221440
			public const int TexIcon = 1;

			// Token: 0x04036101 RID: 221441
			public const int TxtTitle = 2;

			// Token: 0x04036102 RID: 221442
			public const int PanelLayout = 3;

			// Token: 0x04036103 RID: 221443
			public const int ArtTxtLevel = 4;

			// Token: 0x04036104 RID: 221444
			public const int LevelLayout = 5;

			// Token: 0x04036105 RID: 221445
			public const int LevelPoint = 6;

			// Token: 0x04036106 RID: 221446
			public const int BtnUpgrade = 7;

			// Token: 0x04036107 RID: 221447
			public const int ScrollView = 8;

			// Token: 0x04036108 RID: 221448
			public const int InfoItem = 9;

			// Token: 0x04036109 RID: 221449
			public const int BtnLeft = 10;

			// Token: 0x0403610A RID: 221450
			public const int BtnRight = 11;
		}
	}
}
