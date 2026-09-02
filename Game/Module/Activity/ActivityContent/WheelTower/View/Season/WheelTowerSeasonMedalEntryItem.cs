using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x02006235 RID: 25141
	[NullableContext(2)]
	[Nullable(0)]
	public class WheelTowerSeasonMedalEntryItem : UiPanelBase
	{
		// Token: 0x0603F67A RID: 259706 RVA: 0x0103FF48 File Offset: 0x0103E148
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnEntryBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F67B RID: 259707 RVA: 0x01040094 File Offset: 0x0103E294
		protected override UniTask OnBeforeStartAsync()
		{
			WheelTowerSeasonMedalEntryItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerSeasonMedalEntryItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F67C RID: 259708 RVA: 0x010400D8 File Offset: 0x0103E2D8
		public void Refresh(int seasonId)
		{
			List<IWheelTowerMedalGroupData> seasonMedalGroupList = ModelBase<WheelTowerModel>.Instance.GetSeasonMedalGroupList(seasonId, EWheelTowerMedalType.Season);
			if (seasonMedalGroupList.Count == 0)
			{
				base.SetUiActive(false);
				return;
			}
			base.SetUiActive(true);
			IWheelTowerMedalGroupData wheelTowerMedalGroupData = seasonMedalGroupList[0];
			IWheelTowerMedalGroupData wheelTowerMedalGroupData2 = (seasonMedalGroupList.Count >= 2) ? seasonMedalGroupList[1] : null;
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(wheelTowerMedalGroupData2 != null);
			}
			bool isMaxLevel = wheelTowerMedalGroupData.IsMaxLevel;
			bool flag = wheelTowerMedalGroupData2 == null || wheelTowerMedalGroupData2.IsMaxLevel;
			bool flag2 = false;
			bool flag3 = false;
			if (!isMaxLevel)
			{
				flag2 = true;
			}
			else if (wheelTowerMedalGroupData2 != null && !flag)
			{
				flag3 = true;
			}
			FColor highlightColor = FColor.FromHex("FFFFFF");
			FColor highlightColor2 = FColor.FromHex("FDFDBE");
			WheelTowerSeasonMedalPreviewItem leftPreview = this.LeftPreview;
			if (leftPreview != null)
			{
				leftPreview.Refresh(wheelTowerMedalGroupData, flag2, highlightColor);
			}
			if (wheelTowerMedalGroupData2 != null)
			{
				WheelTowerSeasonMedalPreviewItem rightPreview = this.RightPreview;
				if (rightPreview != null)
				{
					rightPreview.Refresh(wheelTowerMedalGroupData2, flag3, highlightColor2);
				}
			}
			this.ApplyScaleAndLayer(flag2, flag3, wheelTowerMedalGroupData2 != null);
			IWheelTowerMedalGroupData group = flag2 ? wheelTowerMedalGroupData : (flag3 ? wheelTowerMedalGroupData2 : (wheelTowerMedalGroupData2 ?? wheelTowerMedalGroupData));
			this.RefreshDescAndProgress(group);
		}

		// Token: 0x0603F67D RID: 259709 RVA: 0x010401EC File Offset: 0x0103E3EC
		private void ApplyScaleAndLayer(bool leftActive, bool rightActive, bool hasRight)
		{
			UUIItem item = base.GetItem(2);
			UUIItem item2 = base.GetItem(1);
			if (item == null || item2 == null)
			{
				return;
			}
			float num = leftActive ? 1f : 0.85f;
			UUIItem uuiitem = item;
			FVector fvector = new FVector(num, num, 1f);
			uuiitem.SetUIRelativeScale3D(fvector);
			if (hasRight)
			{
				float num2 = rightActive ? 1f : 0.85f;
				UUIItem uuiitem2 = item2;
				fvector = new FVector(num2, num2, 1f);
				uuiitem2.SetUIRelativeScale3D(fvector);
				if (leftActive)
				{
					item.SetHierarchyIndex(1);
					item2.SetHierarchyIndex(0);
					return;
				}
				if (rightActive)
				{
					item2.SetHierarchyIndex(1);
					item.SetHierarchyIndex(0);
				}
			}
		}

		// Token: 0x0603F67E RID: 259710 RVA: 0x01040284 File Offset: 0x0103E484
		[NullableContext(1)]
		private void RefreshDescAndProgress(IWheelTowerMedalGroupData group)
		{
			NewTowerMedal? lastMedalConfigByGroupId = WheelTowerUtil.GetLastMedalConfigByGroupId(group.GroupId);
			if (lastMedalConfigByGroupId != null)
			{
				LguiUtil instance = Singleton<LguiUtil>.Instance;
				UUIText text = base.GetText(6);
				string name = lastMedalConfigByGroupId.Value.Name;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("S");
				defaultInterpolatedStringHandler.AppendFormatted<int>(group.SeasonId);
				instance.SetLocalTextNew(text, name, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), lastMedalConfigByGroupId.Value.Desc, Array.Empty<object>());
			}
			int num = Math.Max(group.CurrentTarget, 1);
			float fillAmount = group.IsMaxLevel ? 1f : Math.Min((float)group.Progress / (float)num, 1f);
			UUIText text2 = base.GetText(4);
			if (text2 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(group.Progress);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(group.CurrentTarget);
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUITexture texture = base.GetTexture(5);
			if (texture == null)
			{
				return;
			}
			texture.SetFillAmount(fillAmount);
		}

		// Token: 0x0603F67F RID: 259711 RVA: 0x010403A5 File Offset: 0x0103E5A5
		private void OnEntryBtnClick()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.WheelTowerSeasonRewardView, null);
			ControllerBase<WheelTowerController>.Instance.OpenSeasonMedalView(0, false);
		}

		// Token: 0x04023925 RID: 145701
		private const float ACTIVE_SCALE = 1f;

		// Token: 0x04023926 RID: 145702
		private const float DIM_SCALE = 0.85f;

		// Token: 0x04023927 RID: 145703
		private const int MAX_DISPLAY_COUNT = 2;

		// Token: 0x04023928 RID: 145704
		private WheelTowerSeasonMedalPreviewItem LeftPreview;

		// Token: 0x04023929 RID: 145705
		private WheelTowerSeasonMedalPreviewItem RightPreview;
	}
}
