using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle
{
	// Token: 0x02004BA0 RID: 19360
	[NullableContext(1)]
	[Nullable(0)]
	public class MapMarkTogglePanel : WorldMapSecondaryUi
	{
		// Token: 0x060328C6 RID: 207046 RVA: 0x00CA7698 File Offset: 0x00CA5898
		public override string GetResourceId()
		{
			return "UiView_MapPopupAssistant";
		}

		// Token: 0x060328C7 RID: 207047 RVA: 0x00CA76A0 File Offset: 0x00CA58A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060328C8 RID: 207048 RVA: 0x00CA776C File Offset: 0x00CA596C
		protected override UniTask OnBeforeStartAsync()
		{
			MapMarkTogglePanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapMarkTogglePanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060328C9 RID: 207049 RVA: 0x00CA77B0 File Offset: 0x00CA59B0
		protected override UniTask OnBeforeShowWorldMapSecondaryUiAsync(params object[] param)
		{
			MapMarkTogglePanel.<OnBeforeShowWorldMapSecondaryUiAsync>d__7 <OnBeforeShowWorldMapSecondaryUiAsync>d__;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>4__this = this;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.param = param;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>1__state = -1;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder.Start<MapMarkTogglePanel.<OnBeforeShowWorldMapSecondaryUiAsync>d__7>(ref <OnBeforeShowWorldMapSecondaryUiAsync>d__);
			return <OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060328CA RID: 207050 RVA: 0x00CA77FB File Offset: 0x00CA59FB
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
		}

		// Token: 0x060328CB RID: 207051 RVA: 0x00CA77FD File Offset: 0x00CA59FD
		protected override void OnCloseWorldMapSecondaryUi()
		{
		}

		// Token: 0x060328CC RID: 207052 RVA: 0x00CA77FF File Offset: 0x00CA59FF
		protected override void OnBeforeDestroy()
		{
			this.PopupCaption = null;
			this.MarkToggleLayout = null;
		}

		// Token: 0x060328CD RID: 207053 RVA: 0x00CA780F File Offset: 0x00CA5A0F
		protected override bool GetNeedBgItem()
		{
			return true;
		}

		// Token: 0x060328CE RID: 207054 RVA: 0x00CA7814 File Offset: 0x00CA5A14
		private IMapMarkToggleItemData[] GetMarkToggleDataList()
		{
			return new List<IMapMarkToggleItemData>
			{
				new MapMarkToggleItemData
				{
					NameId = "CustomMark_Text",
					GetToggleResultCallback = new Func<EToggleState>(this.GetCustomMarkToggleState),
					SetToggleStateCallback = new Func<EToggleState, bool>(this.SetCustomMarkToggleState)
				},
				new MapMarkToggleItemData
				{
					NameId = "CompletedGamePlayPoints_Text",
					GetToggleResultCallback = new Func<EToggleState>(this.GetFinishedPlayPointToggleState),
					SetToggleStateCallback = new Func<EToggleState, bool>(this.SetFinishedPlayPointToggleState)
				}
			}.ToArray();
		}

		// Token: 0x060328CF RID: 207055 RVA: 0x00CA789F File Offset: 0x00CA5A9F
		private EToggleState GetCustomMarkToggleState()
		{
			if (!ModelBase<WorldMapModel>.Instance.CustomMarksIsShow)
			{
				return EToggleState.ETT_UnChecked;
			}
			return EToggleState.ETT_Checked;
		}

		// Token: 0x060328D0 RID: 207056 RVA: 0x00CA78B0 File Offset: 0x00CA5AB0
		private bool SetCustomMarkToggleState(EToggleState state)
		{
			return ModelBase<WorldMapModel>.Instance.SetCustomMarksShow(state == EToggleState.ETT_Checked);
		}

		// Token: 0x060328D1 RID: 207057 RVA: 0x00CA78C0 File Offset: 0x00CA5AC0
		private EToggleState GetFinishedPlayPointToggleState()
		{
			if (!ModelBase<WorldMapModel>.Instance.CompletedPlayPointMarkIsShow)
			{
				return EToggleState.ETT_UnChecked;
			}
			return EToggleState.ETT_Checked;
		}

		// Token: 0x060328D2 RID: 207058 RVA: 0x00CA78D1 File Offset: 0x00CA5AD1
		private bool SetFinishedPlayPointToggleState(EToggleState state)
		{
			return ModelBase<WorldMapModel>.Instance.SetCompletedPlayPointMarkShow(state == EToggleState.ETT_Checked);
		}

		// Token: 0x060328D3 RID: 207059 RVA: 0x00CA78E4 File Offset: 0x00CA5AE4
		private IMapMarkProgressItemData[] GetMarkProgressDataList()
		{
			return new IMapMarkProgressItemData[]
			{
				new MapMarkProgressItemData
				{
					NameId = "GamePadMark_Text",
					Progress = ModelBase<WorldMapModel>.Instance.JoystickClickMultiplier,
					ProgressMax = ConfigCommonParamById.GetFloatConfig("MapJoystickClickMaxMultiplier").GetValueOrDefault(),
					ProgressMin = 0f,
					SetProgressCallback = new Action<float>(this.SetJoystickClickMultiplier)
				}
			};
		}

		// Token: 0x060328D4 RID: 207060 RVA: 0x00CA794F File Offset: 0x00CA5B4F
		private void SetJoystickClickMultiplier(float progress)
		{
			ModelBase<WorldMapModel>.Instance.SetJoystickClickMultiplier(progress);
		}

		// Token: 0x0401D787 RID: 120711
		[Nullable(2)]
		private PopupCaptionItem PopupCaption;

		// Token: 0x0401D788 RID: 120712
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<MapMarkToggleItem, IMapMarkToggleItemData> MarkToggleLayout;

		// Token: 0x0401D789 RID: 120713
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<MapMarkProgressItem, IMapMarkProgressItemData> MarkProgressLayout;

		// Token: 0x0200AC7C RID: 44156
		[NullableContext(0)]
		public static class EChildType
		{
			// Token: 0x040359DE RID: 219614
			public const int ItemCaption = 0;

			// Token: 0x040359DF RID: 219615
			public const int VerticalLayoutNote = 1;

			// Token: 0x040359E0 RID: 219616
			public const int ItemMarkToggle = 2;

			// Token: 0x040359E1 RID: 219617
			public const int VerticalLayoutProgress = 3;

			// Token: 0x040359E2 RID: 219618
			public const int PanelProgress = 4;
		}
	}
}
