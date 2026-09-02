using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B70 RID: 19312
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class QuickNavigateLoopScrollAreaGridItem : GridProxyAbstract<QuickNavigateLoopScrollAreaGridItemData>
	{
		// Token: 0x0603273B RID: 206651 RVA: 0x00C9EEB8 File Offset: 0x00C9D0B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603273C RID: 206652 RVA: 0x00C9F003 File Offset: 0x00C9D203
		protected override void OnStart()
		{
			base.GetExtendToggle(3).bLockStateOnSelect = false;
			base.GetSprite(5).SetUIActive(false);
			base.GetSprite(6).SetUIActive(false);
		}

		// Token: 0x0603273D RID: 206653 RVA: 0x00C9F02C File Offset: 0x00C9D22C
		public override void Refresh(QuickNavigateLoopScrollAreaGridItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			int areaId = data.AreaNavigateInfo.AreaId;
			this.SetNameLocalText(ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId).Value.Title);
			if (data.RefreshType == ERefreshNavigateType.AreaOnly || data.RefreshType == ERefreshNavigateType.StateAndAreaBoth || data.RefreshType == ERefreshNavigateType.All)
			{
				this.UpdateToggleSetState();
			}
			if (MapUtil.GetWorldMapLevelOneAreaId() == areaId)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconCommonPlayer");
				base.GetSprite(0).SetUIActive(true);
				this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
			}
			else
			{
				int trackTaskAreaId = ModelBase<ExploreProgressModel>.Instance.TrackTaskAreaId;
				base.GetSprite(0).SetUIActive(trackTaskAreaId == areaId);
				if (trackTaskAreaId == areaId)
				{
					string trackTaskIconPath = ModelBase<ExploreProgressModel>.Instance.TrackTaskIconPath;
					this.SetSpriteByPath(trackTaskIconPath, base.GetSprite(0), false, null, null);
				}
			}
			List<int> onlinePlayerIndexListByAreaId = ModelBase<ExploreProgressModel>.Instance.GetOnlinePlayerIndexListByAreaId(areaId);
			foreach (int name in new int[]
			{
				5,
				6
			})
			{
				int num = (onlinePlayerIndexListByAreaId.Count > 0) ? onlinePlayerIndexListByAreaId[onlinePlayerIndexListByAreaId.Count - 1] : -1;
				if (onlinePlayerIndexListByAreaId.Count > 0)
				{
					onlinePlayerIndexListByAreaId.RemoveAt(onlinePlayerIndexListByAreaId.Count - 1);
				}
				UUISprite sprite = base.GetSprite(name);
				bool flag = num != -1;
				sprite.SetUIActive(flag);
				if (flag)
				{
					string resourceId = WorldMapDefine.OnlinePlayerIconPathList2[num - 1];
					string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
					this.SetSpriteByPath(resourcePath2, sprite, false, null, null);
				}
			}
		}

		// Token: 0x0603273E RID: 206654 RVA: 0x00C9F1DC File Offset: 0x00C9D3DC
		private void SetNameLocalText(string localTextId)
		{
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, localTextId, Array.Empty<object>());
		}

		// Token: 0x0603273F RID: 206655 RVA: 0x00C9F202 File Offset: 0x00C9D402
		private void OnClickToggle(EToggleState toggleState)
		{
			this.UpdateToggleSetState();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapSecondNavigateSelect, base.GridIndex);
		}

		// Token: 0x06032740 RID: 206656 RVA: 0x00C9F220 File Offset: 0x00C9D420
		private void UpdateToggleSetState()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (this.Data.IsSelected)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0401D6FF RID: 120575
		[Nullable(2)]
		private QuickNavigateLoopScrollAreaGridItemData Data;
	}
}
