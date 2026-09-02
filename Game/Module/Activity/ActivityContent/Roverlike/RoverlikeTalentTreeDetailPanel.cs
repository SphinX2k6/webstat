using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006468 RID: 25704
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeTalentTreeDetailPanel : UiPanelBase
	{
		// Token: 0x17009E42 RID: 40514
		// (get) Token: 0x060407A0 RID: 264096 RVA: 0x01085648 File Offset: 0x01083848
		private RoverlikeTalentTreeData TreeData
		{
			get
			{
				RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
				if (currentActivityData == null)
				{
					return null;
				}
				return currentActivityData.TalentTreeData;
			}
		}

		// Token: 0x060407A1 RID: 264097 RVA: 0x01085660 File Offset: 0x01083860
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickBtnUpgrade));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060407A2 RID: 264098 RVA: 0x01085900 File Offset: 0x01083B00
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeTalentTreeDetailPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeTalentTreeDetailPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060407A3 RID: 264099 RVA: 0x01085944 File Offset: 0x01083B44
		[NullableContext(1)]
		public void Refresh(RoverlikeTalentNodeData data)
		{
			this.Data = data;
			RoverlikeTalentTreeData treeData = this.TreeData;
			if (treeData == null)
			{
				return;
			}
			RoverRogueTalentTree headConfig = data.HeadConfig;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), headConfig.Name, Array.Empty<object>());
			UUIText text = base.GetText(14);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.CurLevel);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.MaxLevel);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			int column = headConfig.Column;
			string textStringId;
			string hexStr;
			if (column <= 2)
			{
				textStringId = "RoverRogue_TalentTree_TypeLeft";
				hexStr = "57a2b6";
			}
			else if (column <= 4)
			{
				textStringId = "RoverRogue_TalentTree_TypeMiddle";
				hexStr = "bd655c";
			}
			else
			{
				textStringId = "RoverRogue_TalentTree_TypeRight";
				hexStr = "5d4ac0";
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(16), textStringId, Array.Empty<object>());
			UUISprite sprite = base.GetSprite(15);
			if (sprite != null)
			{
				sprite.SetColor(FColor.FromHex(hexStr));
			}
			RoverRogueTalentTree? roverRogueTalentTree;
			string text2 = ((data.CurrentLevelConfig != null) ? roverRogueTalentTree.GetValueOrDefault().Icon : null) ?? headConfig.Icon;
			bool flag = text2.Contains("Atlas");
			UUITexture texture = base.GetTexture(13);
			texture.SetUIActive(!flag);
			UUISprite sprite2 = base.GetSprite(1);
			sprite2.SetUIActive(flag);
			if (flag)
			{
				this.SetSpriteByPath(text2, sprite2, false, null, null);
			}
			else
			{
				base.SetTextureByPath(text2, texture, null, null);
			}
			bool flag2 = data.CurLevel > 0;
			base.GetItem(2).SetUIActive(flag2);
			if (flag2)
			{
				RoverlikeTalentTreeLevelDescItem curLevelItem = this.CurLevelItem;
				if (curLevelItem != null)
				{
					curLevelItem.SetContent(data.CurLevel, data.CurrentDescTextId, data.CurrentDescParams);
				}
			}
			bool flag3 = !data.IsMaxLevel;
			base.GetItem(3).SetUIActive(flag3);
			if (flag3)
			{
				RoverlikeTalentTreeLevelDescItem nextLevelItem = this.NextLevelItem;
				if (nextLevelItem != null)
				{
					nextLevelItem.SetTitle((data.CurLevel > 0) ? "PrefabTextItem_124464148_Text" : "RoverRogue_TalentTreeUnlockShow");
				}
				RoverlikeTalentTreeLevelDescItem nextLevelItem2 = this.NextLevelItem;
				if (nextLevelItem2 != null)
				{
					nextLevelItem2.SetContent(data.CurLevel + 1, data.NextLevelDescTextId, data.NextLevelDescParams);
				}
			}
			int nextLevelCost = data.NextLevelCost;
			bool flag4 = treeData.GetTalentCoinNum() >= nextLevelCost;
			UUIText text3 = base.GetText(4);
			text3.SetText(nextLevelCost.ToString(), true);
			UUIItem uuiitem = text3;
			bool bUseChangeColor = !flag4;
			FColor? fcolor = new FColor?(text3.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.SetItemIcon(base.GetTexture(8), treeData.TalentPointItemId, null, null);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), "RoverRogue_TalentTree_Activate", Array.Empty<object>());
			this.RefreshStatePanels(data, treeData);
		}

		// Token: 0x060407A4 RID: 264100 RVA: 0x01085C0C File Offset: 0x01083E0C
		[NullableContext(1)]
		private void RefreshStatePanels(RoverlikeTalentNodeData data, RoverlikeTalentTreeData treeData)
		{
			ERoverlikeTalentNodeState state = data.State;
			bool isServerUnlocked = data.IsServerUnlocked;
			if (state == ERoverlikeTalentNodeState.Lock && !isServerUnlocked)
			{
				this.SetCostActive(false);
				UUIItem uuiitem = base.GetButton(5).RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(false);
				}
				base.GetItem(10).SetUIActive(true);
				base.GetItem(9).SetUIActive(false);
				return;
			}
			if (state == ERoverlikeTalentNodeState.Lock)
			{
				this.SetCostActive(true);
				UUIItem uuiitem2 = base.GetButton(5).RootUIComp.Get();
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(true);
				}
				base.GetItem(10).SetUIActive(false);
				base.GetItem(9).SetUIActive(false);
				return;
			}
			if (state == ERoverlikeTalentNodeState.Unlock)
			{
				this.SetCostActive(true);
				UUIItem uuiitem3 = base.GetButton(5).RootUIComp.Get();
				if (uuiitem3 != null)
				{
					uuiitem3.SetUIActive(true);
				}
				base.GetItem(10).SetUIActive(false);
				base.GetItem(9).SetUIActive(false);
				return;
			}
			this.SetCostActive(false);
			UUIItem uuiitem4 = base.GetButton(5).RootUIComp.Get();
			if (uuiitem4 != null)
			{
				uuiitem4.SetUIActive(false);
			}
			base.GetItem(10).SetUIActive(false);
			base.GetItem(9).SetUIActive(true);
		}

		// Token: 0x060407A5 RID: 264101 RVA: 0x01085D43 File Offset: 0x01083F43
		private void SetCostActive(bool isActive)
		{
			base.GetItem(12).SetUIActive(isActive);
			base.GetItem(7).SetUIActive(isActive);
		}

		// Token: 0x060407A6 RID: 264102 RVA: 0x01085D60 File Offset: 0x01083F60
		private void OnClickBtnUpgrade()
		{
			RoverlikeTalentNodeData data = this.Data;
			RoverlikeTalentTreeData treeData = this.TreeData;
			if (data == null || treeData == null)
			{
				return;
			}
			if (!treeData.IsTalentCanUnlock(data))
			{
				if (data.IsServerUnlocked && !data.IsMaxLevel && treeData.GetTalentCoinNum() < data.NextLevelCost)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoverRogue_InsufficientTalent", Array.Empty<object>());
				}
				return;
			}
			string nextDescTextId = data.NextLevelDescTextId;
			List<string> nextDescParams = data.NextLevelDescParams;
			ControllerBase<RoverlikeController>.Instance.RequestUnlockTalentNode(data.HeadConfig.Id, delegate
			{
				this.Refresh(data);
				Action<RoverlikeTalentNodeData> onUnlockSuccess = this.OnUnlockSuccess;
				if (onUnlockSuccess != null)
				{
					onUnlockSuccess(data);
				}
				RoverlikeTalentUnlockViewParam param = new RoverlikeTalentUnlockViewParam
				{
					DescTextId = nextDescTextId,
					DescParams = new List<string>(nextDescParams)
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeTalentTreeUnlockView, param, null);
			});
		}

		// Token: 0x0402418E RID: 147854
		private RoverlikeTalentNodeData Data;

		// Token: 0x0402418F RID: 147855
		private RoverlikeTalentTreeLevelDescItem CurLevelItem;

		// Token: 0x04024190 RID: 147856
		private RoverlikeTalentTreeLevelDescItem NextLevelItem;

		// Token: 0x04024191 RID: 147857
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoverlikeTalentNodeData> OnUnlockSuccess;

		// Token: 0x0200C4BD RID: 50365
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403C8E2 RID: 248034
			public const int TxtName = 0;

			// Token: 0x0403C8E3 RID: 248035
			public const int SprIcon = 1;

			// Token: 0x0403C8E4 RID: 248036
			public const int PnlCurLevel = 2;

			// Token: 0x0403C8E5 RID: 248037
			public const int PnlNextLevel = 3;

			// Token: 0x0403C8E6 RID: 248038
			public const int TxtCost = 4;

			// Token: 0x0403C8E7 RID: 248039
			public const int BtnUpgrade = 5;

			// Token: 0x0403C8E8 RID: 248040
			public const int TxtConfirm = 6;

			// Token: 0x0403C8E9 RID: 248041
			public const int PnlCostNor = 7;

			// Token: 0x0403C8EA RID: 248042
			public const int TexCostIcon = 8;

			// Token: 0x0403C8EB RID: 248043
			public const int PnlMaxLevel = 9;

			// Token: 0x0403C8EC RID: 248044
			public const int PnlActivateCondition = 10;

			// Token: 0x0403C8ED RID: 248045
			public const int TxtActivateCondition = 11;

			// Token: 0x0403C8EE RID: 248046
			public const int PnlCost = 12;

			// Token: 0x0403C8EF RID: 248047
			public const int TexIcon = 13;

			// Token: 0x0403C8F0 RID: 248048
			public const int TxtNameLevel = 14;

			// Token: 0x0403C8F1 RID: 248049
			public const int SprType = 15;

			// Token: 0x0403C8F2 RID: 248050
			public const int TxtType = 16;
		}
	}
}
