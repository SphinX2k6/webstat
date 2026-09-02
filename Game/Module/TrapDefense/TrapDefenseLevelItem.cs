using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E2C RID: 20012
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseLevelItem : GridProxyAbstract<TrapDefenseLevelData>
	{
		// Token: 0x06033BB7 RID: 211895 RVA: 0x00CEE9B4 File Offset: 0x00CECBB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggleTextureTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggleSelf));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033BB8 RID: 211896 RVA: 0x00CEEB64 File Offset: 0x00CECD64
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseLevelItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseLevelItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033BB9 RID: 211897 RVA: 0x00CEEBA7 File Offset: 0x00CECDA7
		[Conditional("WITH_EDITOR")]
		private void EditorShowActorLabel()
		{
		}

		// Token: 0x06033BBA RID: 211898 RVA: 0x00CEEBAC File Offset: 0x00CECDAC
		public override UniTask RefreshAsync(TrapDefenseLevelData data, bool isSelected, int gridIndex)
		{
			TrapDefenseLevelItem.<RefreshAsync>d__7 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<TrapDefenseLevelItem.<RefreshAsync>d__7>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033BBB RID: 211899 RVA: 0x00CEEBF8 File Offset: 0x00CECDF8
		public void UpdateLevelBg()
		{
			bool isEndless = this.ItemData.IsEndless;
			UUIExtendToggleTextureTransition uiExtendToggleTextureTransition = base.GetUiExtendToggleTextureTransition(1);
			uiExtendToggleTextureTransition.RootUIComp.Get().SetUIActive(!isEndless);
			if (!isEndless)
			{
				base.SetExtendToggleTextureTransitionByPath(this.ItemData.Config.LevelNameImage, uiExtendToggleTextureTransition, EToggleTransitionState.ETT_MAX);
			}
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isEndless);
		}

		// Token: 0x06033BBC RID: 211900 RVA: 0x00CEEC5F File Offset: 0x00CECE5F
		public TrapDefenseLevelStarItem CreateItemStar()
		{
			return new TrapDefenseLevelStarItem();
		}

		// Token: 0x06033BBD RID: 211901 RVA: 0x00CEEC66 File Offset: 0x00CECE66
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			}
			Action<TrapDefenseLevelItem> onSelectLevelCallBack = this.OnSelectLevelCallBack;
			if (onSelectLevelCallBack == null)
			{
				return;
			}
			onSelectLevelCallBack(this);
		}

		// Token: 0x06033BBE RID: 211902 RVA: 0x00CEEC8F File Offset: 0x00CECE8F
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06033BBF RID: 211903 RVA: 0x00CEECA8 File Offset: 0x00CECEA8
		public void OnClickToggleSelf(EToggleState state)
		{
			ScrollViewDelegate<TrapDefenseLevelItem, TrapDefenseLevelData> scrollViewDelegate = base.ScrollViewDelegate as ScrollViewDelegate<TrapDefenseLevelItem, TrapDefenseLevelData>;
			int? num = (scrollViewDelegate != null) ? new int?(scrollViewDelegate.GetSelectedGridIndex()) : null;
			int gridIndex = base.GridIndex;
			if (num.GetValueOrDefault() == gridIndex & num != null)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(0);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			else
			{
				ModelBase<GuideModel>.Instance.FinishFocusGuideGroupOnView(EUiViewName.TrapDefenseMainLevelView);
				IScrollViewDelegate<IGridProxy<TrapDefenseLevelData>, TrapDefenseLevelData> scrollViewDelegate2 = base.ScrollViewDelegate;
				if (scrollViewDelegate2 == null)
				{
					return;
				}
				scrollViewDelegate2.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
				return;
			}
		}

		// Token: 0x0401DF2F RID: 122671
		public TrapDefenseLevelData ItemData;

		// Token: 0x0401DF30 RID: 122672
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<TrapDefenseLevelItem> OnSelectLevelCallBack;

		// Token: 0x0401DF31 RID: 122673
		public GenericLayout<TrapDefenseLevelStarItem, bool> LayoutStar;

		// Token: 0x0200ADA5 RID: 44453
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035ECA RID: 220874
			public const int ToggleSelf = 0;

			// Token: 0x04035ECB RID: 220875
			public const int TextureBg = 1;

			// Token: 0x04035ECC RID: 220876
			public const int ArtTextPosition = 2;

			// Token: 0x04035ECD RID: 220877
			public const int TextName = 3;

			// Token: 0x04035ECE RID: 220878
			public const int LayoutStar = 4;

			// Token: 0x04035ECF RID: 220879
			public const int ItemStar = 5;

			// Token: 0x04035ED0 RID: 220880
			public const int ItemEndlessTag = 6;

			// Token: 0x04035ED1 RID: 220881
			public const int ItemFinish = 7;

			// Token: 0x04035ED2 RID: 220882
			public const int ItemLock = 8;

			// Token: 0x04035ED3 RID: 220883
			public const int ItemRedDot = 9;
		}
	}
}
