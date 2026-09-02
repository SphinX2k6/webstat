using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E32 RID: 20018
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class TrapDefenseLevelTabPanel<[Nullable(0)] TLevelModeData> : UiPanelBase where TLevelModeData : ITrapDefenseLevelModeData<TrapDefenseLevelModeDataBase>
	{
		// Token: 0x06033BF2 RID: 211954 RVA: 0x00CEF7EC File Offset: 0x00CED9EC
		public UniTask Init(UUIItem item)
		{
			TrapDefenseLevelTabPanel<TLevelModeData>.<Init>d__7 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseLevelTabPanel<TLevelModeData>.<Init>d__7>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033BF3 RID: 211955 RVA: 0x00CEF838 File Offset: 0x00CEDA38
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIArtText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnBdSum));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033BF4 RID: 211956 RVA: 0x00CEF964 File Offset: 0x00CEDB64
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseLevelTabPanel<TLevelModeData>.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseLevelTabPanel<TLevelModeData>.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033BF5 RID: 211957 RVA: 0x00CEF9A8 File Offset: 0x00CEDBA8
		public void OnClickBtnBdSum()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewBdSum(new bool?(this.IsInstance), new ETrapDefenseBdTabType?(ETrapDefenseBdTabType.BdProgress), null);
		}

		// Token: 0x06033BF6 RID: 211958 RVA: 0x00CEF9D9 File Offset: 0x00CEDBD9
		public TrapDefenseLevelItem CreateItemLevel()
		{
			return new TrapDefenseLevelItem
			{
				OnSelectLevelCallBack = new Action<TrapDefenseLevelItem>(this.SelectLevelItem)
			};
		}

		// Token: 0x06033BF7 RID: 211959 RVA: 0x00CEF9F4 File Offset: 0x00CEDBF4
		public void SelectLevelItem(TrapDefenseLevelItem item)
		{
			TrapDefenseLevelData itemData = item.ItemData;
			this.CurSelectLevel = itemData;
			Action<TrapDefenseLevelData> onSelectLevelCallback = this.OnSelectLevelCallback;
			if (onSelectLevelCallback == null)
			{
				return;
			}
			onSelectLevelCallback(itemData);
		}

		// Token: 0x06033BF8 RID: 211960 RVA: 0x00CEFA20 File Offset: 0x00CEDC20
		public void InitSelectLevel(TrapDefenseLevelData data)
		{
			this.CurSelectLevel = data;
		}

		// Token: 0x06033BF9 RID: 211961 RVA: 0x00CEFA2C File Offset: 0x00CEDC2C
		public void UpdateLevelDataList(TrapDefenseLevelData[] list)
		{
			int selectIndex = this.UpdateSelectIndex(list);
			this.CurSelectLevel = ((selectIndex >= 0 && selectIndex < list.Length) ? list[selectIndex] : null);
			this.ScrollLevel.SelectGridProxy(-1, false);
			this.ScrollLevel.RefreshByData(list, delegate
			{
				this.ScrollLevel.SelectGridProxy(selectIndex, false);
				UUIItem itemByIndex = this.ScrollLevel.GetItemByIndex(selectIndex);
				if (itemByIndex != null)
				{
					this.ScrollLevel.ScrollTo(itemByIndex, false);
				}
			}, true);
		}

		// Token: 0x06033BFA RID: 211962 RVA: 0x00CEFAA0 File Offset: 0x00CEDCA0
		private int UpdateSelectIndex(TrapDefenseLevelData[] list)
		{
			int num = Array.FindIndex<TrapDefenseLevelData>(list, delegate(TrapDefenseLevelData data)
			{
				int id = data.Id;
				TrapDefenseLevelData curSelectLevel = this.CurSelectLevel;
				int? num3 = (curSelectLevel != null) ? new int?(curSelectLevel.Id) : null;
				return id == num3.GetValueOrDefault() & num3 != null;
			});
			if (num >= 0)
			{
				return num;
			}
			int num2 = Array.FindIndex<TrapDefenseLevelData>(list, (TrapDefenseLevelData data) => !data.IsUnlock);
			if (num2 < 0)
			{
				return list.Length - 1;
			}
			if (num2 != 0)
			{
				return num2 - 1;
			}
			return 0;
		}

		// Token: 0x06033BFB RID: 211963 RVA: 0x00CEFB00 File Offset: 0x00CEDD00
		public void UpdateBdSumProgress()
		{
			TrapDefenseRougeModeData rougeModeData = ModelBase<TrapDefenseModel>.Instance.RougeModeData;
			UUIArtText artText = base.GetArtText(5);
			int unlockBdBuffSum = rougeModeData.GetUnlockBdBuffSum();
			int count = rougeModeData.BdBuffDataList.Count;
			UUIArtText uuiartText = artText;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(unlockBdBuffSum);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			uuiartText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06033BFC RID: 211964
		public abstract void UpdateModeData();

		// Token: 0x0401DF3C RID: 122684
		public TLevelModeData ModeData;

		// Token: 0x0401DF3D RID: 122685
		public TrapDefenseDifficultyChangePanel PanelDifficultyChange;

		// Token: 0x0401DF3E RID: 122686
		public GenericScrollViewNew<TrapDefenseLevelItem, TrapDefenseLevelData> ScrollLevel;

		// Token: 0x0401DF3F RID: 122687
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<TrapDefenseLevelData> OnSelectLevelCallback;

		// Token: 0x0401DF40 RID: 122688
		[Nullable(2)]
		public TrapDefenseLevelData CurSelectLevel;

		// Token: 0x0401DF41 RID: 122689
		public bool IsInstance;

		// Token: 0x0200ADB5 RID: 44469
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F14 RID: 220948
			public const int ItemDifficultyChange = 0;

			// Token: 0x04035F15 RID: 220949
			public const int ScrollLevel = 1;

			// Token: 0x04035F16 RID: 220950
			public const int ItemLevel = 2;

			// Token: 0x04035F17 RID: 220951
			public const int BtnBdSum = 3;

			// Token: 0x04035F18 RID: 220952
			public const int TextBdSumTitle = 4;

			// Token: 0x04035F19 RID: 220953
			public const int ArtTextBdProgress = 5;
		}
	}
}
